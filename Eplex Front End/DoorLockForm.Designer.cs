namespace Eplex_Front_End
{
    partial class DoorLockForm
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
            this.SiteName = new System.Windows.Forms.Label();
            this.DoorNameLit = new System.Windows.Forms.Label();
            this.DoorName = new System.Windows.Forms.TextBox();
            this.LockID = new System.Windows.Forms.TextBox();
            this.LockIDLit = new System.Windows.Forms.Label();
            this.LockFunctionLit = new System.Windows.Forms.Label();
            this.LockFunction = new System.Windows.Forms.ComboBox();
            this.UnlockTime = new System.Windows.Forms.NumericUpDown();
            this.UnlockTimeLit = new System.Windows.Forms.Label();
            this.BuzzerVolumeLit = new System.Windows.Forms.Label();
            this.BuzzerVolume = new System.Windows.Forms.NumericUpDown();
            this.TamperCountLit = new System.Windows.Forms.Label();
            this.TamperCount = new System.Windows.Forms.NumericUpDown();
            this.TamperShutdownTimeLit = new System.Windows.Forms.Label();
            this.TamperShutdownTime = new System.Windows.Forms.NumericUpDown();
            this.PassageModeLit = new System.Windows.Forms.Label();
            this.PassageModeActivated = new System.Windows.Forms.RadioButton();
            this.PassageModeDeactivated = new System.Windows.Forms.RadioButton();
            this.PassageModeOpenTime = new System.Windows.Forms.Label();
            this.PassageOpenTime = new System.Windows.Forms.NumericUpDown();
            this.LockoutModeDeactivated = new System.Windows.Forms.RadioButton();
            this.LockoutModeActivated = new System.Windows.Forms.RadioButton();
            this.PassageGroupBox = new System.Windows.Forms.GroupBox();
            this.LockoutModeGrpBox = new System.Windows.Forms.GroupBox();
            this.AccessCodeLengthLit = new System.Windows.Forms.Label();
            this.AccessCodeLength = new System.Windows.Forms.NumericUpDown();
            this.RemoteUnlockGrp = new System.Windows.Forms.GroupBox();
            this.RemoteUnlockActivated = new System.Windows.Forms.RadioButton();
            this.RemoteUnlockDeactivated = new System.Windows.Forms.RadioButton();
            this.LatchHoldbackGrp = new System.Windows.Forms.GroupBox();
            this.LatchHoldbackActivated = new System.Windows.Forms.RadioButton();
            this.LatchHoldbackDeactivated = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.myCancelBtn = new System.Windows.Forms.Button();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DoorStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.DoorAuditAllToggle = new System.Windows.Forms.Button();
            this.AuditLit = new System.Windows.Forms.Label();
            this.AuditBackgroundBox = new System.Windows.Forms.TextBox();
            this.AuditFlagListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.UnlockTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuzzerVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TamperCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TamperShutdownTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassageOpenTime)).BeginInit();
            this.PassageGroupBox.SuspendLayout();
            this.LockoutModeGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccessCodeLength)).BeginInit();
            this.RemoteUnlockGrp.SuspendLayout();
            this.LatchHoldbackGrp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SiteName
            // 
            this.SiteName.AutoSize = true;
            this.SiteName.BackColor = System.Drawing.SystemColors.Info;
            this.SiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiteName.Location = new System.Drawing.Point(23, 16);
            this.SiteName.Name = "SiteName";
            this.SiteName.Size = new System.Drawing.Size(79, 20);
            this.SiteName.TabIndex = 0;
            this.SiteName.Text = "SiteName";
            // 
            // DoorNameLit
            // 
            this.DoorNameLit.AutoSize = true;
            this.DoorNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorNameLit.Location = new System.Drawing.Point(12, 54);
            this.DoorNameLit.Name = "DoorNameLit";
            this.DoorNameLit.Size = new System.Drawing.Size(90, 20);
            this.DoorNameLit.TabIndex = 1;
            this.DoorNameLit.Text = "Door Name";
            // 
            // DoorName
            // 
            this.DoorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorName.Location = new System.Drawing.Point(108, 51);
            this.DoorName.Name = "DoorName";
            this.DoorName.Size = new System.Drawing.Size(167, 26);
            this.DoorName.TabIndex = 2;
            this.DoorName.Text = "DoorName";
            // 
            // LockID
            // 
            this.LockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockID.Location = new System.Drawing.Point(108, 83);
            this.LockID.Name = "LockID";
            this.LockID.Size = new System.Drawing.Size(167, 26);
            this.LockID.TabIndex = 4;
            this.LockID.Text = "LockID";
            // 
            // LockIDLit
            // 
            this.LockIDLit.AutoSize = true;
            this.LockIDLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockIDLit.Location = new System.Drawing.Point(12, 86);
            this.LockIDLit.Name = "LockIDLit";
            this.LockIDLit.Size = new System.Drawing.Size(64, 20);
            this.LockIDLit.TabIndex = 3;
            this.LockIDLit.Text = "Lock ID";
            // 
            // LockFunctionLit
            // 
            this.LockFunctionLit.AutoSize = true;
            this.LockFunctionLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockFunctionLit.Location = new System.Drawing.Point(12, 124);
            this.LockFunctionLit.Name = "LockFunctionLit";
            this.LockFunctionLit.Size = new System.Drawing.Size(109, 20);
            this.LockFunctionLit.TabIndex = 5;
            this.LockFunctionLit.Text = "Lock Function";
            // 
            // LockFunction
            // 
            this.LockFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockFunction.FormattingEnabled = true;
            this.LockFunction.Location = new System.Drawing.Point(127, 121);
            this.LockFunction.Name = "LockFunction";
            this.LockFunction.Size = new System.Drawing.Size(195, 28);
            this.LockFunction.TabIndex = 6;
            // 
            // UnlockTime
            // 
            this.UnlockTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnlockTime.Location = new System.Drawing.Point(227, 161);
            this.UnlockTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.UnlockTime.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UnlockTime.Name = "UnlockTime";
            this.UnlockTime.Size = new System.Drawing.Size(38, 26);
            this.UnlockTime.TabIndex = 7;
            this.UnlockTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // UnlockTimeLit
            // 
            this.UnlockTimeLit.AutoSize = true;
            this.UnlockTimeLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnlockTimeLit.Location = new System.Drawing.Point(12, 163);
            this.UnlockTimeLit.Name = "UnlockTimeLit";
            this.UnlockTimeLit.Size = new System.Drawing.Size(209, 20);
            this.UnlockTimeLit.TabIndex = 8;
            this.UnlockTimeLit.Text = "Unlock Time (2-20 Seconds)";
            // 
            // BuzzerVolumeLit
            // 
            this.BuzzerVolumeLit.AutoSize = true;
            this.BuzzerVolumeLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuzzerVolumeLit.Location = new System.Drawing.Point(12, 194);
            this.BuzzerVolumeLit.Name = "BuzzerVolumeLit";
            this.BuzzerVolumeLit.Size = new System.Drawing.Size(221, 20);
            this.BuzzerVolumeLit.TabIndex = 9;
            this.BuzzerVolumeLit.Text = "Buzzer Volume (0-Min, 3-Max)";
            // 
            // BuzzerVolume
            // 
            this.BuzzerVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuzzerVolume.Location = new System.Drawing.Point(239, 192);
            this.BuzzerVolume.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.BuzzerVolume.Name = "BuzzerVolume";
            this.BuzzerVolume.Size = new System.Drawing.Size(38, 26);
            this.BuzzerVolume.TabIndex = 10;
            this.BuzzerVolume.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // TamperCountLit
            // 
            this.TamperCountLit.AutoSize = true;
            this.TamperCountLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TamperCountLit.Location = new System.Drawing.Point(12, 230);
            this.TamperCountLit.Name = "TamperCountLit";
            this.TamperCountLit.Size = new System.Drawing.Size(224, 20);
            this.TamperCountLit.TabIndex = 11;
            this.TamperCountLit.Text = "Tamper Count(3 to 9 Attemps)";
            // 
            // TamperCount
            // 
            this.TamperCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TamperCount.Location = new System.Drawing.Point(242, 228);
            this.TamperCount.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.TamperCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.TamperCount.Name = "TamperCount";
            this.TamperCount.Size = new System.Drawing.Size(38, 26);
            this.TamperCount.TabIndex = 12;
            this.TamperCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // TamperShutdownTimeLit
            // 
            this.TamperShutdownTimeLit.AutoSize = true;
            this.TamperShutdownTimeLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TamperShutdownTimeLit.Location = new System.Drawing.Point(12, 266);
            this.TamperShutdownTimeLit.Name = "TamperShutdownTimeLit";
            this.TamperShutdownTimeLit.Size = new System.Drawing.Size(307, 20);
            this.TamperShutdownTimeLit.TabIndex = 13;
            this.TamperShutdownTimeLit.Text = "Tamper Shutdown Time (0 to 90 Seconds)";
            // 
            // TamperShutdownTime
            // 
            this.TamperShutdownTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TamperShutdownTime.Location = new System.Drawing.Point(325, 264);
            this.TamperShutdownTime.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.TamperShutdownTime.Name = "TamperShutdownTime";
            this.TamperShutdownTime.Size = new System.Drawing.Size(38, 26);
            this.TamperShutdownTime.TabIndex = 14;
            this.TamperShutdownTime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // PassageModeLit
            // 
            this.PassageModeLit.AutoSize = true;
            this.PassageModeLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageModeLit.Location = new System.Drawing.Point(21, 27);
            this.PassageModeLit.Name = "PassageModeLit";
            this.PassageModeLit.Size = new System.Drawing.Size(49, 20);
            this.PassageModeLit.TabIndex = 15;
            this.PassageModeLit.Text = "Mode";
            // 
            // PassageModeActivated
            // 
            this.PassageModeActivated.AutoSize = true;
            this.PassageModeActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageModeActivated.Location = new System.Drawing.Point(116, 25);
            this.PassageModeActivated.Name = "PassageModeActivated";
            this.PassageModeActivated.Size = new System.Drawing.Size(93, 24);
            this.PassageModeActivated.TabIndex = 16;
            this.PassageModeActivated.Text = "Activated";
            this.PassageModeActivated.UseVisualStyleBackColor = true;
            // 
            // PassageModeDeactivated
            // 
            this.PassageModeDeactivated.AutoSize = true;
            this.PassageModeDeactivated.Checked = true;
            this.PassageModeDeactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageModeDeactivated.Location = new System.Drawing.Point(218, 25);
            this.PassageModeDeactivated.Name = "PassageModeDeactivated";
            this.PassageModeDeactivated.Size = new System.Drawing.Size(112, 24);
            this.PassageModeDeactivated.TabIndex = 17;
            this.PassageModeDeactivated.TabStop = true;
            this.PassageModeDeactivated.Text = "Deactivated";
            this.PassageModeDeactivated.UseVisualStyleBackColor = true;
            // 
            // PassageModeOpenTime
            // 
            this.PassageModeOpenTime.AutoSize = true;
            this.PassageModeOpenTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageModeOpenTime.Location = new System.Drawing.Point(21, 52);
            this.PassageModeOpenTime.Name = "PassageModeOpenTime";
            this.PassageModeOpenTime.Size = new System.Drawing.Size(192, 20);
            this.PassageModeOpenTime.TabIndex = 18;
            this.PassageModeOpenTime.Text = "OpenTime (0 to 24 Hours)";
            // 
            // PassageOpenTime
            // 
            this.PassageOpenTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageOpenTime.Location = new System.Drawing.Point(219, 52);
            this.PassageOpenTime.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.PassageOpenTime.Name = "PassageOpenTime";
            this.PassageOpenTime.Size = new System.Drawing.Size(38, 26);
            this.PassageOpenTime.TabIndex = 19;
            this.PassageOpenTime.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // LockoutModeDeactivated
            // 
            this.LockoutModeDeactivated.AutoSize = true;
            this.LockoutModeDeactivated.Checked = true;
            this.LockoutModeDeactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockoutModeDeactivated.Location = new System.Drawing.Point(128, 27);
            this.LockoutModeDeactivated.Name = "LockoutModeDeactivated";
            this.LockoutModeDeactivated.Size = new System.Drawing.Size(112, 24);
            this.LockoutModeDeactivated.TabIndex = 22;
            this.LockoutModeDeactivated.TabStop = true;
            this.LockoutModeDeactivated.Text = "Deactivated";
            this.LockoutModeDeactivated.UseVisualStyleBackColor = true;
            // 
            // LockoutModeActivated
            // 
            this.LockoutModeActivated.AutoSize = true;
            this.LockoutModeActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockoutModeActivated.Location = new System.Drawing.Point(26, 27);
            this.LockoutModeActivated.Name = "LockoutModeActivated";
            this.LockoutModeActivated.Size = new System.Drawing.Size(93, 24);
            this.LockoutModeActivated.TabIndex = 21;
            this.LockoutModeActivated.Text = "Activated";
            this.LockoutModeActivated.UseVisualStyleBackColor = true;
            // 
            // PassageGroupBox
            // 
            this.PassageGroupBox.Controls.Add(this.PassageModeActivated);
            this.PassageGroupBox.Controls.Add(this.PassageModeDeactivated);
            this.PassageGroupBox.Controls.Add(this.PassageModeLit);
            this.PassageGroupBox.Controls.Add(this.PassageModeOpenTime);
            this.PassageGroupBox.Controls.Add(this.PassageOpenTime);
            this.PassageGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassageGroupBox.Location = new System.Drawing.Point(16, 288);
            this.PassageGroupBox.Name = "PassageGroupBox";
            this.PassageGroupBox.Size = new System.Drawing.Size(347, 84);
            this.PassageGroupBox.TabIndex = 23;
            this.PassageGroupBox.TabStop = false;
            this.PassageGroupBox.Text = "Passage";
            // 
            // LockoutModeGrpBox
            // 
            this.LockoutModeGrpBox.Controls.Add(this.LockoutModeActivated);
            this.LockoutModeGrpBox.Controls.Add(this.LockoutModeDeactivated);
            this.LockoutModeGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockoutModeGrpBox.Location = new System.Drawing.Point(16, 378);
            this.LockoutModeGrpBox.Name = "LockoutModeGrpBox";
            this.LockoutModeGrpBox.Size = new System.Drawing.Size(347, 68);
            this.LockoutModeGrpBox.TabIndex = 24;
            this.LockoutModeGrpBox.TabStop = false;
            this.LockoutModeGrpBox.Text = "Lockout Mode";
            // 
            // AccessCodeLengthLit
            // 
            this.AccessCodeLengthLit.AutoSize = true;
            this.AccessCodeLengthLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessCodeLengthLit.Location = new System.Drawing.Point(12, 464);
            this.AccessCodeLengthLit.Name = "AccessCodeLengthLit";
            this.AccessCodeLengthLit.Size = new System.Drawing.Size(244, 20);
            this.AccessCodeLengthLit.TabIndex = 25;
            this.AccessCodeLengthLit.Text = "AccessCodeLength (4 to 8 digits)";
            // 
            // AccessCodeLength
            // 
            this.AccessCodeLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessCodeLength.Location = new System.Drawing.Point(262, 462);
            this.AccessCodeLength.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.AccessCodeLength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.AccessCodeLength.Name = "AccessCodeLength";
            this.AccessCodeLength.Size = new System.Drawing.Size(38, 26);
            this.AccessCodeLength.TabIndex = 20;
            this.AccessCodeLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // RemoteUnlockGrp
            // 
            this.RemoteUnlockGrp.Controls.Add(this.RemoteUnlockActivated);
            this.RemoteUnlockGrp.Controls.Add(this.RemoteUnlockDeactivated);
            this.RemoteUnlockGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoteUnlockGrp.Location = new System.Drawing.Point(16, 494);
            this.RemoteUnlockGrp.Name = "RemoteUnlockGrp";
            this.RemoteUnlockGrp.Size = new System.Drawing.Size(347, 68);
            this.RemoteUnlockGrp.TabIndex = 25;
            this.RemoteUnlockGrp.TabStop = false;
            this.RemoteUnlockGrp.Text = "Remote Unlock";
            // 
            // RemoteUnlockActivated
            // 
            this.RemoteUnlockActivated.AutoSize = true;
            this.RemoteUnlockActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoteUnlockActivated.Location = new System.Drawing.Point(26, 25);
            this.RemoteUnlockActivated.Name = "RemoteUnlockActivated";
            this.RemoteUnlockActivated.Size = new System.Drawing.Size(93, 24);
            this.RemoteUnlockActivated.TabIndex = 21;
            this.RemoteUnlockActivated.Text = "Activated";
            this.RemoteUnlockActivated.UseVisualStyleBackColor = true;
            // 
            // RemoteUnlockDeactivated
            // 
            this.RemoteUnlockDeactivated.AutoSize = true;
            this.RemoteUnlockDeactivated.Checked = true;
            this.RemoteUnlockDeactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoteUnlockDeactivated.Location = new System.Drawing.Point(128, 25);
            this.RemoteUnlockDeactivated.Name = "RemoteUnlockDeactivated";
            this.RemoteUnlockDeactivated.Size = new System.Drawing.Size(112, 24);
            this.RemoteUnlockDeactivated.TabIndex = 22;
            this.RemoteUnlockDeactivated.TabStop = true;
            this.RemoteUnlockDeactivated.Text = "Deactivated";
            this.RemoteUnlockDeactivated.UseVisualStyleBackColor = true;
            // 
            // LatchHoldbackGrp
            // 
            this.LatchHoldbackGrp.Controls.Add(this.LatchHoldbackActivated);
            this.LatchHoldbackGrp.Controls.Add(this.LatchHoldbackDeactivated);
            this.LatchHoldbackGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatchHoldbackGrp.Location = new System.Drawing.Point(16, 568);
            this.LatchHoldbackGrp.Name = "LatchHoldbackGrp";
            this.LatchHoldbackGrp.Size = new System.Drawing.Size(347, 68);
            this.LatchHoldbackGrp.TabIndex = 26;
            this.LatchHoldbackGrp.TabStop = false;
            this.LatchHoldbackGrp.Text = "Latch Holdback";
            // 
            // LatchHoldbackActivated
            // 
            this.LatchHoldbackActivated.AutoSize = true;
            this.LatchHoldbackActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatchHoldbackActivated.Location = new System.Drawing.Point(26, 25);
            this.LatchHoldbackActivated.Name = "LatchHoldbackActivated";
            this.LatchHoldbackActivated.Size = new System.Drawing.Size(93, 24);
            this.LatchHoldbackActivated.TabIndex = 21;
            this.LatchHoldbackActivated.Text = "Activated";
            this.LatchHoldbackActivated.UseVisualStyleBackColor = true;
            // 
            // LatchHoldbackDeactivated
            // 
            this.LatchHoldbackDeactivated.AutoSize = true;
            this.LatchHoldbackDeactivated.Checked = true;
            this.LatchHoldbackDeactivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatchHoldbackDeactivated.Location = new System.Drawing.Point(128, 25);
            this.LatchHoldbackDeactivated.Name = "LatchHoldbackDeactivated";
            this.LatchHoldbackDeactivated.Size = new System.Drawing.Size(112, 24);
            this.LatchHoldbackDeactivated.TabIndex = 22;
            this.LatchHoldbackDeactivated.TabStop = true;
            this.LatchHoldbackDeactivated.Text = "Deactivated";
            this.LatchHoldbackDeactivated.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(16, 642);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 25);
            this.OKButton.TabIndex = 27;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // myCancelBtn
            // 
            this.myCancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myCancelBtn.Location = new System.Drawing.Point(108, 642);
            this.myCancelBtn.Name = "myCancelBtn";
            this.myCancelBtn.Size = new System.Drawing.Size(75, 25);
            this.myCancelBtn.TabIndex = 28;
            this.myCancelBtn.Text = "Cancel";
            this.myCancelBtn.UseVisualStyleBackColor = true;
            this.myCancelBtn.Click += new System.EventHandler(this.myCancelBtn_Click);
            // 
            // TitleBox
            // 
            this.TitleBox.BackColor = System.Drawing.SystemColors.Info;
            this.TitleBox.Enabled = false;
            this.TitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBox.Location = new System.Drawing.Point(16, 9);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(347, 31);
            this.TitleBox.TabIndex = 29;
            this.TitleBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoorStatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(989, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DoorStatusMsg
            // 
            this.DoorStatusMsg.Name = "DoorStatusMsg";
            this.DoorStatusMsg.Size = new System.Drawing.Size(88, 17);
            this.DoorStatusMsg.Text = "DoorStatusMsg";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 684);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(989, 22);
            this.statusStrip2.TabIndex = 31;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // DoorAuditAllToggle
            // 
            this.DoorAuditAllToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorAuditAllToggle.Location = new System.Drawing.Point(629, 513);
            this.DoorAuditAllToggle.Name = "DoorAuditAllToggle";
            this.DoorAuditAllToggle.Size = new System.Drawing.Size(135, 31);
            this.DoorAuditAllToggle.TabIndex = 48;
            this.DoorAuditAllToggle.Text = "Toggle All";
            this.DoorAuditAllToggle.UseVisualStyleBackColor = true;
            this.DoorAuditAllToggle.Click += new System.EventHandler(this.DoorAuditAllToggle_Click);
            // 
            // AuditLit
            // 
            this.AuditLit.AutoSize = true;
            this.AuditLit.BackColor = System.Drawing.SystemColors.Info;
            this.AuditLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuditLit.Location = new System.Drawing.Point(646, 9);
            this.AuditLit.Name = "AuditLit";
            this.AuditLit.Size = new System.Drawing.Size(104, 24);
            this.AuditLit.TabIndex = 47;
            this.AuditLit.Text = "Audit Flags";
            // 
            // AuditBackgroundBox
            // 
            this.AuditBackgroundBox.BackColor = System.Drawing.SystemColors.Info;
            this.AuditBackgroundBox.Enabled = false;
            this.AuditBackgroundBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuditBackgroundBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AuditBackgroundBox.Location = new System.Drawing.Point(499, 7);
            this.AuditBackgroundBox.Name = "AuditBackgroundBox";
            this.AuditBackgroundBox.Size = new System.Drawing.Size(427, 29);
            this.AuditBackgroundBox.TabIndex = 46;
            this.AuditBackgroundBox.TabStop = false;
            this.AuditBackgroundBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AuditFlagListView
            // 
            this.AuditFlagListView.CheckBoxes = true;
            this.AuditFlagListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuditFlagListView.FullRowSelect = true;
            this.AuditFlagListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.AuditFlagListView.HideSelection = false;
            this.AuditFlagListView.Location = new System.Drawing.Point(499, 33);
            this.AuditFlagListView.Name = "AuditFlagListView";
            this.AuditFlagListView.Size = new System.Drawing.Size(427, 455);
            this.AuditFlagListView.TabIndex = 45;
            this.AuditFlagListView.UseCompatibleStateImageBehavior = false;
            // 
            // DoorLockForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.myCancelBtn;
            this.ClientSize = new System.Drawing.Size(989, 728);
            this.Controls.Add(this.DoorAuditAllToggle);
            this.Controls.Add(this.AuditLit);
            this.Controls.Add(this.AuditBackgroundBox);
            this.Controls.Add(this.AuditFlagListView);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myCancelBtn);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.LatchHoldbackGrp);
            this.Controls.Add(this.RemoteUnlockGrp);
            this.Controls.Add(this.AccessCodeLength);
            this.Controls.Add(this.AccessCodeLengthLit);
            this.Controls.Add(this.LockoutModeGrpBox);
            this.Controls.Add(this.PassageGroupBox);
            this.Controls.Add(this.TamperShutdownTime);
            this.Controls.Add(this.TamperShutdownTimeLit);
            this.Controls.Add(this.TamperCount);
            this.Controls.Add(this.TamperCountLit);
            this.Controls.Add(this.BuzzerVolume);
            this.Controls.Add(this.BuzzerVolumeLit);
            this.Controls.Add(this.UnlockTimeLit);
            this.Controls.Add(this.UnlockTime);
            this.Controls.Add(this.LockFunction);
            this.Controls.Add(this.LockFunctionLit);
            this.Controls.Add(this.LockID);
            this.Controls.Add(this.LockIDLit);
            this.Controls.Add(this.DoorName);
            this.Controls.Add(this.DoorNameLit);
            this.Controls.Add(this.SiteName);
            this.Controls.Add(this.TitleBox);
            this.Name = "DoorLockForm";
            this.Text = "Lock Information for a Door";
            this.Load += new System.EventHandler(this.DoorLockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnlockTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuzzerVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TamperCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TamperShutdownTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassageOpenTime)).EndInit();
            this.PassageGroupBox.ResumeLayout(false);
            this.PassageGroupBox.PerformLayout();
            this.LockoutModeGrpBox.ResumeLayout(false);
            this.LockoutModeGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccessCodeLength)).EndInit();
            this.RemoteUnlockGrp.ResumeLayout(false);
            this.RemoteUnlockGrp.PerformLayout();
            this.LatchHoldbackGrp.ResumeLayout(false);
            this.LatchHoldbackGrp.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SiteName;
        private System.Windows.Forms.Label DoorNameLit;
        private System.Windows.Forms.TextBox DoorName;
        private System.Windows.Forms.TextBox LockID;
        private System.Windows.Forms.Label LockIDLit;
        private System.Windows.Forms.Label LockFunctionLit;
        private System.Windows.Forms.ComboBox LockFunction;
        private System.Windows.Forms.NumericUpDown UnlockTime;
        private System.Windows.Forms.Label UnlockTimeLit;
        private System.Windows.Forms.Label BuzzerVolumeLit;
        private System.Windows.Forms.NumericUpDown BuzzerVolume;
        private System.Windows.Forms.Label TamperCountLit;
        private System.Windows.Forms.NumericUpDown TamperCount;
        private System.Windows.Forms.Label TamperShutdownTimeLit;
        private System.Windows.Forms.NumericUpDown TamperShutdownTime;
        private System.Windows.Forms.Label PassageModeLit;
        private System.Windows.Forms.RadioButton PassageModeActivated;
        private System.Windows.Forms.RadioButton PassageModeDeactivated;
        private System.Windows.Forms.Label PassageModeOpenTime;
        private System.Windows.Forms.NumericUpDown PassageOpenTime;
        private System.Windows.Forms.RadioButton LockoutModeDeactivated;
        private System.Windows.Forms.RadioButton LockoutModeActivated;
        private System.Windows.Forms.GroupBox PassageGroupBox;
        private System.Windows.Forms.GroupBox LockoutModeGrpBox;
        private System.Windows.Forms.Label AccessCodeLengthLit;
        private System.Windows.Forms.NumericUpDown AccessCodeLength;
        private System.Windows.Forms.GroupBox RemoteUnlockGrp;
        private System.Windows.Forms.RadioButton RemoteUnlockActivated;
        private System.Windows.Forms.RadioButton RemoteUnlockDeactivated;
        private System.Windows.Forms.GroupBox LatchHoldbackGrp;
        private System.Windows.Forms.RadioButton LatchHoldbackActivated;
        private System.Windows.Forms.RadioButton LatchHoldbackDeactivated;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button myCancelBtn;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DoorStatusMsg;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Button DoorAuditAllToggle;
        private System.Windows.Forms.Label AuditLit;
        private System.Windows.Forms.TextBox AuditBackgroundBox;
        private System.Windows.Forms.ListView AuditFlagListView;
    }
}