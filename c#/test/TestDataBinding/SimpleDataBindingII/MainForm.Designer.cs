namespace SimpleDataBindingII
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSetProperty = new System.Windows.Forms.Button();
            this.btnSetControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnSetProperty
            // 
            this.btnSetProperty.Location = new System.Drawing.Point(159, 24);
            this.btnSetProperty.Name = "btnSetProperty";
            this.btnSetProperty.Size = new System.Drawing.Size(75, 23);
            this.btnSetProperty.TabIndex = 1;
            this.btnSetProperty.Text = "SetProperty";
            this.btnSetProperty.UseVisualStyleBackColor = true;
            this.btnSetProperty.Click += new System.EventHandler(this.BtnSetPropertyClick);
            // 
            // btnSetControl
            // 
            this.btnSetControl.Location = new System.Drawing.Point(159, 62);
            this.btnSetControl.Name = "btnSetControl";
            this.btnSetControl.Size = new System.Drawing.Size(75, 23);
            this.btnSetControl.TabIndex = 3;
            this.btnSetControl.Text = "SetControl";
            this.btnSetControl.UseVisualStyleBackColor = true;
            this.btnSetControl.Click += new System.EventHandler(this.BtnSetControlClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSetControl);
            this.Controls.Add(this.btnSetProperty);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSetProperty;
        private System.Windows.Forms.Button btnSetControl;
    }
}

