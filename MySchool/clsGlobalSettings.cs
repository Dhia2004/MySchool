using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    static class clsGlobalSettings
    {
        static public clsSchoolInfo SchoolInfo;
        static public clsUser CurrentUser;
        static public bool IsLoggedIn = false;
        static public bool IsLoggedOut = false;
        static public bool EndProgram = false;
        static public bool ConfigurationSucc = false;
    }
    
}
