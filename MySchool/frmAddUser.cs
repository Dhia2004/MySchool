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
    public partial class frmAddUser: Form
    {
        private clsPerson _Person;
        private clsUser _User;
        private int _UserID;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;

        public frmAddUser(int UserID)
        {
            InitializeComponent();

           

            _UserID = UserID;
            if (_UserID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
                Mode = enMode.Update;


            
        }

        private void btnGoToPermessions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool SaveDateUpdate()
        {
            bool IsDone = false;
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _User.UserName = txtUserName.Text;
                _User.Password = txtConfirmPassword.Text;
                _User.Permessions = 128; // Default permission for a new user, can be changed later
                _User.IsActive = chkIsActive.Checked; // Assuming chkIsActive is a CheckBox for user activation status
  
                _User.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // Assuming CurrentUser is a static property in clsGlobalSettings




                if ((IsDone = _User.Save()))

                    MessageBox.Show("User Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("User Updated Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return IsDone;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                Mode = enMode.Update;
                _UserID = _User.UserID;
                lblUserID.Text = _User.UserID.ToString();
                lblMode.Text = "Update user Informations";
                //IsUpdated = true;
                //GetPersonByID(_PersonID);
                return;

            }
        }

        private void GetUserByID(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Populate the form fields with user data
            txtUserName.Text = _User.UserName;
            txtOwnerPassword.Text = _User.Password; // Assuming this is the field for password input
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            // Additional fields can be populated here as needed
        }
        

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.onPersonSelected += (Person) => { 
                _Person = Person;
                btnSave.Enabled = _Person != null; // Enable save button only if a person is selected
                pnlAccountInformation.Enabled = _Person != null; // Show account information panel only if a person is selected

            };
            //ctrlPersonInfoWithFilter1.InitializeCtrlPersonInfoWithFilter();

            if (Mode == enMode.Update)
            {
                lblMode.Text = "Update User Informations";
                lblUserID.Text = _UserID.ToString();
                GetUserByID(_UserID);
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_User.PersonID);
                
                
                
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
