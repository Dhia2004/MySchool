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
using System.Xml.Linq;
using static PSMS_BusinessLayer.clsCourseSection;
using static System.Collections.Specialized.BitVector32;

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
            Subscription = new clsSubscription();


        }

        private void ResetForm()
        {
            btnSave.Enabled = false;
            Student = null;
            Subject = null;
            Level = null;
            CourseSection = null;
            Subscription = null;
            cbSubjects.Items.Clear();
            cbSubjects.Text = string.Empty;
            lblStudentFullName.Text = "[????]";
            lblLevel.Text = "[????]";
            lblSubjectName.Text = "[????]";
            lblCourseID.Text = "[????]";
            lblTeacher.Text = "[????]";
            lblSection.Text = "[????]";
            lblGroup.Text = "[????]";
            lblDay.Text = "[????]";
            lblTime.Text = "[????]";
            lblTotalSeassons.Text = "[????]";
            lblPrice.Text = "[????]";
            chkIsPaid.Checked = false;
            txtNotes.Text = "[????]";
            flpCoursesSectionsList.Controls.Clear();
            pnlSectionAlarm.Visible = true;
            pnlSectionAlarm.BringToFront();
            timer2.Start();
            cbSubjects.Enabled = false;
        }

        private void frmAddEditSubscription_Load(object sender, EventArgs e)
        {
            lblStartDate.Text = DateTime.Now.ToShortDateString();
            lblEndDate.Text = DateTime.Now.AddDays(40).ToShortDateString();
            lblIsPaid.Text = chkIsPaid.Checked? "Yes":"No";
            lblIsPaid.ForeColor = chkIsPaid.Checked ? Color.Green : Color.Red;
            pnlSectionAlarm.Visible = true;
            pnlSectionAlarm.BringToFront();

            timer2.Start();
            cbSubjects.Enabled = false;
            ctrlStudentInfoWithFilter1.onStudentSelected += (s) =>
            {
                this.Student = s;
                if (Student.IsActive)
                {
                    cbSubjects.Enabled = true;
                    pnlAlert.Visible = false;
                    pnlAlert.SendToBack();
                    timer1.Stop();
                    Level = clsLevel.GetLevelByID(Student.LevelID);
                    lblStudentFullName.Text = s.FullName();
                    lblLevel.Text = Level.Name;
                    List<clsSubject> Subjects = clsSubject.GetAllSubjects();
                    cbSubjects.Items.Clear();
                    Level = clsLevel.GetLevelByID(Student.LevelID);
                    foreach (clsSubject subject in Subjects)
                    {
                        if ((subject.TargetedLevels & Level.LevelCode) == Level.LevelCode)              // Check if the level is targeted by the subject
                        {
                            cbSubjects.Items.Add(subject.Name);
                        }
                    }
                }
                else
                {
                    ResetForm();
                    pnlAlert.Visible = true;
                    pnlAlert.BringToFront();
                    timer1.Start();
                    MessageBox.Show("The selected student is not active. Please select an active student.", "Inactive Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }

            };
            ctrlStudentInfoWithFilter1.onStudentNotFound += () =>
            {
                ResetForm();
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
                cbSubjects.Text = string.Empty;

            }
            else
            {
                pnlSectionAlarm.Visible = false;
                pnlSectionAlarm.SendToBack();
                timer2.Stop();
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
                        btnSave.Enabled = true;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            pbWarning.Visible = !pbWarning.Visible;
        }

        public bool SaveDateUpdate()
        {

            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Subscription.StudentID = Student.StudentID;
                Subscription.CourseID = CourseSection.CourseID;
                Subscription.CourseSec_ID = CourseSection.CourseSecID;
                Subscription.TotalSessions = CourseSection.Course.TotalSessions;
                Subscription.RemainingSessions = CourseSection.Course.TotalSessions;
                Subscription.StartDate = DateTime.Now;
                Subscription.EndDate = DateTime.Now.AddDays(40);
                Subscription.IsActive = true;
                Subscription.Notes = txtNotes.Text.Trim();
                Subscription.IsPaid = chkIsPaid.Checked;
                Subscription.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // Assuming CurrentUser is set in your application context


                if ((Subscription.Save()))
                {
                    CourseSection.OccupySeat();
                    MessageBox.Show("Subscription Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }



                MessageBox.Show("Subscription Updated Failed", "Oops..",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;




            }

            return false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                
                clsBarCode.GenerateStudentSubscriptionBarCode(Student.StudentID, Subscription.SubscriptionID, Student.FullName(), Subject.Name, CourseSection.Section.Name,CourseSection.Group.Name, $"{clsGlobalSettings.BarCodeFilesPath}\\Student_{Student.StudentID}_Subscription_{Subscription.SubscriptionID}.pdf");
                this.Text = "Update Subscription";
                lblMode.Text = "Update Subscription";
                lblSubcriptionID.Text = Subscription.SubscriptionID.ToString();

                return;

            }
        }
    }
}
