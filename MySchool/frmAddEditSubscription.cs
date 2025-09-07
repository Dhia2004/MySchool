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
            ctrlStudentInfoWithFilter1.onStudentSelected += (s) =>
            {
                this.Student = s;
                lblStudentFullName.Text = s.FullName();
                List<clsSubject> Subjects = clsSubject.GetAllSubjects();
                cbSubjects.Items.Clear();
                foreach (clsSubject subject in Subjects)
                {
                    if ((subject.TargetedLevels & clsLevel.GetLevelByID(Student.LevelID).LevelCode) == clsLevel.GetLevelByID(Student.LevelID).LevelCode)              // Check if the level is targeted by the subject
                    {
                        cbSubjects.Items.Add(subject.Name);
                    }
                }
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
