namespace WinFormsApp2
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
            if (disposing)
            {
                if (_childFormModal != null)
                    _childFormModal.Dispose();

                if ((components != null))
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox12 = new System.Windows.Forms.ListBox();
            this.listBox11 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonShowModal = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonWithOptions = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonInvoke = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
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
            this.tabControl.Size = new System.Drawing.Size(984, 431);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox12);
            this.tabPage1.Controls.Add(this.listBox11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 405);
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
            this.listBox12.Size = new System.Drawing.Size(470, 399);
            this.listBox12.TabIndex = 1;
            // 
            // listBox11
            // 
            this.listBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox11.FormattingEnabled = true;
            this.listBox11.Location = new System.Drawing.Point(3, 3);
            this.listBox11.Name = "listBox11";
            this.listBox11.Size = new System.Drawing.Size(500, 399);
            this.listBox11.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 405);
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
            this.listBox2.Size = new System.Drawing.Size(970, 399);
            this.listBox2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(976, 405);
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
            this.listBox3.Size = new System.Drawing.Size(976, 405);
            this.listBox3.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonClear);
            this.panelBottom.Controls.Add(this.buttonShowModal);
            this.panelBottom.Controls.Add(this.buttonShow);
            this.panelBottom.Controls.Add(this.buttonWithOptions);
            this.panelBottom.Controls.Add(this.buttonSend);
            this.panelBottom.Controls.Add(this.buttonPost);
            this.panelBottom.Controls.Add(this.buttonInvoke);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 431);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(984, 30);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonShowModal
            // 
            this.buttonShowModal.Location = new System.Drawing.Point(664, 1);
            this.buttonShowModal.Name = "buttonShowModal";
            this.buttonShowModal.Size = new System.Drawing.Size(100, 23);
            this.buttonShowModal.TabIndex = 5;
            this.buttonShowModal.Text = "Show (Modal)";
            this.buttonShowModal.UseVisualStyleBackColor = true;
            this.buttonShowModal.Click += new System.EventHandler(this.buttonShowModal_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(553, 1);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(100, 23);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonWithOptions
            // 
            this.buttonWithOptions.Location = new System.Drawing.Point(442, 1);
            this.buttonWithOptions.Name = "buttonWithOptions";
            this.buttonWithOptions.Size = new System.Drawing.Size(100, 23);
            this.buttonWithOptions.TabIndex = 3;
            this.buttonWithOptions.Text = "With Options";
            this.buttonWithOptions.UseVisualStyleBackColor = true;
            this.buttonWithOptions.Click += new System.EventHandler(this.buttonWithOptions_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(331, 1);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(100, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(220, 1);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(100, 23);
            this.buttonPost.TabIndex = 1;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonInvoke
            // 
            this.buttonInvoke.Location = new System.Drawing.Point(109, 1);
            this.buttonInvoke.Name = "buttonInvoke";
            this.buttonInvoke.Size = new System.Drawing.Size(100, 23);
            this.buttonInvoke.TabIndex = 0;
            this.buttonInvoke.Text = "Invoke";
            this.buttonInvoke.UseVisualStyleBackColor = true;
            this.buttonInvoke.Click += new System.EventHandler(this.buttonInvoke_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(775, 1);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ListBox listBox12;
        public System.Windows.Forms.ListBox listBox11;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button buttonInvoke;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonWithOptions;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonShowModal;
        private System.Windows.Forms.Button buttonClear;
    }
}

