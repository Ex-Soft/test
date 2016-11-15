namespace TestControls
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
            this.tpTestSplitter = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tpTestCommonControls = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl.SuspendLayout();
            this.tpTestSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.tpTestCommonControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpTestSplitter);
            this.tabControl.Controls.Add(this.tpTestCommonControls);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(835, 446);
            this.tabControl.TabIndex = 0;
            // 
            // tpTestSplitter
            // 
            this.tpTestSplitter.Controls.Add(this.splitContainer);
            this.tpTestSplitter.Location = new System.Drawing.Point(4, 22);
            this.tpTestSplitter.Name = "tpTestSplitter";
            this.tpTestSplitter.Padding = new System.Windows.Forms.Padding(3);
            this.tpTestSplitter.Size = new System.Drawing.Size(827, 420);
            this.tpTestSplitter.TabIndex = 0;
            this.tpTestSplitter.Text = "Test Splitter";
            this.tpTestSplitter.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.Navy;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.Teal;
            this.splitContainer.Size = new System.Drawing.Size(821, 414);
            this.splitContainer.SplitterDistance = 273;
            this.splitContainer.TabIndex = 0;
            // 
            // tpTestCommonControls
            // 
            this.tpTestCommonControls.Controls.Add(this.linkLabel1);
            this.tpTestCommonControls.Location = new System.Drawing.Point(4, 22);
            this.tpTestCommonControls.Name = "tpTestCommonControls";
            this.tpTestCommonControls.Size = new System.Drawing.Size(827, 420);
            this.tpTestCommonControls.TabIndex = 1;
            this.tpTestCommonControls.Text = "Test Common Controls";
            this.tpTestCommonControls.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(24, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.google.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 446);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.tpTestSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tpTestCommonControls.ResumeLayout(false);
            this.tpTestCommonControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpTestSplitter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabPage tpTestCommonControls;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

