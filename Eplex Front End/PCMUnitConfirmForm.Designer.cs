namespace Eplex_Front_End
{
    partial class PCMUnitConfirmForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PCMUnitFileAndPathLit = new System.Windows.Forms.Label();
            this.Dismiss = new System.Windows.Forms.Button();
            this.CopyFileName = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "The PCMUnit file has been generated.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PCMUnitFileAndPathLit);
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Information";
            // 
            // PCMUnitFileAndPathLit
            // 
            this.PCMUnitFileAndPathLit.AutoSize = true;
            this.PCMUnitFileAndPathLit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCMUnitFileAndPathLit.Location = new System.Drawing.Point(6, 40);
            this.PCMUnitFileAndPathLit.Name = "PCMUnitFileAndPathLit";
            this.PCMUnitFileAndPathLit.Size = new System.Drawing.Size(159, 20);
            this.PCMUnitFileAndPathLit.TabIndex = 0;
            this.PCMUnitFileAndPathLit.Text = "PCMUnitFileAndPath";
            // 
            // Dismiss
            // 
            this.Dismiss.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dismiss.Location = new System.Drawing.Point(22, 216);
            this.Dismiss.Name = "Dismiss";
            this.Dismiss.Size = new System.Drawing.Size(92, 27);
            this.Dismiss.TabIndex = 2;
            this.Dismiss.Text = "Dismiss";
            this.Dismiss.UseVisualStyleBackColor = true;
            this.Dismiss.Click += new System.EventHandler(this.Dismiss_Click);
            // 
            // CopyFileName
            // 
            this.CopyFileName.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CopyFileName.Location = new System.Drawing.Point(134, 216);
            this.CopyFileName.Name = "CopyFileName";
            this.CopyFileName.Size = new System.Drawing.Size(194, 27);
            this.CopyFileName.TabIndex = 3;
            this.CopyFileName.Text = "Copy File Name to Clpboard";
            this.CopyFileName.UseVisualStyleBackColor = true;
            this.CopyFileName.Click += new System.EventHandler(this.CopyFileName_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(348, 216);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(65, 27);
            this.OpenFile.TabIndex = 4;
            this.OpenFile.Text = "Open";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // PCMUnitConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Dismiss;
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.CopyFileName);
            this.Controls.Add(this.Dismiss);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "PCMUnitConfirmForm";
            this.Text = "PCMUnit FIle Generation Confirm]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PCMUnitConfirmForm_FormClosing);
            this.Load += new System.EventHandler(this.PCMUnitConfirmForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PCMUnitFileAndPathLit;
        private System.Windows.Forms.Button Dismiss;
        private System.Windows.Forms.Button CopyFileName;
        private System.Windows.Forms.Button OpenFile;
    }
}