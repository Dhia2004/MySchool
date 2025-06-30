namespace MySchool
{
    partial class frmAllStudents
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecorsNumber = new System.Windows.Forms.Label();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.ctrlStudentInfoWithFilter1 = new MySchool.ctrlStudentInfoWithFilter();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbRefrech = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbStudentImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefrech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 161);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(901, 534);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(160, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 100);
            this.panel1.TabIndex = 86;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(209, 36);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(410, 47);
            this.lblMode.TabIndex = 87;
            this.lblMode.Text = "Students Managements";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(172, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 21);
            this.label2.TabIndex = 103;
            this.label2.Text = "Search - Add - Edit - Delete - etc .....";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 760);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 106;
            this.label1.Text = "#Records :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecorsNumber
            // 
            this.lblRecorsNumber.AutoSize = true;
            this.lblRecorsNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecorsNumber.ForeColor = System.Drawing.Color.Black;
            this.lblRecorsNumber.Location = new System.Drawing.Point(114, 760);
            this.lblRecorsNumber.Name = "lblRecorsNumber";
            this.lblRecorsNumber.Size = new System.Drawing.Size(0, 25);
            this.lblRecorsNumber.TabIndex = 107;
            this.lblRecorsNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.ForeColor = System.Drawing.Color.Black;
            this.lblPageNumber.Location = new System.Drawing.Point(811, 711);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(61, 35);
            this.lblPageNumber.TabIndex = 110;
            this.lblPageNumber.Tag = "1";
            this.lblPageNumber.Text = "1";
            this.lblPageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlStudentInfoWithFilter1
            // 
            this.ctrlStudentInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlStudentInfoWithFilter1.Location = new System.Drawing.Point(919, 92);
            this.ctrlStudentInfoWithFilter1.Name = "ctrlStudentInfoWithFilter1";
            this.ctrlStudentInfoWithFilter1.Size = new System.Drawing.Size(389, 658);
            this.ctrlStudentInfoWithFilter1.TabIndex = 0;
            // 
            // pbBack
            // 
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = global::MySchool.Properties.Resources.Back_32;
            this.pbBack.Location = new System.Drawing.Point(770, 711);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(35, 35);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBack.TabIndex = 113;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // pbNext
            // 
            this.pbNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNext.Image = global::MySchool.Properties.Resources.Next_32;
            this.pbNext.Location = new System.Drawing.Point(878, 711);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(35, 35);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbNext.TabIndex = 112;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbRefrech
            // 
            this.pbRefrech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRefrech.Image = global::MySchool.Properties.Resources.Reload_24;
            this.pbRefrech.Location = new System.Drawing.Point(717, 711);
            this.pbRefrech.Name = "pbRefrech";
            this.pbRefrech.Size = new System.Drawing.Size(35, 35);
            this.pbRefrech.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRefrech.TabIndex = 111;
            this.pbRefrech.TabStop = false;
            this.pbRefrech.Click += new System.EventHandler(this.pbRefrech_Click);
            // 
            // pbExit
            // 
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = global::MySchool.Properties.Resources.Cross_64;
            this.pbExit.Location = new System.Drawing.Point(1261, 10);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(47, 48);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 105;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::MySchool.Properties.Resources.Equipment_72;
            this.pictureBox2.Location = new System.Drawing.Point(176, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 104;
            this.pictureBox2.TabStop = false;
            // 
            // pbStudentImage
            // 
            this.pbStudentImage.Image = global::MySchool.Properties.Resources.Students_512;
            this.pbStudentImage.Location = new System.Drawing.Point(12, 5);
            this.pbStudentImage.Name = "pbStudentImage";
            this.pbStudentImage.Size = new System.Drawing.Size(142, 148);
            this.pbStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStudentImage.TabIndex = 85;
            this.pbStudentImage.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(1190, 756);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 35);
            this.btnClose.TabIndex = 84;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAllStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1315, 799);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pbRefrech);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.lblRecorsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.ctrlStudentInfoWithFilter1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbStudentImage);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAllStudents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAllStudents";
            this.Load += new System.EventHandler(this.frmAllStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefrech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbStudentImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ctrlStudentInfoWithFilter ctrlStudentInfoWithFilter1;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecorsNumber;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.PictureBox pbRefrech;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbBack;
    }
}