using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hastahane.Modal;

namespace Hastahane.Bilgi
{
    public partial class frmKomorbidite : Form
    {
        int _secimId = -1;
        bool _edit = false;
        Mesajlar _m = new Mesajlar();
        public bool Secim;
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
        public frmKomorbidite()
        {
            InitializeComponent();
        }

        private void frmKomorbidite_Load(object sender, EventArgs e)
        {
            if (Secim)
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                label2.Visible = false;
                txtMorbAd.Visible = false;
            }
            else
            {
                btnOpEkle.Visible = false;
            }
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = _db.TblKomorbidites.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.KomorbiditeAdı;

                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            if (!Secim)
            {
                try
                {
                    _edit = true;
                    btnKaydet.Text = "Güncelle";
                    txtMorbAd.Text = Liste.CurrentRow.Cells[1].Value.ToString();

                    _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());

                }
                catch (Exception)
                {

                    _edit = false;
                    btnKaydet.Text = "Kaydet";
                    _secimId = -1;
                }
            }
            else
            {
                try
                {
                    if (Liste.CurrentRow.DefaultCellStyle.BackColor == Color.Green)
                    {
                        Liste.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        Liste.CurrentRow.DefaultCellStyle.BackColor = Color.Green;
                    }

                }
                catch (Exception ex)
                {

                    _m.Hata(ex);
                }
            }
            Liste.ClearSelection();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_secimId < 0) YeniKaydet();
        }
        void Guncelle()
        {
            TblKomorbidite Ot = _db.TblKomorbidites.First(x => x.Id == _secimId);
            Ot.KomorbiditeAdı = txtMorbAd.Text;
            _db.SubmitChanges();
            Temizle();
        }
        void YeniKaydet()
        {
            try
            {
                TblKomorbidite kom = new TblKomorbidite();
                kom.KomorbiditeAdı = txtMorbAd.Text;

                _db.TblKomorbidites.InsertOnSubmit(kom);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt Başarılı");
                Temizle();

            }
            catch (Exception e)
            {

                _m.Hata(e);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes) Sil();
        }
        void Sil()
        {
            try
            {

                _db.TblKomorbidites.DeleteOnSubmit(_db.TblKomorbidites.First(x => x.Id == _secimId));
                _db.SubmitChanges();
                MessageBox.Show("Kayıt Silindi");
                Temizle();


            }
            catch (Exception e)
            {

                _m.Hata(e);

            }
        }
        void Temizle()
        {
            txtMorbAd.Text = "";
            _edit = false;
            btnKaydet.Text = "Kaydet";
            _secimId = -1;
            Listele();
        }
        string komorb;
        private void btnOpEkle_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < Liste.RowCount; i++)
                {
                    if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                    {
                        komorb += Liste.Rows[i].Cells[1].Value.ToString() + ",";
                    }
                }
                komorb = komorb.Remove(komorb.Length - 1);
                frmAnasayfa.depo = komorb;
                Close();
            }
            catch (Exception )
            {

                
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
