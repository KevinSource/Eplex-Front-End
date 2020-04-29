namespace Eplex_Front_End
{
    partial class DoorCopyForm
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
            this.FromDoorNameLit = new System.Windows.Forms.Label();
            this.FromDoorName = new System.Windows.Forms.Label();
            this.FromDoorGrpBox = new System.Windows.Forms.GroupBox();
            this.FromDoorID = new System.Windows.Forms.Label();
            this.FromDoorIDLit = new System.Windows.Forms.Label();
            this.CopyToGrpBox = new System.Windows.Forms.GroupBox();
            this.ToDoorID = new System.Windows.Forms.TextBox();
            this.ToDoorName = new System.Windows.Forms.TextBox();
            this.ToDoorIDLit = new System.Windows.Forms.Label();
            this.ToDoorNameLit = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.CopyDoorStatusMsgHold = new System.Windows.Forms.StatusStrip();
            this.CopyDoorStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.FromDoorGrpBox.SuspendLayout();
            this.CopyToGrpBox.SuspendLayout();
            this.CopyDoorStatusMsgHold.SuspendLayout();
            this.SuspendLayout();
            // 
            // FromDoorNameLit
            // 
            this.FromDoorNameLit.AutoSize = true;
            this.FromDoorNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDoorNameLit.Location = new System.Drawing.Point(15, 30);
            this.FromDoorNameLit.Name = "FromDoorNameLit";
            this.FromDoorNameLit.Size = new System.Drawing.Size(107, 24);
            this.FromDoorNameLit.TabIndex = 0;
            this.FromDoorNameLit.Text = "Door Name";
            // 
            // FromDoorName
            // 
            this.FromDoorName.AutoSize = true;
            this.FromDoorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDoorName.Location = new System.Drawing.Point(128, 30);
            this.FromDoorName.Name = "FromDoorName";
            this.FromDoorName.Size = new System.Drawing.Size(147, 24);
            this.FromDoorName.TabIndex = 1;
            this.FromDoorName.Text = "FromDoorName";
            // 
            // FromDoorGrpBox
            // 
            this.FromDoorGrpBox.Controls.Add(this.FromDoorID);
            this.FromDoorGrpBox.Controls.Add(this.FromDoorIDLit);
            this.FromDoorGrpBox.Controls.Add(this.FromDoorNameLit);
            this.FromDoorGrpBox.Controls.Add(this.FromDoorName);
            this.FromDoorGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDoorGrpBox.Location = new System.Drawing.Point(12, 12);
            this.FromDoorGrpBox.Name = "FromDoorGrpBox";
            this.FromDoorGrpBox.Size = new System.Drawing.Size(425, 92);
            this.FromDoorGrpBox.TabIndex = 2;
            this.FromDoorGrpBox.TabStop = false;
            this.FromDoorGrpBox.Text = "Copy From";
            // 
            // FromDoorID
            // 
            this.FromDoorID.AutoSize = true;
            this.FromDoorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDoorID.Location = new System.Drawing.Point(128, 54);
            this.FromDoorID.Name = "FromDoorID";
            this.FromDoorID.Size = new System.Drawing.Size(113, 24);
            this.FromDoorID.TabIndex = 3;
            this.FromDoorID.Text = "FromDoorID";
            // 
            // FromDoorIDLit
            // 
            this.FromDoorIDLit.AutoSize = true;
            this.FromDoorIDLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDoorIDLit.Location = new System.Drawing.Point(15, 54);
            this.FromDoorIDLit.Name = "FromDoorIDLit";
            this.FromDoorIDLit.Size = new System.Drawing.Size(73, 24);
            this.FromDoorIDLit.TabIndex = 2;
            this.FromDoorIDLit.Text = "Door ID";
            // 
            // CopyToGrpBox
            // 
            this.CopyToGrpBox.Controls.Add(this.ToDoorID);
            this.CopyToGrpBox.Controls.Add(this.ToDoorName);
            this.CopyToGrpBox.Controls.Add(this.ToDoorIDLit);
            this.CopyToGrpBox.Controls.Add(this.ToDoorNameLit);
            this.CopyToGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyToGrpBox.Location = new System.Drawing.Point(12, 123);
            this.CopyToGrpBox.Name = "CopyToGrpBox";
            this.CopyToGrpBox.Size = new System.Drawing.Size(425, 115);
            this.CopyToGrpBox.TabIndex = 4;
            this.CopyToGrpBox.TabStop = false;
            this.CopyToGrpBox.Text = "Copy To";
            // 
            // ToDoorID
            // 
            this.ToDoorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoorID.Location = new System.Drawing.Point(131, 64);
            this.ToDoorID.Name = "ToDoorID";
            this.ToDoorID.Size = new System.Drawing.Size(278, 29);
            this.ToDoorID.TabIndex = 6;
            this.ToDoorID.Text = "ToDoorID";
            // 
            // ToDoorName
            // 
            this.ToDoorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoorName.Location = new System.Drawing.Point(131, 29);
            this.ToDoorName.MaxLength = 25;
            this.ToDoorName.Name = "ToDoorName";
            this.ToDoorName.Size = new System.Drawing.Size(278, 29);
            this.ToDoorName.TabIndex = 5;
            this.ToDoorName.Text = "ToDoorName";
            // 
            // ToDoorIDLit
            // 
            this.ToDoorIDLit.AutoSize = true;
            this.ToDoorIDLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoorIDLit.Location = new System.Drawing.Point(18, 67);
            this.ToDoorIDLit.Name = "ToDoorIDLit";
            this.ToDoorIDLit.Size = new System.Drawing.Size(73, 24);
            this.ToDoorIDLit.TabIndex = 2;
            this.ToDoorIDLit.Text = "Door ID";
            // 
            // ToDoorNameLit
            // 
            this.ToDoorNameLit.AutoSize = true;
            this.ToDoorNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoorNameLit.Location = new System.Drawing.Point(18, 29);
            this.ToDoorNameLit.Name = "ToDoorNameLit";
            this.ToDoorNameLit.Size = new System.Drawing.Size(107, 24);
            this.ToDoorNameLit.TabIndex = 0;
            this.ToDoorNameLit.Text = "Door Name";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(31, 271);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(102, 32);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // myCancelButton
            // 
            this.myCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myCancelButton.Location = new System.Drawing.Point(151, 271);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(102, 32);
            this.myCancelButton.TabIndex = 6;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            this.myCancelButton.Click += new System.EventHandler(this.myCancelButton_Click);
            // 
            // CopyDoorStatusMsgHold
            // 
            this.CopyDoorStatusMsgHold.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyDoorStatusMsg});
            this.CopyDoorStatusMsgHold.Location = new System.Drawing.Point(0, 339);
            this.CopyDoorStatusMsgHold.Name = "CopyDoorStatusMsgHold";
            this.CopyDoorStatusMsgHold.Size = new System.Drawing.Size(477, 22);
            this.CopyDoorStatusMsgHold.TabIndex = 7;
            this.CopyDoorStatusMsgHold.Text = "statusStrip1";
            // 
            // CopyDoorStatusMsg
            // 
            this.CopyDoorStatusMsg.Name = "CopyDoorStatusMsg";
            this.CopyDoorStatusMsg.Size = new System.Drawing.Size(116, 17);
            this.CopyDoorStatusMsg.Text = "CopyDoorStatusMsg";
            // 
            // DoorCopyForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.myCancelButton;
            this.ClientSize = new System.Drawing.Size(477, 361);
            this.Controls.Add(this.CopyDoorStatusMsgHold);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CopyToGrpBox);
            this.Controls.Add(this.FromDoorGrpBox);
            this.Name = "DoorCopyForm";
            this.Text = "Door Copy";
            this.FromDoorGrpBox.ResumeLayout(false);
            this.FromDoorGrpBox.PerformLayout();
            this.CopyToGrpBox.ResumeLayout(false);
            this.CopyToGrpBox.PerformLayout();
            this.CopyDoorStatusMsgHold.ResumeLayout(false);
            this.CopyDoorStatusMsgHold.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FromDoorNameLit;
        private System.Windows.Forms.Label FromDoorName;
        private System.Windows.Forms.GroupBox FromDoorGrpBox;
        private System.Windows.Forms.Label FromDoorID;
        private System.Windows.Forms.Label FromDoorIDLit;
        private System.Windows.Forms.GroupBox CopyToGrpBox;
        private System.Windows.Forms.TextBox ToDoorID;
        private System.Windows.Forms.TextBox ToDoorName;
        private System.Windows.Forms.Label ToDoorIDLit;
        private System.Windows.Forms.Label ToDoorNameLit;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.StatusStrip CopyDoorStatusMsgHold;
        private System.Windows.Forms.ToolStripStatusLabel CopyDoorStatusMsg;
    }
}