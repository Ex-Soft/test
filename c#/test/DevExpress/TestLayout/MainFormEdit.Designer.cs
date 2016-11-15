namespace TestLayout
{
    partial class MainFormEdit
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
            this.lblBottomRight = new DevExpress.XtraEditors.LabelControl();
            this.lblBottomLeft = new DevExpress.XtraEditors.LabelControl();
            this.pnlFill = new DevExpress.XtraEditors.PanelControl();
            this.lblTopRight = new DevExpress.XtraEditors.LabelControl();
            this.lblTopLeft = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblBottomRight);
            this.pnlBottom.Controls.Add(this.lblBottomLeft);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(19, 342);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(446, 100);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblBottomRight
            // 
            this.lblBottomRight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBottomRight.Location = new System.Drawing.Point(385, 2);
            this.lblBottomRight.Name = "lblBottomRight";
            this.lblBottomRight.Size = new System.Drawing.Size(59, 13);
            this.lblBottomRight.TabIndex = 1;
            this.lblBottomRight.Text = "BottomRight";
            // 
            // lblBottomLeft
            // 
            this.lblBottomLeft.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblBottomLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBottomLeft.Location = new System.Drawing.Point(2, 85);
            this.lblBottomLeft.Name = "lblBottomLeft";
            this.lblBottomLeft.Size = new System.Drawing.Size(53, 13);
            this.lblBottomLeft.TabIndex = 0;
            this.lblBottomLeft.Text = "BottomLeft";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.lblTopRight);
            this.pnlFill.Controls.Add(this.lblTopLeft);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(19, 19);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(446, 323);
            this.pnlFill.TabIndex = 2;
            // 
            // lblTopRight
            // 
            this.lblTopRight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTopRight.Location = new System.Drawing.Point(401, 2);
            this.lblTopRight.Name = "lblTopRight";
            this.lblTopRight.Size = new System.Drawing.Size(43, 13);
            this.lblTopRight.TabIndex = 1;
            this.lblTopRight.Text = "TopRight";
            // 
            // lblTopLeft
            // 
            this.lblTopLeft.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTopLeft.Location = new System.Drawing.Point(2, 2);
            this.lblTopLeft.Name = "lblTopLeft";
            this.lblTopLeft.Size = new System.Drawing.Size(37, 13);
            this.lblTopLeft.TabIndex = 0;
            this.lblTopLeft.Text = "TopLeft";
            // 
            // MainFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(306, 307);
            this.Name = "MainFormEdit";
            this.Text = "MainFormEdit";
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlFill, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl pnlBottom;
        protected DevExpress.XtraEditors.PanelControl pnlFill;
        private DevExpress.XtraEditors.LabelControl lblTopRight;
        private DevExpress.XtraEditors.LabelControl lblTopLeft;
        private DevExpress.XtraEditors.LabelControl lblBottomRight;
        private DevExpress.XtraEditors.LabelControl lblBottomLeft;
    }
}