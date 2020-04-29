using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class DoorCopyForm : Form

    {
        public EplexLockManagement.DoorFormShr LockData;
        public DoorCopyForm(EplexLockManagement.DoorFormShr SharedDoorData)
        {
            InitializeComponent();

            LockData = SharedDoorData;
            LockData.Cancel = false;

            FromDoorName.Text = SharedDoorData.LockSelectedPtr.Name;
            FromDoorID.Text = SharedDoorData.LockSelectedPtr.ID;
            ToDoorName.Text = "";
            ToDoorID.Text = "0000";
            CopyDoorStatusMsg.Text = "";

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            // Do edits
            bool ErrFlag = false;
            /***********************************************************************************************************************
            ** Make sure the door name is not duplicated.
            ***********************************************************************************************************************/
            ToDoorName.ForeColor = Color.Black;
            int ToDoorNameCount = 0;
            for (int i = 0; i < LockData.LockListPtr.Count; i++)
            {
                if (ToDoorName.Text == LockData.LockListPtr[i].Name)
                {
                    ToDoorNameCount++;
                }
            }
            if (ToDoorNameCount > 0)
            {
                ErrFlag = true;
                CopyDoorStatusMsg.Text = "There is already a door lock named:" + ToDoorName.Text;
                ToDoorName.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }
            /***********************************************************************************************************************
            ** Make sure the door number (LockID) is not duplicated.
            ***********************************************************************************************************************/
            ToDoorID.ForeColor = Color.Black;
            int ToDoorIDCount = 0;
            for (int i = 0; i < LockData.LockListPtr.Count; i++)
            {
                if (ToDoorID.Text == LockData.LockListPtr[i].ID)
                {
                    ToDoorIDCount++;
                }
            }
            if (ToDoorIDCount > 0)
            {
                ErrFlag = true;
                CopyDoorStatusMsg.Text = "There is already a door lock ID:" + ToDoorID.Text;
                ToDoorID.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }

            /***********************************************************************************************************************
            ** Make sure the door number isn't 0000
            ***********************************************************************************************************************/
            if (ToDoorID.Text == "0000")
            {
                ErrFlag = true;
                CopyDoorStatusMsg.Text = "Door ID cannot be 0000";
                ToDoorID.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }

            /***********************************************************************************************************************
            ** Make sure the door name isn't spaces
            ***********************************************************************************************************************/
            if (ToDoorName.Text.Trim() == "")
            {
                ErrFlag = true;
                CopyDoorStatusMsg.Text = "Door name cannot be blank";
                ToDoorID.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }

            if (ErrFlag == false)
            {
                LockData.LockSelectedPtr.Name = ToDoorName.Text;
                LockData.LockSelectedPtr.ID = ToDoorID.Text;

                Form tmp = this.FindForm();

                tmp.Close();
                tmp.Dispose();

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            LockData.Cancel = true;
        }

        private void myCancelButton_Click(object sender, EventArgs e)
        {
            LockData.Cancel = true;
        }
    }
}
