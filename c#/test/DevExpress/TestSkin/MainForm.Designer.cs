namespace TestSkin
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
			this.btnSetSkin = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// btnSetSkin
			// 
			this.btnSetSkin.Location = new System.Drawing.Point(55, 19);
			this.btnSetSkin.Name = "btnSetSkin";
			this.btnSetSkin.Size = new System.Drawing.Size(75, 23);
			this.btnSetSkin.TabIndex = 0;
			this.btnSetSkin.Text = "Set Skin";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(184, 61);
			this.Controls.Add(this.btnSetSkin);
			this.Name = "MainForm";
			this.Text = "Main Form";
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnSetSkin;
	}
}

