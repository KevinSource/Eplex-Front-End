using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class SiteName : Form
    {
        public EplexLockManagement.SiteFormShr SharedSiteData;
        public bool ErrFlag;

        public SiteName(EplexLockManagement.SiteFormShr SharedSiteDataIn)
        {
            InitializeComponent();
            SharedSiteData = SharedSiteDataIn;
        }

        private void SiteName_Load(object sender, EventArgs e)
        {
            SharedSiteData.Cancel = false;
            SiteNameMsg.Text = "";

            if (SharedSiteData.DialogFunction == "Rename")
            {
                SiteName1.Text = SharedSiteData.site;
                SiteName1.Enabled = false;
                NewSiteName.Text = "";
            }
            else
            {
                NewSiteNameLit.Enabled = false;
                NewSiteNameLit.Visible = false;
                NewSiteName.Enabled = false;
                NewSiteName.Visible = false;
            }
        }

        private void myOKButton_Click(object sender, EventArgs e)
        {
            ErrFlag = false;
            string source = SharedSiteData.SiteDataPath2020 + @"\" + SiteName1.Text;
            string destination = SharedSiteData.SiteDataPath2020 + @"\" + NewSiteName.Text;
            if (SharedSiteData.DialogFunction == "Rename")
            {
                try
                {
                    Directory.Move(source, destination);
                }
                catch (System.IO.IOException e2)
                {
                    SiteNameMsg.Text = e2.Message;
                    ErrFlag = true;
                    SystemSounds.Beep.Play();

                }
            }
            else
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(source); 
                }
                catch (System.IO.IOException e2)
                {
                    SiteNameMsg.Text = e2.Message;
                    ErrFlag = true;
                    SystemSounds.Beep.Play();

                }
            }

            if (ErrFlag == false)
            {
                if (NewSiteName.Enabled)
                    SharedSiteData.site = NewSiteName.Text;
                else
                    SharedSiteData.site = SiteName1.Text;
                Form tmp = this.FindForm();
                tmp.Close();
            }

        }

        private void myCancelButton_Click(object sender, EventArgs e)
        {
            SharedSiteData.Cancel = true;
        }
    }
}
