using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PSMS_BusinessLayer
{
    public class clsSchoolInfo
    {
        public string SchoolName { get; set; }
        public int OwnerID { get; set; }
        public DateTime SchoolEstablishedYear { get; set; }
        public string SchoolFix { get; set; }
        public string SecondaryFix { get; set; }
        public string SchoolEmail { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
        public string Descreption { get; set; }

        enum enMode
        {
            Add = 1,
            Update = 2
        }
        private enMode Mode;

        public clsSchoolInfo()
        {
            SchoolName = string.Empty;
            OwnerID = -1;
            SchoolEstablishedYear = DateTime.Now;
            SchoolFix = string.Empty;
            SecondaryFix = string.Empty;
            SchoolEmail = string.Empty;
            Address = string.Empty;
            LogoPath = string.Empty;
            Descreption = string.Empty;

            Mode = enMode.Add;
        }

        private clsSchoolInfo(string schoolName, int ownerID, DateTime schoolEstablishedYear, string schoolFix, string secondaryFix, string schoolEmail, string address, string logoPath, string descreption)
        {
            SchoolName = schoolName;
            OwnerID = ownerID;
            SchoolEstablishedYear = schoolEstablishedYear;
            SchoolFix = schoolFix;
            SecondaryFix = secondaryFix;
            SchoolEmail = schoolEmail;
            Address = address;
            LogoPath = logoPath;
            Descreption = descreption;

            Mode = enMode.Update;
        }

        static public clsSchoolInfo GetSchoolInfo()
        {
            string Name = "", FixNumber = "", SecondaryFix = "", Email = "", Address = "", LogoPath = "",
                   Descreption = "";
            int OwnerID = -1;
            DateTime SchoolEstablishedYear = DateTime.Now;
            // Assuming you have a method to fetch the school information from a database or other source

            if (clsSchoolInfoDataAccess.GetSchoolInfo(ref Name, ref OwnerID, ref SchoolEstablishedYear,
            ref FixNumber, ref SecondaryFix, ref Email, ref Address,
            ref LogoPath, ref Descreption))
                return new clsSchoolInfo(Name, OwnerID, SchoolEstablishedYear, FixNumber, SecondaryFix,
                    Email, Address, LogoPath, Descreption);
            else
                return null;

        }

        private bool SetSchoolInfo()
        {
            return clsSchoolInfoDataAccess.InsertSchoolInfo(SchoolName, OwnerID, SchoolEstablishedYear,
                SchoolFix, SecondaryFix, SchoolEmail, Address, LogoPath, Descreption);
        }
        private bool UpdateSchoolInfo()
        {
            return clsSchoolInfoDataAccess.UpdateInfo(SchoolName, OwnerID, SchoolEstablishedYear,
                SchoolFix, SecondaryFix, SchoolEmail, Address, LogoPath, Descreption);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (SetSchoolInfo())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return UpdateSchoolInfo();

                default:
                    return false;       
                    
            }
        }





    }
}
