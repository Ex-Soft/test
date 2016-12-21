namespace TestCustomRepositoryItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageEdit = new DevExpress.XtraTab.XtraTabPage();
            this.customIconTextEdit1 = new TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.customIconTextEdit2 = new TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit();
            this.customIconTextEdit3 = new TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit();
            this.buttonEdit2 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.xtraTabPageGrid = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.xtraTabPageEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.xtraTabPageGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.xtraTabControl);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(594, 334);
            this.pnlFill.TabIndex = 0;
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPageEdit;
            this.xtraTabControl.Size = new System.Drawing.Size(590, 330);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageEdit,
            this.xtraTabPageGrid});
            // 
            // xtraTabPageEdit
            // 
            this.xtraTabPageEdit.Controls.Add(this.customIconTextEdit1);
            this.xtraTabPageEdit.Controls.Add(this.customIconTextEdit2);
            this.xtraTabPageEdit.Controls.Add(this.customIconTextEdit3);
            this.xtraTabPageEdit.Controls.Add(this.buttonEdit2);
            this.xtraTabPageEdit.Controls.Add(this.buttonEdit1);
            this.xtraTabPageEdit.Name = "xtraTabPageEdit";
            this.xtraTabPageEdit.Size = new System.Drawing.Size(584, 302);
            this.xtraTabPageEdit.Text = "Edit";
            // 
            // customIconTextEdit1
            // 
            this.customIconTextEdit1.EditValue = "First";
            this.customIconTextEdit1.Location = new System.Drawing.Point(130, 43);
            this.customIconTextEdit1.Name = "customIconTextEdit1";
            this.customIconTextEdit1.Properties.ImageIndex = 1;
            this.customIconTextEdit1.Properties.ImageList = this.imageCollection1;
            this.customIconTextEdit1.Properties.OnIconSelection += new TestCustomRepositoryItem.CustomIconTextEdit.OnIconSelectionEventHandler(this.customIconTextEdit1_Properties_OnIconSelection);
            this.customIconTextEdit1.Size = new System.Drawing.Size(100, 38);
            this.customIconTextEdit1.TabIndex = 3;
            this.customIconTextEdit1.IconClick += new TestCustomRepositoryItem.CustomIconTextEdit.IconClickEventHandler(this.customIconTextEdit1_IconClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageCollection1.Images.SetKeyName(0, "arrowleft_green_32_h.bmp");
            this.imageCollection1.Images.SetKeyName(1, "arrowleft_green_32_d.bmp");
            this.imageCollection1.Images.SetKeyName(2, "delete_x_32.bmp");
            // 
            // customIconTextEdit2
            // 
            this.customIconTextEdit2.EditValue = "Second";
            this.customIconTextEdit2.Location = new System.Drawing.Point(130, 100);
            this.customIconTextEdit2.Name = "customIconTextEdit2";
            this.customIconTextEdit2.Properties.ImageIndex = 1;
            this.customIconTextEdit2.Properties.ImageList = this.imageCollection1;
            this.customIconTextEdit2.Properties.OnIconSelection += new TestCustomRepositoryItem.CustomIconTextEdit.OnIconSelectionEventHandler(this.customIconTextEdit1_Properties_OnIconSelection);
            this.customIconTextEdit2.Size = new System.Drawing.Size(100, 38);
            this.customIconTextEdit2.TabIndex = 0;
            this.customIconTextEdit2.IconClick += new TestCustomRepositoryItem.CustomIconTextEdit.IconClickEventHandler(this.customIconTextEdit1_IconClick);
            // 
            // customIconTextEdit3
            // 
            this.customIconTextEdit3.EditValue = "Disabled";
            this.customIconTextEdit3.Enabled = false;
            this.customIconTextEdit3.Location = new System.Drawing.Point(130, 178);
            this.customIconTextEdit3.Name = "customIconTextEdit3";
            this.customIconTextEdit3.Properties.ImageIndex = 1;
            this.customIconTextEdit3.Properties.ImageList = this.imageCollection1;
            this.customIconTextEdit3.Properties.OnIconSelection += new TestCustomRepositoryItem.CustomIconTextEdit.OnIconSelectionEventHandler(this.customIconTextEdit1_Properties_OnIconSelection);
            this.customIconTextEdit3.Size = new System.Drawing.Size(100, 38);
            this.customIconTextEdit3.TabIndex = 0;
            this.customIconTextEdit3.IconClick += new TestCustomRepositoryItem.CustomIconTextEdit.IconClickEventHandler(this.customIconTextEdit1_IconClick);
            // 
            // buttonEdit2
            // 
            this.buttonEdit2.Location = new System.Drawing.Point(10, 71);
            this.buttonEdit2.Name = "buttonEdit2";
            this.buttonEdit2.Properties.Appearance.Options.UseTextOptions = true;
            this.buttonEdit2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonEdit2.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.buttonEdit2.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit2.Properties.ReadOnly = true;
            this.buttonEdit2.Size = new System.Drawing.Size(100, 20);
            this.buttonEdit2.TabIndex = 2;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(10, 42);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Appearance.Image = global::TestCustomRepositoryItem.Properties.Resources.image_16x16;
            this.buttonEdit1.Properties.Appearance.Options.UseImage = true;
            serializableAppearanceObject1.Image = global::TestCustomRepositoryItem.Properties.Resources.image_16x16;
            serializableAppearanceObject1.Options.UseImage = true;
            serializableAppearanceObject2.Image = global::TestCustomRepositoryItem.Properties.Resources.image_16x16;
            serializableAppearanceObject2.Options.UseImage = true;
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TestCustomRepositoryItem.Properties.Resources.image_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TestCustomRepositoryItem.Properties.Resources.image_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.buttonEdit1.Size = new System.Drawing.Size(100, 22);
            this.buttonEdit1.TabIndex = 1;
            // 
            // xtraTabPageGrid
            // 
            this.xtraTabPageGrid.Controls.Add(this.gridControl);
            this.xtraTabPageGrid.Name = "xtraTabPageGrid";
            this.xtraTabPageGrid.Size = new System.Drawing.Size(584, 302);
            this.xtraTabPageGrid.Text = "Grid";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(584, 302);
            this.gridControl.TabIndex = 1;
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
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 334);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(594, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 384);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Repository Item";
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.xtraTabPageEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customIconTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.xtraTabPageGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageEdit;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageGrid;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private TestCustomRepositoryItem.CustomButtonEdit.CustomButtonEdit customButtonEdit1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit2;
        private TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit customIconTextEdit1;
        private TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit customIconTextEdit2;
        private TestCustomRepositoryItem.CustomIconTextEdit.CustomIconTextEdit customIconTextEdit3;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}

