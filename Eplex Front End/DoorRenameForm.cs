using System;
using System.Collections.Generic;
using System.Media;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    public partial class RenameDoorForm : Form
    {
        public EplexLockManagement.DoorUserFormShr SharedDoorUserData;
        public EplexLockManagement.DoorFormShr SharedDoorData;
        public EplexLockManagement _ParentForm;
        public List<LockSettings> Lock;
        
        public RenameDoorForm(EplexLockManagement.DoorFormShr SharedDoorDataIn, EplexLockManagement.DoorUserFormShr SharedDoorUserDataIn, EplexLockManagement ParentFormIn)
        {
            InitializeComponent();

            SharedDoorUserData = SharedDoorUserDataIn;
            SharedDoorData = SharedDoorDataIn;
            _ParentForm = ParentFormIn;
            Lock = SharedDoorData.LockListPtr;
        }
        private void RenameDoorForm_Load(object sender, EventArgs e)
        {
            DoorName.Text = SharedDoorData.LockSelectedPtr.Name;
            NewDoorName.Text = SharedDoorData.LockSelectedPtr.Name;
            DoorName.Enabled = false;
            DoorStatusMsg.Text = "";

        }

        //        public bool ErrFlag { get; private set; }
        public bool ErrFlag;

        private void myOKButton_Click(object sender, EventArgs e)
        {
            ErrFlag = false;
            /***********************************************************************************************************************
            ** Make sure the door name is not duplicated.
            ***********************************************************************************************************************/
            DoorName.ForeColor = Color.Black;
            int DoorNameCount = 0;
            for (int i = 0; i < Lock.Count; i++)
            {
                if (NewDoorName.Text == Lock[i].Name )
                {
                    // This is only true when the new name is the same as the old name AND the old name is for the door being processed
                    // In other words, the name wasn't changed
                    if (SharedDoorData.LockSelectedPtr.Name == NewDoorName.Text)
                    {
                        // OK the user did not change the name
                    }
                    else
                    {
                        DoorNameCount++;
                    }
                }
            }
            if (DoorNameCount > 0)
            {
                ErrFlag = true;
                DoorStatusMsg.Text = "There is already a door lock named:" + NewDoorName.Text;
                DoorName.ForeColor = Color.Red;
                SystemSounds.Beep.Play();
            }
            else
            {
                // files are updated in the main
                Form tmp = this.FindForm();
                tmp.Close();

            }
        }
    }
}
