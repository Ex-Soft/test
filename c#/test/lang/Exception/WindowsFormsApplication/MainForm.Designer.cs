namespace WindowsFormsApplication
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
            this.buttonException = new System.Windows.Forms.Button();
            this.buttonAggregateException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonException
            // 
            this.buttonException.Location = new System.Drawing.Point(8, 8);
            this.buttonException.Name = "buttonException";
            this.buttonException.Size = new System.Drawing.Size(75, 23);
            this.buttonException.TabIndex = 0;
            this.buttonException.Text = "Exception";
            this.buttonException.UseVisualStyleBackColor = true;
            this.buttonException.Click += new System.EventHandler(this.buttonException_Click);
            // 
            // buttonAggregateException
            // 
            this.buttonAggregateException.Location = new System.Drawing.Point(8, 37);
            this.buttonAggregateException.Name = "buttonAggregateException";
            this.buttonAggregateException.Size = new System.Drawing.Size(125, 23);
            this.buttonAggregateException.TabIndex = 1;
            this.buttonAggregateException.Text = "AggregateException";
            this.buttonAggregateException.UseVisualStyleBackColor = true;
            this.buttonAggregateException.Click += new System.EventHandler(this.buttonAggregateException_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonAggregateException);
            this.Controls.Add(this.buttonException);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonException;
        private System.Windows.Forms.Button buttonAggregateException;
    }
}

