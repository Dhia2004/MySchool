using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsGroup
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SectionID { get; set; }
        public int MaxSeatsNumber { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode
        {
            Add = 1,
            Update = 2
        }

        enMode Mode;
        
        public clsGroup()
        {
            GroupID = -1;
            Name = string.Empty;
            Description = string.Empty;
            SectionID = -1;
            MaxSeatsNumber = 0;
            CreatedByUserID = -1;
            Mode = enMode.Add; // Default mode is Add
        }
        private clsGroup(int groupID, string name, string description, int sectionID, int maxSeatsNumber, int createdByUserID)
        {
            GroupID = groupID;
            Name = name;
            Description = description;
            SectionID = sectionID;
            MaxSeatsNumber = maxSeatsNumber;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update; // This constructor is used for existing groups, so the mode is Update
        }


        public static clsGroup GetGroupByID(int groupID)
        {
            string Name = string.Empty,Description = string.Empty;
            int SectionID = -1, MaxSeatsNumber = 0, CreatedByUserID = -1;
            if (clsGroupDataAccess.GetGroupByID(groupID,ref Name,ref Description,ref SectionID,ref MaxSeatsNumber
                ,ref CreatedByUserID))
            {
                return new clsGroup(groupID, Name, Description, SectionID, MaxSeatsNumber, CreatedByUserID);
            }
            
                return null; // or throw an exception based on your design choice
 
           

        }

        private bool _AddNew()
        {
            this.GroupID = clsGroupDataAccess.AddNewGroup(Name, Description,
                SectionID, MaxSeatsNumber, CreatedByUserID);
            return this.GroupID != -1;
        }

        private bool _Update()
        {
            return clsGroupDataAccess.UpdateGroup(GroupID,Name, Description, MaxSeatsNumber);
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

        static public List<clsGroup> ConvertGroupsRecordsToObjects(DataTable dtGroups)
        {
            List<clsGroup> Groups = new List<clsGroup>();
            clsGroup Group;
            if (dtGroups == null || dtGroups.Rows.Count == 0)
                return Groups;
            foreach (DataRow s in dtGroups.Rows)
            {
                Group = new clsGroup((int)s["GroupID"], (string)s["Name"], (string)s["Description"],
                                      (int)s["SectionID"], (int)s["MaxSeats"], (int)s["CreatedByUserID"]);

                Groups.Add(Group);
            }
            return Groups;



        }

        static public List<clsGroup> fetchGroupsBatch(int SectionID,int PageNumber)
        {

            DataTable dt = clsGroupDataAccess.fetchGroupssBatch(SectionID,PageNumber);

            return ConvertGroupsRecordsToObjects(dt);



        }

        static public List<clsGroup> GetAllGroupsBySectionID(int SectionID)
        {
            DataTable dtGroups = clsGroupDataAccess.GetAllGroupsBySectionID(SectionID);
            return ConvertGroupsRecordsToObjects(dtGroups);
        }

        static public clsGroup GetGroupByName(string GroupName)
        {
            int GroupID = -1, SectionID = -1, MaxSeatsNumber = 0, CreatedByUserID = -1;
            string Description = string.Empty;
            if (clsGroupDataAccess.GetGroupByName(GroupName, ref GroupID, ref Description, ref SectionID,
                ref MaxSeatsNumber, ref CreatedByUserID))
            {
                return new clsGroup(GroupID, GroupName, Description, SectionID, MaxSeatsNumber, CreatedByUserID);
            }
            return null; // or throw an exception based on your design choice
        }

    }
}
