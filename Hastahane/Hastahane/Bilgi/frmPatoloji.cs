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
    public partial class frmPatoloji : Form
    {
        int _secimId = -1;
        bool _edit = false;
        Mesajlar _m = new Mesajlar();
        public bool Secim;
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
        public frmPatoloji()
        {
            InitializeComponent();
        }

        private void frmPatoloji_Load(object sender, EventArgs e)
        {
            if (Secim)
            {
                btnKaydet.Visible = false;
                btnSil.Visible = false;
                label2.Visible = false;
                txtPatAdi.Visible = false;
            }
            else
            {
                btnPatEkle.Visible = false;
            }
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = _db.TblPatolojis.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.Patoloji;

                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtPatAdi.Text!="" && _edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (txtPatAdi.Text != ""&&_secimId < 0) YeniKaydet();
        }
        void YeniKaydet()
        {
            try
            {
                TblPatoloji pat = new TblPatoloji();
                pat.Patoloji = txtPatAdi.Text;

                _db.TblPatolojis.InsertOnSubmit(pat);
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
            TblPatoloji pat = _db.TblPatolojis.First(x => x.Id == _secimId);
            pat.Patoloji = txtPatAdi.Text;
            _db.SubmitChanges();
            Temizle();
        }
        void Sil()
        {
            try
            {

                _db.TblPatolojis.DeleteOnSubmit(_db.TblPatolojis.First(x => x.Id == _secimId));
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
            txtPatAdi.Text = "";
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
                    txtPatAdi.Text = Liste.CurrentRow.Cells[1].Value.ToString();

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

                   
                }
            }
            Liste.ClearSelection();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes) Sil();
        }
        string secili;

        private void btnPatEkle_Click(object sender, EventArgs e)
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPatAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
