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
    public partial class frmSubscriptionsManagement: Form
    {
        ctrlSubscriptionInfo subscriptionInfo;
        public frmSubscriptionsManagement()
        {
            InitializeComponent();
        }

        List<clsSubscription> subscriptionsList = new List<clsSubscription>();
        private void UpdateCoursesList()
        {
            flpSubscriptionsList.Controls.Clear();
            subscriptionsList = clsSubscription.fetchSubscriptionsBatch(Convert.ToInt32(lblPageNumber.Tag));
            foreach (var subscriptionItem in subscriptionsList)
            {
                ctrlSubscriptionInfo newCard = new ctrlSubscriptionInfo();
                newCard.MouseEnter += (s, e) => subscriptionInfo = (ctrlSubscriptionInfo)s;
                newCard.SetSubscriptionInfo(subscriptionItem);
                flpSubscriptionsList.Controls.Add(newCard);
            }
        }
        private void frmSubscriptionsManagement_Load(object sender, EventArgs e)
        {
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateCoursesList();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) + 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            pbBack.Enabled = true;
            UpdateCoursesList();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) - 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            if (Convert.ToInt32(lblPageNumber.Tag) == 1)
            {
                pbBack.Enabled = false;
            }
            UpdateCoursesList();
        }
    }
}
