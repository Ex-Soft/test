namespace TestSemaphoreSlimWinApp
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
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxTask = new System.Windows.Forms.GroupBox();
            this.textBoxTaskDelay = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.textBoxTaskMaxCount = new System.Windows.Forms.TextBox();
            this.labelTaskMaxCount = new System.Windows.Forms.Label();
            this.groupBoxSemaphoreSlim = new System.Windows.Forms.GroupBox();
            this.textBoxBoxSemaphoreSlimDelay = new System.Windows.Forms.TextBox();
            this.labelSemaphoreSlimDelay = new System.Windows.Forms.Label();
            this.textBoxSemaphoreSlimInitialCount = new System.Windows.Forms.TextBox();
            this.textBoxSemaphoreSlimMaxCount = new System.Windows.Forms.TextBox();
            this.labelSemaphoreSlimMaxCount = new System.Windows.Forms.Label();
            this.labelSemaphoreSlimInitialCount = new System.Windows.Forms.Label();
            this.buttonDoIt = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.groupBoxTask.SuspendLayout();
            this.groupBoxSemaphoreSlim.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(876, 608);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.button1);
            this.tabPageMain.Controls.Add(this.groupBoxTask);
            this.tabPageMain.Controls.Add(this.groupBoxSemaphoreSlim);
            this.tabPageMain.Controls.Add(this.buttonDoIt);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(868, 582);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clear Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add(this.textBoxTaskDelay);
            this.groupBoxTask.Controls.Add(this.labelDelay);
            this.groupBoxTask.Controls.Add(this.textBoxTaskMaxCount);
            this.groupBoxTask.Controls.Add(this.labelTaskMaxCount);
            this.groupBoxTask.Location = new System.Drawing.Point(278, 20);
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTask.TabIndex = 2;
            this.groupBoxTask.TabStop = false;
            this.groupBoxTask.Text = "Task";
            // 
            // textBoxTaskDelay
            // 
            this.textBoxTaskDelay.Location = new System.Drawing.Point(83, 62);
            this.textBoxTaskDelay.Name = "textBoxTaskDelay";
            this.textBoxTaskDelay.Size = new System.Drawing.Size(100, 20);
            this.textBoxTaskDelay.TabIndex = 4;
            this.textBoxTaskDelay.Text = "1000";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(18, 70);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(34, 13);
            this.labelDelay.TabIndex = 3;
            this.labelDelay.Text = "Delay";
            // 
            // textBoxTaskMaxCount
            // 
            this.textBoxTaskMaxCount.Location = new System.Drawing.Point(82, 36);
            this.textBoxTaskMaxCount.Name = "textBoxTaskMaxCount";
            this.textBoxTaskMaxCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxTaskMaxCount.TabIndex = 2;
            this.textBoxTaskMaxCount.Text = "10";
            // 
            // labelTaskMaxCount
            // 
            this.labelTaskMaxCount.AutoSize = true;
            this.labelTaskMaxCount.Location = new System.Drawing.Point(17, 44);
            this.labelTaskMaxCount.Name = "labelTaskMaxCount";
            this.labelTaskMaxCount.Size = new System.Drawing.Size(54, 13);
            this.labelTaskMaxCount.TabIndex = 1;
            this.labelTaskMaxCount.Text = "maxCount";
            // 
            // groupBoxSemaphoreSlim
            // 
            this.groupBoxSemaphoreSlim.Controls.Add(this.textBoxBoxSemaphoreSlimDelay);
            this.groupBoxSemaphoreSlim.Controls.Add(this.labelSemaphoreSlimDelay);
            this.groupBoxSemaphoreSlim.Controls.Add(this.textBoxSemaphoreSlimInitialCount);
            this.groupBoxSemaphoreSlim.Controls.Add(this.textBoxSemaphoreSlimMaxCount);
            this.groupBoxSemaphoreSlim.Controls.Add(this.labelSemaphoreSlimMaxCount);
            this.groupBoxSemaphoreSlim.Controls.Add(this.labelSemaphoreSlimInitialCount);
            this.groupBoxSemaphoreSlim.Location = new System.Drawing.Point(25, 20);
            this.groupBoxSemaphoreSlim.Name = "groupBoxSemaphoreSlim";
            this.groupBoxSemaphoreSlim.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSemaphoreSlim.TabIndex = 1;
            this.groupBoxSemaphoreSlim.TabStop = false;
            this.groupBoxSemaphoreSlim.Text = "SemaphoreSlim";
            // 
            // textBoxBoxSemaphoreSlimDelay
            // 
            this.textBoxBoxSemaphoreSlimDelay.Location = new System.Drawing.Point(82, 63);
            this.textBoxBoxSemaphoreSlimDelay.Name = "textBoxBoxSemaphoreSlimDelay";
            this.textBoxBoxSemaphoreSlimDelay.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoxSemaphoreSlimDelay.TabIndex = 5;
            this.textBoxBoxSemaphoreSlimDelay.Text = "0";
            // 
            // labelSemaphoreSlimDelay
            // 
            this.labelSemaphoreSlimDelay.AutoSize = true;
            this.labelSemaphoreSlimDelay.Location = new System.Drawing.Point(17, 69);
            this.labelSemaphoreSlimDelay.Name = "labelSemaphoreSlimDelay";
            this.labelSemaphoreSlimDelay.Size = new System.Drawing.Size(34, 13);
            this.labelSemaphoreSlimDelay.TabIndex = 4;
            this.labelSemaphoreSlimDelay.Text = "Delay";
            // 
            // textBoxSemaphoreSlimInitialCount
            // 
            this.textBoxSemaphoreSlimInitialCount.Location = new System.Drawing.Point(82, 13);
            this.textBoxSemaphoreSlimInitialCount.Name = "textBoxSemaphoreSlimInitialCount";
            this.textBoxSemaphoreSlimInitialCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxSemaphoreSlimInitialCount.TabIndex = 3;
            this.textBoxSemaphoreSlimInitialCount.Text = "3";
            // 
            // textBoxSemaphoreSlimMaxCount
            // 
            this.textBoxSemaphoreSlimMaxCount.Location = new System.Drawing.Point(82, 36);
            this.textBoxSemaphoreSlimMaxCount.Name = "textBoxSemaphoreSlimMaxCount";
            this.textBoxSemaphoreSlimMaxCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxSemaphoreSlimMaxCount.TabIndex = 2;
            this.textBoxSemaphoreSlimMaxCount.Text = "0";
            // 
            // labelSemaphoreSlimMaxCount
            // 
            this.labelSemaphoreSlimMaxCount.AutoSize = true;
            this.labelSemaphoreSlimMaxCount.Location = new System.Drawing.Point(17, 44);
            this.labelSemaphoreSlimMaxCount.Name = "labelSemaphoreSlimMaxCount";
            this.labelSemaphoreSlimMaxCount.Size = new System.Drawing.Size(54, 13);
            this.labelSemaphoreSlimMaxCount.TabIndex = 1;
            this.labelSemaphoreSlimMaxCount.Text = "maxCount";
            // 
            // labelSemaphoreSlimInitialCount
            // 
            this.labelSemaphoreSlimInitialCount.AutoSize = true;
            this.labelSemaphoreSlimInitialCount.Location = new System.Drawing.Point(17, 20);
            this.labelSemaphoreSlimInitialCount.Name = "labelSemaphoreSlimInitialCount";
            this.labelSemaphoreSlimInitialCount.Size = new System.Drawing.Size(58, 13);
            this.labelSemaphoreSlimInitialCount.TabIndex = 0;
            this.labelSemaphoreSlimInitialCount.Text = "initialCount";
            // 
            // buttonDoIt
            // 
            this.buttonDoIt.Location = new System.Drawing.Point(78, 219);
            this.buttonDoIt.Name = "buttonDoIt";
            this.buttonDoIt.Size = new System.Drawing.Size(75, 23);
            this.buttonDoIt.TabIndex = 0;
            this.buttonDoIt.Text = "DoIt!";
            this.buttonDoIt.UseVisualStyleBackColor = true;
            this.buttonDoIt.Click += new System.EventHandler(this.buttonDoIt_Click);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.listBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(868, 582);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 3);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(862, 576);
            this.listBoxLog.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 608);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test SemaphoreSlim";
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.groupBoxTask.ResumeLayout(false);
            this.groupBoxTask.PerformLayout();
            this.groupBoxSemaphoreSlim.ResumeLayout(false);
            this.groupBoxSemaphoreSlim.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Button buttonDoIt;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBoxSemaphoreSlim;
        private System.Windows.Forms.Label labelSemaphoreSlimInitialCount;
        private System.Windows.Forms.TextBox textBoxSemaphoreSlimInitialCount;
        private System.Windows.Forms.TextBox textBoxSemaphoreSlimMaxCount;
        private System.Windows.Forms.Label labelSemaphoreSlimMaxCount;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.TextBox textBoxTaskMaxCount;
        private System.Windows.Forms.Label labelTaskMaxCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTaskDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Label labelSemaphoreSlimDelay;
        private System.Windows.Forms.TextBox textBoxBoxSemaphoreSlimDelay;
    }
}

