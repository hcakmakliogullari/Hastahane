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
    public partial class frmHastaListesi : Form
    {
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
            public bool Secim;
        Mesajlar _m = new Mesajlar();
        public frmHastaListesi()
        {
            InitializeComponent();
        }

        private void frmHastaListesi_Load(object sender, EventArgs e)
        {
            Liste.ReadOnly = true;
            if (Secim)
            {
                btnSil.Visible = false;
            }
            else
            {
                btnSil.Visible = true;
            }

            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var hasta = (from s in _db.TblHastas select s).ToList();
            foreach (var s in hasta)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = s.Id;
                Liste.Rows[i].Cells[1].Value = s.Prot;
                Liste.Rows[i].Cells[2].Value = s.Ad;
                Liste.Rows[i].Cells[3].Value = s.Soyad;
                Liste.Rows[i].Cells[4].Value = s.Opttar;
                i++;
            }
        }
        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            if (Secim && Liste.CurrentRow.Cells[0].Value!=null)
            {
                frmAnasayfa.aktarma = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
                Close();
            }
            else
            {

                if (Liste.CurrentRow.DefaultCellStyle.BackColor == Color.Red && Liste.CurrentRow.Cells[0].Value != null)
                {
                    Liste.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    bool sec = true;
                    for (int i = 0; i < Liste.RowCount; i++)
                    {
                        if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                        {
                            sec = false;
                        }

                    }
                    if (sec&& Liste.CurrentRow.Cells[0].Value != null)
                    {
                        Liste.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            Liste.ClearSelection();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_m.Sil() == DialogResult.Yes) Sil();
            Listele();
        }
        void Sil()
        {
            try
            {
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    if (Liste.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                    {
                       
                        _db.TblHastas.DeleteOnSubmit(_db.TblHastas.First(x => x.Id == int.Parse(Liste.Rows[i].Cells[0].Value.ToString())));
                        _db.SubmitChanges();

                    }
                }
            }
            catch (Exception em )
            {

                _m.Hata(em);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Liste.Rows.Clear();
            int i = 0;
            var hst = (from s in _db.TblHastas select s).ToList();
            foreach (var s in hst)
            {
                if (s.Ad.Contains(txtHastaBul.Text)||s.Soyad.Contains(txtHastaBul.Text))
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = s.Id;
                    Liste.Rows[i].Cells[1].Value = s.Prot;
                    Liste.Rows[i].Cells[2].Value = s.Ad;
                    Liste.Rows[i].Cells[3].Value = s.Soyad;
                    Liste.Rows[i].Cells[4].Value = s.Opttar;
                    i++;

                }
            }
        }
    }

    
}

