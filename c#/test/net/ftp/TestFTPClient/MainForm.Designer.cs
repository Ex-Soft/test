namespace TestFTPClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpUpload = new System.Windows.Forms.TabPage();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tpDownload = new System.Windows.Forms.TabPage();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tbDownloadFileName = new System.Windows.Forms.TextBox();
            this.lblDownloadFileName = new System.Windows.Forms.Label();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tpRename = new System.Windows.Forms.TabPage();
            this.tbDestDir = new System.Windows.Forms.TextBox();
            this.lbDestDir = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.tbSrcDir = new System.Windows.Forms.TextBox();
            this.lbSrcDir = new System.Windows.Forms.Label();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnSetCurrentDirectory = new System.Windows.Forms.Button();
            this.lblDirectories = new System.Windows.Forms.Label();
            this.lbDirectories = new System.Windows.Forms.ListBox();
            this.btnGetDirectories = new System.Windows.Forms.Button();
            this.btnGetCurrentDirectory = new System.Windows.Forms.Button();
            this.tbCurrentDirectory = new System.Windows.Forms.TextBox();
            this.lblRemoteDirectory = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.tpUpload.SuspendLayout();
            this.tpDownload.SuspendLayout();
            this.tpLog.SuspendLayout();
            this.tpRename.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpUpload);
            this.tabControl.Controls.Add(this.tpDownload);
            this.tabControl.Controls.Add(this.tpRename);
            this.tabControl.Controls.Add(this.tpLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 303);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(671, 197);
            this.tabControl.TabIndex = 0;
            // 
            // tpUpload
            // 
            this.tpUpload.Controls.Add(this.btnUpload);
            this.tpUpload.Location = new System.Drawing.Point(4, 22);
            this.tpUpload.Name = "tpUpload";
            this.tpUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tpUpload.Size = new System.Drawing.Size(663, 171);
            this.tpUpload.TabIndex = 1;
            this.tpUpload.Text = "Upload";
            this.tpUpload.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(11, 21);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUploadClick);
            // 
            // tpDownload
            // 
            this.tpDownload.Controls.Add(this.btnDownload);
            this.tpDownload.Controls.Add(this.tbDownloadFileName);
            this.tpDownload.Controls.Add(this.lblDownloadFileName);
            this.tpDownload.Location = new System.Drawing.Point(4, 22);
            this.tpDownload.Name = "tpDownload";
            this.tpDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tpDownload.Size = new System.Drawing.Size(663, 171);
            this.tpDownload.TabIndex = 2;
            this.tpDownload.Text = "Download";
            this.tpDownload.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(203, 19);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.BtnDownloadClick);
            // 
            // tbDownloadFileName
            // 
            this.tbDownloadFileName.Location = new System.Drawing.Point(77, 20);
            this.tbDownloadFileName.Name = "tbDownloadFileName";
            this.tbDownloadFileName.Size = new System.Drawing.Size(100, 20);
            this.tbDownloadFileName.TabIndex = 1;
            // 
            // lblDownloadFileName
            // 
            this.lblDownloadFileName.AutoSize = true;
            this.lblDownloadFileName.Location = new System.Drawing.Point(16, 24);
            this.lblDownloadFileName.Name = "lblDownloadFileName";
            this.lblDownloadFileName.Size = new System.Drawing.Size(51, 13);
            this.lblDownloadFileName.TabIndex = 0;
            this.lblDownloadFileName.Text = "FileName";
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.lbLog);
            this.tpLog.Location = new System.Drawing.Point(4, 22);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpLog.Size = new System.Drawing.Size(663, 171);
            this.tpLog.TabIndex = 3;
            this.tpLog.Text = "Log";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(3, 3);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(657, 165);
            this.lbLog.TabIndex = 0;
            // 
            // tpRename
            // 
            this.tpRename.Controls.Add(this.tbDestDir);
            this.tpRename.Controls.Add(this.lbDestDir);
            this.tpRename.Controls.Add(this.btnRename);
            this.tpRename.Controls.Add(this.tbSrcDir);
            this.tpRename.Controls.Add(this.lbSrcDir);
            this.tpRename.Location = new System.Drawing.Point(4, 22);
            this.tpRename.Name = "tpRename";
            this.tpRename.Padding = new System.Windows.Forms.Padding(3);
            this.tpRename.Size = new System.Drawing.Size(663, 171);
            this.tpRename.TabIndex = 4;
            this.tpRename.Text = "Rename";
            this.tpRename.UseVisualStyleBackColor = true;
            // 
            // tbDestDir
            // 
            this.tbDestDir.Location = new System.Drawing.Point(128, 45);
            this.tbDestDir.Name = "tbDestDir";
            this.tbDestDir.Size = new System.Drawing.Size(100, 20);
            this.tbDestDir.TabIndex = 7;
            this.tbDestDir.Text = "download";
            // 
            // lbDestDir
            // 
            this.lbDestDir.AutoSize = true;
            this.lbDestDir.Location = new System.Drawing.Point(8, 48);
            this.lbDestDir.Name = "lbDestDir";
            this.lbDestDir.Size = new System.Drawing.Size(105, 13);
            this.lbDestDir.TabIndex = 6;
            this.lbDestDir.Text = "Destination Directory";
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(253, 38);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.BtnRenameClick);
            // 
            // tbSrcDir
            // 
            this.tbSrcDir.Location = new System.Drawing.Point(128, 20);
            this.tbSrcDir.Name = "tbSrcDir";
            this.tbSrcDir.Size = new System.Drawing.Size(100, 20);
            this.tbSrcDir.TabIndex = 4;
            this.tbSrcDir.Text = "upload";
            // 
            // lbSrcDir
            // 
            this.lbSrcDir.AutoSize = true;
            this.lbSrcDir.Location = new System.Drawing.Point(8, 23);
            this.lbSrcDir.Name = "lbSrcDir";
            this.lbSrcDir.Size = new System.Drawing.Size(86, 13);
            this.lbSrcDir.TabIndex = 3;
            this.lbSrcDir.Text = "Source Directory";
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Enabled = false;
            this.btnGetFiles.Location = new System.Drawing.Point(338, 247);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(120, 23);
            this.btnGetFiles.TabIndex = 17;
            this.btnGetFiles.Text = "GetFiles";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.BtnGetFilesClick);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(468, 105);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 16;
            this.lblFiles.Text = "Files";
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(516, 64);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(135, 95);
            this.lbFiles.TabIndex = 15;
            // 
            // btnSetCurrentDirectory
            // 
            this.btnSetCurrentDirectory.Enabled = false;
            this.btnSetCurrentDirectory.Location = new System.Drawing.Point(338, 218);
            this.btnSetCurrentDirectory.Name = "btnSetCurrentDirectory";
            this.btnSetCurrentDirectory.Size = new System.Drawing.Size(120, 23);
            this.btnSetCurrentDirectory.TabIndex = 14;
            this.btnSetCurrentDirectory.Text = "SetCurrentDirectory";
            this.btnSetCurrentDirectory.UseVisualStyleBackColor = true;
            this.btnSetCurrentDirectory.Click += new System.EventHandler(this.BtnSetCurrentDirectoryClick);
            // 
            // lblDirectories
            // 
            this.lblDirectories.AutoSize = true;
            this.lblDirectories.Location = new System.Drawing.Point(236, 105);
            this.lblDirectories.Name = "lblDirectories";
            this.lblDirectories.Size = new System.Drawing.Size(57, 13);
            this.lblDirectories.TabIndex = 13;
            this.lblDirectories.Text = "Directories";
            // 
            // lbDirectories
            // 
            this.lbDirectories.FormattingEnabled = true;
            this.lbDirectories.Location = new System.Drawing.Point(313, 64);
            this.lbDirectories.Name = "lbDirectories";
            this.lbDirectories.Size = new System.Drawing.Size(135, 95);
            this.lbDirectories.TabIndex = 12;
            // 
            // btnGetDirectories
            // 
            this.btnGetDirectories.Enabled = false;
            this.btnGetDirectories.Location = new System.Drawing.Point(212, 247);
            this.btnGetDirectories.Name = "btnGetDirectories";
            this.btnGetDirectories.Size = new System.Drawing.Size(120, 23);
            this.btnGetDirectories.TabIndex = 11;
            this.btnGetDirectories.Text = "GetDirectories";
            this.btnGetDirectories.UseVisualStyleBackColor = true;
            this.btnGetDirectories.Click += new System.EventHandler(this.BtnGetDirectoriesClick);
            // 
            // btnGetCurrentDirectory
            // 
            this.btnGetCurrentDirectory.Enabled = false;
            this.btnGetCurrentDirectory.Location = new System.Drawing.Point(212, 218);
            this.btnGetCurrentDirectory.Name = "btnGetCurrentDirectory";
            this.btnGetCurrentDirectory.Size = new System.Drawing.Size(120, 23);
            this.btnGetCurrentDirectory.TabIndex = 10;
            this.btnGetCurrentDirectory.Text = "GetCurrentDirectory";
            this.btnGetCurrentDirectory.UseVisualStyleBackColor = true;
            this.btnGetCurrentDirectory.Click += new System.EventHandler(this.BtnGetCurrentDirectoryClick);
            // 
            // tbCurrentDirectory
            // 
            this.tbCurrentDirectory.Location = new System.Drawing.Point(81, 101);
            this.tbCurrentDirectory.Name = "tbCurrentDirectory";
            this.tbCurrentDirectory.Size = new System.Drawing.Size(135, 20);
            this.tbCurrentDirectory.TabIndex = 9;
            // 
            // lblRemoteDirectory
            // 
            this.lblRemoteDirectory.AutoSize = true;
            this.lblRemoteDirectory.Location = new System.Drawing.Point(12, 105);
            this.lblRemoteDirectory.Name = "lblRemoteDirectory";
            this.lblRemoteDirectory.Size = new System.Drawing.Size(49, 13);
            this.lblRemoteDirectory.TabIndex = 8;
            this.lblRemoteDirectory.Text = "Directory";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(338, 189);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnectClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(257, 189);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(516, 25);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(135, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.Text = "i.nozhenko@systtech.ru";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(294, 25);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(135, 20);
            this.tbUserName.TabIndex = 4;
            this.tbUserName.Text = "anonymous";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(67, 25);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(135, 20);
            this.tbServer.TabIndex = 3;
            this.tbServer.Text = "localhost";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(446, 29);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(219, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User name";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 29);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server";
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.btnGetFiles);
            this.gbServer.Controls.Add(this.lblServer);
            this.gbServer.Controls.Add(this.btnSetCurrentDirectory);
            this.gbServer.Controls.Add(this.lbFiles);
            this.gbServer.Controls.Add(this.btnGetDirectories);
            this.gbServer.Controls.Add(this.lblFiles);
            this.gbServer.Controls.Add(this.btnGetCurrentDirectory);
            this.gbServer.Controls.Add(this.btnDisconnect);
            this.gbServer.Controls.Add(this.tbServer);
            this.gbServer.Controls.Add(this.btnConnect);
            this.gbServer.Controls.Add(this.lblUserName);
            this.gbServer.Controls.Add(this.tbUserName);
            this.gbServer.Controls.Add(this.lbDirectories);
            this.gbServer.Controls.Add(this.lblDirectories);
            this.gbServer.Controls.Add(this.lblPassword);
            this.gbServer.Controls.Add(this.tbPassword);
            this.gbServer.Controls.Add(this.lblRemoteDirectory);
            this.gbServer.Controls.Add(this.tbCurrentDirectory);
            this.gbServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbServer.Location = new System.Drawing.Point(0, 0);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(671, 281);
            this.gbServer.TabIndex = 1;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Server";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 500);
            this.Controls.Add(this.gbServer);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test FTPLib";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.tabControl.ResumeLayout(false);
            this.tpUpload.ResumeLayout(false);
            this.tpDownload.ResumeLayout(false);
            this.tpDownload.PerformLayout();
            this.tpLog.ResumeLayout(false);
            this.tpRename.ResumeLayout(false);
            this.tpRename.PerformLayout();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TabPage tpUpload;
        private System.Windows.Forms.TabPage tpDownload;
        private System.Windows.Forms.TabPage tpLog;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGetCurrentDirectory;
        private System.Windows.Forms.TextBox tbCurrentDirectory;
        private System.Windows.Forms.Label lblRemoteDirectory;
        private System.Windows.Forms.Button btnGetDirectories;
        private System.Windows.Forms.Label lblDirectories;
        private System.Windows.Forms.ListBox lbDirectories;
        private System.Windows.Forms.Button btnSetCurrentDirectory;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox tbDownloadFileName;
        private System.Windows.Forms.Label lblDownloadFileName;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TabPage tpRename;
        private System.Windows.Forms.TextBox tbDestDir;
        private System.Windows.Forms.Label lbDestDir;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox tbSrcDir;
        private System.Windows.Forms.Label lbSrcDir;
    }
}

