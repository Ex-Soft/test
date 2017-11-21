namespace GridWithEditors
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
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageCommon = new DevExpress.XtraTab.XtraTabPage();
            this.tabPageMasterDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlMasterDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewMasterDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageMasterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasterDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasterDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 334);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(594, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabPageCommon;
            this.tabControl.Size = new System.Drawing.Size(594, 334);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageCommon,
            this.tabPageMasterDetail});
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.gridControl);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Size = new System.Drawing.Size(588, 306);
            this.tabPageCommon.Text = "Common";
            // 
            // tabPageMasterDetail
            // 
            this.tabPageMasterDetail.Controls.Add(this.gridControlMasterDetail);
            this.tabPageMasterDetail.Name = "tabPageMasterDetail";
            this.tabPageMasterDetail.Size = new System.Drawing.Size(588, 306);
            this.tabPageMasterDetail.Text = "MasterDetail";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(588, 306);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // gridControlMasterDetail
            // 
            this.gridControlMasterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMasterDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlMasterDetail.MainView = this.gridViewMasterDetail;
            this.gridControlMasterDetail.Name = "gridControlMasterDetail";
            this.gridControlMasterDetail.Size = new System.Drawing.Size(588, 306);
            this.gridControlMasterDetail.TabIndex = 0;
            this.gridControlMasterDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMasterDetail});
            // 
            // gridViewMasterDetail
            // 
            this.gridViewMasterDetail.GridControl = this.gridControlMasterDetail;
            this.gridViewMasterDetail.Name = "gridViewMasterDetail";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 384);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid with Editors";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageMasterDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasterDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasterDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageCommon;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraTab.XtraTabPage tabPageMasterDetail;
        private DevExpress.XtraGrid.GridControl gridControlMasterDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasterDetail;
    }
}

