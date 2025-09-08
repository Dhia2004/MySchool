using System;
using System.Drawing;
using System.IO;
using BarcodeStandard;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Barcode = BarcodeStandard.Barcode;

namespace PSMS_BusinessLayer
{
    public class clsBarCode
    {
        static public void GenerateStudentSubscriptionBarCode(
    int studentID,
    int subscriptionID,
    string studentName,
    string courseName,
    string sectionName,
    string groupName,
    string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // A7 card with margins
                    Document doc = new Document(PageSize.A7, 12f, 12f, 12f, 12f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    PdfContentByte cb = writer.DirectContent;

                    // ===== Border only =====
                    cb.SetColorStroke(new BaseColor(0, 0, 0));
                    cb.SetLineWidth(1.5f);
                    cb.Rectangle(
                        doc.PageSize.GetLeft(6f),
                        doc.PageSize.GetBottom(6f),
                        doc.PageSize.Width - 12f,
                        doc.PageSize.Height - 12f
                    );
                    cb.Stroke();

                    // ===== Title =====
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, new BaseColor(40, 40, 120));
                    Paragraph title = new Paragraph("STUDENT SUBSCRIPTION CARD", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 4f
                    };
                    doc.Add(title);

                    // Line separator
                    cb.MoveTo(doc.Left, doc.Top - 20f);
                    cb.LineTo(doc.Right, doc.Top - 20f);
                    cb.Stroke();

                    doc.Add(new Paragraph("\n"));

                    // ===== Student details (centered) =====
                    var detailFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
                    Paragraph details = new Paragraph(
                        $"Student ID : {studentID}\n" +
                        $"Subscription : {subscriptionID}\n" +
                        $"Name : {studentName}\n" +
                        $"Course : {courseName}\n" +
                        $"Section : {sectionName}\n"+
                        $"Group : {groupName}",
                        detailFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10f
                    };
                    doc.Add(details);

                    // ===== Barcode =====
                    Barcode128 barcode = new Barcode128
                    {
                        CodeType = Barcode128.CODE128,
                        Code = $"{subscriptionID}"
                    };

                    iTextSharp.text.Image barcodeImage = barcode.CreateImageWithBarcode(writer.DirectContent, null, null);
                    barcodeImage.Alignment = Element.ALIGN_CENTER;
                    barcodeImage.ScalePercent(140); // balanced for A7
                    doc.Add(barcodeImage);

                    doc.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating barcode PDF", ex);
            }
        }



    }
}
