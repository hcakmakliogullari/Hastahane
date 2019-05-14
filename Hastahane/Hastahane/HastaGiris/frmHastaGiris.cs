using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hastahane.Modal;
namespace Hastahane.HastaGiris
{
    public partial class frmHastaGiris : Form
    {
       int _secimId=-1;
        bool _edit=false;

        Formlar _f = new Formlar();
        Mesajlar _m = new Mesajlar();
        PosterolateralDbDataContext _db = new PosterolateralDbDataContext();
        public frmHastaGiris()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void frmHastaGiris_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            var btnoptur = new Button();
            btnoptur.Size = new Size(25, txtOpTur.ClientSize.Height + 2);
            btnoptur.Location = new Point(txtOpTur.ClientSize.Width - btnoptur.Width, -1);
            btnoptur.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtOpTur.Controls.Add(btnoptur);
            SendMessage(txtOpTur.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnoptur.Width << 16));
            btnoptur.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btndr = new Button();
            btndr.Size = new Size(25, txtDr.ClientSize.Height + 2);
            btndr.Location = new Point(txtDr.ClientSize.Width - btndr.Width, -1);
            btndr.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtDr.Controls.Add(btndr);

            var btnmorb = new Button();
            btnmorb.Size = new Size(25, txtKoMorb.ClientSize.Height + 2);
            btnmorb.Location = new Point(txtKoMorb.ClientSize.Width - btnmorb.Width, -1);
            btnmorb.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtKoMorb.Controls.Add(btnmorb);

            var btnlok = new Button();
            btnlok.Size = new Size(25, txtLokalizasyon.ClientSize.Height + 2);
            btnlok.Location = new Point(txtLokalizasyon.ClientSize.Width - btnlok.Width, -1);
            btnlok.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtLokalizasyon.Controls.Add(btnlok);

            var btnpat = new Button();
            btnpat.Size = new Size(25, txtPatoloji.ClientSize.Height + 2);
            btnpat.Location = new Point(txtPatoloji.ClientSize.Width - btnpat.Width, -1);
            btnpat.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtPatoloji.Controls.Add(btnpat);

            var btnag = new Button();
            btnag.Size = new Size(25, txtAltGrup.ClientSize.Height + 2);
            btnag.Location = new Point(txtAltGrup.ClientSize.Width - btnag.Width, -1);
            btnag.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtAltGrup.Controls.Add(btnag);

            var btnhst = new Button();
                btnhst.Size = new Size(25, txtAd.ClientSize.Height + 2);
                btnhst.Location = new Point(txtAd.ClientSize.Width -btnhst.Width, -1);
                btnhst.Cursor = Cursors.Default;
            //btnoptur.Image = Resources.arrow1;
            txtAd.Controls.Add(btnhst);

            SendMessage(txtDr.Handle, 0xd3, (IntPtr)2, (IntPtr)(btndr.Width << 16));
            btndr.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btnoptur.Click += btnoptur_Click;
            btndr.Click += btndr_Click;
            btnmorb.Click += btnmorb_Click;
            btnlok.Click += btnlok_Click;
            btnpat.Click += btnpat_Click;
            btnag.Click += btnag_Click;
            btnhst.Click += btnhst_Click;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        private void btnoptur_Click(object sender, EventArgs e)
        {
            _f.Opturu(true);

            txtOpTur.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";
        }
        
        private void btndr_Click(object sender, EventArgs e)
        {
            _f.DoktorGiris(true);

            txtDr.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";

        }

        private void btnmorb_Click(object sender, EventArgs e)
        {
            _f.MorbiditeGiris(true);
            txtKoMorb.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";
        }

        private void btnhst_Click(object sender, EventArgs e)
        {
            try
            {
                BilgiGetir();
            }
            catch (Exception)
            {

               
            }
        }
        void Temizle()
        {
            foreach (TabPage s in this.tabControl1.TabPages)
            {

                dtpOpTarih.Value = DateTime.Now;
                foreach (Control item in s.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.Clear();
                    }
                    if (item is MaskedTextBox)
                    {
                        MaskedTextBox txt = item as MaskedTextBox;
                        txt.Clear();
                    }
                    if (item is ComboBox)
                    {
                        ComboBox cbx = item as ComboBox;
                        cbx.Text = "";
                    }
                }
            }
          _secimId = -1;
          _edit = false;
          btnKaydet.Text = "Kaydet";

        }
        void BilgiGetir()
        {
            _f.HastaList(true);
            _secimId = frmAnasayfa.aktarma;
            
            frmAnasayfa.aktarma = -1;
            if (_secimId>0)
            {   _edit = true;
                btnKaydet.Text = "GÜNCELLE"; 
            }
            TblHasta hst = new TblHasta();

            hst = _db.TblHastas.First(x => x.Id == _secimId);
            txtAd.Text = hst.Ad;
            txtSoyad.Text = hst.Soyad;
            txtProtokolNo.Text = hst.Prot;
            dtpOpTarih.Text = hst.Opttar.ToString();
            txtOpTur.Text = hst.Opttur;
            txtTakip.Text = hst.Takip.ToString();
            txtAnah.Text = hst.Anah.ToString();

            TblDemograf hd = _db.TblDemografs.First(x => x.HastaId == _secimId);
            txtYas.Text = hd.Yas.ToString();
            txtBoy.Text = hd.Boy.ToString();
            txtKilo.Text = hd.Kilo.ToString();
            txtBMI.Text = hd.BMI.ToString();
            cbAsa.Text = hd.ASA.ToString();
            txtDr.Text = hd.Dr;
            cbCins.Text = hd.Cins;
            cbTaraf.Text = hd.Taraf;
            txtLokalizasyon.Text = hd.Lklzsyn;
            txtBoyut.Text = hd.Boyut.ToString();
            txtKoMorb.Text = hd.Komorbid;

            Tbl_PatalojikVeri pv = _db.Tbl_PatalojikVeris.First(x => x.HastaId == _secimId);

            txtPatoloji.Text = pv.Patoloji;
            txtAltGrup.Text = pv.AltGr;
            cbFuhrman.Text = pv.FurhmanGrade;
            cbPatEvre.Text = pv.PatolojikEvre;
            cbCerrahiSinir.Text = pv.CerrahiSinir;

            TblOperaf op = _db.TblOperafs.First(x => x.HastaId == _secimId);

            cbPksAciklama.Text = op.PksAc;
            cbSIK.Text = op.SIK;
            txtCoop.Text = op.Coop;
            txtIskemi.Text = op.Iskemi.ToString();
            txtPortSay.Text = op.Portsay.ToString();
            txtYardimYnt.Text = op.Yrdmynt;
            txtSure.Text = op.Sure.ToString();
            txtDren.Text = op.Dren.ToString();
            txtKanama.Text = op.Kanama.ToString();
            txtPiyes.Text = op.Piyes.ToString();

            TblPosOperaf po = _db.TblPosOperafs.First(x => x.HastaId == _secimId);

            cbPerErKom.Text = po.PeropErkenKomp;
            txtPosAnaliz.Text = po.PostopAn;
            cbSonda.Text = po.Sonda;
            mtbPreobKeratin.Text = po.preopKeratin.ToString();
            mtbPostopKeratin.Text = po.PostopKreatin.ToString();
            mtbPreopHct.Text = po.PreopHtc.ToString();
            mtbPostopHct.Text = po.PostopHct.ToString();
            mtbPreopHb.Text = po.PreobHb.ToString();
            mtbPostopHb.Text = po.PostopHb.ToString();
            txtPosTakip.Text = po.Takip;
            txtTel.Text = po.Tel;
            txtPostopGecKomp.Text = po.PostopGecKomp;
            txtKompClavien.Text = po.KompClavien;

       


            TblTakip tkp = _db.TblTakips.First(x => x.HastaId == _secimId);

            cb3Nuks.Text = tkp.Postop3Lkl;
            mtbPost3Kerat.Text = tkp.Postop3Krtn.ToString();

            cbNuks6.Text = tkp.Postop6Lkl;
            mtbPost6Kerat.Text = tkp.Postop6Krtn.ToString();

            cbNuks12.Text = tkp.Postop12Lkl;
            mtbPost12Kerat.Text = tkp.Postop12Krtn.ToString();
            
        }

        private void btnlok_Click(object sender, EventArgs e)
        {
            _f.LokalizasyonGiris(true);

            txtLokalizasyon.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";

        }

        private void btnpat_Click(object sender, EventArgs e)
        {
            _f.PatolojiGiris(true);

            txtPatoloji.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";

        }
        private void btnag_Click(object sender, EventArgs e)
        {
            _f.AltGrupGiris(true);

            txtAltGrup.Text = frmAnasayfa.depo;
            frmAnasayfa.depo = "";

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_secimId < 0) YeniKaydet();
            Temizle();
        }
        void Guncelle()
        {
            try
            {
                TblHasta hasta = _db.TblHastas.First(x=>x.Id==_secimId);
                try
                {
                    PosterolateralDbDataContext _db = new PosterolateralDbDataContext();

                    hasta.Ad = txtAd.Text;
                    hasta.Soyad = txtSoyad.Text;
                    hasta.Prot = txtProtokolNo.Text;
                    hasta.Opttar = DateTime.Parse(dtpOpTarih.Text);
                    hasta.Opttur = txtOpTur.Text;
                    hasta.Takip = int.Parse(txtTakip.Text);
                    hasta.Anah = int.Parse(txtAnah.Text);
                    //_db.TblHastas.InsertOnSubmit(hasta);
                    _db.SubmitChanges();
                }
                catch (Exception es)
                {
                    _m.Hata(es);
                }

                TblDemograf demog = _db.TblDemografs.First(x => x.HastaId == _secimId);
                try
                {

                    //demog.HastaId = hasta.Id;
                    demog.Yas = txtYas.Text != "" ? int.Parse(txtYas.Text) : -1;
                    demog.Kilo = txtKilo.Text != "" ? decimal.Parse(txtKilo.Text) : -1;
                    demog.Boy = txtBoy.Text != "" ? int.Parse(txtBoy.Text) : -1;
                    demog.BMI = Convert.ToInt16((demog.Kilo * 10000) / (demog.Boy * demog.Boy));
                    demog.ASA = cbAsa.Text != "" ? int.Parse(cbAsa.Text) : -1;
                    demog.Dr = txtDr.Text;
                    demog.Cins = cbCins.Text;
                    demog.Taraf = cbTaraf.Text;
                    demog.Lklzsyn = txtLokalizasyon.Text;
                    demog.Boyut = txtBoyut.Text !=""? int.Parse(txtBoyut.Text):-1;
                    demog.Komorbid = txtKoMorb.Text;

                    //_db.TblDemografs.InsertOnSubmit(demog);
                }
                catch (Exception ed)
                {

                    _m.Hata(ed);
                }

                TblOperaf op = _db.TblOperafs.First(x => x.HastaId == _secimId);


                try
                {
                    //op.HastaId = hasta.Id;

                    op.PksAc = cbPksAciklama.Text;
                    op.SIK = cbSIK.Text;
                    op.Coop = txtCoop.Text;
                    op.Iskemi = txtIskemi.Text != "" ? int.Parse(txtIskemi.Text) : -1;
                    op.Portsay = txtPortSay.Text != "" ? int.Parse(txtPortSay.Text) : -1;
                    op.Yrdmynt = txtYardimYnt.Text;
                    op.Sure = txtSure.Text != "" ? int.Parse(txtSure.Text) : -1;
                    op.Dren = txtDren.Text != "" ? int.Parse(txtDren.Text) : -1;
                    op.Kanama = txtKanama.Text != "" ? int.Parse(txtKanama.Text) : -1;
                    op.Piyes = txtPiyes.Text != "" ? int.Parse(txtPiyes.Text) : -1;

                    //_db.TblOperafs.InsertOnSubmit(op);

                }
                catch (Exception eo)
                {

                    _m.Hata(eo);
                }

                TblPosOperaf po =_db.TblPosOperafs.First(x => x.HastaId == _secimId);

                try
                {
                    //po.HastaId = hasta.Id;
                    po.PeropErkenKomp = cbPerErKom.Text;
                    po.PostopAn = txtPosAnaliz.Text;
                    po.Sonda = cbSonda.Text;
                    po.HospSur = txtHospSure.Text != "" ? int.Parse(txtHospSure.Text) : -1;
                    po.preopKeratin = mtbPreobKeratin.Text != "" ? decimal.Parse(mtbPreobKeratin.Text) : -1;
                    po.PostopKreatin = mtbPostopKeratin.Text != "" ? decimal.Parse(mtbPostopKeratin.Text) : -1;
                    po.PreopHtc = mtbPreopHct.Text != "" ? decimal.Parse(mtbPreopHct.Text) : -1;
                    po.PostopHct = mtbPostopHct.Text != "" ? decimal.Parse(mtbPostopHct.Text) : -1;
                    po.PreobHb = mtbPreopHb.Text != "" ? decimal.Parse(mtbPreopHb.Text) : -1;
                    po.PostopHb = mtbPostopHb.Text != "" ? decimal.Parse(mtbPostopHb.Text) : -1;
                    po.Takip = txtPosTakip.Text;
                    po.Tel = txtTel.Text;
                    po.PostopGecKomp = txtPostopGecKomp.Text;
                    po.KompClavien = txtKompClavien.Text;

                    //_db.TblPosOperafs.InsertOnSubmit(po);
                }
                catch (Exception p)
                {

                    _m.Hata(p);
                }
                Tbl_PatalojikVeri pa = _db.Tbl_PatalojikVeris.First(x => x.HastaId == _secimId);

                try
                {
                    //pa.HastaId = hasta.Id;
                    pa.Patoloji = txtPatoloji.Text;
                    pa.AltGr = txtAltGrup.Text;
                    pa.FurhmanGrade = cbFuhrman.Text;
                    pa.PatolojikEvre = cbPatEvre.Text;
                    pa.CerrahiSinir = cbCerrahiSinir.Text;

                    //_db.Tbl_PatalojikVeris.InsertOnSubmit(pa);
                }
                catch (Exception a)
                {

                    _m.Hata(a);
                }
                TblTakip tkp = _db.TblTakips.First(x => x.HastaId == _secimId);
                try
                {
                    //tkp.HastaId = hasta.Id;

                    tkp.Postop3Lkl = cb3Nuks.Text;
                    tkp.Postop3Krtn = mtbPost3Kerat.Text != "" ? decimal.Parse(mtbPost3Kerat.Text) : -1;

                    tkp.Postop6Lkl = cbNuks6.Text;
                    tkp.Postop6Krtn = mtbPost6Kerat.Text != "" ? decimal.Parse(mtbPost6Kerat.Text) : -1;

                    tkp.Postop12Lkl = cbNuks12.Text;
                    tkp.Postop12Krtn = mtbPost12Kerat.Text != "" ? decimal.Parse(mtbPost12Kerat.Text) : -1;

                    //_db.TblTakips.InsertOnSubmit(tkp);
                }
                catch (Exception t)
                {
                    _m.Hata(t);
                }




                _db.SubmitChanges();


                MessageBox.Show("Güncelleme Başarılı");
                Temizle();
            }
            catch (Exception d)
            {

                _m.Hata(d);
            }
        }
        void YeniKaydet()
        { 
            try
            {
                TblHasta hasta = new TblHasta();
                try
                {
                    PosterolateralDbDataContext _db = new PosterolateralDbDataContext();

        hasta.Ad = txtAd.Text;
                    hasta.Soyad = txtSoyad.Text;
                    hasta.Prot = txtProtokolNo.Text;
                    hasta.Opttar = DateTime.Parse(dtpOpTarih.Text);
                    hasta.Opttur = txtOpTur.Text;
                    hasta.Takip = int.Parse(txtTakip.Text);
        hasta.Anah = int.Parse(txtAnah.Text);
        _db.TblHastas.InsertOnSubmit(hasta);
                    _db.SubmitChanges();
                }
                catch (Exception es)
                {


                    _m.Hata(es);
                }

TblDemograf demog = new TblDemograf();
                try
                {

                    demog.HastaId = hasta.Id;
                    demog.Yas = txtYas.Text != "" ? int.Parse(txtYas.Text) : -1;
                    demog.Kilo = txtKilo.Text != "" ? decimal.Parse(txtKilo.Text) : -1;
                    demog.Boy = txtBoy.Text != "" ? int.Parse(txtBoy.Text) : -1;
                    demog.BMI = Convert.ToInt16((demog.Kilo* 10000) / (demog.Boy* demog.Boy));
                    demog.ASA = cbAsa.Text != "" ? int.Parse(cbAsa.Text) : -1;
                    demog.Dr = txtDr.Text;
                    demog.Cins = cbCins.Text;
                    demog.Taraf = cbTaraf.Text;
                    demog.Lklzsyn = txtLokalizasyon.Text;
                    demog.Boyut = txtBoyut.Text!=""?int.Parse(txtBoyut.Text):-1;
                    demog.Komorbid = txtKoMorb.Text;

                    _db.TblDemografs.InsertOnSubmit(demog);
                }
                catch (Exception ed)
                {

                    _m.Hata(ed);
                }

                TblOperaf op = new TblOperaf();


                try
                {
                    op.HastaId = hasta.Id;

                    op.PksAc = cbPksAciklama.Text;
                    op.SIK = cbSIK.Text;
                    op.Coop = txtCoop.Text;
                    op.Iskemi = txtIskemi.Text != "" ? int.Parse(txtIskemi.Text) : -1;
                    op.Portsay = txtPortSay.Text != "" ? int.Parse(txtPortSay.Text) : -1;
                    op.Yrdmynt = txtYardimYnt.Text;
                    op.Sure = txtSure.Text != "" ? int.Parse(txtSure.Text) : -1;
                    op.Dren = txtDren.Text != "" ? int.Parse(txtDren.Text) : -1;
                    op.Kanama = txtKanama.Text != "" ? int.Parse(txtKanama.Text) : -1;
                    op.Piyes = txtPiyes.Text != "" ? int.Parse(txtPiyes.Text) : -1;

                    _db.TblOperafs.InsertOnSubmit(op);

                }
                catch (Exception eo)
                {
                    _m.Hata(eo);
                }
                TblPosOperaf po = new TblPosOperaf();

                try
                {
                    po.HastaId = hasta.Id;
                    po.PeropErkenKomp = cbPerErKom.Text;
                    po.PostopAn = txtPosAnaliz.Text;
                    po.Sonda = cbSonda.Text;
                    po.HospSur = txtHospSure.Text != "" ? int.Parse(txtHospSure.Text) : -1;
                    po.preopKeratin = mtbPreobKeratin.Text != "" ? decimal.Parse(mtbPreobKeratin.Text) : -1;
                    po.PostopKreatin = mtbPostopKeratin.Text != "" ? decimal.Parse(mtbPostopKeratin.Text) : -1;
                    po.PreopHtc = mtbPreopHct.Text != "" ? decimal.Parse(mtbPreopHct.Text) : -1;
                    po.PostopHct = mtbPostopHct.Text != "" ? decimal.Parse(mtbPostopHct.Text) : -1;
                    po.PreobHb = mtbPreopHb.Text != "" ? decimal.Parse(mtbPreopHb.Text) : -1;
                    po.PostopHb = mtbPostopHb.Text != "" ? decimal.Parse(mtbPostopHb.Text) : -1;
                    po.Takip = txtPosTakip.Text;
                    po.Tel = txtTel.Text;
                    po.PostopGecKomp = txtPostopGecKomp.Text;
                    po.KompClavien = txtKompClavien.Text;

                    _db.TblPosOperafs.InsertOnSubmit(po);
                }
                catch (Exception p)
                {

                    _m.Hata(p);
                }
                Tbl_PatalojikVeri pa = new Tbl_PatalojikVeri();

                try
                {
                    pa.HastaId = hasta.Id;
                    pa.Patoloji = txtPatoloji.Text;
                    pa.AltGr = txtAltGrup.Text;
                    pa.FurhmanGrade = cbFuhrman.Text;
                    pa.PatolojikEvre = cbPatEvre.Text;
                    pa.CerrahiSinir = cbCerrahiSinir.Text;

                    _db.Tbl_PatalojikVeris.InsertOnSubmit(pa);
                }
                catch (Exception a )
                {

                    _m.Hata(a);
                }
                TblTakip tkp = new TblTakip();
                try
                {
                    tkp.HastaId = hasta.Id;

                    tkp.Postop3Lkl = cb3Nuks.Text;
                    tkp.Postop3Krtn = mtbPost3Kerat.Text != "" ? decimal.Parse(mtbPost3Kerat.Text) : -1;

                    tkp.Postop6Lkl = cbNuks6.Text;
                    tkp.Postop6Krtn = mtbPost6Kerat.Text != "" ? decimal.Parse(mtbPost6Kerat.Text) : -1;

                    tkp.Postop12Lkl = cbNuks12.Text;
                    tkp.Postop12Krtn = mtbPost12Kerat.Text != "" ? decimal.Parse(mtbPost12Kerat.Text) : -1;

                    _db.TblTakips.InsertOnSubmit(tkp);
                }
                catch (Exception t)
                {
                    _m.Hata(t);
                }




                _db.SubmitChanges();

                
                _m.YeniKayit("Kayıt başarılı");
                Temizle();
            }
            catch (Exception d)
            {

                _m.Hata(d);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mtbPostopHct_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
