namespace TestAsyncAwaitWinApp
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnThreadInfo = new System.Windows.Forms.Button();
            this.btnSyncTaskRunResult = new System.Windows.Forms.Button();
            this.btnSyncGetAwaiterGetResult = new System.Windows.Forms.Button();
            this.btnSyncTaskResult = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnAsyncAwait = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.pnlBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnThreadInfo);
            this.pnlBottom.Controls.Add(this.btnSyncTaskRunResult);
            this.pnlBottom.Controls.Add(this.btnSyncGetAwaiterGetResult);
            this.pnlBottom.Controls.Add(this.btnSyncTaskResult);
            this.pnlBottom.Controls.Add(this.btnClearLog);
            this.pnlBottom.Controls.Add(this.btnAsyncAwait);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 511);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(984, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnThreadInfo
            // 
            this.btnThreadInfo.Location = new System.Drawing.Point(817, 14);
            this.btnThreadInfo.Name = "btnThreadInfo";
            this.btnThreadInfo.Size = new System.Drawing.Size(75, 23);
            this.btnThreadInfo.TabIndex = 5;
            this.btnThreadInfo.Text = "Thread info";
            this.btnThreadInfo.UseVisualStyleBackColor = true;
            this.btnThreadInfo.Click += new System.EventHandler(this.BtnThreadInfoClick);
            // 
            // btnSyncTaskRunResult
            // 
            this.btnSyncTaskRunResult.Location = new System.Drawing.Point(388, 14);
            this.btnSyncTaskRunResult.Name = "btnSyncTaskRunResult";
            this.btnSyncTaskRunResult.Size = new System.Drawing.Size(160, 23);
            this.btnSyncTaskRunResult.TabIndex = 4;
            this.btnSyncTaskRunResult.Text = "sync Task.Run() Result";
            this.btnSyncTaskRunResult.UseVisualStyleBackColor = true;
            this.btnSyncTaskRunResult.Click += new System.EventHandler(this.BtnSyncTaskRunResultClick);
            // 
            // btnSyncGetAwaiterGetResult
            // 
            this.btnSyncGetAwaiterGetResult.Location = new System.Drawing.Point(223, 14);
            this.btnSyncGetAwaiterGetResult.Name = "btnSyncGetAwaiterGetResult";
            this.btnSyncGetAwaiterGetResult.Size = new System.Drawing.Size(160, 23);
            this.btnSyncGetAwaiterGetResult.TabIndex = 3;
            this.btnSyncGetAwaiterGetResult.Text = "sync GetAwaiter().GetResult()";
            this.btnSyncGetAwaiterGetResult.UseVisualStyleBackColor = true;
            this.btnSyncGetAwaiterGetResult.Click += new System.EventHandler(this.BtnSyncGetAwaiterGetResultClick);
            // 
            // btnSyncTaskResult
            // 
            this.btnSyncTaskResult.Location = new System.Drawing.Point(118, 14);
            this.btnSyncTaskResult.Name = "btnSyncTaskResult";
            this.btnSyncTaskResult.Size = new System.Drawing.Size(100, 23);
            this.btnSyncTaskResult.TabIndex = 2;
            this.btnSyncTaskResult.Text = "sync task.Result";
            this.btnSyncTaskResult.UseVisualStyleBackColor = true;
            this.btnSyncTaskResult.Click += new System.EventHandler(this.BtnSyncTaskResultClick);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(897, 14);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLogClick);
            // 
            // btnAsyncAwait
            // 
            this.btnAsyncAwait.Location = new System.Drawing.Point(13, 14);
            this.btnAsyncAwait.Name = "btnAsyncAwait";
            this.btnAsyncAwait.Size = new System.Drawing.Size(100, 23);
            this.btnAsyncAwait.TabIndex = 0;
            this.btnAsyncAwait.Text = "async await";
            this.btnAsyncAwait.UseVisualStyleBackColor = true;
            this.btnAsyncAwait.Click += new System.EventHandler(this.BtnAsyncAwaitClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 511);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.listBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(976, 485);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 3);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(970, 479);
            this.listBoxLog.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnAsyncAwait;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnSyncTaskResult;
        private System.Windows.Forms.Button btnSyncGetAwaiterGetResult;
        private System.Windows.Forms.Button btnSyncTaskRunResult;
        private System.Windows.Forms.Button btnThreadInfo;
    }
}

