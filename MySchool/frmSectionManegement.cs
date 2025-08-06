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
    public partial class frmSectionManegement: Form
    {
        public frmSectionManegement()
        {
            InitializeComponent();
        }

        private ctrlSectionInfo SectionInfo;
        List<clsSection> Sections = new List<clsSection>();

        private void UpdateCoursesList()
        {
            flpSectionsList.Controls.Clear();
            Sections = clsSection.fetchSectionsBatch(Convert.ToInt32(lblPageNumber.Tag));
            foreach (var Course in Sections)
            {
                ctrlSectionInfo newCard = new ctrlSectionInfo();
                newCard.MouseEnter += (s, e) => SectionInfo = (ctrlSectionInfo)s;
                newCard.SetSectionInfo(Course);
                flpSectionsList.Controls.Add(newCard);
            }
        }


        private void frmSectionManegement_Load(object sender, EventArgs e)
        {
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateCoursesList();
        }

        private void flpSectionsList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sectionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSectionDetails frm = new frmSectionDetails(SectionInfo.Section);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddEditSection frm = new frmAddEditSection();
            frm.ShowDialog();
            UpdateCoursesList();
        }

        private void editSectionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSection frm = new frmAddEditSection(SectionInfo.Section.SectionID);
            frm.ShowDialog();
            UpdateCoursesList();
        }

        private void deleteSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this section?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return; // User chose not to delete
            }
            if (clsSection.Delete(SectionInfo.Section.SectionID))
            {
                if (MessageBox.Show("Section Deleted Successfully", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close(); // Close the details form after deletion
                }

            }
            else
            {
                MessageBox.Show("Failed to delete section. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
