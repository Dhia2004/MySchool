namespace MySchool
{
    partial class ctrlStudentInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlStudentInfoWithFilter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.ctrlStudentInfoCard1 = new MySchool.ctrlStudentInfoCard();
            this.btnAddNewStudent = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddNewStudent);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtStudentID);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 58);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(286, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 20);
            this.panel2.TabIndex = 123;
            // 
            // txtStudentID
            // 
            this.txtStudentID.BackColor = System.Drawing.Color.White;
            this.txtStudentID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStudentID.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(39, 17);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(241, 23);
            this.txtStudentID.TabIndex = 122;
            // 
            // ctrlStudentInfoCard1
            // 
            this.ctrlStudentInfoCard1.BackColor = System.Drawing.Color.White;
            this.ctrlStudentInfoCard1.Location = new System.Drawing.Point(0, 66);
            this.ctrlStudentInfoCard1.Name = "ctrlStudentInfoCard1";
            this.ctrlStudentInfoCard1.Size = new System.Drawing.Size(389, 591);
            this.ctrlStudentInfoCard1.TabIndex = 0;
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.BackColor = System.Drawing.Color.White;
            this.btnAddNewStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewStudent.FlatAppearance.BorderSize = 0;
            this.btnAddNewStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewStudent.Image")));
            this.btnAddNewStudent.Location = new System.Drawing.Point(342, 14);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(30, 30);
            this.btnAddNewStudent.TabIndex = 143;
            this.btnAddNewStudent.UseVisualStyleBackColor = false;
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::MySchool.Properties.Resources.Search_24;
            this.btnSearch.Location = new System.Drawing.Point(294, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 27);
            this.btnSearch.TabIndex = 142;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlStudentInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlStudentInfoCard1);
            this.Name = "ctrlStudentInfoWithFilter";
            this.Size = new System.Drawing.Size(389, 658);
            this.Load += new System.EventHandler(this.ctrlStudentInfoWithFilter_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrlStudentInfoWithFilter_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlStudentInfoCard ctrlStudentInfoCard1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNewStudent;
    }
}
