using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PSMS_BusinessLayer.clsCourseSection;

namespace PSMS_BusinessLayer
{
    public class clsSubscription
    {
        public int SubscriptionID { get; private set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int CourseSec_ID { get; set; }
        public int TotalSessions { get; set; }
        public int RemainingSessions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsPaid { get; set; }

        public clsStudent Student;
        public clsCourseSection CourseSection;
       
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }
        enMode Mode;

        public clsSubscription()
        {

            SubscriptionID = -1;
            StudentID = -1;
            CourseID = -1;
            CourseSec_ID = -1;
            TotalSessions = 0;
            RemainingSessions = 0;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            IsActive = true;
            Notes = string.Empty;
            CreatedByUserID = -1;
            IsPaid = false;
            Mode = enMode.AddNew;
        }

        public clsSubscription(int subscriptionID, int studentID, int courseID, int courseSec_ID, int totalSessions, int remainingSessions, DateTime startDate, DateTime endDate, bool isActive, string notes, int createdByUserID, bool isPaid)
        {
            SubscriptionID = subscriptionID;
            StudentID = studentID;
            CourseID = courseID;
            CourseSec_ID = courseSec_ID;
            TotalSessions = totalSessions;
            RemainingSessions = remainingSessions;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            IsPaid = isPaid;
            Mode = enMode.Update;

            Student = clsStudent.FindByID(StudentID);
            CourseSection = clsCourseSection.GetCourseSectionByID(CourseSec_ID);
            
        }

        public static clsSubscription GetSubscriptionInfoByID(int SubscriptionID)
        {

            int StudentID = -1, CourseID = -1, CourseSec_ID = -1, TotalSessions = 0, RemainingSessions = 0, CreatedByUserID = -1;
            DateTime StartDate = DateTime.MinValue, EndDate = DateTime.MinValue;
            bool IsActive = false, IsPaid = false;
            string Notes = string.Empty;
            if (clsSubscriptionDataAccess.GetSubscriptionByID(SubscriptionID, ref StudentID, ref CourseID, ref CourseSec_ID,
                ref TotalSessions, ref RemainingSessions, ref StartDate, ref EndDate, ref IsActive,
                ref Notes, ref CreatedByUserID, ref IsPaid))
            {
                return new  clsSubscription(SubscriptionID, StudentID, CourseID, CourseSec_ID, TotalSessions, RemainingSessions,
                    StartDate, EndDate, IsActive, Notes, CreatedByUserID, IsPaid);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewSubscription()
        {
            SubscriptionID = clsSubscriptionDataAccess.AddNewSubscription(StudentID, CourseID, CourseSec_ID,
                TotalSessions, RemainingSessions, StartDate, EndDate, IsActive, Notes, CreatedByUserID, IsPaid);
            return SubscriptionID != -1;
        }

        private bool _UpdateSubscription()
        {
            return clsSubscriptionDataAccess.UpdateSubscriptionInfo(SubscriptionID, StudentID, CourseID, CourseSec_ID,
                TotalSessions, RemainingSessions, StartDate, EndDate, IsActive, Notes, IsPaid);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubscription())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateSubscription();
                default:
                    throw new InvalidOperationException("Invalid mode for saving course.");
            }


        }

        static public List<clsSubscription> ConvertSubscriptionsRecordsToObjects(DataTable dtSubscriptions)
        {
            List<clsSubscription> Subscriptions = new List<clsSubscription>();
            clsSubscription Subscription;
            if (dtSubscriptions == null || dtSubscriptions.Rows.Count == 0)
            {
                return Subscriptions; // Return an empty list if no records found
            }
            foreach (DataRow s in dtSubscriptions.Rows)
            {
                Subscription = new clsSubscription((int)s["SubscriptionID"], (int)s["StudentID"], (int)s["CourseID"],
                                        (int)s["CourseSec_ID"], (int)s["TotalSessions"], (int)s["RemainingSessions"],
                                        (DateTime)s["StartDate"], s["EndDate"] != DBNull.Value ? (DateTime)s["EndDate"] : DateTime.MinValue, (bool)s["IsActive"],
                                        s["Notes"] == DBNull.Value ? string.Empty : (string)s["Notes"],
                                        (int)s["CreatedByUserID"], (bool)s["IsPaid"]);

                Subscriptions.Add(Subscription);
            }
            return Subscriptions;



        }

        static public List<clsSubscription> fetchSubscriptionsBatch(int PageNumber)
        {

            DataTable dt = clsSubscriptionDataAccess.fetchSubscriptionsBatch(PageNumber);

            return ConvertSubscriptionsRecordsToObjects(dt);



        }
        static public bool CheckExistingActiveSubscription(int studentID, int SubjectID)
        {
            return clsSubscriptionDataAccess.CheckExistingActiveSubscription(studentID, SubjectID);
        }

    }
}
