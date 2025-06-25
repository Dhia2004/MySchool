using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    public static class clsLevelDataAccess
    {
        static public DataTable GetAllLevels()
        {
            DataTable dtLevels = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Levels";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtLevels.Load(reader);
                else
                    dtLevels = null;

                reader.Close();
            }
            catch (Exception ex) { dtLevels = null; }
            finally { connection.Close(); }

            return dtLevels;
        }
        static public bool FindByName(string Name,ref int Level_ID,ref string Descreption,ref int LevelCode)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Levels
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
                    Level_ID = (int)reader["Level_ID"];
                    Descreption = reader["Description"] != DBNull.Value ? (string)reader["Description"] : string.Empty;
                    LevelCode = (int)reader["LevelCode"];
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

        static public bool FindByID(int Level_ID, ref string Name,ref string Descrepotion, ref int LevelCode)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Levels
                             WHERE Level_ID = @Level_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Level_ID", Level_ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    Name = (string)reader["Name"];
                    Descrepotion = reader["Description"] != DBNull.Value ? (string)reader["Description"] : string.Empty;
                    LevelCode = (int)reader["LevelCode"];
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
