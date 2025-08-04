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
    public partial class frmCoursesManagement: Form
    {

        ctrlCourseInfo ctrlCourseInfo;
        public frmCoursesManagement()
        {
            InitializeComponent();
        }
        List<clsCourse> Courses = new List<clsCourse>();

        private void UpdateCoursesList()
        {
            flpCourseList.Controls.Clear();
            Courses = clsCourse.fetchCoursesBatch(Convert.ToInt32(lblPageNumber.Tag));
            foreach (var Course in Courses)
            {
                ctrlCourseInfo newCard = new ctrlCourseInfo();
                newCard.MouseEnter += (s, e) => ctrlCourseInfo = (ctrlCourseInfo)s;
                newCard.SetCourseInfo(Course);
                flpCourseList.Controls.Add(newCard);
            }
        }
        private void frmCoursesManagement_Load(object sender, EventArgs e)
        {
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateCoursesList();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) + 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            pbBack.Enabled = true;
            UpdateCoursesList();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) - 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            if (Convert.ToInt32(lblPageNumber.Tag) == 1)
            {
                pbBack.Enabled = false;
            }
            UpdateCoursesList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePrice frm = new frmUpdatePrice(ctrlCourseInfo.Course);
            frm.ShowDialog();
        }

        private void btnAddNewCourse_Click(object sender, EventArgs e)
        {
            frmAddEditCourse frm = new frmAddEditCourse();
            frm.ShowDialog();
            UpdateCoursesList();

        }
    }
}
