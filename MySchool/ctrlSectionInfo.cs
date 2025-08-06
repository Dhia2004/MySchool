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
    public partial class ctrlSectionInfo: UserControl
    {
        public clsSection Section;
        public ctrlSectionInfo()
        {
            InitializeComponent();
        }

        private void ctrlSectionInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetSectionInfo(clsSection Section)
        {
            this.Section = Section;
            lblSectionID.Text = Section.SectionID.ToString();
            lblName.Text = Section.Name;
            lblNumberOfSeats.Text = Section.NumberOfSeat.ToString();
            lblGroupsCount.Text = Section.GroupsCount.ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(Section.CreatedByUserID).UserName;

        }
    }
}
