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
    public partial class ctrlPersonInfoCard: UserControl
    {
        public clsPerson Person;
        public event Action <clsPerson> onPersonSelected;

        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }



        public void ResetPersonCardToDefault()
        {
            
            lblFullName.Parent = pbPersonImage;
            
            pbEditInfo.Visible = false;
            

            lblFullName.Text = "[????]";

            lblPersonID.Text = "[????]";
            lblNationalID.Text = "[????]";
            lblBirthDate.Text = "[????]";
            lblGender.Text = "[????]";
            lblAddress.Text = "[????]";


            lblPhoneNumber.Text = "[????]";
            lblJoinDate.Text = "[????]";
            lblEmail.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            //pbPersonImage.Image = Resources.Male_512;


        }

        public void FillPersonCard(clsPerson Person)
        {
           

            pbEditInfo.Visible = true;

            this.Person = Person;
            lblPersonID.Text = Person.PersonID.ToString();
            lblNationalID.Text = Person.NationalID;
            lblFullName.Text = Person.FullName();
            lblBirthDate.Text = Person.DateOfBirth.ToString();
            if (Person.Gender == 'M')
            {
                lblGender.Text = "Male";
                //pbPersonImage.Image = Resources.Male_512;

            }

            else
            {
                lblGender.Text = "Female";
                //pbPersonImage.Image = Resources.Female_512;


            }


            lblAddress.Text = Person.Address;
            lblPhoneNumber.Text = Person.PhoneNumber;
            lblEmail.Text = Person.Email;
            lblJoinDate.Text = Person.JoinDate.ToShortDateString().ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(Person.CreatedByUserID)?.UserName;

            if (Person.ImagePath != "")
                pbPersonImage.Load(Person.ImagePath);

        }

        public void LoadPersonInfo(int PersonID)
        {
            Person = clsPerson.FindByID(PersonID);
            if (Person != null)
            {
                FillPersonCard(Person);
                onPersonSelected?.Invoke(Person); // Trigger the event when a person is selected
            }
               


            else
            {
                pbEditInfo.Visible = false;

                ResetPersonCardToDefault();
                MessageBox.Show($"This Person with ID [{PersonID}] is not Found", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadPersonInfo(string NationlID)
        {
            Person = clsPerson.FindByNationalID(NationlID);
            if (Person != null)
                FillPersonCard(Person);


            else
            {
                pbEditInfo.Visible = false;

                ResetPersonCardToDefault();
                MessageBox.Show($"This Person with NationalID [{NationlID}] is not Found", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ctrlPersonInfoCard_Load(object sender, EventArgs e)
        {
            ResetPersonCardToDefault();
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






    }
}
