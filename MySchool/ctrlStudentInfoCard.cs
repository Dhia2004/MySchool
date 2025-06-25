using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySchool.Properties;
using PSMS_BusinessLayer;
using System.Media;

namespace MySchool
{
    public partial class ctrlStudentInfoCard: UserControl
    {

        public clsStudent Student;
        public enum enPanelMode
        {
            pnlBasicInfoActive = 1,
            pnlMedicalInfoActive = 2,
        }
        private enPanelMode _PanelMode;
        public ctrlStudentInfoCard()
        {
            InitializeComponent();
        }

        
        public event Action OnBackToFormHandler;
        public event Action OnEditButtonClicked;

        public event Action onReloadData;



        public void ResetPersonCardToDefault()
        {
            _PanelMode = enPanelMode.pnlBasicInfoActive;
            btnMedicalFile.Text = "Medical File";
            //btnMedicalFile.Image = Resources.document__1_;
            pnlMedicalInfo.Visible = false;
            pnlBasicInfo.Visible = true;
            lblFullName.Parent = pbStudentImage;
            lblIsActive.Parent = pbStudentImage;
            btnEditInfo.Visible = false;
            btnStudentHistory.Visible = false;
            pbStudentStatistiques.Visible = false;

            lblFullName.Text = "[????]";

            lblStudentID.Text = "[????]";
            lblBirthDate.Text = "[????]";
            lblGender.Text = "[????]";
            lblAddress.Text = "[????]";


            lblPhoneNumber.Text = "[????]";
            lblJoinDate.Text = "[????]";
            lblEducationLevel.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            pbStudentImage.Image = Resources.Male_512;


        }

        public void FillPersonCard(clsStudent Student)
        {
            bool MedicalFileTest = true;

            btnEditInfo.Visible = true;
            btnStudentHistory.Visible = true;
            pbStudentStatistiques.Visible = true;

            this.Student = Student;
            lblStudentID.Text = Student.StudentID.ToString();
            lblFullName.Text = Student.FullName();
            lblBirthDate.Text = Student.DateOfBirth.ToString();
            if (Student.Gender == 'M')
            {
                lblGender.Text = "Male";
                pbStudentImage.Image = Resources.Male_512;

            }

            else
            {
                lblGender.Text = "Female";
                pbStudentImage.Image = Resources.Female_512;


            }


            lblAddress.Text = Student.Address;
            lblPhoneNumber.Text = Student.PhoneNumber;
            lblJoinDate.Text = Student.JoinDate.ToShortDateString().ToString();
            lblEducationLevel.Text = clsLevel.FindByID(Student.LevelID).Name;
            lblIsActive.Text = Student.IsActive ? "Active" : "Inactive";
            lblIsActive.ForeColor = Student.IsActive ? Color.Green : Color.Red;

            lblCreatedByUser.Text = clsUser.FindByUserID(Student.CreatedByUserID).UserName;
           
            if (Student.ImagePath != "")
                pbStudentImage.Load(Student.ImagePath);

            if (MedicalFileTest)
            {
                SystemSounds.Hand.Play();
            }



        }

        public void LoadStudentInfo(int StudentID)
        {
            Student = clsStudent.FindByID(StudentID);
            if (Student != null)
                FillPersonCard(Student);


            else
            {
                btnEditInfo.Visible = false;
                btnStudentHistory.Visible = false;

                ResetPersonCardToDefault();
                MessageBox.Show($"This Student with ID [{StudentID}] is not Found", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //public void LoadPersonInfo(string NationalNo)
        //{
        //    Student = clsPerson.FindByNationalNo(NationalNo);

        //    if (Student != null)
        //        /*linkLabel1.Visible = true;
        //        lblPersonID.Text = Person.PersonID.ToString();
        //        lblFullName.Text = Person.FullName();
        //        lblNationalNo.Text = Person.NationalNo;
        //        if (Person.Gendor)
        //        {
        //            lblGender.Text = "Female";
        //            pbImagePerson.Image = Resources.Female_512;

        //        }

        //        else
        //        {
        //            lblGender.Text = "Male";
        //            pbImagePerson.Image = Resources.Male_512;


        //        }


        //        lblEmail.Text = Person.Email;
        //        lblAddress.Text = Person.Address;
        //        lblDateOfBirth.Text = Person.DateOfBirth.ToString();
        //        lblPhone.Text = Person.Phone;
        //        lblCountry.Text = Person.NationalityCountryID.ToString();

        //        if (Person.ImagePath != "")
        //            pbImagePerson.Load(Person.ImagePath);*/
        //        FillPersonCard(Student);
        //    else
        //    {
        //        linkLabel1.Visible = false;
        //        ResetPersonCardToDefault();
        //        MessageBox.Show($"This Person with NationalNo [{NationalNo}] is not Found", "Oops",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}


        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            ResetPersonCardToDefault();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

        }

        private void OnStudentInfoUpdated(clsStudent Student)
        {
            onReloadData?.Invoke();
            FillPersonCard(Student);
        }

        private void pbEditInfo_Click(object sender, EventArgs e)
        {

            OnEditButtonClicked?.Invoke();
            frmAddEditStudent frm = new frmAddEditStudent(Student.StudentID);
            frm.DataBackToCard += OnStudentInfoUpdated;
            frm.ONbtnCloseClicked += BackToForm;

            frm.ShowDialog();
        }

        private void BackToForm()
        {
            OnBackToFormHandler?.Invoke();

        }
        private void ctrlStudentInfoCard_Load(object sender, EventArgs e)
        {
            ResetPersonCardToDefault();
        }

        private void pbStudentStatistiques_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet.", "Comming soon...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMedicalFile_Click(object sender, EventArgs e)
        {
            switch (_PanelMode)
            {
                case enPanelMode.pnlMedicalInfoActive:
                    _PanelMode = enPanelMode.pnlBasicInfoActive;
                    pnlMedicalInfo.Visible = false;
                    pnlBasicInfo.Visible = true;
                    btnMedicalFile.Text = "Medical File";
                    //btnMedicalFile.Image = Resources.document__1_;
                    break;
                case enPanelMode.pnlBasicInfoActive:
                    _PanelMode = enPanelMode.pnlMedicalInfoActive;
                    pnlBasicInfo.Visible = false;
                    pnlMedicalInfo.Visible = true;
                    btnMedicalFile.Text = "Basic Info";
                    //btnMedicalFile.Image = Resources.id_card;
                    break;
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            OnEditButtonClicked?.Invoke();
            frmAddEditStudent frm = new frmAddEditStudent(Student.StudentID);
            frm.DataBackToCard += OnStudentInfoUpdated;
            frm.ONbtnCloseClicked += BackToForm;

            frm.ShowDialog();
        }
    }
}
