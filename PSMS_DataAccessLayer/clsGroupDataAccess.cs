using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsGroupDataAccess
    {
        static public bool GetGroupByID(int groupID, ref string name, ref string description, ref int sectionID, ref int maxSeatsNumber, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT *
                             FROM Groups
                             WHERE GroupID = @GroupID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@GroupID", groupID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["Name"].ToString();
                    description = reader["Description"].ToString();
                    sectionID = Convert.ToInt32(reader["SectionID"]);
                    maxSeatsNumber = Convert.ToInt32(reader["MaxSeats"]);
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


        public static int AddNewGroup(string Name,string Description,int SectionID,int MaxSeats,
                                      int CreatedByUserID)
        {
            int GroupID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Groups
                             VALUES (@Name,
                                     @Description,
                                     @SectionID,
                                     @MaxSeats,
                                     @CreatedByUserID
                                     );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);



            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@SectionID", SectionID);
            command.Parameters.AddWithValue("@MaxSeats", MaxSeats);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    GroupID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                GroupID = -1;
            }
            finally
            {
                connection.Close();
            }
            return GroupID;
        }
        public static bool UpdateGroup(int GroupID,string Name, string Description,int MaxSeats)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Groups
                             SET 
                                      Name = @Name,
                                      Description = @Description,
                                      MaxSeatsNumber = @MaxSeats
                              WHERE GroupID = @GroupID";
     

            SqlCommand command = new SqlCommand(query, connection);



            command.Parameters.AddWithValue("@GroupID", GroupID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MaxSeats", MaxSeats);


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

        static public DataTable fetchGroupssBatch(int SectionID,int PageNumber)
        {

            DataTable dtGroups = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
                             SET @PageNumber = @@PageNumber;
                             SET @RowsPerPage = 9;

                             SELECT *
                             FROM Groups
                             WHERE SectionID = @SectionID   
                             order by GroupID
                             OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                             FETCH NEXT @RowsPerPage ROWS ONLY;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@@PageNumber", PageNumber);
            command.Parameters.AddWithValue("@SectionID", SectionID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtGroups.Load(reader);
                else
                    dtGroups = null;
            }
            catch (Exception ex)
            {
                dtGroups = null;
            }
            finally { connection.Close(); }

            return dtGroups;
        }

        static public DataTable GetAllGroupsBySectionID(int SectionID)
        {
            DataTable dtSubjects = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Groups WHERE SectionID = @SectionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SectionID", SectionID);



            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtSubjects.Load(reader);
                else
                    dtSubjects = null;
            }
            catch (Exception ex)
            {
                dtSubjects = null;
            }
            finally { connection.Close(); }

            return dtSubjects;
        }

        static public bool GetGroupByName(string Name, ref int GroupID, ref string Description, ref int SectionID,
                ref int MaxSeatsNumber, ref int CreatedByUserID) 
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Groups
                             WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    GroupID = (int)reader["GroupID"];
                    Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : string.Empty;
                    SectionID = (int)reader["SectionID"];
                    MaxSeatsNumber = (int)reader["MaxSeats"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

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
    }
}
