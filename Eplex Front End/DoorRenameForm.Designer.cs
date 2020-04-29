namespace Eplex_Front_End
{
    partial class RenameDoorForm
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
            this.DoorNameLit = new System.Windows.Forms.Label();
            this.DoorName = new System.Windows.Forms.TextBox();
            this.NewDoorNameLit = new System.Windows.Forms.Label();
            this.NewDoorName = new System.Windows.Forms.TextBox();
            this.myOKButton = new System.Windows.Forms.Button();
            this.myCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DoorStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoorNameLit
            // 
            this.DoorNameLit.AutoSize = true;
            this.DoorNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorNameLit.Location = new System.Drawing.Point(50, 33);
            this.DoorNameLit.Name = "DoorNameLit";
            this.DoorNameLit.Size = new System.Drawing.Size(112, 24);
            this.DoorNameLit.TabIndex = 0;
            this.DoorNameLit.Text = "Door Name:";
            // 
            // DoorName
            // 
            this.DoorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoorName.Location = new System.Drawing.Point(168, 36);
            this.DoorName.Name = "DoorName";
            this.DoorName.Size = new System.Drawing.Size(383, 22);
            this.DoorName.TabIndex = 1;
            this.DoorName.Text = "DoorName";
            // 
            // NewDoorNameLit
            // 
            this.NewDoorNameLit.AutoSize = true;
            this.NewDoorNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDoorNameLit.Location = new System.Drawing.Point(6, 74);
            this.NewDoorNameLit.Name = "NewDoorNameLit";
            this.NewDoorNameLit.Size = new System.Drawing.Size(156, 24);
            this.NewDoorNameLit.TabIndex = 2;
            this.NewDoorNameLit.Text = "New Door Name:";
            // 
            // NewDoorName
            // 
            this.NewDoorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDoorName.Location = new System.Drawing.Point(168, 76);
            this.NewDoorName.Name = "NewDoorName";
            this.NewDoorName.Size = new System.Drawing.Size(383, 22);
            this.NewDoorName.TabIndex = 3;
            this.NewDoorName.Text = "NewDoorName";
            // 
            // myOKButton
            // 
            this.myOKButton.Location = new System.Drawing.Point(82, 135);
            this.myOKButton.Name = "myOKButton";
            this.myOKButton.Size = new System.Drawing.Size(80, 30);
            this.myOKButton.TabIndex = 4;
            this.myOKButton.Text = "OK";
            this.myOKButton.UseVisualStyleBackColor = true;
            this.myOKButton.Click += new System.EventHandler(this.myOKButton_Click);
            // 
            // myCancel
            // 
            this.myCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myCancel.Location = new System.Drawing.Point(168, 135);
            this.myCancel.Name = "myCancel";
            this.myCancel.Size = new System.Drawing.Size(80, 30);
            this.myCancel.TabIndex = 5;
            this.myCancel.Text = "Cancel";
            this.myCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoorStatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 197);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(575, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DoorStatusMsg
            // 
            this.DoorStatusMsg.Name = "DoorStatusMsg";
            this.DoorStatusMsg.Size = new System.Drawing.Size(118, 17);
            this.DoorStatusMsg.Text = "toolStripStatusLabel1";
            // 
            // RenameDoorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 219);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myCancel);
            this.Controls.Add(this.myOKButton);
            this.Controls.Add(this.NewDoorName);
            this.Controls.Add(this.NewDoorNameLit);
            this.Controls.Add(this.DoorName);
            this.Controls.Add(this.DoorNameLit);
            this.Name = "RenameDoorForm";
            this.Text = "Rename Door/Lock";
            this.Load += new System.EventHandler(this.RenameDoorForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DoorNameLit;
        public System.Windows.Forms.TextBox DoorName;
        private System.Windows.Forms.Label NewDoorNameLit;
        public System.Windows.Forms.TextBox NewDoorName;
        private System.Windows.Forms.Button myOKButton;
        private System.Windows.Forms.Button myCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DoorStatusMsg;
    }
}