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
    static public class clsSectionDataAccess
    {
        public static int AddNewSection(string name, string description, int numberOfSeat, int createdByUserID)
        {
            int SectionID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Sections
                             VALUES (@name,
                                     @description,
                                     @numberOfSeat,
                                     @createdByUserID
                                     );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@numberOfSeat", numberOfSeat);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    SectionID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                SectionID = -1;
            }
            finally
            {
                connection.Close();
            }
            return SectionID;
        }
        public static bool UpdateSection(int sectionID, string name, string description, int numberOfSeat)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Sections
                             SET 
                                  Name = @Name,
                                  Description = @Description,
                                  NumberOfSeat = @NumberOfSeat
                             WHERE SectionID = @SectionID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@SectionID", sectionID);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@NumberOfSeat", numberOfSeat);



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

        static public bool GetSectionByID(int sectionID, ref string name, ref string description, ref int numberOfSeat, ref int createdByUserID)
        {
            
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT *
                             FROM Sections
                             WHERE SectionID = @SectionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SectionID", sectionID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["Name"].ToString();
                    description = reader["Description"].ToString();
                    numberOfSeat = Convert.ToInt32(reader["NumberOfSeats"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
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


        static public int GetGroupsCountBySectionID(int sectionID)
        {
            int GroupsCount = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*)
                             FROM Groups
                             WHERE SectionID = @SectionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SectionID", sectionID);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Count))
                {
                    GroupsCount = Count;
                }
            }
            catch (Exception ex)
            {
                GroupsCount = 0;
            }
            finally
            {
                connection.Close();
            }
            return GroupsCount;
        }

        static public DataTable fetchSectionsBatch(int PageNumber)
        {

            DataTable dtCourses = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
                             SET @PageNumber = @@PageNumber;
                             SET @RowsPerPage = 9;

                             SELECT *
                             FROM Sections
                             order by SectionID
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

        static public bool DeleteSection(int SectionID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Sections
                             WHERE SectionID = @SectionID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SectionID", SectionID);
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
    }
}
