namespace TestLayout
{
    partial class TestDEControlsForm
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
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lblDown = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.lblUp = new DevExpress.XtraEditors.LabelControl();
            this.ceLblOnOff = new DevExpress.XtraEditors.CheckEdit();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLblOnOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(0, 5);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.AutoWidth = true;
            this.checkEdit1.Properties.Caption = "checkEdit1";
            this.checkEdit1.Size = new System.Drawing.Size(74, 19);
            this.checkEdit1.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(0, 35);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // lblDown
            // 
            this.lblDown.Location = new System.Drawing.Point(10, 60);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(37, 13);
            this.lblDown.TabIndex = 2;
            this.lblDown.Text = "lblDown";
            // 
            // timeEdit
            // 
            this.timeEdit.EditValue = new System.DateTime(2013, 10, 17, 0, 0, 0, 0);
            this.timeEdit.Location = new System.Drawing.Point(55, 58);
            this.timeEdit.Name = "timeEdit";
            this.timeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit.Size = new System.Drawing.Size(100, 20);
            this.timeEdit.TabIndex = 3;
            // 
            // lblUp
            // 
            this.lblUp.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUp.Location = new System.Drawing.Point(10, 58);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(200, 20);
            this.lblUp.TabIndex = 4;
            this.lblUp.Text = "lblUp";
            this.lblUp.Visible = false;
            // 
            // ceLblOnOff
            // 
            this.ceLblOnOff.Location = new System.Drawing.Point(12, 84);
            this.ceLblOnOff.Name = "ceLblOnOff";
            this.ceLblOnOff.Properties.Caption = "On/Off";
            this.ceLblOnOff.Size = new System.Drawing.Size(74, 19);
            this.ceLblOnOff.TabIndex = 5;
            this.ceLblOnOff.CheckedChanged += new System.EventHandler(this.ceLblOnOff_CheckedChanged);
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(2, 123);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit.Size = new System.Drawing.Size(100, 20);
            this.dateEdit.TabIndex = 6;
            this.dateEdit.EditValueChanged += new System.EventHandler(this.dateEdit_EditValueChanged);
            this.dateEdit.Validating += new System.ComponentModel.CancelEventHandler(this.dateEdit_Validating);
            // 
            // TestDEControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dateEdit);
            this.Controls.Add(this.ceLblOnOff);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.timeEdit);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.checkEdit1);
            this.Name = "TestDEControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestDEControlsForm (caption)";
            this.Load += new System.EventHandler(this.TestDEControlsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLblOnOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl lblDown;
        private DevExpress.XtraEditors.TimeEdit timeEdit;
        private DevExpress.XtraEditors.LabelControl lblUp;
        private DevExpress.XtraEditors.CheckEdit ceLblOnOff;
        private DevExpress.XtraEditors.DateEdit dateEdit;
    }
}