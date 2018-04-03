namespace TestVGrid
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnShowValue = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.vGridControl = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnShowValue);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 211);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(284, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnShowValue
            // 
            this.btnShowValue.Location = new System.Drawing.Point(13, 15);
            this.btnShowValue.Name = "btnShowValue";
            this.btnShowValue.Size = new System.Drawing.Size(75, 23);
            this.btnShowValue.TabIndex = 0;
            this.btnShowValue.Text = "Show Value";
            this.btnShowValue.Click += new System.EventHandler(this.BtnShowValueClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.vGridControl);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(284, 211);
            this.pnlFill.TabIndex = 1;
            // 
            // vGridControl
            // 
            this.vGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl.Location = new System.Drawing.Point(2, 2);
            this.vGridControl.Name = "vGridControl";
            this.vGridControl.Size = new System.Drawing.Size(280, 207);
            this.vGridControl.TabIndex = 0;
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
            this.Text = "Test VGrid";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl;
        private DevExpress.XtraEditors.SimpleButton btnShowValue;
    }
}

