namespace TestWebBrowserV
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnSetUrl = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
            //this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.webBrowser = new WebBrowserExtended();
            this.btnTest = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnTest);
            this.pnlBottom.Controls.Add(this.btnDispose);
            this.pnlBottom.Controls.Add(this.btnSetUrl);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 270);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1094, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnDispose
            // 
            this.btnDispose.Location = new System.Drawing.Point(102, 15);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(75, 23);
            this.btnDispose.TabIndex = 1;
            this.btnDispose.Text = "Dispose";
            this.btnDispose.UseVisualStyleBackColor = true;
            this.btnDispose.Click += new System.EventHandler(this.BtnDisposeClick);
            // 
            // btnSetUrl
            // 
            this.btnSetUrl.Location = new System.Drawing.Point(21, 15);
            this.btnSetUrl.Name = "btnSetUrl";
            this.btnSetUrl.Size = new System.Drawing.Size(75, 23);
            this.btnSetUrl.TabIndex = 0;
            this.btnSetUrl.Text = "SetUrl";
            this.btnSetUrl.UseVisualStyleBackColor = true;
            this.btnSetUrl.Click += new System.EventHandler(this.BtnSetUrlClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.webBrowser);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1094, 270);
            this.pnlFill.TabIndex = 1;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(1094, 270);
            this.webBrowser.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1007, 15);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTestClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 320);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.pnlBottom.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSetUrl;
        private System.Windows.Forms.Panel pnlFill;
        //private System.Windows.Forms.WebBrowser webBrowser;
        private WebBrowserExtended webBrowser;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Button btnTest;
    }
}

