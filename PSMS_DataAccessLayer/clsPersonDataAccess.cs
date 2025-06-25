using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace PSMS_DataAccessLayer
{
    static public class clsPersonDataAccess
    {
        static public bool FindByID(int PersonID, ref string NationalID,
                                    ref string FirstName, ref string LastName,
                                    ref DateTime DateOfBirth, ref char Gender,
                                    ref string Address, ref DateTime JoinDate, ref string PhoneNumber,
                                    ref string Email,ref string ImagePath, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Persons
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

                    NationalID = (string)reader["NationalID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["BirthDate"];
                    Gender = Convert.ToChar(reader["Gender"]);
                    Address = (string)reader["Address"];
                    JoinDate = (DateTime)reader["JoinDate"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = (string)reader["Email"];

                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;


                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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

        static public bool FindByNationalNo(string NationalID,ref int PersonID,
                                    ref string FirstName, ref string LastName,
                                    ref DateTime DateOfBirth, ref char Gender,
                                    ref string Address, ref DateTime JoinDate, ref string PhoneNumber,
                                    ref string Email, ref string ImagePath, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Persons
                             WHERE NationalID = @NationalID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["BirthDate"];
                    Gender = Convert.ToChar(reader["Gender"]);
                    Address = (string)reader["Address"];
                    JoinDate = (DateTime)reader["JoinDate"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Email = (string)reader["Email"];

                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;


                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

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

        //static public bool FindByDriverID(ref int PersonID, ref string NationalNo,
        //                            ref string FirstName, ref string SecondName,
        //                            ref string ThirdName, ref string LastName,
        //                            ref DateTime DateOfBirth, ref bool Gendor,
        //                            ref string Address, ref string Phone, ref string Email,
        //                            ref int NationalityCountryID, ref string ImagePath)
        //{
        //    bool IsFound = false;
        //    SqlConnection connection = new SqlConnection(DataAccressSettings.ConnectionString);
        //    string query = @"SELECT * FROM Drivers
        //                     WHERE PersonID = @PersonID";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@PersonID", PersonID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            IsFound = true;

        //            NationalNo = (string)reader["NationalNo"];
        //            FirstName = (string)reader["FirstName"];
        //            SecondName = (string)reader["SecondName"];
        //            ThirdName = (string)reader["ThirdName"];
        //            LastName = (string)reader["LastName"];
        //            DateOfBirth = (DateTime)reader["DateOfBirth"];
        //            Gendor = Convert.ToBoolean(reader["Gendor"]);
        //            Address = (string)reader["Address"];
        //            Phone = (string)reader["Phone"];
        //            if (reader["Email"] != DBNull.Value)
        //                Email = (string)reader["Email"];

        //            else Email = "No Email";

        //            NationalityCountryID = (int)reader["NationalityCountryID"];
        //            if (reader["ImagePath"] != DBNull.Value)
        //                ImagePath = (string)reader["ImagePath"];
        //            else
        //                ImagePath = "";

        //        }
        //        else
        //            IsFound = false;

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        IsFound = false;
        //    }
        //    finally { connection.Close(); }

        //    return IsFound;

        //}

        static public int AddPerson(string NationalID,string FirstName,string LastName,
                                     DateTime DateOfBirth, char Gender, string Address, DateTime JoinDate,
                                     string PhoneNumber,string Email,string ImagePath,int CreatedByUserID)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Persons
                             VALUES (@NationalID,
                                     @FirstName,
                                     @LastName,
                                     @DateOfBirth,
                                     @Gender,
                                     @Address,
                                     @JoinDate,  
                                     @PhoneNumber,
                                     @ImagePath,
                                     @CreatedByUserID,
                                     @Email);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            if (CreatedByUserID == -1)
                command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@Email", Email);

           
            

           

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }
            return PersonID;
        }

        static public bool Update(int PersonID, string NationalID,string  FirstName,string LastName,
                                     DateTime DateOfBirth,char Gender,string Address,DateTime JoinDate,
                                     string PhoneNumber, string Email, string ImagePath,int CreatedByUserID)

        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Persons
                             SET NationalID = @NationalID,
                                  FirstName = @FirstName,
                                  LastName = @LastName,
                                  DateOfBirth = @DateOfBirth,
                                  Gender = @Gender,
                                  Address = @Address,
                                  JoinDate = @JoinDate,
                                  PhoneNumber = @PhoneNumber,
                                  Email = @Email,
                                  ImagePath = @ImagePath
                                  CreatedByUserID = @CreatedByUserID
                             WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            
            command.Parameters.AddWithValue("@Email", Email);
           

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            if (CreatedByUserID == -1)
                command.Parameters.AddWithValue("@CreatedByUserID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        static public bool Delete(int PersonID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Persons
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

            return RowsAffrected > 0;
        }

        static public bool Delete(string NationalID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM People
                             WHERE NationalID = @NationalID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                RowsAffrected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { RowsAffrected = 0; }
            finally { connection.Close(); }

            return (RowsAffrected > 0);
        }

        static public bool IsNationalIDExist(string NationalID)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT Y = 'Y' FROM People
                             WHERE NationalID = @NationalID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);
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

        static public DataTable GetAllPersons()
        {
            DataTable dtPersons = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM People";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtPersons.Load(reader);
                else
                    dtPersons = null;
            }
            catch (Exception ex)
            {
                dtPersons = null;
            }
            finally { connection.Close(); }

            return dtPersons;
        }


        static public int GetPersonIDByNationalID(string NationalID)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT PersonID FROM Persons
                             WHERE NationalID = @NationalID";
         
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalID", NationalID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex) { PersonID = -1; }
            finally { connection.Close(); }
            return PersonID;
        }
    }
}
