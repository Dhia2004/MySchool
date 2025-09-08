using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsSubscriptionDataAccess
    {
        static public int AddNewSubscription(int studentID, int courseID, int courseSec_ID,
            int totalSessions, int remainingSessions, DateTime startDate, DateTime endDate,
            bool isActive, string notes, int createdByUserID, bool isPaid)
        {
            int SubscriptionID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Subscriptions
                             VALUES (@studentID,
                                        @courseID,
                                        @courseSec_ID,
                                        @totalSessions,
                                        @remainingSessions,
                                        @startDate,
                                        @endDate,
                                        @isActive,
                                        @notes,
                                        @createdByUserID,
                                        @isPaid
                                     );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@courseID", courseID);
            command.Parameters.AddWithValue("@courseSec_ID", courseSec_ID);
            command.Parameters.AddWithValue("@totalSessions", totalSessions);
            command.Parameters.AddWithValue("@remainingSessions", remainingSessions);
            command.Parameters.AddWithValue("@startDate", startDate);


            if (endDate == DateTime.MinValue)
                command.Parameters.AddWithValue("@endDate", DBNull.Value);
            else
                command.Parameters.AddWithValue("@endDate", endDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            if (string.IsNullOrEmpty(notes))
                command.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isPaid", isPaid);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    SubscriptionID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                SubscriptionID = -1;
            }
            finally
            {
                connection.Close();
            }
            return SubscriptionID;
        }

        static public bool UpdateSubscriptionInfo(int subscriptionID, int studentID, int courseID, int courseSec_ID,
            int totalSessions, int remainingSessions, DateTime startDate, DateTime endDate,
            bool isActive, string notes, bool isPaid)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Subscriptions
                             SET 
                                  StudentID = @studentID,
                                  CourseID = @courseID,
                                  CourseSec_ID = @courseSec_ID,
                                  TotalSessions = @totalSessions,
                                  RemainingSessions = @remainingSessions,
                                  StartDate = @startDate,
                                  EndDate = @endDate,
                                  IsActive = @isActive,
                                  Notes = @notes,
                                  IsPaid = @isPaid
                             WHERE SubscriptionID = @subscriptionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@subscriptionID", subscriptionID);
            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@courseID", courseID);
            command.Parameters.AddWithValue("@courseSec_ID", courseSec_ID);
            command.Parameters.AddWithValue("@totalSessions", totalSessions);
            command.Parameters.AddWithValue("@remainingSessions", remainingSessions);
            command.Parameters.AddWithValue("@startDate", startDate);
            if (endDate == DateTime.MinValue)
                command.Parameters.AddWithValue("@endDate", DBNull.Value);
            else
                command.Parameters.AddWithValue("@endDate", endDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            if (string.IsNullOrEmpty(notes))
                command.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@notes", notes);
            command.Parameters.AddWithValue("@isPaid", isPaid);
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0;
        }

        static public DataTable fetchSubscriptionsBatch(int PageNumber)
        {

            DataTable dtSubscriptions = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
                             SET @PageNumber = @@PageNumber;
                             SET @RowsPerPage = 9;

                             SELECT *
                             FROM Subscriptions
                             order by Subscription_ID
                             OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                             FETCH NEXT @RowsPerPage ROWS ONLY;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@@PageNumber", PageNumber);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtSubscriptions.Load(reader);
                else
                    dtSubscriptions = null;
            }
            catch (Exception ex)
            {
                dtSubscriptions = null;
            }
            finally { connection.Close(); }

            return dtSubscriptions;
        }

        static public bool DeleteSubscription(int SubscriptionID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Subscriptions WHERE SubscriptionID = @SubscriptionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0;
        }

        
        static public bool GetSubscriptionByID(int SubscriptionID, ref int studentID, ref int courseID, ref int courseSec_ID,
            ref int totalSessions, ref int remainingSessions, ref DateTime startDate, ref DateTime endDate,
            ref bool isActive, ref string notes, ref int createdByUserID, ref bool isPaid)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subscriptions WHERE SubscriptionID = @SubscriptionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    studentID = (int)reader["StudentID"];
                    courseID = (int)reader["CourseID"];
                    courseSec_ID = (int)reader["CourseSec_ID"];
                    totalSessions = (int)reader["TotalSessions"];
                    remainingSessions = (int)reader["RemainingSessions"];
                    startDate = (DateTime)reader["StartDate"];
                    endDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"] : DateTime.MinValue;
                    isActive = (bool)reader["IsActive"];
                    notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isPaid = (bool)reader["IsPaid"];
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }
            return IsFound;
        }

        static public DataTable GetAllSubscriptions()
        {
            DataTable dtSubscriptions = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subscriptions";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtSubscriptions.Load(reader);
                else
                    dtSubscriptions = null;
            }
            catch (Exception ex)
            {
                dtSubscriptions = null;
            }
            finally { connection.Close(); }
            return dtSubscriptions;
        }


        static public bool CheckExistingActiveSubscription(int studentID, int subjectID)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT count(*) FROM Subscriptions
                             JOIN Courses ON Subscriptions.Course_ID = Courses.CourseID
                             JOIN Subjects ON Courses.SubjectID = Subjects.SubjectID
                             WHERE Subscriptions.Student_ID = @studentID
                             AND Subjects.SubjectID = @subjectID
                             AND Subscriptions.IsActive = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@subjectID", subjectID);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                exists = false;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }

    }
}
