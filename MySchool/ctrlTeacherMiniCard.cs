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
    public partial class ctrlTeacherMiniCard: UserControl
    {
        clsTeacher Teacher;
        public event Action <clsTeacher> OnTeacherSelected;
        public ctrlTeacherMiniCard()
        {
            InitializeComponent();
        }

        public void SetTeacherInfo(clsTeacher Teacher)
        {
            this.Teacher = Teacher;
            pbTeacherImage.Image = Teacher.Person.Gender == 'M' ? Resources.Male_512 : Resources.Female_512;
            lblFullName.Text = Teacher.Person.FullName();
            lblSubject.Text = clsSubject.FindByID(Teacher.SpecialityID).Name;

            if (Teacher.Person.ImagePath != "")
                pbTeacherImage.Load(Teacher.Person.ImagePath);
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OnTeacherSelected?.Invoke(Teacher);
        }
    }
}
