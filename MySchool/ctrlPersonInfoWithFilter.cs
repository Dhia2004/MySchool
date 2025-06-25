using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PSMS_BusinessLayer;

namespace MySchool
{
    public partial class ctrlPersonInfoWithFilter: UserControl
    {
        public clsPerson _Person;
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
            ctrlPersonInfoCard1.onPersonSelected += (Person) => _Person = Person;
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(btnFilter.Text == "Person ID")
                btnFilter.Text = "National ID";
            else
                btnFilter.Text = "Person ID";
            txtInput.Text = string.Empty;
            ctrlPersonInfoCard1.ResetPersonCardToDefault(); // مسح المعلومات الحالية

        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (btnFilter.Text == "Person ID")
            {
                ctrlPersonInfoCard1.LoadPersonInfo(Convert.ToInt32(txtInput.Text));
            }
            else if (btnFilter.Text == "National ID")
            {
                ctrlPersonInfoCard1.LoadPersonInfo(txtInput.Text);
            }
           
        }
    }
}
