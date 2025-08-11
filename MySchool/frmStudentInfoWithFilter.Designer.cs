namespace MySchool
{
    partial class frmStudentInfoWithFilter
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
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.ctrlStudentInfoWithFilter1 = new MySchool.ctrlStudentInfoWithFilter();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = global::MySchool.Properties.Resources.Cross_64;
            this.pbClose.Location = new System.Drawing.Point(359, 16);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(48, 45);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 89;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // ctrlStudentInfoWithFilter1
            // 
            this.ctrlStudentInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlStudentInfoWithFilter1.Location = new System.Drawing.Point(18, 116);
            this.ctrlStudentInfoWithFilter1.Name = "ctrlStudentInfoWithFilter1";
            this.ctrlStudentInfoWithFilter1.Size = new System.Drawing.Size(389, 658);
            this.ctrlStudentInfoWithFilter1.TabIndex = 90;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Blue;
            this.panel12.Location = new System.Drawing.Point(-19, 16);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(43, 84);
            this.panel12.TabIndex = 151;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(135, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 50);
            this.panel1.TabIndex = 154;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MySchool.Properties.Resources.Students_512;
            this.pictureBox3.Location = new System.Drawing.Point(29, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(93, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 153;
            this.pictureBox3.TabStop = false;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Blue;
            this.lblMode.Location = new System.Drawing.Point(164, 34);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(153, 50);
            this.lblMode.TabIndex = 152;
            this.lblMode.Text = "Enter ID or scan\r\nstudent QR";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmStudentInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.ctrlStudentInfoWithFilter1);
            this.Controls.Add(this.pbClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStudentInfoWithFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStudentInfoWithFilter";
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbClose;
        private ctrlStudentInfoWithFilter ctrlStudentInfoWithFilter1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblMode;
    }
}