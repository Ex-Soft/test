using System.Windows.Forms;

namespace TestUserControl
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
            this.btnSet = new System.Windows.Forms.Button();
            this.gbMainForm = new System.Windows.Forms.GroupBox();
            this.tbSlave = new System.Windows.Forms.TextBox();
            this.tbMaster = new System.Windows.Forms.TextBox();
            this.lblSlave = new System.Windows.Forms.Label();
            this.lblMaster = new System.Windows.Forms.Label();
            this.gbUserControl = new System.Windows.Forms.GroupBox();
            this.testUserControl = new TestUserControl();
            this.tbSet = new System.Windows.Forms.TextBox();
            this.gbMainForm.SuspendLayout();
            this.gbUserControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(27, 129);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSetClick);
            // 
            // gbMainForm
            // 
            this.gbMainForm.Controls.Add(this.tbSlave);
            this.gbMainForm.Controls.Add(this.tbMaster);
            this.gbMainForm.Controls.Add(this.lblSlave);
            this.gbMainForm.Controls.Add(this.lblMaster);
            this.gbMainForm.Location = new System.Drawing.Point(5, 5);
            this.gbMainForm.Name = "gbMainForm";
            this.gbMainForm.Size = new System.Drawing.Size(350, 100);
            this.gbMainForm.TabIndex = 6;
            this.gbMainForm.TabStop = false;
            this.gbMainForm.Text = "MainForm";
            // 
            // tbSlave
            // 
            this.tbSlave.Location = new System.Drawing.Point(75, 56);
            this.tbSlave.Name = "tbSlave";
            this.tbSlave.Size = new System.Drawing.Size(250, 20);
            this.tbSlave.TabIndex = 8;
            // 
            // tbMaster
            // 
            this.tbMaster.Location = new System.Drawing.Point(75, 25);
            this.tbMaster.Name = "tbMaster";
            this.tbMaster.Size = new System.Drawing.Size(250, 20);
            this.tbMaster.TabIndex = 7;
            // 
            // lblSlave
            // 
            this.lblSlave.AutoSize = true;
            this.lblSlave.Location = new System.Drawing.Point(19, 56);
            this.lblSlave.Name = "lblSlave";
            this.lblSlave.Size = new System.Drawing.Size(34, 13);
            this.lblSlave.TabIndex = 6;
            this.lblSlave.Text = "Slave";
            // 
            // lblMaster
            // 
            this.lblMaster.AutoSize = true;
            this.lblMaster.Location = new System.Drawing.Point(19, 25);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(39, 13);
            this.lblMaster.TabIndex = 5;
            this.lblMaster.Text = "Master";
            // 
            // gbUserControl
            // 
            this.gbUserControl.Controls.Add(this.testUserControl);
            this.gbUserControl.Location = new System.Drawing.Point(367, 5);
            this.gbUserControl.Name = "gbUserControl";
            this.gbUserControl.Size = new System.Drawing.Size(348, 100);
            this.gbUserControl.TabIndex = 7;
            this.gbUserControl.TabStop = false;
            this.gbUserControl.Text = "UserControl";
            // 
            // testUserControl
            // 
            this.testUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testUserControl.Location = new System.Drawing.Point(3, 16);
            this.testUserControl.Master = null;
            this.testUserControl.Name = "testUserControl";
            this.testUserControl.Size = new System.Drawing.Size(342, 81);
            this.testUserControl.Slave = null;
            this.testUserControl.TabIndex = 1;
            // 
            // tbSet
            // 
            this.tbSet.Location = new System.Drawing.Point(123, 129);
            this.tbSet.Name = "tbSet";
            this.tbSet.Size = new System.Drawing.Size(250, 20);
            this.tbSet.TabIndex = 8;
            this.tbSet.Text = "From UserControl";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 176);
            this.Controls.Add(this.tbSet);
            this.Controls.Add(this.gbUserControl);
            this.Controls.Add(this.gbMainForm);
            this.Controls.Add(this.btnSet);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.gbMainForm.ResumeLayout(false);
            this.gbMainForm.PerformLayout();
            this.gbUserControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSet;
        private GroupBox gbMainForm;
        private TextBox tbSlave;
        private TextBox tbMaster;
        private Label lblSlave;
        private Label lblMaster;
        private GroupBox gbUserControl;
        private TestUserControl testUserControl;
        private TextBox tbSet;
    }
}

