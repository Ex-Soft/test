namespace TestWindow
{
    partial class ModalForm
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
            this.checkBoxCancel = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSetOk = new System.Windows.Forms.Button();
            this.buttonSetNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCancel
            // 
            this.checkBoxCancel.AutoSize = true;
            this.checkBoxCancel.Location = new System.Drawing.Point(64, 12);
            this.checkBoxCancel.Name = "checkBoxCancel";
            this.checkBoxCancel.Size = new System.Drawing.Size(59, 17);
            this.checkBoxCancel.TabIndex = 0;
            this.checkBoxCancel.Text = "Cancel";
            this.checkBoxCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(56, 50);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(56, 79);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSetOk
            // 
            this.buttonSetOk.Location = new System.Drawing.Point(56, 108);
            this.buttonSetOk.Name = "buttonSetOk";
            this.buttonSetOk.Size = new System.Drawing.Size(75, 23);
            this.buttonSetOk.TabIndex = 3;
            this.buttonSetOk.Text = "Set OK";
            this.buttonSetOk.UseVisualStyleBackColor = true;
            this.buttonSetOk.Click += new System.EventHandler(this.ButtonSetOkClick);
            // 
            // buttonSetNone
            // 
            this.buttonSetNone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSetNone.Location = new System.Drawing.Point(56, 137);
            this.buttonSetNone.Name = "buttonSetNone";
            this.buttonSetNone.Size = new System.Drawing.Size(75, 23);
            this.buttonSetNone.TabIndex = 4;
            this.buttonSetNone.Text = "Set None";
            this.buttonSetNone.UseVisualStyleBackColor = true;
            this.buttonSetNone.Click += new System.EventHandler(this.ButtonSetNoneClick);
            // 
            // ModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 176);
            this.Controls.Add(this.buttonSetNone);
            this.Controls.Add(this.buttonSetOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.checkBoxCancel);
            this.Name = "ModalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModalForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModalFormFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSetOk;
        private System.Windows.Forms.Button buttonSetNone;
    }
}