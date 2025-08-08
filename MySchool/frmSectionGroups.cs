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
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateGroupsList();
        }
    }
}
