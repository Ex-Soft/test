namespace TestTaskWinForm
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
            this.btnStartTaskWithChildren = new System.Windows.Forms.Button();
            this.btnCancelTaskWithChildren = new System.Windows.Forms.Button();
            this.btnStartTask = new System.Windows.Forms.Button();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblChildrenTaskMax = new System.Windows.Forms.Label();
            this.lblmSec = new System.Windows.Forms.Label();
            this.tbChildrenTaskMax = new System.Windows.Forms.TextBox();
            this.tbmSec = new System.Windows.Forms.TextBox();
            this.btnStartTaskNotAsync = new System.Windows.Forms.Button();
            this.buttonStartTaskTAP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartTaskWithChildren
            // 
            this.btnStartTaskWithChildren.Location = new System.Drawing.Point(723, 191);
            this.btnStartTaskWithChildren.Name = "btnStartTaskWithChildren";
            this.btnStartTaskWithChildren.Size = new System.Drawing.Size(170, 23);
            this.btnStartTaskWithChildren.TabIndex = 0;
            this.btnStartTaskWithChildren.Text = "Start Task (with children)";
            this.btnStartTaskWithChildren.UseVisualStyleBackColor = true;
            this.btnStartTaskWithChildren.Click += new System.EventHandler(this.BtnStartTaskWithChildrenClick);
            // 
            // btnCancelTaskWithChildren
            // 
            this.btnCancelTaskWithChildren.Location = new System.Drawing.Point(723, 220);
            this.btnCancelTaskWithChildren.Name = "btnCancelTaskWithChildren";
            this.btnCancelTaskWithChildren.Size = new System.Drawing.Size(170, 23);
            this.btnCancelTaskWithChildren.TabIndex = 1;
            this.btnCancelTaskWithChildren.Text = "Cancel Task (with children)";
            this.btnCancelTaskWithChildren.UseVisualStyleBackColor = true;
            this.btnCancelTaskWithChildren.Click += new System.EventHandler(this.BtnCancelTaskClick);
            // 
            // btnStartTask
            // 
            this.btnStartTask.Location = new System.Drawing.Point(723, 133);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(170, 23);
            this.btnStartTask.TabIndex = 2;
            this.btnStartTask.Text = "Start Task";
            this.btnStartTask.UseVisualStyleBackColor = true;
            this.btnStartTask.Click += new System.EventHandler(this.BtnStartTaskClick);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(723, 162);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(170, 23);
            this.btnCancelTask.TabIndex = 3;
            this.btnCancelTask.Text = "Cancel Task";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.BtnCancelTaskClick);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(22, 12);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(675, 264);
            this.listBoxLog.TabIndex = 4;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(723, 257);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(170, 23);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLogClick);
            // 
            // lblChildrenTaskMax
            // 
            this.lblChildrenTaskMax.AutoSize = true;
            this.lblChildrenTaskMax.Location = new System.Drawing.Point(723, 21);
            this.lblChildrenTaskMax.Name = "lblChildrenTaskMax";
            this.lblChildrenTaskMax.Size = new System.Drawing.Size(45, 13);
            this.lblChildrenTaskMax.TabIndex = 6;
            this.lblChildrenTaskMax.Text = "Children";
            // 
            // lblmSec
            // 
            this.lblmSec.AutoSize = true;
            this.lblmSec.Location = new System.Drawing.Point(723, 51);
            this.lblmSec.Name = "lblmSec";
            this.lblmSec.Size = new System.Drawing.Size(34, 13);
            this.lblmSec.TabIndex = 7;
            this.lblmSec.Text = "mSec";
            // 
            // tbChildrenTaskMax
            // 
            this.tbChildrenTaskMax.Location = new System.Drawing.Point(793, 17);
            this.tbChildrenTaskMax.Name = "tbChildrenTaskMax";
            this.tbChildrenTaskMax.Size = new System.Drawing.Size(100, 20);
            this.tbChildrenTaskMax.TabIndex = 8;
            // 
            // tbmSec
            // 
            this.tbmSec.Location = new System.Drawing.Point(793, 47);
            this.tbmSec.Name = "tbmSec";
            this.tbmSec.Size = new System.Drawing.Size(100, 20);
            this.tbmSec.TabIndex = 9;
            // 
            // btnStartTaskNotAsync
            // 
            this.btnStartTaskNotAsync.Location = new System.Drawing.Point(723, 104);
            this.btnStartTaskNotAsync.Name = "btnStartTaskNotAsync";
            this.btnStartTaskNotAsync.Size = new System.Drawing.Size(170, 23);
            this.btnStartTaskNotAsync.TabIndex = 10;
            this.btnStartTaskNotAsync.Text = "Start Task (!async)";
            this.btnStartTaskNotAsync.UseVisualStyleBackColor = true;
            this.btnStartTaskNotAsync.Click += new System.EventHandler(this.BtnStartTaskNotAsyncClick);
            // 
            // buttonStartTaskTAP
            // 
            this.buttonStartTaskTAP.Location = new System.Drawing.Point(723, 75);
            this.buttonStartTaskTAP.Name = "buttonStartTaskTAP";
            this.buttonStartTaskTAP.Size = new System.Drawing.Size(170, 23);
            this.buttonStartTaskTAP.TabIndex = 11;
            this.buttonStartTaskTAP.Text = "Start Task (TAP)";
            this.buttonStartTaskTAP.UseVisualStyleBackColor = true;
            this.buttonStartTaskTAP.Click += new System.EventHandler(this.ButtonStartTaskTAPClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 292);
            this.Controls.Add(this.buttonStartTaskTAP);
            this.Controls.Add(this.btnStartTaskNotAsync);
            this.Controls.Add(this.tbmSec);
            this.Controls.Add(this.tbChildrenTaskMax);
            this.Controls.Add(this.lblmSec);
            this.Controls.Add(this.lblChildrenTaskMax);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnStartTask);
            this.Controls.Add(this.btnCancelTaskWithChildren);
            this.Controls.Add(this.btnStartTaskWithChildren);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartTaskWithChildren;
        private System.Windows.Forms.Button btnCancelTaskWithChildren;
        private System.Windows.Forms.Button btnStartTask;
        private System.Windows.Forms.Button btnCancelTask;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblChildrenTaskMax;
        private System.Windows.Forms.Label lblmSec;
        private System.Windows.Forms.TextBox tbChildrenTaskMax;
        private System.Windows.Forms.TextBox tbmSec;
        private System.Windows.Forms.Button btnStartTaskNotAsync;
        private System.Windows.Forms.Button buttonStartTaskTAP;
    }
}

