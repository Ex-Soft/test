using System.Windows.Forms;

namespace TestWindow
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
            System.Diagnostics.Debug.WriteLine("MainForm: Dispose({0})", disposing);

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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.buttonDoIt = new System.Windows.Forms.Button();
            this.checkBoxModal = new System.Windows.Forms.CheckBox();
            this.checkBoxKeyPreview = new System.Windows.Forms.CheckBox();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.buttonFocus = new System.Windows.Forms.Button();
            this.buttonShowModal = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonTestModal = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPageLog);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(905, 273);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.buttonTestModal);
            this.tabPageMain.Controls.Add(this.buttonDoIt);
            this.tabPageMain.Controls.Add(this.checkBoxModal);
            this.tabPageMain.Controls.Add(this.checkBoxKeyPreview);
            this.tabPageMain.Controls.Add(this.checkBoxEnabled);
            this.tabPageMain.Controls.Add(this.buttonFocus);
            this.tabPageMain.Controls.Add(this.buttonShowModal);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(897, 247);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // buttonDoIt
            // 
            this.buttonDoIt.Location = new System.Drawing.Point(208, 8);
            this.buttonDoIt.Name = "buttonDoIt";
            this.buttonDoIt.Size = new System.Drawing.Size(75, 23);
            this.buttonDoIt.TabIndex = 4;
            this.buttonDoIt.Text = "DoIt!";
            this.buttonDoIt.UseVisualStyleBackColor = true;
            this.buttonDoIt.Click += new System.EventHandler(this.ButtonDoItClick);
            // 
            // checkBoxModal
            // 
            this.checkBoxModal.AutoSize = true;
            this.checkBoxModal.Checked = true;
            this.checkBoxModal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModal.Location = new System.Drawing.Point(8, 83);
            this.checkBoxModal.Name = "checkBoxModal";
            this.checkBoxModal.Size = new System.Drawing.Size(55, 17);
            this.checkBoxModal.TabIndex = 3;
            this.checkBoxModal.Text = "Modal";
            this.checkBoxModal.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeyPreview
            // 
            this.checkBoxKeyPreview.AutoSize = true;
            this.checkBoxKeyPreview.Checked = true;
            this.checkBoxKeyPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeyPreview.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this, "KeyPreview", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxKeyPreview.Location = new System.Drawing.Point(8, 60);
            this.checkBoxKeyPreview.Name = "checkBoxKeyPreview";
            this.checkBoxKeyPreview.Size = new System.Drawing.Size(82, 17);
            this.checkBoxKeyPreview.TabIndex = 2;
            this.checkBoxKeyPreview.Text = "KeyPreview";
            this.checkBoxKeyPreview.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(8, 37);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxEnabled.TabIndex = 1;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxEnabledCheckedChanged);
            // 
            // buttonFocus
            // 
            this.buttonFocus.Location = new System.Drawing.Point(108, 8);
            this.buttonFocus.Name = "buttonFocus";
            this.buttonFocus.Size = new System.Drawing.Size(75, 23);
            this.buttonFocus.TabIndex = 1;
            this.buttonFocus.Text = "Focus";
            this.buttonFocus.UseVisualStyleBackColor = true;
            this.buttonFocus.Click += new System.EventHandler(this.ButtonFocusClick);
            // 
            // buttonShowModal
            // 
            this.buttonShowModal.Location = new System.Drawing.Point(8, 8);
            this.buttonShowModal.Name = "buttonShowModal";
            this.buttonShowModal.Size = new System.Drawing.Size(75, 23);
            this.buttonShowModal.TabIndex = 0;
            this.buttonShowModal.Text = "Show";
            this.buttonShowModal.UseVisualStyleBackColor = true;
            this.buttonShowModal.Click += new System.EventHandler(this.ButtonShowModalClick);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.listBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(897, 247);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 3);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(891, 241);
            this.listBoxLog.TabIndex = 0;
            // 
            // buttonTestModal
            // 
            this.buttonTestModal.Location = new System.Drawing.Point(309, 7);
            this.buttonTestModal.Name = "buttonTestModal";
            this.buttonTestModal.Size = new System.Drawing.Size(75, 23);
            this.buttonTestModal.TabIndex = 5;
            this.buttonTestModal.Text = "Test Modal";
            this.buttonTestModal.UseVisualStyleBackColor = true;
            this.buttonTestModal.Click += new System.EventHandler(this.ButtonTestModalClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 273);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFormClosing);
            this.Closed += new System.EventHandler(this.MainFormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.Disposed += new System.EventHandler(this.MainFormDisposed);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageLog;
        private Button buttonShowModal;
        private ListBox listBoxLog;
        private Button buttonFocus;
        private CheckBox checkBoxEnabled;
        private CheckBox checkBoxKeyPreview;
        private CheckBox checkBoxModal;
        private Button buttonDoIt;
        private Button buttonTestModal;
    }
}

