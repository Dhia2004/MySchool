using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class frmMainPage: Form
    {
        public frmMainPage()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to sign out ?", "Confirm", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question) == DialogResult.Yes)
            {

                clsGlobalSettings.CurrentUser = null;
                clsGlobalSettings.IsLoggedOut = true;
                clsGlobalSettings.IsLoggedIn = false;
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frm = new frmAddEditStudent(-1);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAllStudents frm = new frmAllStudents();
            panel1.Visible = true;
            frm.ShowDialog();
            panel1.Visible = false;

        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            
           


        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllStudents frm = new frmAllStudents();
            panel1.Visible = true;
            menuStrip1.Visible = false;
            frm.ShowDialog();
            panel1.Visible = false;
            menuStrip1.Visible = true;

        }

        


        private void studentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditGroup frm = new frmAddEditGroup();
            frm.ShowDialog();
        }

        private void tTeachers_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmAddEditPerson frm = new frmAddEditPerson(-1);    
            frm.ShowDialog();
        }

        private void tCourses_Click(object sender, EventArgs e)
        {
            
        }

        private void tSections_Click(object sender, EventArgs e)
        {
            
        }

        private void tUsers_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tSettings_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddUser = new frmAddEditUser(-1);
            frmAddUser.ShowDialog();
        }

        private void addNewTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTeachers frmAddEditTeachers = new frmAddEditTeachers(-1);
            frmAddEditTeachers.ShowDialog();
        }

        private void StudentsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllStudents frm = new frmAllStudents();

            panel1.Visible = true;
            menuStrip1.Visible = false;
            frm.ShowDialog();
            panel1.Visible = false;
            menuStrip1.Visible = true;
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frmAddEditStudent = new frmAddEditStudent(-1);
            frmAddEditStudent.ShowDialog();
        }

        private void updateStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentInfoWithFilter frm = new frmStudentInfoWithFilter();
            frm.ShowDialog();
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmAddEditCourse frmAddEditCourse = new frmAddEditCourse();
            frmAddEditCourse.ShowDialog();
        }

        private void coursesManagemantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCoursesManagement frm = new frmCoursesManagement();
            frm.ShowDialog();
        }

        private void addNewSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSection frmAddEditSection = new frmAddEditSection();
            frmAddEditSection.ShowDialog();
        }

        private void sectionManagemantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSectionManegement frm = new frmSectionManegement();
            frm.ShowDialog();
        }
    }
}
