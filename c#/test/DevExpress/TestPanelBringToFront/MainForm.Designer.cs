namespace TestPanelBringToFront
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
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.lblOnPnlFill = new System.Windows.Forms.Label();
            this.lblOnPnlBottom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.lblOnPnlFill);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(284, 211);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblOnPnlBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 211);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(284, 50);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblOnPnlFill
            // 
            this.lblOnPnlFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOnPnlFill.AutoSize = true;
            this.lblOnPnlFill.Location = new System.Drawing.Point(5, 192);
            this.lblOnPnlFill.Name = "lblOnPnlFill";
            this.lblOnPnlFill.Size = new System.Drawing.Size(57, 13);
            this.lblOnPnlFill.TabIndex = 0;
            this.lblOnPnlFill.Text = "lblOnPnlFill";
            // 
            // lblOnPnlBottom
            // 
            this.lblOnPnlBottom.AutoSize = true;
            this.lblOnPnlBottom.Location = new System.Drawing.Point(5, 5);
            this.lblOnPnlBottom.Name = "lblOnPnlBottom";
            this.lblOnPnlBottom.Size = new System.Drawing.Size(79, 13);
            this.lblOnPnlBottom.TabIndex = 1;
            this.lblOnPnlBottom.Text = "lblOnPnlBottom";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlFill;
        private System.Windows.Forms.Label lblOnPnlFill;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private System.Windows.Forms.Label lblOnPnlBottom;
    }
}

