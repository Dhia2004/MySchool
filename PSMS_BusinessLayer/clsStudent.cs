using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsStudent
    {
        public int StudentID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public int LevelID { get; set; }
        public string ImagePath { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public bool HasMedicalFile { get; set; }
        public clsMedicalFile MedicalFile { get; set; }
        public int GuardianID { get; set; } 
        public clsPerson Guardian { get; set; }
        public string DeactivationReason { get; set; } // Added for future use, if needed
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

        public clsStudent()
        {
            Mode = enMode.AddNew;

            this.StudentID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 'M';
            this.Address = "";
            this.PhoneNumber = "";
            this.JoinDate = DateTime.Now;
            this.LevelID = -1;
            this.ImagePath = "";
            this.Notes = "";
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.GuardianID = -1;
            this.Guardian = null;
            this.HasMedicalFile = false; // Assuming a new student does not have a medical file initially
            // Initialize MedicalFile with a new instance
            // This allows the MedicalFile to be created later if needed
            this.MedicalFile = null;
            this.DeactivationReason = ""; // Initialize to an empty string


        }

        private clsStudent(int StudentID, string FirstName, string LastName, DateTime DateOfBirth,
                           char Gender, string Address, string PhoneNumber, DateTime JoinDate, int LevelID,
                           string ImagePath, string Notes, bool IsActive, int CreatedByUserID,
                           bool HasMedicalFile,int GuardianID,string DeactivationReason)
        {
            Mode = enMode.Update;

            this.StudentID = StudentID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.JoinDate = JoinDate;
            this.LevelID = LevelID;
            this.ImagePath = ImagePath;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.GuardianID = GuardianID;
            if (this.GuardianID != -1)
                this.Guardian = clsPerson.FindByID(this.GuardianID);

            this.HasMedicalFile = HasMedicalFile;
            if (HasMedicalFile)
                this.MedicalFile = clsMedicalFile.FindByStudentID(StudentID);

            this.DeactivationReason = DeactivationReason; 



        }

        static public clsStudent FindByID(int StudentID)
        {
            string FirstName = "", LastName = "", Address = "", PhoneNumber = "",
                   Notes = "", ImagePath = "", DeactivationReason = "";

            DateTime DateOfBirth = DateTime.Now, JoinDate = DateTime.Now;
            char Gender = 'M'; bool IsActive = false,HasMedicalFile = false;
            int LevelID = -1, CreatedByUserID = -1,GuardianID = -1;

            if (clsStudentDataAccess.FindByID(StudentID, ref FirstName,
                                    ref LastName, ref DateOfBirth,
                                    ref Gender, ref Address,
                                    ref PhoneNumber, ref JoinDate,
                                    ref LevelID, ref ImagePath, ref Notes,
                                    ref IsActive, ref CreatedByUserID, ref HasMedicalFile,
                                    ref GuardianID,ref DeactivationReason))

                return new clsStudent(StudentID, FirstName,
                                      LastName, DateOfBirth,
                                      Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID,HasMedicalFile,GuardianID, DeactivationReason);

            else
                return null;

        }




        private bool _AddStudent()
        {
            this.StudentID = clsStudentDataAccess.AddStudent(FirstName, LastName, DateOfBirth, Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID,HasMedicalFile,GuardianID,
                                      DeactivationReason);

            return this.StudentID != -1;

        }

        private bool _UpdateStudent()
        {
            return clsStudentDataAccess.Update(StudentID, FirstName,
                                      LastName, DateOfBirth,
                                      Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID,HasMedicalFile,GuardianID,DeactivationReason);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddStudent())
                    {
                        if (MedicalFile != null && MedicalFile.StudentID == -1)
                        {
                            MedicalFile.StudentID = this.StudentID;
                            MedicalFile.Save();
                        }
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                    break;
                case enMode.Update:
                    return _UpdateStudent();
                    break;

                default:
                    return false;

            }

        }

        static public bool Delete(int StudentID)
        {
            return clsStudentDataAccess.Delete(StudentID);
        }


        static public DataTable GetAllStudents()
        {
            return clsStudentDataAccess.GetAllStudents();
        }

        static public List<clsStudent> GetAllStudentsObjects()
        {
            DataTable dt = clsStudentDataAccess.GetAllStudents();
            
            return ConvertStudentsRecordsToObjects(dt);



        }

        static public List<clsStudent> ConvertStudentsRecordsToObjects(DataTable dtStudents)
        {
            List<clsStudent> Students = new List<clsStudent>();
            clsStudent student;
            foreach (DataRow s in dtStudents.Rows)
            {
                student = new clsStudent((int)s["StudentID"], (string)s["FirstName"], (string)s["LastName"],
                                         (DateTime)s["BirthDate"], Convert.ToChar(s["Gender"]), (string)s["Address"],
                                         (string)s["PhoneNumber"], (DateTime)s["JoinDate"],
                                         (int)s["Level_ID"], s["ImagePath"] != DBNull.Value ? (string)s["ImagePath"] : "",
                                         s["Notes"] != DBNull.Value ? (string)s["Notes"] : "",
                                         Convert.ToBoolean(s["IsActive"]), (int)s["CreatedByUserID"],
                                         Convert.ToBoolean(s["HasMedicalFile"]), (int)s["GuardianID"],
                                         s["DeactivationReason"] != DBNull.Value ? (string)s["DeactivationReason"] : "");

                Students.Add(student);
            }
            return Students;



        }

        static public List<clsStudent> fetchStudentBatch(int PageNumber)
        {
           
            DataTable dt = clsStudentDataAccess.fetchStudentBatch(PageNumber);
            //foreach (DataRow s in dt.Rows)
            //{
            //    student = new clsStudent((int)s["StudentID"], (string)s["FirstName"], (string)s["LastName"],
            //                             (DateTime)s["BirthDate"], Convert.ToChar(s["Gender"]), (string)s["Address"],
            //                             (string)s["PhoneNumber"], (DateTime)s["JoinDate"],
            //                             (int)s["Level_ID"], s["ImagePath"] != DBNull.Value ? (string)s["ImagePath"] : "",
            //                             s["Notes"] != DBNull.Value ? (string)s["Notes"] : "",
            //                             Convert.ToBoolean(s["IsActive"]), (int)s["CreatedByUserID"]);

            //    Students.Add(student);
            //}
            return ConvertStudentsRecordsToObjects(dt);



        }
    }
}
