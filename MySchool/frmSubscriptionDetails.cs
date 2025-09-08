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
    public partial class frmSubscriptionDetails: Form
    {
        private clsSubscription Subscription;
        public frmSubscriptionDetails(clsSubscription subscription)
        {
            InitializeComponent();
            Subscription = subscription;
        }

        public void UpdateSubscriptionDetails(clsSubscription Subscription)
        {
            lblSubscriptionID.Text = Subscription.SubscriptionID.ToString();
            lblStudentID.Text = Subscription.StudentID.ToString();
            lblFullName.Text = Subscription.Student.FullName();
            lblCourseID.Text = Subscription.CourseSection.Course.CourseID.ToString();
            lblSubject.Text = clsSubject.FindByID(Subscription.CourseSection.Course.SubjectID).Name;
            lblSection.Text = Subscription.CourseSection.Section.Name;
            lblGroup.Text = Subscription.CourseSection.Group.Name;
            lblDay.Text = Subscription.CourseSection.Day;
            lblTime.Text = Subscription.CourseSection.Time;
            lblSessions.Text = Subscription.TotalSessions.ToString() + " Session(s)";
            lblRemaining.Text = Subscription.RemainingSessions.ToString() + " Session(s)";
            lblStartDate.Text = Subscription.StartDate.ToString("dd MMM yyyy");
            lblEndDate.Text = Subscription.EndDate == DateTime.MinValue ? "N/A" : Subscription.EndDate.ToString("dd MMM yyyy");
            lblStatus.Text = Subscription.IsActive ? "Active" : "Inactive";
            lblPaid.Text = Subscription.IsPaid ? "Paid" : "Not Paid";
            lblStatus.ForeColor = Subscription.IsActive ? Color.Green : Color.Red;
            lblPaid.ForeColor = Subscription.IsPaid ? Color.Green : Color.Red;
            lblNotes.Text = string.IsNullOrWhiteSpace(Subscription.Notes) ? "N/A" : Subscription.Notes;
            lblCreatedByUser.Text = clsUser.FindByUserID(Subscription.CreatedByUserID).UserName;


        }
        private void frmSubscriptionDetails_Load(object sender, EventArgs e)
        {
            UpdateSubscriptionDetails(Subscription);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCreatedByUser_Click(object sender, EventArgs e)
        {

        }
    }
}
