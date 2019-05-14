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
    public partial class OpTuruGiris : Form
    {
        int _secimId = -1;
        bool _edit = false;
        Mesajlar _m = new Mesajlar();
        public bool Secim;
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();

        public OpTuruGiris()
        {
            InitializeComponent();
        }

       
        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = _db.TblOpTurus.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.OpTuru;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
        void Guncelle()
        {
            TblOpTuru Ot = _db.TblOpTurus.First(x=>x.Id== _secimId);
            Ot.OpTuru = txtOpAD.Text;
            _db.SubmitChanges();
            Temizle();
        }
        void Temizle()
        {
            txtOpAD.Text = "";
            _edit = false;
            btnKaydet.Text = "Kaydet";
            _secimId = -1;
            Listele();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes) Sil();
        }
        void Sil()
        {
            try
            {

                _db.TblOpTurus.DeleteOnSubmit(_db.TblOpTurus.First(x => x.Id == _secimId));
                _db.SubmitChanges();
                MessageBox.Show("Kayıt Silindi");
                Temizle();


            }
            catch (Exception e)
            {

                _m.Hata(e);
            }
        }

        private void OpTuruGiris_Load(object sender, EventArgs e)
        {
            if (Secim)
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                label2.Visible = false;
                txtOpAD.Visible = false;
            }
            else
            {
                btnOpEkle.Visible = false;
            }
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
                    txtOpAD.Text = Liste.CurrentRow.Cells[1].Value.ToString();

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
        void YeniKaydet()
        {
            try
            {
                TblOpTuru Opt = new TblOpTuru();
                Opt.OpTuru = txtOpAD.Text;
              
                _db.TblOpTurus.InsertOnSubmit(Opt);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt Başarılı");
                Temizle();

            }
            catch (Exception e)
            {

                _m.Hata(e);
            }
        }
        string ops;
        private void btnOpEkle_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                    {
                        ops += Liste.Rows[i].Cells[1].Value.ToString() + ",";
                    }
                }
                ops = ops.Remove(ops.Length - 1);
                frmAnasayfa.depo = ops;
                Close();
            }
            catch (Exception)
            {

            
            }
        }
    }
}
