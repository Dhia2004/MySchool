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
            frmAllStudents frm = new frmAllStudents();

            panel1.Visible = true;
            menuStrip1.Visible = false;
            frm.ShowDialog();
            panel1.Visible = false;
            menuStrip1.Visible = true;


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tSections_Click(object sender, EventArgs e)
        {
            //    MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmPersonInfoWithFilter frm = new frmPersonInfoWithFilter();
            frm.ShowDialog();
        }

        private void tUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tSettings_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
