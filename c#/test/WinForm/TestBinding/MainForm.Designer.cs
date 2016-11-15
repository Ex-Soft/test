namespace TestBinding
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
            this.tbFString1 = new System.Windows.Forms.TextBox();
            this.tbFString2 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFString1
            // 
            this.tbFString1.Location = new System.Drawing.Point(12, 12);
            this.tbFString1.Name = "tbFString1";
            this.tbFString1.Size = new System.Drawing.Size(100, 20);
            this.tbFString1.TabIndex = 0;
            this.tbFString1.Validating += new System.ComponentModel.CancelEventHandler(this.tbFString1_Validating);
            // 
            // tbFString2
            // 
            this.tbFString2.Location = new System.Drawing.Point(12, 38);
            this.tbFString2.Name = "tbFString2";
            this.tbFString2.Size = new System.Drawing.Size(100, 20);
            this.tbFString2.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.tbFString2);
            this.Controls.Add(this.tbFString1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFString1;
        private System.Windows.Forms.TextBox tbFString2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

