namespace TestLayout
{
    partial class MainFormEditWSplitControl2
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
            this.mainLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.Location = new System.Drawing.Point(184, 102);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(423, 356, 450, 400);
            this.mainLayout.Root = this.layoutControlGroupRoot;
            this.mainLayout.Size = new System.Drawing.Size(180, 120);
            this.mainLayout.TabIndex = 4;
            this.mainLayout.Text = "mainLayout";
            // 
            // layoutControlGroupRoot
            // 
            this.layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupRoot.GroupBordersVisible = false;
            this.layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.splitterItem1,
            this.simpleLabelItem1,
            this.simpleLabelItem2});
            this.layoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupRoot.Name = "Root";
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(180, 120);
            this.layoutControlGroupRoot.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(69, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 100);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHide = false;
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.CustomizationFormText = "First Item";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.MinSize = new System.Drawing.Size(65, 21);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(69, 100);
            this.simpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem1.Text = "First Item";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(60, 13);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.CustomizationFormText = "Second Item";
            this.simpleLabelItem2.Location = new System.Drawing.Point(74, 0);
            this.simpleLabelItem2.MinSize = new System.Drawing.Size(86, 17);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(86, 100);
            this.simpleLabelItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem2.Text = "Second Item";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(60, 13);
            // 
            // MainFormEditWSplitControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.mainLayout);
            this.MinimumSize = new System.Drawing.Size(306, 307);
            this.Name = "MainFormEditWSplitControl2";
            this.Text = "MainFormEditWSplitControl2";
            this.Controls.SetChildIndex(this.mainLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mainLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl mainLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
    }
}