namespace TestLayout
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
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelRight = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelRight_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelLeft = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelLeft_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerTop = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelTop = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelTop_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelBottom = new DevExpress.XtraBars.Docking.DockPanel();
            this.docPanelBottom_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanelRight.SuspendLayout();
            this.hideContainerLeft.SuspendLayout();
            this.dockPanelLeft.SuspendLayout();
            this.hideContainerTop.SuspendLayout();
            this.dockPanelTop.SuspendLayout();
            this.hideContainerBottom.SuspendLayout();
            this.dockPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight,
            this.hideContainerLeft,
            this.hideContainerTop,
            this.hideContainerBottom});
            this.dockManager.Form = this;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dockPanelRight);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(465, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 461);
            // 
            // dockPanelRight
            // 
            this.dockPanelRight.Controls.Add(this.dockPanelRight_Container);
            this.dockPanelRight.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelRight.ID = new System.Guid("5337fe47-ad4d-43ce-ae5a-de5781ee593b");
            this.dockPanelRight.Location = new System.Drawing.Point(0, 0);
            this.dockPanelRight.Name = "dockPanelRight";
            this.dockPanelRight.Options.ShowCloseButton = false;
            this.dockPanelRight.OriginalSize = new System.Drawing.Size(95, 200);
            this.dockPanelRight.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelRight.SavedIndex = 0;
            this.dockPanelRight.Size = new System.Drawing.Size(95, 261);
            this.dockPanelRight.Text = "RightDockPanel";
            this.dockPanelRight.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelRight_Container
            // 
            this.dockPanelRight_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanelRight_Container.Name = "dockPanelRight_Container";
            this.dockPanelRight_Container.Size = new System.Drawing.Size(87, 234);
            this.dockPanelRight_Container.TabIndex = 0;
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.dockPanelLeft);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 461);
            // 
            // dockPanelLeft
            // 
            this.dockPanelLeft.Controls.Add(this.dockPanelLeft_Container);
            this.dockPanelLeft.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelLeft.ID = new System.Guid("f773b173-894f-400b-bf0a-1c73a7b90c89");
            this.dockPanelLeft.Location = new System.Drawing.Point(19, 0);
            this.dockPanelLeft.Name = "dockPanelLeft";
            this.dockPanelLeft.Options.ShowCloseButton = false;
            this.dockPanelLeft.OriginalSize = new System.Drawing.Size(92, 200);
            this.dockPanelLeft.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelLeft.SavedIndex = 0;
            this.dockPanelLeft.Size = new System.Drawing.Size(92, 261);
            this.dockPanelLeft.Text = "LeftDockPanel";
            this.dockPanelLeft.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelLeft_Container
            // 
            this.dockPanelLeft_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanelLeft_Container.Name = "dockPanelLeft_Container";
            this.dockPanelLeft_Container.Size = new System.Drawing.Size(84, 234);
            this.dockPanelLeft_Container.TabIndex = 0;
            // 
            // hideContainerTop
            // 
            this.hideContainerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerTop.Controls.Add(this.dockPanelTop);
            this.hideContainerTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.hideContainerTop.Location = new System.Drawing.Point(19, 0);
            this.hideContainerTop.Name = "hideContainerTop";
            this.hideContainerTop.Size = new System.Drawing.Size(446, 19);
            // 
            // dockPanelTop
            // 
            this.dockPanelTop.Controls.Add(this.dockPanelTop_Container);
            this.dockPanelTop.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanelTop.ID = new System.Guid("dce69a9c-fdcb-4d3d-93b9-44bbf47f0299");
            this.dockPanelTop.Location = new System.Drawing.Point(0, 0);
            this.dockPanelTop.Name = "dockPanelTop";
            this.dockPanelTop.Options.ShowCloseButton = false;
            this.dockPanelTop.OriginalSize = new System.Drawing.Size(200, 73);
            this.dockPanelTop.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanelTop.SavedIndex = 0;
            this.dockPanelTop.Size = new System.Drawing.Size(446, 73);
            this.dockPanelTop.Text = "TopDockPanel";
            this.dockPanelTop.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelTop_Container
            // 
            this.dockPanelTop_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanelTop_Container.Name = "dockPanelTop_Container";
            this.dockPanelTop_Container.Size = new System.Drawing.Size(438, 46);
            this.dockPanelTop_Container.TabIndex = 0;
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dockPanelBottom);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(19, 442);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(446, 19);
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Controls.Add(this.docPanelBottom_Container);
            this.dockPanelBottom.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.ID = new System.Guid("3489cffa-980f-426b-be66-70c3455e2b79");
            this.dockPanelBottom.Location = new System.Drawing.Point(0, 0);
            this.dockPanelBottom.Name = "dockPanelBottom";
            this.dockPanelBottom.Options.ShowCloseButton = false;
            this.dockPanelBottom.OriginalSize = new System.Drawing.Size(200, 92);
            this.dockPanelBottom.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.SavedIndex = 0;
            this.dockPanelBottom.Size = new System.Drawing.Size(446, 92);
            this.dockPanelBottom.Text = "BottomDockPanel";
            this.dockPanelBottom.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // docPanelBottom_Container
            // 
            this.docPanelBottom_Container.Location = new System.Drawing.Point(4, 23);
            this.docPanelBottom_Container.Name = "docPanelBottom_Container";
            this.docPanelBottom_Container.Size = new System.Drawing.Size(438, 65);
            this.docPanelBottom_Container.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.hideContainerTop);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.hideContainerRight);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanelRight.ResumeLayout(false);
            this.hideContainerLeft.ResumeLayout(false);
            this.dockPanelLeft.ResumeLayout(false);
            this.hideContainerTop.ResumeLayout(false);
            this.dockPanelTop.ResumeLayout(false);
            this.hideContainerBottom.ResumeLayout(false);
            this.dockPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelRight;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelRight_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelLeft;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelLeft_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelTop;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelTop_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerTop;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelBottom;
        private DevExpress.XtraBars.Docking.ControlContainer docPanelBottom_Container;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
    }
}