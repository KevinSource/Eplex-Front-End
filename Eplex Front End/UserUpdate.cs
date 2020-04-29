using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplex_Front_End
{
    /***********************************************************************************************************************
    ** This defines class for the form.
    ***********************************************************************************************************************/
    public partial class UserUpdateForm : Form
    {
        /***********************************************************************************************************************
        ** These are global variables.
        ** The dictionary is used to check for duplicate access codes.
        ***********************************************************************************************************************/
        public bool ErrFlag;
        public bool AllDoorSelected = false;
        public Color SaveColor;
        public EplexLockManagement.UserFormShr SharedUserData;
        public EplexLockManagement.DoorFormShr SharedDoorData;
        private EplexLockManagement _ParentForm;

        /***********************************************************************************************************************
        ** This is executed when the form is instantiated.
        ***********************************************************************************************************************/
        public UserUpdateForm(EplexLockManagement.UserFormShr SharedUserDataIn, EplexLockManagement.DoorFormShr SharedDoorDataIn, EplexLockManagement ParentForm)
        {
            InitializeComponent();
            SharedUserData = SharedUserDataIn;
            SharedDoorData = SharedDoorDataIn;
            _ParentForm = ParentForm;

        }
        private void UserUpdateForm_Load(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** This is executed when the form is loaded.
        ***********************************************************************************************************************/
        {
            AccessCode.Controls[0].Visible = false;
            SiteDoorsLabel.Text = "Select Doors for User, Site: " + SharedDoorData.site;
            LoadDoorListbox();
            SharedUserData.Cancel = false;
            StatusMsg.Text = "";
            SharedUserData.UserDictionaryPtr.Remove(SharedUserData.code);
            string UsrNum = SharedUserData.num.ToString("000");
            UserNumber.Text = UsrNum;
            UserName.Text = SharedUserData.name;
            AccessCode.Value = SharedUserData.code;

            if (SharedUserData.code == 0)
            {
                AccessCode.ForeColor = Color.White;
            }
            if (SharedUserData.type == "Manager")
            {
                ManagerRadioButton.Checked = true;
                SharedUserData.type = "Manager";
            }
            else
            {
                AccessUserRadioButton.Checked = true;
                SharedUserData.type = "Access User";
            }
            if (UserName.Text == "")
            {
                ToggleLockSelection();
            }
            else
            {
                /***********************************************************************************************************************
                ** This figures out if the user has all doors selected. Needed for the Toggle All button
                ***********************************************************************************************************************/
                int CheckedDoorCount = 0;
                for (int i = 0; i < SharedUserData.ThisUserDoorListPtr.Count; i++)
                {
                    for (int j = 0; j < DoorSelectionList.Items.Count; j++)
                    {
                        if (SharedUserData.ThisUserDoorListPtr[i] == DoorSelectionList.Items[j].SubItems[1].Text)
                        {
                            DoorSelectionList.Items[j].Checked = true;
                            CheckedDoorCount++;
                            break;
                        }
                    }
                }
                if (CheckedDoorCount == DoorSelectionList.Items.Count)
                {
                    AllDoorSelected = true;
                }

                if (_ParentForm.UserListView.SelectedItems[0].Index == 0)
                {
                    PrevUser.Enabled = false;
                }
                else
                {
                    PrevUser.Enabled = true;
                }
                if (_ParentForm.UserListView.SelectedItems[0].Index == _ParentForm.UserListView.Items.Count - 1)
                {
                    NextUser.Enabled = false;
                }
                else
                {
                    NextUser.Enabled = true;
                }
                //NextUser.Enabled = SharedUserData.NextButtonEnabled;
                //PrevUser.Enabled = SharedUserData.PrevButtonEnabled;
                //NextUser.Visible = SharedUserData.NextButtonEnabled;
                //PrevUser.Visible = SharedUserData.PrevButtonEnabled;
            }
        }

        private void AccessCode_Leave(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** This does some data validation on the Access code.
        ***********************************************************************************************************************/
        {
            int DoorCodeLen = SharedDoorData.LockSelectedPtr.AccessCodeLength;
            string DoorCodeLenLit = DoorCodeLen.ToString();
            double maxUserCode = Math.Pow(10, SharedDoorData.LockSelectedPtr.AccessCodeLength) - 1;
            double minUserCode = Math.Pow(10, SharedDoorData.LockSelectedPtr.AccessCodeLength - 2);

            ErrFlag = false;
            StatusMsg.Text = "";
            if (AccessCode.Text == "")
            {
                ErrFlag = true;
                StatusMsg.Text = DoorCodeLenLit + " digit Accesss code required";
            }
            else
            {
                if (double.Parse(AccessCode.Text) < 0)
                {
                    ErrFlag = true;
                    StatusMsg.Text = "Access Code less than zero";
                }
                if (double.Parse(AccessCode.Text) > maxUserCode)
                {
                    ErrFlag = true;
                    StatusMsg.Text = "Access Code more than " + DoorCodeLenLit + " digits";
                }
                if (double.Parse(AccessCode.Text) < minUserCode)
                {
                    ErrFlag = true;
                    StatusMsg.Text = $"Access Code less than {DoorCodeLenLit} digits";
                }
                int TestNum = int.Parse(AccessCode.Text);
                string OriginalNm = SharedUserData.name;
                string CurNm = "";
                if (SharedUserData.UserDictionaryPtr.TryGetValue(TestNum, out CurNm))
                {
                    if (OriginalNm == CurNm)
                    {
                        // OK, The Access code is taken, but its by the person being edited, that's OK.
                    }
                    else
                    {
                        ErrFlag = true;
                        StatusMsg.Text = "Access code in use by " + CurNm;
                    }
                }
                if (ErrFlag)
                {
                    AccessCode.ForeColor = Color.Red;
                    SystemSounds.Beep.Play();
                }
                else
                {
                    AccessCode.ForeColor = Color.Black;
                }
            }

        }
        /***********************************************************************************************************************
        ** Validate the data
        ** Set the return data up for the caller
        ** Update the dictionary
        ***********************************************************************************************************************/
        private void OKButton_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Validate the data
        ** Move data to the Shared Data for the caller to have access
        ***********************************************************************************************************************/
        {
            EditUserData();
            if (ErrFlag)
            {
                // Stay put
            }
            else
            {
                Form tmp = this.FindForm();
                tmp.Close();
            }
        }
        private void EditUserData()
        {
            ErrFlag = false;
            int DoorCodeLen = SharedDoorData.LockSelectedPtr.AccessCodeLength;
            string DoorCodeLenLit = DoorCodeLen.ToString();
            double maxUserCode = Math.Pow(10, SharedDoorData.LockSelectedPtr.AccessCodeLength) - 1;
            double minUserCode = Math.Pow(10, SharedDoorData.LockSelectedPtr.AccessCodeLength - 2);


            /**********************************************************************************************************************
            * * Make sure the access code is in range
            * *********************************************************************************************************************/
            if (AccessCode.Text.Trim() == "")
            {
                ErrFlag = true;
                StatusMsg.Text = $"Access code must be {DoorCodeLenLit} digits ";
            }
            else
            {
                if (int.Parse(AccessCode.Text) > minUserCode & int.Parse(AccessCode.Text) < maxUserCode)
                {
                    SharedUserData.code = int.Parse(AccessCode.Text);
                }
                else
                {
                    ErrFlag = true;
                    StatusMsg.Text = $"Access code must be {DoorCodeLenLit} digits ";
                }
                /**********************************************************************************************************************
                * * Make sure the user access code is unique to this site
                * *********************************************************************************************************************/
                int TmpNum = int.Parse(AccessCode.Text);
                if (SharedUserData.UserDictionaryPtr.ContainsKey(TmpNum))
                {
                    ErrFlag = true;
                    StatusMsg.Text = "Access Code must be unique. " + AccessCode.Text + " Currently assigned to " + SharedUserData.UserDictionaryPtr[TmpNum];
                }
            }
            /**********************************************************************************************************************
            * * Make sure the user name is not blank
            * *********************************************************************************************************************/
            if (UserName.TextLength > 0)
            {
                SharedUserData.name = UserName.Text;
            }
            else
            {
                ErrFlag = true;
                StatusMsg.Text = "User name is blank ";
            }

            SharedUserData.num = int.Parse(UserNumber.Text);
            if (UserName.TextLength > 0)
            {
                SharedUserData.name = UserName.Text;
            }
            else
            {
                ErrFlag = true;
                StatusMsg.Text = "User name is blank ";
            }
            // SharedUserData.type = is set on form entry and changed when the button is clicked

            /***********************************************************************************************************************
            ** Move the door for this user to the shared memory so the caller can update the users record
            ***********************************************************************************************************************/
            if (SharedUserData.ThisUserDoorListPtr == null)
            {
                SharedUserData.ThisUserDoorListPtr = new List<string>();
            }
            else
            {
                try
                {
                    SharedUserData.ThisUserDoorListPtr.Clear();
                }
                catch
                {
                }
            }
            for (int i = 0; i < this.DoorSelectionList.Items.Count; i++)
            {
                if (this.DoorSelectionList.Items[i].Checked == true)
                {
                    SharedUserData.ThisUserDoorListPtr.Add(this.DoorSelectionList.Items[i].SubItems[1].Text);
                }
            }

            if (ErrFlag)
            {
                SystemSounds.Beep.Play();
            }
            else
            {
                SharedUserData.code = int.Parse(AccessCode.Text);
                SharedUserData.UserDictionaryPtr[int.Parse(AccessCode.Text)] = UserName.Text;

                //Form tmp = this.FindForm();
                //tmp.Close();
            }
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Set the cancel flag and leave
        ***********************************************************************************************************************/
        {
            Form tmp = this.FindForm();
            SharedUserData.Cancel = true;

            tmp.Close();
            tmp.Dispose();
        }
        private void CancelButton1_MouseEnter(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Color the button.
        ***********************************************************************************************************************/
        {
            SaveColor = CancelButton1.BackColor;
            CancelButton1.BackColor = Color.LightBlue;
        }
        private void CancelButton1_MouseLeave(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Restore the button color to default.
        ***********************************************************************************************************************/
        {
            CancelButton1.BackColor = SaveColor;
        }
        private void OKButton_MouseEnter(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Color the button.
        ***********************************************************************************************************************/
        {
            SaveColor = OKButton.BackColor;
            OKButton.BackColor = Color.LightBlue;
        }
        private void OKButton_MouseLeave(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Restore the button color to default.
        ***********************************************************************************************************************/
        {
            OKButton.BackColor = SaveColor;
        }
        private void AccessUserRadioButton_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Set the user type..
        ***********************************************************************************************************************/
        {
            SharedUserData.type = "Access User";
        }
        private void ManagerRadioButton_CheckedChanged(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** Set the user type..
        ***********************************************************************************************************************/
        {
            SharedUserData.type = "Manager";
        }
        private void AccessCode_Enter(object sender, EventArgs e)
        /***********************************************************************************************************************
        ** AccessCode is a NumericUpDown control. This only allows numbers.
        ** If AccessCode was zero When the form was initialized, the font color was changed to white so it would be invisible.
        ** But, for this application, the zero just complicates the code entry. So the zero is deleted when this control is entered.
        ***********************************************************************************************************************/
        {
            if (AccessCode.ForeColor == Color.White)
            {
                AccessCode.ForeColor = Color.Black;
                AccessCode.Focus();
                SendKeys.SendWait("{Delete}");
            }
        }

        public void LoadDoorListbox()
        /***********************************************************************************************************************
        ** Loads all the Doors for the site into the listview control
        ***********************************************************************************************************************/
        {
            DoorSelectionList.Items.Clear();
            DoorSelectionList.GridLines = true;
            DoorSelectionList.View = View.Details;
            DoorSelectionList.Columns.Add("", 20);
            DoorSelectionList.Columns.Add("Name", -2);
            DoorSelectionList.Columns[0].TextAlign = HorizontalAlignment.Center;
            DoorSelectionList.Columns[1].TextAlign = HorizontalAlignment.Left;

            for (int i = 0; i < SharedDoorData.LockListPtr.Count; i++)
            {
                ListViewItem item1 = new ListViewItem("");
                item1.SubItems.Add(SharedDoorData.LockListPtr[i].Name );
                DoorSelectionList.Items.AddRange(new ListViewItem[] { item1 });
            }
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
            if (AllDoorSelected)
            {
                AllDoorSelected = false;
                for (int i = 0; i < DoorSelectionList.Items.Count; i++)
                {
                    DoorSelectionList.Items[i].Checked = false;
                }
            }
            else
            {
                AllDoorSelected = true;
                for (int i = 0; i < DoorSelectionList.Items.Count; i++)
                {
                    DoorSelectionList.Items[i].Checked = true;
                }
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NextUser_Click(object sender, EventArgs e)
        {
            SharedUserData.NextRequested = true;

            EditUserData();
            UpdateListViewAndWrite();

            //******************************************************************************************************************
            //* Set up for next user
            //******************************************************************************************************************
            _ParentForm.UserListView.Items[_ParentForm.UserListView.SelectedItems[0].Index + 1].Selected = true;
            _ParentForm.UserListView.Items[_ParentForm.UserListView.SelectedItems[0].Index].Selected = false;

            SetupForNextUser();

            UserUpdateForm_Load(sender, e);
            }

        private void PrevUser_Click(object sender, EventArgs e)
        {
            SharedUserData.PrevRequested = true;

            EditUserData();
            UpdateListViewAndWrite();

            //******************************************************************************************************************
            //* Set up for prev user
            //******************************************************************************************************************
            _ParentForm.UserListView.Items[_ParentForm.UserListView.SelectedItems[0].Index - 1].Selected = true;
            _ParentForm.UserListView.Items[_ParentForm.UserListView.SelectedItems[0].Index + 1].Selected = false;

            SetupForNextUser();

            UserUpdateForm_Load(sender, e);
        }
        private void UpdateListViewAndWrite()
        {
            //******************************************************************************************************************
            //* Update the Listview on the dialog 
            //******************************************************************************************************************
            ListViewItem selectedItem = _ParentForm.UserListView.SelectedItems[0];
            selectedItem.SubItems[0].Text = SharedUserData.num.ToString("000");
            selectedItem.SubItems[1].Text = SharedUserData.code.ToString();
            selectedItem.SubItems[2].Text = SharedUserData.name;
            selectedItem.SubItems[3].Text = SharedUserData.type;
            _ParentForm.WriteEplexUserData(_ParentForm.UserDataPathAndFile);

        }
        private void SetupForNextUser()
        {
            int UsrNum = Int32.Parse(_ParentForm.UserListView.SelectedItems[0].SubItems[0].Text);
            SharedUserData.num = _ParentForm.Users[UsrNum].Num;
            SharedUserData.name = _ParentForm.Users[UsrNum].Name;
            SharedUserData.code = _ParentForm.Users[UsrNum].Code;
            SharedUserData.type = _ParentForm.Users[UsrNum].Type;
            SharedUserData.ThisUserDoorListPtr = _ParentForm.Users[UsrNum].ThisUserDoorListPtr;
//            SharedDoorData.LockListPtr = Lock;

        }
    }
}
