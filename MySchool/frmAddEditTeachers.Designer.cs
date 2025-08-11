namespace MySchool
{
    partial class frmAddEditTeachers
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
            this.label2 = new System.Windows.Forms.Label();
            this.tmWarning = new System.Windows.Forms.Timer(this.components);
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTeacherID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbAlarm = new System.Windows.Forms.PictureBox();
            this.pnlAccountInformation = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlPersonInfoWithFilter1 = new MySchool.ctrlPersonInfoWithFilter();
            this.pnlWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlarm)).BeginInit();
            this.pnlAccountInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(105, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 40);
            this.label2.TabIndex = 150;
            this.label2.Text = "Warning !!!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmWarning
            // 
            this.tmWarning.Enabled = true;
            this.tmWarning.Interval = 1000;
            this.tmWarning.Tick += new System.EventHandler(this.tmWarning_Tick);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(230, 315);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(91, 25);
            this.chkIsActive.TabIndex = 106;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(134, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 40);
            this.label1.TabIndex = 91;
            this.label1.Text = "Teacher Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTeacherID
            // 
            this.lblTeacherID.AutoSize = true;
            this.lblTeacherID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacherID.ForeColor = System.Drawing.Color.Red;
            this.lblTeacherID.Location = new System.Drawing.Point(674, 129);
            this.lblTeacherID.Name = "lblTeacherID";
            this.lblTeacherID.Size = new System.Drawing.Size(40, 21);
            this.lblTeacherID.TabIndex = 157;
            this.lblTeacherID.Text = "N/A";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(578, 129);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 21);
            this.label16.TabIndex = 156;
            this.label16.Text = "Teacher ID :";
            // 
            // pnlWarning
            // 
            this.pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarning.Controls.Add(this.label3);
            this.pnlWarning.Controls.Add(this.label2);
            this.pnlWarning.Controls.Add(this.pbAlarm);
            this.pnlWarning.Location = new System.Drawing.Point(436, 175);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(383, 536);
            this.pnlWarning.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 50);
            this.label3.TabIndex = 206;
            this.label3.Text = "Please select a person first before\r\ncontinuing the process";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAlarm
            // 
            this.pbAlarm.Enabled = false;
            this.pbAlarm.Image = global::MySchool.Properties.Resources.Alarm_128;
            this.pbAlarm.Location = new System.Drawing.Point(117, 38);
            this.pbAlarm.Name = "pbAlarm";
            this.pbAlarm.Size = new System.Drawing.Size(146, 146);
            this.pbAlarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAlarm.TabIndex = 150;
            this.pbAlarm.TabStop = false;
            // 
            // pnlAccountInformation
            // 
            this.pnlAccountInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccountInformation.Controls.Add(this.panel5);
            this.pnlAccountInformation.Controls.Add(this.lblCreatedByUser);
            this.pnlAccountInformation.Controls.Add(this.lblFullName);
            this.pnlAccountInformation.Controls.Add(this.cbSubjects);
            this.pnlAccountInformation.Controls.Add(this.pictureBox5);
            this.pnlAccountInformation.Controls.Add(this.label6);
            this.pnlAccountInformation.Controls.Add(this.pictureBox4);
            this.pnlAccountInformation.Controls.Add(this.label5);
            this.pnlAccountInformation.Controls.Add(this.pictureBox2);
            this.pnlAccountInformation.Controls.Add(this.label4);
            this.pnlAccountInformation.Controls.Add(this.pictureBox1);
            this.pnlAccountInformation.Controls.Add(this.chkIsActive);
            this.pnlAccountInformation.Controls.Add(this.label1);
            this.pnlAccountInformation.Location = new System.Drawing.Point(436, 175);
            this.pnlAccountInformation.Name = "pnlAccountInformation";
            this.pnlAccountInformation.Size = new System.Drawing.Size(383, 536);
            this.pnlAccountInformation.TabIndex = 153;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel5.Location = new System.Drawing.Point(21, 161);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(342, 1);
            this.panel5.TabIndex = 231;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(95, 438);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(225, 21);
            this.lblCreatedByUser.TabIndex = 125;
            this.lblCreatedByUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.Red;
            this.lblFullName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFullName.Location = new System.Drawing.Point(139, 116);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(213, 21);
            this.lblFullName.TabIndex = 124;
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSubjects
            // 
            this.cbSubjects.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Location = new System.Drawing.Point(59, 253);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(262, 28);
            this.cbSubjects.TabIndex = 122;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::MySchool.Properties.Resources.Created_By_User_32;
            this.pictureBox5.Location = new System.Drawing.Point(59, 392);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 116;
            this.pictureBox5.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 21);
            this.label6.TabIndex = 115;
            this.label6.Text = "Created By User :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MySchool.Properties.Resources.Subject_32;
            this.pictureBox4.Location = new System.Drawing.Point(129, 198);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(44, 39);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 114;
            this.pictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 113;
            this.label5.Text = "Subject :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MySchool.Properties.Resources.Student_32;
            this.pictureBox2.Location = new System.Drawing.Point(137, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 112;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 111;
            this.label4.Text = "Full Name :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MySchool.Properties.Resources.User_256;
            this.pictureBox1.Location = new System.Drawing.Point(21, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(154, 38);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(256, 40);
            this.lblMode.TabIndex = 151;
            this.lblMode.Text = "Add New Teacher";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = global::MySchool.Properties.Resources.Person_ID_32;
            this.pictureBox21.Location = new System.Drawing.Point(549, 126);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(25, 27);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox21.TabIndex = 158;
            this.pictureBox21.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::MySchool.Properties.Resources.Close_ic_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(587, 726);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 35);
            this.btnClose.TabIndex = 155;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::MySchool.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(706, 726);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 35);
            this.btnSave.TabIndex = 154;
            this.btnSave.Text = "     Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MySchool.Properties.Resources.teacher_32;
            this.pictureBox3.Location = new System.Drawing.Point(57, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(81, 81);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 170;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(-18, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 102);
            this.panel1.TabIndex = 169;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(146, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 60);
            this.panel2.TabIndex = 171;
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(17, 106);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(391, 660);
            this.ctrlPersonInfoWithFilter1.TabIndex = 150;
            // 
            // frmAddEditTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 775);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Controls.Add(this.lblTeacherID);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlAccountInformation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(852, 802);
            this.Name = "frmAddEditTeachers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Teacher";
            this.Load += new System.EventHandler(this.frmAddEditTeachers_Load);
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlarm)).EndInit();
            this.pnlAccountInformation.ResumeLayout(false);
            this.pnlAccountInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmWarning;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbAlarm;
        private System.Windows.Forms.Button btnSave;
        private ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Label lblTeacherID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlAccountInformation;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSubjects;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}