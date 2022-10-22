namespace Eplex_Front_End
{
    partial class UserUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserNumberLit = new System.Windows.Forms.Label();
            this.UserNumber = new System.Windows.Forms.Label();
            this.AccessCodeLit = new System.Windows.Forms.Label();
            this.UserNameLit = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.AccessCode = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.AccessUserRadioButton = new System.Windows.Forms.RadioButton();
            this.ManagerRadioButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.AccessCodeGrpBox = new System.Windows.Forms.GroupBox();
            this.DoorSelectionList = new System.Windows.Forms.ListView();
            this.SiteDoorsLabel = new System.Windows.Forms.GroupBox();
            this.UserSelectAllToggle = new System.Windows.Forms.Button();
            this.PrevUser = new System.Windows.Forms.Button();
            this.NextUser = new System.Windows.Forms.Button();
            this.GenerateRandomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccessCode)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.AccessCodeGrpBox.SuspendLayout();
            this.SiteDoorsLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNumberLit
            // 
            this.UserNumberLit.AutoSize = true;
            this.UserNumberLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNumberLit.Location = new System.Drawing.Point(12, 30);
            this.UserNumberLit.Name = "UserNumberLit";
            this.UserNumberLit.Size = new System.Drawing.Size(157, 29);
            this.UserNumberLit.TabIndex = 0;
            this.UserNumberLit.Text = "User Number";
            // 
            // UserNumber
            // 
            this.UserNumber.AutoSize = true;
            this.UserNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNumber.Location = new System.Drawing.Point(175, 30);
            this.UserNumber.Name = "UserNumber";
            this.UserNumber.Size = new System.Drawing.Size(151, 29);
            this.UserNumber.TabIndex = 1;
            this.UserNumber.Text = "UserNumber";
            // 
            // AccessCodeLit
            // 
            this.AccessCodeLit.AutoSize = true;
            this.AccessCodeLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessCodeLit.Location = new System.Drawing.Point(29, 109);
            this.AccessCodeLit.Name = "AccessCodeLit";
            this.AccessCodeLit.Size = new System.Drawing.Size(123, 24);
            this.AccessCodeLit.TabIndex = 3;
            this.AccessCodeLit.Text = "Access Code";
            // 
            // UserNameLit
            // 
            this.UserNameLit.AutoSize = true;
            this.UserNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLit.Location = new System.Drawing.Point(47, 73);
            this.UserNameLit.Name = "UserNameLit";
            this.UserNameLit.Size = new System.Drawing.Size(105, 24);
            this.UserNameLit.TabIndex = 4;
            this.UserNameLit.Text = "User Name";
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(165, 70);
            this.UserName.MaxLength = 25;
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(288, 29);
            this.UserName.TabIndex = 5;
            this.UserName.Text = "UserName";
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // AccessCode
            // 
            this.AccessCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessCode.Location = new System.Drawing.Point(165, 106);
            this.AccessCode.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.AccessCode.Name = "AccessCode";
            this.AccessCode.Size = new System.Drawing.Size(146, 29);
            this.AccessCode.TabIndex = 6;
            this.AccessCode.Enter += new System.EventHandler(this.AccessCode_Enter);
            this.AccessCode.Leave += new System.EventHandler(this.AccessCode_Leave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(928, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusMsg
            // 
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.Size = new System.Drawing.Size(62, 17);
            this.StatusMsg.Text = "StatusMsg";
            // 
            // AccessUserRadioButton
            // 
            this.AccessUserRadioButton.AutoSize = true;
            this.AccessUserRadioButton.Checked = true;
            this.AccessUserRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessUserRadioButton.Location = new System.Drawing.Point(34, 28);
            this.AccessUserRadioButton.Name = "AccessUserRadioButton";
            this.AccessUserRadioButton.Size = new System.Drawing.Size(67, 28);
            this.AccessUserRadioButton.TabIndex = 8;
            this.AccessUserRadioButton.TabStop = true;
            this.AccessUserRadioButton.Text = "User";
            this.AccessUserRadioButton.UseVisualStyleBackColor = true;
            this.AccessUserRadioButton.CheckedChanged += new System.EventHandler(this.AccessUserRadioButton_CheckedChanged);
            // 
            // ManagerRadioButton
            // 
            this.ManagerRadioButton.AutoSize = true;
            this.ManagerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManagerRadioButton.Location = new System.Drawing.Point(107, 28);
            this.ManagerRadioButton.Name = "ManagerRadioButton";
            this.ManagerRadioButton.Size = new System.Drawing.Size(103, 28);
            this.ManagerRadioButton.TabIndex = 9;
            this.ManagerRadioButton.Text = "Manager";
            this.ManagerRadioButton.UseVisualStyleBackColor = true;
            this.ManagerRadioButton.CheckedChanged += new System.EventHandler(this.ManagerRadioButton_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(17, 368);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 31);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            this.OKButton.MouseEnter += new System.EventHandler(this.OKButton_MouseEnter);
            this.OKButton.MouseLeave += new System.EventHandler(this.OKButton_MouseLeave);
            // 
            // CancelButton1
            // 
            this.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.Location = new System.Drawing.Point(127, 368);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(90, 31);
            this.CancelButton1.TabIndex = 11;
            this.CancelButton1.Text = "&Cancel";
            this.CancelButton1.UseVisualStyleBackColor = true;
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
            this.CancelButton1.MouseEnter += new System.EventHandler(this.CancelButton1_MouseEnter);
            this.CancelButton1.MouseLeave += new System.EventHandler(this.CancelButton1_MouseLeave);
            // 
            // AccessCodeGrpBox
            // 
            this.AccessCodeGrpBox.Controls.Add(this.AccessUserRadioButton);
            this.AccessCodeGrpBox.Controls.Add(this.ManagerRadioButton);
            this.AccessCodeGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessCodeGrpBox.Location = new System.Drawing.Point(33, 144);
            this.AccessCodeGrpBox.Name = "AccessCodeGrpBox";
            this.AccessCodeGrpBox.Size = new System.Drawing.Size(265, 71);
            this.AccessCodeGrpBox.TabIndex = 12;
            this.AccessCodeGrpBox.TabStop = false;
            this.AccessCodeGrpBox.Text = "Access Type";
            // 
            // DoorSelectionList
            // 
            this.DoorSelectionList.CheckBoxes = true;
            this.DoorSelectionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorSelectionList.FullRowSelect = true;
            this.DoorSelectionList.HideSelection = false;
            this.DoorSelectionList.Location = new System.Drawing.Point(14, 29);
            this.DoorSelectionList.Name = "DoorSelectionList";
            this.DoorSelectionList.Size = new System.Drawing.Size(346, 294);
            this.DoorSelectionList.TabIndex = 13;
            this.DoorSelectionList.UseCompatibleStateImageBehavior = false;
            // 
            // SiteDoorsLabel
            // 
            this.SiteDoorsLabel.Controls.Add(this.UserSelectAllToggle);
            this.SiteDoorsLabel.Controls.Add(this.DoorSelectionList);
            this.SiteDoorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiteDoorsLabel.Location = new System.Drawing.Point(544, 8);
            this.SiteDoorsLabel.Name = "SiteDoorsLabel";
            this.SiteDoorsLabel.Size = new System.Drawing.Size(371, 409);
            this.SiteDoorsLabel.TabIndex = 14;
            this.SiteDoorsLabel.TabStop = false;
            this.SiteDoorsLabel.Text = "Site  Doors";
            // 
            // UserSelectAllToggle
            // 
            this.UserSelectAllToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSelectAllToggle.Location = new System.Drawing.Point(52, 354);
            this.UserSelectAllToggle.Name = "UserSelectAllToggle";
            this.UserSelectAllToggle.Size = new System.Drawing.Size(135, 31);
            this.UserSelectAllToggle.TabIndex = 14;
            this.UserSelectAllToggle.Text = "Toggle All";
            this.UserSelectAllToggle.UseVisualStyleBackColor = true;
            this.UserSelectAllToggle.Click += new System.EventHandler(this.UserSelectAllToggle_Click);
            // 
            // PrevUser
            // 
            this.PrevUser.Location = new System.Drawing.Point(17, 241);
            this.PrevUser.Name = "PrevUser";
            this.PrevUser.Size = new System.Drawing.Size(135, 27);
            this.PrevUser.TabIndex = 15;
            this.PrevUser.Text = "< -- Previous User";
            this.PrevUser.UseVisualStyleBackColor = true;
            this.PrevUser.Click += new System.EventHandler(this.PrevUser_Click);
            // 
            // NextUser
            // 
            this.NextUser.Location = new System.Drawing.Point(158, 241);
            this.NextUser.Name = "NextUser";
            this.NextUser.Size = new System.Drawing.Size(135, 27);
            this.NextUser.TabIndex = 16;
            this.NextUser.Text = "Next User ->";
            this.NextUser.UseVisualStyleBackColor = true;
            this.NextUser.Click += new System.EventHandler(this.NextUser_Click);
            // 
            // GenerateRandomButton
            // 
            this.GenerateRandomButton.Location = new System.Drawing.Point(325, 106);
            this.GenerateRandomButton.Name = "GenerateRandomButton";
            this.GenerateRandomButton.Size = new System.Drawing.Size(196, 28);
            this.GenerateRandomButton.TabIndex = 17;
            this.GenerateRandomButton.Text = "Generate Random";
            this.GenerateRandomButton.UseVisualStyleBackColor = true;
            this.GenerateRandomButton.Click += new System.EventHandler(this.GenerateRandomButton_Click);
            // 
            // UserUpdateForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton1;
            this.ClientSize = new System.Drawing.Size(928, 450);
            this.Controls.Add(this.GenerateRandomButton);
            this.Controls.Add(this.NextUser);
            this.Controls.Add(this.PrevUser);
            this.Controls.Add(this.SiteDoorsLabel);
            this.Controls.Add(this.AccessCodeGrpBox);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.AccessCode);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.UserNameLit);
            this.Controls.Add(this.AccessCodeLit);
            this.Controls.Add(this.UserNumber);
            this.Controls.Add(this.UserNumberLit);
            this.Name = "UserUpdateForm";
            this.Text = "User Add/Change/Delete";
            this.Load += new System.EventHandler(this.UserUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccessCode)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.AccessCodeGrpBox.ResumeLayout(false);
            this.AccessCodeGrpBox.PerformLayout();
            this.SiteDoorsLabel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNumberLit;
        private System.Windows.Forms.Label UserNumber;
        private System.Windows.Forms.Label AccessCodeLit;
        private System.Windows.Forms.Label UserNameLit;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.NumericUpDown AccessCode;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusMsg;
        private System.Windows.Forms.RadioButton AccessUserRadioButton;
        private System.Windows.Forms.RadioButton ManagerRadioButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.GroupBox AccessCodeGrpBox;
        private System.Windows.Forms.ListView DoorSelectionList;
        private System.Windows.Forms.GroupBox SiteDoorsLabel;
        private System.Windows.Forms.Button UserSelectAllToggle;
        public System.Windows.Forms.Button PrevUser;
        public System.Windows.Forms.Button NextUser;
        private System.Windows.Forms.Button GenerateRandomButton;
    }
}