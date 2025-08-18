using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsSubject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TargetedLevels { get; set; } // This could be a bitmask or a list of levels, depending on your design
        public string ImagePath { get;set; }


        public clsSubject() 
        {
            this.SubjectID = -1;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.TargetedLevels = 0; // Default value, can be adjusted based on your requirements
            this.ImagePath = string.Empty; // Default value for ImagePath

        }
        private clsSubject(int SubjectID, string Name, string Description, int TargetedLevels,string ImagePath)
        {
            this.SubjectID = SubjectID;
            this.Name = Name;
            this.Description = Description;
            this.TargetedLevels = TargetedLevels;
            this.ImagePath = ImagePath; // Initialize ImagePath
        }


        static public clsSubject FindByName(string Name)
        {
            int SubjectID = -1, TargetedLevels = 0;
            string Description = "",ImagePath = "";
            if (clsSubjectDataAccess.FindByName(Name, ref SubjectID, ref Description, ref TargetedLevels,ref ImagePath))
            {
                return new clsSubject(SubjectID, Name, Description, TargetedLevels, ImagePath);
            }
            else
                return null;
        }

        static public clsSubject FindByID(int SubjectID)
        {
            string Name = "", Description = "", ImagePath = "";
            int TargetedLevels = 0;
            if (clsSubjectDataAccess.FindByID(SubjectID, ref Name, ref Description, ref TargetedLevels,ref ImagePath))
            {
                return new clsSubject(SubjectID, Name, Description, TargetedLevels, ImagePath);
            }
            else
                return null;
        }
        public static List<clsSubject> GetAllSubjects()
        {
            DataTable dtSubjects = clsSubjectDataAccess.GetAllSubjects();
            List<clsSubject> Subjects = new List<clsSubject>();
            //clsSubject Subject;
            if (dtSubjects != null)
                foreach (DataRow s in dtSubjects.Rows)
                    Subjects.Add(new clsSubject((int)s["SubjectID"], (string)s["Name"], (string)s["Description"],
                                             (int)s["TargetedLevels"], (string)s["ImagePath"]));
            return Subjects;
        }

    }
}
