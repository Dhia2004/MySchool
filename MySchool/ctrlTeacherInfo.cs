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
    public partial class ctrlTeacherInfo: UserControl
    {

        public clsTeacher Teacher;
        public ctrlTeacherInfo()
        {
            InitializeComponent();
        }

        private void ctrlTeacherInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetSectionInfo(clsTeacher Teacher)
        {

            this.Teacher = Teacher;
            lblTeacherID.Text = Teacher.TeacherID.ToString();
            lblPersonID.Text = Teacher.PersonID.ToString();
            lblName.Text = Teacher.Person.FullName();
            lblSubject.Text = clsSubject.FindByID(Teacher.SpecialityID).Name;
            lblStatus.Text = Teacher.IsActive ? "Active" : "Inactive";
            lblStatus.ForeColor = Teacher.IsActive ? Color.Green : Color.Red;
            lblCreatedByUser.Text = clsUser.FindByUserID(Teacher.CreatedByUserID).UserName;

        }
    }
}
