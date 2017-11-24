namespace TestFilter
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
            this.checkEditHandler = new DevExpress.XtraEditors.CheckEdit();
            this.btnAddMaster = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCommon = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageCommon = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCommon = new DevExpress.XtraGrid.GridControl();
            this.gridViewCommon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPageMaster = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPageTreeList = new DevExpress.XtraTab.XtraTabPage();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.tabPageWithCustomFilter = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlWithCustomFilter = new DevExpress.XtraGrid.GridControl();
            this.gridViewWithCustomFilter = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHandler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommon)).BeginInit();
            this.tabPageMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            this.tabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            this.tabPageTreeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.tabPageWithCustomFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithCustomFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWithCustomFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.checkEditHandler);
            this.pnlBottom.Controls.Add(this.btnAddMaster);
            this.pnlBottom.Controls.Add(this.btnAddCommon);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 455);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(870, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // checkEditHandler
            // 
            this.checkEditHandler.Location = new System.Drawing.Point(335, 17);
            this.checkEditHandler.Name = "checkEditHandler";
            this.checkEditHandler.Properties.Caption = "Handler";
            this.checkEditHandler.Size = new System.Drawing.Size(75, 19);
            this.checkEditHandler.TabIndex = 2;
            this.checkEditHandler.CheckedChanged += new System.EventHandler(this.CheckEditHandlerCheckedChanged);
            // 
            // btnAddMaster
            // 
            this.btnAddMaster.Location = new System.Drawing.Point(168, 15);
            this.btnAddMaster.Name = "btnAddMaster";
            this.btnAddMaster.Size = new System.Drawing.Size(150, 23);
            this.btnAddMaster.TabIndex = 1;
            this.btnAddMaster.Tag = "Master";
            this.btnAddMaster.Text = "Add (Master)";
            this.btnAddMaster.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // btnAddCommon
            // 
            this.btnAddCommon.Location = new System.Drawing.Point(12, 15);
            this.btnAddCommon.Name = "btnAddCommon";
            this.btnAddCommon.Size = new System.Drawing.Size(150, 23);
            this.btnAddCommon.TabIndex = 0;
            this.btnAddCommon.Tag = "Common";
            this.btnAddCommon.Text = "Add (Common)";
            this.btnAddCommon.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabPageCommon;
            this.tabControl.Size = new System.Drawing.Size(870, 455);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageCommon,
            this.tabPageMaster,
            this.tabPageDetail,
            this.tabPageTreeList,
            this.tabPageWithCustomFilter});
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.gridControlCommon);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Size = new System.Drawing.Size(864, 427);
            this.tabPageCommon.Text = "Common";
            // 
            // gridControlCommon
            // 
            this.gridControlCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCommon.Location = new System.Drawing.Point(0, 0);
            this.gridControlCommon.MainView = this.gridViewCommon;
            this.gridControlCommon.Name = "gridControlCommon";
            this.gridControlCommon.Size = new System.Drawing.Size(864, 427);
            this.gridControlCommon.TabIndex = 0;
            this.gridControlCommon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCommon});
            // 
            // gridViewCommon
            // 
            this.gridViewCommon.GridControl = this.gridControlCommon;
            this.gridViewCommon.Name = "gridViewCommon";
            // 
            // tabPageMaster
            // 
            this.tabPageMaster.Controls.Add(this.gridControlMaster);
            this.tabPageMaster.Name = "tabPageMaster";
            this.tabPageMaster.Size = new System.Drawing.Size(864, 427);
            this.tabPageMaster.Text = "Master";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(864, 427);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.Name = "gridViewMaster";
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.gridControlDetail);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Size = new System.Drawing.Size(864, 427);
            this.tabPageDetail.Text = "Detail";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(864, 427);
            this.gridControlDetail.TabIndex = 0;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.GridControl = this.gridControlDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            // 
            // tabPageTreeList
            // 
            this.tabPageTreeList.Controls.Add(this.treeList);
            this.tabPageTreeList.Name = "tabPageTreeList";
            this.tabPageTreeList.Size = new System.Drawing.Size(864, 427);
            this.tabPageTreeList.Text = "TreeList";
            // 
            // treeList
            // 
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.ParentFieldName = "Parent!Key";
            this.treeList.Size = new System.Drawing.Size(864, 427);
            this.treeList.TabIndex = 0;
            // 
            // tabPageWithCustomFilter
            // 
            this.tabPageWithCustomFilter.Controls.Add(this.gridControlWithCustomFilter);
            this.tabPageWithCustomFilter.Name = "tabPageWithCustomFilter";
            this.tabPageWithCustomFilter.Size = new System.Drawing.Size(864, 427);
            this.tabPageWithCustomFilter.Text = "CustomFilter";
            // 
            // gridControlWithCustomFilter
            // 
            this.gridControlWithCustomFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWithCustomFilter.Location = new System.Drawing.Point(0, 0);
            this.gridControlWithCustomFilter.MainView = this.gridViewWithCustomFilter;
            this.gridControlWithCustomFilter.Name = "gridControlWithCustomFilter";
            this.gridControlWithCustomFilter.Size = new System.Drawing.Size(864, 427);
            this.gridControlWithCustomFilter.TabIndex = 1;
            this.gridControlWithCustomFilter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWithCustomFilter});
            // 
            // gridViewWithCustomFilter
            // 
            this.gridViewWithCustomFilter.GridControl = this.gridControlWithCustomFilter;
            this.gridViewWithCustomFilter.Name = "gridViewWithCustomFilter";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 505);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Filter";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHandler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCommon)).EndInit();
            this.tabPageMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            this.tabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            this.tabPageTreeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.tabPageWithCustomFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithCustomFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWithCustomFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabPageCommon;
        private DevExpress.XtraTab.XtraTabPage tabPageMaster;
        private DevExpress.XtraTab.XtraTabPage tabPageDetail;
        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        private DevExpress.XtraGrid.GridControl gridControlCommon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCommon;
        private DevExpress.XtraEditors.SimpleButton btnAddCommon;
        private DevExpress.XtraEditors.SimpleButton btnAddMaster;
        private DevExpress.XtraTab.XtraTabPage tabPageTreeList;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraEditors.CheckEdit checkEditHandler;
        private DevExpress.XtraTab.XtraTabPage tabPageWithCustomFilter;
        private DevExpress.XtraGrid.GridControl gridControlWithCustomFilter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWithCustomFilter;
    }
}

