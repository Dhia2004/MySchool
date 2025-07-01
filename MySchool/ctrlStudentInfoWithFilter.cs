using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSMS_BusinessLayer;
using System.Drawing.Drawing2D;

namespace MySchool
{
    public partial class ctrlStudentInfoWithFilter : UserControl
    {



        public ctrlStudentInfoWithFilter()
        {
            InitializeComponent();

        }

        public event Action OnbtnAddNewStudentClicked;
        public event Action OnBackToFormHandeler;

        public void InitializeCtrlStudentCardEvents(Action OnbtnAddNewStudentClicked, Action OnBackToFormHandeler, Action onEditButtonClicked, Action OnBackToFormHandler)
        {
            this.OnbtnAddNewStudentClicked += OnbtnAddNewStudentClicked;
            this.OnBackToFormHandeler += OnBackToFormHandeler;
            ctrlStudentInfoCard1.OnEditButtonClicked += onEditButtonClicked;
            ctrlStudentInfoCard1.OnBackToFormHandler += OnBackToFormHandler;
        }

        public void FullStudentCard(clsStudent Student)
        {
            txtStudentID.Text = Student.StudentID.ToString();
            ctrlStudentInfoCard1.ResetPersonCardToDefault();
            ctrlStudentInfoCard1.FillPersonCard(Student);
            ctrlStudentInfoCard1.onReloadData += () => OnBackToFormHandeler?.Invoke();


        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtStudentID.Text))
        //        ctrlStudentInfoCard1.LoadStudentInfo(Convert.ToInt32(txtStudentID.Text));
        //}

        private void ctrlStudentInfoWithFilter_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // لتنعيم الحواف

            // إعدادات المستطيل
            int width = 310;
            int height = 35;
            int x = 20; // موقع المستطيل أفقيًا
            int y = 11; // موقع المستطيل عموديًا
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

        //private void pbSearch_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtStudentID.Text))
        //        ctrlStudentInfoCard1.LoadStudentInfo(Convert.ToInt32(txtStudentID.Text));
        //}

        private void ctrlStudentInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtStudentID.Text = "Enter here Student ID";
            txtStudentID.ForeColor = Color.Gray;
            txtStudentID.GotFocus += (s, ev) =>
            {
                if (txtStudentID.Text == "Enter here Student ID")
                {
                    txtStudentID.Text = "";
                    txtStudentID.ForeColor = Color.Black;
                }
            };
            txtStudentID.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                {
                    txtStudentID.Text = "Enter here Student ID";
                    txtStudentID.ForeColor = Color.Gray;
                }
            };

        }

        //private void pbAddNewStudent_Click(object sender, EventArgs e)
        //{
        //    frmAddEditStudent frm = new frmAddEditStudent(-1);
        //    OnbtnAddNewStudentClicked?.Invoke();
        //    frm.ONbtnCloseClicked += () => OnBackToFormHandeler?.Invoke();
        //    frm.ShowDialog();
        //}

        public void ResetCtrlStudentInfoWithFilter()
        {
            ctrlStudentInfoCard1.ResetPersonCardToDefault();
            txtStudentID.Text = "Enter here Student ID";
            txtStudentID.ForeColor = Color.Gray;
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frm = new frmAddEditStudent(-1);
            OnbtnAddNewStudentClicked?.Invoke();
            frm.ONbtnCloseClicked += () => OnBackToFormHandeler?.Invoke();
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStudentID.Text))
                ctrlStudentInfoCard1.LoadStudentInfo(Convert.ToInt32(txtStudentID.Text));
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
    

