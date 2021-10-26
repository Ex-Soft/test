
namespace TestCountdownEventWinApp
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
            this.tpCommit = new System.Windows.Forms.TabPage();
            this.scCommit = new System.Windows.Forms.SplitContainer();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lbCommitLog = new System.Windows.Forms.ListBox();
            this.lblCommitBatchSize = new System.Windows.Forms.Label();
            this.tbCommitBatchSize = new System.Windows.Forms.TextBox();
            this.btnCommitCancel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpCommit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCommit)).BeginInit();
            this.scCommit.Panel1.SuspendLayout();
            this.scCommit.Panel2.SuspendLayout();
            this.scCommit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpCommit);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tpCommit
            // 
            this.tpCommit.Controls.Add(this.scCommit);
            this.tpCommit.Location = new System.Drawing.Point(4, 29);
            this.tpCommit.Name = "tpCommit";
            this.tpCommit.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommit.Size = new System.Drawing.Size(792, 417);
            this.tpCommit.TabIndex = 0;
            this.tpCommit.Text = "Commit";
            this.tpCommit.UseVisualStyleBackColor = true;
            // 
            // scCommit
            // 
            this.scCommit.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.scCommit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCommit.Location = new System.Drawing.Point(3, 3);
            this.scCommit.Name = "scCommit";
            this.scCommit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scCommit.Panel1
            // 
            this.scCommit.Panel1.Controls.Add(this.btnCommitCancel);
            this.scCommit.Panel1.Controls.Add(this.tbCommitBatchSize);
            this.scCommit.Panel1.Controls.Add(this.lblCommitBatchSize);
            this.scCommit.Panel1.Controls.Add(this.btnCommit);
            // 
            // scCommit.Panel2
            // 
            this.scCommit.Panel2.Controls.Add(this.lbCommitLog);
            this.scCommit.Size = new System.Drawing.Size(786, 411);
            this.scCommit.SplitterDistance = 90;
            this.scCommit.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(256, 33);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(94, 29);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.BtnCommitClick);
            // 
            // lbCommitLog
            // 
            this.lbCommitLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCommitLog.FormattingEnabled = true;
            this.lbCommitLog.ItemHeight = 20;
            this.lbCommitLog.Location = new System.Drawing.Point(0, 0);
            this.lbCommitLog.Name = "lbCommitLog";
            this.lbCommitLog.Size = new System.Drawing.Size(786, 317);
            this.lbCommitLog.TabIndex = 0;
            // 
            // lblCommitBatchSize
            // 
            this.lblCommitBatchSize.AutoSize = true;
            this.lblCommitBatchSize.Location = new System.Drawing.Point(26, 37);
            this.lblCommitBatchSize.Name = "lblCommitBatchSize";
            this.lblCommitBatchSize.Size = new System.Drawing.Size(78, 20);
            this.lblCommitBatchSize.TabIndex = 1;
            this.lblCommitBatchSize.Text = "Batch size:";
            // 
            // tbCommitBatchSize
            // 
            this.tbCommitBatchSize.Location = new System.Drawing.Point(110, 33);
            this.tbCommitBatchSize.Name = "tbCommitBatchSize";
            this.tbCommitBatchSize.Size = new System.Drawing.Size(100, 27);
            this.tbCommitBatchSize.TabIndex = 2;
            // 
            // btnCommitCancel
            // 
            this.btnCommitCancel.Location = new System.Drawing.Point(356, 31);
            this.btnCommitCancel.Name = "btnCommitCancel";
            this.btnCommitCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCommitCancel.TabIndex = 3;
            this.btnCommitCancel.Text = "Cancel";
            this.btnCommitCancel.UseVisualStyleBackColor = true;
            this.btnCommitCancel.Click += new System.EventHandler(this.BtnCancel);
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
            this.tpCommit.ResumeLayout(false);
            this.scCommit.Panel1.ResumeLayout(false);
            this.scCommit.Panel1.PerformLayout();
            this.scCommit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scCommit)).EndInit();
            this.scCommit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpCommit;
        private System.Windows.Forms.SplitContainer scCommit;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.ListBox lbCommitLog;
        private System.Windows.Forms.Button btnCommitCancel;
        private System.Windows.Forms.TextBox tbCommitBatchSize;
        private System.Windows.Forms.Label lblCommitBatchSize;
    }
}

