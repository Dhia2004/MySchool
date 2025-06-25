using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSMS_BusinessLayer;
using MySchool.Properties;

namespace MySchool
{
    public partial class ctrlStudentMiniCard: UserControl
    {
        public ctrlStudentMiniCard()
        {
            InitializeComponent();
        }

        public delegate void delStudentSelected(clsStudent student);
        public event delStudentSelected StudentSelected;
        public event Action OnBackToForm;
        public event Action onSubFormOpened;
        public event Action onSubFormClosed;
        private clsStudent Student;

        public void SetStudentInfo(clsStudent student)
        {
            this.Student = student;
            pbStudentImage.Image = student.Gender == 'M' ? Resources.Male_512:Resources.Female_512;
            lblFullName.Text = student.FullName();
            lblGender.Text = student.Gender == 'M'? "Male" : "Female";
            lblGender.ForeColor = student.Gender == 'M' ? Color.Blue:Color.Purple;
            if (student.ImagePath != "")
                pbStudentImage.Load(student.ImagePath);
            lblBirthDate.Text = student.DateOfBirth.ToShortDateString();
           

            if (student.IsActive)
            {
                lblStatus.Text = "Active";
                lblStatus.ForeColor = Color.Green;
                //pbEditStatus.Image = Resources.desactivate;
            }
            else
            {
                lblStatus.Text = "Inactive";
                lblStatus.ForeColor = Color.Red;
                //pbEditStatus.Image = Resources.Activate;
            }
        }

        private void btnMoreDetails_Click(object sender, EventArgs e)
        {
            StudentSelected?.Invoke(Student);

        }

        private void pbEditStudent_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frm = new frmAddEditStudent(Student.StudentID);
            onSubFormOpened?.Invoke();
            frm.DataBackToMiniCard += () => OnBackToForm?.Invoke();
            frm.ONbtnCloseClicked += () => onSubFormClosed?.Invoke();
            frm.ShowDialog();
        }

        private void pbDeleteStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbEditStatus_Click(object sender, EventArgs e)
        {
            

            if (Student.IsActive)
            {
                onSubFormOpened?.Invoke();
                frmEditStudentStatus frm = new frmEditStudentStatus(Student);
                frm.OnFormClosing += () => onSubFormClosed?.Invoke();
                frm.ShowDialog();
                //Student.IsActive = false;
                //lblStatus.Text = "Inactive";
                //lblStatus.ForeColor = Color.Red;
                //pbEditStatus.Image = Resources.Activate;
            }
            else
            {

                //Student.IsActive = true;
                //lblStatus.Text = "Active";
                //lblStatus.ForeColor = Color.Green;
                //pbEditStatus.Image = Resources.desactivate;
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frm = new frmAddEditStudent(Student.StudentID);
            onSubFormOpened?.Invoke();
            frm.DataBackToMiniCard += () => OnBackToForm?.Invoke();
            frm.ONbtnCloseClicked += () => onSubFormClosed?.Invoke();
            frm.ShowDialog();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditStutus_Click(object sender, EventArgs e)
        {
            if (Student.IsActive)
            {
                onSubFormOpened?.Invoke();
                frmEditStudentStatus frm = new frmEditStudentStatus(Student);
                frm.OnFormClosing += () => onSubFormClosed?.Invoke();
                frm.ShowDialog();
                //Student.IsActive = false;
                //lblStatus.Text = "Inactive";
                //lblStatus.ForeColor = Color.Red;
                //pbEditStatus.Image = Resources.Activate;
            }
            else
            {

                //Student.IsActive = true;
                //lblStatus.Text = "Active";
                //lblStatus.ForeColor = Color.Green;
                //pbEditStatus.Image = Resources.desactivate;
            }
        }
    }
}
