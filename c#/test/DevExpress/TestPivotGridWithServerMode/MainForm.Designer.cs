using DevExpress.XtraPivotGrid;

namespace TestPivotGridWithServerMode
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
            this.btnRefreshAsync = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefreshAsync);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 698);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1402, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnRefreshAsync
            // 
            this.btnRefreshAsync.Location = new System.Drawing.Point(118, 6);
            this.btnRefreshAsync.Name = "btnRefreshAsync";
            this.btnRefreshAsync.Size = new System.Drawing.Size(100, 23);
            this.btnRefreshAsync.TabIndex = 1;
            this.btnRefreshAsync.Tag = "async";
            this.btnRefreshAsync.Text = "RefreshAsync()";
            this.btnRefreshAsync.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh()";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.pivotGridControl);
            this.splitContainerControl.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.splitContainerControl.Panel2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.splitContainerControl.Size = new System.Drawing.Size(1402, 698);
            this.splitContainerControl.SplitterPosition = 294;
            this.splitContainerControl.TabIndex = 2;
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.OptionsCustomization.AllowCustomizationForm = false;
            this.pivotGridControl.OptionsCustomization.AllowFilterInCustomizationForm = true;
            this.pivotGridControl.OptionsCustomization.AllowSortInCustomizationForm = true;
            this.pivotGridControl.OptionsCustomization.CustomizationFormStyle = DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle.Excel2007;
            this.pivotGridControl.OptionsView.ColumnTotalsLocation = DevExpress.XtraPivotGrid.PivotTotalsLocation.Near;
            this.pivotGridControl.OptionsView.RowTotalsLocation = DevExpress.XtraPivotGrid.PivotRowTotalsLocation.Tree;
            this.pivotGridControl.OptionsView.RowTreeWidth = 300;
            //this.pivotGridControl.OptionsView.ShowColumnHeaders = false;
            //this.pivotGridControl.OptionsView.ShowDataHeaders = false;
            //this.pivotGridControl.OptionsView.ShowFilterHeaders = false;
            //this.pivotGridControl.OptionsView.ShowRowHeaders = false;
            this.pivotGridControl.Size = new System.Drawing.Size(1103, 698);
            this.pivotGridControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 733);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PivitGrid with ServerMode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRefreshAsync;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
    }
}

