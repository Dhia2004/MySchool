using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace MySchool
{
    public partial class frmTeacherInfo: Form
    {
        clsTeacher Teacher;
        public frmTeacherInfo(clsTeacher Teacher)
        {
            InitializeComponent();
            this.Teacher = Teacher;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void UpdateTeacherDetails(clsTeacher Teacher)
        {

            this.Teacher = Teacher;
            lblTeacherID.Text = Teacher.TeacherID.ToString();
            lblPersonID.Text = Teacher.PersonID.ToString();
            lblFullName.Text = Teacher.Person.FullName();
            lblSpeciality.Text = clsSubject.FindByID(Teacher.SpecialityID).Name;
            lblStatus.Text = Teacher.IsActive ? "Active" : "Inactive";
            lblStatus.ForeColor = Teacher.IsActive ? Color.Green : Color.Red;
            lblCreatedByUser.Text = clsUser.FindByUserID(Teacher.CreatedByUserID).UserName;
        }
        private void frmTeacherInfo_Load(object sender, EventArgs e)
        {
            UpdateTeacherDetails(Teacher);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Teacher?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return; // User chose not to delete
            }
            //if (clsTeacher.Delete(Teacher.TeacherID))
            //{
            //    if (MessageBox.Show("Teacher Deleted Successfully", "Done",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //    {
            //        this.Close(); // Close the details form after deletion
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Failed to delete Teacher. Please try again.", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnShowPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(Teacher.PersonID);
            frm.ShowDialog();
            
        }
    }
}
