namespace TestLockDictionaryNodeII
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
            this.btnThread1 = new System.Windows.Forms.Button();
            this.btnThread2 = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.textBoxMillisecondsTimeout = new System.Windows.Forms.TextBox();
            this.lblSleep = new System.Windows.Forms.Label();
            this.lblMs = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblNodeNo = new System.Windows.Forms.Label();
            this.textBoxNodeNo = new System.Windows.Forms.TextBox();
            this.btnThreadWithInit1 = new System.Windows.Forms.Button();
            this.btnThreadWithInit2 = new System.Windows.Forms.Button();
            this.btnShowWithInit = new System.Windows.Forms.Button();
            this.btnThreadWithInitII1 = new System.Windows.Forms.Button();
            this.btnThreadWithInitII2 = new System.Windows.Forms.Button();
            this.btnShowWithInitII = new System.Windows.Forms.Button();
            this.btnMRESet = new System.Windows.Forms.Button();
            this.groupBoxMREs = new System.Windows.Forms.GroupBox();
            this.radioButtonAfterAdd = new System.Windows.Forms.RadioButton();
            this.radioButtonBeforeAdd = new System.Windows.Forms.RadioButton();
            this.radioButtonBeforeLock = new System.Windows.Forms.RadioButton();
            this.radioButtonCheckII = new System.Windows.Forms.RadioButton();
            this.radioButtonCheckI = new System.Windows.Forms.RadioButton();
            this.groupBoxMREs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThread1
            // 
            this.btnThread1.Location = new System.Drawing.Point(521, 8);
            this.btnThread1.Name = "btnThread1";
            this.btnThread1.Size = new System.Drawing.Size(75, 23);
            this.btnThread1.TabIndex = 5;
            this.btnThread1.Text = "Thread #1";
            this.btnThread1.UseVisualStyleBackColor = true;
            this.btnThread1.Click += new System.EventHandler(this.BtnThread1Click);
            // 
            // btnThread2
            // 
            this.btnThread2.Location = new System.Drawing.Point(602, 8);
            this.btnThread2.Name = "btnThread2";
            this.btnThread2.Size = new System.Drawing.Size(75, 23);
            this.btnThread2.TabIndex = 6;
            this.btnThread2.Text = "Thread #2";
            this.btnThread2.UseVisualStyleBackColor = true;
            this.btnThread2.Click += new System.EventHandler(this.BtnThread2Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(0, 118);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(984, 381);
            this.listBoxLog.TabIndex = 9;
            // 
            // textBoxMillisecondsTimeout
            // 
            this.textBoxMillisecondsTimeout.Location = new System.Drawing.Point(316, 9);
            this.textBoxMillisecondsTimeout.Name = "textBoxMillisecondsTimeout";
            this.textBoxMillisecondsTimeout.Size = new System.Drawing.Size(100, 20);
            this.textBoxMillisecondsTimeout.TabIndex = 3;
            // 
            // lblSleep
            // 
            this.lblSleep.AutoSize = true;
            this.lblSleep.Location = new System.Drawing.Point(273, 13);
            this.lblSleep.Name = "lblSleep";
            this.lblSleep.Size = new System.Drawing.Size(37, 13);
            this.lblSleep.TabIndex = 2;
            this.lblSleep.Text = "Sleep:";
            // 
            // lblMs
            // 
            this.lblMs.AutoSize = true;
            this.lblMs.Location = new System.Drawing.Point(423, 13);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(20, 13);
            this.lblMs.TabIndex = 4;
            this.lblMs.Text = "ms";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(683, 8);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShowClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(764, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            // 
            // lblNodeNo
            // 
            this.lblNodeNo.AutoSize = true;
            this.lblNodeNo.Location = new System.Drawing.Point(113, 13);
            this.lblNodeNo.Name = "lblNodeNo";
            this.lblNodeNo.Size = new System.Drawing.Size(46, 13);
            this.lblNodeNo.TabIndex = 0;
            this.lblNodeNo.Text = "Node #:";
            // 
            // textBoxNodeNo
            // 
            this.textBoxNodeNo.Location = new System.Drawing.Point(167, 9);
            this.textBoxNodeNo.Name = "textBoxNodeNo";
            this.textBoxNodeNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxNodeNo.TabIndex = 1;
            // 
            // btnThreadWithInit1
            // 
            this.btnThreadWithInit1.Location = new System.Drawing.Point(521, 39);
            this.btnThreadWithInit1.Name = "btnThreadWithInit1";
            this.btnThreadWithInit1.Size = new System.Drawing.Size(75, 23);
            this.btnThreadWithInit1.TabIndex = 10;
            this.btnThreadWithInit1.Text = "Thread #1";
            this.btnThreadWithInit1.UseVisualStyleBackColor = true;
            this.btnThreadWithInit1.Click += new System.EventHandler(this.BtnThreadWithInit1Click);
            // 
            // btnThreadWithInit2
            // 
            this.btnThreadWithInit2.Location = new System.Drawing.Point(602, 39);
            this.btnThreadWithInit2.Name = "btnThreadWithInit2";
            this.btnThreadWithInit2.Size = new System.Drawing.Size(75, 23);
            this.btnThreadWithInit2.TabIndex = 11;
            this.btnThreadWithInit2.Text = "Thread #2";
            this.btnThreadWithInit2.UseVisualStyleBackColor = true;
            this.btnThreadWithInit2.Click += new System.EventHandler(this.BtnThreadWithInit2Click);
            // 
            // btnShowWithInit
            // 
            this.btnShowWithInit.Location = new System.Drawing.Point(683, 39);
            this.btnShowWithInit.Name = "btnShowWithInit";
            this.btnShowWithInit.Size = new System.Drawing.Size(75, 23);
            this.btnShowWithInit.TabIndex = 12;
            this.btnShowWithInit.Text = "Show";
            this.btnShowWithInit.UseVisualStyleBackColor = true;
            this.btnShowWithInit.Click += new System.EventHandler(this.BtnShowClick);
            // 
            // btnThreadWithInitII1
            // 
            this.btnThreadWithInitII1.Location = new System.Drawing.Point(521, 70);
            this.btnThreadWithInitII1.Name = "btnThreadWithInitII1";
            this.btnThreadWithInitII1.Size = new System.Drawing.Size(75, 23);
            this.btnThreadWithInitII1.TabIndex = 13;
            this.btnThreadWithInitII1.Text = "Thread #1";
            this.btnThreadWithInitII1.UseVisualStyleBackColor = true;
            this.btnThreadWithInitII1.Click += new System.EventHandler(this.BtnThreadWithInitII1Click);
            // 
            // btnThreadWithInitII2
            // 
            this.btnThreadWithInitII2.Location = new System.Drawing.Point(602, 70);
            this.btnThreadWithInitII2.Name = "btnThreadWithInitII2";
            this.btnThreadWithInitII2.Size = new System.Drawing.Size(75, 23);
            this.btnThreadWithInitII2.TabIndex = 14;
            this.btnThreadWithInitII2.Text = "Thread #2";
            this.btnThreadWithInitII2.UseVisualStyleBackColor = true;
            this.btnThreadWithInitII2.Click += new System.EventHandler(this.BtnThreadWithInitII2Click);
            // 
            // btnShowWithInitII
            // 
            this.btnShowWithInitII.Location = new System.Drawing.Point(683, 70);
            this.btnShowWithInitII.Name = "btnShowWithInitII";
            this.btnShowWithInitII.Size = new System.Drawing.Size(75, 23);
            this.btnShowWithInitII.TabIndex = 15;
            this.btnShowWithInitII.Text = "Show";
            this.btnShowWithInitII.UseVisualStyleBackColor = true;
            this.btnShowWithInitII.Click += new System.EventHandler(this.BtnShowClick);
            // 
            // btnMRESet
            // 
            this.btnMRESet.Location = new System.Drawing.Point(764, 70);
            this.btnMRESet.Name = "btnMRESet";
            this.btnMRESet.Size = new System.Drawing.Size(75, 23);
            this.btnMRESet.TabIndex = 16;
            this.btnMRESet.Text = "Set";
            this.btnMRESet.UseVisualStyleBackColor = true;
            this.btnMRESet.Click += new System.EventHandler(this.BtnMRESetClick);
            // 
            // groupBoxMREs
            // 
            this.groupBoxMREs.Controls.Add(this.radioButtonAfterAdd);
            this.groupBoxMREs.Controls.Add(this.radioButtonBeforeAdd);
            this.groupBoxMREs.Controls.Add(this.radioButtonBeforeLock);
            this.groupBoxMREs.Controls.Add(this.radioButtonCheckII);
            this.groupBoxMREs.Controls.Add(this.radioButtonCheckI);
            this.groupBoxMREs.Location = new System.Drawing.Point(8, 56);
            this.groupBoxMREs.Name = "groupBoxMREs";
            this.groupBoxMREs.Size = new System.Drawing.Size(499, 50);
            this.groupBoxMREs.TabIndex = 17;
            this.groupBoxMREs.TabStop = false;
            this.groupBoxMREs.Text = " MREs ";
            // 
            // radioButtonAfterAdd
            // 
            this.radioButtonAfterAdd.AutoSize = true;
            this.radioButtonAfterAdd.Location = new System.Drawing.Point(412, 17);
            this.radioButtonAfterAdd.Name = "radioButtonAfterAdd";
            this.radioButtonAfterAdd.Size = new System.Drawing.Size(69, 17);
            this.radioButtonAfterAdd.TabIndex = 5;
            this.radioButtonAfterAdd.Text = "After Add";
            this.radioButtonAfterAdd.UseVisualStyleBackColor = true;
            // 
            // radioButtonBeforeAdd
            // 
            this.radioButtonBeforeAdd.AutoSize = true;
            this.radioButtonBeforeAdd.Location = new System.Drawing.Point(319, 17);
            this.radioButtonBeforeAdd.Name = "radioButtonBeforeAdd";
            this.radioButtonBeforeAdd.Size = new System.Drawing.Size(78, 17);
            this.radioButtonBeforeAdd.TabIndex = 4;
            this.radioButtonBeforeAdd.Text = "Before Add";
            this.radioButtonBeforeAdd.UseVisualStyleBackColor = true;
            // 
            // radioButtonBeforeLock
            // 
            this.radioButtonBeforeLock.AutoSize = true;
            this.radioButtonBeforeLock.Location = new System.Drawing.Point(113, 17);
            this.radioButtonBeforeLock.Name = "radioButtonBeforeLock";
            this.radioButtonBeforeLock.Size = new System.Drawing.Size(83, 17);
            this.radioButtonBeforeLock.TabIndex = 2;
            this.radioButtonBeforeLock.Text = "Before Lock";
            this.radioButtonBeforeLock.UseVisualStyleBackColor = true;
            // 
            // radioButtonCheckII
            // 
            this.radioButtonCheckII.AutoSize = true;
            this.radioButtonCheckII.Location = new System.Drawing.Point(211, 17);
            this.radioButtonCheckII.Name = "radioButtonCheckII";
            this.radioButtonCheckII.Size = new System.Drawing.Size(65, 17);
            this.radioButtonCheckII.TabIndex = 1;
            this.radioButtonCheckII.Text = "Check II";
            this.radioButtonCheckII.UseVisualStyleBackColor = true;
            // 
            // radioButtonCheckI
            // 
            this.radioButtonCheckI.AutoSize = true;
            this.radioButtonCheckI.Checked = true;
            this.radioButtonCheckI.Location = new System.Drawing.Point(8, 17);
            this.radioButtonCheckI.Name = "radioButtonCheckI";
            this.radioButtonCheckI.Size = new System.Drawing.Size(62, 17);
            this.radioButtonCheckI.TabIndex = 0;
            this.radioButtonCheckI.TabStop = true;
            this.radioButtonCheckI.Text = "Check I";
            this.radioButtonCheckI.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 499);
            this.Controls.Add(this.groupBoxMREs);
            this.Controls.Add(this.btnMRESet);
            this.Controls.Add(this.btnShowWithInitII);
            this.Controls.Add(this.btnThreadWithInitII2);
            this.Controls.Add(this.btnThreadWithInitII1);
            this.Controls.Add(this.btnShowWithInit);
            this.Controls.Add(this.btnThreadWithInit2);
            this.Controls.Add(this.btnThreadWithInit1);
            this.Controls.Add(this.lblNodeNo);
            this.Controls.Add(this.textBoxNodeNo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblMs);
            this.Controls.Add(this.lblSleep);
            this.Controls.Add(this.textBoxMillisecondsTimeout);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnThread2);
            this.Controls.Add(this.btnThread1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test lock Dictionary node";
            this.groupBoxMREs.ResumeLayout(false);
            this.groupBoxMREs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThread1;
        private System.Windows.Forms.Button btnThread2;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TextBox textBoxMillisecondsTimeout;
        private System.Windows.Forms.Label lblSleep;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblNodeNo;
        private System.Windows.Forms.TextBox textBoxNodeNo;
        private System.Windows.Forms.Button btnThreadWithInit1;
        private System.Windows.Forms.Button btnThreadWithInit2;
        private System.Windows.Forms.Button btnShowWithInit;
        private System.Windows.Forms.Button btnThreadWithInitII1;
        private System.Windows.Forms.Button btnThreadWithInitII2;
        private System.Windows.Forms.Button btnShowWithInitII;
        private System.Windows.Forms.Button btnMRESet;
        private System.Windows.Forms.GroupBox groupBoxMREs;
        private System.Windows.Forms.RadioButton radioButtonCheckII;
        private System.Windows.Forms.RadioButton radioButtonCheckI;
        private System.Windows.Forms.RadioButton radioButtonBeforeLock;
        private System.Windows.Forms.RadioButton radioButtonAfterAdd;
        private System.Windows.Forms.RadioButton radioButtonBeforeAdd;
    }
}

