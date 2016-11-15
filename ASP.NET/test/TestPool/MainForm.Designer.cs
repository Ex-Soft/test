namespace TestPool
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
            this.TextBoxPoolSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonDoIt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxPoolSize
            // 
            this.TextBoxPoolSize.Location = new System.Drawing.Point(57, 12);
            this.TextBoxPoolSize.Name = "TextBoxPoolSize";
            this.TextBoxPoolSize.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPoolSize.TabIndex = 0;
            this.TextBoxPoolSize.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pool size";
            // 
            // ButtonDoIt
            // 
            this.ButtonDoIt.Location = new System.Drawing.Point(82, 84);
            this.ButtonDoIt.Name = "ButtonDoIt";
            this.ButtonDoIt.Size = new System.Drawing.Size(75, 23);
            this.ButtonDoIt.TabIndex = 2;
            this.ButtonDoIt.Text = "DoIt!";
            this.ButtonDoIt.UseVisualStyleBackColor = true;
            this.ButtonDoIt.Click += new System.EventHandler(this.ButtonDoIt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.ButtonDoIt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPoolSize);
            this.Name = "MainForm";
            this.Text = "Test Pool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxPoolSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonDoIt;
    }
}

