using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class frmLoginPage : Form
    {

        private bool UseSystemPasswordChar = true;
        public frmLoginPage()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.EndProgram = true;
            this.Close();
        }

        private bool IsCorrectPassword(string UserPassword, string InputPassword)
        {
            return (UserPassword == InputPassword);
        }

        private void SaveLoginInformationToFile()
        {

            string Path = @"C:\Users\dhiad\source\repos\MySchool\LoginInformation.txt";
            using (StreamWriter writer = new StreamWriter(Path, false))
            {
                writer.WriteLine(txtUserName.Text);
                writer.WriteLine(txtPassword.Text);
                writer.Close();

            }

        }

        private void DeleteLoginInformationFromFile()
        {
            string Path = @"C:\Users\dhiad\source\repos\MySchool\LoginInformation.txt";
            if (File.Exists(Path))
                using (StreamWriter writer = new StreamWriter(Path, false))
                    writer.Close();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserNameExist(txtUserName.Text))
            {
                clsUser User = clsUser.FindByUserName(txtUserName.Text);
                if (IsCorrectPassword(User.Password, txtPassword.Text))
                {

                    if (User.IsActive)
                    {

                        if (chkRemmeberMe.Checked)
                            SaveLoginInformationToFile();
                        else
                            DeleteLoginInformationFromFile();


                        clsGlobalSettings.CurrentUser = User;
                        clsGlobalSettings.IsLoggedIn = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(@"This Account is not Active, Contact The Admins for " +
                                       "more details...", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show(@"The password is not Correct :-(", "Oops",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtUserName.Clear();
                    txtPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("This user name is not found :-(", "Oops",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUserName.Clear();
                txtPassword.Clear();
            }
        }

        private bool LoadLoginInformation()
        {

            string Path = @"C:\Users\dhiad\source\repos\MySchool\LoginInformation.txt";
            if (File.Exists(Path))
            {
                if (!string.IsNullOrEmpty(File.ReadAllText(Path)))
                {
                    string[] UserInfo = File.ReadAllLines(Path);
                    txtUserName.Text = UserInfo[0];
                    txtPassword.Text = UserInfo[1];
                    return true;
                }


            }
            return false;

        }

        private void frmLoginPage_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            if (LoadLoginInformation())
            {
                btnLogin.Enabled = true;
                chkRemmeberMe.Checked = true;
            }
            else
            {
                btnLogin.Enabled = false;
                chkRemmeberMe.Checked = false;
            }
        }

        private void IsNullOrEmptyText(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError((TextBox)sender, "This field must be not empty");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private bool IsAllControlsNotNull()
        {
            return (txtUserName.Text != "" && txtPassword.Text != "");
        }

        private void btnLoginEnabled(object sender, EventArgs e)
        {
            btnLogin.Enabled = IsAllControlsNotNull();
        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            UseSystemPasswordChar = !UseSystemPasswordChar;
            txtPassword.UseSystemPasswordChar = UseSystemPasswordChar;
            if (UseSystemPasswordChar)
            {
                pbEye.Image = Properties.Resources.Eye_open_72;
            }
            else
            {
                pbEye.Image = Properties.Resources.Eye_closed_72;
            }
        }
    }
    
}
