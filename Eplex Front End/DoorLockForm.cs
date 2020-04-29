using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class DoorLockForm : Form
    {
        /***********************************************************************************************************************
        ** These are global variables.
        ** The dictionary is used to check for duplicate access codes.
        ***********************************************************************************************************************/
        public bool ErrFlag;
        public bool AllAuditFlagsSelected;
        public Color SaveColor;
        public EplexLockManagement.DoorFormShr LockData;
        public EplexLockManagement.DoorFormShr SharedDoorData;
        public DoorLockForm(EplexLockManagement.DoorFormShr SharedDoorDataIn)
        {
            InitializeComponent();
            SharedDoorData = SharedDoorDataIn;
            LockData = SharedDoorData;
            LockData.Cancel = false;
            SiteName.Text = LockData.site;

            foreach (string L_Func in LockData.LockFunctionsPtr)
            {
                LockFunction.Items.Add(L_Func);
                if (L_Func == LockData.LockSelectedPtr.Function)
                {
                    LockFunction.SelectedIndex = LockFunction.Items.Count - 1;
                }
            }

            if (LockData.LockSelectedPtr.Name == "%%!!%%ADD")
            {
                DoorName.Text = "";
                LockID.Text = "0000";
                DoorName.Enabled = true;
            }
            else
            {
                DoorName.Text = LockData.LockSelectedPtr.Name;
                DoorName.Enabled = false;
                LockID.Text = LockData.LockSelectedPtr.ID;

                UnlockTime.Value = LockData.LockSelectedPtr.UnlockTime;
                BuzzerVolume.Value = LockData.LockSelectedPtr.BuzzerVolume;
                TamperCount.Value = LockData.LockSelectedPtr.TamperCount;
                TamperShutdownTime.Value = LockData.LockSelectedPtr.TamperShutdownTime;
                if (LockData.LockSelectedPtr.PassageMode)
                    PassageModeActivated.Checked = true;
                else
                    PassageModeDeactivated.Checked = true;
                PassageOpenTime.Value = LockData.LockSelectedPtr.PassageModeOpenTimeLimit;
                if (LockData.LockSelectedPtr.LockOutMode)
                    LockoutModeActivated.Checked = true;
                else
                    LockoutModeDeactivated.Checked = true;
                AccessCodeLength.Value = LockData.LockSelectedPtr.AccessCodeLength;
                if (LockData.LockSelectedPtr.RemoteUnlock)
                    RemoteUnlockActivated.Checked = true;
                else
                    RemoteUnlockDeactivated.Checked = true;
                if (LockData.LockSelectedPtr.LatchHoldback)
                    LatchHoldbackActivated.Checked = true;
                else
                    LatchHoldbackDeactivated.Checked = true;
            }

            /****************************************************************************************************************************************
            * * These statements didn't work, look  in the properties of the form in the design view 
            *****************************************************************************************************************************************/
            //this.AcceptButton = this.OKButton;
            //OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            //myCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;  // Doesn't work Escape won't invoke. I think due to combo box
        }
        private void DoorLockForm_Load(object sender, EventArgs e)
        {
            AuditFlagListView.Items.Clear();
            AuditFlagListView.GridLines = true;
            AuditFlagListView.View = View.Details;
            AuditFlagListView.Columns.Add("", 20);
            AuditFlagListView.Columns.Add("", -2);
            AuditFlagListView.Columns[0].TextAlign = HorizontalAlignment.Center;
            AuditFlagListView.Columns[1].TextAlign = HorizontalAlignment.Left;

            for (int i = 0; i < SharedDoorData.LockSelectedPtr.AuditFlags.Length; i++)
            {
                ListViewItem item1 = new ListViewItem("");
                string AuditFlgLit = SharedDoorData.LockSelectedPtr.AuditFlagDictionary.ElementAt(i).Key;
                item1.SubItems.Add(AuditFlgLit);
                AuditFlagListView.Items.AddRange(new ListViewItem[] { item1 });
                AuditFlagListView.Items[i].Checked = true;
            }

            /***********************************************************************************************************************
            ** This figures out if all the audit flags are selected. Needed for the Toggle All button
            ***********************************************************************************************************************/
            int CheckedAuditFlagCount = 0;
            for (int j = 0; j<AuditFlagListView.Items.Count; j++)
            {
                if (SharedDoorData.LockSelectedPtr.AuditFlags[j] == true)
                {
                    AuditFlagListView.Items[j].Checked = true;
                    CheckedAuditFlagCount++;
                }
            }
            AllAuditFlagsSelected = false;
            if (CheckedAuditFlagCount == AuditFlagListView.Items.Count)
            {
                AllAuditFlagsSelected = true;
            }
        }
        private void ToggleLockSelection()
        /***********************************************************************************************************************
        ** Figures out whether to check or uncheck the audit flags
        ***********************************************************************************************************************/
        {
            if (AllAuditFlagsSelected)
            {
                AllAuditFlagsSelected = false;
                for (int i = 0; i < AuditFlagListView.Items.Count; i++)
                {
                    AuditFlagListView.Items[i].Checked = false;
                }
            }
            else
            {
                AllAuditFlagsSelected = true;
                for (int i = 0; i < AuditFlagListView.Items.Count; i++)
                {
                    AuditFlagListView.Items[i].Checked = true;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Form tmp = this.FindForm();
            LockData.Cancel = true;

            tmp.Close();
            tmp.Dispose();

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // Do edits
            ErrFlag = false;
            /***********************************************************************************************************************
            ** Make sure the door name is not duplicated.
            ***********************************************************************************************************************/
            DoorName.ForeColor = Color.Black;
            int DoorNameCount = 0;
            for (int i=0; i < LockData.LockListPtr.Count; i++ )
            {
                if (DoorName.Text == LockData.LockListPtr[i].Name )
                {
                    if (SharedDoorData.AddInProgress)
                    {
                        DoorNameCount++;
                    }
                }
            }
            if (DoorNameCount > 0)
            {
                ErrFlag = true;
                DoorStatusMsg.Text = "There is already a door lock named:" + DoorName.Text;
                DoorName.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }
            /***********************************************************************************************************************
            ** Make sure the door number (LockID) is not duplicated.
            ***********************************************************************************************************************/
            LockID.ForeColor = Color.Black;
            int LockIdCount = 0;
            bool SameNameFnd = false;
            
            for (int i = 0; i < LockData.LockListPtr.Count; i++)
            {
                if (LockID.Text == LockData.LockListPtr[i].ID )
                {
                    if (SharedDoorData.AddInProgress)
                        LockIdCount++;
                    else
                    {
                        if (DoorName.Text == LockData.LockListPtr[i].Name)
                        {
                            // OK, change 
                        }
                        else
                        {
                            LockIdCount++;
                        }
                    }
                }
            }
            if (LockIdCount > 0)
            {
                ErrFlag = true;
                DoorStatusMsg.Text = "There is already a door lock ID:" + LockID.Text;
                LockID.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }

            if (ErrFlag == false)
            {
                LockData.LockSelectedPtr.Name = DoorName.Text;
                LockData.LockSelectedPtr.ID = LockID.Text;
                LockData.LockSelectedPtr.Function = LockFunction.Text;

                LockData.LockSelectedPtr.UnlockTime = (int)UnlockTime.Value;
                LockData.LockSelectedPtr.BuzzerVolume = (int)BuzzerVolume.Value;
                LockData.LockSelectedPtr.TamperCount = (int)TamperCount.Value;
                LockData.LockSelectedPtr.TamperShutdownTime = (int)TamperShutdownTime.Value;
                if (PassageModeActivated.Checked == true)
                    LockData.LockSelectedPtr.PassageMode = true;
                else
                    LockData.LockSelectedPtr.PassageMode = false;
                LockData.LockSelectedPtr.PassageModeOpenTimeLimit = (int)PassageOpenTime.Value;
                if (LockoutModeActivated.Checked == true)
                    LockData.LockSelectedPtr.LockOutMode = true;
                else
                    LockData.LockSelectedPtr.LockOutMode = false;
                LockData.LockSelectedPtr.AccessCodeLength = (int)AccessCodeLength.Value;
                if (RemoteUnlockActivated.Checked == true)
                    LockData.LockSelectedPtr.RemoteUnlock = true;
                else
                    LockData.LockSelectedPtr.RemoteUnlock = false;
                if (LatchHoldbackActivated.Checked == true)
                    LockData.LockSelectedPtr.LatchHoldback = true;
                else
                    LockData.LockSelectedPtr.LatchHoldback = false;

                for (int j = 0; j < 34; j++)
                {
                    LockData.LockSelectedPtr.AuditFlags[j] = AuditFlagListView.Items[j].Checked;
                } // for j


                Form tmp = this.FindForm();

                tmp.Close();
                tmp.Dispose();

            }
            else
            {
                // Do nothing
            }
        }

        private void myCancelBtn_Click(object sender, EventArgs e)
        {
            Form tmp = this.FindForm();
            LockData.Cancel = true;

            tmp.Close();
            tmp.Dispose();


        }

        private void DoorAuditAllToggle_Click(object sender, EventArgs e)
        {
            ToggleLockSelection();
        }
    }
}
