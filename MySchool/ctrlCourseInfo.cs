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
    public partial class ctrlCourseInfo: UserControl
    {

        public clsCourse Course;
        public ctrlCourseInfo()
        {
            InitializeComponent();
        }

        private void ctrlCourseInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetCourseInfo(clsCourse Course)
        {
            this.Course = Course;
            lblCourseID.Text = Course.CourseID.ToString();
            lblSubject.Text = clsSubject.FindByID(Course.SubjectID).Name;
            lblLevel.Text = clsLevel.GetLevelByID(Course.LevelID).Name;
            lblTeacher.Text = clsTeacher.FindByTeacherID(Course.TeacherID).Person.FullName();
            lblSessions.Text = Course.TotalSessions.ToString();
            lblPrice.Text = Course.Price.ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(Course.CreatedByUserID).UserName;

        }
    }
}
