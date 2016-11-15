using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn6
{
    public partial class ThisAddIn
    {
        const string
            CustomMessageClass = "IPM.Note.CustomOutlookFormRegion";

        public static Regex
            regexFrom = new Regex("(?<=From:.*?<).*?(?=>)", RegexOptions.Singleline | RegexOptions.IgnoreCase),
            regexJira = new Regex("(?<=^X-JIRA-FingerPrint:\\s).*?(?=$)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        Outlook.Explorers
            explorers;

        List<Outlook.Explorer>
            listExplorers=new List<Outlook.Explorer>();

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Startup");

            explorers = Application.Explorers;
            explorers.NewExplorer += new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
            foreach (Outlook.Explorer explorer in explorers)
            {
                explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
                listExplorers.Add(explorer);
            }
        }

        void Explorers_NewExplorer(Microsoft.Office.Interop.Outlook.Explorer Explorer)
        {
            Explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
            listExplorers.Add(Explorer);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Shutdown");

            explorers.NewExplorer -= new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);

            for (int i = 0; i < listExplorers.Count; ++i)
            {
                listExplorers[i].SelectionChange -= new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
                listExplorers[i] = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        void Explorer_SelectionChange()
        {
            WriteToLog("Explorer_SelectionChange");

            Outlook.Explorer
                explorer;

            Outlook.MailItem
                mailItem;

            string
                jira=string.Empty;

            if ((explorer = Application.ActiveExplorer()) == null
                || explorer.Selection == null
                || explorer.Selection.Count == 0
                || (mailItem = explorer.Selection[1] as Outlook.MailItem) == null
                || mailItem.MessageClass == CustomMessageClass
                /*|| (jira=GetMailItemHeaderItem(mailItem, regexJira)) == string.Empty*/)
                return;

            //WriteToLog(string.Format("{0} -> call ChangeMessageClass()", jira));

            ChangeMessageClass(mailItem);
        }

        void ChangeMessageClass(Outlook.MailItem mailItem)
        {
            mailItem.MessageClass = CustomMessageClass;
            mailItem.Save();
        }

        public static string GetMailItemHeaderItem(Outlook.MailItem mailItem, Regex regex)
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

                Match
                    match = regex.Match(header);

                header = match.Success ? match.Value.Trim() : string.Empty;
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

        public static void WriteToLog(string msg)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "TestOutlookAddIn6";
            tmpEventLog.WriteEntry(msg, EventLogEntryType.Information);
        }

        public static Outlook.Recipient GetCurrenUser()
        {
            Outlook.Recipient
                currentUser = null;

            Outlook.NameSpace
                nameSpace;

            if ((nameSpace = Globals.ThisAddIn.Application.GetNamespace("MAPI")) != null)
                currentUser = nameSpace.CurrentUser;

            return currentUser;
        }
    }
}
