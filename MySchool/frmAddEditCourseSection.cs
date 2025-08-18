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

namespace MySchool
{
    public partial class frmAddEditCourseSection: Form
    {
        clsCourseSection CourseSection;
        clsCourse Course;
        clsTeacher Teacher;
        clsSubject Subject;
        clsLevel Level;
        clsSection Section;
        clsGroup Group;
        // Constructor
        public frmAddEditCourseSection()
        {
            InitializeComponent();
            CourseSection = new clsCourseSection(); // Initialize a new CourseSection object
        }

        private void frmAddEditCourseSection_Load(object sender, EventArgs e)
        {
            pnlFirst.BringToFront(); // Ensure the first panel is in front when the form loads
            pnlSecond.SendToBack(); // Ensure the second panel is behind the first panel
            lblUser.Text = clsGlobalSettings.CurrentUser.UserName; // Display the current user's name
            List<clsLevel> Levels = clsLevel.GetAllLevelsAsObjects();
            foreach (clsLevel level in Levels)
            {
                cbLevels.Items.Add(level.Name);
            }

            List<clsSection> Sections = clsSection.GetAllSectionsAsObjects();
            foreach (clsSection Section in Sections)
            {
                cbSections.Items.Add(Section.Name);
            }
            cbGroup.Enabled = false; // Disable group selection initially
            cbDays.Items.Add("Saturday");
            cbDays.Items.Add("Sunday");
            cbDays.Items.Add("Monday");
            cbDays.Items.Add("Tuesday");
            cbDays.Items.Add("Wednesday");
            cbDays.Items.Add("Thursday");
            cbDays.Items.Add("Friday");

            cbDays.Enabled = false; // Disable day selection initially
            txtTimeStart.Enabled = false; // Disable time selection initially
            txtTimeEnd.Enabled = false; // Disable time selection initially

        }

        private void cbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLevel.Text = cbLevels.Text; // Update the label to show the selected level
            List<clsCourse> Courses = clsCourse.GetAllCoursesAsObjectsByLevel(clsLevel.FindByName(cbLevels.Text).Level_ID);
            flpCoursesList.Controls.Clear();

            if (Courses == null || Courses.Count == 0)
            {
                MessageBox.Show("No courses found for the selected level.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flpCoursesList.Controls.Clear(); // Clear the flow layout panel if no courses are found
                return;
            }
            foreach (clsCourse Course in Courses)
            {
                
                    ctrlCourseMiniCard newCard = new ctrlCourseMiniCard();
                    newCard.OnCourseSelected += (_Course) =>
                    {
                        this.Course = _Course;
                        lblSubject.Text = clsSubject.FindByID(_Course.SubjectID).Name;
                        lblTeacher.Text = clsTeacher.FindByTeacherID(_Course.TeacherID).Person.FullName();
                        lblNumberOfSeasson.Text = _Course.TotalSessions.ToString();
                        pnlFirst.Visible = false; // Hide the first panel when a subject is selected
                        pnlSecond.Visible = true; // Show the second panel to display teachers

                    };
                    newCard.SetTeacherInfo(Course);
                    flpCoursesList.Controls.Add(newCard);

            }
        }

        private void flpCoursesList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFirst_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlFirst.Visible = true; // Show the first panel to select a subject
            pnlSecond.Visible = false; // Hide the second panel with teacher selection
        }

        private void cbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGroup.Enabled = true; // Enable group selection when a section is selected
            Section = clsSection.GetSectionByName(cbSections.Text);
            List<clsGroup> Groups = clsGroup.GetAllGroupsBySectionID(Section.SectionID);
            cbGroup.Items.Clear();
            if (Groups == null || Groups.Count == 0)
            {
                MessageBox.Show("No groups found for the selected section.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGroup.Enabled = false; // Disable group selection if no groups are found
                return;
            }
            foreach (clsGroup Group in Groups)
            {
                cbGroup.Items.Add(Group.Name);
            }
            

        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbDays.Enabled = true; // Enable day selection when a group is selected
            Group = clsGroup.GetGroupByName(cbGroup.Text);
            lblSeats.Text = Group.MaxSeatsNumber.ToString();
        }

        private void cbDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDay.Text = cbDays.Text; // Update the label to show the selected day
            txtTimeStart.Enabled = true; // Enable time selection when a day is selected
        }

        private void txtTimeStart_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void txtTimeStart_MouseLeave(object sender, EventArgs e)
        {
            if (TimeSpan.TryParse(txtTimeStart.Text, out TimeSpan startTime))
            {
                txtTimeEnd.Enabled = true; // Enable end time selection when start time is valid
            }
            else
            {
                MessageBox.Show("Please enter a valid start time in HH:mm format.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimeEnd.Enabled = false; // Disable end time selection if start time is invalid
            }
        }

        private void txtTimeEnd_MouseLeave(object sender, EventArgs e)
        {

            if (TimeSpan.TryParse(txtTimeEnd.Text, out TimeSpan endTime))
            {
                // Check if end time is after start time
                if (TimeSpan.TryParse(txtTimeStart.Text, out TimeSpan startTime) && endTime > startTime)
                {
                    // Valid time range
                    lblTime.Text = $"{txtTimeStart.Text} - {txtTimeEnd.Text}";
                }
                else
                {
                    MessageBox.Show("End time must be after start time.", "Invalid Time Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblTime.Text = string.Empty; // Clear the label if the time range is invalid
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid end time in HH:mm format.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTime.Text = string.Empty; // Clear the label if the end time is invalid
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool SaveDateUpdate()
        {

            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Course == null || Section == null || Group == null || string.IsNullOrEmpty(lblDay.Text) ||
                    string.IsNullOrEmpty(txtTimeStart.Text) || string.IsNullOrEmpty(txtTimeEnd.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                CourseSection.CourseID = Course.CourseID;
                CourseSection.SectionID = Section.SectionID;
                CourseSection.GroupID = Group.GroupID;
                CourseSection.Day = lblDay.Text;
                CourseSection.Time = $"{txtTimeStart.Text} - {txtTimeEnd.Text}";
                CourseSection.NumberOfSeats = Group.MaxSeatsNumber;
                CourseSection.RemainingSeats = Group.MaxSeatsNumber; // Assuming all seats are available initially
                CourseSection.Notes = txtNotes.Text.Trim();
                CourseSection.Status = true; // Assuming the course section is active
                CourseSection.CreatedBuUserID = clsGlobalSettings.CurrentUser.UserID; // Set the current user as the creator
                if (CourseSection.Save())
                {
                    MessageBox.Show("Course Section Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Course Section Update Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            return false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                lblMode.Text = "Update course section Info";
                lblSectionID.Text = Course.CourseID.ToString();

                return;

            }
        }
    }
}
