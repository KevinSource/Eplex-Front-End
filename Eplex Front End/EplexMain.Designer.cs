namespace Eplex_Front_End
{
    partial class EplexLockManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EplexLockManagement));
            this.UserListView = new System.Windows.Forms.ListView();
            this.SiteListView = new System.Windows.Forms.ListView();
            this.DoorListView = new System.Windows.Forms.ListView();
            this.SiteGroupBox = new System.Windows.Forms.GroupBox();
            this.SiteGenerateButton = new System.Windows.Forms.Button();
            this.SiteDeleteButton = new System.Windows.Forms.Button();
            this.SiteRenameButton = new System.Windows.Forms.Button();
            this.SiteAdd = new System.Windows.Forms.Button();
            this.DoorGroupBox = new System.Windows.Forms.GroupBox();
            this.DoorUsersButton = new System.Windows.Forms.Button();
            this.DoorEditButton = new System.Windows.Forms.Button();
            this.DoorDeleteButton = new System.Windows.Forms.Button();
            this.DoorCopyButton = new System.Windows.Forms.Button();
            this.DoorAddButton = new System.Windows.Forms.Button();
            this.UserGroupBox = new System.Windows.Forms.GroupBox();
            this.UserDeleteButton = new System.Windows.Forms.Button();
            this.UserEditButton = new System.Windows.Forms.Button();
            this.UserAddButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.AuditBuildGroupBox = new System.Windows.Forms.GroupBox();
            this.AbortButton = new System.Windows.Forms.Button();
            this.AuditDoorUserStatus = new System.Windows.Forms.Label();
            this.AuditUserProgressBar = new System.Windows.Forms.ProgressBar();
            this.AuditDoorStatus = new System.Windows.Forms.Label();
            this.AuditDoorProgressBar = new System.Windows.Forms.ProgressBar();
            this.printProgressGroupBox = new System.Windows.Forms.GroupBox();
            this.DoorUserAbortButton = new System.Windows.Forms.Button();
            this.printProgessStatus = new System.Windows.Forms.Label();
            this.printProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.DoosBoxLabel = new System.Windows.Forms.Label();
            this.SitesLabel = new System.Windows.Forms.Label();
            this.UsersBackgroundBox = new System.Windows.Forms.TextBox();
            this.DoorsLockBackgroundBox = new System.Windows.Forms.TextBox();
            this.SiteBackgroundBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePCMUnitFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAuditFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameButton = new System.Windows.Forms.Button();
            this.SiteGroupBox.SuspendLayout();
            this.DoorGroupBox.SuspendLayout();
            this.UserGroupBox.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.AuditBuildGroupBox.SuspendLayout();
            this.printProgressGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserListView
            // 
            this.UserListView.FullRowSelect = true;
            this.UserListView.HideSelection = false;
            this.UserListView.Location = new System.Drawing.Point(435, 41);
            this.UserListView.Name = "UserListView";
            this.UserListView.Size = new System.Drawing.Size(427, 383);
            this.UserListView.TabIndex = 0;
            this.UserListView.UseCompatibleStateImageBehavior = false;
            this.UserListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.UserListView_ColumnClick);
            this.UserListView.DoubleClick += new System.EventHandler(this.UserListView_DoubleClick);
            this.UserListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserListView_KeyUp);
            this.UserListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserListView_MouseClick);
            // 
            // SiteListView
            // 
            this.SiteListView.FullRowSelect = true;
            this.SiteListView.HideSelection = false;
            this.SiteListView.Location = new System.Drawing.Point(3, 41);
            this.SiteListView.Name = "SiteListView";
            this.SiteListView.Size = new System.Drawing.Size(157, 221);
            this.SiteListView.TabIndex = 1;
            this.SiteListView.UseCompatibleStateImageBehavior = false;
            this.SiteListView.Visible = false;
            this.SiteListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SiteListView_ColumnClick);
            this.SiteListView.SelectedIndexChanged += new System.EventHandler(this.SiteListView_SelectedIndexChanged);
            // 
            // DoorListView
            // 
            this.DoorListView.FullRowSelect = true;
            this.DoorListView.HideSelection = false;
            this.DoorListView.Location = new System.Drawing.Point(166, 41);
            this.DoorListView.Name = "DoorListView";
            this.DoorListView.Size = new System.Drawing.Size(263, 347);
            this.DoorListView.TabIndex = 2;
            this.DoorListView.UseCompatibleStateImageBehavior = false;
            this.DoorListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DoorListView_ColumnClick);
            this.DoorListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DoorListView_KeyUp_1);
            this.DoorListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoorListView_MouseDoubleClick);
            // 
            // SiteGroupBox
            // 
            this.SiteGroupBox.Controls.Add(this.SiteGenerateButton);
            this.SiteGroupBox.Controls.Add(this.SiteDeleteButton);
            this.SiteGroupBox.Controls.Add(this.SiteRenameButton);
            this.SiteGroupBox.Controls.Add(this.SiteAdd);
            this.SiteGroupBox.Location = new System.Drawing.Point(3, 268);
            this.SiteGroupBox.Name = "SiteGroupBox";
            this.SiteGroupBox.Size = new System.Drawing.Size(157, 140);
            this.SiteGroupBox.TabIndex = 3;
            this.SiteGroupBox.TabStop = false;
            this.SiteGroupBox.Text = "Site Actions";
            // 
            // SiteGenerateButton
            // 
            this.SiteGenerateButton.Location = new System.Drawing.Point(15, 94);
            this.SiteGenerateButton.Name = "SiteGenerateButton";
            this.SiteGenerateButton.Size = new System.Drawing.Size(122, 26);
            this.SiteGenerateButton.TabIndex = 3;
            this.SiteGenerateButton.Text = "Generate PC M-Unit File";
            this.SiteGenerateButton.UseVisualStyleBackColor = true;
            this.SiteGenerateButton.Click += new System.EventHandler(this.SiteGenerateButton_Click);
            // 
            // SiteDeleteButton
            // 
            this.SiteDeleteButton.Location = new System.Drawing.Point(15, 51);
            this.SiteDeleteButton.Name = "SiteDeleteButton";
            this.SiteDeleteButton.Size = new System.Drawing.Size(52, 26);
            this.SiteDeleteButton.TabIndex = 2;
            this.SiteDeleteButton.Text = "Delete";
            this.SiteDeleteButton.UseVisualStyleBackColor = true;
            this.SiteDeleteButton.Click += new System.EventHandler(this.SiteDeleteButton_Click);
            // 
            // SiteRenameButton
            // 
            this.SiteRenameButton.Location = new System.Drawing.Point(73, 19);
            this.SiteRenameButton.Name = "SiteRenameButton";
            this.SiteRenameButton.Size = new System.Drawing.Size(64, 26);
            this.SiteRenameButton.TabIndex = 1;
            this.SiteRenameButton.Text = "Rename";
            this.SiteRenameButton.UseVisualStyleBackColor = true;
            this.SiteRenameButton.Click += new System.EventHandler(this.SiteRenameButton_Click);
            // 
            // SiteAdd
            // 
            this.SiteAdd.Location = new System.Drawing.Point(15, 19);
            this.SiteAdd.Name = "SiteAdd";
            this.SiteAdd.Size = new System.Drawing.Size(52, 26);
            this.SiteAdd.TabIndex = 0;
            this.SiteAdd.Text = "Add";
            this.SiteAdd.UseVisualStyleBackColor = true;
            this.SiteAdd.Click += new System.EventHandler(this.SiteAddButton_Click);
            // 
            // DoorGroupBox
            // 
            this.DoorGroupBox.Controls.Add(this.RenameButton);
            this.DoorGroupBox.Controls.Add(this.DoorUsersButton);
            this.DoorGroupBox.Controls.Add(this.DoorEditButton);
            this.DoorGroupBox.Controls.Add(this.DoorDeleteButton);
            this.DoorGroupBox.Controls.Add(this.DoorCopyButton);
            this.DoorGroupBox.Controls.Add(this.DoorAddButton);
            this.DoorGroupBox.Location = new System.Drawing.Point(179, 394);
            this.DoorGroupBox.Name = "DoorGroupBox";
            this.DoorGroupBox.Size = new System.Drawing.Size(227, 122);
            this.DoorGroupBox.TabIndex = 4;
            this.DoorGroupBox.TabStop = false;
            this.DoorGroupBox.Text = "Door Actions";
            // 
            // DoorUsersButton
            // 
            this.DoorUsersButton.Location = new System.Drawing.Point(19, 83);
            this.DoorUsersButton.Name = "DoorUsersButton";
            this.DoorUsersButton.Size = new System.Drawing.Size(168, 26);
            this.DoorUsersButton.TabIndex = 8;
            this.DoorUsersButton.Text = "Door Users";
            this.DoorUsersButton.UseVisualStyleBackColor = true;
            this.DoorUsersButton.Click += new System.EventHandler(this.DoorUsersButton_Click);
            // 
            // DoorEditButton
            // 
            this.DoorEditButton.Location = new System.Drawing.Point(135, 19);
            this.DoorEditButton.Name = "DoorEditButton";
            this.DoorEditButton.Size = new System.Drawing.Size(52, 26);
            this.DoorEditButton.TabIndex = 7;
            this.DoorEditButton.Text = "Edit";
            this.DoorEditButton.UseVisualStyleBackColor = true;
            this.DoorEditButton.Click += new System.EventHandler(this.DoorEditButton_Click);
            // 
            // DoorDeleteButton
            // 
            this.DoorDeleteButton.Location = new System.Drawing.Point(135, 51);
            this.DoorDeleteButton.Name = "DoorDeleteButton";
            this.DoorDeleteButton.Size = new System.Drawing.Size(52, 26);
            this.DoorDeleteButton.TabIndex = 5;
            this.DoorDeleteButton.Text = "Delete";
            this.DoorDeleteButton.UseVisualStyleBackColor = true;
            this.DoorDeleteButton.Click += new System.EventHandler(this.DoorDeleteButton_Click);
            // 
            // DoorCopyButton
            // 
            this.DoorCopyButton.Location = new System.Drawing.Point(77, 19);
            this.DoorCopyButton.Name = "DoorCopyButton";
            this.DoorCopyButton.Size = new System.Drawing.Size(52, 26);
            this.DoorCopyButton.TabIndex = 4;
            this.DoorCopyButton.Text = "Copy";
            this.DoorCopyButton.UseVisualStyleBackColor = true;
            this.DoorCopyButton.Click += new System.EventHandler(this.DoorCopyButton_Click);
            // 
            // DoorAddButton
            // 
            this.DoorAddButton.Location = new System.Drawing.Point(19, 19);
            this.DoorAddButton.Name = "DoorAddButton";
            this.DoorAddButton.Size = new System.Drawing.Size(52, 26);
            this.DoorAddButton.TabIndex = 3;
            this.DoorAddButton.Text = "Add";
            this.DoorAddButton.UseVisualStyleBackColor = true;
            this.DoorAddButton.Click += new System.EventHandler(this.DoorAddButton_Click);
            // 
            // UserGroupBox
            // 
            this.UserGroupBox.Controls.Add(this.UserDeleteButton);
            this.UserGroupBox.Controls.Add(this.UserEditButton);
            this.UserGroupBox.Controls.Add(this.UserAddButton);
            this.UserGroupBox.Location = new System.Drawing.Point(435, 430);
            this.UserGroupBox.Name = "UserGroupBox";
            this.UserGroupBox.Size = new System.Drawing.Size(427, 89);
            this.UserGroupBox.TabIndex = 5;
            this.UserGroupBox.TabStop = false;
            this.UserGroupBox.Text = "User Actions";
            // 
            // UserDeleteButton
            // 
            this.UserDeleteButton.Location = new System.Drawing.Point(133, 19);
            this.UserDeleteButton.Name = "UserDeleteButton";
            this.UserDeleteButton.Size = new System.Drawing.Size(52, 26);
            this.UserDeleteButton.TabIndex = 9;
            this.UserDeleteButton.Text = "Delete";
            this.UserDeleteButton.UseVisualStyleBackColor = true;
            this.UserDeleteButton.Click += new System.EventHandler(this.UserDeleteButton_Click);
            // 
            // UserEditButton
            // 
            this.UserEditButton.Location = new System.Drawing.Point(75, 19);
            this.UserEditButton.Name = "UserEditButton";
            this.UserEditButton.Size = new System.Drawing.Size(52, 26);
            this.UserEditButton.TabIndex = 8;
            this.UserEditButton.Text = "Edit";
            this.UserEditButton.UseVisualStyleBackColor = true;
            this.UserEditButton.Click += new System.EventHandler(this.UserEditButton_Click);
            // 
            // UserAddButton
            // 
            this.UserAddButton.Location = new System.Drawing.Point(17, 19);
            this.UserAddButton.Name = "UserAddButton";
            this.UserAddButton.Size = new System.Drawing.Size(52, 26);
            this.UserAddButton.TabIndex = 7;
            this.UserAddButton.Text = "Add";
            this.UserAddButton.UseVisualStyleBackColor = true;
            this.UserAddButton.Click += new System.EventHandler(this.UserAddButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(18, 484);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(52, 26);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.AuditBuildGroupBox);
            this.UserPanel.Controls.Add(this.printProgressGroupBox);
            this.UserPanel.Controls.Add(this.label1);
            this.UserPanel.Controls.Add(this.DoosBoxLabel);
            this.UserPanel.Controls.Add(this.SitesLabel);
            this.UserPanel.Controls.Add(this.UsersBackgroundBox);
            this.UserPanel.Controls.Add(this.DoorsLockBackgroundBox);
            this.UserPanel.Controls.Add(this.SiteBackgroundBox);
            this.UserPanel.Controls.Add(this.ExitButton);
            this.UserPanel.Controls.Add(this.UserGroupBox);
            this.UserPanel.Controls.Add(this.DoorGroupBox);
            this.UserPanel.Controls.Add(this.SiteGroupBox);
            this.UserPanel.Controls.Add(this.DoorListView);
            this.UserPanel.Controls.Add(this.SiteListView);
            this.UserPanel.Controls.Add(this.UserListView);
            this.UserPanel.Location = new System.Drawing.Point(12, 38);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(865, 526);
            this.UserPanel.TabIndex = 2;
            // 
            // AuditBuildGroupBox
            // 
            this.AuditBuildGroupBox.Controls.Add(this.AbortButton);
            this.AuditBuildGroupBox.Controls.Add(this.AuditDoorUserStatus);
            this.AuditBuildGroupBox.Controls.Add(this.AuditUserProgressBar);
            this.AuditBuildGroupBox.Controls.Add(this.AuditDoorStatus);
            this.AuditBuildGroupBox.Controls.Add(this.AuditDoorProgressBar);
            this.AuditBuildGroupBox.Location = new System.Drawing.Point(487, 32);
            this.AuditBuildGroupBox.Name = "AuditBuildGroupBox";
            this.AuditBuildGroupBox.Size = new System.Drawing.Size(366, 210);
            this.AuditBuildGroupBox.TabIndex = 11;
            this.AuditBuildGroupBox.TabStop = false;
            this.AuditBuildGroupBox.Text = "Audit Progress";
            this.AuditBuildGroupBox.Visible = false;
            // 
            // AbortButton
            // 
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Location = new System.Drawing.Point(126, 155);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(84, 26);
            this.AbortButton.TabIndex = 8;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // AuditDoorUserStatus
            // 
            this.AuditDoorUserStatus.AutoSize = true;
            this.AuditDoorUserStatus.Location = new System.Drawing.Point(30, 88);
            this.AuditDoorUserStatus.Name = "AuditDoorUserStatus";
            this.AuditDoorUserStatus.Size = new System.Drawing.Size(61, 13);
            this.AuditDoorUserStatus.TabIndex = 7;
            this.AuditDoorUserStatus.Text = "User n of m";
            this.AuditDoorUserStatus.Visible = false;
            // 
            // AuditUserProgressBar
            // 
            this.AuditUserProgressBar.Location = new System.Drawing.Point(28, 113);
            this.AuditUserProgressBar.Name = "AuditUserProgressBar";
            this.AuditUserProgressBar.Size = new System.Drawing.Size(300, 18);
            this.AuditUserProgressBar.TabIndex = 6;
            this.AuditUserProgressBar.Visible = false;
            // 
            // AuditDoorStatus
            // 
            this.AuditDoorStatus.AutoSize = true;
            this.AuditDoorStatus.Location = new System.Drawing.Point(30, 25);
            this.AuditDoorStatus.Name = "AuditDoorStatus";
            this.AuditDoorStatus.Size = new System.Drawing.Size(58, 13);
            this.AuditDoorStatus.TabIndex = 5;
            this.AuditDoorStatus.Text = "Door x of y";
            this.AuditDoorStatus.Visible = false;
            // 
            // AuditDoorProgressBar
            // 
            this.AuditDoorProgressBar.Location = new System.Drawing.Point(28, 50);
            this.AuditDoorProgressBar.Name = "AuditDoorProgressBar";
            this.AuditDoorProgressBar.Size = new System.Drawing.Size(300, 18);
            this.AuditDoorProgressBar.TabIndex = 4;
            this.AuditDoorProgressBar.Visible = false;
            // 
            // printProgressGroupBox
            // 
            this.printProgressGroupBox.Controls.Add(this.DoorUserAbortButton);
            this.printProgressGroupBox.Controls.Add(this.printProgessStatus);
            this.printProgressGroupBox.Controls.Add(this.printProgressBar);
            this.printProgressGroupBox.Location = new System.Drawing.Point(126, 120);
            this.printProgressGroupBox.Name = "printProgressGroupBox";
            this.printProgressGroupBox.Size = new System.Drawing.Size(366, 129);
            this.printProgressGroupBox.TabIndex = 10;
            this.printProgressGroupBox.TabStop = false;
            this.printProgressGroupBox.Text = "Print Progress";
            // 
            // DoorUserAbortButton
            // 
            this.DoorUserAbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoorUserAbortButton.Location = new System.Drawing.Point(130, 84);
            this.DoorUserAbortButton.Name = "DoorUserAbortButton";
            this.DoorUserAbortButton.Size = new System.Drawing.Size(83, 23);
            this.DoorUserAbortButton.TabIndex = 6;
            this.DoorUserAbortButton.Text = "Abort";
            this.DoorUserAbortButton.UseVisualStyleBackColor = true;
            this.DoorUserAbortButton.Click += new System.EventHandler(this.DoorUserAbortButton_Click);
            // 
            // printProgessStatus
            // 
            this.printProgessStatus.AutoSize = true;
            this.printProgessStatus.Location = new System.Drawing.Point(30, 25);
            this.printProgessStatus.Name = "printProgessStatus";
            this.printProgessStatus.Size = new System.Drawing.Size(35, 13);
            this.printProgessStatus.TabIndex = 5;
            this.printProgessStatus.Text = "label2";
            // 
            // printProgressBar
            // 
            this.printProgressBar.Location = new System.Drawing.Point(28, 50);
            this.printProgressBar.Name = "printProgressBar";
            this.printProgressBar.Size = new System.Drawing.Size(300, 18);
            this.printProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(581, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Users";
            // 
            // DoosBoxLabel
            // 
            this.DoosBoxLabel.AutoSize = true;
            this.DoosBoxLabel.BackColor = System.Drawing.SystemColors.Info;
            this.DoosBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoosBoxLabel.Location = new System.Drawing.Point(258, 16);
            this.DoosBoxLabel.Name = "DoosBoxLabel";
            this.DoosBoxLabel.Size = new System.Drawing.Size(114, 24);
            this.DoosBoxLabel.TabIndex = 8;
            this.DoosBoxLabel.Text = "Doors/Locks";
            // 
            // SitesLabel
            // 
            this.SitesLabel.AutoSize = true;
            this.SitesLabel.BackColor = System.Drawing.SystemColors.Info;
            this.SitesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SitesLabel.Location = new System.Drawing.Point(49, 18);
            this.SitesLabel.Name = "SitesLabel";
            this.SitesLabel.Size = new System.Drawing.Size(50, 24);
            this.SitesLabel.TabIndex = 4;
            this.SitesLabel.Text = "Sites";
            // 
            // UsersBackgroundBox
            // 
            this.UsersBackgroundBox.BackColor = System.Drawing.SystemColors.Info;
            this.UsersBackgroundBox.Enabled = false;
            this.UsersBackgroundBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersBackgroundBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UsersBackgroundBox.Location = new System.Drawing.Point(435, 15);
            this.UsersBackgroundBox.Name = "UsersBackgroundBox";
            this.UsersBackgroundBox.Size = new System.Drawing.Size(427, 29);
            this.UsersBackgroundBox.TabIndex = 7;
            this.UsersBackgroundBox.TabStop = false;
            this.UsersBackgroundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DoorsLockBackgroundBox
            // 
            this.DoorsLockBackgroundBox.BackColor = System.Drawing.SystemColors.Info;
            this.DoorsLockBackgroundBox.Enabled = false;
            this.DoorsLockBackgroundBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorsLockBackgroundBox.Location = new System.Drawing.Point(166, 15);
            this.DoorsLockBackgroundBox.Name = "DoorsLockBackgroundBox";
            this.DoorsLockBackgroundBox.Size = new System.Drawing.Size(263, 29);
            this.DoorsLockBackgroundBox.TabIndex = 6;
            this.DoorsLockBackgroundBox.TabStop = false;
            this.DoorsLockBackgroundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SiteBackgroundBox
            // 
            this.SiteBackgroundBox.BackColor = System.Drawing.SystemColors.Info;
            this.SiteBackgroundBox.Enabled = false;
            this.SiteBackgroundBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiteBackgroundBox.Location = new System.Drawing.Point(3, 15);
            this.SiteBackgroundBox.Name = "SiteBackgroundBox";
            this.SiteBackgroundBox.Size = new System.Drawing.Size(157, 29);
            this.SiteBackgroundBox.TabIndex = 4;
            this.SiteBackgroundBox.TabStop = false;
            this.SiteBackgroundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.auditToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(889, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.generatePCMUnitFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // generatePCMUnitFileToolStripMenuItem
            // 
            this.generatePCMUnitFileToolStripMenuItem.Name = "generatePCMUnitFileToolStripMenuItem";
            this.generatePCMUnitFileToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.generatePCMUnitFileToolStripMenuItem.Text = "Generate PC M-Unit File";
            this.generatePCMUnitFileToolStripMenuItem.Click += new System.EventHandler(this.generatePCMUnitFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // auditToolStripMenuItem
            // 
            this.auditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildAuditFilesToolStripMenuItem});
            this.auditToolStripMenuItem.Name = "auditToolStripMenuItem";
            this.auditToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.auditToolStripMenuItem.Text = "Audit";
            // 
            // buildAuditFilesToolStripMenuItem
            // 
            this.buildAuditFilesToolStripMenuItem.Name = "buildAuditFilesToolStripMenuItem";
            this.buildAuditFilesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.buildAuditFilesToolStripMenuItem.Text = "Build Audit Report";
            this.buildAuditFilesToolStripMenuItem.Click += new System.EventHandler(this.buildAuditFilesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLocationsToolStripMenuItem,
            this.fileToolStripMenuItem1,
            this.reportFilesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // fileLocationsToolStripMenuItem
            // 
            this.fileLocationsToolStripMenuItem.Name = "fileLocationsToolStripMenuItem";
            this.fileLocationsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.fileLocationsToolStripMenuItem.Text = "File Locations";
            this.fileLocationsToolStripMenuItem.Click += new System.EventHandler(this.fileLocationsToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.fileToolStripMenuItem1.Text = "Data Files";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // reportFilesToolStripMenuItem
            // 
            this.reportFilesToolStripMenuItem.Name = "reportFilesToolStripMenuItem";
            this.reportFilesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.reportFilesToolStripMenuItem.Text = "Report Files";
            this.reportFilesToolStripMenuItem.Click += new System.EventHandler(this.reportFilesToolStripMenuItem_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(19, 51);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(110, 26);
            this.RenameButton.TabIndex = 9;
            this.RenameButton.Text = "Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // EplexLockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(889, 576);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.UserPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EplexLockManagement";
            this.Text = "Eplex Lock Management";
            this.Load += new System.EventHandler(this.EplexLockManagement_Load);
            this.SiteGroupBox.ResumeLayout(false);
            this.DoorGroupBox.ResumeLayout(false);
            this.UserGroupBox.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.AuditBuildGroupBox.ResumeLayout(false);
            this.AuditBuildGroupBox.PerformLayout();
            this.printProgressGroupBox.ResumeLayout(false);
            this.printProgressGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListView UserListView;
        private System.Windows.Forms.ListView SiteListView;
        private System.Windows.Forms.ListView DoorListView;
        private System.Windows.Forms.GroupBox SiteGroupBox;
        private System.Windows.Forms.Button SiteGenerateButton;
        private System.Windows.Forms.Button SiteDeleteButton;
        private System.Windows.Forms.Button SiteRenameButton;
        private System.Windows.Forms.Button SiteAdd;
        private System.Windows.Forms.GroupBox DoorGroupBox;
        private System.Windows.Forms.Button DoorEditButton;
        private System.Windows.Forms.Button DoorDeleteButton;
        private System.Windows.Forms.Button DoorCopyButton;
        private System.Windows.Forms.Button DoorAddButton;
        private System.Windows.Forms.GroupBox UserGroupBox;
        private System.Windows.Forms.Button UserDeleteButton;
        private System.Windows.Forms.Button UserEditButton;
        private System.Windows.Forms.Button UserAddButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox DoorsLockBackgroundBox;
        private System.Windows.Forms.TextBox SiteBackgroundBox;
        private System.Windows.Forms.TextBox UsersBackgroundBox;
        private System.Windows.Forms.Label SitesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DoosBoxLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileLocationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.Button DoorUsersButton;
        public System.Windows.Forms.GroupBox printProgressGroupBox;
        public System.Windows.Forms.ProgressBar printProgressBar;
        public System.Windows.Forms.Label printProgessStatus;
        private System.Windows.Forms.ToolStripMenuItem reportFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAuditFilesToolStripMenuItem;
        public System.Windows.Forms.GroupBox AuditBuildGroupBox;
        public System.Windows.Forms.Label AuditDoorUserStatus;
        public System.Windows.Forms.ProgressBar AuditUserProgressBar;
        public System.Windows.Forms.Label AuditDoorStatus;
        public System.Windows.Forms.ProgressBar AuditDoorProgressBar;
        private System.Windows.Forms.ToolStripMenuItem generatePCMUnitFileToolStripMenuItem;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button DoorUserAbortButton;
        private System.Windows.Forms.Button RenameButton;
    }
}

