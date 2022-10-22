using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class RegistrySettingsForm : Form
    {
        public EplexLockManagement.RegistrySettingsFormShr SharedRegistryFormData;
        public bool DemoPgm;
        public RegistrySettingsForm(EplexLockManagement.RegistrySettingsFormShr SharedRegistryFormDataIn, bool DemoPgmIn)
        {
            InitializeComponent();
            SharedRegistryFormData = SharedRegistryFormDataIn;
            DemoPgm = DemoPgmIn;
        }

        private void RegistrySettingsForm_Load(object sender, EventArgs e)
        {
            string RegistryEntry = "";

            AppPath.Text = SharedRegistryFormData.AppPath;
            ToolTip ToolTip1 = new ToolTip();
            // Set up the delays for the ToolTip.
            ToolTip1.AutoPopDelay = 5000;
            ToolTip1.InitialDelay = 100;
            ToolTip1.ReshowDelay = 100;

            ToolTip1.SetToolTip(AppPath, "Location of the Eplex Standard application. Used to find the m-Unit program.");
            DataPath.Text = SharedRegistryFormData.DataPath;
            ToolTip1.SetToolTip(DataPath, "Location of the data files for Eplex Standard software. Should be a local drive. Onedrive locations fail miserably.");
            DataPath2020.Text = SharedRegistryFormData.DataPath2020;
            ToolTip1.SetToolTip(DataPath2020, "Location of the data files for this application. Network and OneDrive locations work fine.");
            MUnitPath.Text = SharedRegistryFormData.MUnitPath;
            ToolTip1.SetToolTip(MUnitPath, "Location of the data files used by the Eplex M-Unit Program. This can be set here or in the PCM-Unit program. This program and PCM-Unit both rely on the same registry entry");
            EncryptDataCheckbox.Checked = SharedRegistryFormData.EplexDataEncryption;
            LatestReportPath.Text = SharedRegistryFormData.LatestReportPath;
            ToolTip1.SetToolTip(LatestReportPath, "Location of most recent Excel report file created by this application.");
            string ElpexPathKeyLit = @"Software\Kaba\Eplex 5000";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(ElpexPathKeyLit,true);
            object o = key.GetValue(SharedRegistryFormData.LatestReportFileLit);
            if (o != null)
            {
                RegistryEntry = o.ToString();
                SharedRegistryFormData.LatestReportFile = RegistryEntry;
            }
            else
            {
                SharedRegistryFormData.LatestReportFile = "";
            }
            LatestReportFile.Text = SharedRegistryFormData.LatestReportFile;
            ToolTip1.SetToolTip(LatestReportFile, "File name of the most recently generated report file.");

            o = key.GetValue(SharedRegistryFormData.LatestReportBaseFileNameLit);
            if (o != null)
            {
                RegistryEntry = o.ToString();
                SharedRegistryFormData.LatestReportBaseFileName = RegistryEntry;
            }
            else
            {
                SharedRegistryFormData.LatestReportBaseFileName = "";
            }
            LatestReportBaseFileName.Text = SharedRegistryFormData.LatestReportBaseFileName;
            ToolTip1.SetToolTip(LatestReportBaseFileName, "The location will be appended to this name.");

            StatusMsg.Text = "";
            if (DemoPgm)
            {
                AppPathUpdate.Enabled = false;
                DataPathUpdate.Enabled = false;
                MUnitPathUpdate.Enabled = false;
            }
        }

        private void AppPathCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedRegistryFormData.AppPath);
            StatusMsg.Text = SharedRegistryFormData.AppPath + " copied to the clipboard";
        }

        private void DataPathCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedRegistryFormData.DataPath);
            StatusMsg.Text = SharedRegistryFormData.DataPath + " copied to the clipboard";
        }

        private void MUnitPathCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedRegistryFormData.MUnitPath);
            StatusMsg.Text = SharedRegistryFormData.MUnitPath + " copied to the clipboard";
        }

        private void AppPathUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppPath.Text.Substring(AppPath.Text.Length - 1, 1) != @"\")
                    AppPath.Text = AppPath.Text + @"\";

                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.AppPathLit, AppPath.Text);
                StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.AppPathLit + " SET TO: " + AppPath.Text;
            }
            catch (Exception e1)
            {
                StatusMsg.Text = e1.Message;
            }

        }

        private void DataPathUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataPath.Text.Substring(DataPath.Text.Length - 1, 1) != @"\")
                    DataPath.Text = DataPath.Text + @"\";

                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.DataPathLit, DataPath.Text);
                StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.DataPathLit + " SET TO: " + DataPath.Text;
            }
            catch (Exception e1)
            {
                StatusMsg.Text = e1.Message;
            }
        }

        private void MUnitPathUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MUnitPath.Text.Substring(MUnitPath.Text.Length - 1, 1) != @"\")
                    MUnitPath.Text = MUnitPath.Text + @"\";

                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.MUnitPathLit, MUnitPath.Text);
                StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.MUnitPathLit + " SET TO: " + MUnitPath.Text;
            }
            catch (Exception e1)
            {
                StatusMsg.Text = e1.Message;
            }
        }

        private void AppPathExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(AppPath.Text);
        }

        private void DataPathExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(DataPath.Text);
        }

        private void MUnitPathExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(MUnitPath.Text);
        }

        private void EncryptDataCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SharedRegistryFormData.EplexDataEncryption = EncryptDataCheckbox.Checked;
            try
            {
//              RegistryKey key = Registry.CurrentUser.OpenSubKey(SharedRegistryFormData.EplexDataEncryptionLit,true);
                if (EncryptDataCheckbox.Checked)
                {
                    Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.EplexDataEncryptionLit, "True");
                    StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.DataPathLit + " SET TO: True";
                }
                else
                {
                    Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.EplexDataEncryptionLit, "False");
                    StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.DataPathLit + " SET TO: False";
                }
            }
            catch (Exception e1)
            {
                StatusMsg.Text = e1.Message;
            }
        }

        private void LatestReportFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(SharedRegistryFormData.LatestReportPath + SharedRegistryFormData.LatestReportFile);
            }
            catch (Exception e1)
            {
                SystemSounds.Beep.Play();
                DialogResult OKFlag = MessageBox.Show("File is not available. ", "Warning", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedRegistryFormData.LatestReportPath + SharedRegistryFormData.LatestReportFile);
        }

        private void LatestReportFileExplore_Click(object sender, EventArgs e)
        {
            Process.Start(SharedRegistryFormData.LatestReportPath);
        }

        private void myOKButon_Click(object sender, EventArgs e)
        {
            if (LatestReportPath.Text.Substring(LatestReportPath.Text.Length - 1, 1) != @"\")
                LatestReportPath.Text = LatestReportPath.Text + @"\";

            SharedRegistryFormData.LatestReportFile = LatestReportFile.Text;
            SharedRegistryFormData.LatestReportBaseFileName = LatestReportBaseFileName.Text;
            SharedRegistryFormData.LatestReportPath = LatestReportPath.Text;

            if (SharedRegistryFormData.Test == false)
            {
                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.LatestReportFileLit, LatestReportFile.Text);
                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.LatestReportBaseFileNameLit, LatestReportBaseFileName.Text);
                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.LatestReportPathLit, LatestReportPath.Text);
            }

        }

        private void DataPath2020Copy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedRegistryFormData.DataPath2020);
            StatusMsg.Text = SharedRegistryFormData.DataPath2020 + " copied to the clipboard";
        }

        private void DataPath2020Explorer_Click(object sender, EventArgs e)
        {
            Process.Start(DataPath2020.Text);
        }

        private void DataPath2020Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataPath2020.Text.Substring(DataPath2020.Text.Length - 1, 1) != @"\")
                    DataPath2020.Text = DataPath2020.Text + @"\";

                Registry.SetValue(SharedRegistryFormData.EplexRegistryKeyPart1, SharedRegistryFormData.DataPath2020Lit, DataPath2020.Text);
                StatusMsg.Text = "REGISTRY: " + SharedRegistryFormData.EplexRegistryKeyPart1 + " KEY: " + SharedRegistryFormData.DataPath2020Lit + " SET TO: " + DataPath2020.Text;
            }
            catch (Exception e1)
            {
                StatusMsg.Text = e1.Message;
            }
        }

        private void MUnitPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
