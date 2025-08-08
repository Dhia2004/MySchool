using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class frmAddEditGroup: Form
    {
        private clsSection Section;
        public frmAddEditGroup()
        {
            InitializeComponent();
        }

        private void frmAddEditGroup_Load(object sender, EventArgs e)
        {
            List<clsSection> Sections = clsSection.GetAllSectionsAsObjects();
            foreach (clsSection Section in Sections)
            {
                cbSections.Items.Add(Section.Name);
            }
        }

        private void cbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlGroupInfo.Enabled = true;
            Section = clsSection.GetSectionByName(cbSections.Text);
            nudSeats.Maximum = Section.NumberOfSeat;
        }

        private void pnlGroupInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
