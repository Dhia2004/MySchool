using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsCourseDataAccess
    {
        static public int AddNewCourse(int SubjectID, int TeacherID, int Level_ID, int TotalSessions,
            float Price, int CreatedByUserID)
        {
            int CourseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Courses
                             VALUES (@SubjectID,
                                     @TeacherID,
                                     @LevelID,
                                     @TotalSessions,
                                     @Price,
                                     @CreatedByUserID
                                     );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@subjectID", SubjectID);
            command.Parameters.AddWithValue("@teacherID", TeacherID);
            command.Parameters.AddWithValue("@levelID", Level_ID);
            command.Parameters.AddWithValue("@TotalSessions", TotalSessions);
            command.Parameters.AddWithValue("@price", Price);
            command.Parameters.AddWithValue("@createdByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    CourseID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                CourseID = -1;
            }
            finally
            {
                connection.Close();
            }
            return CourseID;

        }

        static public bool UpdateCourseInfo(int CourseID,int SubjectID, int TeacherID, int Level_ID,
                                            int TotalSessions, float Price)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Courses
                             SET 
                                  SubjectID = @SubjectID,
                                  TeacherID = @TeacherID,
                                  Level_ID = @Level_ID,
                                  TotalSessions = @TotalSessions,
                                  Price = @Price
                             WHERE CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CourseID", CourseID);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);
            command.Parameters.AddWithValue("@TeacherID", TeacherID);
            command.Parameters.AddWithValue("@Level_ID", Level_ID);
            command.Parameters.AddWithValue("@TotalSessions", TotalSessions);
            command.Parameters.AddWithValue("@Price", Price);


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

        static public DataTable fetchCoursesBatch(int PageNumber)
        {

            DataTable dtCourses = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
                             SET @PageNumber = @@PageNumber;
                             SET @RowsPerPage = 9;

                             SELECT *
                             FROM Courses
                             order by CourseID
                             OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                             FETCH NEXT @RowsPerPage ROWS ONLY;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@@PageNumber", PageNumber);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtCourses.Load(reader);
                else
                    dtCourses = null;
            }
            catch (Exception ex)
            {
                dtCourses = null;
            }
            finally { connection.Close(); }

            return dtCourses;
        }
    }
}
