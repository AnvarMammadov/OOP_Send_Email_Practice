using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public static class SendMail
    {
        public static void SendMailExams(string senderMail, string senderMailPass, string recieverMail, string subject, string pdfName, string text)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(senderMail, senderMailPass);

                MailMessage mail = new MailMessage(senderMail, recieverMail);
                mail.Subject = subject;

                byte[] pdfBytes = CreatePdfDocument(text);

                string pdfPath = SavePdfToDesktop(pdfName, pdfBytes);

                AttachAndSendPdf(pdfName, mail, pdfBytes, pdfPath, smtpClient);

                Console.WriteLine("Email sent and PDF saved to desktop");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending error: " + ex.Message);
            }
        }

        private static byte[] CreatePdfDocument(string text)
        {
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();

           
            BaseColor backgroundColor = new BaseColor(0, 204, 204); 

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                
                PdfContentByte background = writer.DirectContentUnder;
                background.SetColorFill(backgroundColor);
                background.Rectangle(0, 0, PageSize.A4.Width, PageSize.A4.Height);
                background.Fill();

               
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.YELLOW);
                Paragraph title = new Paragraph("E X A M   R E S U L T S", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 16,BaseColor.WHITE);

                Paragraph studentInfo = new Paragraph(text, infoFont);
                studentInfo.Alignment = Element.ALIGN_LEFT;
                studentInfo.SpacingBefore = 20f;
                document.Add(studentInfo);
            }
            finally
            {
                document.Close();
            }

            return memoryStream.ToArray();
        }


        private static string SavePdfToDesktop(string pdfName, byte[] pdfBytes)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pdfPath = Path.Combine(desktopPath, pdfName);
            File.WriteAllBytes(pdfPath, pdfBytes);
            return pdfPath;
        }

        private static void AttachAndSendPdf(string pdfName, MailMessage mail, byte[] pdfBytes, string pdfPath, SmtpClient smtpClient)
        {
            mail.Attachments.Add(new Attachment(new MemoryStream(pdfBytes), pdfName));
            smtpClient.Send(mail);
        }
    }
}

