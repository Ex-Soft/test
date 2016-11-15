namespace TestOutlookAddInMailAndFolders
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class FormRegionMailAndFolders : Microsoft.Office.Tools.Outlook.FormRegionControl
    {
        public FormRegionMailAndFolders(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            : base(formRegion)
        {
            this.InitializeComponent();
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetCurrentFolder = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonGetFolders = new System.Windows.Forms.Button();
            this.buttonSetFolder = new System.Windows.Forms.Button();
            this.buttonMoveMailItem = new System.Windows.Forms.Button();
            this.buttonCreateFolder = new System.Windows.Forms.Button();
            this.buttonCreateRule = new System.Windows.Forms.Button();
            this.buttonGetMailItem = new System.Windows.Forms.Button();
            this.buttonChangeMailItem = new System.Windows.Forms.Button();
            this.buttonAddUserProperty = new System.Windows.Forms.Button();
            this.buttonFindMailItem = new System.Windows.Forms.Button();
            this.buttonAppConfig = new System.Windows.Forms.Button();
            this.buttonGetUserProperty = new System.Windows.Forms.Button();
            this.buttonGetHeader = new System.Windows.Forms.Button();
            this.buttonSetHeader = new System.Windows.Forms.Button();
            this.buttonAddAttach = new System.Windows.Forms.Button();
            this.buttonCloseExplorer = new System.Windows.Forms.Button();
            this.buttonCloseInspector = new System.Windows.Forms.Button();
            this.buttonSetMessageClass = new System.Windows.Forms.Button();
            this.buttonGetMessageClass = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // buttonGetCurrentFolder
            // 
            this.buttonGetCurrentFolder.Location = new System.Drawing.Point(3, 9);
            this.buttonGetCurrentFolder.Name = "buttonGetCurrentFolder";
            this.buttonGetCurrentFolder.Size = new System.Drawing.Size(113, 23);
            this.buttonGetCurrentFolder.TabIndex = 0;
            this.buttonGetCurrentFolder.Text = "GetCurrentFolder";
            this.buttonGetCurrentFolder.UseVisualStyleBackColor = true;
            this.buttonGetCurrentFolder.Click += new System.EventHandler(this.buttonGetCurrentFolder_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(3, 96);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(1112, 20);
            this.textBoxLog.TabIndex = 20;
            // 
            // buttonGetFolders
            // 
            this.buttonGetFolders.Location = new System.Drawing.Point(122, 9);
            this.buttonGetFolders.Name = "buttonGetFolders";
            this.buttonGetFolders.Size = new System.Drawing.Size(75, 23);
            this.buttonGetFolders.TabIndex = 1;
            this.buttonGetFolders.Text = "GetFolders";
            this.buttonGetFolders.UseVisualStyleBackColor = true;
            this.buttonGetFolders.Click += new System.EventHandler(this.buttonGetFolders_Click);
            // 
            // buttonSetFolder
            // 
            this.buttonSetFolder.Location = new System.Drawing.Point(203, 9);
            this.buttonSetFolder.Name = "buttonSetFolder";
            this.buttonSetFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSetFolder.TabIndex = 2;
            this.buttonSetFolder.Text = "SetFolder";
            this.buttonSetFolder.UseVisualStyleBackColor = true;
            this.buttonSetFolder.Click += new System.EventHandler(this.buttonSetFolder_Click);
            // 
            // buttonMoveMailItem
            // 
            this.buttonMoveMailItem.Location = new System.Drawing.Point(84, 67);
            this.buttonMoveMailItem.Name = "buttonMoveMailItem";
            this.buttonMoveMailItem.Size = new System.Drawing.Size(96, 23);
            this.buttonMoveMailItem.TabIndex = 10;
            this.buttonMoveMailItem.Text = "MoveMailItem";
            this.buttonMoveMailItem.UseVisualStyleBackColor = true;
            this.buttonMoveMailItem.Click += new System.EventHandler(this.buttonMoveMailItem_Click);
            // 
            // buttonCreateFolder
            // 
            this.buttonCreateFolder.Location = new System.Drawing.Point(284, 9);
            this.buttonCreateFolder.Name = "buttonCreateFolder";
            this.buttonCreateFolder.Size = new System.Drawing.Size(90, 23);
            this.buttonCreateFolder.TabIndex = 3;
            this.buttonCreateFolder.Text = "CreateFolder";
            this.buttonCreateFolder.UseVisualStyleBackColor = true;
            this.buttonCreateFolder.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // buttonCreateRule
            // 
            this.buttonCreateRule.Location = new System.Drawing.Point(3, 38);
            this.buttonCreateRule.Name = "buttonCreateRule";
            this.buttonCreateRule.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateRule.TabIndex = 5;
            this.buttonCreateRule.Text = "CreateRule";
            this.buttonCreateRule.UseVisualStyleBackColor = true;
            this.buttonCreateRule.Click += new System.EventHandler(this.buttonCreateRule_Click);
            // 
            // buttonGetMailItem
            // 
            this.buttonGetMailItem.Location = new System.Drawing.Point(3, 67);
            this.buttonGetMailItem.Name = "buttonGetMailItem";
            this.buttonGetMailItem.Size = new System.Drawing.Size(75, 23);
            this.buttonGetMailItem.TabIndex = 9;
            this.buttonGetMailItem.Text = "GetMailItem";
            this.buttonGetMailItem.UseVisualStyleBackColor = true;
            this.buttonGetMailItem.Click += new System.EventHandler(this.buttonGetMailItem_Click);
            // 
            // buttonChangeMailItem
            // 
            this.buttonChangeMailItem.Location = new System.Drawing.Point(186, 67);
            this.buttonChangeMailItem.Name = "buttonChangeMailItem";
            this.buttonChangeMailItem.Size = new System.Drawing.Size(98, 23);
            this.buttonChangeMailItem.TabIndex = 11;
            this.buttonChangeMailItem.Text = "ChangeMailItem";
            this.buttonChangeMailItem.UseVisualStyleBackColor = true;
            this.buttonChangeMailItem.Click += new System.EventHandler(this.buttonChangeMailItem_Click);
            // 
            // buttonAddUserProperty
            // 
            this.buttonAddUserProperty.Location = new System.Drawing.Point(290, 67);
            this.buttonAddUserProperty.Name = "buttonAddUserProperty";
            this.buttonAddUserProperty.Size = new System.Drawing.Size(106, 23);
            this.buttonAddUserProperty.TabIndex = 12;
            this.buttonAddUserProperty.Text = "AddUserProperty";
            this.buttonAddUserProperty.UseVisualStyleBackColor = true;
            this.buttonAddUserProperty.Click += new System.EventHandler(this.buttonAddUserProperty_Click);
            // 
            // buttonFindMailItem
            // 
            this.buttonFindMailItem.Location = new System.Drawing.Point(380, 9);
            this.buttonFindMailItem.Name = "buttonFindMailItem";
            this.buttonFindMailItem.Size = new System.Drawing.Size(94, 23);
            this.buttonFindMailItem.TabIndex = 4;
            this.buttonFindMailItem.Text = "FindMailItem";
            this.buttonFindMailItem.UseVisualStyleBackColor = true;
            this.buttonFindMailItem.Click += new System.EventHandler(this.buttonFindMailItem_Click);
            // 
            // buttonAppConfig
            // 
            this.buttonAppConfig.Location = new System.Drawing.Point(84, 38);
            this.buttonAppConfig.Name = "buttonAppConfig";
            this.buttonAppConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonAppConfig.TabIndex = 6;
            this.buttonAppConfig.Text = "AppConfig";
            this.buttonAppConfig.UseVisualStyleBackColor = true;
            this.buttonAppConfig.Click += new System.EventHandler(this.buttonAppConfig_Click);
            // 
            // buttonGetUserProperty
            // 
            this.buttonGetUserProperty.Location = new System.Drawing.Point(411, 67);
            this.buttonGetUserProperty.Name = "buttonGetUserProperty";
            this.buttonGetUserProperty.Size = new System.Drawing.Size(104, 23);
            this.buttonGetUserProperty.TabIndex = 13;
            this.buttonGetUserProperty.Text = "GetUserProperty";
            this.buttonGetUserProperty.UseVisualStyleBackColor = true;
            this.buttonGetUserProperty.Click += new System.EventHandler(this.buttonGetUserProperty_Click);
            // 
            // buttonGetHeader
            // 
            this.buttonGetHeader.Location = new System.Drawing.Point(832, 67);
            this.buttonGetHeader.Name = "buttonGetHeader";
            this.buttonGetHeader.Size = new System.Drawing.Size(75, 23);
            this.buttonGetHeader.TabIndex = 17;
            this.buttonGetHeader.Text = "GetHeader";
            this.buttonGetHeader.UseVisualStyleBackColor = true;
            this.buttonGetHeader.Click += new System.EventHandler(this.buttonGetHeader_Click);
            // 
            // buttonSetHeader
            // 
            this.buttonSetHeader.Location = new System.Drawing.Point(913, 67);
            this.buttonSetHeader.Name = "buttonSetHeader";
            this.buttonSetHeader.Size = new System.Drawing.Size(75, 23);
            this.buttonSetHeader.TabIndex = 18;
            this.buttonSetHeader.Text = "SetHeader";
            this.buttonSetHeader.UseVisualStyleBackColor = true;
            this.buttonSetHeader.Click += new System.EventHandler(this.buttonSetHeader_Click);
            // 
            // buttonAddAttach
            // 
            this.buttonAddAttach.Location = new System.Drawing.Point(521, 67);
            this.buttonAddAttach.Name = "buttonAddAttach";
            this.buttonAddAttach.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAttach.TabIndex = 14;
            this.buttonAddAttach.Text = "AddAttach";
            this.buttonAddAttach.UseVisualStyleBackColor = true;
            this.buttonAddAttach.Click += new System.EventHandler(this.buttonAddAttach_Click);
            // 
            // buttonCloseExplorer
            // 
            this.buttonCloseExplorer.Location = new System.Drawing.Point(165, 38);
            this.buttonCloseExplorer.Name = "buttonCloseExplorer";
            this.buttonCloseExplorer.Size = new System.Drawing.Size(148, 23);
            this.buttonCloseExplorer.TabIndex = 7;
            this.buttonCloseExplorer.Text = "CloseExplorer (Outlook)";
            this.buttonCloseExplorer.UseVisualStyleBackColor = true;
            this.buttonCloseExplorer.Click += new System.EventHandler(this.buttonCloseExplorer_Click);
            // 
            // buttonCloseInspector
            // 
            this.buttonCloseInspector.Location = new System.Drawing.Point(338, 38);
            this.buttonCloseInspector.Name = "buttonCloseInspector";
            this.buttonCloseInspector.Size = new System.Drawing.Size(93, 23);
            this.buttonCloseInspector.TabIndex = 8;
            this.buttonCloseInspector.Text = "CloseInspector";
            this.buttonCloseInspector.UseVisualStyleBackColor = true;
            this.buttonCloseInspector.Click += new System.EventHandler(this.buttonCloseInspector_Click);
            // 
            // buttonSetMessageClass
            // 
            this.buttonSetMessageClass.Location = new System.Drawing.Point(602, 67);
            this.buttonSetMessageClass.Name = "buttonSetMessageClass";
            this.buttonSetMessageClass.Size = new System.Drawing.Size(110, 23);
            this.buttonSetMessageClass.TabIndex = 15;
            this.buttonSetMessageClass.Text = "SetMessageClass";
            this.buttonSetMessageClass.UseVisualStyleBackColor = true;
            this.buttonSetMessageClass.Click += new System.EventHandler(this.buttonSetMessageClass_Click);
            // 
            // buttonGetMessageClass
            // 
            this.buttonGetMessageClass.Location = new System.Drawing.Point(718, 67);
            this.buttonGetMessageClass.Name = "buttonGetMessageClass";
            this.buttonGetMessageClass.Size = new System.Drawing.Size(108, 23);
            this.buttonGetMessageClass.TabIndex = 16;
            this.buttonGetMessageClass.Text = "GetMessageClass";
            this.buttonGetMessageClass.UseVisualStyleBackColor = true;
            this.buttonGetMessageClass.Click += new System.EventHandler(this.buttonGetMessageClass_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(994, 67);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 19;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(3, 122);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1112, 68);
            this.webBrowser1.TabIndex = 21;
            // 
            // FormRegionMailAndFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonGetMessageClass);
            this.Controls.Add(this.buttonSetMessageClass);
            this.Controls.Add(this.buttonCloseInspector);
            this.Controls.Add(this.buttonCloseExplorer);
            this.Controls.Add(this.buttonAddAttach);
            this.Controls.Add(this.buttonSetHeader);
            this.Controls.Add(this.buttonGetHeader);
            this.Controls.Add(this.buttonGetUserProperty);
            this.Controls.Add(this.buttonAppConfig);
            this.Controls.Add(this.buttonFindMailItem);
            this.Controls.Add(this.buttonAddUserProperty);
            this.Controls.Add(this.buttonChangeMailItem);
            this.Controls.Add(this.buttonGetMailItem);
            this.Controls.Add(this.buttonCreateRule);
            this.Controls.Add(this.buttonCreateFolder);
            this.Controls.Add(this.buttonMoveMailItem);
            this.Controls.Add(this.buttonSetFolder);
            this.Controls.Add(this.buttonGetFolders);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonGetCurrentFolder);
            this.Name = "FormRegionMailAndFolders";
            this.Size = new System.Drawing.Size(1118, 201);
            this.FormRegionClosed += new System.EventHandler(this.FormRegionMailAndFolders_FormRegionClosed);
            this.FormRegionShowing += new System.EventHandler(this.FormRegionMailAndFolders_FormRegionShowing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Form Region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest)
        {
            manifest.FormRegionName = "FormRegionMailAndFolders";
            manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining;

        }

        #endregion

        private System.Windows.Forms.Button buttonGetCurrentFolder;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonGetFolders;
        private System.Windows.Forms.Button buttonSetFolder;
        private System.Windows.Forms.Button buttonMoveMailItem;
        private System.Windows.Forms.Button buttonCreateFolder;
        private System.Windows.Forms.Button buttonCreateRule;
        private System.Windows.Forms.Button buttonGetMailItem;
        private System.Windows.Forms.Button buttonChangeMailItem;
        private System.Windows.Forms.Button buttonAddUserProperty;
        private System.Windows.Forms.Button buttonFindMailItem;
        private System.Windows.Forms.Button buttonAppConfig;
        private System.Windows.Forms.Button buttonGetUserProperty;
        private System.Windows.Forms.Button buttonGetHeader;
        private System.Windows.Forms.Button buttonSetHeader;
        private System.Windows.Forms.Button buttonAddAttach;
        private System.Windows.Forms.Button buttonCloseExplorer;
        private System.Windows.Forms.Button buttonCloseInspector;
        private System.Windows.Forms.Button buttonSetMessageClass;
        private System.Windows.Forms.Button buttonGetMessageClass;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.WebBrowser webBrowser1;

        public partial class FormRegionMailAndFoldersFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
        {
            public event System.EventHandler<Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs> FormRegionInitializing;

            private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public FormRegionMailAndFoldersFactory()
            {
                this._Manifest = new Microsoft.Office.Tools.Outlook.FormRegionManifest();
                FormRegionMailAndFolders.InitializeManifest(this._Manifest);
                this.FormRegionInitializing += new System.EventHandler<Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs>(this.FormRegionMailAndFoldersFactory_FormRegionInitializing);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
            {
                get
                {
                    return this._Manifest;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            {
                FormRegionMailAndFolders form = new FormRegionMailAndFolders(formRegion);
                form.Factory = this;
                return form;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                throw new System.NotSupportedException();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                if (this.FormRegionInitializing != null)
                {
                    Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
                    this.FormRegionInitializing(this, cancelArgs);
                    return !cancelArgs.Cancel;
                }
                else
                {
                    return true;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            string Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            {
                get
                {
                    return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
                }
            }
        }
    }

    partial class WindowFormRegionCollection
    {
        internal FormRegionMailAndFolders FormRegionMailAndFolders
        {
            get
            {
                return this.FindFirst<FormRegionMailAndFolders>();
            }
        }
    }
}
