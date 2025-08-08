using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsSection
    {
        public int SectionID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfSeat { get; set; }
        public int GroupsCount { get; }
        public int CreatedByUserID { get; set; }

        enum enMode
        {
            Add = 1,
            Update = 2
        }
        private enMode Mode;

        public clsSection()
        {
            SectionID = -1;
            Name = string.Empty;
            Description = string.Empty;
            NumberOfSeat = 0;
            GroupsCount = 0; // Assuming GroupsCount is always 0 for a new section
            CreatedByUserID = -1;
            Mode = enMode.Add;
        }
        private
            clsSection(int sectionID, string name, string description, int numberOfSeat, int createdByUserID)
        {
            SectionID = sectionID;
            Name = name;
            Description = description;
            NumberOfSeat = numberOfSeat;
            GroupsCount = clsSectionDataAccess.GetGroupsCountBySectionID(SectionID); ; // Assuming GroupsCount is always 0 for a new section
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.SectionID = clsSectionDataAccess.AddNewSection(Name, Description,
                NumberOfSeat, CreatedByUserID);
            return this.SectionID != -1;
        }

        private bool _Update()
        {
            return clsSectionDataAccess.UpdateSection(SectionID, Name, Description, NumberOfSeat);
        }

        static public clsSection GetSectionByID(int SectionID) 
        {
            string Name = string.Empty, Description = string.Empty;
            int NumberOfSeat = 0, CreatedByUserID = -1;

            if (clsSectionDataAccess.GetSectionByID(SectionID, ref Name, ref Description, ref NumberOfSeat, ref CreatedByUserID))
            {
                return new clsSection(SectionID, Name, Description, NumberOfSeat, CreatedByUserID);
            }
            return null;
        }

        static public clsSection GetSectionByName(string Name)
        {
            string Description = string.Empty;
            int  SectionID = -1, NumberOfSeat = 0, CreatedByUserID = -1;

            if (clsSectionDataAccess.GetSectionByName(Name, ref SectionID , ref Description, ref NumberOfSeat, ref CreatedByUserID))
            {
                return new clsSection(SectionID, Name, Description, NumberOfSeat, CreatedByUserID);
            }
            return null;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    throw new InvalidOperationException("Invalid mode for saving section.");
            }
        }

        static public List<clsSection> ConvertSectionsRecordsToObjects(DataTable dtSections)
        {
            List<clsSection> Sections = new List<clsSection>();
            clsSection Section;
            foreach (DataRow s in dtSections.Rows)
            {
                Section = new clsSection((int)s["SectionID"], (string)s["Name"], (string)s["Description"], (int)s["NumberOfSeats"]
                                         ,(int)s["CreatedByUserID"]);

                Sections.Add(Section);
            }
            return Sections;



        }

        static public List<clsSection> fetchSectionsBatch(int PageNumber)
        {

            DataTable dt = clsSectionDataAccess.fetchSectionsBatch(PageNumber);

            return ConvertSectionsRecordsToObjects(dt);



        }

        static public bool Delete(int SectionID)
        {
            return clsSectionDataAccess.DeleteSection(SectionID);
        }


        static public List <clsSection> GetAllSectionsAsObjects()
        {
            DataTable dt = clsSectionDataAccess.GetAllSections();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsSection>();
            return ConvertSectionsRecordsToObjects(dt);
        }

    }
}
