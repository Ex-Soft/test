namespace TestReload
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
            this.pnlFill = new System.Windows.Forms.Panel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnEditItInGridSession = new System.Windows.Forms.Button();
            this.btnEditInAnotherSession = new System.Windows.Forms.Button();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gridControl);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(394, 211);
            this.pnlFill.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(394, 211);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnEditItInGridSession);
            this.pnlBottom.Controls.Add(this.btnEditInAnotherSession);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 211);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(394, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnEditItInGridSession
            // 
            this.btnEditItInGridSession.Location = new System.Drawing.Point(179, 15);
            this.btnEditItInGridSession.Name = "btnEditItInGridSession";
            this.btnEditItInGridSession.Size = new System.Drawing.Size(124, 23);
            this.btnEditItInGridSession.TabIndex = 1;
            this.btnEditItInGridSession.Text = "Edit in grid session";
            this.btnEditItInGridSession.UseVisualStyleBackColor = true;
            this.btnEditItInGridSession.Click += new System.EventHandler(this.BtnEditItInGridSessionClick);
            // 
            // btnEditInAnotherSession
            // 
            this.btnEditInAnotherSession.Location = new System.Drawing.Point(12, 15);
            this.btnEditInAnotherSession.Name = "btnEditInAnotherSession";
            this.btnEditInAnotherSession.Size = new System.Drawing.Size(145, 23);
            this.btnEditInAnotherSession.TabIndex = 0;
            this.btnEditInAnotherSession.Text = "Edit in another session";
            this.btnEditInAnotherSession.UseVisualStyleBackColor = true;
            this.btnEditInAnotherSession.Click += new System.EventHandler(this.BtnEditInAnotherSessionClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 261);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFill;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnEditInAnotherSession;
        private System.Windows.Forms.Button btnEditItInGridSession;
    }
}

