using System;
using PSMS_BusinessLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.Properties;

namespace MySchool
{
    public partial class frmSchoolConfig: Form
    {
        private clsSchoolInfo SchoolInfo;
        private clsPerson OwnerInfo;
        private clsUser OwnerAccount;


        public frmSchoolConfig()
        {
            InitializeComponent();
            SchoolInfo = new clsSchoolInfo();
            OwnerInfo = new clsPerson();
            OwnerAccount = new clsUser();
        }

        private void frmSchoolConfig_Load(object sender, EventArgs e)
        {
            pnlSchoolInfo.Visible = true;
            pnlOwnerInfo.Visible = false;
            pnlOwnerAccount.Visible = false;
            btnPage1Next.Enabled = false;
            btnPage2Next.Enabled = false;
            btnSaveInfo.Enabled = false;
            l_lblRemoveImage.Visible = false;
            ll_RemoveLink.Visible = false;
        }


        private bool SetSchoolInfo()
        {
            SchoolInfo.SchoolName = txtSchoolName.Text;
            SchoolInfo.OwnerID = OwnerInfo.PersonID;
            SchoolInfo.SchoolFix = txtFixNumber.Text.ToString();
            SchoolInfo.SecondaryFix = txtSecondaryFix.Text.ToString();
            SchoolInfo.SchoolEmail = txtSchoolEmail.Text.ToString();
            SchoolInfo.Address = txtSchoolAddress.Text.ToString();
            SchoolInfo.SchoolEstablishedYear = dtpEstablishedYear.Value;
            SchoolInfo.LogoPath = pbSchoolLogo.ImageLocation == null ? "" : pbPersonImage.ImageLocation.ToString();
            SchoolInfo.Descreption = txtSchoolDescreption.Text.ToString();

            return SchoolInfo.Save();



        }
        private bool SetOwnerInfo()
        {
            OwnerInfo.NationalID = txtNationalID.Text.ToString();
            OwnerInfo.FirstName = txtFirstName.Text.ToString();
            OwnerInfo.LastName = txtLastName.Text.ToString();
            OwnerInfo.DateOfBirth = dtpBirthDate.Value;
            if (rbMale.Checked)
                OwnerInfo.Gender = 'M';
            else
                OwnerInfo.Gender = 'F';

            OwnerInfo.Address = txtAddress.Text.ToString();
            OwnerInfo.JoinDate = DateTime.Now;
            OwnerInfo.PhoneNumber = txtPhone.Text.ToString();
            OwnerInfo.Email = txtEmail.Text.ToString();
            OwnerInfo.ImagePath = pbPersonImage.ImageLocation == null? "": pbPersonImage.ImageLocation.ToString();
            OwnerInfo.CreatedByUserID = -1;

            return OwnerInfo.Save();


        }

        private bool SetOwnerAccount()
        {
            OwnerAccount.UserName = txtOwnerEmail.Text.ToString();
            OwnerAccount.Password = txtConfirmPassword.Text.ToString();
            OwnerAccount.PersonID = OwnerInfo.PersonID;
            OwnerAccount.Permessions = 0;
            OwnerAccount.CreatedByUserID = -1;
            OwnerAccount.IsActive = true;
            return OwnerAccount.Save();
        }

        private void Save()
        {
            if (SetOwnerInfo())
            {
                if (SetSchoolInfo())
                {
                    if (SetOwnerAccount())
                    {
                        MessageBox.Show("All Informations are saved Succesfully");
                        clsGlobalSettings.ConfigurationSucc = true;
                        this.Close();
                    }
                       
                    else
                        MessageBox.Show("Error in Saving Owner Account");
                }

                else
                    MessageBox.Show("Error in Saving School Information");
                   
            }
            else
                MessageBox.Show("Error in Saving Owner Information");



        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void IsAllFieldsFilled(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSchoolName.Text) ||
                string.IsNullOrEmpty(txtSchoolEmail.Text) ||
                string.IsNullOrEmpty(txtFixNumber.Text) ||
                string.IsNullOrEmpty(txtSchoolAddress.Text))

                btnPage1Next.Enabled = false;

            else
                btnPage1Next.Enabled = true;
        }

        private void IsAllOwnerFieldsFilled(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtNationalID.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))

                btnPage2Next.Enabled = false;

            else
                btnPage2Next.Enabled = true;
        }

        private void IsAllAccInfoFieldsFilled(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOwnerEmail.Text) ||
                string.IsNullOrEmpty(txtOwnerPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text))

                btnSaveInfo.Enabled = false;

            else
                btnSaveInfo.Enabled = true;
        }

        
        private void btnPage1Next_Click(object sender, EventArgs e)
        {
            pnlSchoolInfo.Visible = false;
            pnlOwnerInfo.Visible = true;
            lblPageName.Text = "Owner Informations";
            lblPageNumber.Text = "2/3";
        }

        private void btnPage2Next_Click(object sender, EventArgs e)
        {
            pnlOwnerInfo.Visible = false;
            pnlOwnerAccount.Visible = true;
            lblPageName.Text = "Owner Account";
            lblPageNumber.Text = "3/3";
        }

        private void btnPage2Back_Click(object sender, EventArgs e)
        {
            pnlOwnerInfo.Visible = false;
            pnlSchoolInfo.Visible = true;
            lblPageName.Text = "School Informations";
            lblPageNumber.Text = "1/3";
        }

        private void btnPage3Back_Click(object sender, EventArgs e)
        {
            pnlOwnerAccount.Visible = false;
            pnlOwnerInfo.Visible = true;
            lblPageName.Text = "Owner Inforamtions";
            lblPageNumber.Text = "2/3";
        }

        private void l_lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Select Image";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

                if (openFileDialog1.FileName != "")
                {
                    pbSchoolLogo.Load(openFileDialog1.FileName);
                    l_lblRemoveImage.Visible = true;
                }

        }

        private void l_lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbSchoolLogo.ImageLocation = null;
            l_lblRemoveImage.Visible = false;
        }

        private void ll_SetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Select Image";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

                if (openFileDialog1.FileName != "")
                {
                    pbPersonImage.Load(openFileDialog1.FileName);
                    ll_RemoveLink.Visible = true;
                }
        }

        private void ll_RemoveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            ll_RemoveLink.Visible = false;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
