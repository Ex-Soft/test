namespace TestTreeList
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
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaterializedPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelected = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xpCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.session = new DevExpress.Xpo.Session(this.components);
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnGetSelected = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colParentId,
            this.colVal,
            this.colMaterializedPath,
            this.colSelected});
            this.treeList.DataSource = this.xpCollection;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.KeyFieldName = "Id";
            this.treeList.Location = new System.Drawing.Point(2, 2);
            this.treeList.Name = "treeList";
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.ParentFieldName = "Parent!Key";
            this.treeList.Size = new System.Drawing.Size(380, 322);
            this.treeList.TabIndex = 0;
            this.treeList.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.TreeListCustomNodeCellEdit);
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeListFocusedNodeChanged);
            this.treeList.SelectionChanged += new System.EventHandler(this.TreeListSelectionChanged);
            this.treeList.CustomDrawColumnHeader += new DevExpress.XtraTreeList.CustomDrawColumnHeaderEventHandler(this.TreeListCustomDrawColumnHeader);
            this.treeList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeListMouseUp);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Width = 50;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.OptionsColumn.AllowEdit = false;
            this.colParentId.Width = 50;
            // 
            // colVal
            // 
            this.colVal.FieldName = "Val";
            this.colVal.MinWidth = 32;
            this.colVal.Name = "colVal";
            this.colVal.OptionsColumn.AllowEdit = false;
            this.colVal.Visible = true;
            this.colVal.VisibleIndex = 0;
            this.colVal.Width = 50;
            // 
            // colMaterializedPath
            // 
            this.colMaterializedPath.FieldName = "MaterializedPath";
            this.colMaterializedPath.Name = "colMaterializedPath";
            this.colMaterializedPath.OptionsColumn.AllowEdit = false;
            this.colMaterializedPath.Visible = true;
            this.colMaterializedPath.VisibleIndex = 1;
            this.colMaterializedPath.Width = 100;
            // 
            // colSelected
            // 
            this.colSelected.Caption = "Caption of column \"Selected\"";
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.OptionsColumn.AllowSort = false;
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 2;
            this.colSelected.Width = 50;
            // 
            // xpCollection
            // 
            this.xpCollection.ObjectType = typeof(TestDB.TableWithHierarchy);
            this.xpCollection.Session = this.session;
            // 
            // session
            // 
            this.session.ConnectionString = "XpoProvider=MSSqlServer;Server=.;Database=testdb;User ID=sa;Password=123;Persist " +
    "Security Info=true";
            this.session.IsObjectModifiedOnNonPersistentPropertyChange = null;
            this.session.TrackPropertiesModifications = false;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.treeList);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(384, 326);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnGetSelected);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 326);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(384, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnGetSelected
            // 
            this.btnGetSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSelected.Location = new System.Drawing.Point(298, 6);
            this.btnGetSelected.Name = "btnGetSelected";
            this.btnGetSelected.Size = new System.Drawing.Size(75, 23);
            this.btnGetSelected.TabIndex = 0;
            this.btnGetSelected.Text = "GetSelected";
            this.btnGetSelected.Click += new System.EventHandler(this.BtnGetSelectedClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreeList";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.Xpo.XPCollection xpCollection;
        private DevExpress.Xpo.Session session;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVal;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaterializedPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelected;
        private DevExpress.XtraEditors.SimpleButton btnGetSelected;
    }
}

