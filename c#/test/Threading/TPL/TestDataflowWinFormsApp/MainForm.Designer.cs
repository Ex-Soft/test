
namespace TestDataflowWinFormsApp
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
            this.tpMix = new System.Windows.Forms.TabPage();
            this.scMix = new System.Windows.Forms.SplitContainer();
            this.btnClearMix = new System.Windows.Forms.Button();
            this.cbThrowExceptionMix = new System.Windows.Forms.CheckBox();
            this.btnPostMix = new System.Windows.Forms.Button();
            this.btnCancelMix = new System.Windows.Forms.Button();
            this.btnProduceMix = new System.Windows.Forms.Button();
            this.lbLogMix = new System.Windows.Forms.ListBox();
            this.tpPipeline = new System.Windows.Forms.TabPage();
            this.scPipeline = new System.Windows.Forms.SplitContainer();
            this.btnPostPipeline = new System.Windows.Forms.Button();
            this.cbThrowExceptionPipeline = new System.Windows.Forms.CheckBox();
            this.btnCancelPipeline = new System.Windows.Forms.Button();
            this.btnProducePipeline = new System.Windows.Forms.Button();
            this.lbLogPipeline = new System.Windows.Forms.ListBox();
            this.btnClearPipeline = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpMix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMix)).BeginInit();
            this.scMix.Panel1.SuspendLayout();
            this.scMix.Panel2.SuspendLayout();
            this.scMix.SuspendLayout();
            this.tpPipeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPipeline)).BeginInit();
            this.scPipeline.Panel1.SuspendLayout();
            this.scPipeline.Panel2.SuspendLayout();
            this.scPipeline.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMix);
            this.tabControl.Controls.Add(this.tpPipeline);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tpMix
            // 
            this.tpMix.Controls.Add(this.scMix);
            this.tpMix.Location = new System.Drawing.Point(4, 29);
            this.tpMix.Name = "tpMix";
            this.tpMix.Padding = new System.Windows.Forms.Padding(3);
            this.tpMix.Size = new System.Drawing.Size(792, 417);
            this.tpMix.TabIndex = 0;
            this.tpMix.Text = "Mix";
            this.tpMix.UseVisualStyleBackColor = true;
            // 
            // scMix
            // 
            this.scMix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMix.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMix.Location = new System.Drawing.Point(3, 3);
            this.scMix.Name = "scMix";
            this.scMix.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMix.Panel1
            // 
            this.scMix.Panel1.Controls.Add(this.btnClearMix);
            this.scMix.Panel1.Controls.Add(this.cbThrowExceptionMix);
            this.scMix.Panel1.Controls.Add(this.btnPostMix);
            this.scMix.Panel1.Controls.Add(this.btnCancelMix);
            this.scMix.Panel1.Controls.Add(this.btnProduceMix);
            // 
            // scMix.Panel2
            // 
            this.scMix.Panel2.Controls.Add(this.lbLogMix);
            this.scMix.Size = new System.Drawing.Size(786, 411);
            this.scMix.TabIndex = 0;
            // 
            // btnClearMix
            // 
            this.btnClearMix.Location = new System.Drawing.Point(500, 11);
            this.btnClearMix.Name = "btnClearMix";
            this.btnClearMix.Size = new System.Drawing.Size(94, 29);
            this.btnClearMix.TabIndex = 8;
            this.btnClearMix.Tag = "Mix";
            this.btnClearMix.Text = "Clear";
            this.btnClearMix.UseVisualStyleBackColor = true;
            this.btnClearMix.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // cbThrowExceptionMix
            // 
            this.cbThrowExceptionMix.AutoSize = true;
            this.cbThrowExceptionMix.Location = new System.Drawing.Point(16, 13);
            this.cbThrowExceptionMix.Name = "cbThrowExceptionMix";
            this.cbThrowExceptionMix.Size = new System.Drawing.Size(141, 24);
            this.cbThrowExceptionMix.TabIndex = 7;
            this.cbThrowExceptionMix.Text = "Throw Exception";
            this.cbThrowExceptionMix.UseVisualStyleBackColor = true;
            // 
            // btnPostMix
            // 
            this.btnPostMix.Location = new System.Drawing.Point(200, 11);
            this.btnPostMix.Name = "btnPostMix";
            this.btnPostMix.Size = new System.Drawing.Size(94, 29);
            this.btnPostMix.TabIndex = 6;
            this.btnPostMix.Text = "Post";
            this.btnPostMix.UseVisualStyleBackColor = true;
            this.btnPostMix.Click += new System.EventHandler(this.BtnPostMixClick);
            // 
            // btnCancelMix
            // 
            this.btnCancelMix.Location = new System.Drawing.Point(400, 11);
            this.btnCancelMix.Name = "btnCancelMix";
            this.btnCancelMix.Size = new System.Drawing.Size(94, 29);
            this.btnCancelMix.TabIndex = 5;
            this.btnCancelMix.Text = "Cancel";
            this.btnCancelMix.UseVisualStyleBackColor = true;
            this.btnCancelMix.Click += new System.EventHandler(this.BtnCancelMixClick);
            // 
            // btnProduceMix
            // 
            this.btnProduceMix.Location = new System.Drawing.Point(300, 11);
            this.btnProduceMix.Name = "btnProduceMix";
            this.btnProduceMix.Size = new System.Drawing.Size(94, 29);
            this.btnProduceMix.TabIndex = 4;
            this.btnProduceMix.Text = "Produce";
            this.btnProduceMix.UseVisualStyleBackColor = true;
            this.btnProduceMix.Click += new System.EventHandler(this.BtnProduceMixClick);
            // 
            // lbLogMix
            // 
            this.lbLogMix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogMix.FormattingEnabled = true;
            this.lbLogMix.ItemHeight = 20;
            this.lbLogMix.Location = new System.Drawing.Point(0, 0);
            this.lbLogMix.Name = "lbLogMix";
            this.lbLogMix.Size = new System.Drawing.Size(784, 355);
            this.lbLogMix.TabIndex = 0;
            // 
            // tpPipeline
            // 
            this.tpPipeline.Controls.Add(this.scPipeline);
            this.tpPipeline.Location = new System.Drawing.Point(4, 29);
            this.tpPipeline.Name = "tpPipeline";
            this.tpPipeline.Padding = new System.Windows.Forms.Padding(3);
            this.tpPipeline.Size = new System.Drawing.Size(792, 417);
            this.tpPipeline.TabIndex = 1;
            this.tpPipeline.Text = "Pipeline";
            this.tpPipeline.UseVisualStyleBackColor = true;
            // 
            // scPipeline
            // 
            this.scPipeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scPipeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPipeline.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scPipeline.Location = new System.Drawing.Point(3, 3);
            this.scPipeline.Name = "scPipeline";
            this.scPipeline.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scPipeline.Panel1
            // 
            this.scPipeline.Panel1.Controls.Add(this.btnClearPipeline);
            this.scPipeline.Panel1.Controls.Add(this.btnPostPipeline);
            this.scPipeline.Panel1.Controls.Add(this.cbThrowExceptionPipeline);
            this.scPipeline.Panel1.Controls.Add(this.btnCancelPipeline);
            this.scPipeline.Panel1.Controls.Add(this.btnProducePipeline);
            // 
            // scPipeline.Panel2
            // 
            this.scPipeline.Panel2.Controls.Add(this.lbLogPipeline);
            this.scPipeline.Size = new System.Drawing.Size(786, 411);
            this.scPipeline.TabIndex = 1;
            // 
            // btnPostPipeline
            // 
            this.btnPostPipeline.Location = new System.Drawing.Point(200, 11);
            this.btnPostPipeline.Name = "btnPostPipeline";
            this.btnPostPipeline.Size = new System.Drawing.Size(94, 29);
            this.btnPostPipeline.TabIndex = 8;
            this.btnPostPipeline.Text = "Post";
            this.btnPostPipeline.UseVisualStyleBackColor = true;
            this.btnPostPipeline.Click += new System.EventHandler(this.BtnPostPipelineClick);
            // 
            // cbThrowExceptionPipeline
            // 
            this.cbThrowExceptionPipeline.AutoSize = true;
            this.cbThrowExceptionPipeline.Location = new System.Drawing.Point(16, 13);
            this.cbThrowExceptionPipeline.Name = "cbThrowExceptionPipeline";
            this.cbThrowExceptionPipeline.Size = new System.Drawing.Size(141, 24);
            this.cbThrowExceptionPipeline.TabIndex = 7;
            this.cbThrowExceptionPipeline.Text = "Throw Exception";
            this.cbThrowExceptionPipeline.UseVisualStyleBackColor = true;
            // 
            // btnCancelPipeline
            // 
            this.btnCancelPipeline.Location = new System.Drawing.Point(400, 11);
            this.btnCancelPipeline.Name = "btnCancelPipeline";
            this.btnCancelPipeline.Size = new System.Drawing.Size(94, 29);
            this.btnCancelPipeline.TabIndex = 5;
            this.btnCancelPipeline.Text = "Cancel";
            this.btnCancelPipeline.UseVisualStyleBackColor = true;
            this.btnCancelPipeline.Click += new System.EventHandler(this.BtnCancelPipelineClick);
            // 
            // btnProducePipeline
            // 
            this.btnProducePipeline.Location = new System.Drawing.Point(300, 11);
            this.btnProducePipeline.Name = "btnProducePipeline";
            this.btnProducePipeline.Size = new System.Drawing.Size(94, 29);
            this.btnProducePipeline.TabIndex = 4;
            this.btnProducePipeline.Text = "Produce";
            this.btnProducePipeline.UseVisualStyleBackColor = true;
            this.btnProducePipeline.Click += new System.EventHandler(this.BtnProducePipelineClick);
            // 
            // lbLogPipeline
            // 
            this.lbLogPipeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogPipeline.FormattingEnabled = true;
            this.lbLogPipeline.ItemHeight = 20;
            this.lbLogPipeline.Location = new System.Drawing.Point(0, 0);
            this.lbLogPipeline.Name = "lbLogPipeline";
            this.lbLogPipeline.Size = new System.Drawing.Size(784, 355);
            this.lbLogPipeline.TabIndex = 0;
            // 
            // btnClearPipeline
            // 
            this.btnClearPipeline.Location = new System.Drawing.Point(500, 11);
            this.btnClearPipeline.Name = "btnClearPipeline";
            this.btnClearPipeline.Size = new System.Drawing.Size(94, 29);
            this.btnClearPipeline.TabIndex = 9;
            this.btnClearPipeline.Tag = "Pipeline";
            this.btnClearPipeline.Text = "Clear";
            this.btnClearPipeline.UseVisualStyleBackColor = true;
            this.btnClearPipeline.Click += new System.EventHandler(this.BtnClearClick);
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
            this.tpMix.ResumeLayout(false);
            this.scMix.Panel1.ResumeLayout(false);
            this.scMix.Panel1.PerformLayout();
            this.scMix.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMix)).EndInit();
            this.scMix.ResumeLayout(false);
            this.tpPipeline.ResumeLayout(false);
            this.scPipeline.Panel1.ResumeLayout(false);
            this.scPipeline.Panel1.PerformLayout();
            this.scPipeline.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPipeline)).EndInit();
            this.scPipeline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMix;
        private System.Windows.Forms.TabPage tpPipeline;
        private System.Windows.Forms.SplitContainer scMix;
        private System.Windows.Forms.CheckBox cbThrowExceptionMix;
        private System.Windows.Forms.Button btnPostMix;
        private System.Windows.Forms.Button btnCancelMix;
        private System.Windows.Forms.Button btnProduceMix;
        private System.Windows.Forms.ListBox lbLogMix;
        private System.Windows.Forms.SplitContainer scPipeline;
        private System.Windows.Forms.CheckBox cbThrowExceptionPipeline;
        private System.Windows.Forms.Button btnCancelPipeline;
        private System.Windows.Forms.Button btnProducePipeline;
        private System.Windows.Forms.ListBox lbLogPipeline;
        private System.Windows.Forms.Button btnPostPipeline;
        private System.Windows.Forms.Button btnClearMix;
        private System.Windows.Forms.Button btnClearPipeline;
    }
}

