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
using static MySchool.ctrlStudentInfoCard;

namespace MySchool
{
    public partial class frmAddEditStudent : Form
    {
        private bool IsUpdated = false;
        //private bool MessingMedicalFile = false; // To check if the medical file is missing or not

        private int _StudentID;

        private clsStudent _Student;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;

        public enum enPanelMode
        {
            pnlBasicInfoActive = 1,
            pnlMedicalInfoActive = 2,
        }
        private enPanelMode _PanelMode;

        public event Action<clsStudent> DataBackToCard;
        public event Action DataBackToMiniCard;


        public delegate void btnCloseHandel();
        public event btnCloseHandel ONbtnCloseClicked;






        private void _FullComboBoxWithLevels()
        {
            DataTable dtLevels = new DataTable();
            dtLevels = clsLevel.GetAllLevels();
            if (dtLevels != null)
            {
                foreach (DataRow Row in dtLevels.Rows)
                {
                    cbLevel.Items.Add(Row["Name"].ToString());

                }
                cbLevel.SelectedIndex = 0;
            }


        }

        public void InitializefrmAddUpdatePerson()
        {
            //DateTime MaxDate = new DateTime(DateTime.Now.Year-18,DateTime.Now.Month, DateTime.Now.Day) ;
            _Student = new clsStudent();
            rbMale.Checked = true;
            // pbImagePerson.Image = Resources.Male_512;


            //if (pbStudentImage.ImageLocation != null)
            //{
            //    ll_SetLink.Visible = false;
            //    ll_RemoveLink.Visible = true;
            //}
            //else
            //{
            //    ll_SetLink.Visible = true;
            //    ll_RemoveLink.Visible = false;
            //}

        }



        private void rbGendor_ChekedChanged(object sender, EventArgs e)
        {
            if (pbStudentImage.ImageLocation == null)
            {
                if (((RadioButton)sender).Tag.ToString() == "Woman")
                    pbStudentImage.Image = Resources.Female_512;
                else
                    pbStudentImage.Image = Resources.Male_512;
            }


        }

        private void FullPnlMedicalFile()
        {
            chkMedicalFile.Checked = true;
            cbBloodType.SelectedIndex = cbBloodType.FindString(_Student.MedicalFile.BloodType);
            
            if (_Student.MedicalFile.IsDisabled)
            {
                if (_Student.MedicalFile.DisabilityDescription == "Physical")
                    rbPhysicalDisability.Checked = true;
                else
                    rbMentalDisability.Checked = true;
            }
            else
                rbNo_Disability.Checked = true;

            rbGlasses_Yes.Checked = _Student.MedicalFile.WearsGlasses;
            rbPracticeSport_Yes.Checked = _Student.MedicalFile.CanParticipateInSports;
            rbSurgery_Yes.Checked = _Student.MedicalFile.HasUndergoneSurgery;
            rbChronic_Yes.Checked = _Student.MedicalFile.HasChronicDisease;
            if (_Student.MedicalFile.HasChronicDisease)
            {
                rbChronic_Yes.Checked = true;
                string [] ChronicsSelected = _Student.MedicalFile.ChronicDiseaseDescription.Split('-');

                foreach (string item in ChronicsSelected)
                {
                    switch (item.Trim())
                    {
                        case "Asthma":
                            chkAsthma.Checked = true;
                            break;
                        case "Diabetes":
                            chkDiabetes.Checked = true;
                            break;
                        case "Heart Disease":
                            chkHeartDisease.Checked = true;
                            break;
                        case "Anemia":
                            chkAnemia.Checked = true;
                            break;
                        case "Epilepsy":
                            chkEpilepsy.Checked = true;
                            break;
                        case "Kidney Disease":
                            chkKidneyDisease.Checked = true;
                            break;
                        case "Liver Disease":
                            chkLiverDisease.Checked = true;
                            break;
                        case "Thyroid Disorders":
                            chkThyroidDisorders.Checked = true;
                            break;
                    }
                }
                
            }
            else
            {
                rbChronic_No.Checked = true;
                pnlNoChronics.Visible = true;
            }

            rbAllergy_Yes.Checked = _Student.MedicalFile.HasAllergy;
            if (_Student.MedicalFile.HasAllergy)
            {
                rbAllergy_Yes.Checked = true;
                string[] AllergySelected = _Student.MedicalFile.AllergyDescription.Split('-');
                foreach (string item in AllergySelected)
                {
                    switch (item.Trim())
                    {
                        case "Peanut":
                            chkPeanut.Checked = true;
                            break;
                        case "Lactose":
                            chkLactose.Checked = true;
                            break;
                        case "Gluten":
                            chkGluten.Checked = true;
                            break;
                        case "Dust":
                            chkDust.Checked = true;
                            break;
                        case "Egg":
                            chkEgg.Checked = true;
                            break;
                        case "Skin":
                            chkSkin.Checked = true;
                            break;
                        case "Aspirin":
                            chkAspirin.Checked = true;
                            break;
                        case "Pollen":
                            chkPollen.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                rbAllergy_No.Checked = true;
                pnlNoAllergy.Visible = true;
            }

            rbMedication_Yes.Checked = _Student.MedicalFile.TakesMedication;
            if (_Student.MedicalFile.TakesMedication)
            {
                rbMedication_Yes.Checked = true;
                string[] MedicationsSelected = _Student.MedicalFile.MedicationDescription.Split('-');
                foreach (string item in MedicationsSelected)
                {
                    switch (item.Trim())
                    {
                        case "Insulin":
                            chkInsulin.Checked = true;
                            break;
                        case "Paracetamol":
                            chkParacetamol.Checked = true;
                            break;
                        case "Asthma Medications":
                            chkAsthmaMedications.Checked = true;
                            break;
                        case "Cardiac Medications":
                            chkCardiacMedications.Checked = true;
                            break;
                        case "Penicillin":
                            chkPenicillin.Checked = true;
                            break;
                        case "Antihistamines":
                            chkAntihistamines.Checked = true;
                            break;
                        case "Diabetes Medications":
                            chkDiabetesMedications.Checked = true;
                            break;
                        case "Anti Epi Drugs":
                            chkAntiEpiDrugs.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                rbMedication_No.Checked = true;
                pnlNoMedication.Visible = true;
            }

            txtMedicalRemarks.Text = _Student.MedicalFile.Remarks;



        }

        public void GetStudentByID(int StudentID)
        {
            _Student = clsStudent.FindByID(StudentID);
            if (_Student != null)
            {
                txtFirstName.Text = _Student.FirstName;
                txtLastName.Text = _Student.LastName;

                if (_Student.Gender == 'M')
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                if (_Student.Guardian != null)
                {
                    lblFullName.Text = _Student.Guardian.FullName();
                    lblPhone.Text = _Student.Guardian.PhoneNumber;
                }
                    


                txtAddress.Text = _Student.Address;
                dtpBirthDate.Value = _Student.DateOfBirth;
                txtPhone.Text = _Student.PhoneNumber;


                if (_Student.ImagePath != "")
                {
                    pbStudentImage.Load(_Student.ImagePath);
                    //ll_RemoveLink.Visible = true;


                }


                


                cbLevel.SelectedIndex = cbLevel.FindString(clsLevel.FindByID(_Student.LevelID).Name);

                if (_Student.HasMedicalFile)
                {
                    FullPnlMedicalFile();
                }
            }
        }

        private clsMedicalFile CreateNewMedicalFile()
        {
            clsMedicalFile MedicalFile = new clsMedicalFile();
            MedicalFile.StudentID = -1;
            if (Mode == enMode.Update)
            {
                MedicalFile.StudentID = _Student.StudentID;
            }
            MedicalFile.BloodType = cbBloodType.SelectedItem.ToString();
            MedicalFile.IsDisabled = !rbNo_Disability.Checked;
            if(MedicalFile.IsDisabled)
                MedicalFile.DisabilityDescription = rbPhysicalDisability.Checked? rbPhysicalDisability.Tag.ToString():rbMentalDisability.Tag.ToString();
            MedicalFile.WearsGlasses = rbGlasses_No.Checked ? false : true;
            MedicalFile.CanParticipateInSports = rbPracticeSport_Yes.Checked ? true : false;
            MedicalFile.HasUndergoneSurgery = rbSurgery_No.Checked ? false : true;
            MedicalFile.HasChronicDisease = rbChronic_No.Checked ? false : true;
            MedicalFile.ChronicDiseaseDescription = txtChronicIllness.Text;
            MedicalFile.HasAllergy = rbAllergy_No.Checked ? false : true;
            MedicalFile.AllergyDescription = txtAllergy.Text;
            MedicalFile.TakesMedication = rbMedication_No.Checked ? false : true;
            MedicalFile.MedicationDescription = txtMedications.Text;
            MedicalFile.Remarks = txtMedicalRemarks.Text;
            MedicalFile.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // TODO: Replace with actual user ID


            return MedicalFile;
        }
        public bool SaveDateUpdate()
        {
            bool IsDone = false;
            if (MessageBox.Show("Are you sure for save this Changes?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Student.FirstName = txtFirstName.Text;
                _Student.LastName = txtLastName.Text;
                _Student.DateOfBirth = dtpBirthDate.Value;
                _Student.Gender = rbMale.Checked ? 'M' : 'F';
                _Student.Address = txtAddress.Text;
                _Student.PhoneNumber = txtPhone.Text;
                _Student.JoinDate = DateTime.Now;
                _Student.LevelID = clsLevel.FindByName(cbLevel.SelectedItem.ToString()).Level_ID;
                _Student.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID; // TODO: Replace with actual user ID
                _Student.Notes = txtNotes.Text;
                _Student.IsActive = true; // Assuming new students are active by default

                _Student.ImagePath = pbStudentImage.ImageLocation == null ? "" : pbStudentImage.ImageLocation;
                if (_Student.HasMedicalFile == false && chkMedicalFile.Checked)
                {
                    _Student.MedicalFile = CreateNewMedicalFile();
                }
                _Student.HasMedicalFile = chkMedicalFile.Checked;
                
                    


                if ((IsDone = _Student.Save()))

                    MessageBox.Show("Student Updated Successfully", "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Student Updated Failed", "Oops..",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            return IsDone;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkMedicalFile.Checked)
            {
                if (MessageBox.Show("The student does not have a medical file.\nDo you want to continue?",
                                "Medical File Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.No)
                    return;
            }

            if (SaveDateUpdate())
            {
                Mode = enMode.Update;
                _StudentID = _Student.StudentID;
                lblPersonID.Text = _Student.StudentID.ToString();
                lblMode.Text = "Update Student Informations";
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
                DataBackToCard?.Invoke(_Student);
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




        public frmAddEditStudent(int StudentID)
        {
            InitializeComponent();

            _StudentID = StudentID;
            if (StudentID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
                Mode = enMode.Update;
        }


        private void IntializePnlMedicalInfo()
        {
            cbBloodType.SelectedIndex = 0;
            chkMedicalFile.Checked = false;
            chkMedicalFile.Visible = false;
            rbNo_Disability.Checked = true;
            rbGlasses_No.Checked = true;
            rbPracticeSport_Yes.Checked = true;
            rbSurgery_No.Checked = true;
            rbChronic_No.Checked = true;
            rbAllergy_No.Checked = true;
            rbMedication_No.Checked = true;
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {
            _PanelMode = enPanelMode.pnlBasicInfoActive;
            IntializePnlMedicalInfo();
            pbDelete.Visible = false;
            pbUpdate.Visible = false;
            btnMedicalFile.BringToFront();
            btnClose.Location = new Point(252, 741);
            btnMedicalFile.Text = "Medical File";
            btnMedicalFile.Image = Resources.Medical_File_32;
            pnlBasicInfo.Visible = true;
            pnlMedicalInfo.Visible = false;
            _FullComboBoxWithLevels();
            dtpBirthDate.MaxDate = (DateTime.Now).AddYears(-6);

            if (Mode == enMode.Update)
            {
                lblPersonID.Text = _StudentID.ToString();
                lblMode.Text = "Update Student Informations";
                GetStudentByID(_StudentID);
                return;
            }

            InitializefrmAddUpdatePerson();
        }

        private void ll_SetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Select Image";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //if (openFileDialog1.FileName != "")
                //{
                //    pbStudentImage.Load(openFileDialog1.FileName);
                //    ll_RemoveLink.Visible = true;
                //}

            }
        }

        private void ll_RemoveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbStudentImage.ImageLocation = null;
            //if (_Student.Gender == 'M')
            //    //pbStudentImage.Image = Resources.Male_512;
            //else
            //    //pbStudentImage.Image = Resources.Female_512;
        }



        private void pbExit_Click(object sender, EventArgs e)
        {
            CloseForm();


        }

        private void btnMedicalFile_Click(object sender, EventArgs e)
        {
            switch (_PanelMode)
            {
                case enPanelMode.pnlMedicalInfoActive:
                    _PanelMode = enPanelMode.pnlBasicInfoActive;
                    chkMedicalFile.Visible = false;
                    pbUpdate.Visible = false;
                    pbDelete.Visible = false;
                    pnlMedicalInfo.Visible = false;
                    pnlBasicInfo.Visible = true;
                    btnMedicalFile.Text = "Medical File";
                    btnMedicalFile.Location = new Point(370, 741);
                    btnClose.Location = new Point(252, 741);
                    btnMedicalFile.Image = Resources.Basic_Info_32;
                    break;
                case enPanelMode.pnlBasicInfoActive:
                    _PanelMode = enPanelMode.pnlMedicalInfoActive;
                    chkMedicalFile.Visible = true;
                    pbUpdate.Visible = true;
                    pbDelete.Visible = true;
                    pnlBasicInfo.Visible = false;
                    pnlMedicalInfo.Visible = true;
                    pnlMedicalInfo.BringToFront();
                    btnMedicalFile.Text = "Basic Info";
                    btnMedicalFile.Location = new Point(163, 741);
                    btnClose.Location = new Point(45, 741);
                    btnMedicalFile.Image = Resources.Basic_Info_32;
                    break;
            }


        }

        private void rbChronicIllness_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Tag)
            {
                case "Yes":
                    pnlChronicIllness.BringToFront();
                    txtChronicIllness.BringToFront();
                    pnlNoChronics.SendToBack();
                    pnlNoChronics.Visible = false;

                    break;
                case "No":
                    pnlChronicIllness.SendToBack();
                    txtChronicIllness.SendToBack();
                    pnlNoChronics.BringToFront();
                    pnlNoChronics.Visible = true;


                    break;
            }
        }

        private void rbAllergy_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Tag)
            {
                case "Yes":
                    pnlAllergy.BringToFront();
                    txtAllergy.BringToFront();
                    pnlNoAllergy.SendToBack();
                    pnlNoAllergy.Visible = false;

                    break;
                case "No":
                    pnlAllergy.SendToBack();
                    txtAllergy.SendToBack();
                    pnlNoAllergy.BringToFront();
                    pnlNoAllergy.Visible = true;

                    break;
            }
        }

        private void rbMedication_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Tag)
            {
                case "Yes":
                    pnlMedications.BringToFront();
                    txtMedications.BringToFront();
                    pnlNoMedication.SendToBack();
                    pnlNoMedication.Visible = false;

                    break;
                case "No":
                    pnlMedications.SendToBack();
                    txtMedications.SendToBack();
                    pnlNoMedication.BringToFront();
                    pnlNoMedication.Visible = true;

                    break;
            }
        }

        private void UpdateChronicsSelected(object sender, EventArgs e)
        {
            string ChrinicsSelected = "";

            if (chkAsthma.Checked)
            {
                ChrinicsSelected += "Asthma ";
            }
            if (chkDiabetes.Checked)
            {
                ChrinicsSelected += "- Diabetes ";
            }
            if (chkHeartDisease.Checked)
            {
                ChrinicsSelected += "- Heart Disease ";
            }
            if (chkAnemia.Checked)
            {
                ChrinicsSelected += "- Anemia ";
            }
            if (chkEpilepsy.Checked)
            {
                ChrinicsSelected += "- Epilepsy ";
            }
            if (chkKidneyDisease.Checked)
            {
                ChrinicsSelected += "- Kidney Disease ";
            }
            if (chkLiverDisease.Checked)
            {
                ChrinicsSelected += "- Liver Disease ";
            }
            if (chkThyroidDisorders.Checked)
            {
                ChrinicsSelected += "- Thyroid Disorders";
            }

            if (ChrinicsSelected.StartsWith("-"))

                ChrinicsSelected = ChrinicsSelected.Substring(2, ChrinicsSelected.Length - 2);


            txtChronicIllness.Text = ChrinicsSelected;
        }

        private void UpdateAllergySelected(object sender, EventArgs e)
        {
            string AllergySelected = "";

            if (chkPeanut.Checked)
            {
                AllergySelected += "Peanut ";
            }
            if (chkLactose.Checked)
            {
                AllergySelected += "- Lactose ";
            }
            if (chkGluten.Checked)
            {
                AllergySelected += "- Gluten ";
            }
            if (chkDust.Checked)
            {
                AllergySelected += "- Dust ";
            }
            if (chkEgg.Checked)
            {
                AllergySelected += "- Egg ";
            }
            if (chkSkin.Checked)
            {
                AllergySelected += "- Skin ";
            }
            if (chkAspirin.Checked)
            {
                AllergySelected += "- Aspirin ";
            }
            if (chkPollen.Checked)
            {
                AllergySelected += "- Pollen";
            }

            if (AllergySelected.StartsWith("-"))

                AllergySelected = AllergySelected.Substring(2, AllergySelected.Length - 2);


            txtAllergy.Text = AllergySelected;
        }

        private void UpdateMadicationsSelected(object sender, EventArgs e)
        {
            string MedicationsSelected = "";

            if (chkInsulin.Checked)
            {
                MedicationsSelected += "Insulin ";
            }
            if (chkParacetamol.Checked)
            {
                MedicationsSelected += "- Paracetamol ";
            }
            if (chkAsthmaMedications.Checked)
            {
                MedicationsSelected += "- Asthma Medications ";
            }
            if (chkCardiacMedications.Checked)
            {
                MedicationsSelected += "- Cardiac Medications ";
            }
            if (chkPenicillin.Checked)
            {
                MedicationsSelected += "- Penicillin ";
            }
            if (chkAntihistamines.Checked)
            {
                MedicationsSelected += "- Antihistamines ";
            }
            if (chkDiabetesMedications.Checked)
            {
                MedicationsSelected += "- Diabetes Medications ";
            }
            if (chkAntiEpiDrugs.Checked)
            {
                MedicationsSelected += "- Anti Epi Drugs";
            }

            if (MedicationsSelected.StartsWith("-"))

                MedicationsSelected = MedicationsSelected.Substring(2, MedicationsSelected.Length - 2);


            txtMedications.Text = MedicationsSelected;

            
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmPersonInfoWithFilter frm = new frmPersonInfoWithFilter();
            frm.onPersonSelected += (Person) =>
            {

                if (Person != null)
                {
                    _Student.GuardianID = Person.PersonID;
                    _Student.Guardian = Person;
                    lblFullName.Text = Person.FullName();
                    lblPhone.Text = Person.PhoneNumber;
                }
            };
            frm.ShowInTaskbar = false;

            this.Opacity = 0.5;

            frm.ShowDialog();
            this.Opacity = 1.0;

        }

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_Student.Guardian.PersonID);
            frm.ShowInTaskbar = false;
            this.Opacity = 0.5;
            
            frm.ShowDialog();
            this.Opacity = 1.0;

        }

        private void pbStudentImage_MouseEnter(object sender, EventArgs e)
        {
            if (pbStudentImage.ImageLocation == null)
            {
                pnlUploadImage.BringToFront();
                pbStudentImage.SendToBack();
                return;
            }
            pnlDeleteImage.BringToFront();
            pnlUploadImage.SendToBack();
            pbStudentImage.SendToBack();

        }

        private void pnlUploadImage_MouseLeave(object sender, EventArgs e)
        {
            pnlUploadImage.SendToBack();
            pbStudentImage.BringToFront();
        }

        private void pnlUploadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Select Image";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

                if (openFileDialog1.FileName != "")
                {
                    pbStudentImage.Load(openFileDialog1.FileName);
                    //ll_RemoveLink.Visible = true;
                }
        }

        private void pnlDeleteImage_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this picture ?",
                "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                pbStudentImage.ImageLocation = null;
                if (rbMale.Checked)
                    pbStudentImage.Image = Resources.Male_512;
                else
                    pbStudentImage.Image = Resources.Female_512;
                pnlDeleteImage.SendToBack();
                pnlUploadImage.SendToBack();
                pbStudentImage.BringToFront();
            }
            
        }

        private void pnlDeleteImage_MouseLeave(object sender, EventArgs e)
        {
            pnlUploadImage.SendToBack();
            pnlDeleteImage.SendToBack();
            pbStudentImage.BringToFront();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkMedicalFile_CheckedChanged(object sender, EventArgs e)
        {
            pnlMedicalInfo.Enabled = chkMedicalFile.Checked;
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this medical file ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_Student.MedicalFile != null)
                {
                    clsMedicalFile.Delete(_StudentID);
                }
                _Student.MedicalFile = null;
                chkMedicalFile.Checked = false;
                _Student.HasMedicalFile = false;

            }
        }
    }
}
