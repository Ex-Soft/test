using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace TestOutlookAddIn2
{
    public partial class ThisAddIn
    {
        private Office.CommandBar _objMenuBar;
        private Office.CommandBarPopup _objNewMenuBar;

        private Office.CommandBar _objToolBar;
        private Office.CommandBarButton _objNewToolBarButton;

        private Outlook.Inspectors Inspectors;

        private Office.CommandBarButton _objButton;
        private Office.CommandBarButton _objEmailToolBarButton1;
        private Office.CommandBarButton _objEmailToolBarButton2;
        private Office.CommandBarButton _objTaskToolBarButton;
        private Office.CommandBarButton _objNoteToolBarButton;

        private string menuTag = "MyMenu";
        private string menuToolBarTag = "MyToolBarButton";
        private string toolBarTagEmail = "MyEmailToolBar";
        private string toolBarTagTask = "MyTaskToolBar";
        private string toolBarTagNote = "MyNoteToolBar";

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.MyMenuBar();
            this.MyToolBar();

            Inspectors = this.Application.Inspectors;
            Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(AddToEmail);
            Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(AddToTask);
            Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(AddToNotes);
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

        #region "Outlook07 Menu"
        private void MyMenuBar()
        {
            this.ErsMyMenuBar();

            try
            {
                //Define the existent Menu Bar
                _objMenuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;
                //Define the new Menu Bar into the old menu bar
                _objNewMenuBar = (Office.CommandBarPopup)
                                 _objMenuBar.Controls.Add(Office.MsoControlType.msoControlPopup
                                                        , missing
                                                        , missing
                                                        , missing
                                                        , false);

                if (_objNewMenuBar != null)
                {
                    _objNewMenuBar.Caption = "My Menu";
                    _objNewMenuBar.Tag = menuTag;
                    _objButton = (Office.CommandBarButton)_objNewMenuBar.Controls.
                    Add(Office.MsoControlType.msoControlButton, missing,
                        missing, 1, true);
                    _objButton.Style = Office.MsoButtonStyle.
                        msoButtonIconAndCaption;
                    _objButton.Caption = "My menu item.";
                    //Icon 
                    _objButton.FaceId = 500;
                    _objButton.Tag = "ItemTag";
                    //EventHandler
                    _objButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objButton_Click);
                    _objNewMenuBar.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(), "Error Message");
            }
        }
        #endregion

        #region "Outlook07 ToolBar"

        private void MyToolBar()
        {

            try
            {
                // Delete the existing instance, if applicable.
                Office.CommandBar _objTmpToolBar = (Office.CommandBar)this.Application.ActiveExplorer()
                    .CommandBars.FindControl(missing, missing,
                   menuToolBarTag, true);
                if (_objTmpToolBar != null)
                    _objTmpToolBar.Delete();

                // Add a new toolbar to the CommandBars collection
                // of the Explorer window.
                _objToolBar = this.Application.ActiveExplorer()
                    .CommandBars.Add(menuToolBarTag,
                    Office.MsoBarPosition.msoBarTop, false, true);
                if (_objToolBar != null)
                {
                    // Add a button to the new toolbar.
                    _objNewToolBarButton = (Office.CommandBarButton)_objToolBar
                        .Controls.Add(Office.MsoControlType.msoControlButton,
                        missing, missing, 1, true);
                    _objNewToolBarButton.Style = Office.MsoButtonStyle
                        .msoButtonIconAndCaption;
                    _objNewToolBarButton.Caption = "My ToolBar Button";
                    _objNewToolBarButton.FaceId = 65;
                    _objNewToolBarButton.Tag = menuToolBarTag;
                    _objNewToolBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objToolBarButton_Click);
                    _objNewToolBarButton.Visible = true;
                }


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString()
                                                   , "Error Message");
            }

        }
        #endregion

        #region "Outlook07 Active Object"

        private void AddToEmail(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.MailItem _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;

            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                bool IsExists = false;

                foreach (Office.CommandBar _ObjCmd in Inspector.CommandBars)
                {
                    if (_ObjCmd.Name == toolBarTagEmail)
                    {
                        IsExists = true;
                        _ObjCmd.Delete();
                    }
                }

                Office.CommandBar _ObjCommandBar = Inspector.CommandBars.Add(toolBarTagEmail, Office.MsoBarPosition.msoBarBottom, false, true);
                _objEmailToolBarButton1 = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);
                _objEmailToolBarButton2 = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);

                if (!IsExists)
                {
                    _objEmailToolBarButton1.Caption = "My Email ToolBar Button1";
                    _objEmailToolBarButton1.Style = Office.MsoButtonStyle.msoButtonIconAndCaptionBelow;
                    _objEmailToolBarButton1.FaceId = 500;
                    _objEmailToolBarButton1.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objEmailToolBarButton_Click);

                    _objEmailToolBarButton2.Caption = "My Email ToolBar Button2";
                    _objEmailToolBarButton2.Style = Office.MsoButtonStyle.msoButtonIconAndCaptionBelow;
                    _objEmailToolBarButton2.FaceId = 65;
                    _objEmailToolBarButton2.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objEmailToolBarButton_Click);

                    _ObjCommandBar.Visible = true;
                }
            }
        }

        private void AddToTask(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.TaskItem _ObjTaskItem = (Outlook.TaskItem)Inspector.CurrentItem;

            if (Inspector.CurrentItem is Outlook.TaskItem)
            {
                _ObjTaskItem = (Outlook.TaskItem)Inspector.CurrentItem;
                bool IsExists = false;

                foreach (Office.CommandBar _ObjCmd in Inspector.CommandBars)
                {
                    if (_ObjCmd.Name == toolBarTagTask)
                    {
                        IsExists = true;
                        _ObjCmd.Delete();
                    }
                }

                Office.CommandBar _ObjCommandBar = Inspector.CommandBars.Add(toolBarTagTask, Office.MsoBarPosition.msoBarBottom, false, true);
                _objTaskToolBarButton = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);

                if (!IsExists)
                {
                    _objTaskToolBarButton.Caption = "My Task ToolBar Button";
                    _objTaskToolBarButton.Style = Office.MsoButtonStyle.msoButtonIconAndCaptionBelow;
                    _objTaskToolBarButton.FaceId = 500;
                    _objTaskToolBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objTaskToolBarButton_Click);
                    _ObjCommandBar.Visible = true;
                }
            }
        }

        private void AddToNotes(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.NoteItem _ObjNoteItem = (Outlook.NoteItem)Inspector.CurrentItem;

            if (Inspector.CurrentItem is Outlook.NoteItem)
            {
                _ObjNoteItem = (Outlook.NoteItem)Inspector.CurrentItem;
                bool IsExists = false;

                foreach (Office.CommandBar _ObjCmd in Inspector.CommandBars)
                {
                    if (_ObjCmd.Name == toolBarTagNote)
                    {
                        IsExists = true;
                        _ObjCmd.Delete();
                    }
                }

                Office.CommandBar _ObjCommandBar = Inspector.CommandBars.Add(toolBarTagNote, Office.MsoBarPosition.msoBarBottom, false, true);
                _objNoteToolBarButton = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);

                if (!IsExists)
                {
                    _objNoteToolBarButton.Caption = "My Notes";
                    _objNoteToolBarButton.Style = Office.MsoButtonStyle.msoButtonIconAndCaptionBelow;
                    _objNoteToolBarButton.FaceId = 500;
                    _objNoteToolBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objNoteToolBarButton_Click);
                    _ObjCommandBar.Visible = true;
                }
            }
        }

        #endregion

        #region "Event Handler"

        #region "Menu Button"

        private void _objButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("My Menu....");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        #endregion

        #region "ToolBar Button"

        private void _objToolBarButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("My ToolBar...");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        private void _objEmailToolBarButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("My Email ToolBar ...");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        private void _objTaskToolBarButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("My Task ToolBar ...");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        private void _objNoteToolBarButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("My Note ToolBar ...");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        #endregion

        #region "Remove Existing"

        private void ErsMyMenuBar()
        {
            // If the menu already exists, remove it.
            try
            {
                Office.CommandBarPopup _objIsMenueExist = (Office.CommandBarPopup)
                    this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.
                    FindControl(Office.MsoControlType.msoControlPopup
                              , missing
                              , menuTag
                              , true
                              , true);

                if (_objIsMenueExist != null)
                {
                    _objIsMenueExist.Delete(true);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString()
                                                   , "Error Message");
            }
        }

        #endregion

        #endregion

        private void GetMessageID(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            string strMsgID = string.Empty;

            Outlook.MailItem _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;

            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                strMsgID = _ObjMailItem.EntryID;

                foreach (Outlook.Attachment _attachment in _ObjMailItem.Attachments)
                {
                    _attachment.SaveAsFile(@"c:/TemP/"
                                             + strMsgID
                                             + "-"
                                             + _attachment.FileName);
                }



            }

            System.Windows.Forms.MessageBox.Show("ID:" + strMsgID, "Outlook Entry ID");
            Id = strMsgID;
        }

        void WriteToLog(string msg)
        {
            EventLog
                tmpEventLog = new EventLog();

            tmpEventLog.Source = "TestOutlookAddIn2";
            tmpEventLog.WriteEntry(msg, EventLogEntryType.Information);
        }
    }
}
