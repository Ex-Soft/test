namespace TestPivotGrid
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
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sqlDataSource = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldProductName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldStoreName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnAllowDrag = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlDataSource
            // 
            this.sqlDataSource.ConnectionName = "testdb";
            this.sqlDataSource.Name = "sqlDataSource";
            customSqlQuery1.Name = "CustomSqlQuery";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource.ResultSchemaSerializable = resources.GetString("sqlDataSource.ResultSchemaSerializable");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAllowDrag);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 486);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1089, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel2.Controls.Add(this.pivotGridControl);
            this.splitContainerControl.Size = new System.Drawing.Size(1089, 486);
            this.splitContainerControl.SplitterPosition = 300;
            this.splitContainerControl.TabIndex = 1;
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.ActiveFilterString = "";
            this.pivotGridControl.DataMember = "CustomSqlQuery";
            this.pivotGridControl.DataSource = this.sqlDataSource;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldProductName,
            this.fieldStoreName,
            this.fieldCount});
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.OptionsCustomization.AllowCustomizationForm = false;
            this.pivotGridControl.OptionsCustomization.AllowFilterInCustomizationForm = true;
            this.pivotGridControl.OptionsCustomization.AllowSortInCustomizationForm = true;
            this.pivotGridControl.OptionsCustomization.CustomizationFormStyle = DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle.Excel2007;
            this.pivotGridControl.Size = new System.Drawing.Size(784, 486);
            this.pivotGridControl.TabIndex = 2;
            // 
            // fieldProductName
            // 
            this.fieldProductName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea) 
            | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.fieldProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldProductName.AreaIndex = 0;
            this.fieldProductName.Caption = "Product  Name";
            this.fieldProductName.FieldName = "ProductName";
            this.fieldProductName.Name = "fieldProductName";
            // 
            // fieldStoreName
            // 
            this.fieldStoreName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea) 
            | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.fieldStoreName.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldStoreName.AreaIndex = 0;
            this.fieldStoreName.Caption = "Store Name";
            this.fieldStoreName.FieldName = "StoreName";
            this.fieldStoreName.Name = "fieldStoreName";
            // 
            // fieldCount
            // 
            this.fieldCount.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.fieldCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCount.AreaIndex = 0;
            this.fieldCount.Caption = "Count";
            this.fieldCount.FieldName = "Count";
            this.fieldCount.Name = "fieldCount";
            // 
            // btnAllowDrag
            // 
            this.btnAllowDrag.Location = new System.Drawing.Point(24, 15);
            this.btnAllowDrag.Name = "btnAllowDrag";
            this.btnAllowDrag.Size = new System.Drawing.Size(75, 23);
            this.btnAllowDrag.TabIndex = 0;
            this.btnAllowDrag.Text = "AllowDrag";
            this.btnAllowDrag.Click += new System.EventHandler(this.BtnAllowDragClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 536);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test PivotGrid";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        private DevExpress.XtraPivotGrid.PivotGridField fieldProductName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldStoreName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCount;
        private DevExpress.XtraEditors.SimpleButton btnAllowDrag;
    }
}

