using MySchool.Properties;
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
    public partial class frmAddEditPerson: Form
    {
        private bool IsUpdated = false;
        private int _PersonID;

        private clsPerson _Person;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;

        public event Action<clsStudent> DataBackToCard;
        public event Action DataBackToMiniCard;


        public delegate void btnCloseHandel();
        public event btnCloseHandel ONbtnCloseClicked;

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            if (PersonID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
                Mode = enMode.Update;
        }

       

        

        





        

        public void InitializefrmAddUpdatePerson()
        {
            //DateTime MaxDate = new DateTime(DateTime.Now.Year-18,DateTime.Now.Month, DateTime.Now.Day) ;
            _Person = new clsPerson();
            rbMale.Checked = true;
            // pbImagePerson.Image = Resources.Male_512;


            if (pbPersonImage.ImageLocation != null)
            {
                ll_SetLink.Visible = false;
                ll_RemoveLink.Visible = true;
            }
            else
            {
                ll_SetLink.Visible = true;
                ll_RemoveLink.Visible = false;
            }

        }



        private void rbGendor_ChekedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
            {
                //if (((RadioButton)sender).Tag.ToString() == "Woman")
                //    pbPersonImage.Image = Resources.Female_512;
                //else
                //    pbPersonImage.Image = Resources.Male_512;
            }


        }


        public void GetPersonByID(int PersonID)
        {
            _Person = clsPerson.FindByID(PersonID);
            if (_Person != null)
            {
                txtFirstName.Text = _Person.FirstName;
                txtLastName.Text = _Person.LastName;

                if (_Person.Gender == 'M')
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;


                txtAddress.Text = _Person.Address;
                dtpBirthDate.Value = _Person.DateOfBirth;
                txtPhone.Text = _Person.PhoneNumber;


                if (_Person.ImagePath != "")
                {
                    pbPersonImage.Load(_Person.ImagePath);
                    ll_RemoveLink.Visible = true;


                }


                else
                {
                    ll_RemoveLink.Visible = false;
                    ll_SetLink.Visible = true;
                }


                
            }
        }

        public bool SaveDateUpdate()
        {
            bool IsDone = false;
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Person.FirstName = txtFirstName.Text;
                _Person.LastName = txtLastName.Text;
                _Person.NationalID = txtNationalID.Text; // Assuming NationalID is a property of clsStudent
                _Person.DateOfBirth = dtpBirthDate.Value;
                _Person.Gender = rbMale.Checked ? 'M' : 'F';
                _Person.Address = txtAddress.Text;
                _Person.PhoneNumber = txtPhone.Text;
                _Person.Email = txtEmail.Text; // Assuming Email is a property of clsPerson
                _Person.JoinDate = DateTime.Now;
                _Person.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // TODO: Replace with actual user ID
                

                _Person.ImagePath = pbPersonImage.ImageLocation == null ? "" : pbPersonImage.ImageLocation;
                if ((IsDone = _Person.Save()))

                    MessageBox.Show("Person Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Person Updated Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return IsDone;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                Mode = enMode.Update;
                _PersonID = _Person.PersonID;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblMode.Text = "Update Person Informations";
                IsUpdated = true;
                //GetPersonByID(_PersonID);
                return;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (IsUpdated)
            {
                //DataBackToCard?.Invoke(_Person);
                DataBackToMiniCard?.Invoke();
                ONbtnCloseClicked?.Invoke();
            }
            ONbtnCloseClicked?.Invoke();
            this.Close();
        }

        private void l_lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void l_lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }




        





        private void ll_SetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Select Image";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    pbPersonImage.Load(openFileDialog1.FileName);
                    ll_RemoveLink.Visible = true;
                }

            }
        }

        private void ll_RemoveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            //if (_Person.Gender == 'M')
            //    pbPersonImage.Image = Resources.Male_512;
            //else
            //    pbPersonImage.Image = Resources.Female_512;
        }



        private void pbExit_Click(object sender, EventArgs e)
        {
            CloseForm();


        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            dtpBirthDate.MaxDate = (DateTime.Now).AddYears(-18);

            if (Mode == enMode.Update)
            {
                lblPersonID.Text = _PersonID.ToString();
                lblMode.Text = "Update Person Informations";
                GetPersonByID(_PersonID);
                return;
            }

            InitializefrmAddUpdatePerson();
        }
    }
}
