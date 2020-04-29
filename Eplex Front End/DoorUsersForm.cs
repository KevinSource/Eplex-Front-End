using System;
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
    public partial class DoorUsersForm : Form
    {
        public EplexLockManagement.DoorUserFormShr SharedDoorUserData;
        public bool AllDoorUsersSelected = false;
        private EplexLockManagement _ParentForm;

        public ToolTip LockFunctionToolTip { get; private set; }

        public DoorUsersForm(EplexLockManagement.DoorUserFormShr SharedDoorUserDataIn, EplexLockManagement ParentForm)
        {
            InitializeComponent();

            SharedDoorUserData = SharedDoorUserDataIn;
            _ParentForm = ParentForm;

        }

        private void DoorUsersForm_Load(object sender, EventArgs e)
        {
            this.SiteName.Text = SharedDoorUserData.site;
            this.DoorName.Text = SharedDoorUserData.LockSelectedPtr.Name;
            if (SharedDoorUserData.LockSelectedPtr.Function.Length > 25)
            {
                this.Function.Text = SharedDoorUserData.LockSelectedPtr.Function.Substring(0, 25) + "..." ;
            }
            else
            {
                this.Function.Text = SharedDoorUserData.LockSelectedPtr.Function;
            }

            this.DoorID.Text = SharedDoorUserData.LockSelectedPtr.ID;

            if (SharedDoorUserData.DoorRowSelected == SharedDoorUserData.LockListPtr.Count()-1)
            {
                NextDoor.Enabled = false;
            }
            else
            {
                NextDoor.Enabled = true;
            }

            if (SharedDoorUserData.DoorRowSelected == 0)
            {
                PrevDoor.Enabled = false;
            }
            else
            {
                PrevDoor.Enabled = true;
            }

            LoadDoorUserListbox();
            if (LockFunctionToolTip != null)
            {
                LockFunctionToolTip.Dispose();
            }
            LockFunctionToolTip = new ToolTip();
            //The below are optional, of course,

            LockFunctionToolTip.ToolTipIcon = ToolTipIcon.Info;
            LockFunctionToolTip.IsBalloon = true;
            LockFunctionToolTip.ShowAlways = true;

            LockFunctionToolTip.SetToolTip(Function, SharedDoorUserData.LockSelectedPtr.Function);
        }
        public void LoadDoorUserListbox()
        /***********************************************************************************************************************
        ** Loads all the Doors for the site into the listview control
        ***********************************************************************************************************************/
        {
            DoorUserListView.Items.Clear();
            DoorUserListView.GridLines = true;
            DoorUserListView.View = View.Details;
            DoorUserListView.Columns.Add("", 20);
            DoorUserListView.Columns.Add("Name", -2);
            DoorUserListView.Columns.Add("Num", 40);
            DoorUserListView.Columns[0].TextAlign = HorizontalAlignment.Center;
            DoorUserListView.Columns[1].TextAlign = HorizontalAlignment.Left;

            int DoorCnt = -1;
            int CheckedDoorUsersCount = 0;
            for (int i = 0; i < SharedDoorUserData.Users.Length; i++)
            {
                if (SharedDoorUserData.Users[i].Name.Trim() != "")
                {
                    DoorCnt++;
                    ListViewItem item1 = new ListViewItem("");
                    item1.SubItems.Add(SharedDoorUserData.Users[i].Name);
                    item1.SubItems.Add(SharedDoorUserData.Users[i].Num.ToString("000"));
                    DoorUserListView.Items.AddRange(new ListViewItem[] { item1 });
                    int index = SharedDoorUserData.Users[i].ThisUserDoorListPtr.FindIndex(a => a == this.DoorName.Text);
                    if (index > -1)
                    {
                        //                        DoorUserListView.Items[i].Checked = true;
                        DoorUserListView.Items[DoorCnt].Checked = true;
                        CheckedDoorUsersCount++;
                    }
                    else
                    {
                        DoorUserListView.Items[DoorCnt].Checked = false;
                    }
                    /***********************************************************************************************************************
                    ** This figures out if all the users are assigned to this door. Needed for the Toggle All button
                    ***********************************************************************************************************************/

                    if (CheckedDoorUsersCount == DoorUserListView.Items.Count)
                    {
                        AllDoorUsersSelected = true;
                    }

                }
            }
        }

        private void myOKButton_Click(object sender, EventArgs e)
        {
            UpdateTheUserList();

            Form tmp = this.FindForm();
            tmp.Close();
        }
        private void UpdateTheUserList()
        {
            /***********************************************************************************************************************
            ** Move the door to each selected user list so the caller can write the changes to the user file
            ***********************************************************************************************************************/
            int UsrNum = 0;
            for (int i = 0; i < this.DoorUserListView.Items.Count; i++)
            {
                UsrNum = Int32.Parse(this.DoorUserListView.Items[i].SubItems[2].Text);
                int index = SharedDoorUserData.Users[UsrNum].ThisUserDoorListPtr.FindIndex(a => a == this.DoorName.Text);
                if (this.DoorUserListView.Items[i].Checked == true)
                {
                    if (index > -1)
                    {
                        // This door already in the users record. 
                    }
                    else
                    {
                        SharedDoorUserData.Users[UsrNum].ThisUserDoorListPtr.Add(this.DoorName.Text);
                    }
                }
                else
                {
                    if (index > -1)
                    {
                        SharedDoorUserData.Users[UsrNum].ThisUserDoorListPtr.RemoveAt(index);
                    }
                    else
                    {
                        // This door isn't in the users record, so do nothing.
                    }
                }
            }
        }

        private void myCancelButton_Click(object sender, EventArgs e)
        {
            SharedDoorUserData.Cancel = true;
        }

        private void UserSelectAllToggle_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Calls the Toggle routine
        ***********************************************************************************************************************/
        {
            ToggleLockSelection();
        }
        private void ToggleLockSelection()
        /***********************************************************************************************************************
        ** Figures out whether to check or uncheck the doors
        ***********************************************************************************************************************/
        {
            if (AllDoorUsersSelected)
            {
                AllDoorUsersSelected = false;
                for (int i = 0; i < DoorUserListView.Items.Count; i++)
                {
                    DoorUserListView.Items[i].Checked = false;
                }
            }
            else
            {
                AllDoorUsersSelected = true;
                for (int i = 0; i < DoorUserListView.Items.Count; i++)
                {
                    DoorUserListView.Items[i].Checked = true;
                }
            }
        }

        private void NextDoor_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Handles writing the current door and seting up the next door.
        ***********************************************************************************************************************/
        {
            // in load, enable disable prev next buttons

            UpdateTheUserList();
            _ParentForm.WriteEplexUserData(_ParentForm.UserDataPathAndFile);

            int CurRow = SharedDoorUserData.DoorRowSelected;
            SharedDoorUserData.DoorRowSelected = CurRow + 1;

            SharedDoorUserData.LockSelectedPtr = SharedDoorUserData.LockListPtr[SharedDoorUserData.DoorRowSelected];
            
            DoorUsersForm_Load(sender, e);

        }

        private void PrevDoor_Click(object sender, EventArgs e)
        {
            // in load, enable disable prev next buttons

            UpdateTheUserList();
            _ParentForm.WriteEplexUserData(_ParentForm.UserDataPathAndFile);

            int CurRow = SharedDoorUserData.DoorRowSelected;
            SharedDoorUserData.DoorRowSelected = CurRow - 1;

            SharedDoorUserData.LockSelectedPtr = SharedDoorUserData.LockListPtr[SharedDoorUserData.DoorRowSelected];

            DoorUsersForm_Load(sender, e);

        }
    }
}
