namespace MySchool
{
    partial class frmMainPage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tStudents = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.tPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.tSections = new System.Windows.Forms.ToolStripMenuItem();
            this.tGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(222, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(880, 580);
            this.label1.TabIndex = 2;
            this.label1.Text = "قيد التطوير ...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStudents,
            this.tTeachers,
            this.tPeople,
            this.tCourses,
            this.tSections,
            this.tGroups,
            this.tUsers,
            this.tSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(222, 580);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tStudents
            // 
            this.tStudents.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStudents.Image = global::MySchool.Properties.Resources.People_64;
            this.tStudents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStudents.Name = "tStudents";
            this.tStudents.Size = new System.Drawing.Size(215, 68);
            this.tStudents.Text = "    Students";
            this.tStudents.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(222, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 580);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(222, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(880, 580);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tTeachers
            // 
            this.tTeachers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTeachers.Image = global::MySchool.Properties.Resources.Teachers_64;
            this.tTeachers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tTeachers.Name = "tTeachers";
            this.tTeachers.Size = new System.Drawing.Size(215, 68);
            this.tTeachers.Text = "    Teachers";
            // 
            // tPeople
            // 
            this.tPeople.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPeople.Image = global::MySchool.Properties.Resources.People_64;
            this.tPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tPeople.Name = "tPeople";
            this.tPeople.Size = new System.Drawing.Size(215, 68);
            this.tPeople.Text = "    People";
            this.tPeople.Click += new System.EventHandler(this.tTeachers_Click);
            // 
            // tCourses
            // 
            this.tCourses.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCourses.Image = global::MySchool.Properties.Resources.Curriculum_64;
            this.tCourses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tCourses.Name = "tCourses";
            this.tCourses.Size = new System.Drawing.Size(215, 68);
            this.tCourses.Text = "    Courses";
            this.tCourses.Click += new System.EventHandler(this.tCourses_Click);
            // 
            // tSections
            // 
            this.tSections.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSections.Image = global::MySchool.Properties.Resources.Classroom_64;
            this.tSections.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSections.Name = "tSections";
            this.tSections.Size = new System.Drawing.Size(215, 68);
            this.tSections.Text = "    Sections";
            this.tSections.Click += new System.EventHandler(this.tSections_Click);
            // 
            // tGroups
            // 
            this.tGroups.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tGroups.Image = global::MySchool.Properties.Resources.Groups_64;
            this.tGroups.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tGroups.Name = "tGroups";
            this.tGroups.Size = new System.Drawing.Size(215, 68);
            this.tGroups.Text = "    Groups";
            this.tGroups.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tUsers
            // 
            this.tUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsers.Image = global::MySchool.Properties.Resources.Users_64;
            this.tUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tUsers.Name = "tUsers";
            this.tUsers.Size = new System.Drawing.Size(215, 68);
            this.tUsers.Text = "    Users";
            this.tUsers.Click += new System.EventHandler(this.tUsers_Click);
            // 
            // tSettings
            // 
            this.tSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.tSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSettings.Image = global::MySchool.Properties.Resources.Settings_64;
            this.tSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSettings.Name = "tSettings";
            this.tSettings.Size = new System.Drawing.Size(215, 68);
            this.tSettings.Text = "    Settings";
            this.tSettings.Click += new System.EventHandler(this.tSettings_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1102, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tStudents;
        private System.Windows.Forms.ToolStripMenuItem tPeople;
        private System.Windows.Forms.ToolStripMenuItem tCourses;
        private System.Windows.Forms.ToolStripMenuItem tSections;
        private System.Windows.Forms.ToolStripMenuItem tUsers;
        private System.Windows.Forms.ToolStripMenuItem tSettings;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tGroups;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tTeachers;
    }
}

