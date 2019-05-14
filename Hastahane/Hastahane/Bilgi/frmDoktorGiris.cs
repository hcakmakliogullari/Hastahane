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
    public partial class frmDoktorGiris : Form
    {
        int _secimId = -1;
        bool _edit = false;
        public bool Secim = false;
        Mesajlar _m = new Mesajlar();
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
    

        public frmDoktorGiris()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_secimId < 0) YeniKaydet();
        }
        void Guncelle()
        {
            TblDoktor dr = _db.TblDoktors.First(x => x.Id == _secimId);
            dr.DoktorAdi = txtDad.Text;
            dr.DoktorSoyad = txtDsoyad.Text;
            _db.SubmitChanges();
            Temizle();
        }
        void Temizle()
        {
            txtDad.Text = "";
            txtDsoyad.Text = "";


            _edit = false;
            btnKaydet.Text = "Kaydet";
            _secimId = -1;
            Listele();
        }
        void YeniKaydet()
        {
            try
            {
                TblDoktor dr = new TblDoktor();
                dr.DoktorAdi = txtDad.Text;
                dr.DoktorSoyad = txtDsoyad.Text;
                _db.TblDoktors.InsertOnSubmit(dr);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt Başarılı");
                Temizle();

            }
            catch (Exception e )
            {

                _m.Hata(e);
            }
            
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = _db.TblDoktors.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.DoktorAdi;
                Liste.Rows[i].Cells[2].Value = k.DoktorSoyad;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
        private void frmDoktorGiris_Load(object sender, EventArgs e)
        {
            if (Secim)
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
                txtDad.Visible = false;
                txtDsoyad.Visible = false;
            }
            else
            {
                btnDrEkle.Visible = false;
            }
            Listele();
        }
        void Sil()
        {
            try
            {
                
                    _db.TblDoktors.DeleteOnSubmit(_db.TblDoktors.First(x => x.Id == _secimId));
                    _db.SubmitChanges();
                    MessageBox.Show("Kayıt Silindi");
                Temizle();
                   
                
            }
            catch (Exception e )
            {

                _m.Hata(e);
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _edit = true;
                btnKaydet.Text = "Güncelle";
                txtDad.Text = Liste.CurrentRow.Cells[1].Value.ToString();
                txtDsoyad.Text = Liste.CurrentRow.Cells[2].Value.ToString();
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception)
            {

                _edit = false;
                btnKaydet.Text = "Kaydet";
                _secimId = -1;
            }
            if (Secim)
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
            if (_edit&&_secimId>0&& _m.Sil() == DialogResult.Yes) Sil();
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
         string doktorlar;
        private void btnDrEkle_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < Liste.RowCount; i++)
            {
                if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {

                  doktorlar += Liste.Rows[i].Cells[1].Value.ToString() +",";
                   
                }
            }
            doktorlar = doktorlar.Remove(doktorlar.Length - 1);
            frmAnasayfa.depo = doktorlar;
            Close();
        }
    }
}
