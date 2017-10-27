namespace WinFormsApp2
{
    partial class ChildFormModal
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
            var msg = $"{System.DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{System.Reflection.MethodBase.GetCurrentMethod().Name}({disposing}) (Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId})";
            System.Diagnostics.Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));

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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.buttonWithOptions = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonInvoke = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox12 = new WinFormsApp2.CustomListBox();
            this.listBox11 = new WinFormsApp2.CustomListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox2 = new WinFormsApp2.CustomListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox3 = new WinFormsApp2.CustomListBox();
            this.radioButtonPost = new System.Windows.Forms.RadioButton();
            this.radioButtonSend = new System.Windows.Forms.RadioButton();
            this.radioButtonWithOptions = new System.Windows.Forms.RadioButton();
            this.panelBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.radioButtonWithOptions);
            this.panelBottom.Controls.Add(this.radioButtonSend);
            this.panelBottom.Controls.Add(this.radioButtonPost);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnOk);
            this.panelBottom.Controls.Add(this.buttonWithOptions);
            this.panelBottom.Controls.Add(this.buttonSend);
            this.panelBottom.Controls.Add(this.buttonPost);
            this.panelBottom.Controls.Add(this.buttonInvoke);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 201);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(984, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(722, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(610, 1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // buttonWithOptions
            // 
            this.buttonWithOptions.Location = new System.Drawing.Point(498, 1);
            this.buttonWithOptions.Name = "buttonWithOptions";
            this.buttonWithOptions.Size = new System.Drawing.Size(100, 23);
            this.buttonWithOptions.TabIndex = 3;
            this.buttonWithOptions.Text = "With Options";
            this.buttonWithOptions.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(386, 1);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(100, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(274, 1);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(100, 23);
            this.buttonPost.TabIndex = 1;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            // 
            // buttonInvoke
            // 
            this.buttonInvoke.Location = new System.Drawing.Point(162, 1);
            this.buttonInvoke.Name = "buttonInvoke";
            this.buttonInvoke.Size = new System.Drawing.Size(100, 23);
            this.buttonInvoke.TabIndex = 0;
            this.buttonInvoke.Text = "Invoke";
            this.buttonInvoke.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 201);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox12);
            this.tabPage1.Controls.Add(this.listBox11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox12
            // 
            this.listBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox12.FormattingEnabled = true;
            this.listBox12.Location = new System.Drawing.Point(503, 3);
            this.listBox12.Name = "listBox12";
            this.listBox12.Size = new System.Drawing.Size(470, 169);
            this.listBox12.TabIndex = 1;
            // 
            // listBox11
            // 
            this.listBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox11.FormattingEnabled = true;
            this.listBox11.Location = new System.Drawing.Point(3, 3);
            this.listBox11.Name = "listBox11";
            this.listBox11.Size = new System.Drawing.Size(500, 169);
            this.listBox11.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(970, 199);
            this.listBox2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(976, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(0, 0);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(976, 205);
            this.listBox3.TabIndex = 0;
            // 
            // radioButtonPost
            // 
            this.radioButtonPost.Checked = true;
            this.radioButtonPost.Location = new System.Drawing.Point(294, 31);
            this.radioButtonPost.Name = "radioButtonPost";
            this.radioButtonPost.Size = new System.Drawing.Size(100, 17);
            this.radioButtonPost.TabIndex = 6;
            this.radioButtonPost.Text = "Post";
            this.radioButtonPost.UseVisualStyleBackColor = true;
            // 
            // radioButtonSend
            // 
            this.radioButtonSend.Location = new System.Drawing.Point(442, 31);
            this.radioButtonSend.Name = "radioButtonSend";
            this.radioButtonSend.Size = new System.Drawing.Size(100, 17);
            this.radioButtonSend.TabIndex = 7;
            this.radioButtonSend.Text = "Send";
            this.radioButtonSend.UseVisualStyleBackColor = true;
            // 
            // radioButtonWithOptions
            // 
            this.radioButtonWithOptions.Location = new System.Drawing.Point(590, 31);
            this.radioButtonWithOptions.Name = "radioButtonWithOptions";
            this.radioButtonWithOptions.Size = new System.Drawing.Size(100, 17);
            this.radioButtonWithOptions.TabIndex = 8;
            this.radioButtonWithOptions.Text = "With Options";
            this.radioButtonWithOptions.UseVisualStyleBackColor = true;
            // 
            // ChildFormModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 261);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.Name = "ChildFormModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChildFormModal";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ChildFormModal_Closing);
            this.Closed += new System.EventHandler(this.ChildFormModal_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildFormModal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChildFormModal_FormClosed);
            this.Disposed += new System.EventHandler(this.ChildFormModal_Disposed);
            this.panelBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button buttonWithOptions;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonInvoke;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private WinFormsApp2.CustomListBox listBox12;
        private WinFormsApp2.CustomListBox listBox11;
        private System.Windows.Forms.TabPage tabPage2;
        private WinFormsApp2.CustomListBox listBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private WinFormsApp2.CustomListBox listBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton radioButtonWithOptions;
        private System.Windows.Forms.RadioButton radioButtonSend;
        private System.Windows.Forms.RadioButton radioButtonPost;
    }
}