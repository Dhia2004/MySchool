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
        public clsMedicalFile MedicalFile { get; set; }
        public int GuardianID { get; set; } 
        public clsPerson Guardian { get; set; }
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
            this.MedicalFile = new clsMedicalFile();


        }

        private clsStudent(int StudentID, string FirstName, string LastName, DateTime DateOfBirth,
                           char Gender, string Address, string PhoneNumber, DateTime JoinDate, int LevelID,
                           string ImagePath, string Notes, bool IsActive, int CreatedByUserID)
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
            this.MedicalFile = clsMedicalFile.FindByStudentID(StudentID);

        }

        static public clsStudent FindByID(int StudentID)
        {
            string FirstName = "", LastName = "", Address = "", PhoneNumber = "",
                   Notes = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now, JoinDate = DateTime.Now;
            char Gender = 'M'; bool IsActive = false;
            int LevelID = -1, CreatedByUserID = -1;

            if (clsStudentDataAccess.FindByID(StudentID, ref FirstName,
                                    ref LastName, ref DateOfBirth,
                                    ref Gender, ref Address,
                                    ref PhoneNumber, ref JoinDate,
                                    ref LevelID, ref ImagePath, ref Notes,
                                    ref IsActive, ref CreatedByUserID))

                return new clsStudent(StudentID, FirstName,
                                      LastName, DateOfBirth,
                                      Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID);

            else
                return null;

        }




        private bool _AddStudent()
        {
            this.StudentID = clsStudentDataAccess.AddStudent(FirstName, LastName, DateOfBirth, Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID);

            return this.StudentID != -1;

        }

        private bool _UpdateStudent()
        {
            return clsStudentDataAccess.Update(StudentID, FirstName,
                                      LastName, DateOfBirth,
                                      Gender, Address,
                                      PhoneNumber, JoinDate,
                                      LevelID, ImagePath, Notes,
                                      IsActive, CreatedByUserID);

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
            List<clsStudent> Students = new List<clsStudent>();
            clsStudent student;
            DataTable dt = clsStudentDataAccess.GetAllStudents();
            foreach (DataRow s in dt.Rows)
            {
                student = new clsStudent((int)s["StudentID"], (string)s["FirstName"], (string)s["LastName"],
                                         (DateTime)s["BirthDate"], Convert.ToChar(s["Gender"]), (string)s["Address"],
                                         (string)s["PhoneNumber"], (DateTime)s["JoinDate"],
                                         (int)s["Level_ID"], s["ImagePath"] != DBNull.Value? (string)s["ImagePath"] : "",
                                         s["Notes"] != DBNull.Value? (string)s["Notes"]:"",
                                         Convert.ToBoolean(s["IsActive"]), (int)s["CreatedByUserID"]);

                Students.Add(student);
            }
            return Students;



        }

        static public List<clsStudent> fetchStudentBatch(int PageNumber)
        {
            List<clsStudent> Students = new List<clsStudent>();
            clsStudent student;
            DataTable dt = clsStudentDataAccess.fetchStudentBatch(PageNumber);
            foreach (DataRow s in dt.Rows)
            {
                student = new clsStudent((int)s["StudentID"], (string)s["FirstName"], (string)s["LastName"],
                                         (DateTime)s["BirthDate"], Convert.ToChar(s["Gender"]), (string)s["Address"],
                                         (string)s["PhoneNumber"], (DateTime)s["JoinDate"],
                                         (int)s["Level_ID"], s["ImagePath"] != DBNull.Value ? (string)s["ImagePath"] : "",
                                         s["Notes"] != DBNull.Value ? (string)s["Notes"] : "",
                                         Convert.ToBoolean(s["IsActive"]), (int)s["CreatedByUserID"]);

                Students.Add(student);
            }
            return Students;



        }
    }
}
