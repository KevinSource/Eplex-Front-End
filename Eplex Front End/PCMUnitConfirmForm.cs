using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class PCMUnitConfirmForm : Form
    {
        public EplexLockManagement.PCMUnitFormShr SharedPCMUnitData;
        public PCMUnitConfirmForm(EplexLockManagement.PCMUnitFormShr SharedPCMUnitDataIn)
        {
            InitializeComponent();
            SharedPCMUnitData = SharedPCMUnitDataIn;
        }

        private void PCMUnitConfirmForm_Load(object sender, EventArgs e)
        {
            PCMUnitFileAndPathLit.Text = SharedPCMUnitData.PCMUnitDataPath;

        }

        private void CopyFileName_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(SharedPCMUnitData.PCMUnitDataPath);
            PCMUnitConfirmForm_Load(sender, e);
        }

        private void Dismiss_Click(object sender, EventArgs e)
        {
            SharedPCMUnitData.Cancel = true;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", SharedPCMUnitData.PCMUnitDataPath);
        }

        private void PCMUnitConfirmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SharedPCMUnitData.Cancel == true)
                e.Cancel = false;
            else
                e.Cancel = true;
            if (e.CloseReason.ToString() == "UserClosing")
            {
                e.Cancel = false;
            }
        }
    }
}
