using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    public static class clsStudentDataAccess
    {

        static public bool FindByID(int StudentID, ref string FirstName,
                                    ref string LastName, ref DateTime DateOfBirth,
                                    ref char Gender, ref string Address,
                                    ref string PhoneNumber, ref DateTime JoinDate,
                                    ref int LevelID, ref string ImagePath, ref string Notes,
                                    ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Students
                             WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["BirthDate"];
                    Gender = Convert.ToChar(reader["Gender"]);
                    JoinDate = (DateTime)reader["JoinDate"];
                    LevelID = (int)reader["Level_ID"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";

                    if (reader["PhoneNumber"] != DBNull.Value)
                        PhoneNumber = (string)reader["PhoneNumber"];
                    else
                        PhoneNumber = "";

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";


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

        static public bool FindByNationalNo(string NationalNo, ref int PersonID,
                                    ref string FirstName, ref string SecondName,
                                    ref string ThirdName, ref string LastName,
                                    ref DateTime DateOfBirth, ref bool Gendor,
                                    ref string Address, ref string Phone, ref string Email,
                                    ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM People
                             WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToBoolean(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    //ImagePath = (string)reader["ImagePath"];

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

        static public int AddStudent(string FirstName, string LastName, DateTime DateOfBirth,
                          char Gender, string Address, string PhoneNumber, DateTime JoinDate, int LevelID,
                          string ImagePath, string Notes, bool IsActive, int CreatedByUserID)
        {
            int StudentID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Students
                             VALUES (@FirstName,
                                     @LastName,
                                     @DateOfBirth,
                                     @Gender,
                                     @Address,
                                     @PhoneNumber,
                                     @JoinDate,
                                     @LevelID,
                                     @IsActive,
                                     @Notes,
                                     @CreatedByUserID,
                                     @ImagePath
                                     );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
           
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@LevelID", LevelID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            

            if (Address != "")
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);

            if (PhoneNumber != "")
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            else
                command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);

            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

           if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
               command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    StudentID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                StudentID = -1;
            }
            finally
            {
                connection.Close();
            }
            return StudentID;
        }

        static public bool Update(int StudentID, string FirstName, string LastName, DateTime DateOfBirth,
                          char Gender, string Address, string PhoneNumber, DateTime JoinDate, int LevelID,
                          string ImagePath, string Notes, bool IsActive, int CreatedByUserID)

        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE Students
                             SET     FirstName = @FirstName,
                                     LastName = @LastName,
                                     BirthDate = @DateOfBirth,
                                     Gender = @Gender,
                                     Address = @Address,
                                     PhoneNumber = @PhoneNumber,
                                     JoinDate = @JoinDate,
                                     Level_ID = @LevelID,
                                     IsActive = @IsActive,
                                     Notes = @Notes,
                                     CreatedByUserID = @CreatedByUserID,
                                     ImagePath = @ImagePath
                             WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@JoinDate", JoinDate);
            command.Parameters.AddWithValue("@LevelID", LevelID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Address != "")
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);


            if (PhoneNumber != "")
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            else
                command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);


            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);


            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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

        static public bool Delete(int StudentID)
        {
            int RowsAffrected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Students
                             WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                RowsAffrected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { RowsAffrected = 0; }
            finally { connection.Close(); }

            return RowsAffrected > 0;
        }

        

        

        static public DataTable GetAllStudents()
        {
            DataTable dtPersons = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Students";

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


        static public int GetPersonIDByNationalNo(string NationalNo)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT PersonID FROM People
                             WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        static public DataTable fetchStudentBatch(int PageNumber)
        {

            DataTable dtPersons = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"DECLARE @PageNumber AS INT, @RowsPerPage AS INT;
                             SET @PageNumber = @@PageNumber;
                             SET @RowsPerPage = 9;

                             SELECT *
                             FROM Students
                             order by StudentID
                             OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                             FETCH NEXT @RowsPerPage ROWS ONLY;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@@PageNumber", PageNumber);

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
    }
}
