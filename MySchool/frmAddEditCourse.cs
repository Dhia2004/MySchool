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
    public partial class frmAddEditCourse: Form
    {
        clsTeacher Teacher;
        clsSubject Subject;
        public frmAddEditCourse()
        {
            InitializeComponent();
        }

        private void FilterTeachersBySubject(int SubjectID)
        {
            List<clsTeacher> Teachers = clsTeacher.GetAllTeachersBySubject(SubjectID);
            flowLayoutPanel1.Controls.Clear();
            if (Teachers == null || Teachers.Count == 0)
            {
                MessageBox.Show("No teachers found for the selected subject.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var Teacher in Teachers)
            {
                ctrlTeacherMiniCard newCard = new ctrlTeacherMiniCard();
                newCard.OnTeacherSelected += (_Teacher) => 
                {
                    this.Teacher = _Teacher;
                    lblTeacher.Text = _Teacher.Person.FullName();
                };
                newCard.SetTeacherInfo(Teacher);
                
                flowLayoutPanel1.Controls.Add(newCard);
            }

        }
        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SubjectID = clsSubject.FindByName(cbSubjects.Text).SubjectID;
            lblSubject.Text = cbSubjects.Text;
            FilterTeachersBySubject(SubjectID);

        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            List<clsSubject> subjects = clsSubject.GetAllSubjects();
            foreach (clsSubject subject in subjects)
            {
                cbSubjects.Items.Add(subject.Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
