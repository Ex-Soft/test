using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn1
{
    public partial class ThisAddIn
    {
        MyUserControl
            myUserControl1;

        Microsoft.Office.Tools.CustomTaskPane
            myCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            foreach(Outlook.Explorer explorer in Application.Explorers)
                explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(explorer_SelectionChange);

            Application.Explorers.NewExplorer += new Microsoft.Office.Interop.Outlook.ExplorersEvents_NewExplorerEventHandler(Explorers_NewExplorer);
            Application.Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

            Application.ItemLoad += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemLoadEventHandler(Application_ItemLoad);

            myUserControl1 = new MyUserControl();
            myCustomTaskPane = CustomTaskPanes.Add(myUserControl1, "My Task Pane");
            myCustomTaskPane.Visible = true;
        }

        void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            WriteToLog("Inspectors_NewInspector");
        }

        void Explorers_NewExplorer(Microsoft.Office.Interop.Outlook.Explorer Explorer)
        {
            WriteToLog("Explorers_NewExplorer");

            Explorer.SelectionChange += new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(explorer_SelectionChange);
        }

        void explorer_SelectionChange()
        {
            WriteToLog("explorer_SelectionChange");
        }

        void Application_ItemLoad(object Item)
        {
            WriteToLog("Application_ItemLoad");

            Outlook.MailItem
                mailItem;

            if ((mailItem = Item as Outlook.MailItem) != null)
            {
                mailItem.Open += new Microsoft.Office.Interop.Outlook.ItemEvents_10_OpenEventHandler(MailItem_Open);
                mailItem.Read += new Microsoft.Office.Interop.Outlook.ItemEvents_10_ReadEventHandler(MailItem_Read);
                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)mailItem).Close += new Microsoft.Office.Interop.Outlook.ItemEvents_10_CloseEventHandler(MailItem_Close);
            }
        }

        void MailItem_Close(ref bool Cancel)
        {
            WriteToLog("MailItem_Close");
        }

        void MailItemHeaderShow(Outlook.MailItem mailItem)
        {
            if(mailItem==null)
                return;

            System.Windows.Forms.TextBox
                tmpTextBox;

            if ((tmpTextBox = myUserControl1.Controls["textBox1"] as System.Windows.Forms.TextBox) != null)
            {
                //http://blogs.msdn.com/b/zainnab/archive/2008/07/01/using-visual-studio-2008-vsto-outlook-to-pull-out-rfc-822-header-data.aspx
                //http://www.lessanvaezi.com/email-headers-from-outlook-mailitem/

                string
                    TransportMessageHeadersSchema = "http://schemas.microsoft.com/mapi/proptag/0x007D001E",
                    // TransportMessageHeadersSchema = "http://schemas.microsoft.com/mapi/proptag/0x007D001F", // 4 Unicode
                    header=string.Empty;

                try
                {
                    if (mailItem.PropertyAccessor != null)
                    {
                        Outlook.PropertyAccessor
                            propertyAccessor = mailItem.PropertyAccessor;

                        header = (string) propertyAccessor.GetProperty(TransportMessageHeadersSchema);
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

                tmpTextBox.Text = header;
            }
        }

        void MailItem_Read()
        {
            WriteToLog("MailItem_Read");
            MailItemProcess();
        }

        void MailItem_Open(ref bool Cancel)
        {
            WriteToLog("MailItem_Open");
            MailItemProcess();
        }

        void MailItemProcess()
        {
            Outlook.Inspector
                inspector = Application.ActiveInspector();

            Outlook.Explorer
                explorer = Application.ActiveExplorer();

            object
                tmpObject = null;

            Outlook.MailItem
                mailItem;

            try
            {
                if (inspector != null
                    && inspector.CurrentItem != null)
                    tmpObject = inspector.CurrentItem;

                if (explorer != null
                    && explorer.Selection != null
                    && explorer.Selection.Count > 0)
                {
                    if(File.Exists("1"))
                        tmpObject = explorer.Selection[1];
                }
                if ((mailItem = tmpObject as Outlook.MailItem) != null)
                    MailItemHeaderShow(mailItem);
            }
            catch (Exception eException)
            {
                WriteToLog(eException.Message);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
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

            tmpEventLog.Source = "TestOutlookAddIn1";
            tmpEventLog.WriteEntry(msg, EventLogEntryType.Information);
        }
    }
}
