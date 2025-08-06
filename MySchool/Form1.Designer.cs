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
            this.StudentsManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStudentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.activateDeactivateStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tCourses = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesManagemantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSections = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionManagemantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.tStudents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StudentsManagementToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewStudentToolStripMenuItem,
            this.updateStudentInfoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.activateDeactivateStudentToolStripMenuItem});
            this.tStudents.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStudents.Image = global::MySchool.Properties.Resources.People_64;
            this.tStudents.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tStudents.Name = "tStudents";
            this.tStudents.Size = new System.Drawing.Size(215, 68);
            this.tStudents.Text = "    Students";
            this.tStudents.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click_1);
            // 
            // StudentsManagementToolStripMenuItem
            // 
            this.StudentsManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentsManagementToolStripMenuItem.Name = "StudentsManagementToolStripMenuItem";
            this.StudentsManagementToolStripMenuItem.Size = new System.Drawing.Size(286, 24);
            this.StudentsManagementToolStripMenuItem.Text = "Students Management";
            this.StudentsManagementToolStripMenuItem.Click += new System.EventHandler(this.StudentsManagementToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(283, 6);
            // 
            // addNewStudentToolStripMenuItem
            // 
            this.addNewStudentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewStudentToolStripMenuItem.Name = "addNewStudentToolStripMenuItem";
            this.addNewStudentToolStripMenuItem.Size = new System.Drawing.Size(286, 24);
            this.addNewStudentToolStripMenuItem.Text = "Add new student";
            this.addNewStudentToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentToolStripMenuItem_Click);
            // 
            // updateStudentInfoToolStripMenuItem
            // 
            this.updateStudentInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateStudentInfoToolStripMenuItem.Name = "updateStudentInfoToolStripMenuItem";
            this.updateStudentInfoToolStripMenuItem.Size = new System.Drawing.Size(286, 24);
            this.updateStudentInfoToolStripMenuItem.Text = "Update Student Info";
            this.updateStudentInfoToolStripMenuItem.Click += new System.EventHandler(this.updateStudentInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(283, 6);
            // 
            // activateDeactivateStudentToolStripMenuItem
            // 
            this.activateDeactivateStudentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateDeactivateStudentToolStripMenuItem.Name = "activateDeactivateStudentToolStripMenuItem";
            this.activateDeactivateStudentToolStripMenuItem.Size = new System.Drawing.Size(286, 24);
            this.activateDeactivateStudentToolStripMenuItem.Text = "Activate / Deactivate student";
            // 
            // tTeachers
            // 
            this.tTeachers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTeacherToolStripMenuItem});
            this.tTeachers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTeachers.Image = global::MySchool.Properties.Resources.Teachers_64;
            this.tTeachers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tTeachers.Name = "tTeachers";
            this.tTeachers.Size = new System.Drawing.Size(215, 68);
            this.tTeachers.Text = "    Teachers";
            // 
            // addNewTeacherToolStripMenuItem
            // 
            this.addNewTeacherToolStripMenuItem.Name = "addNewTeacherToolStripMenuItem";
            this.addNewTeacherToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.addNewTeacherToolStripMenuItem.Text = "Add New Teacher";
            this.addNewTeacherToolStripMenuItem.Click += new System.EventHandler(this.addNewTeacherToolStripMenuItem_Click);
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
            this.tCourses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coursesManagemantToolStripMenuItem,
            this.toolStripMenuItem3,
            this.addNewCourseToolStripMenuItem});
            this.tCourses.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCourses.Image = global::MySchool.Properties.Resources.Curriculum_64;
            this.tCourses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tCourses.Name = "tCourses";
            this.tCourses.Size = new System.Drawing.Size(215, 68);
            this.tCourses.Text = "    Courses";
            this.tCourses.Click += new System.EventHandler(this.tCourses_Click);
            // 
            // coursesManagemantToolStripMenuItem
            // 
            this.coursesManagemantToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.coursesManagemantToolStripMenuItem.Name = "coursesManagemantToolStripMenuItem";
            this.coursesManagemantToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.coursesManagemantToolStripMenuItem.Text = "Courses Managemant";
            this.coursesManagemantToolStripMenuItem.Click += new System.EventHandler(this.coursesManagemantToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(230, 6);
            // 
            // addNewCourseToolStripMenuItem
            // 
            this.addNewCourseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.addNewCourseToolStripMenuItem.Name = "addNewCourseToolStripMenuItem";
            this.addNewCourseToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.addNewCourseToolStripMenuItem.Text = "Add New Course";
            this.addNewCourseToolStripMenuItem.Click += new System.EventHandler(this.addNewCourseToolStripMenuItem_Click);
            // 
            // tSections
            // 
            this.tSections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectionManagemantToolStripMenuItem,
            this.toolStripMenuItem4,
            this.addNewSectionToolStripMenuItem});
            this.tSections.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSections.Image = global::MySchool.Properties.Resources.Classroom_64;
            this.tSections.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSections.Name = "tSections";
            this.tSections.Size = new System.Drawing.Size(215, 68);
            this.tSections.Text = "    Sections";
            this.tSections.Click += new System.EventHandler(this.tSections_Click);
            // 
            // sectionManagemantToolStripMenuItem
            // 
            this.sectionManagemantToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.sectionManagemantToolStripMenuItem.Name = "sectionManagemantToolStripMenuItem";
            this.sectionManagemantToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.sectionManagemantToolStripMenuItem.Text = "Section Management";
            this.sectionManagemantToolStripMenuItem.Click += new System.EventHandler(this.sectionManagemantToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(226, 6);
            // 
            // addNewSectionToolStripMenuItem
            // 
            this.addNewSectionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.addNewSectionToolStripMenuItem.Name = "addNewSectionToolStripMenuItem";
            this.addNewSectionToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.addNewSectionToolStripMenuItem.Text = "Add New Section";
            this.addNewSectionToolStripMenuItem.Click += new System.EventHandler(this.addNewSectionToolStripMenuItem_Click);
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
            this.tUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem});
            this.tUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsers.Image = global::MySchool.Properties.Resources.Users_64;
            this.tUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tUsers.Name = "tUsers";
            this.tUsers.Size = new System.Drawing.Size(215, 68);
            this.tUsers.Text = "    Users";
            this.tUsers.Click += new System.EventHandler(this.tUsers_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::MySchool.Properties.Resources.User_32;
            this.addNewUserToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(227, 38);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StudentsManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStudentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem activateDeactivateStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesManagemantToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem addNewCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionManagemantToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem addNewSectionToolStripMenuItem;
    }
}

