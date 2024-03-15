//#define TEST_LINK_TO_IMG
//#define TEST_DISPOSE
//#define TEST_DISPOSE_WITH_USING
//#define TEST_SMTP_SERVER
//#define TEST_HEADER
#define TEST_IMG_IN_BODY

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

                const string host = "sandbox.smtp.mailtrap.io";
                const int port = 25;
                const string user = "";
                const string password = "";
                const string from = "from@ex_soft.com";
                const string to = "to@ex_soft.com";

                //const string host = "smtp.freesmtpservers.com";
                //const int port = 25;

                //const string host = "smtp-relay.brevo.com";
                //const int port = 587;
                //const string user = "";
                //const string password = "";

                #if TEST_LINK_TO_IMG
					using (mailMessage = new MailMessage())
					{
						mailMessage.From = new MailAddress(from);
						mailMessage.To.Add(to);
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
							smtpClient = new SmtpClient(host, port);
							smtpClient.EnableSsl = true;
							smtpClient.Credentials = new NetworkCredential(user, password);
							smtpClient.Send(mailMessage);
						}
						catch (Exception eException)
						{
							Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
						}
						finally
                        {
                            smtpClient?.Dispose();
                        }
					}
                #endif

                #if TEST_DISPOSE
                    using (mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(from);
                        mailMessage.To.Add(to);
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
                            using (smtpClient = new SmtpClient(host, port))
                        #else
                            try
                        #endif
                            {
                                #if !TEST_DISPOSE_WITH_USING
                                    smtpClient = new SmtpClient(host, port);
                                #endif

                                smtpClient.EnableSsl = false;
                                smtpClient.Credentials = new NetworkCredential(user, password);
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

                #if TEST_SMTP_SERVER
				    var credential = new NetworkCredential(user, password);

                    smtpClient = new SmtpClient(host, port);
				    smtpClient.Credentials = credential;
                    mailMessage = new MailMessage(from, to, "Test Smtp Server", "Test Smtp Server");
                    smtpClient.Send(mailMessage);
                #endif

                #if TEST_HEADER
                    smtpClient = new SmtpClient(host, port);
                    smtpClient.Credentials = new NetworkCredential(user, password);
                    mailMessage = new MailMessage(from, to, "Test Custom Tag", "C in header MySuperPuperTag ;)");
                    mailMessage.Headers.Add("MySuperPuperTag", "blah-blah-blah");
                    smtpClient.Send(mailMessage);
                    //smtpClient.Send(from, to, "Subject", "Body");
                #endif

                #if TEST_IMG_IN_BODY
                    string
                        currentDirectory = Directory.GetCurrentDirectory(),
                        inputFileName = "clear_icon.png";

                    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

                    if (File.Exists(inputFileName = Path.Combine(currentDirectory, inputFileName)))
                    {
                        var encbuff = File.ReadAllBytes(inputFileName);
                        var strBase64 = Convert.ToBase64String(encbuff);
						var body = $"<html><body><b>Hi!!!</b><br/><img src=\"data:image/{Path.GetExtension(inputFileName)[1..]};base64,{strBase64}\" /><br/></body></html>";
                        
                        smtpClient = new SmtpClient(host, port);
                        smtpClient.Credentials = new NetworkCredential(user, password);

						mailMessage = new MailMessage(from, to, "Test html (with Content-Type + Content-Disposition)", body);
						//mailMessage = new MailMessage(from, to);

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
