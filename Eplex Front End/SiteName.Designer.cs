namespace Eplex_Front_End
{
    partial class SiteName
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
            this.CurSiteNameLit = new System.Windows.Forms.Label();
            this.SiteName1 = new System.Windows.Forms.TextBox();
            this.NewSiteNameLit = new System.Windows.Forms.Label();
            this.NewSiteName = new System.Windows.Forms.TextBox();
            this.myOKButton = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SiteNameMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurSiteNameLit
            // 
            this.CurSiteNameLit.AutoSize = true;
            this.CurSiteNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurSiteNameLit.Location = new System.Drawing.Point(56, 56);
            this.CurSiteNameLit.Name = "CurSiteNameLit";
            this.CurSiteNameLit.Size = new System.Drawing.Size(97, 24);
            this.CurSiteNameLit.TabIndex = 0;
            this.CurSiteNameLit.Text = "Site Name";
            // 
            // SiteName1
            // 
            this.SiteName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SiteName1.Location = new System.Drawing.Point(159, 56);
            this.SiteName1.Name = "SiteName1";
            this.SiteName1.Size = new System.Drawing.Size(593, 29);
            this.SiteName1.TabIndex = 1;
            this.SiteName1.Text = "SiteName1";
            // 
            // NewSiteNameLit
            // 
            this.NewSiteNameLit.AutoSize = true;
            this.NewSiteNameLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSiteNameLit.Location = new System.Drawing.Point(12, 134);
            this.NewSiteNameLit.Name = "NewSiteNameLit";
            this.NewSiteNameLit.Size = new System.Drawing.Size(141, 24);
            this.NewSiteNameLit.TabIndex = 2;
            this.NewSiteNameLit.Text = "New Site Name";
            // 
            // NewSiteName
            // 
            this.NewSiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSiteName.Location = new System.Drawing.Point(159, 134);
            this.NewSiteName.Name = "NewSiteName";
            this.NewSiteName.Size = new System.Drawing.Size(593, 29);
            this.NewSiteName.TabIndex = 3;
            this.NewSiteName.Text = "NewSiteName";
            // 
            // myOKButton
            // 
            this.myOKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myOKButton.Location = new System.Drawing.Point(42, 214);
            this.myOKButton.Name = "myOKButton";
            this.myOKButton.Size = new System.Drawing.Size(98, 34);
            this.myOKButton.TabIndex = 4;
            this.myOKButton.Text = "OK";
            this.myOKButton.UseVisualStyleBackColor = true;
            this.myOKButton.Click += new System.EventHandler(this.myOKButton_Click);
            // 
            // myCancelButton
            // 
            this.myCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.myCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myCancelButton.Location = new System.Drawing.Point(159, 214);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(95, 35);
            this.myCancelButton.TabIndex = 5;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            this.myCancelButton.Click += new System.EventHandler(this.myCancelButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SiteNameMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 286);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SiteNameMsg
            // 
            this.SiteNameMsg.Name = "SiteNameMsg";
            this.SiteNameMsg.Size = new System.Drawing.Size(81, 17);
            this.SiteNameMsg.Text = "SiteNameMsg";
            // 
            // SiteName
            // 
            this.AcceptButton = this.myOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.myCancelButton;
            this.ClientSize = new System.Drawing.Size(800, 308);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.myOKButton);
            this.Controls.Add(this.NewSiteName);
            this.Controls.Add(this.NewSiteNameLit);
            this.Controls.Add(this.SiteName1);
            this.Controls.Add(this.CurSiteNameLit);
            this.Name = "SiteName";
            this.Text = "Site Name";
            this.Load += new System.EventHandler(this.SiteName_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurSiteNameLit;
        private System.Windows.Forms.TextBox SiteName1;
        private System.Windows.Forms.Label NewSiteNameLit;
        private System.Windows.Forms.TextBox NewSiteName;
        private System.Windows.Forms.Button myOKButton;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SiteNameMsg;
    }
}