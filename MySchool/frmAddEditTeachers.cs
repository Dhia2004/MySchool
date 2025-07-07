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
  
                _Teacher.SpecialityID = clsSubject.FindByName(cbSubjects.SelectedItem.ToString()).SubjectID; // Assuming cbSubjects is a ComboBox for subject selection
                _Teacher.IsActive = chkIsActive.Checked; // Assuming chkIsActive is a CheckBox for user activation status
                _Teacher.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // Assuming CurrentUser is a static property in clsGlobalSettings




                if ((IsDone = _Teacher.Save()))

                    MessageBox.Show("Teacher Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Teacher Updated Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return IsDone;

        }

        private void GetTeacherByID(int TeacherID)
        {
            _Teacher = clsTeacher.FindByTeacherID(TeacherID);
            if (_Teacher == null)
            {
                MessageBox.Show("Teacher not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Populate the form fields with user data
            //lblPersonID.Text = _Teacher.PersonID.ToString();
            lblFullName.Text = _Teacher.Person.FullName(); // Assuming this is the field for password input
            cbSubjects.SelectedIndex = cbSubjects.FindString(clsSubject.FindByID(_Teacher.SpecialityID).Name);

            chkIsActive.Checked = _Teacher.IsActive;
            lblCreatedByUser.Text =  _Teacher.CreatedByUserID.ToString(); // Assuming this is the field for created by user ID
            // Additional fields can be populated here as needed
        }

        private void frmAddEditTeachers_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.onPersonSelected += (Person) => {
                _Person = Person;
                //lblPersonID.Text = _Person.PersonID.ToString(); // Display the selected person's ID
                lblFullName.Text = _Person.FullName(); // Display the selected person's full name

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

            List<clsSubject> subjects = clsSubject.GetAllSubjects();
            foreach(clsSubject subject in subjects)
            {
                cbSubjects.Items.Add(subject.Name);
            }
            lblCreatedByUser.Text = "- " + clsGlobalSettings.CurrentUser.UserName; // Assuming CurrentUser is a static property in clsGlobalSettings

            if (Mode == enMode.Update)
            {
                lblMode.Text = "Update User Informations";
                lblTeacherID.Text = _TeacherID.ToString();
                GetTeacherByID(_TeacherID);
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_Teacher.PersonID);



                return;
            }
            _Teacher = new clsTeacher();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveDateUpdate())
            {
                Mode = enMode.Update;
                _TeacherID = _Teacher.TeacherID;
                lblTeacherID.Text = _Teacher.TeacherID.ToString();
                lblMode.Text = "Update Teacher Informations";
                //IsUpdated = true;
                //GetPersonByID(_PersonID);
                return;

            }
        }

        private void tmWarning_Tick(object sender, EventArgs e)
        {
            pbAlarm.Visible = !pbAlarm.Visible; // Toggle the visibility of the alarm icon

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
