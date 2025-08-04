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
    static public class clsTeacherDataAccess
    {


        static public bool FindByTeacherID(int TeacherID, ref int PersonID, ref int SpecialityID, ref bool IsActive, ref int CraetedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Teachers
                             WHERE TeacherID = @TeacherID";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherID", TeacherID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = reader.GetInt32(reader.GetOrdinal("PersonID"));
                    SpecialityID = reader.GetInt32(reader.GetOrdinal("SpecialityID"));
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CraetedByUserID = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));



                }
                else
                    IsFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }

            return IsFound;
        }
        static public bool FindByPersonID(int PersonID, ref int TeacherID, ref int SpecialityID, ref bool IsActive, ref int CraetedByUserID)
        {
            // This method should implement the logic to retrieve teacher details by PersonID from the database
            // For now, we will return false to indicate that no data was found
            return false; // Placeholder for actual database retrieval logic
        }
       
        
        static public int AddNewTeacher(int PersonID, int SpecialityID, bool IsActive, int CraetedByUserID)
        {
           int TeacherID = -1;
           SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
           string query = @"INSERT INTO Teachers (PersonID, SpecialityID, IsActive, CreatedByUserID) 
                             VALUES (@PersonID, @SpecialityID, @IsActive, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();"; // Get the newly inserted TeacherID 

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@SpecialityID", SpecialityID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CraetedByUserID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    TeacherID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                TeacherID = -1; // Indicate failure
            }
            finally
            {
                connection.Close();
            }

            return TeacherID; // Placeholder for actual database insert logic
        }
        static public bool Update(int TeacherID, int SpecialityID, bool IsActive)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Teachers 
                             SET
                                 SpecialityID = @SpecialityID,
                                 IsActive = @IsActive
                             WHERE TeacherID = @TeacherID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherID", TeacherID);
            command.Parameters.AddWithValue("@SpecialityID", SpecialityID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                RowsAffected = 0; // Indicate failure
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0; // Return true if at least one row was updated

        }

        static public bool DeleteTeacher(int TeacherID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Teachers WHERE TeacherID = @TeacherID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherID", TeacherID);
            try
            {
                connection.Open();
                RowsAffrected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                RowsAffrected = 0; // Indicate failure
            }
            finally
            {
                connection.Close();
            }

            return RowsAffrected > 0; // Return true if at least one row was deleted
        }

        static public DataTable GetAllTeachersBySubject(int SubjectID)
        {
            DataTable dtAllTeachers = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Teachers
                             WHERE SpecialityID = @SubjectID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtAllTeachers.Load(reader);
                else
                    dtAllTeachers = null;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                dtAllTeachers = null; // Indicate failure
            }
            finally
            {
                connection.Close();
            }
            return dtAllTeachers; // Return the DataTable containing all teachers for the specified subject

        }



    }
}
