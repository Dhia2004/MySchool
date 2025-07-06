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
    public partial class frmAddEditTeachers: Form
    {
        private clsPerson _Person;
        private clsTeacher _Teacher;
        private int _TeacherID;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;

        public frmAddEditTeachers(int TeacherID)
        {
            InitializeComponent();

            _TeacherID = TeacherID;
            if (_TeacherID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
                Mode = enMode.Update;
        }


        public bool SaveDateUpdate()
        {
            bool IsDone = false;
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Teacher.PersonID = _Person.PersonID; // Assuming _Person is already set from the person selection control
                
                _Teacher.IsActive = chkIsActive.Checked; // Assuming chkIsActive is a CheckBox for user activation status

                _Teacher.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // Assuming CurrentUser is a static property in clsGlobalSettings




                if ((IsDone = _Teacher.Save()))

                    MessageBox.Show("User Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("User Updated Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return IsDone;

        }

        private void GetUserByID(int UserID)
        {
            _Teacher = clsUser.FindByUserID(UserID);
            if (_Teacher == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Populate the form fields with user data
            txtUserName.Text = _Teacher.UserName;
            txtOwnerPassword.Text = _Teacher.Password; // Assuming this is the field for password input
            txtConfirmPassword.Text = _Teacher.Password;
            chkIsActive.Checked = _Teacher.IsActive;
            // Additional fields can be populated here as needed
        }

        private void frmAddEditTeachers_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.onPersonSelected += (Person) => {
                _Person = Person;
                btnSave.Enabled = _Person != null; // Enable save button only if a person is selected
                pnlWarning.Visible = _Person == null; // Show warning panel if no person is selected
                tmWarning.Enabled = _Person == null; // Start the timer to hide the warning panel if no person is selected
                //pnlAccountInformation.Enabled = _Person != null; // Show account information panel only if a person is selected

            };
            ctrlPersonInfoWithFilter1.onPersonNotFound += () =>
            {
                _Person = null;
                btnSave.Enabled = false; // Disable save button if no person is found
                pnlWarning.Visible = true; // Show warning panel if no person is found
                tmWarning.Enabled = true; // Start the timer to hide the warning panel


                //pnlAccountInformation.Enabled = false; // Hide account information panel if no person is found
            };

            //ctrlPersonInfoWithFilter1.InitializeCtrlPersonInfoWithFilter();

            if (Mode == enMode.Update)
            {
                lblMode.Text = "Update User Informations";
                lblUserID.Text = _TeacherID.ToString();
                GetUserByID(_TeacherID);
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_Teacher.PersonID);



                return;
            }
            _Teacher = new clsUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                Mode = enMode.Update;
                _TeacherID = _Teacher.UserID;
                lblUserID.Text = _Teacher.UserID.ToString();
                lblMode.Text = "Update user Informations";
                //IsUpdated = true;
                //GetPersonByID(_PersonID);
                return;

            }
        }

        private void tmWarning_Tick(object sender, EventArgs e)
        {
            pbAlarm.Visible = !pbAlarm.Visible; // Toggle the visibility of the alarm icon

        }
    }
}
