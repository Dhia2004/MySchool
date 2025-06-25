using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_DataAccessLayer
{
    static public class clsMedicalFileDataAccess
    {
        static public bool Exists(int StudentID)
        {
            bool Exists = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(*) FROM MedicalFiles WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                Exists = count > 0;
            }
            catch
            {
                Exists = false;
            }
            finally
            {
                connection.Close();
            }

            return Exists;
        }

        static public bool DeleteMedicalFile(int StudentID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "DELETE FROM MedicalFiles WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsDeleted = rowsAffected > 0;
            }
            catch
            {
                IsDeleted = false;
            }
            finally
            {
                connection.Close();
            }

            return IsDeleted;
        }

        static public DataTable GetAllMedicalFiles()
        {
            DataTable dtMedicalFiles = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "SELECT * FROM MedicalFiles";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dtMedicalFiles.Load(reader);
                else
                    dtMedicalFiles = null;

                reader.Close();
            }
            catch
            {
                dtMedicalFiles = null;
            }
            finally
            {
                connection.Close();
            }

            return dtMedicalFiles;
        }

        static public bool FindByStudentID(int StudentID,
                                           ref string BloodType,
                                           ref bool IsDisabled,
                                           ref string DisabilityDescription,
                                           ref bool WearsGlasses,
                                           ref bool HasUndergoneSurgery,
                                           ref bool HasChronicDisease,
                                           ref string ChronicDiseaseDescription,
                                           ref bool HasAllergy,
                                           ref string AllergyDescription,
                                           ref bool TakesMedication,
                                           ref string MedicationDescription,
                                           ref bool CanParticipateInSports,
                                           ref string Remarks,
                                           ref DateTime CreatedAt,
                                           ref DateTime? UpdatedAt,
                                           ref int CreatedByUserID,
                                           ref int? UpdatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM MedicalFiles WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    BloodType = reader["BloodType"]?.ToString() ?? string.Empty;
                    IsDisabled = reader["IsDisabled"] != DBNull.Value && (bool)reader["IsDisabled"];
                    DisabilityDescription = reader["DisabilityDescription"]?.ToString() ?? string.Empty;
                    WearsGlasses = reader["WearsGlasses"] != DBNull.Value && (bool)reader["WearsGlasses"];
                    HasUndergoneSurgery = reader["HasUndergoneSurgery"] != DBNull.Value && (bool)reader["HasUndergoneSurgery"];
                    HasChronicDisease = reader["HasChronicDisease"] != DBNull.Value && (bool)reader["HasChronicDisease"];
                    ChronicDiseaseDescription = reader["ChronicDiseaseDescription"]?.ToString() ?? string.Empty;
                    HasAllergy = reader["HasAllergy"] != DBNull.Value && (bool)reader["HasAllergy"];
                    AllergyDescription = reader["AllergyDescription"]?.ToString() ?? string.Empty;
                    TakesMedication = reader["TakesMedication"] != DBNull.Value && (bool)reader["TakesMedication"];
                    MedicationDescription = reader["MedicationDescription"]?.ToString() ?? string.Empty;
                    CanParticipateInSports = reader["CanParticipateInSports"] != DBNull.Value && (bool)reader["CanParticipateInSports"];
                    Remarks = reader["Remarks"]?.ToString() ?? string.Empty;
                    CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : DateTime.MinValue;
                    UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null;
                    CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? (int)reader["CreatedByUserID"] : 0;
                    UpdatedByUserID = reader["UpdatedByUserID"] != DBNull.Value ? (int?)reader["UpdatedByUserID"] : null;
                }

                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        static public int InsertMedicalFile(int StudentID,
                                            string BloodType,
                                            bool IsDisabled,
                                            string DisabilityDescription,
                                            bool WearsGlasses,
                                            bool HasUndergoneSurgery,
                                            bool HasChronicDisease,
                                            string ChronicDiseaseDescription,
                                            bool HasAllergy,
                                            string AllergyDescription,
                                            bool TakesMedication,
                                            string MedicationDescription,
                                            bool CanParticipateInSports,
                                            string Remarks,
                                            int CreatedByUserID)
        {
            int InsertedID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO MedicalFiles
                        (StudentID, BloodType, IsDisabled, DisabilityDescription,
                         WearsGlasses, HasUndergoneSurgery, HasChronicDisease, ChronicDiseaseDescription,
                         HasAllergy, AllergyDescription, TakesMedication, MedicationDescription,
                         CanParticipateInSports, Remarks, CreatedByUserID)
                        VALUES
                        (@StudentID, @BloodType, @IsDisabled, @DisabilityDescription,
                         @WearsGlasses, @HasUndergoneSurgery, @HasChronicDisease, @ChronicDiseaseDescription,
                         @HasAllergy, @AllergyDescription, @TakesMedication, @MedicationDescription,
                         @CanParticipateInSports, @Remarks, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@IsDisabled", IsDisabled);
            command.Parameters.AddWithValue("@DisabilityDescription", DisabilityDescription);
            command.Parameters.AddWithValue("@WearsGlasses", WearsGlasses);
            command.Parameters.AddWithValue("@HasUndergoneSurgery", HasUndergoneSurgery);
            command.Parameters.AddWithValue("@HasChronicDisease", HasChronicDisease);
            command.Parameters.AddWithValue("@ChronicDiseaseDescription", ChronicDiseaseDescription);
            command.Parameters.AddWithValue("@HasAllergy", HasAllergy);
            command.Parameters.AddWithValue("@AllergyDescription", AllergyDescription);
            command.Parameters.AddWithValue("@TakesMedication", TakesMedication);
            command.Parameters.AddWithValue("@MedicationDescription", MedicationDescription);
            command.Parameters.AddWithValue("@CanParticipateInSports", CanParticipateInSports);
            command.Parameters.AddWithValue("@Remarks", Remarks);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    InsertedID = id;
                }
            }
            catch
            {
                InsertedID = -1;
            }
            finally
            {
                connection.Close();
            }

            return InsertedID;
        }

        static public bool UpdateMedicalFile(int StudentID,
                                             string BloodType,
                                             bool IsDisabled,
                                             string DisabilityDescription,
                                             bool WearsGlasses,
                                             bool HasUndergoneSurgery,
                                             bool HasChronicDisease,
                                             string ChronicDiseaseDescription,
                                             bool HasAllergy,
                                             string AllergyDescription,
                                             bool TakesMedication,
                                             string MedicationDescription,
                                             bool CanParticipateInSports,
                                             string Remarks,
                                             int UpdatedByUserID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE MedicalFiles
                         SET BloodType = @BloodType,
                             IsDisabled = @IsDisabled,
                             DisabilityDescription = @DisabilityDescription,
                             WearsGlasses = @WearsGlasses,
                             HasUndergoneSurgery = @HasUndergoneSurgery,
                             HasChronicDisease = @HasChronicDisease,
                             ChronicDiseaseDescription = @ChronicDiseaseDescription,
                             HasAllergy = @HasAllergy,
                             AllergyDescription = @AllergyDescription,
                             TakesMedication = @TakesMedication,
                             MedicationDescription = @MedicationDescription,
                             CanParticipateInSports = @CanParticipateInSports,
                             Remarks = @Remarks,
                             UpdatedAt = GETDATE(),
                             UpdatedByUserID = @UpdatedByUserID
                         WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@IsDisabled", IsDisabled);
            command.Parameters.AddWithValue("@DisabilityDescription", DisabilityDescription);
            command.Parameters.AddWithValue("@WearsGlasses", WearsGlasses);
            command.Parameters.AddWithValue("@HasUndergoneSurgery", HasUndergoneSurgery);
            command.Parameters.AddWithValue("@HasChronicDisease", HasChronicDisease);
            command.Parameters.AddWithValue("@ChronicDiseaseDescription", ChronicDiseaseDescription);
            command.Parameters.AddWithValue("@HasAllergy", HasAllergy);
            command.Parameters.AddWithValue("@AllergyDescription", AllergyDescription);
            command.Parameters.AddWithValue("@TakesMedication", TakesMedication);
            command.Parameters.AddWithValue("@MedicationDescription", MedicationDescription);
            command.Parameters.AddWithValue("@CanParticipateInSports", CanParticipateInSports);
            command.Parameters.AddWithValue("@Remarks", Remarks);
            command.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsUpdated = rowsAffected > 0;
            }
            catch
            {
                IsUpdated = false;
            }
            finally
            {
                connection.Close();
            }

            return IsUpdated;
        }
    }

}

