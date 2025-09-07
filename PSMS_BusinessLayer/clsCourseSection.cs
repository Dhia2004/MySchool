using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsCourseSection
    {
        public int CourseSecID { get; private set; }
        public int CourseID { get; set; }
        public int SectionID { get; set; }
        public int GroupID { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int NumberOfSeats { get; set; }
        public int RemainingSeats { get; set; }
        public string Notes { get; set; }
        public bool Status { get; set; }
        public int CreatedBuUserID { get; set; }

        public clsCourse Course;

        public clsSection Section;

        public clsGroup Group;

        public clsLevel Level;

        // Enum to define the mode of operation
        public enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        private enMode Mode;

        public clsCourseSection()
        {
            CourseSecID = -1;
            CourseID = -1;
            SectionID = -1;
            GroupID = -1;
            Day = string.Empty;
            Time = string.Empty;
            NumberOfSeats = 0;
            RemainingSeats = 0;
            Notes = string.Empty;
            Status = false;
            CreatedBuUserID = -1;
            Course = null;
            Section = null;
            Group = null;
            Level = null;
            Mode = enMode.AddNew; // Default mode is AddNew
        }
        private clsCourseSection(int courseSecID, int courseID, int sectionID, int groupID, string day, string time,
            int numberOfSeats, int remainingSeats, string notes, bool status, int createdBuUserID)
        {
            CourseSecID = courseSecID;
            CourseID = courseID;
            SectionID = sectionID;
            GroupID = groupID;
            Day = day;
            Time = time;
            NumberOfSeats = numberOfSeats;
            RemainingSeats = remainingSeats;
            Notes = notes;
            Status = status;
            CreatedBuUserID = createdBuUserID;

            Group = clsGroup.GetGroupByID(GroupID);
            Section = clsSection.GetSectionByID(SectionID);
            Course = clsCourse.GetCourseByID(CourseID);
            if (Course != null)
            {
                Level = clsLevel.GetLevelByID(Course.LevelID);
            }
            else
            {
                Level = null; // or handle the case where Course is null
            }

            Mode = enMode.Update; // This constructor is used for existing course sections, so the mode is Update

        }

        public static clsCourseSection GetCourseSectionByID(int courseSecID)
        {
            int courseID = -1, sectionID = -1, groupID = -1, numberOfSeats = 0, remainingSeats = 0, createdByUserID = -1;
            string day = string.Empty, time = string.Empty, notes = string.Empty;
            bool status = false;
            if (clsCourseSectionDataAccess.GetCourseSectionByID(courseSecID, ref courseID, ref sectionID,
                ref groupID, ref day, ref time, ref numberOfSeats, ref remainingSeats, ref notes,
                ref status, ref createdByUserID))
            {
                return new clsCourseSection(courseSecID, courseID, sectionID, groupID, day, time,
                    numberOfSeats, remainingSeats, notes, status, createdByUserID);
            }
            return null;


        }

        private bool _AddNew()
        {
            this.CourseSecID = clsCourseSectionDataAccess.AddNewCourseSection(CourseID, SectionID, GroupID, Day,
                Time, NumberOfSeats, RemainingSeats, Notes, Status, CreatedBuUserID);
            return this.CourseSecID != -1;
        }

        private bool _Update()
        {
            return clsCourseSectionDataAccess.UpdateCourseSection(CourseSecID, CourseID, SectionID, GroupID, Day,
                Time, NumberOfSeats, RemainingSeats, Notes, Status);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    throw new InvalidOperationException("Invalid mode for saving section.");
            }


        }

        public static List<clsCourseSection> ConvertCourseSectionsRecordsToObjects(System.Data.DataTable dtCourseSections)
        {
            List<clsCourseSection> courseSections = new List<clsCourseSection>();
            foreach (System.Data.DataRow row in dtCourseSections.Rows)
            {
                clsCourseSection courseSection = new clsCourseSection(
                    (int)row["CourseSec_ID"],
                    (int)row["Course_ID"],
                    (int)row["Section_ID"],
                    (int)row["Group_ID"],
                    row["Day"].ToString(),
                    row["Time"].ToString(),
                    (int)row["NumberOfSeats"],
                    (int)row["RemainingSeats"],
                    row["Notes"].ToString(),
                    (bool)row["Status"],
                    (int)row["CreatedByUserID"]
                );
                courseSections.Add(courseSection);
            }
            return courseSections;
        }


        public static List<clsCourseSection> GetAllCourseSections()
        {
            System.Data.DataTable dtCourseSections = clsCourseSectionDataAccess.GetAllCourseSections();
            return ConvertCourseSectionsRecordsToObjects(dtCourseSections);





        }

        public static List<clsCourseSection> GetAllCourseSectionsByCourseID(int courseID)
        {
            DataTable dtCourseSections = clsCourseSectionDataAccess.GetAllCourseSectionsByCourseID(courseID);
            return ConvertCourseSectionsRecordsToObjects(dtCourseSections);
        }
    }
}
