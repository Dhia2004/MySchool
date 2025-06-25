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
    public partial class frmPersonInfo: Form
    {
        int _PersonID = -1;
        clsPerson _Person;

        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoCard1.onPersonSelected += (Person) => _Person = Person;
            ctrlPersonInfoCard1.LoadPersonInfo(_PersonID);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
