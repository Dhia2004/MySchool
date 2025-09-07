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

namespace MySchool
{
    public partial class ctrlSubscriptionInfo: UserControl
    {
        public clsSubscription Subscription;
        public ctrlSubscriptionInfo()
        {
            InitializeComponent();
        }

        private void ctrlSubscriptionInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetSubscriptionInfo(clsSubscription Subscription)
        {

            this.Subscription = Subscription;
            lblSubscriptionID.Text = Subscription.SubscriptionID.ToString();
            lblSubscriptionID.Text = Subscription.SubscriptionID.ToString();
            lblStudentFullName.Text = Subscription.Student.FullName();
            lblCourseID.Text = Subscription.CourseID.ToString();
            lblSubjectName.Text = clsSubject.FindByID(Subscription.CourseSection.Course.SubjectID).Name;
            lblLevel.Text = clsLevel.GetLevelByID(Subscription.CourseSection.Course.LevelID).Name;
            lblSectionName.Text = Subscription.CourseSection.Section.Name;
            lblGroupName.Text = Subscription.CourseSection.Group.Name;
            lblStatus.Text = Subscription.IsActive ? "Active" : "Inactive";
            lblStatus.ForeColor = Subscription.IsActive ? Color.Green : Color.Red;
            lblIsPaid.Text = Subscription.IsPaid ? "Paid" : "Not Paid";
            lblIsPaid.ForeColor = Subscription.IsPaid ? Color.Green : Color.Red;







        }
    }
}
