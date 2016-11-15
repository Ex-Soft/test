//#define SHOW_PATH
//#define TEST_ACTIVE_EXPLORER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn4
{
    public partial class ThisAddIn
    {
        const string
            CustomMessageClass = "IPM.Note.CustomReadingPane";

        #if TEST_ACTIVE_EXPLORER
            Outlook.Explorer
                explorer;
        #else
            Outlook.Explorers
                explorers;
        #endif

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Startup");

            Application.Explorers.NewExplorer += new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
            
            #if TEST_ACTIVE_EXPLORER
                explorer = Application.ActiveExplorer();
                explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
            #else
                explorers = Application.Explorers;
                WriteToLog(string.Format("explorers.Count={0}", explorers.Count));
                foreach (Outlook.Explorer explorer in explorers)
                    explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
            #endif

            Application.ItemLoad += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemLoadEventHandler(Application_ItemLoad);
        }

        void Application_ItemLoad(object Item)
        {
            WriteToLog("Application_ItemLoad");

            Outlook.MailItem
                mailItem;

            if ((mailItem = Item as Outlook.MailItem) != null)
                WriteToLog(mailItem.MessageClass);

            #if !TEST_ACTIVE_EXPLORER
                Outlook.Explorer
                    activeExplorer = Application.ActiveExplorer();

                foreach (Outlook.Explorer explorer in explorers)
                {
                    if (explorer == activeExplorer)
                        ;
                }
            #endif

            #if SHOW_PATH
                Outlook.Explorer
                    explorer;

                if ((explorer = Application.ActiveExplorer()) == null)
                    return;

                if (explorer.CurrentFolder != null)
                    WriteToLog(string.Format("Name: {0} FolderPath: {1} FullFolderPath: {2} WebViewOn: {3}", explorer.CurrentFolder.Name, explorer.CurrentFolder.FolderPath, explorer.CurrentFolder.FullFolderPath, explorer.CurrentFolder.WebViewOn));
            #endif
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            WriteToLog("ThisAddIn_Shutdown");

            #if TEST_ACTIVE_EXPLORER
                explorer.SelectionChange -= new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
            #else
                WriteToLog(string.Format("explorers.Count={0}", explorers.Count));
                foreach (Outlook.Explorer explorer in explorers)
                    explorer.SelectionChange -= new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
            #endif
        }

        void Explorers_NewExplorer(Microsoft.Office.Interop.Outlook.Explorer Explorer)
        {
            WriteToLog("Explorers_NewExplorer");
            Explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(Explorer_SelectionChange);
        }

        void Explorer_SelectionChange()
        {
            WriteToLog("Explorer_SelectionChange");

            Outlook.Explorer
                explorer;

            if((explorer = Application.ActiveExplorer()) == null)
                return;

            #if SHOW_PATH
                if(explorer.CurrentFolder!=null)
                    WriteToLog(string.Format("Name: {0} FolderPath: {1} FullFolderPath: {2} WebViewOn: {3}", explorer.CurrentFolder.Name, explorer.CurrentFolder.FolderPath, explorer.CurrentFolder.FullFolderPath, explorer.CurrentFolder.WebViewOn));
            #endif

            Outlook.MailItem
                mailItem;

            if (explorer.Selection == null
                || explorer.Selection.Count == 0
                || (mailItem = explorer.Selection[1] as Outlook.MailItem) == null
                || mailItem.MessageClass == CustomMessageClass
                /*|| GetMailItemHeaderFrom(mailItem)==string.Empty*/)
                return;

            ChangeMessageClass(mailItem);
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

            tmpEventLog.Source = "TestOutlookAddIn4";
            tmpEventLog.WriteEntry(msg, EventLogEntryType.Information);
        }
    }
}
