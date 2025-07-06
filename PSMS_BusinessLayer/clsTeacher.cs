using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsTeacher
    {
        public int TeacherID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson Person { get; set; } // Assuming clsPerson is a class that holds person details
        public string SpecialityID { get; set; } // Assuming a single subject for simplicity, can be extended to multiple subject
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
            this.SpecialityID = "";
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.Person = new clsPerson(); // Initialize with a new person object
        }
        private clsTeacher(int TeacherID, int PersonID, string SpecialityID, bool IsActive, int CraetedByUserID)
        {
            Mode = enMode.Update;
            this.TeacherID = TeacherID;
            this.PersonID = PersonID;
            this.SpecialityID = SpecialityID;
            this.IsActive = IsActive;
            this.CreatedByUserID = CraetedByUserID;
            this.Person = clsPerson.FindByID(PersonID); // Assuming FindByPersonID is a method to get person details
        }

        static public clsTeacher FindByTeacherID(int TeacherID)
        {
            int PersonID = -1, CraetedByUserID = -1;
            string SpecialityID = "";
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
            int TeacherID = -1, CraetedByUserID = -1;
            string SpecialityID = "";
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
            if (Mode == enMode.AddNew)
            {
                // Logic to save a new teacher
                return clsTeacherDataAccess.AddNewTeacher(this.PersonID, this.SpecialityID, this.IsActive, this.CreatedByUserID) != -1;
            }
            else if (Mode == enMode.Update)
            {
                // Logic to update an existing teacher
                return clsTeacherDataAccess.Update(this.TeacherID, this.PersonID, this.SpecialityID, this.IsActive, this.CreatedByUserID);
            }
            return false; // If neither add nor update, return false
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

    }

}
