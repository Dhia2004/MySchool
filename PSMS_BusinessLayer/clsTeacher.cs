using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsTeacher
    {
        public int TeacherID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson Person { get; set; } // Assuming clsPerson is a class that holds person details
        public int SpecialityID { get; set; } // Assuming a single subject for simplicity, can be extended to multiple subject
        public bool IsActive { get; set; } // Active status of the teacher
        public int CreatedByUserID { get; set; } // User ID of the creator

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;
        public clsTeacher()
        {
            Mode = enMode.AddNew;
            this.TeacherID = -1;
            this.PersonID = -1;
            this.SpecialityID = -1;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.Person = new clsPerson(); // Initialize with a new person object
        }
        private clsTeacher(int TeacherID, int PersonID, int SpecialityID, bool IsActive, int CraetedByUserID)
        {
            Mode = enMode.Update;
            this.TeacherID = TeacherID;
            this.PersonID = PersonID;
            this.SpecialityID = SpecialityID;
            this.IsActive = IsActive;
            this.CreatedByUserID = CraetedByUserID;
            this.Person = clsPerson.FindByID(PersonID); // Assuming FindByPersonID is a method to get person details
        }

        private bool _AddNewTeacher()
        {
            this.TeacherID = clsTeacherDataAccess.AddNewTeacher(PersonID,SpecialityID,IsActive,CreatedByUserID);

            return this.TeacherID != -1;
        }

        private bool _UpdateTeacher()
        {
            return clsTeacherDataAccess.Update(this.TeacherID,this.SpecialityID, this.IsActive);
        }

        static public clsTeacher FindByTeacherID(int TeacherID)
        {
            int PersonID = -1, CraetedByUserID = -1, SpecialityID = -1;
     
            bool IsActive = false;
            if (clsTeacherDataAccess.FindByTeacherID(TeacherID, ref PersonID, ref SpecialityID, ref IsActive, ref CraetedByUserID))
            {
                return new clsTeacher(TeacherID, PersonID, SpecialityID, IsActive, CraetedByUserID);
            }
            else
            {
                return null;
            }
        }
        static public clsTeacher FindByPersonID(int PersonID)
        {
            int TeacherID = -1, CraetedByUserID = -1,SpecialityID = -1;
            
            bool IsActive = false;
            if (clsTeacherDataAccess.FindByPersonID(PersonID, ref TeacherID, ref SpecialityID, ref IsActive, ref CraetedByUserID))
            {
                return new clsTeacher(TeacherID, PersonID, SpecialityID, IsActive, CraetedByUserID);
            }
            else
            {
                return null;
            }
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTeacher())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                    break;
                case enMode.Update:
                    return _UpdateTeacher();

                    break;

                default:
                    return false;

            }
        }
        public bool Delete()
        {
            // Logic to delete a teacher
            return clsTeacherDataAccess.DeleteTeacher(this.TeacherID);
        }
        public override string ToString()
        {
            return $"{Person.FirstName} {Person.LastName} - {SpecialityID}";


        }

        //public static List<clsTeacher> GetAllTeachers()
        //{
        //    List<clsTeacher> teachers = new List<clsTeacher>();
        //    var teacherData = clsTeacherDataAccess.GetAllTeachers();
        //    foreach (var data in teacherData)
        //    {
        //        teachers.Add(new clsTeacher(data.TeacherID, data.PersonID, data.SpecialityID, data.IsActive, data.CreatedByUserID));
        //    }
        //    return teachers;
        //}

        public static List<clsTeacher> GetAllTeachersBySubject(int subjectID)
        {
            List<clsTeacher> teachers = new List<clsTeacher>();
            DataTable dtTeachers = clsTeacherDataAccess.GetAllTeachersBySubject(subjectID);
            
            return dtTeachers!= null ? ConvertTeachersRecordsToObjects(dtTeachers) : null;
        }


        static public List<clsTeacher> ConvertTeachersRecordsToObjects(DataTable dtTeachers)
        {
            List<clsTeacher> Teachers = new List<clsTeacher>();
            clsTeacher Teacher;
            foreach (DataRow s in dtTeachers.Rows)
            {
                Teacher = new clsTeacher((int)s["TeacherID"], (int)s["PersonID"], (int)s["SpecialityID"],
                    Convert.ToBoolean(s["IsActive"]), (int)s["CreatedByUserID"]);

                Teachers.Add(Teacher);
            }
            return Teachers;



        }
    }

}
