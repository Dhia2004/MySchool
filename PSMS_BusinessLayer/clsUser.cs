using PSMS_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMS_BusinessLayer
{
    public class clsUser
    {

        public int UserID { get; private set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Permessions { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }


        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode Mode;

        public clsUser()
        {
            this.Mode = enMode.AddNew;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.Permessions = 0;
            this.CreatedByUserID = -1;
            this.IsActive = false;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, int Permessions, int CreatedByUserID, bool IsActive)
        {
            Mode = enMode.Update;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.Permessions = Permessions;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;

        }


        static public clsUser FindByUserID(int UserID)
        {
            string UserName = "", Password = "";
            bool IsActive = false;
            int PersonID = -1, Permessions = 0, CreatedByUserID = -1;

            if (clsUserDataAccess.FindByUserID(UserID, ref PersonID, ref UserName, ref Password, ref Permessions,
                ref CreatedByUserID, ref IsActive))

                return new clsUser(UserID, PersonID, UserName, Password,Permessions,CreatedByUserID, IsActive);

            else
            {
                return null;
            }



        }

        static public clsUser FindByPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            bool IsActive = false;
            int UserID = -1,Permessions = 0,CreatedByUserID = -1;

            if (clsUserDataAccess.FindByPersonID(ref UserID, PersonID, ref UserName,
                                                 ref Password,ref Permessions,ref CreatedByUserID, ref IsActive))

                return new clsUser(UserID, PersonID, UserName, Password, Permessions, CreatedByUserID, IsActive);

            else
            {
                return null;
            }



        }

        static public clsUser FindByUserName(string UserName)
        {
            string Password = "";
            bool IsActive = false;
            int UserID = -1;
            int PersonID = -1,Permessions = 0,CreatedByUserID = 0;

            if (clsUserDataAccess.FindByUserName(ref UserID, ref PersonID, UserName,
                                                 ref Password,ref Permessions,ref CreatedByUserID, ref IsActive))

                return new clsUser(UserID, PersonID, UserName, Password, Permessions, CreatedByUserID, IsActive);

            else
            {
                return null;
            }



        }


        private bool _AddUser()
        {
            this.UserID = clsUserDataAccess.AddUser(PersonID, UserName
                                                      , Password,Permessions,CreatedByUserID, IsActive);

            return this.UserID != -1;

        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.Update(UserID, UserName, Password,Permessions,CreatedByUserID, IsActive);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                    break;
                case enMode.Update:
                    return _UpdateUser();
                    break;

                default:
                    return false;

            }

        }

        static public bool Delete(int UserID)
        {
            return clsUserDataAccess.Delete(UserID);
        }


        //static public DataTable GetAllUsers()
        //{
        //    return clsUserDataAccess.GetAllUsers();
        //}


        static public bool IsUserNameExist(string UserName)
        {
            return clsUserDataAccess.IsUserNameExist(UserName);
        }



        public bool ChangePassword()
        {
            return clsUserDataAccess.ChangePassword(this.UserID, this.Password);
        }
    }
}
