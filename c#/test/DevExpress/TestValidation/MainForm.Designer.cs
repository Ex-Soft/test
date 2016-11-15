namespace TestValidation
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
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.checkEditBuffered = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonClearLog = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControlLog = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBuffered.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(13, 13);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit.Size = new System.Drawing.Size(100, 20);
            this.dateEdit.TabIndex = 0;
            this.dateEdit.DateTimeChanged += new System.EventHandler(this.dateEdit_DateTimeChanged);
            this.dateEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.dateEdit_CloseUp);
            this.dateEdit.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.dateEdit_Closed);
            this.dateEdit.EditValueChanged += new System.EventHandler(this.dateEdit_EditValueChanged);
            this.dateEdit.Modified += new System.EventHandler(this.dateEdit_Modified);
            this.dateEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateEdit_EditValueChanging);
            this.dateEdit.Validating += new System.ComponentModel.CancelEventHandler(this.dateEdit_Validating);
            this.dateEdit.Validated += new System.EventHandler(this.dateEdit_Validated);
            // 
            // checkEditBuffered
            // 
            this.checkEditBuffered.Location = new System.Drawing.Point(119, 14);
            this.checkEditBuffered.Name = "checkEditBuffered";
            this.checkEditBuffered.Properties.Caption = "Buffered";
            this.checkEditBuffered.Size = new System.Drawing.Size(75, 19);
            this.checkEditBuffered.TabIndex = 1;
            this.checkEditBuffered.CheckedChanged += new System.EventHandler(this.checkEditBuffered_CheckedChanged);
            // 
            // simpleButtonClearLog
            // 
            this.simpleButtonClearLog.Location = new System.Drawing.Point(201, 13);
            this.simpleButtonClearLog.Name = "simpleButtonClearLog";
            this.simpleButtonClearLog.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonClearLog.TabIndex = 2;
            this.simpleButtonClearLog.Text = "ClearLog";
            this.simpleButtonClearLog.Click += new System.EventHandler(this.simpleButtonClearLog_Click);
            // 
            // listBoxControlLog
            // 
            this.listBoxControlLog.Location = new System.Drawing.Point(13, 40);
            this.listBoxControlLog.Name = "listBoxControlLog";
            this.listBoxControlLog.Size = new System.Drawing.Size(634, 639);
            this.listBoxControlLog.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 691);
            this.Controls.Add(this.listBoxControlLog);
            this.Controls.Add(this.simpleButtonClearLog);
            this.Controls.Add(this.checkEditBuffered);
            this.Controls.Add(this.dateEdit);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Validation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBuffered.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit;
        private DevExpress.XtraEditors.CheckEdit checkEditBuffered;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClearLog;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlLog;
    }
}

