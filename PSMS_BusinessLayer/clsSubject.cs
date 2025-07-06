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


        public clsSubject() 
        {
            this.SubjectID = -1;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.TargetedLevels = 0; // Default value, can be adjusted based on your requirements

        }
        private clsSubject(int SubjectID, string Name, string Description, int TargetedLevels)
        {
            this.SubjectID = SubjectID;
            this.Name = Name;
            this.Description = Description;
            this.TargetedLevels = TargetedLevels;
        }

        public static List<clsSubject> GetAllSubjects()
        {
            DataTable dtSubjects = clsSubjectDataAccess.GetAllSubjects();
            List<clsSubject> Subjects = new List<clsSubject>();
            //clsSubject Subject;
            if (dtSubjects != null)
                foreach (DataRow s in dtSubjects.Rows)
                    Subjects.Add(new clsSubject((int)s["SubjectID"], (string)s["Name"], (string)s["Description"],
                                             (int)s["TargetedLevels"]));
            return Subjects;
        }

    }
}
