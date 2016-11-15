#define TEST_LINK_TO_IMG
//#define TEST_DISPOSE
//#define TEST_DISPOSE_WITH_USING
//#define TEST_MAIL_RU
//#define TEST_HEADER
//#define TEST_IMG_IN_BODY

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace TestSMTP
{
    #if TEST_DISPOSE
        public class TestMemoryStream : MemoryStream
        {
            protected override void Dispose(bool disposing)
            {
                System.Diagnostics.Debug.WriteLine("TestMemoryStream.Dispose({0})", disposing);
                base.Dispose(disposing);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                System.Diagnostics.Debug.WriteLine("TestMemoryStream.Read()");
                return base.Read(buffer, offset, count);
            }
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmtpClient
                    smtpClient = null;

                MailMessage
                    mailMessage = null;

				#if TEST_LINK_TO_IMG
					using (mailMessage = new MailMessage())
					{
						mailMessage.From = new MailAddress("nozhenko@kr.zt.ukrtel.net");

						mailMessage.To.Add("4others@mail.ru");
						//mailMessage.To.Add("4others2@gmail.com");
						//mailMessage.To.Add("4others@ua.fm");
						//mailMessage.To.Add("4others@ukr.net");
						mailMessage.To.Add("i.nozhenko@systtech.ru");
						//mailMessage.To.Add("a.perkovsky@systtech.ru");
						//mailMessage.To.Add("i.loputneva@systtech.ru");
						//mailMessage.To.Add("inga-loputneva@yandex.ru");

						mailMessage.Subject = "Test";

						var htmlBody = "<html><body>";

						htmlBody += string.Format("<p>&lt;img&gt;<img alt=\"IMG_20160629_142844.jpg\" src=\"https://ra.st-mobile.ru/photo/2016Q3/IMG_20160629_142844.jpg\"/></p>");
						htmlBody += string.Format("<p>&lt;img&gt;<img alt=\"2016-07-11_165728(1).jpg\" src=\"https://ra.st-mobile.ru/photo/2016Q3/2016-07-11_165728(1).jpg\"/></p>");

						/*htmlBody += string.Format("<p>&lt;img&gt;<img id=\"imageByUrl\" alt=\"imageByUrl\" src=\"http://st-drive.systtech.ru/3a023caac019469799a97e2ad50f61bc\"/></p>");
						htmlBody += string.Format("<p>&lt;img&gt;<img id=\"imageByUrl\" alt=\"imageByUrl\" src=\"http://localhost/exchange/TestImageIV.jpg\"/></p>");
						htmlBody += string.Format("<p>imageByUnc2 <img id=\"imageByUnc2\" alt=\"imageByUnc\" src=\"file://i-nozhenko/exchange/TestImageIV.jpg\"/></p>");
						htmlBody += string.Format("<p>imageByUnc3 <img id=\"imageByUnc3\" alt=\"imageByUnc\" src=\"file:///i-nozhenko/exchange/TestImageIV.jpg\"/></p>");
						htmlBody += string.Format("<p>imageByUnc4 <img id=\"imageByUnc4\" alt=\"imageByUnc\" src=\"file:////i-nozhenko/exchange/TestImageIV.jpg\"/></p>");
						htmlBody += string.Format("<p>imageByUnc5 <img id=\"imageByUnc5\" alt=\"imageByUnc\" src=\"file://///i-nozhenko/exchange/TestImageIV.jpg\"/></p>");
						htmlBody += string.Format("<p>anchorByUnc2 <a id=\"anchorByUnc2\" href=\"file://i-nozhenko/exchange/TestImageIV.jpg\">TestImageIV.jpg</a></p>");
						htmlBody += string.Format("<p>anchorByUnc3 <a id=\"anchorByUnc3\" href=\"file:///i-nozhenko/exchange/TestImageIV.jpg\">TestImageIV.jpg</a></p>");
						htmlBody += string.Format("<p>anchorByUnc4 <a id=\"anchorByUnc4\" href=\"file:////i-nozhenko/exchange/TestImageIV.jpg\">TestImageIV.jpg</a></p>");
						htmlBody += string.Format("<p>anchorByUnc5 <a id=\"anchorByUnc5\" href=\"file://///i-nozhenko/exchange/TestImageIV.jpg\">TestImageIV.jpg</a></p>");*/
						htmlBody += "</body></html>";

						mailMessage.IsBodyHtml = true;
						mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
						mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
						mailMessage.BodyTransferEncoding = TransferEncoding.Base64;

						mailMessage.Body = htmlBody;

						try
						{
							smtpClient = new SmtpClient("mail.ukrpost.ua", 25);
							smtpClient.EnableSsl = false;
							smtpClient.Credentials = new NetworkCredential("nozhenko@kr.zt.ukrtel.net", "experimentator");
							smtpClient.Send(mailMessage);
						}
						catch (Exception eException)
						{
							Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
						}
						finally
						{
							if (smtpClient != null)
								smtpClient.Dispose();
						}
					}
				#endif

                #if TEST_DISPOSE
                    using (mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("nozhenko@kr.zt.ukrtel.net");
                        mailMessage.To.Add("4others@ua.fm");
                        mailMessage.To.Add("i.nozhenko@systtech.ru");
                        mailMessage.Subject = "Test";

                        var htmlBody = "<html><body>";
                        var files = new List<string> { PatchFileName("TestImageI.jpg"), PatchFileName("TestImageII.jpg"), PatchFileName("TestImageIII.jpg") };
                        var linkedResources = new List<LinkedResource>();
                        var attachments = new List<Attachment>();

                        for (var i = 0; i < files.Count; ++i)
                        {
                            if (!File.Exists(files[i]))
                            {
                                htmlBody += string.Format("<p>The file &quot;{0}&quot; doesn't exist</p>", files[i]);
                                continue;
                            }

                            Stream streamWithImage;
                            var attattachment = new Attachment(streamWithImage = GetImage(files[i]), Path.GetFileName(files[i]));
                            attachments.Add(attattachment);

                            var imageResource = new LinkedResource(CopyStream(streamWithImage), "image/jpeg");
                            imageResource.ContentId = "HDIImage" + i;
                            linkedResources.Add(imageResource);

                            htmlBody += string.Format("<p><img id=\"image{0}\" alt=\"image{0}\" src=\"cid:HDIImage{0}\"/></p>", i);
                        }

                        htmlBody += "</body></html>";

                        var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

                        foreach (var linkedResource in linkedResources)
                            htmlView.LinkedResources.Add(linkedResource);

                        foreach (var attachment in attachments)
                            mailMessage.Attachments.Add(attachment);

                        mailMessage.AlternateViews.Add(htmlView);

                        #if TEST_DISPOSE_WITH_USING
                            using (smtpClient = new SmtpClient("mail.ukrpost.ua", 25))
                        #else
                            try
                        #endif
                            {
                                #if !TEST_DISPOSE_WITH_USING
                                    smtpClient = new SmtpClient("mail.ukrpost.ua", 25);
                                #endif

                                smtpClient.EnableSsl = false;
                                smtpClient.Credentials = new NetworkCredential("nozhenko@kr.zt.ukrtel.net", "");
                                smtpClient.Send(mailMessage);
                            }
                        #if !TEST_DISPOSE_WITH_USING
                            finally
                            {
                                if (mailMessage != null)
                                    mailMessage.Dispose();

                                if (smtpClient != null)
                                    smtpClient.Dispose();
                            }
                        #endif
                    }
                #endif

                #if TEST_MAIL_RU
				    NetworkCredential
					    credential = new NetworkCredential("4others@mail.ru", "password");

                    smtp = new SmtpClient("smtp.mail.ru", /*25*/ 587);
				    smtp.Credentials = credential;
                    mailMessage = new MailMessage("4others@mail.ru", "4others@ua.fm", "Test SmtpClient", "Test SmtpClient");
                    smtp.Send(mailMessage);
                    //smtp.Send("4others@mail.ru", "4others@ua.fm", "Test SmtpClient", "Test SmtpClient");
                #endif
                
                #if TEST_HEADER
                    smtp = new SmtpClient("10.3.7.33");
                    mailMessage = new MailMessage("nozhenko@inbase.com.ua", "nozhenko@inbase.com.ua", "Test Custom Tag", "C in header MySuperPuperTag ;)");
                    mailMessage.Headers.Add("MySuperPuperTag", "blah-blah-blah");
                    smtp.Send(mailMessage);
                    //smtp.Send("nozhenko@inbase.com.ua", "nozhenko@inbase.com.ua", "Subject", "Body");
                #endif

                #if TEST_IMG_IN_BODY
                    string
                        currentDirectory = Directory.GetCurrentDirectory(),
                        inputFileName = "clear_icon.png";

                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                    if (File.Exists(inputFileName = Path.Combine(currentDirectory, inputFileName)))
                    {
                        var encbuff = File.ReadAllBytes(inputFileName);
                        var strBase64 = Convert.ToBase64String(encbuff);
						var body = string.Format("<html><body><b>Hi!!!</b><br/><img src=\"data:image/{0};base64,{1}\" /><br/></body></html>", Path.GetExtension(inputFileName).Substring(1), strBase64);
						var credential = new NetworkCredential("nozhenko@kr.zt.ukrtel.net", "password");

						smtpClient = new SmtpClient("mail.ukrpost.ua", 25);
                        smtpClient.Credentials = credential;

						//mailMessage = new MailMessage("nozhenko@kr.zt.ukrtel.net", "4others2@gmail.com", "Test html (with Content-Type + Content-Disposition)", body);
						mailMessage = new MailMessage("nozhenko@kr.zt.ukrtel.net", "4others2@gmail.com, 4others@ua.fm, 4others@ukr.net");

                        mailMessage.Headers.Add("Content-Type", "text/html; charset=\"UTF-8\"");
                        mailMessage.Headers.Add("Content-Disposition", "inline");
                        
                        mailMessage.IsBodyHtml = true;
                        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                        mailMessage.Subject = "Test html";

                        //ContentType mimeType = new ContentType("text/html");
                        //AlternateView alternate = new AlternateView(body, mimeType);

                        //mailMessage.AlternateViews.Add(alternate);

                        //mailMessage.BodyTransferEncoding = TransferEncoding.Base64;

                        mailMessage.Body = body;

                        smtpClient.Send(mailMessage);
                    }
                #endif
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        #if TEST_DISPOSE
            static string PatchFileName(string fileName)
            {
                var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                return Path.Combine(currentDirectory, fileName);
            }

            static Stream GetImage(string fileName)
            {
                TestMemoryStream memoryStream = null;

                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    memoryStream = new TestMemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                }

                return memoryStream;
            }

            static Stream CopyStream(Stream streamInput)
            {
                Stream streamOutput = new TestMemoryStream();
                
                streamInput.CopyTo(streamOutput);
                streamInput.Position = 0;
                streamOutput.Position = 0;

                return streamOutput;
            }
        #endif
    }
}
