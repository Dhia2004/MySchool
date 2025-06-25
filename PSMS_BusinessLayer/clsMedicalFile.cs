using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsMedicalFile
    {
        public int MedicalFileID { get; private set; }
        public int StudentID { get; set; }

        public string BloodType { get; set; }

        public bool IsDisabled { get; set; }
        public string DisabilityDescription { get; set; }

        public bool WearsGlasses { get; set; }
        public bool HasUndergoneSurgery { get; set; }

        public bool HasChronicDisease { get; set; }
        public string ChronicDiseaseDescription { get; set; }

        public bool HasAllergy { get; set; }
        public string AllergyDescription { get; set; }

        public bool TakesMedication { get; set; }
        public string MedicationDescription { get; set; }

        public bool CanParticipateInSports { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int CreatedByUserID { get; set; }
        public int? UpdatedByUserID { get; set; }

        private enum enMode { AddNew, Update }
        private enMode Mode;

        public clsMedicalFile()
        {
            Mode = enMode.AddNew;
            MedicalFileID = -1;
            StudentID = -1;
            BloodType = "";
            IsDisabled = false;
            DisabilityDescription = "";
            WearsGlasses = false;
            HasUndergoneSurgery = false;
            HasChronicDisease = false;
            ChronicDiseaseDescription = "";
            HasAllergy = false;
            AllergyDescription = "";
            TakesMedication = false;
            MedicationDescription = "";
            CanParticipateInSports = true;
            Remarks = "";
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            CreatedByUserID = -1;
            UpdatedByUserID = null;
        }

        private clsMedicalFile(int medicalFileID, int studentID, string bloodType, bool isDisabled, string disabilityDescription,
                               bool wearsGlasses, bool hasUndergoneSurgery, bool hasChronicDisease, string chronicDiseaseDescription,
                               bool hasAllergy, string allergyDescription, bool takesMedication, string medicationDescription,
                               bool canParticipateInSports, string remarks, DateTime createdAt, DateTime? updatedAt,
                               int createdByUserID, int? updatedByUserID)
        {
            Mode = enMode.Update;

            MedicalFileID = medicalFileID;
            StudentID = studentID;
            BloodType = bloodType;
            IsDisabled = isDisabled;
            DisabilityDescription = disabilityDescription;
            WearsGlasses = wearsGlasses;
            HasUndergoneSurgery = hasUndergoneSurgery;
            HasChronicDisease = hasChronicDisease;
            ChronicDiseaseDescription = chronicDiseaseDescription;
            HasAllergy = hasAllergy;
            AllergyDescription = allergyDescription;
            TakesMedication = takesMedication;
            MedicationDescription = medicationDescription;
            CanParticipateInSports = canParticipateInSports;
            Remarks = remarks;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedByUserID = createdByUserID;
            UpdatedByUserID = updatedByUserID;
        }

        public static clsMedicalFile FindByStudentID(int studentID)
        {
            string bloodType = "", disabilityDescription = "", chronicDiseaseDescription = "",
                   allergyDescription = "", medicationDescription = "", remarks = "";
            bool isDisabled = false, wearsGlasses = false, hasUndergoneSurgery = false,
                 hasChronicDisease = false, hasAllergy = false, takesMedication = false, canParticipateInSports = true;

            DateTime createdAt = DateTime.MinValue;
            DateTime? updatedAt = null;
            int createdByUserID = -1;
            int? updatedByUserID = null;

            bool found = clsMedicalFileDataAccess.FindByStudentID(studentID, ref bloodType, ref isDisabled,
                ref disabilityDescription, ref wearsGlasses, ref hasUndergoneSurgery,
                ref hasChronicDisease, ref chronicDiseaseDescription,
                ref hasAllergy, ref allergyDescription,
                ref takesMedication, ref medicationDescription,
                ref canParticipateInSports, ref remarks,
                ref createdAt, ref updatedAt, ref createdByUserID, ref updatedByUserID);

            if (found)
            {
                return new clsMedicalFile(-1, studentID, bloodType, isDisabled, disabilityDescription,
                    wearsGlasses, hasUndergoneSurgery, hasChronicDisease, chronicDiseaseDescription,
                    hasAllergy, allergyDescription, takesMedication, medicationDescription,
                    canParticipateInSports, remarks, createdAt, updatedAt, createdByUserID, updatedByUserID);
            }

            return null;
        }

        private bool Add()
        {
            MedicalFileID = clsMedicalFileDataAccess.InsertMedicalFile(StudentID, BloodType, IsDisabled, DisabilityDescription,
                WearsGlasses, HasUndergoneSurgery, HasChronicDisease, ChronicDiseaseDescription,
                HasAllergy, AllergyDescription, TakesMedication, MedicationDescription,
                CanParticipateInSports, Remarks, CreatedByUserID);

            return MedicalFileID != -1;
        }

        private bool Update()
        {
            return clsMedicalFileDataAccess.UpdateMedicalFile(StudentID, BloodType, IsDisabled, DisabilityDescription,
                WearsGlasses, HasUndergoneSurgery, HasChronicDisease, ChronicDiseaseDescription,
                HasAllergy, AllergyDescription, TakesMedication, MedicationDescription,
                CanParticipateInSports, Remarks, UpdatedByUserID ?? -1);
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (Add())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                return Update();
            }
        }

        public static bool Delete(int studentID)
        {
            return clsMedicalFileDataAccess.DeleteMedicalFile(studentID);
        }

        public static bool Exists(int studentID)
        {
            return clsMedicalFileDataAccess.Exists(studentID);
        }

        public static DataTable GetAll()
        {
            return clsMedicalFileDataAccess.GetAllMedicalFiles();
        }

    }
}
