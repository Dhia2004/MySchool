using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsPerson
    {
        public int PersonID { get; private set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int CreatedByUserID { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode Mode;

        public clsPerson()
        {
            Mode = enMode.AddNew;
            this.PersonID = -1;
            this.NationalID = "";
            this.FirstName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 'M';
            this.Address = "";
            this.JoinDate = DateTime.Now;
            this.PhoneNumber = "";
            this.Email = "";
            this.ImagePath = "";
            this.CreatedByUserID = -1;
        }

        private clsPerson(int PersonID, string NationalID, string FirstName, string LastName,
                          DateTime DateOfBirth, char Gender,
                          string Address, DateTime JoinDate, string PhoneNumber, string Email,
                          string ImagePath, int CreatedByUserID)
        {
            Mode = enMode.Update;

            this.PersonID = PersonID;
            this.NationalID = NationalID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.JoinDate = JoinDate;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.CreatedByUserID = CreatedByUserID;
        }

        static public clsPerson FindByID(int PersonID)
        {
            string NationalID = "", FirstName = "", LastName = "", Address = "", PhoneNumber = "", Email = "",
                   ImagePath = "";

            DateTime DateOfBirth = DateTime.Now, JoinDate = DateTime.Now;
            char Gender = 'M';
            int CreatedByUserID = -1;

            if (clsPersonDataAccess.FindByID(PersonID, ref NationalID,
                                    ref FirstName, ref LastName,
                                    ref DateOfBirth, ref Gender,
                                    ref Address, ref JoinDate, ref PhoneNumber, ref Email,
                                    ref ImagePath, ref CreatedByUserID))
                return new clsPerson(PersonID, NationalID, FirstName, LastName,
                                     DateOfBirth, Gender, Address, JoinDate,
                                     PhoneNumber, Email, ImagePath, CreatedByUserID);
            else
            {
                return null;
            }





        }

        static public clsPerson FindByNationalID(string NationalID)
        {
            
            string FirstName = "", LastName = "", Address = "", PhoneNumber = "", Email = "",
                   ImagePath = "";

            DateTime DateOfBirth = DateTime.Now, JoinDate = DateTime.Now;
            char Gender = 'M';
            int PersonID = -1, CreatedByUserID = -1;

            if (clsPersonDataAccess.FindByNationalNo(NationalID, ref PersonID,
                                    ref FirstName, ref LastName,
                                    ref DateOfBirth, ref Gender,
                                    ref Address, ref JoinDate, ref PhoneNumber, ref Email,
                                    ref ImagePath, ref CreatedByUserID))
                return new clsPerson(PersonID, NationalID, FirstName, LastName,
                                     DateOfBirth, Gender, Address, JoinDate,
                                     PhoneNumber, Email, ImagePath, CreatedByUserID);
            else
            {
                return null;
            }



        }




        private bool _AddPeron()
        {
            this.PersonID = clsPersonDataAccess.AddPerson(NationalID, FirstName, LastName,
                                     DateOfBirth, Gender, Address, JoinDate,
                                     PhoneNumber, Email, ImagePath, CreatedByUserID);

            return this.PersonID != -1;

        }

        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.Update(PersonID, NationalID, FirstName, LastName,
                                     DateOfBirth, Gender, Address, JoinDate,
                                     PhoneNumber, Email, ImagePath, CreatedByUserID);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddPeron())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                    break;
                case enMode.Update:
                    return _UpdatePerson();
                    break;

                default:
                    return false;

            }

        }

        static public bool Delete(int PersonID)
        {
            return clsPersonDataAccess.Delete(PersonID);
        }


        //static public DataTable GetAllPersons()
        //{
        //    return clsPersonDataAccess.GetAllPersons();
        //}

        static public int GetPersonIDByNationalID(string NationalID)
        {
            return clsPersonDataAccess.GetPersonIDByNationalID(NationalID);
        }
    }
}
