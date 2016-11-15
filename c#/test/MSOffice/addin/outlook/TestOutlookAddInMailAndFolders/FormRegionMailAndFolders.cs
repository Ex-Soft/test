//#define TRANSPORT_MESSAGE_HEADERS_W

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;

namespace TestOutlookAddInMailAndFolders
{
    partial class FormRegionMailAndFolders
    {
        const string
            userPropertyName = "TestUserProperty",
            headerKey = "MySuperPuperTag",
            PR_TRANSPORT_MESSAGE_HEADERS = "http://schemas.microsoft.com/mapi/proptag/0x007D001E", // for ANSI (PT_STRING8)
            PR_TRANSPORT_MESSAGE_HEADERS_W = "http://schemas.microsoft.com/mapi/proptag/0x007D001F"; // for Unicode

        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)]
        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass("IPM.Note.FormRegionMailAndFolders")]
        [Microsoft.Office.Tools.Outlook.FormRegionName("TestOutlookAddInMailAndFolders.FormRegionMailAndFolders")]
        public partial class FormRegionMailAndFoldersFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void FormRegionMailAndFoldersFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void FormRegionMailAndFolders_FormRegionShowing(object sender, System.EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        webBrowser1.DocumentText = mailItem.HTMLBody;
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void FormRegionMailAndFolders_FormRegionClosed(object sender, System.EventArgs e)
        {
        }

        private void buttonGetCurrentFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.Explorer
                    explorer = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (explorer = mailItem.Application.ActiveExplorer()) != null)
                    {
                        textBoxLog.Text = explorer.CurrentFolder.FolderPath;
                    }
                }
                finally
                {
                    if (explorer != null)
                    {
                        Marshal.ReleaseComObject(explorer);
                        explorer = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonGetFolders_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook._NameSpace
                    nameSpace = null;

                Outlook.MAPIFolder
                    defaultFolder = null,
                    parentFolder = null,
                    tmpFolder = null;

                try
                {
                    if((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace=mailItem.Application.GetNamespace("MAPI"))!=null
                        && (defaultFolder=nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox))!=null
                        && (parentFolder=defaultFolder.Parent as Outlook.MAPIFolder)!=null)
                    {
                        string
                            tmpString;

                        if(!string.IsNullOrEmpty(tmpString=textBoxLog.Text.Trim())
                            && (tmpFolder = GetFolder(parentFolder, tmpString))!=null)
                            tmpFolder = GetFolder(tmpFolder, "Inbox");

                        tmpString = string.Empty;
                        foreach (Outlook.MAPIFolder f in parentFolder.Folders)
                        {
                            if (!string.IsNullOrEmpty(tmpString))
                                tmpString += " ";

                            tmpString += f.FolderPath;
                        }

                        textBoxLog.Text = string.Format("{0} {1} {2}", parentFolder.FullFolderPath, parentFolder.FolderPath, parentFolder.Folders.Count);
                    }
                }
                finally
                {
                    if (tmpFolder != null)
                    {
                        Marshal.ReleaseComObject(tmpFolder);
                        tmpFolder = null;
                    }

                    if (parentFolder != null)
                    {
                        Marshal.ReleaseComObject(parentFolder);
                        parentFolder = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonSetFolder_Click(object sender, EventArgs e)
        {
            string
                folderName;

            if(string.IsNullOrEmpty(folderName=textBoxLog.Text.Trim()))
                return;

            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook._NameSpace
                    nameSpace = null;

                Outlook.MAPIFolder
                    defaultFolder = null,
                    parentFolder = null;

                Outlook.Explorer
                    explorer = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace = mailItem.Application.GetNamespace("MAPI")) != null
                        && (defaultFolder = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)) != null
                        && (parentFolder = defaultFolder.Parent as Outlook.MAPIFolder) != null
                        && (explorer = mailItem.Application.ActiveExplorer()) != null)
                    {
                        explorer.CurrentFolder = parentFolder.Folders[folderName];
                        explorer.CurrentFolder.Display();
                    }
                }
                finally
                {
                    if (explorer != null)
                    {
                        Marshal.ReleaseComObject(explorer);
                        explorer = null;
                    }

                    if (parentFolder != null)
                    {
                        Marshal.ReleaseComObject(parentFolder);
                        parentFolder = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            string
                folderName;

            if (string.IsNullOrEmpty(folderName = textBoxLog.Text.Trim()))
                return;

            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook._NameSpace
                    nameSpace = null;

                Outlook.MAPIFolder
                    defaultFolder = null,
                    parentFolder = null,
                    tmpFolder = null;

                Outlook.Explorer
                    explorer = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace = mailItem.Application.GetNamespace("MAPI")) != null
                        && (defaultFolder = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)) != null
                        && (parentFolder = defaultFolder.Parent as Outlook.MAPIFolder) != null
                        && (explorer = mailItem.Application.ActiveExplorer()) != null)
                    {
                        if ((tmpFolder = GetFolder(parentFolder, folderName)) == null)
                            tmpFolder = parentFolder.Folders.Add(folderName, Outlook.OlDefaultFolders.olFolderDrafts);

                        string
                            folderFolderName = "Inbox";

                        if (GetFolder(tmpFolder, folderFolderName) == null)
                            tmpFolder.Folders.Add(folderFolderName, Outlook.OlDefaultFolders.olFolderDrafts);

                        folderFolderName = "Sent Items";
                        if (GetFolder(tmpFolder, folderFolderName) == null)
                            tmpFolder.Folders.Add(folderFolderName, Outlook.OlDefaultFolders.olFolderDrafts);

                        explorer.CurrentFolder = parentFolder.Folders[folderName];
                        explorer.CurrentFolder.Display();
                    }
                }
                finally
                {
                    if (explorer != null)
                    {
                        Marshal.ReleaseComObject(explorer);
                        explorer = null;
                    }

                    if (tmpFolder != null)
                    {
                        Marshal.ReleaseComObject(tmpFolder);
                        tmpFolder = null;
                    }

                    if (parentFolder != null)
                    {
                        Marshal.ReleaseComObject(parentFolder);
                        parentFolder = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonMoveMailItem_Click(object sender, EventArgs e)
        {
            string
                folderName="test";

            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook._NameSpace
                    nameSpace = null;

                Outlook.MAPIFolder
                    defaultFolder = null,
                    parentFolder = null,
                    destFolder = null;

                Outlook.Explorer
                    explorer = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace = mailItem.Application.GetNamespace("MAPI")) != null
                        && (defaultFolder = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)) != null
                        && (parentFolder = defaultFolder.Parent as Outlook.MAPIFolder) != null
                        && (destFolder = parentFolder.Folders[folderName]) != null
                        && (explorer = mailItem.Application.ActiveExplorer()) != null)
                    {
                        mailItem.Move(destFolder);
                        explorer.CurrentFolder = destFolder;
                        explorer.CurrentFolder.Display();
                    }
                }
                finally
                {
                    if (explorer != null)
                    {
                        Marshal.ReleaseComObject(explorer);
                        explorer = null;
                    }

                    if (destFolder != null)
                    {
                        Marshal.ReleaseComObject(destFolder);
                        destFolder = null;
                    }

                    if (parentFolder != null)
                    {
                        Marshal.ReleaseComObject(parentFolder);
                        parentFolder = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonCreateRule_Click(object sender, EventArgs e)
        {
            string
                folderName = "Test",
                folderFolderName = "Inbox";

            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.NameSpace
                    nameSpace = null;

                Outlook.Rules
                    rules = null;

                Outlook.Rule
                    rule = null;

                Outlook.MAPIFolder
                    defaultFolder = null,
                    parentFolder = null,
                    tmpFolder = null,
                    destFolder = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace = mailItem.Application.GetNamespace("MAPI")) != null
                        && (rules = mailItem.Application.Session.DefaultStore.GetRules()) != null
                        && (defaultFolder = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)) != null
                        && (parentFolder = defaultFolder.Parent as Outlook.MAPIFolder) != null
                        && (tmpFolder = GetFolder(parentFolder, folderName)) !=null
                        && (destFolder = GetFolder(tmpFolder, folderFolderName)) != null)
                    {
                        foreach (Outlook.Rule r in rules)
                        {
                            string
                                tmpString = string.Format("{0} {1} {2} {3} {4}",
                                    r.Name,
                                    r.Conditions.From.Recipients.Count > 0 ? r.Conditions.From.Recipients[1].Name : "!From.Recipients",
                                    r.Conditions.SentTo.Recipients.Count > 0 ? r.Conditions.SentTo.Recipients[1].Name : "!SendTo.Recipients",
                                    r.Actions.MoveToFolder.Folder !=null ? r.Actions.MoveToFolder.Folder.FullFolderPath : "!MoveToFolder",
                                    r.Actions.CopyToFolder.Folder != null ? r.Actions.CopyToFolder.Folder.FullFolderPath : "!CopyToFolder");
                        }

                        rule = rules.Create("TestRule", Outlook.OlRuleType.olRuleReceive);
                        rule.Conditions.From.Enabled = true;
                        rule.Conditions.From.Recipients.Add("test@mail.ru");
                        //rule.Conditions.From.Recipients.ResolveAll();

                        rule.Actions.MoveToFolder.Enabled = true;
                        rule.Actions.MoveToFolder.Folder = destFolder;
                        rule.Actions.DesktopAlert.Enabled = true;

                        rules.Save(false);

                        textBoxLog.Text = "Done";
                    }
                }
                finally
                {
                    if (destFolder != null)
                    {
                        Marshal.ReleaseComObject(destFolder);
                        destFolder = null;
                    }

                    if (tmpFolder != null)
                    {
                        Marshal.ReleaseComObject(tmpFolder);
                        tmpFolder = null;
                    }

                    if (parentFolder != null)
                    {
                        Marshal.ReleaseComObject(parentFolder);
                        parentFolder = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (rule != null)
                    {
                        Marshal.ReleaseComObject(rule);
                        rule = null;
                    }

                    if (rules != null)
                    {
                        Marshal.ReleaseComObject(rules);
                        rules = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        Outlook.MAPIFolder GetFolder(Outlook.MAPIFolder folder, string folderName)
        {
            Outlook.Folder
                result = null;

            Regex
                regex = new Regex(string.Format(@"(?<={0}\\){1}", folder.FolderPath.Replace("\\","\\\\"), folderName), RegexOptions.IgnoreCase);

            Match
                match;

            foreach (Outlook.Folder f in folder.Folders)
            {
                match = regex.Match(f.FolderPath);
                if(match.Success)
                {
                    result = f;
                    break;
                }
            }

            return result;
        }

        private void buttonGetMailItem_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        textBoxLog.Text = !string.IsNullOrEmpty(mailItem.EntryID) ? mailItem.EntryID : "string.IsNullOrEmpty()";
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonChangeMailItem_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        Regex
                            regex = new Regex("(?<=<a href=\".*?\">).*?(?=</a>)");

                        mailItem.HTMLBody = regex.Replace(mailItem.HTMLBody, string.Format("Забить на задачу ({0}).",DateTime.Now));
                        mailItem.Save();
                        webBrowser1.DocumentText = mailItem.HTMLBody;
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonAddUserProperty_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.UserProperty
                    userProperty = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        if ((userProperty = mailItem.UserProperties[userPropertyName]) == null)
                            userProperty = mailItem.UserProperties.Add(userPropertyName, Outlook.OlUserPropertyType.olText, false, Outlook.OlFormatText.olFormatTextText);
                        userProperty.Value = "UserProperty";
                        mailItem.Save();
                    }
                }
                finally
                {
                    if (userProperty != null)
                    {
                        Marshal.ReleaseComObject(userProperty);
                        userProperty = null;
                    }
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonGetUserProperty_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.UserProperty
                    userProperty = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        textBoxLog.Text = (userProperty = mailItem.UserProperties[userPropertyName]) != null ? (string)userProperty.Value : "null";
                    }
                }
                finally
                {
                    if (userProperty != null)
                    {
                        Marshal.ReleaseComObject(userProperty);
                        userProperty = null;
                    }
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonFindMailItem_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook._NameSpace
                    nameSpace = null;

                Outlook.MAPIFolder
                    defaultFolder = null;

                Outlook.Items
                    items = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (nameSpace = mailItem.Application.GetNamespace("MAPI")) != null
                        && (defaultFolder = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)) != null)
                    {
                        string
                            filter = "@SQL=\"http://schemas.microsoft.com/mapi/string/{00020329-0000-0000-C000-000000000046}/TestUserProperty/0000001f\" = 'UserProperty'";

                        items = defaultFolder.Items.Restrict(filter);

                        filter = "@SQL=\"http://schemas.microsoft.com/mapi/string/{00020329-0000-0000-C000-000000000046}/TestUserProperty/0000001f\" is null";
                        items = defaultFolder.Items.Restrict(filter);

                        filter = "@SQL=\"http://schemas.microsoft.com/mapi/string/{00020329-0000-0000-C000-000000000046}/TestUserProperty/0000001f\" is not null";
                        items = defaultFolder.Items.Restrict(filter);

                        string
                            TransportMessageHeadersSchema =
                            #if !TRANSPORT_MESSAGE_HEADERS_W
                                PR_TRANSPORT_MESSAGE_HEADERS
                            #else
                                PR_TRANSPORT_MESSAGE_HEADERS_W
                            #endif
                            ,
                            header = (string)mailItem.PropertyAccessor.GetProperty(TransportMessageHeadersSchema);

                        filter = string.Format("@SQL=\"{0}\" like '%{1}%'", TransportMessageHeadersSchema, "MySuperPuperTag: blah-blah-blah");
                        items = defaultFolder.Items.Restrict(filter);

                        filter = string.Format("[LastModificationTime] > \"{0}\"",new DateTime(2011,12,8,16,0,0).ToString("g"));
                        items = defaultFolder.Items.Restrict(filter);
                    }
                }
                finally
                {
                    if (items != null)
                    {
                        Marshal.ReleaseComObject(items);
                        items = null;
                    }

                    if (defaultFolder != null)
                    {
                        Marshal.ReleaseComObject(defaultFolder);
                        defaultFolder = null;
                    }

                    if (nameSpace != null)
                    {
                        Marshal.ReleaseComObject(nameSpace);
                        nameSpace = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonAppConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string
                    currentDir = Directory.GetCurrentDirectory(),
                    SmthKeyKeySignature = "SmthKey",
                    SmthKeyValue = !string.IsNullOrEmpty(ConfigurationManager.AppSettings[SmthKeyKeySignature]) ? ConfigurationManager.AppSettings[SmthKeyKeySignature] : "null" ;

                textBoxLog.Text = string.Format("Directory.GetCurrentDirectory(): {0} \"{1}\": \"{2}\"", currentDir, SmthKeyKeySignature, SmthKeyValue);
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonGetHeader_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        string
                            TransportMessageHeadersSchema =
                            #if !TRANSPORT_MESSAGE_HEADERS_W
                                PR_TRANSPORT_MESSAGE_HEADERS
                            #else
                                PR_TRANSPORT_MESSAGE_HEADERS_W
                            #endif
                            ,                            
                            header = (string)mailItem.PropertyAccessor.GetProperty(TransportMessageHeadersSchema);

                        Regex
                            regex = new Regex(string.Format("(?<=^{0}:\\s).*?(?=$)", headerKey), RegexOptions.Multiline | RegexOptions.IgnoreCase);

                        Match
                            match = regex.Match(header);

                        textBoxLog.Text = match.Success ? match.Value : string.Empty;
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonSetHeader_Click(object sender, EventArgs e)
        {
            string
                newValue;

            if(string.IsNullOrEmpty(newValue=textBoxLog.Text.Trim()))
                return;

            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        string
                            TransportMessageHeadersSchema =
                            #if !TRANSPORT_MESSAGE_HEADERS_W
                                PR_TRANSPORT_MESSAGE_HEADERS
                            #else
                                PR_TRANSPORT_MESSAGE_HEADERS_W
                            #endif
                            ,
                            header = (string)mailItem.PropertyAccessor.GetProperty(TransportMessageHeadersSchema);

                        Regex
                            regex = new Regex(string.Format("(?<=^{0}:\\s).*?(?=$)", headerKey), RegexOptions.Multiline | RegexOptions.IgnoreCase);

                        Match
                            match = regex.Match(header);

                        if (match.Success)
                        {
                            header = regex.Replace(header, newValue);
                            mailItem.PropertyAccessor.SetProperty(TransportMessageHeadersSchema, header);
                            mailItem.Save();
                        }
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonAddAttach_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        mailItem.Attachments.Add("d:\\test.txt", Outlook.OlAttachmentType.olByValue, 1, "Test Attachment");
                        mailItem.Save();
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonCloseExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.Explorer
                    explorer = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (explorer = mailItem.Application.ActiveExplorer()) != null)
                    {
                        explorer.Close();
                    }
                }
                finally
                {
                    if (explorer != null)
                    {
                        Marshal.ReleaseComObject(explorer);
                        explorer = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonCloseInspector_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                Outlook.Inspector
                    inspector = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null
                        && (inspector = mailItem.Application.ActiveInspector()) != null)
                    {
                        inspector.Close(Outlook.OlInspectorClose.olDiscard);
                    }
                }
                finally
                {
                    if (inspector != null)
                    {
                        Marshal.ReleaseComObject(inspector);
                        inspector = null;
                    }

                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonSetMessageClass_Click(object sender, EventArgs e)
        {
            string
                messageClass;

            if (string.IsNullOrEmpty(messageClass = textBoxLog.Text.Trim()))
                return;

            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        mailItem.MessageClass = messageClass;
                        mailItem.Save();
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonGetMessageClass_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        textBoxLog.Text = mailItem.MessageClass;
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            try
            {
                Outlook.MailItem
                    mailItem = null;

                try
                {
                    if ((mailItem = OutlookItem as Outlook.MailItem) != null)
                    {
                        mailItem.Close(Outlook.OlInspectorClose.olDiscard);
                    }
                }
                finally
                {
                    if (mailItem != null)
                    {
                        Marshal.ReleaseComObject(mailItem);
                        mailItem = null;
                    }
                }
            }
            catch (Exception eException)
            {
                string msg;

                ThisAddIn.WriteToLog(msg = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                textBoxLog.Text = msg;
            }
        }
    }
}
