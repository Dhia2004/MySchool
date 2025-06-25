using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if ((clsGlobalSettings.SchoolInfo = clsSchoolInfo.GetSchoolInfo()) != null)
                RunTheSystem();

            else
            {
                Application.Run(new frmWelcomeForm());
                if (clsGlobalSettings.ConfigurationSucc)
                    RunTheSystem();
            }
                

        }

        static private void RunTheSystem()
        {
            while (true)
            {


                //Run The Login Screen
                Application.Run(new frmLoginPage());

                //If the user press btnClose button then end the program
                if (clsGlobalSettings.EndProgram)
                    break;

                //if the user enter the right username and password then show the Main Form
                if (clsGlobalSettings.IsLoggedIn)
                {
                    Application.Run(new frmMainPage());

                    //if the user press the Close button then end the Program
                    if (!clsGlobalSettings.IsLoggedOut)
                        break;

                }

            }

        }
    }
}
