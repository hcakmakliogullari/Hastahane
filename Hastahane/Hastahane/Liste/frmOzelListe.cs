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

namespace Hastahane.Liste
{
    public partial class frmOzelListe : Form
    {
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
        int kmin=-5, kmax=5000, tmin=-5, tmax=1000;
        string pat="", pks="";
        bool kan, tmr, pt, ps = false;
        public frmOzelListe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOzelListe_Load(object sender, EventArgs e)
        {
            //var pat = (from a in _db.Tbl_PatalojikVeris select a).ToList();
            //cbPat.Items.Add("");
            //foreach (var a in pat)
            //{
            //    if (!cbPat.Items.Contains(a.Patoloji))
            //    {
            //        cbPat.Items.Add(a.Patoloji);
            //    }
            //}

            Listele();
        }
        void Listele()
        {
            Liste.Columns.Clear();
            Liste.Columns.Add("ıd","Hasta Id");
            Liste.Columns.Add("pn","Prot No");
            Liste.Columns.Add("ad","Hasta Adı");
            Liste.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Liste.Columns.Add("soy","Soyadı");
            Liste.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Liste.Columns.Add("od","Operasyon Tarihi");
            
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
        private void button2_Click(object sender, EventArgs e)
        {
            kan = false;
            tmr = false;
            pt = false;
            ps = false;
            Liste.Columns.Clear();
            Liste.Columns.Clear();
            Liste.Columns.Add("ıd", "Hasta Id");
            Liste.Columns.Add("pn", "Prot No");
            Liste.Columns.Add("ad", "Hasta Adı");
            Liste.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Liste.Columns.Add("soy", "Soyadı");
            Liste.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Liste.Columns.Add("od", "Operasyon Tarihi");
            Liste.Columns.Add("txt", "Patoloji");
            Liste.Columns.Add("pks", "PKS");

            int tr = 0;
            int kn = 0;
            int p=0;
            int ks=0;
            if (txtTmrMin.Text!=""||txtTmrMax.Text!="")
            {
                tmr = true;

               Liste.Columns.Add("tmr","Tümör Boyut");
                if (txtTmrMin.Text != "")
                {
                    tmin = int.Parse(txtTmrMin.Text);
                }
                if (txtTmrMax.Text != "")
                {
                    tmax = int.Parse(txtTmrMax.Text);
                }
                tr++;
            }
            
            if (txtKanMin.Text != ""||txtKanMax.Text!="")
            {
                Liste.Columns.Add("kan","Kanama");
                kan = true;
                if (txtKanMin.Text != "")
                {
                    kmin = int.Parse(txtKanMin.Text);
                }
                if (txtKanMax.Text != "")
                {
                    kmax = int.Parse(txtKanMax.Text);
                }
               kn=tr+ 1;
            }
            else
            {
                kn = tr;
            }
//            if (cbPat.Text !="")
//            {
//                pt = true;
//                Liste.Columns.Add("txt","Patoloji");
//                p = kn + 1
//;            }
//            else
//            {
//                p = kn;
//            }
//            if (cbPks.Text != "")
//            {
//                ps = true;
//                Liste.Columns.Add("pks","PKS");
//                ks = p + 1;
//            }
            

            var hasta = (from s in _db.TblHastas where (_db.TblOperafs.First(x => x.HastaId == s.Id).Kanama) > kmin && (_db.TblOperafs.First(x => x.HastaId == s.Id).Kanama) < kmax && (_db.TblDemografs.First(x => x.HastaId == s.Id).Boyut) >= tmin &&(_db.TblDemografs.First(x => x.HastaId == s.Id).Boyut) <= kmax && (_db.Tbl_PatalojikVeris.First(x => x.HastaId == s.Id).Patoloji).Contains(cbPat.Text) && (_db.TblOperafs.First(x => x.HastaId == s.Id).PksAc).Contains(cbPks.Text) select s).ToList();



                         

            int i = 0;

            foreach (var s in hasta)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = s.Id;
                Liste.Rows[i].Cells[1].Value = s.Prot;
                Liste.Rows[i].Cells[2].Value = s.Ad;
                Liste.Rows[i].Cells[3].Value = s.Soyad;
                Liste.Rows[i].Cells[4].Value = s.Opttar;
                Liste.Rows[i].Cells[5].Value= _db.Tbl_PatalojikVeris.First(x => x.HastaId == s.Id).Patoloji;
                Liste.Rows[i].Cells[6].Value= _db.TblOperafs.First(x => x.HastaId == s.Id).PksAc;
                if (tmr)
                {
                    Liste.Rows[i].Cells[6 + tr].Value = _db.TblDemografs.First(x => x.HastaId == s.Id).Boyut;
                }
                if (kan)
                {
                    Liste.Rows[i].Cells[6 + kn].Value = _db.TblOperafs.First(x => x.HastaId == s.Id).Kanama;
                }
                //if (pt)
                //{
                //    Liste.Rows[i].Cells[4 + p].Value = _db.Tbl_PatalojikVeris.First(x => x.HastaId == s.Id).Patoloji;
                //}
                //if (ps)
                //{
                //    Liste.Rows[i].Cells[4 + ks].Value = _db.TblOperafs.First(x => x.HastaId == s.Id).PksAc;
                //}
                i++;


            }


        }

        //private void txtKanMin_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtKanMin.Text!= "" &&txtKanMax.Text=="")
        //    {
        //        btnFiltrele.Enabled = false;
        //    }
        //    else if (txtKanMax.Text == "" && txtKanMax.Text == "")
        //    {
        //        btnFiltrele.Enabled = true;
        //    }

        //}

        //private void txtTmrMin_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtTmrMin.Text!="" && txtTmrMax.Text == "")
        //    {
        //        btnFiltrele.Enabled = false;
        //    }
        //    else if (txtTmrMin.Text == "" && txtTmrMax.Text == "")            {
        //        btnFiltrele.Enabled = true;
        //    }
        //}

        //private void txtKanMax_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtKanMin.Text!=""&&txtKanMax.Text!="")
        //    {
        //        btnFiltrele.Enabled = true;
        //    }
        //    else if(txtKanMin.Text=="" && txtKanMax.Text!="")
        //    {
        //        btnFiltrele.Enabled = false;
        //    }
        //    else if (txtKanMin.Text=="" && txtKanMax.Text=="")
        //    {
        //        btnFiltrele.Enabled=
        //    }
        //}
    }
}
