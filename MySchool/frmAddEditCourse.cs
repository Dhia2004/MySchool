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
            pnlFirst.Visible = false; // Hide the first panel when a subject is selected
            pnlSecond.Visible = true; // Show the second panel to display teachers
            label10.Text = "Select a teacher for the subject:" + "\n" + cbSubjects.Text;
            FilterTeachersBySubject(SubjectID);

        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            List<clsLevel> Levels = clsLevel.GetAllLevelsAsObjects();
            foreach (clsLevel level in Levels)
            {
                cbLevels.Items.Add(level.Name);
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<clsSubject> Subjects = clsSubject.GetAllSubjects();
            cbSubjects.Items.Clear();
            foreach (clsSubject subject in Subjects)
            {
                if ((subject.TargetedLevels & clsLevel.FindByName(cbLevels.Text).LevelCode) == clsLevel.FindByName(cbLevels.Text).LevelCode)              // Check if the level is targeted by the subject
                {
                    cbSubjects.Items.Add(subject.Name);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlFirst.Visible = true; // Show the first panel to select a subject
            pnlSecond.Visible = false; // Hide the second panel with teacher selection

        }
    }
}
