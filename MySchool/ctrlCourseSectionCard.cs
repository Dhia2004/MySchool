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
    public partial class ctrlCourseSectionCard: UserControl
    {
        public clsCourseSection CourseSection;
        public Action<clsCourseSection> OnCourseSectionSelected;
        public ctrlCourseSectionCard()
        {
            InitializeComponent();
        }

        private void ctrlCourseSectionCard_Load(object sender, EventArgs e)
        {

        }
        public void SetCourseSectionInfo(clsCourseSection CourseSection)
        {

            this.CourseSection = CourseSection;
            lblSectionName.Text = CourseSection.Section.Name;
            lblGroupName.Text = CourseSection.Group.Name;
            lblDay.Text = CourseSection.Day;
            lblTime.Text = CourseSection.Time;
            lblNumberOfSeats.Text = CourseSection.NumberOfSeats.ToString() + " ~ " + CourseSection.RemainingSeats.ToString();
            if (CourseSection.RemainingSeats != 0)
            {
                pnlAlarm.Visible = false;
            }
            else
            {
                btnSelect.Enabled = false;
                timer1.Start();
            }








        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlAlarm.Visible = !pnlAlarm.Visible;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OnCourseSectionSelected?.Invoke(this.CourseSection);
        }
    }
}
