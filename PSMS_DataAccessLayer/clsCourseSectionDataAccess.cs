using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PSMS_DataAccessLayer
{
    static public class clsCourseSectionDataAccess
    {
        public static bool GetCourseSectionByID(int courseSecID, ref int courseID, ref int sectionID, ref int groupID,
            ref string day, ref string time, ref int numberOfSeats, ref int remainingSeats, ref string notes,
            ref bool status, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT *
                             FROM CourseSections
                             WHERE CourseSec_ID = @CourseSecID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseSecID", courseSecID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    courseID = reader.GetInt32(reader.GetOrdinal("Course_ID"));
                    sectionID = reader.GetInt32(reader.GetOrdinal("Section_ID"));
                    groupID = reader.GetInt32(reader.GetOrdinal("Group_ID"));
                    day = reader.GetString(reader.GetOrdinal("Day"));
                    time = reader.GetString(reader.GetOrdinal("Time"));
                    numberOfSeats = reader.GetInt32(reader.GetOrdinal("NumberOfSeats"));
                    remainingSeats = reader.GetInt32(reader.GetOrdinal("RemainingSeats"));
                    notes = reader.GetString(reader.GetOrdinal("Notes"));
                    status = reader.GetBoolean(reader.GetOrdinal("Status"));
                    createdByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public static int AddNewCourseSection(int courseID, int sectionID, int groupID, string day,
            string time, int numberOfSeats, int remainingSeats, string notes, bool status, int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO CoursesSection (Course_ID, Section_ID, Group_ID, Day, Time,
                                NumberOfSeats, RemainingSeats, Notes, Status, CreatedByUserID)
                             VALUES (@CourseID, @SectionID, @GroupID, @Day, @Time,
                                @NumberOfSeats, @RemainingSeats, @Notes, @Status, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseID", courseID);
            command.Parameters.AddWithValue("@SectionID", sectionID);
            command.Parameters.AddWithValue("@GroupID", groupID);
            command.Parameters.AddWithValue("@Day", day);
            command.Parameters.AddWithValue("@Time", time);
            command.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
            command.Parameters.AddWithValue("@RemainingSeats", remainingSeats);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            try
            {
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return -1; // Indicating failure
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool UpdateCourseSection(int courseSecID, int courseID, int sectionID, int groupID, string day,
            string time, int numberOfSeats, int remainingSeats, string notes, bool status)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE CoursesSection
                             SET Course_ID = @CourseID,
                                 Section_ID = @SectionID,
                                 Group_ID = @GroupID,
                                 Day = @Day,
                                 Time = @Time,
                                 NumberOfSeats = @NumberOfSeats,
                                 RemainingSeats = @RemainingSeats,
                                 Notes = @Notes,
                                 Status = @Status
                             WHERE CourseSec_ID = @CourseSecID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseSecID", courseSecID);
            command.Parameters.AddWithValue("@CourseID", courseID);
            command.Parameters.AddWithValue("@SectionID", sectionID);
            command.Parameters.AddWithValue("@GroupID", groupID);
            command.Parameters.AddWithValue("@Day", day);
            command.Parameters.AddWithValue("@Time", time);
            command.Parameters.AddWithValue("@NumberOfSeats", numberOfSeats);
            command.Parameters.AddWithValue("@RemainingSeats", remainingSeats);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@Status", status);
            try
            {
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCourseSection(int courseSecID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM CourseSections
                             WHERE CourseSec_ID = @CourseSecID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseSecID", courseSecID);
            try
            {
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public static System.Data.DataTable GetAllCourseSections()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CourseSections";
            SqlCommand command = new SqlCommand(query, connection);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtCourseSections);
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        public static System.Data.DataTable GetAllCourseSectionsByCourseID(int courseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CoursesSection WHERE Course_ID = @CourseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseID", courseID);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCourseSections.Load(reader);
                }
                else
                {
                    dtCourseSections = null;
                }
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        public static System.Data.DataTable GetCourseSectionsBySectionID(int sectionID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CourseSections WHERE Section_ID = @SectionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SectionID", sectionID);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtCourseSections);
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        public static System.Data.DataTable GetCourseSectionsByGroupID(int groupID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CourseSections WHERE Group_ID = @GroupID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@GroupID", groupID);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtCourseSections);
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        public static System.Data.DataTable GetCourseSectionsByStatus(bool status)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CourseSections WHERE Status = @Status";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", status);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtCourseSections);
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        public static System.Data.DataTable GetCourseSectionsByCreatedByUserID(int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CourseSections WHERE CreatedByUserID = @CreatedByUserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            System.Data.DataTable dtCourseSections = new System.Data.DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtCourseSections);
            }
            catch (Exception ex)
            {
                dtCourseSections = null;
            }
            finally
            {
                connection.Close();
            }
            return dtCourseSections;
        }

        

    }
}
