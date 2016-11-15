namespace TestDataTable
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
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageStaff = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlStaff = new DevExpress.XtraGrid.GridControl();
            this.gridViewStaff = new TestDataTable.CustomGridView();
            this.xtraTabPageMasterDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMasterDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewMasterDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageADOdotNETDataTable = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlADOdotNETDataTable = new DevExpress.XtraGrid.GridControl();
            this.gridViewADOdotNETDataTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageTestTable4Types = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlTestTable4Types = new DevExpress.XtraGrid.GridControl();
            this.gridViewTestTable4Types = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabPageStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStaff)).BeginInit();
            this.xtraTabPageMasterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasterDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasterDetail)).BeginInit();
            this.xtraTabPageADOdotNETDataTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlADOdotNETDataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewADOdotNETDataTable)).BeginInit();
            this.xtraTabPageTestTable4Types.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTestTable4Types)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTestTable4Types)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPageStaff;
            this.xtraTabControl.Size = new System.Drawing.Size(541, 261);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageStaff,
            this.xtraTabPageMasterDetail,
            this.xtraTabPageADOdotNETDataTable,
            this.xtraTabPageTestTable4Types});
            // 
            // xtraTabPageStaff
            // 
            this.xtraTabPageStaff.Controls.Add(this.gridControlStaff);
            this.xtraTabPageStaff.Name = "xtraTabPageStaff";
            this.xtraTabPageStaff.Size = new System.Drawing.Size(535, 233);
            this.xtraTabPageStaff.Text = "Staff";
            // 
            // gridControlStaff
            // 
            this.gridControlStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStaff.Location = new System.Drawing.Point(0, 0);
            this.gridControlStaff.MainView = this.gridViewStaff;
            this.gridControlStaff.Name = "gridControlStaff";
            this.gridControlStaff.Size = new System.Drawing.Size(535, 233);
            this.gridControlStaff.TabIndex = 0;
            this.gridControlStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStaff});
            // 
            // gridViewStaff
            // 
            this.gridViewStaff.GridControl = this.gridControlStaff;
            this.gridViewStaff.Name = "gridViewStaff";
            // 
            // xtraTabPageMasterDetail
            // 
            this.xtraTabPageMasterDetail.Controls.Add(this.gridControlMasterDetail);
            this.xtraTabPageMasterDetail.Name = "xtraTabPageMasterDetail";
            this.xtraTabPageMasterDetail.Size = new System.Drawing.Size(278, 233);
            this.xtraTabPageMasterDetail.Text = "MasterDetail";
            // 
            // gridControlMasterDetail
            // 
            this.gridControlMasterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMasterDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlMasterDetail.MainView = this.gridViewMasterDetail;
            this.gridControlMasterDetail.Name = "gridControlMasterDetail";
            this.gridControlMasterDetail.Size = new System.Drawing.Size(278, 233);
            this.gridControlMasterDetail.TabIndex = 0;
            this.gridControlMasterDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMasterDetail});
            // 
            // gridViewMasterDetail
            // 
            this.gridViewMasterDetail.GridControl = this.gridControlMasterDetail;
            this.gridViewMasterDetail.Name = "gridViewMasterDetail";
            // 
            // xtraTabPageADOdotNETDataTable
            // 
            this.xtraTabPageADOdotNETDataTable.Controls.Add(this.gridControlADOdotNETDataTable);
            this.xtraTabPageADOdotNETDataTable.Name = "xtraTabPageADOdotNETDataTable";
            this.xtraTabPageADOdotNETDataTable.Size = new System.Drawing.Size(278, 233);
            this.xtraTabPageADOdotNETDataTable.Text = "ADO.NET DataTable";
            // 
            // gridControlADOdotNETDataTable
            // 
            this.gridControlADOdotNETDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlADOdotNETDataTable.Location = new System.Drawing.Point(0, 0);
            this.gridControlADOdotNETDataTable.MainView = this.gridViewADOdotNETDataTable;
            this.gridControlADOdotNETDataTable.Name = "gridControlADOdotNETDataTable";
            this.gridControlADOdotNETDataTable.Size = new System.Drawing.Size(278, 233);
            this.gridControlADOdotNETDataTable.TabIndex = 0;
            this.gridControlADOdotNETDataTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewADOdotNETDataTable});
            // 
            // gridViewADOdotNETDataTable
            // 
            this.gridViewADOdotNETDataTable.GridControl = this.gridControlADOdotNETDataTable;
            this.gridViewADOdotNETDataTable.Name = "gridViewADOdotNETDataTable";
            this.gridViewADOdotNETDataTable.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewADOdotNETDataTable_RowStyle);
            // 
            // xtraTabPageTestTable4Types
            // 
            this.xtraTabPageTestTable4Types.Controls.Add(this.gridControlTestTable4Types);
            this.xtraTabPageTestTable4Types.Name = "xtraTabPageTestTable4Types";
            this.xtraTabPageTestTable4Types.Size = new System.Drawing.Size(535, 233);
            this.xtraTabPageTestTable4Types.Text = "TestTable4Types";
            // 
            // gridControlTestTable4Types
            // 
            this.gridControlTestTable4Types.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTestTable4Types.Location = new System.Drawing.Point(0, 0);
            this.gridControlTestTable4Types.MainView = this.gridViewTestTable4Types;
            this.gridControlTestTable4Types.Name = "gridControlTestTable4Types";
            this.gridControlTestTable4Types.Size = new System.Drawing.Size(535, 233);
            this.gridControlTestTable4Types.TabIndex = 0;
            this.gridControlTestTable4Types.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTestTable4Types});
            // 
            // gridViewTestTable4Types
            // 
            this.gridViewTestTable4Types.GridControl = this.gridControlTestTable4Types;
            this.gridViewTestTable4Types.Name = "gridViewTestTable4Types";
            this.gridViewTestTable4Types.CellValueChanged += GridViewTestTable4TypesCellValueChanged;
            this.gridViewTestTable4Types.CustomRowCellEdit += GridViewTestTable4TypesCustomRowCellEdit;
            this.gridViewTestTable4Types.CustomRowCellEditForEditing += GridViewTestTable4TypesCustomRowCellEditForEditing;
            this.gridViewTestTable4Types.HiddenEditor += GridViewTestTable4TypesHiddenEditor;
            this.gridViewTestTable4Types.ShownEditor += GridViewTestTable4TypesShownEditor;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.xtraTabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabPageStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStaff)).EndInit();
            this.xtraTabPageMasterDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMasterDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasterDetail)).EndInit();
            this.xtraTabPageADOdotNETDataTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlADOdotNETDataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewADOdotNETDataTable)).EndInit();
            this.xtraTabPageTestTable4Types.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTestTable4Types)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTestTable4Types)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageStaff;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMasterDetail;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageADOdotNETDataTable;
        private DevExpress.XtraGrid.GridControl gridControlStaff;
        //private DevExpress.XtraGrid.Views.Grid.GridView gridViewStaff;
        private CustomGridView gridViewStaff;
        private DevExpress.XtraGrid.GridControl gridControlMasterDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasterDetail;
        private DevExpress.XtraGrid.GridControl gridControlADOdotNETDataTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewADOdotNETDataTable;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTestTable4Types;
        private DevExpress.XtraGrid.GridControl gridControlTestTable4Types;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTestTable4Types;
    }
}

