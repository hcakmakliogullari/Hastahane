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
    public partial class frmAltGrup : Form
    {
        int _secimId = -1;
        bool _edit = false;
        Mesajlar _m = new Mesajlar();
        public bool Secim;
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
        public frmAltGrup()
        {
            InitializeComponent();
        }

        private void frmAltGrup_Load(object sender, EventArgs e)
        {
            if (Secim)
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                label2.Visible = false;
                txtAltGrAdi.Visible = false;
            }
            else
            {
                btnAltGrEkle.Visible = false;
            }
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = _db.TblAltGrups.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.AltGrup;

                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_secimId < 0) YeniKaydet();
        }
        void YeniKaydet()
        {
            try
            {
                TblAltGrup ag = new TblAltGrup();
                ag.AltGrup = txtAltGrAdi.Text;

                _db.TblAltGrups.InsertOnSubmit(ag);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt Başarılı");
                Temizle();

            }
            catch (Exception e)
            {

                _m.Hata(e);
            }
        }
        void Guncelle()
        {
            TblAltGrup ag= _db.TblAltGrups.First(x => x.Id == _secimId);
            ag.AltGrup = txtAltGrAdi.Text;
            _db.SubmitChanges();
            Temizle();
        }
        void Sil()
        {
            try
            {

                _db.TblAltGrups.DeleteOnSubmit(_db.TblAltGrups.First(x => x.Id == _secimId));
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
            txtAltGrAdi.Text = "";
            _edit = false;
            btnKaydet.Text = "Kaydet";
            _secimId = -1;
            Listele();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            if (!Secim)
            {
                try
                {
                    _edit = true;
                    btnKaydet.Text = "Güncelle";
                    txtAltGrAdi.Text = Liste.CurrentRow.Cells[1].Value.ToString();

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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
        string secili;
        private void btnAltGrEkle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Liste.RowCount; i++)
            {
                if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {
                    secili += Liste.Rows[i].Cells[1].Value.ToString() + ",";
                }
            }
            secili = secili.Remove(secili.Length - 1);
            frmAnasayfa.depo = secili;
            Close();
        }
    }

}
