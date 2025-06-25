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
    public partial class frmPersonInfoWithFilter: Form
    {
        public event Action<clsPerson> onPersonSelected;

        public frmPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            onPersonSelected?.Invoke(ctrlPersonInfoWithFilter1._Person);
            this.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
