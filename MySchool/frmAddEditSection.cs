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
    public partial class frmAddEditSection: Form
    {

        clsSection Section;

        enum enMode
        {
            Add = 1,
            Update = 2
        }
        private enMode Mode;

        public frmAddEditSection(int SectionID = -1)
        {
            InitializeComponent();
            if (SectionID == -1)
            {
                Mode = enMode.Add;
                Section = new clsSection();
            }
            else
            {
                Mode = enMode.Update;
                Section = clsSection.GetSectionByID(SectionID);
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditSection_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                this.Text = "Update Section";
                lblMode.Text = "Update Section";
                lblSectionID.Text = Section.SectionID.ToString();
                txtName.Text = Section.Name;
                txtDescription.Text = Section.Description;
                nudSeats.Value = Section.NumberOfSeat;
                return;
            }

            this.Text = "Add New Section";
        }


        public bool SaveDateUpdate()
        {
            
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Section.Name = txtName.Text.Trim();
                Section.Description = txtDescription.Text.Trim();
                Section.NumberOfSeat = (int)nudSeats.Value;
                Section.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // Assuming CurrentUser is set in your application context

                if ((Section.Save()))
                {
                    MessageBox.Show("Section Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }



                MessageBox.Show("Section Updated Failed", "Oops..",
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

                this.Text = "Update Section";
                lblMode.Text = "Update Section";
                lblSectionID.Text = Section.SectionID.ToString();

                return;

            }
        }
    }
}
