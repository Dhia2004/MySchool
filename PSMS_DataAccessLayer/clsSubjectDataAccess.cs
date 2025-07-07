using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsSubjectDataAccess
    {

        static public bool FindByName(string Name, ref int SubjectID, ref string Description, ref int TargetedLevels)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subjects WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    SubjectID = (int)reader["SubjectID"];
                    Description =  (string)reader["Description"];
                    TargetedLevels = (int)reader["TargetedLevels"];
                    
                }
                
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }

            return IsFound;
        }

        static public bool FindByID(int SubjectID, ref string Name, ref string Description, ref int TargetedLevels)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subjects WHERE SubjectID = @SubjectID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubjectID", SubjectID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    Name = (string)reader["Name"];
                    Description = (string)reader["Description"];
                    TargetedLevels = (int)reader["TargetedLevels"];

                    
                }
               
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally { connection.Close(); }
            return IsFound;
        }
        static public DataTable GetAllSubjects()
        {
            DataTable dtSubjects = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Subjects";

            SqlCommand command = new SqlCommand(query, connection);

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
    }
}
