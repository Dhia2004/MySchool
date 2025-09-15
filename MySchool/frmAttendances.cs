using PSMS_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySchool
{
    public partial class frmAttendances: Form
    {
        clsSubscription Subscription;
        public frmAttendances()
        {
            InitializeComponent();
        }

        private void frmAttendances_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // لتنعيم الحواف

            // إعدادات المستطيل
            int width = 712;
            int height = 35;
            int x = 233; // موقع المستطيل أفقيًا
            int y = 156; // موقع المستطيل عموديًا
            int cornerRadius = 15; // نصف قطر الزوايا

            // إنشاء المسار ذو الزوايا الدائرية
            using (GraphicsPath path = GetRoundedRectPath(new Rectangle(x, y, width, height), cornerRadius))
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawPath(pen, path); // رسم حدود المستطيل
                }

                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillPath(brush, path); // تعبئة المستطيل بلون
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            // الزاوية العلوية اليسرى
            path.AddArc(arc, 180, 90);

            // الزاوية العلوية اليمنى
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // الزاوية السفلية اليمنى
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // الزاوية السفلية اليسرى
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void txtSubscriptionID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
                
                this.Text = string.Empty;
                this.Focus();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubscriptionID.Text))
            {
                Subscription = clsSubscription.GetSubscriptionInfoByID(Convert.ToInt32(txtSubscriptionID.Text));
                if (Subscription != null)
                {
                    if (Subscription.Student.IsActive)
                    {
                        if (Subscription.IsActive)

                        {
                            pnlDone.Visible = true;
                            var timer = new System.Windows.Forms.Timer();
                            timer.Interval = 1000; // 2 seconds
                            timer.Tick += (s, args) =>
                            {
                                pnlDone.Visible = false;
                                timer.Stop();
                                timer.Dispose();
                            };
                            timer.Start();

                            //pnlDone.Visible = false;

                            Subscription.DecrementRemainingSessions();
                            lblStudentName.Text = Subscription.Student.FullName();

                            if (Subscription.Student.Gender == 'M')
                            {
                                pbStudentImage.Image = Properties.Resources.Male_512;
                            }
                            else
                            {
                                pbStudentImage.Image = Properties.Resources.Female_512;
                            }
                            if (Subscription.Student.ImagePath != "")
                            {
                                pbStudentImage.Load(Subscription.Student.ImagePath);
                            }


                            lblStudentStatus.Text = Subscription.Student.IsActive ? "Active" : "Inactive";
                            lblUnpaidSubs.Text = Subscription.Student.UnpaidSubscriptionsCount().ToString();
                            lblRemainingSeassons.Text = Subscription.RemainingSessions.ToString();

                            lblSubject.Text = clsSubject.FindByID(Subscription.CourseSection.Course.SubjectID).Name;
                            lblTeacherName.Text = clsTeacher.FindByTeacherID(Subscription.CourseSection.Course.TeacherID).Person.FullName();
                            lblSection.Text = Subscription.CourseSection.Section.Name;
                            lblGroup.Text = Subscription.CourseSection.Group.Name;
                            lblDay.Text = Subscription.CourseSection.Day;

                            lblTime.Text = Subscription.CourseSection.Time.ToString();
                            lblSeassons.Text = Subscription.TotalSessions.ToString();
                            lblSubStatus.Text = Subscription.IsActive ? "Active" : "Inactive";
                            lblStartDate.Text = Subscription.StartDate.ToShortDateString();
                            lblEndDate.Text = Subscription.EndDate.ToShortDateString();


                        }

                        else
                        {
                            MessageBox.Show("The selected subscription is not active. Please select an active subscription.", "Inactive Subscription", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected student is not active. Please select an active student.", "Inactive Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Subscription not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //panelDetails.Visible = false;
                }

            }
            else
            {
                MessageBox.Show("Please enter a subscription ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtSubscriptionID.Text = string.Empty;
        }

        private void ResetForm()
        {
            txtSubscriptionID.Text = string.Empty;
            lblStudentName.Text = "---";
            pbStudentImage.Image = Properties.Resources.Male_512;
            lblStudentStatus.Text = "---";
            lblUnpaidSubs.Text = "---";
            lblRemainingSeassons.Text = "---";
            lblSubject.Text = "---";
            lblTeacherName.Text = "---";
            lblSection.Text = "---";
            lblGroup.Text = "---";
            lblDay.Text = "---";
            lblTime.Text = "---";
            lblSeassons.Text = "---";
            lblSubStatus.Text = "---";
            lblStartDate.Text = "---";
            lblEndDate.Text = "---";
            Subscription = null;
        }
        private void frmAttendances_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
