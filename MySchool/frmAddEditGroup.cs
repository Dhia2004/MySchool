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
    public partial class frmAddEditGroup: Form
    {
        private clsSection Section;

        private clsGroup Group;

        enum enMode
        {
            Add = 1,
            Update = 2
        }
        private enMode Mode;
        public frmAddEditGroup(int GroupID = -1)
        {
            InitializeComponent();
            if (GroupID == -1)
            {
                Mode = enMode.Add;
                Group = new clsGroup();
            }
            else
            {
                Mode = enMode.Update;
                Group = clsGroup.GetGroupByID(GroupID);
            }
        }

        public frmAddEditGroup(clsSection Section)
        {
            InitializeComponent();
            this.Section = Section;
            this.Group = new clsGroup();
            Mode = enMode.Add;
            
        }

        private void frmAddEditGroup_Load(object sender, EventArgs e)
        {
            List<clsSection> Sections = clsSection.GetAllSectionsAsObjects();
            foreach (clsSection Section in Sections)
            {
                cbSections.Items.Add(Section.Name);
            }

            if (Section != null)
            {
                cbSections.SelectedIndex = cbSections.FindString(Section.Name);
                cbSections.Enabled = false;
                pnlGroupInfo.Enabled = true;
                return;
            }

            if (Mode == enMode.Update)
            {
                
                lblMode.Text = "Update Group Info";
                lblGroupID.Text = Group.GroupID.ToString();
                txtName.Text = Group.Name;
                txtDescription.Text = Group.Description;
                nudSeats.Value = Group.MaxSeatsNumber;
                cbSections.SelectedIndex = cbSections.FindString(clsSection.GetSectionByID(Group.SectionID).Name);
                return;
            }
            

        }

        private void cbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlGroupInfo.Enabled = true;
            Section = clsSection.GetSectionByName(cbSections.Text);
            nudSeats.Maximum = Section.NumberOfSeat;
            nudSeats.Value = Section.NumberOfSeat;

        }

        private void pnlGroupInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool SaveDateUpdate()
        {

            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Group.Name = txtName.Text.Trim();
                Group.Description = txtDescription.Text.Trim();
                Group.MaxSeatsNumber = (int)nudSeats.Value;
                Group.SectionID = Section.SectionID;
                Group.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;


                if ((Group.Save()))
                {
                    MessageBox.Show("Group Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }



                MessageBox.Show("Group Updated Failed", "Oops..",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;




            }

            return false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                Mode = enMode.Update;

                this.Text = "Update Group";
                lblMode.Text = "Update Group";
                lblGroupID.Text = Group.GroupID.ToString();

                return;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
