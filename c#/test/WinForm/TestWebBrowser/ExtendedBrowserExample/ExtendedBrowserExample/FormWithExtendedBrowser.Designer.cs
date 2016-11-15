namespace ExampleWithMyExtendedWebBrowser
{
    partial class FormWithExtendedBrowser
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.extendedWebBrowser1 = new ExtendedWebBrowser();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(333, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Navigate to given address:";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 465);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(466, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "http://localhost/JavaScript/test0.htm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address:";
            // 
            // extendedWebBrowser1
            // 
            this.extendedWebBrowser1.Location = new System.Drawing.Point(29, 33);
            this.extendedWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.extendedWebBrowser1.Name = "extendedWebBrowser1";
            this.extendedWebBrowser1.Size = new System.Drawing.Size(565, 392);
            this.extendedWebBrowser1.TabIndex = 1;
            this.extendedWebBrowser1.NewWindow2 += new System.EventHandler<NewWindow2EventArgs>(this.extendedWebBrowser1_NewWindow2);
            // 
            // FormWithExtendedBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.extendedWebBrowser1);
            this.Name = "FormWithExtendedBrowser";
            this.Text = "Example where a new window or popup is openned in a new form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedWebBrowser extendedWebBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;

    }
}

