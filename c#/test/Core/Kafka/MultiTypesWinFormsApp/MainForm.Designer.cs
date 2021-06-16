
namespace MultiTypesWinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpProduce = new System.Windows.Forms.TabPage();
            this.scProduce = new System.Windows.Forms.SplitContainer();
            this.btnCancelProduce = new System.Windows.Forms.Button();
            this.btnProduce = new System.Windows.Forms.Button();
            this.lbLogProduce = new System.Windows.Forms.ListBox();
            this.tpConsume = new System.Windows.Forms.TabPage();
            this.scConsume = new System.Windows.Forms.SplitContainer();
            this.btnCancelConsume = new System.Windows.Forms.Button();
            this.btnConsume = new System.Windows.Forms.Button();
            this.lbLogConsume = new System.Windows.Forms.ListBox();
            this.tbProduceMSec = new System.Windows.Forms.TextBox();
            this.tbProduceMax = new System.Windows.Forms.TextBox();
            this.lblProduceMSec = new System.Windows.Forms.Label();
            this.lblProduceMax = new System.Windows.Forms.Label();
            this.tbConsumeMin = new System.Windows.Forms.TextBox();
            this.lblConsumeMin = new System.Windows.Forms.Label();
            this.tbConsumeMSec = new System.Windows.Forms.TextBox();
            this.tbConsumeMax = new System.Windows.Forms.TextBox();
            this.lblConsumeMSec = new System.Windows.Forms.Label();
            this.lblConsumeMax = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tpProduce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scProduce)).BeginInit();
            this.scProduce.Panel1.SuspendLayout();
            this.scProduce.Panel2.SuspendLayout();
            this.scProduce.SuspendLayout();
            this.tpConsume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConsume)).BeginInit();
            this.scConsume.Panel1.SuspendLayout();
            this.scConsume.Panel2.SuspendLayout();
            this.scConsume.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpProduce);
            this.tabControl.Controls.Add(this.tpConsume);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tpProduce
            // 
            this.tpProduce.Controls.Add(this.scProduce);
            this.tpProduce.Location = new System.Drawing.Point(4, 29);
            this.tpProduce.Name = "tpProduce";
            this.tpProduce.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduce.Size = new System.Drawing.Size(792, 417);
            this.tpProduce.TabIndex = 0;
            this.tpProduce.Text = "Produce";
            this.tpProduce.UseVisualStyleBackColor = true;
            // 
            // scProduce
            // 
            this.scProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scProduce.Location = new System.Drawing.Point(3, 3);
            this.scProduce.Name = "scProduce";
            this.scProduce.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scProduce.Panel1
            // 
            this.scProduce.Panel1.Controls.Add(this.tbProduceMSec);
            this.scProduce.Panel1.Controls.Add(this.tbProduceMax);
            this.scProduce.Panel1.Controls.Add(this.lblProduceMSec);
            this.scProduce.Panel1.Controls.Add(this.lblProduceMax);
            this.scProduce.Panel1.Controls.Add(this.btnCancelProduce);
            this.scProduce.Panel1.Controls.Add(this.btnProduce);
            // 
            // scProduce.Panel2
            // 
            this.scProduce.Panel2.Controls.Add(this.lbLogProduce);
            this.scProduce.Size = new System.Drawing.Size(786, 411);
            this.scProduce.SplitterDistance = 60;
            this.scProduce.TabIndex = 1;
            // 
            // btnCancelProduce
            // 
            this.btnCancelProduce.Location = new System.Drawing.Point(354, 16);
            this.btnCancelProduce.Name = "btnCancelProduce";
            this.btnCancelProduce.Size = new System.Drawing.Size(94, 29);
            this.btnCancelProduce.TabIndex = 1;
            this.btnCancelProduce.Text = "Cancel";
            this.btnCancelProduce.UseVisualStyleBackColor = true;
            this.btnCancelProduce.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnProduce
            // 
            this.btnProduce.Location = new System.Drawing.Point(237, 16);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(94, 29);
            this.btnProduce.TabIndex = 0;
            this.btnProduce.Text = "Produce";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Click += new System.EventHandler(this.BtnProduceClick);
            // 
            // lbLogProduce
            // 
            this.lbLogProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogProduce.FormattingEnabled = true;
            this.lbLogProduce.ItemHeight = 20;
            this.lbLogProduce.Location = new System.Drawing.Point(0, 0);
            this.lbLogProduce.Name = "lbLogProduce";
            this.lbLogProduce.Size = new System.Drawing.Size(786, 347);
            this.lbLogProduce.TabIndex = 0;
            // 
            // tpConsume
            // 
            this.tpConsume.Controls.Add(this.scConsume);
            this.tpConsume.Location = new System.Drawing.Point(4, 29);
            this.tpConsume.Name = "tpConsume";
            this.tpConsume.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsume.Size = new System.Drawing.Size(792, 417);
            this.tpConsume.TabIndex = 1;
            this.tpConsume.Text = "Consume";
            this.tpConsume.UseVisualStyleBackColor = true;
            // 
            // scConsume
            // 
            this.scConsume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scConsume.Location = new System.Drawing.Point(3, 3);
            this.scConsume.Name = "scConsume";
            this.scConsume.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scConsume.Panel1
            // 
            this.scConsume.Panel1.Controls.Add(this.tbConsumeMin);
            this.scConsume.Panel1.Controls.Add(this.lblConsumeMin);
            this.scConsume.Panel1.Controls.Add(this.tbConsumeMSec);
            this.scConsume.Panel1.Controls.Add(this.tbConsumeMax);
            this.scConsume.Panel1.Controls.Add(this.lblConsumeMSec);
            this.scConsume.Panel1.Controls.Add(this.lblConsumeMax);
            this.scConsume.Panel1.Controls.Add(this.btnCancelConsume);
            this.scConsume.Panel1.Controls.Add(this.btnConsume);
            // 
            // scConsume.Panel2
            // 
            this.scConsume.Panel2.Controls.Add(this.lbLogConsume);
            this.scConsume.Size = new System.Drawing.Size(786, 411);
            this.scConsume.SplitterDistance = 60;
            this.scConsume.TabIndex = 0;
            // 
            // btnCancelConsume
            // 
            this.btnCancelConsume.Location = new System.Drawing.Point(461, 16);
            this.btnCancelConsume.Name = "btnCancelConsume";
            this.btnCancelConsume.Size = new System.Drawing.Size(94, 29);
            this.btnCancelConsume.TabIndex = 1;
            this.btnCancelConsume.Text = "Cancel";
            this.btnCancelConsume.UseVisualStyleBackColor = true;
            this.btnCancelConsume.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnConsume
            // 
            this.btnConsume.Location = new System.Drawing.Point(344, 16);
            this.btnConsume.Name = "btnConsume";
            this.btnConsume.Size = new System.Drawing.Size(94, 29);
            this.btnConsume.TabIndex = 0;
            this.btnConsume.Text = "Consume";
            this.btnConsume.UseVisualStyleBackColor = true;
            this.btnConsume.Click += new System.EventHandler(this.BtnConsumeClick);
            // 
            // lbLogConsume
            // 
            this.lbLogConsume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogConsume.FormattingEnabled = true;
            this.lbLogConsume.ItemHeight = 20;
            this.lbLogConsume.Location = new System.Drawing.Point(0, 0);
            this.lbLogConsume.Name = "lbLogConsume";
            this.lbLogConsume.Size = new System.Drawing.Size(786, 347);
            this.lbLogConsume.TabIndex = 0;
            // 
            // tbProduceMSec
            // 
            this.tbProduceMSec.Location = new System.Drawing.Point(172, 17);
            this.tbProduceMSec.Name = "tbProduceMSec";
            this.tbProduceMSec.Size = new System.Drawing.Size(50, 27);
            this.tbProduceMSec.TabIndex = 10;
            // 
            // tbProduceMax
            // 
            this.tbProduceMax.Location = new System.Drawing.Point(55, 17);
            this.tbProduceMax.Name = "tbProduceMax";
            this.tbProduceMax.Size = new System.Drawing.Size(50, 27);
            this.tbProduceMax.TabIndex = 9;
            // 
            // lblProduceMSec
            // 
            this.lblProduceMSec.AutoSize = true;
            this.lblProduceMSec.Location = new System.Drawing.Point(121, 20);
            this.lblProduceMSec.Name = "lblProduceMSec";
            this.lblProduceMSec.Size = new System.Drawing.Size(45, 20);
            this.lblProduceMSec.TabIndex = 8;
            this.lblProduceMSec.Text = "mSec";
            // 
            // lblProduceMax
            // 
            this.lblProduceMax.AutoSize = true;
            this.lblProduceMax.Location = new System.Drawing.Point(12, 20);
            this.lblProduceMax.Name = "lblProduceMax";
            this.lblProduceMax.Size = new System.Drawing.Size(37, 20);
            this.lblProduceMax.TabIndex = 7;
            this.lblProduceMax.Text = "Max";
            // 
            // tbConsumeMin
            // 
            this.tbConsumeMin.Location = new System.Drawing.Point(67, 17);
            this.tbConsumeMin.Name = "tbConsumeMin";
            this.tbConsumeMin.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMin.TabIndex = 19;
            // 
            // lblConsumeMin
            // 
            this.lblConsumeMin.AutoSize = true;
            this.lblConsumeMin.Location = new System.Drawing.Point(10, 20);
            this.lblConsumeMin.Name = "lblConsumeMin";
            this.lblConsumeMin.Size = new System.Drawing.Size(34, 20);
            this.lblConsumeMin.TabIndex = 18;
            this.lblConsumeMin.Text = "Min";
            // 
            // tbConsumeMSec
            // 
            this.tbConsumeMSec.Location = new System.Drawing.Point(273, 17);
            this.tbConsumeMSec.Name = "tbConsumeMSec";
            this.tbConsumeMSec.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMSec.TabIndex = 17;
            // 
            // tbConsumeMax
            // 
            this.tbConsumeMax.Location = new System.Drawing.Point(166, 17);
            this.tbConsumeMax.Name = "tbConsumeMax";
            this.tbConsumeMax.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMax.TabIndex = 16;
            // 
            // lblConsumeMSec
            // 
            this.lblConsumeMSec.AutoSize = true;
            this.lblConsumeMSec.Location = new System.Drawing.Point(222, 20);
            this.lblConsumeMSec.Name = "lblConsumeMSec";
            this.lblConsumeMSec.Size = new System.Drawing.Size(45, 20);
            this.lblConsumeMSec.TabIndex = 15;
            this.lblConsumeMSec.Text = "mSec";
            // 
            // lblConsumeMax
            // 
            this.lblConsumeMax.AutoSize = true;
            this.lblConsumeMax.Location = new System.Drawing.Point(123, 20);
            this.lblConsumeMax.Name = "lblConsumeMax";
            this.lblConsumeMax.Size = new System.Drawing.Size(37, 20);
            this.lblConsumeMax.TabIndex = 14;
            this.lblConsumeMax.Text = "Max";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.tpProduce.ResumeLayout(false);
            this.scProduce.Panel1.ResumeLayout(false);
            this.scProduce.Panel1.PerformLayout();
            this.scProduce.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scProduce)).EndInit();
            this.scProduce.ResumeLayout(false);
            this.tpConsume.ResumeLayout(false);
            this.scConsume.Panel1.ResumeLayout(false);
            this.scConsume.Panel1.PerformLayout();
            this.scConsume.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scConsume)).EndInit();
            this.scConsume.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpProduce;
        private System.Windows.Forms.TabPage tpConsume;
        private System.Windows.Forms.SplitContainer scConsume;
        private System.Windows.Forms.Button btnConsume;
        private System.Windows.Forms.ListBox lbLogConsume;
        private System.Windows.Forms.Button btnCancelConsume;
        private System.Windows.Forms.SplitContainer scProduce;
        private System.Windows.Forms.Button btnCancelProduce;
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.ListBox lbLogProduce;
        private System.Windows.Forms.TextBox tbProduceMSec;
        private System.Windows.Forms.TextBox tbProduceMax;
        private System.Windows.Forms.Label lblProduceMSec;
        private System.Windows.Forms.Label lblProduceMax;
        private System.Windows.Forms.TextBox tbConsumeMin;
        private System.Windows.Forms.Label lblConsumeMin;
        private System.Windows.Forms.TextBox tbConsumeMSec;
        private System.Windows.Forms.TextBox tbConsumeMax;
        private System.Windows.Forms.Label lblConsumeMSec;
        private System.Windows.Forms.Label lblConsumeMax;
    }
}

