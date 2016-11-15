namespace TestUserControl
{
    partial class TestUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbkMaster = new System.Windows.Forms.Label();
            this.lblSlave = new System.Windows.Forms.Label();
            this.tbMaster = new System.Windows.Forms.TextBox();
            this.tbSlave = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbkMaster
            // 
            this.lbkMaster.AutoSize = true;
            this.lbkMaster.Location = new System.Drawing.Point(12, 19);
            this.lbkMaster.Name = "lbkMaster";
            this.lbkMaster.Size = new System.Drawing.Size(39, 13);
            this.lbkMaster.TabIndex = 0;
            this.lbkMaster.Text = "Master";
            // 
            // lblSlave
            // 
            this.lblSlave.AutoSize = true;
            this.lblSlave.Location = new System.Drawing.Point(12, 49);
            this.lblSlave.Name = "lblSlave";
            this.lblSlave.Size = new System.Drawing.Size(34, 13);
            this.lblSlave.TabIndex = 1;
            this.lblSlave.Text = "Slave";
            // 
            // tbMaster
            // 
            this.tbMaster.Location = new System.Drawing.Point(65, 15);
            this.tbMaster.Name = "tbMaster";
            this.tbMaster.Size = new System.Drawing.Size(250, 20);
            this.tbMaster.TabIndex = 2;
            // 
            // tbSlave
            // 
            this.tbSlave.Location = new System.Drawing.Point(65, 45);
            this.tbSlave.Name = "tbSlave";
            this.tbSlave.Size = new System.Drawing.Size(250, 20);
            this.tbSlave.TabIndex = 3;
            // 
            // TestUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSlave);
            this.Controls.Add(this.tbMaster);
            this.Controls.Add(this.lblSlave);
            this.Controls.Add(this.lbkMaster);
            this.Name = "TestUserControl";
            this.Size = new System.Drawing.Size(334, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbkMaster;
        private System.Windows.Forms.Label lblSlave;
        private System.Windows.Forms.TextBox tbMaster;
        private System.Windows.Forms.TextBox tbSlave;
    }
}
