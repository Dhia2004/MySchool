using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSMS_BusinessLayer;

namespace MySchool
{
    public partial class ctrlGroupInfo: UserControl
    {

        public clsGroup Group;
        public ctrlGroupInfo()
        {
            InitializeComponent();
        }

        private void ctrlGroupInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetGroupInfo(clsGroup Group)
        {

            this.Group = Group;
            lblGroupID.Text = Group.GroupID.ToString();
            lblName.Text = Group.Name;
            lblMaxSeatsNumber.Text = Group.MaxSeatsNumber.ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(Group.CreatedByUserID).UserName;

        }
    }
}
