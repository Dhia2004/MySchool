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
    public partial class frmAllStudents : Form
    {
        public frmAllStudents()
        {
            InitializeComponent();
        }

        private List<clsStudent> AllStudents;

        private void UpdateFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            AllStudents = clsStudent.fetchStudentBatch(Convert.ToInt32(lblPageNumber.Tag));

            foreach (var Student in AllStudents)
            {


                ctrlStudentMiniCard newCard = new ctrlStudentMiniCard();
                newCard.StudentSelected += ctrlStudentInfoWithFilter1.FullStudentCard;
                newCard.OnBackToForm += ReloadFlowLayoutPanel;
                newCard.onSubFormOpened += () => this.Opacity = 0.6;
                newCard.onSubFormClosed += () => this.Opacity = 1;
                ctrlStudentInfoWithFilter1.InitializeCtrlStudentCardEvents(
                    () => this.Opacity = 0.6,
                    () => this.Opacity = 1,
                    () => this.Opacity = 0.6,
                    () => this.Opacity = 1
                );
                newCard.SetStudentInfo(Student);
                flowLayoutPanel1.Controls.Add(newCard);
            }


        }
        private void frmAllStudents_Load(object sender, EventArgs e)
        {
            //ctrlStudentInfoCard1.OnEditButtonClicked += () => this.Opacity = 0.6;
            //ctrlStudentInfoCard1.OnBackToFormHandler += () => this.Opacity = 1;
            ctrlStudentInfoWithFilter1.OnBackToFormHandeler += ReloadFlowLayoutPanel;
            pbBack.Enabled = false;
            lblPageNumber.Tag = 1;
            UpdateFlowLayoutPanel();


            //lblRecorsNumber.Text = flowLayoutPanel1.Controls.Count.ToString() + " Student(s)" ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        

        

        private void ReloadFlowLayoutPanel()
        {
            lblPageNumber.Tag = 1;
            lblPageNumber.Text = "1";
            pbBack.Enabled = false;
            UpdateFlowLayoutPanel();
            ctrlStudentInfoWithFilter1.ResetCtrlStudentInfoWithFilter();

        }

        private void pbRefrech_Click(object sender, EventArgs e)
        {
            ReloadFlowLayoutPanel();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) - 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            if (Convert.ToInt32(lblPageNumber.Tag) == 1)
            {
                pbBack.Enabled = false;
            }
            UpdateFlowLayoutPanel();
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            lblPageNumber.Tag = Convert.ToInt32(lblPageNumber.Tag) + 1;
            lblPageNumber.Text = lblPageNumber.Tag.ToString();
            pbBack.Enabled = true;
            UpdateFlowLayoutPanel();
        }
    }
}