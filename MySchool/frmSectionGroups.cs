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
using static System.Collections.Specialized.BitVector32;

namespace MySchool
{
    public partial class frmSectionGroups: Form
    {
        clsSection Section = new clsSection();
        public frmSectionGroups(clsSection section)
        {
            InitializeComponent();
            Section = section;
        }
        private ctrlGroupInfo SectionInfo;
        List<clsGroup> Groups = new List<clsGroup>();

        private void UpdateGroupsList()
        {
            flpGroupsList.Controls.Clear();
            Groups = clsGroup.fetchGroupsBatch(Section.SectionID, Convert.ToInt32(lblPageNumber.Tag));
            foreach (var Group in Groups)
            {
                ctrlGroupInfo newCard = new ctrlGroupInfo();
                newCard.MouseEnter += (s, e) => SectionInfo = (ctrlGroupInfo)s;
                newCard.SetGroupInfo(Group);
                flpGroupsList.Controls.Add(newCard);
            }
        }

        private void frmSectionGroups_Load(object sender, EventArgs e)
        {
            lblSectionName.Text = Section.Name;
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateGroupsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) + 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            pbBack.Enabled = true;
            UpdateGroupsList();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) - 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            if (Convert.ToInt32(lblPageNumber.Tag) == 1)
            {
                pbBack.Enabled = false;
            }
            UpdateGroupsList();
        }

        private void btnAddNewGroup_Click(object sender, EventArgs e)
        {
            frmAddEditGroup frm = new frmAddEditGroup(Section);
            frm.ShowDialog();
            UpdateGroupsList(); // Refresh the list after adding a new group
        }
    }
}
