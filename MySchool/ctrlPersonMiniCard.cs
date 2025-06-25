using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class ctrlPersonMiniCard: UserControl
    {
        public ctrlPersonMiniCard()
        {
            InitializeComponent();
        }

        public void FullPersonCard(string FullName,string Phone)
        {
            lblFullName.Text = FullName;
            lblPhone.Text = Phone;
        }
    }
}
