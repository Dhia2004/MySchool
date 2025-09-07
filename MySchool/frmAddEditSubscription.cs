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
    public partial class frmAddEditSubscription: Form
    {
        clsStudent Student;
        clsSubject Subject;
        clsLevel Level;
        clsCourseSection CourseSection;
        clsSubscription Subscription;

        public frmAddEditSubscription()
        {
            InitializeComponent();
            


        }

        private void frmAddEditSubscription_Load(object sender, EventArgs e)
        {
            lblStartDate.Text = DateTime.Now.ToShortDateString();
            lblIsPaid.Text = chkIsPaid.Checked? "Yes":"No";
            lblIsPaid.ForeColor = chkIsPaid.Checked ? Color.Green : Color.Red;
            ctrlStudentInfoWithFilter1.onStudentSelected += (s) =>
            {
                this.Student = s;
                if (Student.IsActive)
                {

                    pnlAlert.Visible = false;
                    pnlAlert.SendToBack();
                    timer1.Stop();
                    Level = clsLevel.GetLevelByID(Student.LevelID);
                    lblStudentFullName.Text = s.FullName();
                    lblLevel.Text = Level.Name;
                    List<clsSubject> Subjects = clsSubject.GetAllSubjects();
                    cbSubjects.Items.Clear();
                    foreach (clsSubject subject in Subjects)
                    {
                        if ((subject.TargetedLevels & clsLevel.GetLevelByID(Student.LevelID).LevelCode) == clsLevel.GetLevelByID(Student.LevelID).LevelCode)              // Check if the level is targeted by the subject
                        {
                            cbSubjects.Items.Add(subject.Name);
                        }
                    }
                }
                else
                {
                    pnlAlert.Visible = true;
                    pnlAlert.BringToFront();
                    timer1.Start();
                    MessageBox.Show("The selected student is not active. Please select an active student.", "Inactive Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Student = null;
                    lblStudentFullName.Text = string.Empty;
                    lblLevel.Text = string.Empty;
                    cbSubjects.Items.Clear();
                }

            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject = clsSubject.FindByName(cbSubjects.Text);
            if (clsSubscription.CheckExistingActiveSubscription(Student.StudentID, Subject.SubjectID))
            {

                MessageBox.Show("The selected student already has an active subscription for the selected subject.", "Active Subscription Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSubjects.SelectedIndex = -1;
                
            }
            else
            {
                lblSubjectName.Text = Subject.Name;
                List<clsCourse> Courses = clsCourse.GetAllCoursesBySubjectAndLevelAsObjects(Subject.SubjectID, Level.Level_ID);
                List<clsCourseSection> CoursesSection = new List<clsCourseSection>();
                foreach (var Course in Courses)
                {
                    List<clsCourseSection> s = clsCourseSection.GetAllCourseSectionsByCourseID(Course.CourseID);
                    if (s != null && s.Count > 0)
                    {
                        foreach (var cs in s)
                        {
                            CoursesSection.Add(cs);
                        }
                    }
                }

                flpCoursesSectionsList.Controls.Clear();
                foreach (var cs in CoursesSection)
                {
                    ctrlCourseSectionCard rb = new ctrlCourseSectionCard();
                    rb.OnCourseSectionSelected += (c) =>
                    {
                        this.CourseSection = c;
                        lblCourseID.Text = c.CourseID.ToString();
                        lblTeacher.Text = clsTeacher.FindByTeacherID(c.Course.TeacherID).Person.FullName();
                        lblSection.Text = c.Section.Name;
                        lblGroup.Text = c.Group.Name;
                        lblDay.Text = c.Day;
                        lblTime.Text = c.Time;
                        lblTotalSeassons.Text = c.Course.TotalSessions.ToString();
                        lblPrice.Text = c.Course.Price.ToString("F2");

                    };
                    rb.SetCourseSectionInfo(cs);

                    flpCoursesSectionsList.Controls.Add(rb);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbAlarm.Visible = !pbAlarm.Visible;
        }

        private void chkIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            lblIsPaid.Text = chkIsPaid.Checked? "Yes":"No";
            lblIsPaid.ForeColor = chkIsPaid.Checked ? Color.Green : Color.Red;
        }
    }
}
