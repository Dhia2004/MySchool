namespace MySchool
{
    partial class frmEditStudentStatus
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
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDeactivationReason = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDesactivate = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = global::MySchool.Properties.Resources.Cross_64;
            this.pbExit.Location = new System.Drawing.Point(307, 2);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(47, 48);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 92;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(88, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 50);
            this.panel1.TabIndex = 91;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MySchool.Properties.Resources.Students_512;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 68);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 90;
            this.pictureBox3.TabStop = false;
            // 
            // lblMode
            // 
            this.lblMode.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(96, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(193, 24);
            this.lblMode.TabIndex = 89;
            this.lblMode.Text = "Desactivate Student";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.Red;
            this.lblStudentID.Location = new System.Drawing.Point(241, 116);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(48, 21);
            this.lblStudentID.TabIndex = 121;
            this.lblStudentID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(99, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 120;
            this.label1.Text = "Student ID :";
            // 
            // lblFullName
            // 
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.Black;
            this.lblFullName.Location = new System.Drawing.Point(12, 216);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(330, 21);
            this.lblFullName.TabIndex = 123;
            this.lblFullName.Text = "Dhia Eddine DJEDDI";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(108, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 21);
            this.label2.TabIndex = 124;
            this.label2.Text = "Deactivation Reason";
            // 
            // cbDeactivationReason
            // 
            this.cbDeactivationReason.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbDeactivationReason.FormattingEnabled = true;
            this.cbDeactivationReason.Items.AddRange(new object[] {
            "01 - Non-payment of tuition fees",
            "02 - Transferred to another school",
            "03 - Dropped out of school",
            "04 - Graduated or completed school level",
            "05 - Prolonged unexplained absence",
            "06 - Family or social circumstances",
            "07 - Health-related issues",
            "08 - Disciplinary action",
            "09 - Parent/guardian request",
            "10 - Travel or relocation abroad"});
            this.cbDeactivationReason.Location = new System.Drawing.Point(51, 316);
            this.cbDeactivationReason.Name = "cbDeactivationReason";
            this.cbDeactivationReason.Size = new System.Drawing.Size(251, 28);
            this.cbDeactivationReason.TabIndex = 125;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MySchool.Properties.Resources.Info_24;
            this.pictureBox1.Location = new System.Drawing.Point(79, 263);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // btnDesactivate
            // 
            this.btnDesactivate.BackColor = System.Drawing.Color.White;
            this.btnDesactivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDesactivate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDesactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesactivate.ForeColor = System.Drawing.Color.Black;
            this.btnDesactivate.Image = global::MySchool.Properties.Resources.Desactivate_32;
            this.btnDesactivate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesactivate.Location = new System.Drawing.Point(172, 381);
            this.btnDesactivate.Name = "btnDesactivate";
            this.btnDesactivate.Size = new System.Drawing.Size(170, 42);
            this.btnDesactivate.TabIndex = 127;
            this.btnDesactivate.Text = "     Desactivate";
            this.btnDesactivate.UseVisualStyleBackColor = false;
            this.btnDesactivate.Click += new System.EventHandler(this.btnDesactivate_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MySchool.Properties.Resources.Person_ID_32;
            this.pictureBox2.Location = new System.Drawing.Point(68, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 128;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MySchool.Properties.Resources.Student_32;
            this.pictureBox4.Location = new System.Drawing.Point(118, 163);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 129;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(149, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 21);
            this.label3.TabIndex = 130;
            this.label3.Text = "Full Name";
            // 
            // frmEditStudentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 438);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnDesactivate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbDeactivationReason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditStudentStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditStudentStatus";
            this.Load += new System.EventHandler(this.frmEditStudentStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDeactivationReason;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDesactivate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
    }
}