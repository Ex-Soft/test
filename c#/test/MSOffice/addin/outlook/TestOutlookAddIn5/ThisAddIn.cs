using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn5
{
    public partial class ThisAddIn
    {
        const string
            CustomMessageClass = "IPM.Note.CustomFormRegion";

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Startup");

            Application.Explorers.NewExplorer += new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);

            WriteToLog(string.Format("Application.Explorers.Count={0}", Application.Explorers.Count));
            foreach (Outlook.Explorer explorer in Application.Explorers)
                explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);

            Application.ItemLoad += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemLoadEventHandler(Application_ItemLoad);
        }

        void Application_ItemLoad(object Item)
        {
            WriteToLog("Application_ItemLoad");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Shutdown");
        }

        void Explorers_NewExplorer(Microsoft.Office.Interop.Outlook.Explorer Explorer)
        {
            WriteToLog("Explorers_NewExplorer");
            Explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
        }

        void Explorer_SelectionChange()
        {
            WriteToLog("Explorer_SelectionChange");
            
            /*
            Outlook.Explorer
                explorer;

            Outlook.MailItem
                mailItem;

            if ((explorer = Globals.ThisAddIn.Application.ActiveExplorer()) == null
                || explorer.Selection == null
                || explorer.Selection.Count == 0
                || (mailItem = explorer.Selection[1] as Outlook.MailItem) == null
                || mailItem.MessageClass == CustomMessageClass
                || GetMailItemHeaderFrom(mailItem)==string.Empty)
                return;

            ChangeMessageClass(mailItem);
            */
        }

        void ChangeMessageClass(Outlook.MailItem mailItem)
        {
            mailItem.MessageClass = CustomMessageClass;
            mailItem.Save();
        }

        public static string GetMailItemHeaderFrom(Outlook.MailItem mailItem)
        {
            if (mailItem == null)
                return string.Empty;

            string
                TransportMessageHeadersSchema = "http://schemas.microsoft.com/mapi/proptag/0x007D001E",
                header = string.Empty;

            try
            {
                if (mailItem.PropertyAccessor != null)
                {
                    Outlook.PropertyAccessor
                        propertyAccessor = mailItem.PropertyAccessor;

                    header = (string)propertyAccessor.GetProperty(TransportMessageHeadersSchema);
                }

                Regex
                    r = new Regex("(?<=From:.*?<).*?(?=>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                Match
                    match = r.Match(header);

                header = match.Success ? match.Value : string.Empty;
            }
            catch (Exception eException)
            {
                header = eException.Message;
            }

            return header;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion

        void WriteToLog(string msg)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "TestOutlookAddIn5";
            tmpEventLog.WriteEntry(msg, EventLogEntryType.Information);
        }
    }
}
