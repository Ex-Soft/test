namespace TestThreadsIV
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
			this.TextBoxNumberOfMainThreads = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ButtonDoIt = new System.Windows.Forms.Button();
			this.TabControlLog = new System.Windows.Forms.TabControl();
			this.TabPageMainThreadsLog = new System.Windows.Forms.TabPage();
			this.ListBoxMainThreadsLog = new System.Windows.Forms.ListBox();
			this.TabPageChildThreadsLog = new System.Windows.Forms.TabPage();
			this.ListBoxChildThreadsLog = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TextBoxSleep = new System.Windows.Forms.TextBox();
			this.CheckBoxIsBackground = new System.Windows.Forms.CheckBox();
			this.ButtonStop = new System.Windows.Forms.Button();
			this.ButtonShow = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBoxNumberOfChildThreads = new System.Windows.Forms.TextBox();
			this.TabControlLog.SuspendLayout();
			this.TabPageMainThreadsLog.SuspendLayout();
			this.TabPageChildThreadsLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextBoxNumberOfMainThreads
			// 
			this.TextBoxNumberOfMainThreads.Location = new System.Drawing.Point(144, 6);
			this.TextBoxNumberOfMainThreads.Name = "TextBoxNumberOfMainThreads";
			this.TextBoxNumberOfMainThreads.Size = new System.Drawing.Size(100, 20);
			this.TextBoxNumberOfMainThreads.TabIndex = 0;
			this.TextBoxNumberOfMainThreads.Text = "5";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Number Of Main Threads:";
			// 
			// ButtonDoIt
			// 
			this.ButtonDoIt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ButtonDoIt.Location = new System.Drawing.Point(291, 238);
			this.ButtonDoIt.Name = "ButtonDoIt";
			this.ButtonDoIt.Size = new System.Drawing.Size(75, 23);
			this.ButtonDoIt.TabIndex = 2;
			this.ButtonDoIt.Text = "DoIt!";
			this.ButtonDoIt.UseVisualStyleBackColor = true;
			this.ButtonDoIt.Click += new System.EventHandler(this.ButtonDoIt_Click);
			// 
			// TabControlLog
			// 
			this.TabControlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControlLog.Controls.Add(this.TabPageMainThreadsLog);
			this.TabControlLog.Controls.Add(this.TabPageChildThreadsLog);
			this.TabControlLog.Location = new System.Drawing.Point(9, 32);
			this.TabControlLog.Name = "TabControlLog";
			this.TabControlLog.SelectedIndex = 0;
			this.TabControlLog.Size = new System.Drawing.Size(866, 200);
			this.TabControlLog.TabIndex = 3;
			// 
			// TabPageMainThreadsLog
			// 
			this.TabPageMainThreadsLog.Controls.Add(this.ListBoxMainThreadsLog);
			this.TabPageMainThreadsLog.Location = new System.Drawing.Point(4, 22);
			this.TabPageMainThreadsLog.Name = "TabPageMainThreadsLog";
			this.TabPageMainThreadsLog.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageMainThreadsLog.Size = new System.Drawing.Size(858, 174);
			this.TabPageMainThreadsLog.TabIndex = 0;
			this.TabPageMainThreadsLog.Text = "MainThreads";
			this.TabPageMainThreadsLog.UseVisualStyleBackColor = true;
			// 
			// ListBoxMainThreadsLog
			// 
			this.ListBoxMainThreadsLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBoxMainThreadsLog.FormattingEnabled = true;
			this.ListBoxMainThreadsLog.Location = new System.Drawing.Point(3, 3);
			this.ListBoxMainThreadsLog.Name = "ListBoxMainThreadsLog";
			this.ListBoxMainThreadsLog.Size = new System.Drawing.Size(852, 168);
			this.ListBoxMainThreadsLog.TabIndex = 0;
			// 
			// TabPageChildThreadsLog
			// 
			this.TabPageChildThreadsLog.Controls.Add(this.ListBoxChildThreadsLog);
			this.TabPageChildThreadsLog.Location = new System.Drawing.Point(4, 22);
			this.TabPageChildThreadsLog.Name = "TabPageChildThreadsLog";
			this.TabPageChildThreadsLog.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageChildThreadsLog.Size = new System.Drawing.Size(609, 174);
			this.TabPageChildThreadsLog.TabIndex = 1;
			this.TabPageChildThreadsLog.Text = "ChildThreads";
			this.TabPageChildThreadsLog.UseVisualStyleBackColor = true;
			// 
			// ListBoxChildThreadsLog
			// 
			this.ListBoxChildThreadsLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBoxChildThreadsLog.FormattingEnabled = true;
			this.ListBoxChildThreadsLog.Location = new System.Drawing.Point(3, 3);
			this.ListBoxChildThreadsLog.Name = "ListBoxChildThreadsLog";
			this.ListBoxChildThreadsLog.Size = new System.Drawing.Size(603, 168);
			this.ListBoxChildThreadsLog.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(254, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Sleep (ms):";
			// 
			// TextBoxSleep
			// 
			this.TextBoxSleep.Location = new System.Drawing.Point(317, 6);
			this.TextBoxSleep.Name = "TextBoxSleep";
			this.TextBoxSleep.Size = new System.Drawing.Size(100, 20);
			this.TextBoxSleep.TabIndex = 1;
			this.TextBoxSleep.Text = "1000";
			// 
			// CheckBoxIsBackground
			// 
			this.CheckBoxIsBackground.AutoSize = true;
			this.CheckBoxIsBackground.Location = new System.Drawing.Point(427, 8);
			this.CheckBoxIsBackground.Name = "CheckBoxIsBackground";
			this.CheckBoxIsBackground.Size = new System.Drawing.Size(92, 17);
			this.CheckBoxIsBackground.TabIndex = 5;
			this.CheckBoxIsBackground.Text = "IsBackground";
			this.CheckBoxIsBackground.UseVisualStyleBackColor = true;
			// 
			// ButtonStop
			// 
			this.ButtonStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ButtonStop.Enabled = false;
			this.ButtonStop.Location = new System.Drawing.Point(404, 238);
			this.ButtonStop.Name = "ButtonStop";
			this.ButtonStop.Size = new System.Drawing.Size(75, 23);
			this.ButtonStop.TabIndex = 6;
			this.ButtonStop.Text = "Stop";
			this.ButtonStop.UseVisualStyleBackColor = true;
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// ButtonShow
			// 
			this.ButtonShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ButtonShow.Location = new System.Drawing.Point(517, 238);
			this.ButtonShow.Name = "ButtonShow";
			this.ButtonShow.Size = new System.Drawing.Size(75, 23);
			this.ButtonShow.TabIndex = 7;
			this.ButtonShow.Text = "Show";
			this.ButtonShow.UseVisualStyleBackColor = true;
			this.ButtonShow.Click += new System.EventHandler(this.ButtonShow_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(529, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Number Of Child Threads:";
			// 
			// TextBoxNumberOfChildThreads
			// 
			this.TextBoxNumberOfChildThreads.Location = new System.Drawing.Point(663, 6);
			this.TextBoxNumberOfChildThreads.Name = "TextBoxNumberOfChildThreads";
			this.TextBoxNumberOfChildThreads.Size = new System.Drawing.Size(100, 20);
			this.TextBoxNumberOfChildThreads.TabIndex = 9;
			this.TextBoxNumberOfChildThreads.Text = "5";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 273);
			this.Controls.Add(this.TextBoxNumberOfChildThreads);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ButtonShow);
			this.Controls.Add(this.ButtonStop);
			this.Controls.Add(this.CheckBoxIsBackground);
			this.Controls.Add(this.TextBoxSleep);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TabControlLog);
			this.Controls.Add(this.ButtonDoIt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextBoxNumberOfMainThreads);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.TabControlLog.ResumeLayout(false);
			this.TabPageMainThreadsLog.ResumeLayout(false);
			this.TabPageChildThreadsLog.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBoxNumberOfMainThreads;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ButtonDoIt;
		private System.Windows.Forms.TabControl TabControlLog;
		private System.Windows.Forms.TabPage TabPageMainThreadsLog;
		private System.Windows.Forms.TabPage TabPageChildThreadsLog;
		private System.Windows.Forms.ListBox ListBoxMainThreadsLog;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TextBoxSleep;
		private System.Windows.Forms.CheckBox CheckBoxIsBackground;
		private System.Windows.Forms.Button ButtonStop;
		private System.Windows.Forms.Button ButtonShow;
		private System.Windows.Forms.ListBox ListBoxChildThreadsLog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TextBoxNumberOfChildThreads;
	}
}

