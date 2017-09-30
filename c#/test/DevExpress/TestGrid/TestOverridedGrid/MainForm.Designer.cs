namespace TestOverridedGrid
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlFill1 = new System.Windows.Forms.Panel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new TestOverridedGrid.OverridedGridView();
            this.pnlBottom1 = new System.Windows.Forms.Panel();
            this.btnRefreshDataSource = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshData = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnModifyData = new DevExpress.XtraEditors.SimpleButton();
            this.tabPageWithFilter = new System.Windows.Forms.TabPage();
            this.pnlFill2 = new System.Windows.Forms.Panel();
            this.gridControlWithFilter = new DevExpress.XtraGrid.GridControl();
            this.customGridViewWithFilter = new TestOverridedGrid.CustomGridViewWithFilter();
            this.pnlBottom2 = new System.Windows.Forms.Panel();
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount = new DevExpress.XtraEditors.SimpleButton();
            this.textEditColumnFilterPopupMaxRecordsCount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabPageWithValidation = new System.Windows.Forms.TabPage();
            this.pnlFill3 = new System.Windows.Forms.Panel();
            this.gridControlWithValidation = new DevExpress.XtraGrid.GridControl();
            this.customGridViewWithValidation = new TestOverridedGrid.CustomGridViewWithValidation();
            this.pnlBottom3 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlFill1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlBottom1.SuspendLayout();
            this.tabPageWithFilter.SuspendLayout();
            this.pnlFill2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewWithFilter)).BeginInit();
            this.pnlBottom2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditColumnFilterPopupMaxRecordsCount.Properties)).BeginInit();
            this.tabPageWithValidation.SuspendLayout();
            this.pnlFill3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewWithValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPageWithFilter);
            this.tabControl.Controls.Add(this.tabPageWithValidation);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(673, 422);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlFill1);
            this.tabPage1.Controls.Add(this.pnlBottom1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(665, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlFill1
            // 
            this.pnlFill1.Controls.Add(this.gridControl);
            this.pnlFill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill1.Location = new System.Drawing.Point(3, 3);
            this.pnlFill1.Name = "pnlFill1";
            this.pnlFill1.Size = new System.Drawing.Size(659, 340);
            this.pnlFill1.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(659, 340);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // pnlBottom1
            // 
            this.pnlBottom1.Controls.Add(this.btnRefreshDataSource);
            this.pnlBottom1.Controls.Add(this.btnRefresh);
            this.pnlBottom1.Controls.Add(this.btnRefreshData);
            this.pnlBottom1.Controls.Add(this.btnReload);
            this.pnlBottom1.Controls.Add(this.btnModifyData);
            this.pnlBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom1.Location = new System.Drawing.Point(3, 343);
            this.pnlBottom1.Name = "pnlBottom1";
            this.pnlBottom1.Size = new System.Drawing.Size(659, 50);
            this.pnlBottom1.TabIndex = 1;
            // 
            // btnRefreshDataSource
            // 
            this.btnRefreshDataSource.Location = new System.Drawing.Point(97, 14);
            this.btnRefreshDataSource.Name = "btnRefreshDataSource";
            this.btnRefreshDataSource.Size = new System.Drawing.Size(125, 23);
            this.btnRefreshDataSource.TabIndex = 9;
            this.btnRefreshDataSource.Text = "RefreshDataSource";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(232, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(317, 14);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshData.TabIndex = 7;
            this.btnRefreshData.Text = "RefreshData";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(402, 14);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload";
            // 
            // btnModifyData
            // 
            this.btnModifyData.Location = new System.Drawing.Point(487, 14);
            this.btnModifyData.Name = "btnModifyData";
            this.btnModifyData.Size = new System.Drawing.Size(75, 23);
            this.btnModifyData.TabIndex = 5;
            this.btnModifyData.Text = "Modify";
            // 
            // tabPageWithFilter
            // 
            this.tabPageWithFilter.Controls.Add(this.pnlFill2);
            this.tabPageWithFilter.Controls.Add(this.pnlBottom2);
            this.tabPageWithFilter.Location = new System.Drawing.Point(4, 22);
            this.tabPageWithFilter.Name = "tabPageWithFilter";
            this.tabPageWithFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWithFilter.Size = new System.Drawing.Size(665, 396);
            this.tabPageWithFilter.TabIndex = 1;
            this.tabPageWithFilter.Text = "Filter";
            this.tabPageWithFilter.UseVisualStyleBackColor = true;
            // 
            // pnlFill2
            // 
            this.pnlFill2.Controls.Add(this.gridControlWithFilter);
            this.pnlFill2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill2.Location = new System.Drawing.Point(3, 3);
            this.pnlFill2.Name = "pnlFill2";
            this.pnlFill2.Size = new System.Drawing.Size(659, 340);
            this.pnlFill2.TabIndex = 0;
            // 
            // gridControlWithFilter
            // 
            this.gridControlWithFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWithFilter.Location = new System.Drawing.Point(0, 0);
            this.gridControlWithFilter.MainView = this.customGridViewWithFilter;
            this.gridControlWithFilter.Name = "gridControlWithFilter";
            this.gridControlWithFilter.Size = new System.Drawing.Size(659, 340);
            this.gridControlWithFilter.TabIndex = 2;
            this.gridControlWithFilter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridViewWithFilter});
            // 
            // customGridViewWithFilter
            // 
            this.customGridViewWithFilter.GridControl = this.gridControlWithFilter;
            this.customGridViewWithFilter.Name = "customGridViewWithFilter";
            // 
            // pnlBottom2
            // 
            this.pnlBottom2.Controls.Add(this.simpleButtonSetColumnFilterPopupMaxRecordsCount);
            this.pnlBottom2.Controls.Add(this.textEditColumnFilterPopupMaxRecordsCount);
            this.pnlBottom2.Controls.Add(this.labelControl1);
            this.pnlBottom2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom2.Location = new System.Drawing.Point(3, 343);
            this.pnlBottom2.Name = "pnlBottom2";
            this.pnlBottom2.Size = new System.Drawing.Size(659, 50);
            this.pnlBottom2.TabIndex = 1;
            // 
            // simpleButtonSetColumnFilterPopupMaxRecordsCount
            // 
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.Location = new System.Drawing.Point(320, 14);
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.Name = "simpleButtonSetColumnFilterPopupMaxRecordsCount";
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.TabIndex = 2;
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.Text = "Set";
            this.simpleButtonSetColumnFilterPopupMaxRecordsCount.Click += new System.EventHandler(this.SimpleButtonSetColumnFilterPopupMaxRecordsCountClick);
            // 
            // textEditColumnFilterPopupMaxRecordsCount
            // 
            this.textEditColumnFilterPopupMaxRecordsCount.EditValue = "-1";
            this.textEditColumnFilterPopupMaxRecordsCount.Location = new System.Drawing.Point(200, 15);
            this.textEditColumnFilterPopupMaxRecordsCount.Name = "textEditColumnFilterPopupMaxRecordsCount";
            this.textEditColumnFilterPopupMaxRecordsCount.Size = new System.Drawing.Size(100, 20);
            this.textEditColumnFilterPopupMaxRecordsCount.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(177, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ColumnFilterPopupMaxRecordsCount";
            // 
            // tabPageWithValidation
            // 
            this.tabPageWithValidation.Controls.Add(this.pnlFill3);
            this.tabPageWithValidation.Controls.Add(this.pnlBottom3);
            this.tabPageWithValidation.Location = new System.Drawing.Point(4, 22);
            this.tabPageWithValidation.Name = "tabPageWithValidation";
            this.tabPageWithValidation.Size = new System.Drawing.Size(665, 396);
            this.tabPageWithValidation.TabIndex = 2;
            this.tabPageWithValidation.Text = "Validation";
            this.tabPageWithValidation.UseVisualStyleBackColor = true;
            // 
            // pnlFill3
            // 
            this.pnlFill3.Controls.Add(this.gridControlWithValidation);
            this.pnlFill3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill3.Location = new System.Drawing.Point(0, 0);
            this.pnlFill3.Name = "pnlFill3";
            this.pnlFill3.Size = new System.Drawing.Size(665, 346);
            this.pnlFill3.TabIndex = 0;
            // 
            // gridControlWithValidation
            // 
            this.gridControlWithValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlWithValidation.Location = new System.Drawing.Point(0, 0);
            this.gridControlWithValidation.MainView = this.customGridViewWithValidation;
            this.gridControlWithValidation.Name = "gridControlWithValidation";
            this.gridControlWithValidation.Size = new System.Drawing.Size(665, 346);
            this.gridControlWithValidation.TabIndex = 2;
            this.gridControlWithValidation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.customGridViewWithValidation});
            // 
            // customGridViewWithValidation
            // 
            this.customGridViewWithValidation.GridControl = this.gridControlWithValidation;
            this.customGridViewWithValidation.Name = "customGridViewWithValidation";
            // 
            // pnlBottom3
            // 
            this.pnlBottom3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom3.Location = new System.Drawing.Point(0, 346);
            this.pnlBottom3.Name = "pnlBottom3";
            this.pnlBottom3.Size = new System.Drawing.Size(665, 50);
            this.pnlBottom3.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 422);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Overrided Grid";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlFill1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlBottom1.ResumeLayout(false);
            this.tabPageWithFilter.ResumeLayout(false);
            this.pnlFill2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewWithFilter)).EndInit();
            this.pnlBottom2.ResumeLayout(false);
            this.pnlBottom2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditColumnFilterPopupMaxRecordsCount.Properties)).EndInit();
            this.tabPageWithValidation.ResumeLayout(false);
            this.pnlFill3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlWithValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customGridViewWithValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlFill1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private OverridedGridView gridView;
        private System.Windows.Forms.Panel pnlBottom1;
        private DevExpress.XtraEditors.SimpleButton btnRefreshDataSource;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRefreshData;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnModifyData;
        private System.Windows.Forms.TabPage tabPageWithFilter;
        private System.Windows.Forms.Panel pnlFill2;
        private DevExpress.XtraGrid.GridControl gridControlWithFilter;
        private CustomGridViewWithFilter customGridViewWithFilter;
        private System.Windows.Forms.Panel pnlBottom2;
        private System.Windows.Forms.TabPage tabPageWithValidation;
        private System.Windows.Forms.Panel pnlFill3;
        private DevExpress.XtraGrid.GridControl gridControlWithValidation;
        private CustomGridViewWithValidation customGridViewWithValidation;
        private System.Windows.Forms.Panel pnlBottom3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSetColumnFilterPopupMaxRecordsCount;
        private DevExpress.XtraEditors.TextEdit textEditColumnFilterPopupMaxRecordsCount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

