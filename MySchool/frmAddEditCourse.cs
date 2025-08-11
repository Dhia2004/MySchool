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
        clsCourse Course;
        clsTeacher Teacher;
        clsSubject Subject;

        
        public frmAddEditCourse()
        {
            InitializeComponent();
            Course = new clsCourse();

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
            Subject = clsSubject.FindByName(cbSubjects.Text);
            lblSubject.Text = cbSubjects.Text;
            pnlFirst.Visible = false; // Hide the first panel when a subject is selected
            pnlSecond.Visible = true; // Show the second panel to display teachers
           
            lblPageNumber.Text = "2/2";
            label10.Text = "Select a teacher for the subject:" + "\n" + cbSubjects.Text;
            FilterTeachersBySubject(Subject.SubjectID);

        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            //lblCurrentUser.Text = clsGlobalSettings.CurrentUser.UserName; // Display the current user's name
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
            lblLevel.Text = cbLevels.Text; // Update the label to show the selected level
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
            
            lblPageNumber.Text = "1/2";

        }

        private void nudSeassonsNumber_ValueChanged(object sender, EventArgs e)
        {
            lblNumberOfSeasson.Text =  nudSeassonsNumber.Value.ToString() + " Seasson(s)";
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            lblPrice.Text = nudPrice.Value.ToString() + " DA";
        }


        public bool SaveDateUpdate()
        {
            
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Course.SubjectID = Subject.SubjectID;
                Course.TeacherID = Teacher.TeacherID;
                Course.LevelID = clsLevel.FindByName(cbLevels.Text).Level_ID;
                Course.TotalSessions = (int)nudSeassonsNumber.Value;
                Course.Price = (float)nudPrice.Value;
                Course.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // TODO: Replace with actual user ID

                if ((Course.Save()))
                {
                    MessageBox.Show("Course Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }


              
                MessageBox.Show("Course Updated Failed", "Oops..",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
             
                   


            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                lblMode.Text = "Update course Info";
                lblCourseID.Text = Course.CourseID.ToString();

                return;

            }
        }
    }
}
