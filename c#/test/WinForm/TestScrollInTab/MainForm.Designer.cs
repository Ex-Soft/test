namespace TestScrollInTab
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
            this.pnlFill = new System.Windows.Forms.Panel();
            this.tcData = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.groupControl3 = new System.Windows.Forms.GroupBox();
            this.groupControl2 = new System.Windows.Forms.GroupBox();
            this.groupControl1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.checkBoxAnchorBottom = new System.Windows.Forms.CheckBox();
            this.pnlFill.SuspendLayout();
            this.tcData.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.tcData);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(284, 211);
            this.pnlFill.TabIndex = 0;
            // 
            // tcData
            // 
            this.tcData.Controls.Add(this.tpMain);
            this.tcData.Controls.Add(this.tabPage2);
            this.tcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcData.Location = new System.Drawing.Point(0, 0);
            this.tcData.Name = "tcData";
            this.tcData.SelectedIndex = 0;
            this.tcData.Size = new System.Drawing.Size(284, 211);
            this.tcData.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.AutoScroll = true;
            this.tpMain.AutoScrollMinSize = new System.Drawing.Size(0, 185);
            this.tpMain.Controls.Add(this.groupControl3);
            this.tpMain.Controls.Add(this.groupControl2);
            this.tpMain.Controls.Add(this.groupControl1);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(276, 185);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "tpMain";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Location = new System.Drawing.Point(3, 120);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(200, 50);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.TabStop = false;
            this.groupControl3.Text = "groupControl3";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Location = new System.Drawing.Point(3, 60);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(200, 50);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.TabStop = false;
            this.groupControl2.Text = "groupControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 50);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.TabStop = false;
            this.groupControl1.Text = "groupControl1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 185);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.checkBoxAnchorBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 211);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(284, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // checkBoxAnchorBottom
            // 
            this.checkBoxAnchorBottom.AutoSize = true;
            this.checkBoxAnchorBottom.Location = new System.Drawing.Point(24, 7);
            this.checkBoxAnchorBottom.Name = "checkBoxAnchorBottom";
            this.checkBoxAnchorBottom.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAnchorBottom.TabIndex = 0;
            this.checkBoxAnchorBottom.Text = "Anchor (Bottom)";
            this.checkBoxAnchorBottom.UseVisualStyleBackColor = true;
            this.checkBoxAnchorBottom.CheckedChanged += new System.EventHandler(this.CheckBoxAnchorBottomCheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlFill.ResumeLayout(false);
            this.tcData.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.TabControl tcData;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.GroupBox groupControl2;
        private System.Windows.Forms.GroupBox groupControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.GroupBox groupControl3;
        private System.Windows.Forms.CheckBox checkBoxAnchorBottom;
    }
}

