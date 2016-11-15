namespace TestLockForm
{
    partial class SlaveForm
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
            System.Diagnostics.Debug.WriteLine("Dispose({0}) (CurrentThread.ManagedThreadId: {1}, CurrentContext.ContextID: {2})", disposing, System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);

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
            this.SuspendLayout();
            // 
            // SlaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "SlaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SlaveForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SlaveFormClosing);
            this.Closed += new System.EventHandler(this.SlaveFormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlaveFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SlaveFormFormClosed);
            this.Disposed += new System.EventHandler(this.SlaveFormDisposed);
            this.ResumeLayout(false);

        }

        #endregion
    }
}