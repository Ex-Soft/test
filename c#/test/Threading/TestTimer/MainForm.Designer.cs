namespace TestTimer
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
            this.groupBoxSystemTimersTimer = new System.Windows.Forms.GroupBox();
            this.btnStartSystemTimersTimer = new System.Windows.Forms.Button();
            this.btnStopSystemTimersTimer = new System.Windows.Forms.Button();
            this.groupBoxSystemThreadingTimer = new System.Windows.Forms.GroupBox();
            this.btnStartSystemThreadingTimer = new System.Windows.Forms.Button();
            this.btnStopSystemThreadingTimer = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.checkBoxAutoReset = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.groupBoxSystemTimersTimer.SuspendLayout();
            this.groupBoxSystemThreadingTimer.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.groupBoxSystemTimersTimer);
            this.pnlBottom.Controls.Add(this.groupBoxSystemThreadingTimer);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 243);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1084, 68);
            this.pnlBottom.TabIndex = 0;
            // 
            // groupBoxSystemTimersTimer
            // 
            this.groupBoxSystemTimersTimer.Controls.Add(this.checkBoxAutoReset);
            this.groupBoxSystemTimersTimer.Controls.Add(this.btnStartSystemTimersTimer);
            this.groupBoxSystemTimersTimer.Controls.Add(this.btnStopSystemTimersTimer);
            this.groupBoxSystemTimersTimer.Location = new System.Drawing.Point(220, 8);
            this.groupBoxSystemTimersTimer.Name = "groupBoxSystemTimersTimer";
            this.groupBoxSystemTimersTimer.Size = new System.Drawing.Size(283, 50);
            this.groupBoxSystemTimersTimer.TabIndex = 9;
            this.groupBoxSystemTimersTimer.TabStop = false;
            this.groupBoxSystemTimersTimer.Text = "System.Timers.Timer";
            // 
            // btnStartSystemTimersTimer
            // 
            this.btnStartSystemTimersTimer.Location = new System.Drawing.Point(22, 22);
            this.btnStartSystemTimersTimer.Name = "btnStartSystemTimersTimer";
            this.btnStartSystemTimersTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStartSystemTimersTimer.TabIndex = 9;
            this.btnStartSystemTimersTimer.Text = "Start";
            this.btnStartSystemTimersTimer.UseVisualStyleBackColor = true;
            this.btnStartSystemTimersTimer.Click += new System.EventHandler(this.BtnStartSystemTimersTimerClick);
            // 
            // btnStopSystemTimersTimer
            // 
            this.btnStopSystemTimersTimer.Enabled = false;
            this.btnStopSystemTimersTimer.Location = new System.Drawing.Point(103, 22);
            this.btnStopSystemTimersTimer.Name = "btnStopSystemTimersTimer";
            this.btnStopSystemTimersTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStopSystemTimersTimer.TabIndex = 8;
            this.btnStopSystemTimersTimer.Text = "Stop";
            this.btnStopSystemTimersTimer.UseVisualStyleBackColor = true;
            this.btnStopSystemTimersTimer.Click += new System.EventHandler(this.BtnStopSystemTimersTimerClick);
            // 
            // groupBoxSystemThreadingTimer
            // 
            this.groupBoxSystemThreadingTimer.Controls.Add(this.btnStartSystemThreadingTimer);
            this.groupBoxSystemThreadingTimer.Controls.Add(this.btnStopSystemThreadingTimer);
            this.groupBoxSystemThreadingTimer.Location = new System.Drawing.Point(8, 8);
            this.groupBoxSystemThreadingTimer.Name = "groupBoxSystemThreadingTimer";
            this.groupBoxSystemThreadingTimer.Size = new System.Drawing.Size(200, 50);
            this.groupBoxSystemThreadingTimer.TabIndex = 8;
            this.groupBoxSystemThreadingTimer.TabStop = false;
            this.groupBoxSystemThreadingTimer.Text = "System.Threading.Timer";
            // 
            // btnStartSystemThreadingTimer
            // 
            this.btnStartSystemThreadingTimer.Location = new System.Drawing.Point(22, 22);
            this.btnStartSystemThreadingTimer.Name = "btnStartSystemThreadingTimer";
            this.btnStartSystemThreadingTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStartSystemThreadingTimer.TabIndex = 9;
            this.btnStartSystemThreadingTimer.Text = "Start";
            this.btnStartSystemThreadingTimer.UseVisualStyleBackColor = true;
            this.btnStartSystemThreadingTimer.Click += new System.EventHandler(this.BtnStartSystemThreadingTimerClick);
            // 
            // btnStopSystemThreadingTimer
            // 
            this.btnStopSystemThreadingTimer.Enabled = false;
            this.btnStopSystemThreadingTimer.Location = new System.Drawing.Point(103, 22);
            this.btnStopSystemThreadingTimer.Name = "btnStopSystemThreadingTimer";
            this.btnStopSystemThreadingTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStopSystemThreadingTimer.TabIndex = 8;
            this.btnStopSystemThreadingTimer.Text = "Stop";
            this.btnStopSystemThreadingTimer.UseVisualStyleBackColor = true;
            this.btnStopSystemThreadingTimer.Click += new System.EventHandler(this.BtnStopSystemThreadingTimerClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.listBoxLog);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1084, 243);
            this.pnlFill.TabIndex = 1;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(0, 0);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.ScrollAlwaysVisible = true;
            this.listBoxLog.Size = new System.Drawing.Size(1084, 243);
            this.listBoxLog.TabIndex = 3;
            // 
            // checkBoxAutoReset
            // 
            this.checkBoxAutoReset.AutoSize = true;
            this.checkBoxAutoReset.Checked = true;
            this.checkBoxAutoReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoReset.Location = new System.Drawing.Point(185, 25);
            this.checkBoxAutoReset.Name = "checkBoxAutoReset";
            this.checkBoxAutoReset.Size = new System.Drawing.Size(76, 17);
            this.checkBoxAutoReset.TabIndex = 10;
            this.checkBoxAutoReset.Text = "AutoReset";
            this.checkBoxAutoReset.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 311);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Timer";
            this.pnlBottom.ResumeLayout(false);
            this.groupBoxSystemTimersTimer.ResumeLayout(false);
            this.groupBoxSystemTimersTimer.PerformLayout();
            this.groupBoxSystemThreadingTimer.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBoxSystemThreadingTimer;
        private System.Windows.Forms.GroupBox groupBoxSystemTimersTimer;
        private System.Windows.Forms.Button btnStartSystemTimersTimer;
        private System.Windows.Forms.Button btnStopSystemTimersTimer;
        private System.Windows.Forms.Button btnStartSystemThreadingTimer;
        private System.Windows.Forms.Button btnStopSystemThreadingTimer;
        private System.Windows.Forms.CheckBox checkBoxAutoReset;
    }
}

