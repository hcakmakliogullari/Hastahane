using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hastahane.Modal
{
    class Formlar
    {
        public void HastaGiris()
        {

            HastaGiris.frmHastaGiris frm = new HastaGiris.frmHastaGiris();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        public void BilgiGiris()
        {
          Bilgi.frmDoktorGiris frm = new Bilgi.frmDoktorGiris();
            frm.ShowDialog();
        }
        public void OzelList()
        {
            Liste.frmOzelListe frm = new Liste.frmOzelListe();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        //public Boolean Cinsiyet(string cinsiyet)
        //{
        //    if (cinsiyet == "Erkek")
        //    {
        //        return true;
        //    }
        //    else if (cinsiyet == "Kadın")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return ;
        //    }
        //}
        public void DoktorGiris(bool secim = false)

        { Bilgi.frmDoktorGiris frm = new Bilgi.frmDoktorGiris();
            if (secim)
            {
            frm.Secim = true;
            frm.ShowDialog();
           
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
               
        }

        public void Opturu(bool secim = false)
        {
            Bilgi.OpTuruGiris frm = new Bilgi.OpTuruGiris();
            
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

        public void MorbiditeGiris(bool secim = false)
        {
            Bilgi.frmKomorbidite frm = new Bilgi.frmKomorbidite();

            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

        public void LokalizasyonGiris(bool secim = false)
        {
            Bilgi.frmLokalizasyon frm = new Bilgi.frmLokalizasyon();

            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

        public void PatolojiGiris(bool secim = false)
        {
            Bilgi.frmPatoloji frm = new Bilgi.frmPatoloji();

            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

        public void AltGrupGiris(bool secim = false)
        {
            Bilgi.frmAltGrup frm = new Bilgi.frmAltGrup();

            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

        public void HastaList(bool secim = false)
        {
            Bilgi.frmHastaListesi frm= new Bilgi.frmHastaListesi();

            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }

        }

    }
}
