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

namespace MySchool
{
    public partial class frmEditStudentStatus: Form
    {
        private clsStudent Student;
        public event Action OnFormClosing;
        public frmEditStudentStatus(clsStudent Student)
        {
            InitializeComponent();
            this.Student = Student;
        }

        private void frmEditStudentStatus_Load(object sender, EventArgs e)
        {
            lblStudentID.Text = Student.StudentID.ToString();
            lblFullName.Text = Student.FullName();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            OnFormClosing?.Invoke();
            this.Close();
        }

        private void btnDesactivate_Click(object sender, EventArgs e)
        {
            Student.IsActive = false;
            Student.DeactivationReason = cbDeactivationReason.Text.Trim();
            if (Student.UpdateStudentStatus())
            {
                MessageBox.Show("The student status has been updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnFormClosing?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update the student status. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
