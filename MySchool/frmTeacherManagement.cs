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
using static System.Collections.Specialized.BitVector32;

namespace MySchool
{
    public partial class frmTeacherManagement: Form
    {
        public frmTeacherManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ctrlTeacherInfo TeacherInfo;
        List<clsTeacher> Teachers = new List<clsTeacher>();

        private void UpdateTeachersList()
        {
            flpTeacherList.Controls.Clear();
            Teachers = clsTeacher.fetchTeachersBatch(Convert.ToInt32(lblPageNumber.Tag));
            foreach (var Course in Teachers)
            {
                ctrlTeacherInfo newCard = new ctrlTeacherInfo();
                newCard.MouseEnter += (s, e) => TeacherInfo = (ctrlTeacherInfo)s;
                newCard.SetSectionInfo(Course);
                flpTeacherList.Controls.Add(newCard);
            }
        }

        private void frmTeacherManagement_Load(object sender, EventArgs e)
        {
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateTeachersList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTeacherInfo frm = new frmTeacherInfo(TeacherInfo.Teacher);
            frm.ShowDialog();
            UpdateTeachersList(); // Refresh the list after viewing details
        }

        private void btnAddNewTeacher_Click(object sender, EventArgs e)
        {
            frmAddEditTeachers frmAddEditTeachers = new frmAddEditTeachers(-1);
            frmAddEditTeachers.ShowDialog();
            UpdateTeachersList(); // Refresh the list after adding a new teacher
        }
    }
}
