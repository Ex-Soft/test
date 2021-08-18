
namespace AllWinApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpManualResetEvent = new System.Windows.Forms.TabPage();
            this.scManualResetEvent = new System.Windows.Forms.SplitContainer();
            this.btnManualResetEventStop = new System.Windows.Forms.Button();
            this.btnManualResetEventStart = new System.Windows.Forms.Button();
            this.btnManualResetEventReset = new System.Windows.Forms.Button();
            this.btnManualResetEventSet = new System.Windows.Forms.Button();
            this.lbManualResetEventLog = new System.Windows.Forms.ListBox();
            this.tpManualResetEventSlim = new System.Windows.Forms.TabPage();
            this.scManualResetEventSlim = new System.Windows.Forms.SplitContainer();
            this.btnManualResetEventSlimStop = new System.Windows.Forms.Button();
            this.btnManualResetEventSlimStart = new System.Windows.Forms.Button();
            this.btnManualResetEventSetSlim = new System.Windows.Forms.Button();
            this.btnManualSetEventSlimSet = new System.Windows.Forms.Button();
            this.lbManualResetEventSlimLog = new System.Windows.Forms.ListBox();
            this.tpTask = new System.Windows.Forms.TabPage();
            this.scTask = new System.Windows.Forms.SplitContainer();
            this.btnCancellationTokenSourceForTaskCancel = new System.Windows.Forms.Button();
            this.btnManualResetEventSlimForTaskSet = new System.Windows.Forms.Button();
            this.btnWaitHandleToTask = new System.Windows.Forms.Button();
            this.btnTaskToWaitHandle = new System.Windows.Forms.Button();
            this.lbTaskLog = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tpManualResetEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scManualResetEvent)).BeginInit();
            this.scManualResetEvent.Panel1.SuspendLayout();
            this.scManualResetEvent.Panel2.SuspendLayout();
            this.scManualResetEvent.SuspendLayout();
            this.tpManualResetEventSlim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scManualResetEventSlim)).BeginInit();
            this.scManualResetEventSlim.Panel1.SuspendLayout();
            this.scManualResetEventSlim.Panel2.SuspendLayout();
            this.scManualResetEventSlim.SuspendLayout();
            this.tpTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTask)).BeginInit();
            this.scTask.Panel1.SuspendLayout();
            this.scTask.Panel2.SuspendLayout();
            this.scTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpManualResetEvent);
            this.tabControl.Controls.Add(this.tpManualResetEventSlim);
            this.tabControl.Controls.Add(this.tpTask);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tpManualResetEvent
            // 
            this.tpManualResetEvent.Controls.Add(this.scManualResetEvent);
            this.tpManualResetEvent.Location = new System.Drawing.Point(4, 29);
            this.tpManualResetEvent.Name = "tpManualResetEvent";
            this.tpManualResetEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tpManualResetEvent.Size = new System.Drawing.Size(792, 417);
            this.tpManualResetEvent.TabIndex = 0;
            this.tpManualResetEvent.Text = "ManualResetEvent";
            this.tpManualResetEvent.UseVisualStyleBackColor = true;
            // 
            // scManualResetEvent
            // 
            this.scManualResetEvent.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.scManualResetEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scManualResetEvent.Location = new System.Drawing.Point(3, 3);
            this.scManualResetEvent.Name = "scManualResetEvent";
            this.scManualResetEvent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scManualResetEvent.Panel1
            // 
            this.scManualResetEvent.Panel1.Controls.Add(this.btnManualResetEventStop);
            this.scManualResetEvent.Panel1.Controls.Add(this.btnManualResetEventStart);
            this.scManualResetEvent.Panel1.Controls.Add(this.btnManualResetEventReset);
            this.scManualResetEvent.Panel1.Controls.Add(this.btnManualResetEventSet);
            // 
            // scManualResetEvent.Panel2
            // 
            this.scManualResetEvent.Panel2.Controls.Add(this.lbManualResetEventLog);
            this.scManualResetEvent.Size = new System.Drawing.Size(786, 411);
            this.scManualResetEvent.SplitterDistance = 90;
            this.scManualResetEvent.TabIndex = 0;
            // 
            // btnManualResetEventStop
            // 
            this.btnManualResetEventStop.Location = new System.Drawing.Point(429, 23);
            this.btnManualResetEventStop.Name = "btnManualResetEventStop";
            this.btnManualResetEventStop.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventStop.TabIndex = 3;
            this.btnManualResetEventStop.Text = "Stop";
            this.btnManualResetEventStop.UseVisualStyleBackColor = true;
            this.btnManualResetEventStop.Click += new System.EventHandler(this.BtnManualResetEventStopClick);
            // 
            // btnManualResetEventStart
            // 
            this.btnManualResetEventStart.Location = new System.Drawing.Point(52, 23);
            this.btnManualResetEventStart.Name = "btnManualResetEventStart";
            this.btnManualResetEventStart.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventStart.TabIndex = 2;
            this.btnManualResetEventStart.Text = "Start";
            this.btnManualResetEventStart.UseVisualStyleBackColor = true;
            this.btnManualResetEventStart.Click += new System.EventHandler(this.BtnManualResetEventStartClick);
            // 
            // btnManualResetEventReset
            // 
            this.btnManualResetEventReset.Location = new System.Drawing.Point(317, 23);
            this.btnManualResetEventReset.Name = "btnManualResetEventReset";
            this.btnManualResetEventReset.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventReset.TabIndex = 1;
            this.btnManualResetEventReset.Text = "Reset";
            this.btnManualResetEventReset.UseVisualStyleBackColor = true;
            this.btnManualResetEventReset.Click += new System.EventHandler(this.BtnManualResetEventResetClick);
            // 
            // btnManualResetEventSet
            // 
            this.btnManualResetEventSet.Location = new System.Drawing.Point(186, 23);
            this.btnManualResetEventSet.Name = "btnManualResetEventSet";
            this.btnManualResetEventSet.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventSet.TabIndex = 0;
            this.btnManualResetEventSet.Text = "Set";
            this.btnManualResetEventSet.UseVisualStyleBackColor = true;
            this.btnManualResetEventSet.Click += new System.EventHandler(this.BtnManualResetEventSetClick);
            // 
            // lbManualResetEventLog
            // 
            this.lbManualResetEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbManualResetEventLog.FormattingEnabled = true;
            this.lbManualResetEventLog.ItemHeight = 20;
            this.lbManualResetEventLog.Location = new System.Drawing.Point(0, 0);
            this.lbManualResetEventLog.Name = "lbManualResetEventLog";
            this.lbManualResetEventLog.Size = new System.Drawing.Size(786, 317);
            this.lbManualResetEventLog.TabIndex = 0;
            // 
            // tpManualResetEventSlim
            // 
            this.tpManualResetEventSlim.Controls.Add(this.scManualResetEventSlim);
            this.tpManualResetEventSlim.Location = new System.Drawing.Point(4, 29);
            this.tpManualResetEventSlim.Name = "tpManualResetEventSlim";
            this.tpManualResetEventSlim.Padding = new System.Windows.Forms.Padding(3);
            this.tpManualResetEventSlim.Size = new System.Drawing.Size(792, 417);
            this.tpManualResetEventSlim.TabIndex = 1;
            this.tpManualResetEventSlim.Text = "ManualResetEventSlim";
            this.tpManualResetEventSlim.UseVisualStyleBackColor = true;
            // 
            // scManualResetEventSlim
            // 
            this.scManualResetEventSlim.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.scManualResetEventSlim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scManualResetEventSlim.Location = new System.Drawing.Point(3, 3);
            this.scManualResetEventSlim.Name = "scManualResetEventSlim";
            this.scManualResetEventSlim.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scManualResetEventSlim.Panel1
            // 
            this.scManualResetEventSlim.Panel1.Controls.Add(this.btnManualResetEventSlimStop);
            this.scManualResetEventSlim.Panel1.Controls.Add(this.btnManualResetEventSlimStart);
            this.scManualResetEventSlim.Panel1.Controls.Add(this.btnManualResetEventSetSlim);
            this.scManualResetEventSlim.Panel1.Controls.Add(this.btnManualSetEventSlimSet);
            // 
            // scManualResetEventSlim.Panel2
            // 
            this.scManualResetEventSlim.Panel2.Controls.Add(this.lbManualResetEventSlimLog);
            this.scManualResetEventSlim.Size = new System.Drawing.Size(786, 411);
            this.scManualResetEventSlim.SplitterDistance = 90;
            this.scManualResetEventSlim.TabIndex = 1;
            // 
            // btnManualResetEventSlimStop
            // 
            this.btnManualResetEventSlimStop.Location = new System.Drawing.Point(429, 23);
            this.btnManualResetEventSlimStop.Name = "btnManualResetEventSlimStop";
            this.btnManualResetEventSlimStop.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventSlimStop.TabIndex = 3;
            this.btnManualResetEventSlimStop.Text = "Stop";
            this.btnManualResetEventSlimStop.UseVisualStyleBackColor = true;
            this.btnManualResetEventSlimStop.Click += new System.EventHandler(this.BtnManualResetEventSlimStopClick);
            // 
            // btnManualResetEventSlimStart
            // 
            this.btnManualResetEventSlimStart.Location = new System.Drawing.Point(52, 23);
            this.btnManualResetEventSlimStart.Name = "btnManualResetEventSlimStart";
            this.btnManualResetEventSlimStart.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventSlimStart.TabIndex = 2;
            this.btnManualResetEventSlimStart.Text = "Start";
            this.btnManualResetEventSlimStart.UseVisualStyleBackColor = true;
            this.btnManualResetEventSlimStart.Click += new System.EventHandler(this.BtnManualResetEventSlimStartClick);
            // 
            // btnManualResetEventSetSlim
            // 
            this.btnManualResetEventSetSlim.Location = new System.Drawing.Point(317, 23);
            this.btnManualResetEventSetSlim.Name = "btnManualResetEventSetSlim";
            this.btnManualResetEventSetSlim.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventSetSlim.TabIndex = 1;
            this.btnManualResetEventSetSlim.Text = "Reset";
            this.btnManualResetEventSetSlim.UseVisualStyleBackColor = true;
            this.btnManualResetEventSetSlim.Click += new System.EventHandler(this.BtnManualResetEventSlimResetClick);
            // 
            // btnManualSetEventSlimSet
            // 
            this.btnManualSetEventSlimSet.Location = new System.Drawing.Point(186, 23);
            this.btnManualSetEventSlimSet.Name = "btnManualSetEventSlimSet";
            this.btnManualSetEventSlimSet.Size = new System.Drawing.Size(94, 29);
            this.btnManualSetEventSlimSet.TabIndex = 0;
            this.btnManualSetEventSlimSet.Text = "Set";
            this.btnManualSetEventSlimSet.UseVisualStyleBackColor = true;
            this.btnManualSetEventSlimSet.Click += new System.EventHandler(this.BtnManualResetEventSlimSetClick);
            // 
            // lbManualResetEventSlimLog
            // 
            this.lbManualResetEventSlimLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbManualResetEventSlimLog.FormattingEnabled = true;
            this.lbManualResetEventSlimLog.ItemHeight = 20;
            this.lbManualResetEventSlimLog.Location = new System.Drawing.Point(0, 0);
            this.lbManualResetEventSlimLog.Name = "lbManualResetEventSlimLog";
            this.lbManualResetEventSlimLog.Size = new System.Drawing.Size(786, 317);
            this.lbManualResetEventSlimLog.TabIndex = 0;
            // 
            // tpTask
            // 
            this.tpTask.Controls.Add(this.scTask);
            this.tpTask.Location = new System.Drawing.Point(4, 29);
            this.tpTask.Name = "tpTask";
            this.tpTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpTask.Size = new System.Drawing.Size(792, 417);
            this.tpTask.TabIndex = 2;
            this.tpTask.Text = "Task";
            this.tpTask.UseVisualStyleBackColor = true;
            // 
            // scTask
            // 
            this.scTask.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.scTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTask.Location = new System.Drawing.Point(3, 3);
            this.scTask.Name = "scTask";
            this.scTask.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTask.Panel1
            // 
            this.scTask.Panel1.Controls.Add(this.btnCancellationTokenSourceForTaskCancel);
            this.scTask.Panel1.Controls.Add(this.btnManualResetEventSlimForTaskSet);
            this.scTask.Panel1.Controls.Add(this.btnWaitHandleToTask);
            this.scTask.Panel1.Controls.Add(this.btnTaskToWaitHandle);
            // 
            // scTask.Panel2
            // 
            this.scTask.Panel2.Controls.Add(this.lbTaskLog);
            this.scTask.Size = new System.Drawing.Size(786, 411);
            this.scTask.SplitterDistance = 90;
            this.scTask.TabIndex = 2;
            // 
            // btnCancellationTokenSourceForTaskCancel
            // 
            this.btnCancellationTokenSourceForTaskCancel.Location = new System.Drawing.Point(261, 23);
            this.btnCancellationTokenSourceForTaskCancel.Name = "btnCancellationTokenSourceForTaskCancel";
            this.btnCancellationTokenSourceForTaskCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancellationTokenSourceForTaskCancel.TabIndex = 5;
            this.btnCancellationTokenSourceForTaskCancel.Text = "Cancel";
            this.btnCancellationTokenSourceForTaskCancel.UseVisualStyleBackColor = true;
            this.btnCancellationTokenSourceForTaskCancel.Click += new System.EventHandler(this.BtnCancellationTokenSourceForTaskCancelClick);
            // 
            // btnManualResetEventSlimForTaskSet
            // 
            this.btnManualResetEventSlimForTaskSet.Location = new System.Drawing.Point(161, 23);
            this.btnManualResetEventSlimForTaskSet.Name = "btnManualResetEventSlimForTaskSet";
            this.btnManualResetEventSlimForTaskSet.Size = new System.Drawing.Size(94, 29);
            this.btnManualResetEventSlimForTaskSet.TabIndex = 4;
            this.btnManualResetEventSlimForTaskSet.Text = "Set";
            this.btnManualResetEventSlimForTaskSet.UseVisualStyleBackColor = true;
            this.btnManualResetEventSlimForTaskSet.Click += new System.EventHandler(this.BtnManualResetEventSlimForTaskSetClick);
            // 
            // btnWaitHandleToTask
            // 
            this.btnWaitHandleToTask.Location = new System.Drawing.Point(5, 23);
            this.btnWaitHandleToTask.Name = "btnWaitHandleToTask";
            this.btnWaitHandleToTask.Size = new System.Drawing.Size(150, 29);
            this.btnWaitHandleToTask.TabIndex = 3;
            this.btnWaitHandleToTask.Text = "WaitHandle -> Task";
            this.btnWaitHandleToTask.UseVisualStyleBackColor = true;
            this.btnWaitHandleToTask.Click += new System.EventHandler(this.BtnWaitHandleToTaskClick);
            // 
            // btnTaskToWaitHandle
            // 
            this.btnTaskToWaitHandle.Location = new System.Drawing.Point(384, 23);
            this.btnTaskToWaitHandle.Name = "btnTaskToWaitHandle";
            this.btnTaskToWaitHandle.Size = new System.Drawing.Size(150, 29);
            this.btnTaskToWaitHandle.TabIndex = 2;
            this.btnTaskToWaitHandle.Text = "Task -> WaitHandle";
            this.btnTaskToWaitHandle.UseVisualStyleBackColor = true;
            this.btnTaskToWaitHandle.Click += new System.EventHandler(this.BtnTaskToWaitHandleClick);
            // 
            // lbTaskLog
            // 
            this.lbTaskLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTaskLog.FormattingEnabled = true;
            this.lbTaskLog.ItemHeight = 20;
            this.lbTaskLog.Location = new System.Drawing.Point(0, 0);
            this.lbTaskLog.Name = "lbTaskLog";
            this.lbTaskLog.Size = new System.Drawing.Size(786, 317);
            this.lbTaskLog.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.tpManualResetEvent.ResumeLayout(false);
            this.scManualResetEvent.Panel1.ResumeLayout(false);
            this.scManualResetEvent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scManualResetEvent)).EndInit();
            this.scManualResetEvent.ResumeLayout(false);
            this.tpManualResetEventSlim.ResumeLayout(false);
            this.scManualResetEventSlim.Panel1.ResumeLayout(false);
            this.scManualResetEventSlim.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scManualResetEventSlim)).EndInit();
            this.scManualResetEventSlim.ResumeLayout(false);
            this.tpTask.ResumeLayout(false);
            this.scTask.Panel1.ResumeLayout(false);
            this.scTask.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTask)).EndInit();
            this.scTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpManualResetEvent;
        private System.Windows.Forms.SplitContainer scManualResetEvent;
        private System.Windows.Forms.Button btnManualResetEventReset;
        private System.Windows.Forms.Button btnManualResetEventSet;
        private System.Windows.Forms.ListBox lbManualResetEventLog;
        private System.Windows.Forms.TabPage tpManualResetEventSlim;
        private System.Windows.Forms.Button btnManualResetEventStart;
        private System.Windows.Forms.Button btnManualResetEventStop;
        private System.Windows.Forms.SplitContainer scManualResetEventSlim;
        private System.Windows.Forms.Button btnManualResetEventSlimStop;
        private System.Windows.Forms.Button btnManualResetEventSlimStart;
        private System.Windows.Forms.Button btnManualResetEventSetSlim;
        private System.Windows.Forms.Button btnManualSetEventSlimSet;
        private System.Windows.Forms.ListBox lbManualResetEventSlimLog;
        private System.Windows.Forms.TabPage tpTask;
        private System.Windows.Forms.SplitContainer scTask;
        private System.Windows.Forms.Button btnWaitHandleToTask;
        private System.Windows.Forms.Button btnTaskToWaitHandle;
        private System.Windows.Forms.ListBox lbTaskLog;
        private System.Windows.Forms.Button btnCancellationTokenSourceForTaskCancel;
        private System.Windows.Forms.Button btnManualResetEventSlimForTaskSet;
    }
}

