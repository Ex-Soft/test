namespace TestXtraMessageBox
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
            this.simpleButtonShow = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonTaskSendShow = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonTaskShow = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButtonShow
            // 
            this.simpleButtonShow.Location = new System.Drawing.Point(36, 23);
            this.simpleButtonShow.Name = "simpleButtonShow";
            this.simpleButtonShow.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonShow.TabIndex = 0;
            this.simpleButtonShow.Text = "Show()";
            this.simpleButtonShow.Click += new System.EventHandler(this.SimpleButtonShowClick);
            // 
            // simpleButtonTaskSendShow
            // 
            this.simpleButtonTaskSendShow.Location = new System.Drawing.Point(36, 108);
            this.simpleButtonTaskSendShow.Name = "simpleButtonTaskSendShow";
            this.simpleButtonTaskSendShow.Size = new System.Drawing.Size(141, 23);
            this.simpleButtonTaskSendShow.TabIndex = 1;
            this.simpleButtonTaskSendShow.Text = "Task(Send(Show()))";
            this.simpleButtonTaskSendShow.Click += new System.EventHandler(this.SimpleButtonTaskSendShowClick);
            // 
            // simpleButtonTaskShow
            // 
            this.simpleButtonTaskShow.Location = new System.Drawing.Point(36, 65);
            this.simpleButtonTaskShow.Name = "simpleButtonTaskShow";
            this.simpleButtonTaskShow.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonTaskShow.TabIndex = 2;
            this.simpleButtonTaskShow.Text = "Task(Show())";
            this.simpleButtonTaskShow.Click += new System.EventHandler(this.SimpleButtonTaskShowClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.simpleButtonTaskShow);
            this.Controls.Add(this.simpleButtonTaskSendShow);
            this.Controls.Add(this.simpleButtonShow);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonShow;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTaskSendShow;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTaskShow;
    }
}

