namespace TestWindow
{
    partial class SmthForm
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
            System.Diagnostics.Debug.WriteLine("SmthForm: Dispose({0})", disposing);

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItem11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subItem12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItem11ToolStripMenuItem,
            this.subItem12ToolStripMenuItem});
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.item1ToolStripMenuItem.Text = "Item# 1";
            // 
            // subItem11ToolStripMenuItem
            // 
            this.subItem11ToolStripMenuItem.Name = "subItem11ToolStripMenuItem";
            this.subItem11ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subItem11ToolStripMenuItem.Text = "SubItem# 1.1";
            // 
            // subItem12ToolStripMenuItem
            // 
            this.subItem12ToolStripMenuItem.Name = "subItem12ToolStripMenuItem";
            this.subItem12ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subItem12ToolStripMenuItem.Text = "SubItem# 1.2";
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.item2ToolStripMenuItem.Text = "Item# 2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(26, 100);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "Hide()";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.BtnHideClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(116, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close()";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // SmthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SmthForm";
            this.Text = "SmthForm";
            this.Activated += new System.EventHandler(this.SmthFormActivated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SmthFormClosing);
            this.Closed += new System.EventHandler(this.SmthFormClosed);
            this.Deactivate += new System.EventHandler(this.SmthFormDeactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SmthFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SmthFormFormClosed);
            this.Load += new System.EventHandler(this.SmthFormLoad);
            this.Shown += new System.EventHandler(this.SmthFormShown);
            this.HandleCreated += new System.EventHandler(this.SmthFormHandleCreated);
            this.HandleDestroyed += new System.EventHandler(this.SmthFormHandleDestroyed);
            this.Enter += new System.EventHandler(this.SmthFormEnter);
            this.GotFocus += new System.EventHandler(this.SmthFormGotFocus);
            this.Leave += new System.EventHandler(this.SmthFormLeave);
            this.LostFocus += new System.EventHandler(this.SmthFormLostFocus);
            this.Disposed += new System.EventHandler(this.SmthFormDisposed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        

        

        
        
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subItem11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subItem12ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnClose;
    }
}