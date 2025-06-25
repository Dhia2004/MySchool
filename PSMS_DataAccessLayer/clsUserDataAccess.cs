using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PSMS_DataAccessLayer
{
    public class clsUserDataAccess
    {
        static public bool FindByUserID(int UserID, ref int PersonID,
                                        ref string UserName, ref string Password,ref int Permessions,
                                        ref int CreatedByUserID,
                                        ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Users
                             WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permessions = (int)reader["Permessions"];
                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;

                    IsActive = Convert.ToBoolean(reader["IsActive"]);

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

        static public bool FindByPersonID(ref int UserID, int PersonID,
                                        ref string UserName, ref string Password,ref int Permessions,ref int CreatedByUserID, ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Users
                             WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permessions = (int)reader["Permessions"];
                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;
                    IsActive = Convert.ToBoolean(reader["IsActive"]);

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



        static public bool FindByUserName(ref int UserID, ref int PersonID,
                                        string UserName, ref string Password,
                                        ref int Permessions,
                                        ref int CreatedByUserID,
                                        ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Users
                             WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    Permessions = (int)reader["Permessions"];
                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;
                    IsActive = Convert.ToBoolean(reader["IsActive"]);

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


        static public int AddUser(int PersonID, string UserName, string Password, int Permessions,
                                  int CreatedByUserID,
                                  bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users
                             VALUES (@PersonID,
                                     @UserName,
                                     @Password,
                                     @Permessions,   
                                     @IsActive,
                                     @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permessions", Permessions);
            if (CreatedByUserID == -1)
                command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (IsActive)
                command.Parameters.AddWithValue("@IsActive", 1);
            else
                command.Parameters.AddWithValue("@IsActive", 0);



            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    UserID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }
            return UserID;
        }

        static public bool Update(int UserID, string UserName, string Password,int Permessions,
                                  int CreatedByUserID, bool IsActive)

        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Users
                             SET UserName = @UserName,
                                  Password = @Password,
                                  Permessions = @Permessions,
                                  IsActive = @IsActive          
                             WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permessions", Permessions);

            if (CreatedByUserID == -1)
                command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (IsActive)
                command.Parameters.AddWithValue("@IsActive", 1);
            else
                command.Parameters.AddWithValue("@IsActive", 0);

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

        static public bool Delete(int UserID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Users
                             WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                RowsAffrected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { RowsAffrected = 0; }
            finally { connection.Close(); }

            return RowsAffrected > 0;
        }

        static public bool Delete(string PersonID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Users
                             WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RowsAffrected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { RowsAffrected = 0; }
            finally { connection.Close(); }

            return (RowsAffrected > 0);
        }

        static public bool IsUserNameExist(string UserName)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT Y = 'Y' FROM Users
                             WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null)
                    IsExist = true;

                else
                    IsExist = false;

            }
            catch (Exception ex) { IsExist = false; }
            finally { connection.Close(); }

            return IsExist;
        }

        static public DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID,Users.PersonID,
                                    People.FirstName + ' ' +
                                    People.SecondName + ' ' +
                                    People.ThirdName + ' ' +
                                    People.LastName as FullName ,
                                    Users.UserName,Users.IsActive        
                             FROM Users JOIN People 
                             ON Users.PersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtUsers.Load(reader);
                else
                    dtUsers = null;
            }
            catch (Exception ex)
            {
                dtUsers = null;
            }
            finally { connection.Close(); }

            return dtUsers;
        }

        static public bool ChangePassword(int UserID, string Password)
        {
            int IsDone = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"Update Users
                             SET Password = @Password
                             WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                IsDone = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                IsDone = 0;

            }
            finally { connection.Close(); }
            return IsDone > 0;


        }

    }
}
