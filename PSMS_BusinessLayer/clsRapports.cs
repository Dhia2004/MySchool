using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using QuestPDF;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

using QuestPDF.Infrastructure;


namespace PSMS_BusinessLayer
{
    public class clsRapports
    {

        
        static public void GenerateStudentRapport(clsStudent student)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{student.FirstName}_{student.LastName}.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);

                    page.Header().Column(headerCol =>
                    {
                        headerCol.Item().Row(row =>
                        {
                            // 🔵 الصورة اليسرى
                            row.ConstantItem(100).Image(student.ImagePath);

                            // 🟢 النص في الوسط
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Container().AlignCenter().Text("الجمهورية الجزائرية الديمقراطية الشعبية").FontFamily("Arial").FontSize(14).Bold();
                                col.Item().Container().AlignCenter().Text("مدرسة الإتقان الخاصة").FontFamily("Arial").FontSize(16).Bold();
                                col.Item().Container().AlignCenter().Text("مؤسسة تعليمية خاصة معتمدة لجميع الأطوار").FontFamily("Arial").FontSize(12);
                                col.Item().Container().AlignCenter().Text("📞 023 45 67 89    ✉️ contact@school.dz").FontFamily("Arial").FontSize(10);
                                col.Item().Container().AlignCenter().Text("العنوان: حي النخيل، الجزائر العاصمة").FontFamily("Arial").FontSize(10);
                            });

                            // 🔴 الشعار على اليمين
                            row.ConstantItem(100).Image(student.ImagePath);
                        });

                        // ✅ الخط الفاصل
                        headerCol.Item().PaddingVertical(10);
                        headerCol.Item().LineHorizontal(1).LineColor(Colors.Black);
                    });



                    page.Content().Column(col =>
                    {
                        // 🔷 عنوان الملف
                        col.Item().Container().AlignCenter().Text("Student File").FontSize(20).Bold();
                        col.Item().PaddingVertical(10);

                        // 🔷 صورة التلميذ + الاسم واللقب
                        col.Item().Row(row =>
                        {
                            row.ConstantItem(100).Image(student.ImagePath);
                            row.RelativeItem().Column(infoCol =>
                            {
                                infoCol.Item().PaddingVertical(5).PaddingLeft(10).Text($"Student ID : {student.StudentID}").FontSize(14);
                                infoCol.Item().PaddingVertical(5).PaddingLeft(10).Text($"First Name : {student.FirstName}").FontSize(14);
                                infoCol.Item().PaddingVertical(5).PaddingLeft(10).Text($"Last Name : {student.LastName}").FontSize(14);
                            });
                        });

                        col.Item().PaddingVertical(10);

                        // 🔷 باقي معلومات التلميذ
                        col.Item().Column(info =>
                        {
                            info.Item().Text($"Gender : {student.Gender}").FontSize(12);
                            info.Item().Text($"Status : {student.IsActive}").FontSize(12);
                            info.Item().Text($"Date of birth : {student.DateOfBirth}").FontSize(12);
                            info.Item().Text($"Level : {student.LevelID}").FontSize(12);
                            info.Item().Text($"Phone : {student.PhoneNumber}").FontSize(12);
                            info.Item().Text($"Address : {student.Address}").FontSize(12);
                            info.Item().Text($"Join DATE : {student.JoinDate}").FontSize(12);
                        });
                    });

                    page.Footer().AlignRight().Text($"Date : {DateTime.Now:yyyy-MM-dd}").FontSize(10);
                });
            })
            .GeneratePdf(filePath);
        }

    }
}
