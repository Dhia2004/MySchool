using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsSchoolInfoDataAccess
    {
        static public bool GetSchoolInfo(ref string Name,ref int OwnerID,ref DateTime SchoolEstablishedYear,
            ref string SchoolFix,ref string SecondaryFix,ref string SchoolEmail,ref string Address,
            ref string LogoPath,ref string Descreption)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM SchoolInfo";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Name = (string)reader["Name"];
                    OwnerID = (int)reader["OwnerID"];
                    SchoolEstablishedYear = (DateTime)reader["SchoolEstablishedYear"];
                    SchoolFix = (string)reader["FixNumber"];

                    if (reader["SecondaryFix"] != DBNull.Value)
                        SecondaryFix = (string)reader["SecondaryFix"];
                    else
                        SecondaryFix = string.Empty;


                    SchoolEmail = (string)reader["Email"];
                    Address = (string)reader["Address"];

                    if (reader["LogoPath"] != DBNull.Value)
                        LogoPath = (string)reader["LogoPath"];
                    else
                        LogoPath = string.Empty;

                    if (reader["Descreption"] != DBNull.Value)
                        Descreption = (string)reader["Descreption"];
                    else
                        Descreption = string.Empty;

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

        static public bool InsertSchoolInfo(string Name, int OwnerID, DateTime SchoolEstablishedYear,
            string SchoolFix, string SecondaryFix, string SchoolEmail, string Address,
            string LogoPath, string Descreption)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO SchoolInfo
                             (Name, OwnerID, SchoolEstablishedYear, FixNumber, SecondaryFix, Email, Address,
                              LogoPath, Descreption)
                             VALUES
                             (@Name, @OwnerID, @SchoolEstablishedYear, @FixNumber, @SecondaryFix, @Email,
                             @Address, @LogoPath, @Descreption);";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@OwnerID", OwnerID);
            command.Parameters.AddWithValue("@SchoolEstablishedYear", SchoolEstablishedYear);
            command.Parameters.AddWithValue("@FixNumber", SchoolFix);
            if(string.IsNullOrEmpty(SecondaryFix))
                command.Parameters.AddWithValue("@SecondaryFix", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SecondaryFix", SecondaryFix);

            command.Parameters.AddWithValue("@Email", SchoolEmail);
            command.Parameters.AddWithValue("@Address", Address);
            if (string.IsNullOrEmpty(LogoPath))
                command.Parameters.AddWithValue("@LogoPath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@LogoPath", LogoPath);

            if (string.IsNullOrEmpty(Descreption))
                command.Parameters.AddWithValue("@Descreption", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Descreption", Descreption);

            try
            {
                connection.Open();
                
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    IsUpdated = true;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
            }
            finally { connection.Close(); }
            return IsUpdated;
        }


        static public bool UpdateInfo(string Name, int OwnerID, DateTime SchoolEstablishedYear,
            string SchoolFix, string SecondaryFix, string SchoolEmail, string Address,
            string LogoPath, string Descreption)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE SchoolInfo
                             SET Name = @Name,
                                 OwnerID = @OwnerID,
                                 SchoolEstablishedYear = @SchoolEstablishedYear,
                                 FixNumber = @FixNumber,
                                 SecondaryFix = @SecondaryFix,
                                 Email = @Email,
                                 Address = @Address,
                                 LogoPath = @LogoPath,
                                 Descreption = @Descreption";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@OwnerID", OwnerID);
            command.Parameters.AddWithValue("@SchoolEstablishedYear", SchoolEstablishedYear);
            command.Parameters.AddWithValue("@FixNumber", SchoolFix);
            if (string.IsNullOrEmpty(SecondaryFix))
                command.Parameters.AddWithValue("@SecondaryFix", DBNull.Value);
            else
                command.Parameters.AddWithValue("@SecondaryFix", SecondaryFix);

            command.Parameters.AddWithValue("@Email", SchoolEmail);
            command.Parameters.AddWithValue("@Address", Address);
            if (string.IsNullOrEmpty(LogoPath))
                command.Parameters.AddWithValue("@LogoPath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@LogoPath", LogoPath);

            if (string.IsNullOrEmpty(Descreption))
                command.Parameters.AddWithValue("@Descreption", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Descreption", Descreption);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    IsUpdated = true;
            }
            catch (Exception ex)
            {
                IsUpdated = false;
            }
            finally { connection.Close(); }
            return IsUpdated;
        }



    }
}
