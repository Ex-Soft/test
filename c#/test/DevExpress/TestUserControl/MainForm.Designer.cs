namespace TestUserControl
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
            this.customUserControl1 = new TestUserControl.CustomUserControl();
            this.customUserControl2 = new TestUserControl.CustomUserControl();
            this.customUserControl3 = new TestUserControl.CustomUserControl();
            this.customUserControl4 = new TestUserControl.CustomUserControl();
            this.SuspendLayout();
            // 
            // customUserControl1
            // 
            this.customUserControl1.Location = new System.Drawing.Point(12, 12);
            this.customUserControl1.Name = "customUserControl1";
            this.customUserControl1.Size = new System.Drawing.Size(85, 78);
            this.customUserControl1.TabIndex = 0;
            // 
            // customUserControl2
            // 
            this.customUserControl2.Location = new System.Drawing.Point(187, 12);
            this.customUserControl2.Name = "customUserControl2";
            this.customUserControl2.Size = new System.Drawing.Size(85, 78);
            this.customUserControl2.TabIndex = 1;
            // 
            // customUserControl3
            // 
            this.customUserControl3.Location = new System.Drawing.Point(12, 171);
            this.customUserControl3.Name = "customUserControl3";
            this.customUserControl3.Size = new System.Drawing.Size(85, 78);
            this.customUserControl3.TabIndex = 2;
            // 
            // customUserControl4
            // 
            this.customUserControl4.Location = new System.Drawing.Point(176, 171);
            this.customUserControl4.Name = "customUserControl4";
            this.customUserControl4.Size = new System.Drawing.Size(85, 78);
            this.customUserControl4.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.customUserControl4);
            this.Controls.Add(this.customUserControl3);
            this.Controls.Add(this.customUserControl2);
            this.Controls.Add(this.customUserControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUserControl customUserControl1;
        private CustomUserControl customUserControl2;
        private CustomUserControl customUserControl3;
        private CustomUserControl customUserControl4;
    }
}

