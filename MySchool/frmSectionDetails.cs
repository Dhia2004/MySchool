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
    public partial class frmSectionDetails : Form
    {
        private clsSection Section;
        public frmSectionDetails(clsSection Section)
        {
            InitializeComponent();
            this.Section = Section;
        }

        public void UpdateSectionDetails(clsSection Section)
        {
            this.Section = Section;
            lblSectionID.Text = Section.SectionID.ToString();
            lblSectionName.Text = Section.Name;
            lblDescription.Text = Section.Description;
            lblSeats.Text = Section.NumberOfSeat.ToString() + " Seat(s)";
            lblGroupsCount.Text = Section.GroupsCount.ToString() + " Group(s)";
        }

        private void frmSectionDetails_Load(object sender, EventArgs e)
        {
            UpdateSectionDetails(Section);


        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            frmAddEditSection frm = new frmAddEditSection(Section.SectionID);
            frm.ShowDialog();
            this.Close(); // Close the details form after editing

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this section?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return; // User chose not to delete
            }
            if (clsSection.Delete(Section.SectionID))
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

        private void btnSectionGroups_Click(object sender, EventArgs e)
        {
            frmSectionGroups frm = new frmSectionGroups(Section);
            frm.ShowDialog();
            UpdateSectionDetails(clsSection.GetSectionByID(Section.SectionID)); // Refresh the section details after viewing groups

        }
    }
}
