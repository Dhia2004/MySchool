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
    public class clsCourse
    {
        public int CourseID { get; private set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public int LevelID { get; set; }
        public int TotalSessions { get; set; }
        public float Price { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        enMode Mode;

        public clsCourse()
        {
            CourseID = -1;
            SubjectID = -1;
            TeacherID = -1;
            LevelID = -1;
            TotalSessions = 0;
            Price = 0.0f;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }
        private clsCourse(int courseID, int subjectID, int teacherID, int levelID, int totalSeassons, float price, int createdByUserID)
        {
            CourseID = courseID;
            SubjectID = subjectID;
            TeacherID = teacherID;
            LevelID = levelID;
            TotalSessions = totalSeassons;
            this.Price = price;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        public static clsCourse GetCourseByID(int CourseID)
        {
            int SubjectID = -1, TeacherID = -1, LevelID = -1, TotalSessions = 0, CreatedByUserID = -1;
            float Price = 0.0f;
            if (clsCourseDataAccess.GetCourseByID(CourseID, ref SubjectID, ref TeacherID, ref LevelID, ref TotalSessions
                ,ref CreatedByUserID,ref Price))
            {
                return new clsCourse(CourseID, SubjectID, TeacherID, LevelID, TotalSessions, Price, CreatedByUserID);
            }
            else
            {
                return null; // or throw an exception if preferred

            }
        }
        private bool _AddNewCourse()
        {
            CourseID = clsCourseDataAccess.AddNewCourse(SubjectID, TeacherID,
                LevelID, TotalSessions, Price, CreatedByUserID);
            return CourseID != -1;
        }

        private bool _UpdateCourse()
        {
            return clsCourseDataAccess.UpdateCourseInfo(CourseID, SubjectID, TeacherID,
                LevelID, TotalSessions, Price);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCourse())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateCourse();
                default:
                    throw new InvalidOperationException("Invalid mode for saving course.");
            }


        }

        static public List<clsCourse> ConvertCoursesRecordsToObjects(DataTable dtCourses)
        {
            List<clsCourse> Courses = new List<clsCourse>();
            clsCourse Course;
            if (dtCourses == null || dtCourses.Rows.Count == 0)
            {
                return Courses; // Return an empty list if no records found
            }
            foreach (DataRow s in dtCourses.Rows)
            {
                Course = new clsCourse((int)s["CourseID"], (int)s["SubjectID"], (int)s["TeacherID"],
                                        (int)s["Level_ID"], (int)s["TotalSessions"], (float)(double)s["Price"],
                                        (int)s["CreatedByUserID"]);

                Courses.Add(Course);
            }
            return Courses;



        }

        static public List<clsCourse> fetchCoursesBatch(int PageNumber)
        {

            DataTable dt = clsCourseDataAccess.fetchCoursesBatch(PageNumber);
            
            return ConvertCoursesRecordsToObjects(dt);



        }

        static public List<clsCourse> GetAllCoursesAsObjects()
        {
            DataTable dt = clsCourseDataAccess.GetAllCourses();
            return ConvertCoursesRecordsToObjects(dt);
        }

        static public List<clsCourse> GetAllCoursesAsObjectsByLevel(int LevelID)
        {
            DataTable dt = clsCourseDataAccess.GetAllCoursesByLevel(LevelID);
            return ConvertCoursesRecordsToObjects(dt);
        }

        static public List<clsCourse> GetAllCoursesBySubjectAndLevelAsObjects(int SubjectID, int LevelID)
        {
            DataTable dt = clsCourseDataAccess.GetAllCoursesBySubjectAndLevel(SubjectID, LevelID);
            return ConvertCoursesRecordsToObjects(dt);
        }
    }
}
