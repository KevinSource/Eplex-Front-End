namespace Eplex_Front_End
{
    partial class RegistrySettingsForm
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
            this.ApplicationPathLit = new System.Windows.Forms.Label();
            this.DataPathLit = new System.Windows.Forms.Label();
            this.MUnitLit = new System.Windows.Forms.Label();
            this.AppPath = new System.Windows.Forms.TextBox();
            this.DataPath = new System.Windows.Forms.TextBox();
            this.MUnitPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.myOKButon = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.AppPathCopy = new System.Windows.Forms.Button();
            this.DataPathCopy = new System.Windows.Forms.Button();
            this.MUnitPathCopy = new System.Windows.Forms.Button();
            this.AppPathUpdate = new System.Windows.Forms.Button();
            this.DataPathUpdate = new System.Windows.Forms.Button();
            this.MUnitPathUpdate = new System.Windows.Forms.Button();
            this.AppPathExplorer = new System.Windows.Forms.Button();
            this.DataPathExplorer = new System.Windows.Forms.Button();
            this.MUnitPathExplorer = new System.Windows.Forms.Button();
            this.DataSecurityGrpBoxLit = new System.Windows.Forms.GroupBox();
            this.EncryptDataCheckbox = new System.Windows.Forms.CheckBox();
            this.ReportCopyGroupBox = new System.Windows.Forms.GroupBox();
            this.LatestReportFileOpen = new System.Windows.Forms.Button();
            this.LatestReportFileExplore = new System.Windows.Forms.Button();
            this.LatestReportCopy = new System.Windows.Forms.Button();
            this.LatestReportFile = new System.Windows.Forms.TextBox();
            this.LatestReportFileLit = new System.Windows.Forms.Label();
            this.LatestReportPath = new System.Windows.Forms.TextBox();
            this.LatestReportPathLit = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ThisAppDataPathLit = new System.Windows.Forms.Label();
            this.DataPath2020 = new System.Windows.Forms.TextBox();
            this.DataPath2020Copy = new System.Windows.Forms.Button();
            this.DataPath2020Explorer = new System.Windows.Forms.Button();
            this.DataPath2020Update = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.DataSecurityGrpBoxLit.SuspendLayout();
            this.ReportCopyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationPathLit
            // 
            this.ApplicationPathLit.AutoSize = true;
            this.ApplicationPathLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationPathLit.Location = new System.Drawing.Point(30, 27);
            this.ApplicationPathLit.Name = "ApplicationPathLit";
            this.ApplicationPathLit.Size = new System.Drawing.Size(150, 24);
            this.ApplicationPathLit.TabIndex = 0;
            this.ApplicationPathLit.Text = "Application Path:";
            // 
            // DataPathLit
            // 
            this.DataPathLit.AutoSize = true;
            this.DataPathLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataPathLit.Location = new System.Drawing.Point(5, 64);
            this.DataPathLit.Name = "DataPathLit";
            this.DataPathLit.Size = new System.Drawing.Size(180, 24);
            this.DataPathLit.TabIndex = 1;
            this.DataPathLit.Text = "Eplex Std Data Path:";
            // 
            // MUnitLit
            // 
            this.MUnitLit.AutoSize = true;
            this.MUnitLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MUnitLit.Location = new System.Drawing.Point(50, 139);
            this.MUnitLit.Name = "MUnitLit";
            this.MUnitLit.Size = new System.Drawing.Size(105, 24);
            this.MUnitLit.TabIndex = 2;
            this.MUnitLit.Text = "MUnit Path:";
            // 
            // AppPath
            // 
            this.AppPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppPath.Location = new System.Drawing.Point(188, 27);
            this.AppPath.Name = "AppPath";
            this.AppPath.Size = new System.Drawing.Size(623, 22);
            this.AppPath.TabIndex = 3;
            this.AppPath.Text = "AppPath";
            // 
            // DataPath
            // 
            this.DataPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataPath.Location = new System.Drawing.Point(188, 64);
            this.DataPath.Name = "DataPath";
            this.DataPath.Size = new System.Drawing.Size(623, 22);
            this.DataPath.TabIndex = 4;
            this.DataPath.Text = "DataPath";
            // 
            // MUnitPath
            // 
            this.MUnitPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MUnitPath.Location = new System.Drawing.Point(188, 139);
            this.MUnitPath.Name = "MUnitPath";
            this.MUnitPath.Size = new System.Drawing.Size(623, 22);
            this.MUnitPath.TabIndex = 5;
            this.MUnitPath.Text = "MUnitPath";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1168, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusMsg
            // 
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.Size = new System.Drawing.Size(62, 17);
            this.StatusMsg.Text = "StatusMsg";
            // 
            // myOKButon
            // 
            this.myOKButon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.myOKButon.Location = new System.Drawing.Point(188, 419);
            this.myOKButon.Name = "myOKButon";
            this.myOKButon.Size = new System.Drawing.Size(105, 34);
            this.myOKButon.TabIndex = 7;
            this.myOKButon.Text = "OK";
            this.myOKButon.UseVisualStyleBackColor = true;
            this.myOKButon.Click += new System.EventHandler(this.myOKButon_Click);
            // 
            // myCancelButton
            // 
            this.myCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myCancelButton.Location = new System.Drawing.Point(299, 419);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(105, 34);
            this.myCancelButton.TabIndex = 8;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            // 
            // AppPathCopy
            // 
            this.AppPathCopy.Location = new System.Drawing.Point(817, 20);
            this.AppPathCopy.Name = "AppPathCopy";
            this.AppPathCopy.Size = new System.Drawing.Size(105, 29);
            this.AppPathCopy.TabIndex = 9;
            this.AppPathCopy.Text = "Copy to Clipboard";
            this.AppPathCopy.UseVisualStyleBackColor = true;
            this.AppPathCopy.Click += new System.EventHandler(this.AppPathCopy_Click);
            // 
            // DataPathCopy
            // 
            this.DataPathCopy.Location = new System.Drawing.Point(817, 59);
            this.DataPathCopy.Name = "DataPathCopy";
            this.DataPathCopy.Size = new System.Drawing.Size(105, 29);
            this.DataPathCopy.TabIndex = 10;
            this.DataPathCopy.Text = "Copy to Clipboard";
            this.DataPathCopy.UseVisualStyleBackColor = true;
            this.DataPathCopy.Click += new System.EventHandler(this.DataPathCopy_Click);
            // 
            // MUnitPathCopy
            // 
            this.MUnitPathCopy.Location = new System.Drawing.Point(817, 137);
            this.MUnitPathCopy.Name = "MUnitPathCopy";
            this.MUnitPathCopy.Size = new System.Drawing.Size(105, 29);
            this.MUnitPathCopy.TabIndex = 11;
            this.MUnitPathCopy.Text = "Copy to Clipboard";
            this.MUnitPathCopy.UseVisualStyleBackColor = true;
            this.MUnitPathCopy.Click += new System.EventHandler(this.MUnitPathCopy_Click);
            // 
            // AppPathUpdate
            // 
            this.AppPathUpdate.Location = new System.Drawing.Point(1012, 20);
            this.AppPathUpdate.Name = "AppPathUpdate";
            this.AppPathUpdate.Size = new System.Drawing.Size(105, 29);
            this.AppPathUpdate.TabIndex = 12;
            this.AppPathUpdate.Text = "Update in Registry";
            this.AppPathUpdate.UseVisualStyleBackColor = true;
            this.AppPathUpdate.Click += new System.EventHandler(this.AppPathUpdate_Click);
            // 
            // DataPathUpdate
            // 
            this.DataPathUpdate.Location = new System.Drawing.Point(1012, 59);
            this.DataPathUpdate.Name = "DataPathUpdate";
            this.DataPathUpdate.Size = new System.Drawing.Size(105, 29);
            this.DataPathUpdate.TabIndex = 13;
            this.DataPathUpdate.Text = "Update in Registry";
            this.DataPathUpdate.UseVisualStyleBackColor = true;
            this.DataPathUpdate.Click += new System.EventHandler(this.DataPathUpdate_Click);
            // 
            // MUnitPathUpdate
            // 
            this.MUnitPathUpdate.Location = new System.Drawing.Point(1012, 137);
            this.MUnitPathUpdate.Name = "MUnitPathUpdate";
            this.MUnitPathUpdate.Size = new System.Drawing.Size(105, 29);
            this.MUnitPathUpdate.TabIndex = 14;
            this.MUnitPathUpdate.Text = "Update in Registry";
            this.MUnitPathUpdate.UseVisualStyleBackColor = true;
            this.MUnitPathUpdate.Click += new System.EventHandler(this.MUnitPathUpdate_Click);
            // 
            // AppPathExplorer
            // 
            this.AppPathExplorer.Location = new System.Drawing.Point(928, 20);
            this.AppPathExplorer.Name = "AppPathExplorer";
            this.AppPathExplorer.Size = new System.Drawing.Size(78, 29);
            this.AppPathExplorer.TabIndex = 15;
            this.AppPathExplorer.Text = "File Explorer";
            this.AppPathExplorer.UseVisualStyleBackColor = true;
            this.AppPathExplorer.Click += new System.EventHandler(this.AppPathExplorer_Click);
            // 
            // DataPathExplorer
            // 
            this.DataPathExplorer.Location = new System.Drawing.Point(928, 59);
            this.DataPathExplorer.Name = "DataPathExplorer";
            this.DataPathExplorer.Size = new System.Drawing.Size(78, 29);
            this.DataPathExplorer.TabIndex = 16;
            this.DataPathExplorer.Text = "File Explorer";
            this.DataPathExplorer.UseVisualStyleBackColor = true;
            this.DataPathExplorer.Click += new System.EventHandler(this.DataPathExplorer_Click);
            // 
            // MUnitPathExplorer
            // 
            this.MUnitPathExplorer.Location = new System.Drawing.Point(928, 136);
            this.MUnitPathExplorer.Name = "MUnitPathExplorer";
            this.MUnitPathExplorer.Size = new System.Drawing.Size(78, 29);
            this.MUnitPathExplorer.TabIndex = 17;
            this.MUnitPathExplorer.Text = "File Explorer";
            this.MUnitPathExplorer.UseVisualStyleBackColor = true;
            this.MUnitPathExplorer.Click += new System.EventHandler(this.MUnitPathExplorer_Click);
            // 
            // DataSecurityGrpBoxLit
            // 
            this.DataSecurityGrpBoxLit.Controls.Add(this.EncryptDataCheckbox);
            this.DataSecurityGrpBoxLit.Location = new System.Drawing.Point(188, 175);
            this.DataSecurityGrpBoxLit.Name = "DataSecurityGrpBoxLit";
            this.DataSecurityGrpBoxLit.Size = new System.Drawing.Size(371, 69);
            this.DataSecurityGrpBoxLit.TabIndex = 18;
            this.DataSecurityGrpBoxLit.TabStop = false;
            this.DataSecurityGrpBoxLit.Text = "Data Security";
            // 
            // EncryptDataCheckbox
            // 
            this.EncryptDataCheckbox.AutoSize = true;
            this.EncryptDataCheckbox.Location = new System.Drawing.Point(19, 33);
            this.EncryptDataCheckbox.Name = "EncryptDataCheckbox";
            this.EncryptDataCheckbox.Size = new System.Drawing.Size(169, 17);
            this.EncryptDataCheckbox.TabIndex = 0;
            this.EncryptDataCheckbox.Text = "Encrypt Data (Recommended)";
            this.EncryptDataCheckbox.UseVisualStyleBackColor = true;
            this.EncryptDataCheckbox.CheckedChanged += new System.EventHandler(this.EncryptDataCheckbox_CheckedChanged);
            // 
            // ReportCopyGroupBox
            // 
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportFileOpen);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportFileExplore);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportCopy);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportFile);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportFileLit);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportPath);
            this.ReportCopyGroupBox.Controls.Add(this.LatestReportPathLit);
            this.ReportCopyGroupBox.Location = new System.Drawing.Point(188, 250);
            this.ReportCopyGroupBox.Name = "ReportCopyGroupBox";
            this.ReportCopyGroupBox.Size = new System.Drawing.Size(869, 148);
            this.ReportCopyGroupBox.TabIndex = 19;
            this.ReportCopyGroupBox.TabStop = false;
            this.ReportCopyGroupBox.Text = "Most Recently Run Report";
            // 
            // LatestReportFileOpen
            // 
            this.LatestReportFileOpen.Location = new System.Drawing.Point(194, 104);
            this.LatestReportFileOpen.Name = "LatestReportFileOpen";
            this.LatestReportFileOpen.Size = new System.Drawing.Size(78, 29);
            this.LatestReportFileOpen.TabIndex = 23;
            this.LatestReportFileOpen.Text = "Open";
            this.LatestReportFileOpen.UseVisualStyleBackColor = true;
            this.LatestReportFileOpen.Click += new System.EventHandler(this.LatestReportFileOpen_Click);
            // 
            // LatestReportFileExplore
            // 
            this.LatestReportFileExplore.Location = new System.Drawing.Point(535, 104);
            this.LatestReportFileExplore.Name = "LatestReportFileExplore";
            this.LatestReportFileExplore.Size = new System.Drawing.Size(78, 29);
            this.LatestReportFileExplore.TabIndex = 20;
            this.LatestReportFileExplore.Text = "File Explorer";
            this.LatestReportFileExplore.UseVisualStyleBackColor = true;
            this.LatestReportFileExplore.Click += new System.EventHandler(this.LatestReportFileExplore_Click);
            // 
            // LatestReportCopy
            // 
            this.LatestReportCopy.Location = new System.Drawing.Point(288, 104);
            this.LatestReportCopy.Name = "LatestReportCopy";
            this.LatestReportCopy.Size = new System.Drawing.Size(228, 29);
            this.LatestReportCopy.TabIndex = 20;
            this.LatestReportCopy.Text = "Copy Path and File Name to Clipboard";
            this.LatestReportCopy.UseVisualStyleBackColor = true;
            this.LatestReportCopy.Click += new System.EventHandler(this.button1_Click);
            // 
            // LatestReportFile
            // 
            this.LatestReportFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestReportFile.Location = new System.Drawing.Point(194, 67);
            this.LatestReportFile.Name = "LatestReportFile";
            this.LatestReportFile.Size = new System.Drawing.Size(623, 22);
            this.LatestReportFile.TabIndex = 22;
            this.LatestReportFile.Text = "LastestReportFile";
            // 
            // LatestReportFileLit
            // 
            this.LatestReportFileLit.AutoSize = true;
            this.LatestReportFileLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestReportFileLit.Location = new System.Drawing.Point(27, 64);
            this.LatestReportFileLit.Name = "LatestReportFileLit";
            this.LatestReportFileLit.Size = new System.Drawing.Size(155, 24);
            this.LatestReportFileLit.TabIndex = 21;
            this.LatestReportFileLit.Text = "Latest Report File";
            // 
            // LatestReportPath
            // 
            this.LatestReportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestReportPath.Location = new System.Drawing.Point(194, 28);
            this.LatestReportPath.Name = "LatestReportPath";
            this.LatestReportPath.Size = new System.Drawing.Size(623, 22);
            this.LatestReportPath.TabIndex = 20;
            this.LatestReportPath.Text = "LatestReportPath";
            // 
            // LatestReportPathLit
            // 
            this.LatestReportPathLit.AutoSize = true;
            this.LatestReportPathLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestReportPathLit.Location = new System.Drawing.Point(27, 25);
            this.LatestReportPathLit.Name = "LatestReportPathLit";
            this.LatestReportPathLit.Size = new System.Drawing.Size(161, 24);
            this.LatestReportPathLit.TabIndex = 20;
            this.LatestReportPathLit.Text = "Latest Report Path";
            // 
            // ThisAppDataPathLit
            // 
            this.ThisAppDataPathLit.AutoSize = true;
            this.ThisAppDataPathLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThisAppDataPathLit.Location = new System.Drawing.Point(7, 100);
            this.ThisAppDataPathLit.Name = "ThisAppDataPathLit";
            this.ThisAppDataPathLit.Size = new System.Drawing.Size(175, 24);
            this.ThisAppDataPathLit.TabIndex = 20;
            this.ThisAppDataPathLit.Text = "This App Data Path:";
            // 
            // DataPath2020
            // 
            this.DataPath2020.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataPath2020.Location = new System.Drawing.Point(188, 100);
            this.DataPath2020.Name = "DataPath2020";
            this.DataPath2020.Size = new System.Drawing.Size(623, 22);
            this.DataPath2020.TabIndex = 21;
            this.DataPath2020.Text = "DataPath2020";
            // 
            // DataPath2020Copy
            // 
            this.DataPath2020Copy.Location = new System.Drawing.Point(817, 97);
            this.DataPath2020Copy.Name = "DataPath2020Copy";
            this.DataPath2020Copy.Size = new System.Drawing.Size(105, 29);
            this.DataPath2020Copy.TabIndex = 22;
            this.DataPath2020Copy.Text = "Copy to Clipboard";
            this.DataPath2020Copy.UseVisualStyleBackColor = true;
            this.DataPath2020Copy.Click += new System.EventHandler(this.DataPath2020Copy_Click);
            // 
            // DataPath2020Explorer
            // 
            this.DataPath2020Explorer.Location = new System.Drawing.Point(928, 93);
            this.DataPath2020Explorer.Name = "DataPath2020Explorer";
            this.DataPath2020Explorer.Size = new System.Drawing.Size(78, 29);
            this.DataPath2020Explorer.TabIndex = 23;
            this.DataPath2020Explorer.Text = "File Explorer";
            this.DataPath2020Explorer.UseVisualStyleBackColor = true;
            this.DataPath2020Explorer.Click += new System.EventHandler(this.DataPath2020Explorer_Click);
            // 
            // DataPath2020Update
            // 
            this.DataPath2020Update.Location = new System.Drawing.Point(1012, 95);
            this.DataPath2020Update.Name = "DataPath2020Update";
            this.DataPath2020Update.Size = new System.Drawing.Size(105, 29);
            this.DataPath2020Update.TabIndex = 24;
            this.DataPath2020Update.Text = "Update in Registry";
            this.DataPath2020Update.UseVisualStyleBackColor = true;
            this.DataPath2020Update.Click += new System.EventHandler(this.DataPath2020Update_Click);
            // 
            // RegistrySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 497);
            this.Controls.Add(this.DataPath2020Update);
            this.Controls.Add(this.DataPath2020Explorer);
            this.Controls.Add(this.DataPath2020Copy);
            this.Controls.Add(this.DataPath2020);
            this.Controls.Add(this.ThisAppDataPathLit);
            this.Controls.Add(this.ReportCopyGroupBox);
            this.Controls.Add(this.MUnitPathExplorer);
            this.Controls.Add(this.DataPathExplorer);
            this.Controls.Add(this.AppPathExplorer);
            this.Controls.Add(this.MUnitPathUpdate);
            this.Controls.Add(this.DataPathUpdate);
            this.Controls.Add(this.AppPathUpdate);
            this.Controls.Add(this.MUnitPathCopy);
            this.Controls.Add(this.DataPathCopy);
            this.Controls.Add(this.AppPathCopy);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.myOKButon);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MUnitPath);
            this.Controls.Add(this.DataPath);
            this.Controls.Add(this.AppPath);
            this.Controls.Add(this.MUnitLit);
            this.Controls.Add(this.DataPathLit);
            this.Controls.Add(this.ApplicationPathLit);
            this.Controls.Add(this.DataSecurityGrpBoxLit);
            this.Name = "RegistrySettingsForm";
            this.Text = "Registry Settings";
            this.Load += new System.EventHandler(this.RegistrySettingsForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.DataSecurityGrpBoxLit.ResumeLayout(false);
            this.DataSecurityGrpBoxLit.PerformLayout();
            this.ReportCopyGroupBox.ResumeLayout(false);
            this.ReportCopyGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ApplicationPathLit;
        private System.Windows.Forms.Label DataPathLit;
        private System.Windows.Forms.Label MUnitLit;
        private System.Windows.Forms.TextBox AppPath;
        private System.Windows.Forms.TextBox DataPath;
        private System.Windows.Forms.TextBox MUnitPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusMsg;
        private System.Windows.Forms.Button myOKButon;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.Button AppPathCopy;
        private System.Windows.Forms.Button DataPathCopy;
        private System.Windows.Forms.Button MUnitPathCopy;
        private System.Windows.Forms.Button AppPathUpdate;
        private System.Windows.Forms.Button DataPathUpdate;
        private System.Windows.Forms.Button MUnitPathUpdate;
        private System.Windows.Forms.Button AppPathExplorer;
        private System.Windows.Forms.Button DataPathExplorer;
        private System.Windows.Forms.Button MUnitPathExplorer;
        private System.Windows.Forms.GroupBox DataSecurityGrpBoxLit;
        private System.Windows.Forms.CheckBox EncryptDataCheckbox;
        private System.Windows.Forms.GroupBox ReportCopyGroupBox;
        private System.Windows.Forms.Button LatestReportFileOpen;
        private System.Windows.Forms.Button LatestReportFileExplore;
        private System.Windows.Forms.Button LatestReportCopy;
        private System.Windows.Forms.TextBox LatestReportFile;
        private System.Windows.Forms.Label LatestReportFileLit;
        private System.Windows.Forms.TextBox LatestReportPath;
        private System.Windows.Forms.Label LatestReportPathLit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ThisAppDataPathLit;
        private System.Windows.Forms.TextBox DataPath2020;
        private System.Windows.Forms.Button DataPath2020Copy;
        private System.Windows.Forms.Button DataPath2020Explorer;
        private System.Windows.Forms.Button DataPath2020Update;
    }
}