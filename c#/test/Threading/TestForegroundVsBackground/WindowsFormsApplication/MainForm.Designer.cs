namespace WindowsFormsApplication
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
			this.buttonDoIt = new System.Windows.Forms.Button();
			this.checkBoxBackground = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// buttonDoIt
			// 
			this.buttonDoIt.Location = new System.Drawing.Point(257, 18);
			this.buttonDoIt.Name = "buttonDoIt";
			this.buttonDoIt.Size = new System.Drawing.Size(75, 23);
			this.buttonDoIt.TabIndex = 0;
			this.buttonDoIt.Text = "DoIt!";
			this.buttonDoIt.UseVisualStyleBackColor = true;
			this.buttonDoIt.Click += new System.EventHandler(this.ButtonDoItClick);
			// 
			// checkBoxBackground
			// 
			this.checkBoxBackground.AutoSize = true;
			this.checkBoxBackground.Location = new System.Drawing.Point(148, 24);
			this.checkBoxBackground.Name = "checkBoxBackground";
			this.checkBoxBackground.Size = new System.Drawing.Size(84, 17);
			this.checkBoxBackground.TabIndex = 1;
			this.checkBoxBackground.Text = "Background";
			this.checkBoxBackground.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 53);
			this.Controls.Add(this.checkBoxBackground);
			this.Controls.Add(this.buttonDoIt);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Test Foreground Vs Background ";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormOnFormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonDoIt;
		private System.Windows.Forms.CheckBox checkBoxBackground;
	}
}

