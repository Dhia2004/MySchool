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
    public partial class frmUpdatePrice: Form
    {
        clsCourse Course;
        public frmUpdatePrice(clsCourse Course)
        {
            InitializeComponent();
            this.Course = Course;
        }

        private void frmUpdatePrice_Load(object sender, EventArgs e)
        {
            lblOldPrice.Text = Course.Price.ToString();
            nudNewPrice.Value = (decimal)Course.Price;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
