namespace TestUOWWinApp
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageAsync = new DevExpress.XtraTab.XtraTabPage();
            this.btnCommitTransactionAsync = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageSync = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabPageAsync.SuspendLayout();
            this.xtraTabPageSync.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 211);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(284, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.xtraTabControl);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(284, 211);
            this.pnlFill.TabIndex = 1;
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPageAsync;
            this.xtraTabControl.Size = new System.Drawing.Size(280, 207);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageAsync,
            this.xtraTabPageSync});
            // 
            // xtraTabPageAsync
            // 
            this.xtraTabPageAsync.Controls.Add(this.btnCommitTransactionAsync);
            this.xtraTabPageAsync.Name = "xtraTabPageAsync";
            this.xtraTabPageAsync.Size = new System.Drawing.Size(274, 179);
            this.xtraTabPageAsync.Text = "Async";
            // 
            // btnCommitTransactionAsync
            // 
            this.btnCommitTransactionAsync.AutoSize = true;
            this.btnCommitTransactionAsync.Location = new System.Drawing.Point(19, 19);
            this.btnCommitTransactionAsync.Name = "btnCommitTransactionAsync";
            this.btnCommitTransactionAsync.Size = new System.Drawing.Size(129, 22);
            this.btnCommitTransactionAsync.TabIndex = 0;
            this.btnCommitTransactionAsync.Text = "CommitTransactionAsync";
            this.btnCommitTransactionAsync.Click += new System.EventHandler(this.btnCommitTransactionAsync_Click);
            // 
            // xtraTabPageSync
            // 
            this.xtraTabPageSync.Controls.Add(this.simpleButton1);
            this.xtraTabPageSync.Name = "xtraTabPageSync";
            this.xtraTabPageSync.Size = new System.Drawing.Size(274, 179);
            this.xtraTabPageSync.Text = "Sync";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AutoSize = true;
            this.simpleButton1.Location = new System.Drawing.Point(19, 14);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 22);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "CommitTransaction";
            this.simpleButton1.Click += new System.EventHandler(this.btnCommitTransaction_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test XPO";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabPageAsync.ResumeLayout(false);
            this.xtraTabPageAsync.PerformLayout();
            this.xtraTabPageSync.ResumeLayout(false);
            this.xtraTabPageSync.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAsync;
        private DevExpress.XtraEditors.SimpleButton btnCommitTransactionAsync;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSync;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

