using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.Properties;
using PSMS_BusinessLayer;

namespace MySchool
{
    public partial class ctrlCourseMiniCard: UserControl
    {

        clsCourse Course;
        public event Action<clsCourse> OnCourseSelected;
        public ctrlCourseMiniCard()
        {
            InitializeComponent();
        }

        
        public void SetTeacherInfo(clsCourse Course)
        {
            this.Course = Course;
            //pbTeacherImage.Image = Course.Person.Gender == 'M' ? Resources.Male_512 : Resources.Female_512;
            lblCourseName.Text = clsSubject.FindByID(Course.SubjectID).Name;
            lblTeacherName.Text = clsTeacher.FindByTeacherID(Course.TeacherID).Person.FullName();
            pbTeacherImage.Load(clsSubject.FindByID(Course.SubjectID).ImagePath);
            //if (Course.Person.ImagePath != "")
            //    pbTeacherImage.Load(Course.Person.ImagePath);

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
        }

        private void ctrlCourseMiniCard_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            OnCourseSelected?.Invoke(Course);
        }
    }
}
