
namespace KafkaWinFormsApp
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tbProduceMSec = new System.Windows.Forms.TextBox();
            this.tbProduceMax = new System.Windows.Forms.TextBox();
            this.lblProduceMSec = new System.Windows.Forms.Label();
            this.lblProduceMax = new System.Windows.Forms.Label();
            this.lbLogProduce = new System.Windows.Forms.ListBox();
            this.btnProduceCancel = new System.Windows.Forms.Button();
            this.btnProduce = new System.Windows.Forms.Button();
            this.btnConsume = new System.Windows.Forms.Button();
            this.btnConsumeCancel = new System.Windows.Forms.Button();
            this.tbConsumeMSec = new System.Windows.Forms.TextBox();
            this.tbConsumeMax = new System.Windows.Forms.TextBox();
            this.lblConsumeMSec = new System.Windows.Forms.Label();
            this.lblConsumeMax = new System.Windows.Forms.Label();
            this.lbLogConsume = new System.Windows.Forms.ListBox();
            this.tbConsumeMin = new System.Windows.Forms.TextBox();
            this.lblConsumeMin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tbProduceMSec);
            this.splitContainer.Panel1.Controls.Add(this.tbProduceMax);
            this.splitContainer.Panel1.Controls.Add(this.lblProduceMSec);
            this.splitContainer.Panel1.Controls.Add(this.lblProduceMax);
            this.splitContainer.Panel1.Controls.Add(this.lbLogProduce);
            this.splitContainer.Panel1.Controls.Add(this.btnProduceCancel);
            this.splitContainer.Panel1.Controls.Add(this.btnProduce);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tbConsumeMin);
            this.splitContainer.Panel2.Controls.Add(this.lblConsumeMin);
            this.splitContainer.Panel2.Controls.Add(this.lbLogConsume);
            this.splitContainer.Panel2.Controls.Add(this.tbConsumeMSec);
            this.splitContainer.Panel2.Controls.Add(this.tbConsumeMax);
            this.splitContainer.Panel2.Controls.Add(this.lblConsumeMSec);
            this.splitContainer.Panel2.Controls.Add(this.lblConsumeMax);
            this.splitContainer.Panel2.Controls.Add(this.btnConsumeCancel);
            this.splitContainer.Panel2.Controls.Add(this.btnConsume);
            this.splitContainer.Size = new System.Drawing.Size(1082, 453);
            this.splitContainer.SplitterDistance = 541;
            this.splitContainer.TabIndex = 0;
            // 
            // tbProduceMSec
            // 
            this.tbProduceMSec.Location = new System.Drawing.Point(172, 13);
            this.tbProduceMSec.Name = "tbProduceMSec";
            this.tbProduceMSec.Size = new System.Drawing.Size(50, 27);
            this.tbProduceMSec.TabIndex = 6;
            // 
            // tbProduceMax
            // 
            this.tbProduceMax.Location = new System.Drawing.Point(55, 13);
            this.tbProduceMax.Name = "tbProduceMax";
            this.tbProduceMax.Size = new System.Drawing.Size(50, 27);
            this.tbProduceMax.TabIndex = 5;
            // 
            // lblProduceMSec
            // 
            this.lblProduceMSec.AutoSize = true;
            this.lblProduceMSec.Location = new System.Drawing.Point(121, 16);
            this.lblProduceMSec.Name = "lblProduceMSec";
            this.lblProduceMSec.Size = new System.Drawing.Size(45, 20);
            this.lblProduceMSec.TabIndex = 4;
            this.lblProduceMSec.Text = "mSec";
            // 
            // lblProduceMax
            // 
            this.lblProduceMax.AutoSize = true;
            this.lblProduceMax.Location = new System.Drawing.Point(12, 16);
            this.lblProduceMax.Name = "lblProduceMax";
            this.lblProduceMax.Size = new System.Drawing.Size(37, 20);
            this.lblProduceMax.TabIndex = 3;
            this.lblProduceMax.Text = "Max";
            // 
            // lbLogProduce
            // 
            this.lbLogProduce.FormattingEnabled = true;
            this.lbLogProduce.ItemHeight = 20;
            this.lbLogProduce.Location = new System.Drawing.Point(3, 70);
            this.lbLogProduce.Name = "lbLogProduce";
            this.lbLogProduce.Size = new System.Drawing.Size(535, 364);
            this.lbLogProduce.TabIndex = 2;
            // 
            // btnProduceCancel
            // 
            this.btnProduceCancel.Location = new System.Drawing.Point(380, 12);
            this.btnProduceCancel.Name = "btnProduceCancel";
            this.btnProduceCancel.Size = new System.Drawing.Size(94, 29);
            this.btnProduceCancel.TabIndex = 1;
            this.btnProduceCancel.Text = "Cancel";
            this.btnProduceCancel.UseVisualStyleBackColor = true;
            this.btnProduceCancel.Click += new System.EventHandler(this.BtnProduceCancelClick);
            // 
            // btnProduce
            // 
            this.btnProduce.Location = new System.Drawing.Point(262, 12);
            this.btnProduce.Name = "btnProduce";
            this.btnProduce.Size = new System.Drawing.Size(94, 29);
            this.btnProduce.TabIndex = 0;
            this.btnProduce.Text = "Produce";
            this.btnProduce.UseVisualStyleBackColor = true;
            this.btnProduce.Click += new System.EventHandler(this.BtnProduceClick);
            // 
            // btnConsume
            // 
            this.btnConsume.Location = new System.Drawing.Point(331, 13);
            this.btnConsume.Name = "btnConsume";
            this.btnConsume.Size = new System.Drawing.Size(94, 29);
            this.btnConsume.TabIndex = 1;
            this.btnConsume.Text = "Consume";
            this.btnConsume.UseVisualStyleBackColor = true;
            this.btnConsume.Click += new System.EventHandler(this.BtnConsumeClick);
            // 
            // btnConsumeCancel
            // 
            this.btnConsumeCancel.Location = new System.Drawing.Point(431, 14);
            this.btnConsumeCancel.Name = "btnConsumeCancel";
            this.btnConsumeCancel.Size = new System.Drawing.Size(94, 29);
            this.btnConsumeCancel.TabIndex = 2;
            this.btnConsumeCancel.Text = "Cancel";
            this.btnConsumeCancel.UseVisualStyleBackColor = true;
            this.btnConsumeCancel.Click += new System.EventHandler(this.BtnConsumeCancelClick);
            // 
            // tbConsumeMSec
            // 
            this.tbConsumeMSec.Location = new System.Drawing.Point(275, 15);
            this.tbConsumeMSec.Name = "tbConsumeMSec";
            this.tbConsumeMSec.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMSec.TabIndex = 10;
            // 
            // tbConsumeMax
            // 
            this.tbConsumeMax.Location = new System.Drawing.Point(168, 15);
            this.tbConsumeMax.Name = "tbConsumeMax";
            this.tbConsumeMax.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMax.TabIndex = 9;
            // 
            // lblConsumeMSec
            // 
            this.lblConsumeMSec.AutoSize = true;
            this.lblConsumeMSec.Location = new System.Drawing.Point(224, 18);
            this.lblConsumeMSec.Name = "lblConsumeMSec";
            this.lblConsumeMSec.Size = new System.Drawing.Size(45, 20);
            this.lblConsumeMSec.TabIndex = 8;
            this.lblConsumeMSec.Text = "mSec";
            // 
            // lblConsumeMax
            // 
            this.lblConsumeMax.AutoSize = true;
            this.lblConsumeMax.Location = new System.Drawing.Point(125, 18);
            this.lblConsumeMax.Name = "lblConsumeMax";
            this.lblConsumeMax.Size = new System.Drawing.Size(37, 20);
            this.lblConsumeMax.TabIndex = 7;
            this.lblConsumeMax.Text = "Max";
            // 
            // lbLogConsume
            // 
            this.lbLogConsume.FormattingEnabled = true;
            this.lbLogConsume.ItemHeight = 20;
            this.lbLogConsume.Location = new System.Drawing.Point(-1, 70);
            this.lbLogConsume.Name = "lbLogConsume";
            this.lbLogConsume.Size = new System.Drawing.Size(535, 364);
            this.lbLogConsume.TabIndex = 11;
            // 
            // tbConsumeMin
            // 
            this.tbConsumeMin.Location = new System.Drawing.Point(69, 16);
            this.tbConsumeMin.Name = "tbConsumeMin";
            this.tbConsumeMin.Size = new System.Drawing.Size(50, 27);
            this.tbConsumeMin.TabIndex = 13;
            // 
            // lblConsumeMin
            // 
            this.lblConsumeMin.AutoSize = true;
            this.lblConsumeMin.Location = new System.Drawing.Point(12, 20);
            this.lblConsumeMin.Name = "lblConsumeMin";
            this.lblConsumeMin.Size = new System.Drawing.Size(34, 20);
            this.lblConsumeMin.TabIndex = 12;
            this.lblConsumeMin.Text = "Min";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 453);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnProduce;
        private System.Windows.Forms.Button btnProduceCancel;
        private System.Windows.Forms.ListBox lbLogProduce;
        private System.Windows.Forms.Button btnConsume;
        private System.Windows.Forms.TextBox tbProduceMSec;
        private System.Windows.Forms.TextBox tbProduceMax;
        private System.Windows.Forms.Label lblProduceMSec;
        private System.Windows.Forms.Label lblProduceMax;
        private System.Windows.Forms.ListBox lbLogConsume;
        private System.Windows.Forms.TextBox tbConsumeMSec;
        private System.Windows.Forms.TextBox tbConsumeMax;
        private System.Windows.Forms.Label lblConsumeMSec;
        private System.Windows.Forms.Label lblConsumeMax;
        private System.Windows.Forms.Button btnConsumeCancel;
        private System.Windows.Forms.TextBox tbConsumeMin;
        private System.Windows.Forms.Label lblConsumeMin;
    }
}

