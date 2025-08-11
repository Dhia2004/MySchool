namespace MySchool
{
    partial class frmPersonInfo
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
            this.ctrlPersonInfoCard1 = new MySchool.ctrlPersonInfoCard();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPersonInfoCard1
            // 
            this.ctrlPersonInfoCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfoCard1.Location = new System.Drawing.Point(31, 133);
            this.ctrlPersonInfoCard1.Name = "ctrlPersonInfoCard1";
            this.ctrlPersonInfoCard1.Size = new System.Drawing.Size(389, 591);
            this.ctrlPersonInfoCard1.TabIndex = 0;
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::MySchool.Properties.Resources.Cross_64;
            this.pbClose.Location = new System.Drawing.Point(390, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(48, 45);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 88;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(-12, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 102);
            this.panel1.TabIndex = 168;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MySchool.Properties.Resources.People_64;
            this.pictureBox1.Location = new System.Drawing.Point(40, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 170;
            this.pictureBox1.TabStop = false;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Gray;
            this.lblMode.Location = new System.Drawing.Point(132, 27);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(236, 47);
            this.lblMode.TabIndex = 171;
            this.lblMode.Text = "Peson details";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 757);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.ctrlPersonInfoCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPersonInfo";
            this.Load += new System.EventHandler(this.frmPersonInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInfoCard ctrlPersonInfoCard1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMode;
    }
}