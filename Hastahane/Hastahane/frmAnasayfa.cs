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

namespace Hastahane
{
    public partial class frmAnasayfa : Form
    {
        public static int aktarma;
        public static string depo;
        Modal.Formlar _f = new Modal.Formlar();
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        private void btnBolum1_Click(object sender, EventArgs e)
        {
            pnlLeft1.Visible = true;
            pnlLeft2.Visible = false;
            pnlLeft3.Visible = false;
            grpLeft.Text = "Bölüm-1 Giriş İşlemleri";
            grpLeft.BackColor = Color.Silver;
            grpLeft.ForeColor = Color.White;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            _f.HastaGiris();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpTur_Click(object sender, EventArgs e)
        {
            _f.DoktorGiris();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _f.Opturu();
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            _f.MorbiditeGiris();
        }

        private void btnLokalEkle_Click(object sender, EventArgs e)
        {
            _f.LokalizasyonGiris();
        }

        private void btnPatGiris_Click(object sender, EventArgs e)
        {
            _f.PatolojiGiris();
        }

        private void btnAltGrupGiris_Click(object sender, EventArgs e)
        {
            _f.AltGrupGiris();
        }

        private void btnHastaList_Click(object sender, EventArgs e)
        {
            _f.HastaList();
        }

        private void btnOzelListe_Click(object sender, EventArgs e)
        {
            _f.OzelList();
        }
    }
}
