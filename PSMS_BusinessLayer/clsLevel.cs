using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF;

namespace PSMS_BusinessLayer
{
    public class clsLevel
    {
        public int Level_ID { get; private set;}
        public string Name{ get; set;}
        public string Description { get; set;}
        public int LevelCode { get; set;}


        private clsLevel(int Level_ID, string Name,string Descreption,int LevelCode)
        {
            this.Level_ID = Level_ID;
            this.Name = Name;
            this.Description = Descreption;
            this.LevelCode = LevelCode;
        }

        static public clsLevel FindByName(string Name)
        {
            int Level_ID = -1,LevelCode = 0;
            string Description = "";
            if (clsLevelDataAccess.FindByName(Name, ref Level_ID, ref Description, ref LevelCode))
            {
                return new clsLevel(Level_ID, Name, Description, LevelCode);
            }
            else
                return null;
           
        }


        static public clsLevel FindByID(int Level_ID)
        {
            string Name = "",Descreption = "";
            int LevelCode = 0;

            if (clsLevelDataAccess.FindByID(Level_ID, ref Name, ref Descreption, ref LevelCode))
            {
                return new clsLevel(Level_ID, Name, Descreption, LevelCode);
            }
            else
                return null;
            
        }

        static public DataTable GetAllLevels()
        {
            return clsLevelDataAccess.GetAllLevels();
        }

        static public List<clsLevel> GetAllLevelsAsObjects()
        {
            DataTable dtLevels = clsLevelDataAccess.GetAllLevels();
            List<clsLevel> Level = new List<clsLevel>();
            //clsSubject Subject;
            if (dtLevels != null)
                foreach (DataRow s in dtLevels.Rows)
                    Level.Add(new clsLevel((int)s["Level_ID"], (string)s["Name"], (string)s["Description"],
                        (int)s["LevelCode"]));
            return Level;
        }

    }
}
