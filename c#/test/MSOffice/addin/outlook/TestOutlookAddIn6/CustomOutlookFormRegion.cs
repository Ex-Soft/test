using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Softline.DocNet.UI.Plugins.Explorer;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace TestOutlookAddIn6
{
    partial class CustomOutlookFormRegion
    {
        static int
            count = 0;

        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Note.CustomOutlookFormRegion")]
        [Microsoft.Office.Tools.Outlook.FormRegionName("TestOutlookAddIn6.CustomOutlookFormRegion")]
        public partial class CustomOutlookFormRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void CustomOutlookFormRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void CustomOutlookFormRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
            ThisAddIn.WriteToLog("CustomOutlookFormRegion_FormRegionShowing");

            Outlook.MailItem
                mailItem;

            if ((mailItem = OutlookItem as Outlook.MailItem) != null)
            {
                button2.Visible = (++count % 2) != 0;
                textBox1.Text = ThisAddIn.GetMailItemHeaderItem(mailItem, ThisAddIn.regexFrom);
                labelSubject.Text = mailItem.Subject;
                webBrowserBody.DocumentText = mailItem.HTMLBody;
            }
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void CustomOutlookFormRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
            ThisAddIn.WriteToLog("CustomOutlookFormRegion_FormRegionClosed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Outlook.MailItem
                mailItem;

            if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                System.Windows.Forms.MessageBox.Show(mailItem.MessageClass);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Outlook.MailItem
                mailItem;

            if ((mailItem = OutlookItem as Outlook.MailItem) != null)
            {
                mailItem.MessageClass = "INP.Note";
                mailItem.Save();
                System.Windows.Forms.MessageBox.Show(mailItem.MessageClass);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                WebRequest
                       request = WebRequest.Create("http://nozhenko-s8k/DocNet/_layouts/DocNet/Service/ClientApi.asmx/GetDocumentSingInfo");

                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                request.Credentials = CredentialCache.DefaultCredentials;

                int
                    taskId = 6;

                string
                    postData = string.Format("{{ \"taskId\": {0} }}", taskId);

                byte[]
                    byteArray = Encoding.UTF8.GetBytes(postData);

                request.ContentLength = byteArray.Length;

                Stream
                    dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse
                    response = request.GetResponse();

                StreamReader
                    reader = new StreamReader(response.GetResponseStream());

                string
                    result = reader.ReadToEnd().Trim();

                reader.Close();
                response.Close();

                SignPdfModule
                    signPdfModule = new SignPdfModule();

                Regex
                    regexFilePath = new Regex("(?<=\"filePath\":\").*?(?=\")"),
                    regexInstruction = new Regex("(?<=\"instructions\":\").*?(?=\")");

                Match
                    match = regexFilePath.Match(result);

                string
                    filePath = match.Success ? match.Value.Trim() : string.Empty;

                match = regexInstruction.Match(result);

                string
                    instructions = match.Success ? match.Value.Trim() : string.Empty;

                SignResult
                    signResult = signPdfModule.DoSigning(filePath, instructions);

                if (signResult.Succeed)
                {
                    byte[]
                        file = Convert.FromBase64String(signResult.FileBase64);

                    BinaryWriter
                        binaryWriter = new BinaryWriter(new FileStream("binary.pdf", FileMode.Create, FileAccess.Write));

                    binaryWriter.Write(file);
                    binaryWriter.Close();
                }
            }
            catch (Exception eException)
            {
                ThisAddIn.WriteToLog(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        private void webBrowserBody_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            ThisAddIn.WriteToLog("webBrowserBody_DocumentCompleted");
        }
    }
}
