namespace AsynchronousClientSocketIII
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
			this.tabControlMainForm = new System.Windows.Forms.TabControl();
			this.tabPageServer = new System.Windows.Forms.TabPage();
			this.listBoxClients = new System.Windows.Forms.ListBox();
			this.richTextBoxServer = new System.Windows.Forms.RichTextBox();
			this.ButtonSendServer = new System.Windows.Forms.Button();
			this.ButtonReceiveServer = new System.Windows.Forms.Button();
			this.checkBoxServerSocketBlocked = new System.Windows.Forms.CheckBox();
			this.ServerBindButton = new System.Windows.Forms.Button();
			this.tabPageClient1 = new System.Windows.Forms.TabPage();
			this.richTextBoxClient1 = new System.Windows.Forms.RichTextBox();
			this.ButtonSendClient1 = new System.Windows.Forms.Button();
			this.ButtonReceiveClient1 = new System.Windows.Forms.Button();
			this.checkBoxClientSocket1Blocked = new System.Windows.Forms.CheckBox();
			this.ButtonConnectClient1 = new System.Windows.Forms.Button();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.ListBoxLog = new System.Windows.Forms.ListBox();
			this.tabControlMainForm.SuspendLayout();
			this.tabPageServer.SuspendLayout();
			this.tabPageClient1.SuspendLayout();
			this.tabPageLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlMainForm
			// 
			this.tabControlMainForm.Controls.Add(this.tabPageServer);
			this.tabControlMainForm.Controls.Add(this.tabPageClient1);
			this.tabControlMainForm.Controls.Add(this.tabPageLog);
			this.tabControlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMainForm.Location = new System.Drawing.Point(0, 0);
			this.tabControlMainForm.Name = "tabControlMainForm";
			this.tabControlMainForm.SelectedIndex = 0;
			this.tabControlMainForm.Size = new System.Drawing.Size(632, 453);
			this.tabControlMainForm.TabIndex = 0;
			// 
			// tabPageServer
			// 
			this.tabPageServer.Controls.Add(this.listBoxClients);
			this.tabPageServer.Controls.Add(this.richTextBoxServer);
			this.tabPageServer.Controls.Add(this.ButtonSendServer);
			this.tabPageServer.Controls.Add(this.ButtonReceiveServer);
			this.tabPageServer.Controls.Add(this.checkBoxServerSocketBlocked);
			this.tabPageServer.Controls.Add(this.ServerBindButton);
			this.tabPageServer.Location = new System.Drawing.Point(4, 22);
			this.tabPageServer.Name = "tabPageServer";
			this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageServer.Size = new System.Drawing.Size(624, 427);
			this.tabPageServer.TabIndex = 0;
			this.tabPageServer.Text = "Server";
			this.tabPageServer.UseVisualStyleBackColor = true;
			// 
			// listBoxClients
			// 
			this.listBoxClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxClients.FormattingEnabled = true;
			this.listBoxClients.Location = new System.Drawing.Point(158, 6);
			this.listBoxClients.Name = "listBoxClients";
			this.listBoxClients.Size = new System.Drawing.Size(458, 82);
			this.listBoxClients.TabIndex = 8;
			// 
			// richTextBoxServer
			// 
			this.richTextBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxServer.Location = new System.Drawing.Point(8, 93);
			this.richTextBoxServer.Name = "richTextBoxServer";
			this.richTextBoxServer.Size = new System.Drawing.Size(608, 326);
			this.richTextBoxServer.TabIndex = 7;
			this.richTextBoxServer.Text = "";
			// 
			// ButtonSendServer
			// 
			this.ButtonSendServer.Enabled = false;
			this.ButtonSendServer.Location = new System.Drawing.Point(8, 64);
			this.ButtonSendServer.Name = "ButtonSendServer";
			this.ButtonSendServer.Size = new System.Drawing.Size(75, 23);
			this.ButtonSendServer.TabIndex = 6;
			this.ButtonSendServer.Text = "Send";
			this.ButtonSendServer.UseVisualStyleBackColor = true;
			this.ButtonSendServer.Click += new System.EventHandler(this.ButtonSend_Click);
			// 
			// ButtonReceiveServer
			// 
			this.ButtonReceiveServer.Enabled = false;
			this.ButtonReceiveServer.Location = new System.Drawing.Point(8, 35);
			this.ButtonReceiveServer.Name = "ButtonReceiveServer";
			this.ButtonReceiveServer.Size = new System.Drawing.Size(75, 23);
			this.ButtonReceiveServer.TabIndex = 5;
			this.ButtonReceiveServer.Text = "Receive";
			this.ButtonReceiveServer.UseVisualStyleBackColor = true;
			this.ButtonReceiveServer.Click += new System.EventHandler(this.ButtonReceive_Click);
			// 
			// checkBoxServerSocketBlocked
			// 
			this.checkBoxServerSocketBlocked.AutoSize = true;
			this.checkBoxServerSocketBlocked.Checked = true;
			this.checkBoxServerSocketBlocked.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxServerSocketBlocked.Location = new System.Drawing.Point(87, 10);
			this.checkBoxServerSocketBlocked.Name = "checkBoxServerSocketBlocked";
			this.checkBoxServerSocketBlocked.Size = new System.Drawing.Size(65, 17);
			this.checkBoxServerSocketBlocked.TabIndex = 4;
			this.checkBoxServerSocketBlocked.Text = "Blocked";
			this.checkBoxServerSocketBlocked.UseVisualStyleBackColor = true;
			// 
			// ServerBindButton
			// 
			this.ServerBindButton.Location = new System.Drawing.Point(6, 6);
			this.ServerBindButton.Name = "ServerBindButton";
			this.ServerBindButton.Size = new System.Drawing.Size(75, 23);
			this.ServerBindButton.TabIndex = 3;
			this.ServerBindButton.Text = "Bind";
			this.ServerBindButton.UseVisualStyleBackColor = true;
			this.ServerBindButton.Click += new System.EventHandler(this.ServerBindButton_Click);
			// 
			// tabPageClient1
			// 
			this.tabPageClient1.Controls.Add(this.richTextBoxClient1);
			this.tabPageClient1.Controls.Add(this.ButtonSendClient1);
			this.tabPageClient1.Controls.Add(this.ButtonReceiveClient1);
			this.tabPageClient1.Controls.Add(this.checkBoxClientSocket1Blocked);
			this.tabPageClient1.Controls.Add(this.ButtonConnectClient1);
			this.tabPageClient1.Location = new System.Drawing.Point(4, 22);
			this.tabPageClient1.Name = "tabPageClient1";
			this.tabPageClient1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageClient1.Size = new System.Drawing.Size(624, 427);
			this.tabPageClient1.TabIndex = 1;
			this.tabPageClient1.Text = "Client #1";
			this.tabPageClient1.UseVisualStyleBackColor = true;
			// 
			// richTextBoxClient1
			// 
			this.richTextBoxClient1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxClient1.Location = new System.Drawing.Point(8, 93);
			this.richTextBoxClient1.Name = "richTextBoxClient1";
			this.richTextBoxClient1.Size = new System.Drawing.Size(608, 326);
			this.richTextBoxClient1.TabIndex = 8;
			this.richTextBoxClient1.Text = "";
			// 
			// ButtonSendClient1
			// 
			this.ButtonSendClient1.Enabled = false;
			this.ButtonSendClient1.Location = new System.Drawing.Point(8, 64);
			this.ButtonSendClient1.Name = "ButtonSendClient1";
			this.ButtonSendClient1.Size = new System.Drawing.Size(75, 23);
			this.ButtonSendClient1.TabIndex = 7;
			this.ButtonSendClient1.Text = "Send";
			this.ButtonSendClient1.UseVisualStyleBackColor = true;
			this.ButtonSendClient1.Click += new System.EventHandler(this.ButtonSend_Click);
			// 
			// ButtonReceiveClient1
			// 
			this.ButtonReceiveClient1.Enabled = false;
			this.ButtonReceiveClient1.Location = new System.Drawing.Point(8, 35);
			this.ButtonReceiveClient1.Name = "ButtonReceiveClient1";
			this.ButtonReceiveClient1.Size = new System.Drawing.Size(75, 23);
			this.ButtonReceiveClient1.TabIndex = 6;
			this.ButtonReceiveClient1.Text = "Receive";
			this.ButtonReceiveClient1.UseVisualStyleBackColor = true;
			this.ButtonReceiveClient1.Click += new System.EventHandler(this.ButtonReceive_Click);
			// 
			// checkBoxClientSocket1Blocked
			// 
			this.checkBoxClientSocket1Blocked.AutoSize = true;
			this.checkBoxClientSocket1Blocked.Checked = true;
			this.checkBoxClientSocket1Blocked.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxClientSocket1Blocked.Location = new System.Drawing.Point(87, 10);
			this.checkBoxClientSocket1Blocked.Name = "checkBoxClientSocket1Blocked";
			this.checkBoxClientSocket1Blocked.Size = new System.Drawing.Size(65, 17);
			this.checkBoxClientSocket1Blocked.TabIndex = 5;
			this.checkBoxClientSocket1Blocked.Text = "Blocked";
			this.checkBoxClientSocket1Blocked.UseVisualStyleBackColor = true;
			// 
			// ButtonConnectClient1
			// 
			this.ButtonConnectClient1.Location = new System.Drawing.Point(6, 6);
			this.ButtonConnectClient1.Name = "ButtonConnectClient1";
			this.ButtonConnectClient1.Size = new System.Drawing.Size(75, 23);
			this.ButtonConnectClient1.TabIndex = 4;
			this.ButtonConnectClient1.Text = "Connect";
			this.ButtonConnectClient1.UseVisualStyleBackColor = true;
			this.ButtonConnectClient1.Click += new System.EventHandler(this.ClientConnectButton_Click);
			// 
			// tabPageLog
			// 
			this.tabPageLog.Controls.Add(this.ListBoxLog);
			this.tabPageLog.Location = new System.Drawing.Point(4, 22);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLog.Size = new System.Drawing.Size(624, 427);
			this.tabPageLog.TabIndex = 2;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// ListBoxLog
			// 
			this.ListBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBoxLog.FormattingEnabled = true;
			this.ListBoxLog.Location = new System.Drawing.Point(3, 3);
			this.ListBoxLog.Name = "ListBoxLog";
			this.ListBoxLog.Size = new System.Drawing.Size(618, 421);
			this.ListBoxLog.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.tabControlMainForm);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.tabControlMainForm.ResumeLayout(false);
			this.tabPageServer.ResumeLayout(false);
			this.tabPageServer.PerformLayout();
			this.tabPageClient1.ResumeLayout(false);
			this.tabPageClient1.PerformLayout();
			this.tabPageLog.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.TabControl tabControlMainForm;
		private System.Windows.Forms.TabPage tabPageServer;
		private System.Windows.Forms.Button ServerBindButton;
		private System.Windows.Forms.TabPage tabPageClient1;
		private System.Windows.Forms.Button ButtonConnectClient1;
		private System.Windows.Forms.TabPage tabPageLog;
		private System.Windows.Forms.ListBox ListBoxLog;
		private System.Windows.Forms.CheckBox checkBoxServerSocketBlocked;
		private System.Windows.Forms.CheckBox checkBoxClientSocket1Blocked;
		private System.Windows.Forms.Button ButtonReceiveClient1;
		private System.Windows.Forms.Button ButtonSendClient1;
		private System.Windows.Forms.RichTextBox richTextBoxClient1;
		private System.Windows.Forms.RichTextBox richTextBoxServer;
		private System.Windows.Forms.Button ButtonSendServer;
		private System.Windows.Forms.Button ButtonReceiveServer;
		private System.Windows.Forms.ListBox listBoxClients;

	}
}

