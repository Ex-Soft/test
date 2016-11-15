using System;
using System.Windows.Forms;

namespace Sender
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label LabelArgIntSend;
		private System.Windows.Forms.TextBox TextBoxArgIntSend;
		private System.Windows.Forms.Label LabelArgStringSend;
		private System.Windows.Forms.TextBox TextBoxArgStringSend;
		private System.Windows.Forms.Button ButtonSend;
		private System.Windows.Forms.Label LabelSender;
		private System.Windows.Forms.TextBox TextBoxSender;
		private System.Windows.Forms.Label LabelArgIntRecv;
		private System.Windows.Forms.TextBox TextBoxArgIntRecv;
		private System.Windows.Forms.Label LabelArgStringRecv;
		private System.Windows.Forms.TextBox TextBoxArgStringRecv;

		private System.ComponentModel.Container components = null;

		EventClass.EventClass
			evt=null;

		public MainForm()
		{
			InitializeComponent();

			if(evt==null)
			{
				evt=new EventClass.EventClass();
				evt.SomeEvent+=new EventClass.EventClassHandler(ReceiverEventHandler);
			}
		}

		private bool ReceiverEventHandler(object sender, EventClass.EventClassArgs args)
		{
			TextBoxSender.Text=((Control)sender).Name;
			TextBoxArgIntRecv.Text=Convert.ToString(args.ArgInt);
			TextBoxArgStringRecv.Text=args.ArgString;

			return(true);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.LabelArgIntSend = new System.Windows.Forms.Label();
			this.TextBoxArgIntSend = new System.Windows.Forms.TextBox();
			this.LabelArgStringSend = new System.Windows.Forms.Label();
			this.TextBoxArgStringSend = new System.Windows.Forms.TextBox();
			this.ButtonSend = new System.Windows.Forms.Button();
			this.LabelSender = new System.Windows.Forms.Label();
			this.TextBoxSender = new System.Windows.Forms.TextBox();
			this.LabelArgIntRecv = new System.Windows.Forms.Label();
			this.TextBoxArgIntRecv = new System.Windows.Forms.TextBox();
			this.LabelArgStringRecv = new System.Windows.Forms.Label();
			this.TextBoxArgStringRecv = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LabelArgIntSend
			// 
			this.LabelArgIntSend.Location = new System.Drawing.Point(8, 16);
			this.LabelArgIntSend.Name = "LabelArgIntSend";
			this.LabelArgIntSend.Size = new System.Drawing.Size(60, 20);
			this.LabelArgIntSend.TabIndex = 0;
			this.LabelArgIntSend.Text = "ArgInt:";
			// 
			// TextBoxArgIntSend
			// 
			this.TextBoxArgIntSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgIntSend.AutoSize = false;
			this.TextBoxArgIntSend.Location = new System.Drawing.Point(73, 16);
			this.TextBoxArgIntSend.Name = "TextBoxArgIntSend";
			this.TextBoxArgIntSend.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgIntSend.TabIndex = 2;
			this.TextBoxArgIntSend.Text = "";
			// 
			// LabelArgStringSend
			// 
			this.LabelArgStringSend.Location = new System.Drawing.Point(8, 41);
			this.LabelArgStringSend.Name = "LabelArgStringSend";
			this.LabelArgStringSend.Size = new System.Drawing.Size(60, 20);
			this.LabelArgStringSend.TabIndex = 1;
			this.LabelArgStringSend.Text = "ArgString:";
			// 
			// TextBoxArgStringSend
			// 
			this.TextBoxArgStringSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgStringSend.AutoSize = false;
			this.TextBoxArgStringSend.Location = new System.Drawing.Point(73, 41);
			this.TextBoxArgStringSend.Name = "TextBoxArgStringSend";
			this.TextBoxArgStringSend.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgStringSend.TabIndex = 3;
			this.TextBoxArgStringSend.Text = "";
			// 
			// ButtonSend
			// 
			this.ButtonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonSend.Location = new System.Drawing.Point(112, 66);
			this.ButtonSend.Name = "ButtonSend";
			this.ButtonSend.TabIndex = 4;
			this.ButtonSend.Text = "Send";
			this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
			// 
			// LabelSender
			// 
			this.LabelSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelSender.Location = new System.Drawing.Point(8, 94);
			this.LabelSender.Name = "LabelSender";
			this.LabelSender.Size = new System.Drawing.Size(60, 20);
			this.LabelSender.TabIndex = 5;
			this.LabelSender.Text = "sender:";
			// 
			// TextBoxSender
			// 
			this.TextBoxSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxSender.AutoSize = false;
			this.TextBoxSender.Location = new System.Drawing.Point(73, 94);
			this.TextBoxSender.Name = "TextBoxSender";
			this.TextBoxSender.Size = new System.Drawing.Size(217, 20);
			this.TextBoxSender.TabIndex = 8;
			this.TextBoxSender.Text = "";
			// 
			// LabelArgIntRecv
			// 
			this.LabelArgIntRecv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelArgIntRecv.Location = new System.Drawing.Point(8, 119);
			this.LabelArgIntRecv.Name = "LabelArgIntRecv";
			this.LabelArgIntRecv.Size = new System.Drawing.Size(60, 20);
			this.LabelArgIntRecv.TabIndex = 6;
			this.LabelArgIntRecv.Text = "ArgInt:";
			// 
			// TextBoxArgIntRecv
			// 
			this.TextBoxArgIntRecv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgIntRecv.AutoSize = false;
			this.TextBoxArgIntRecv.Location = new System.Drawing.Point(73, 119);
			this.TextBoxArgIntRecv.Name = "TextBoxArgIntRecv";
			this.TextBoxArgIntRecv.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgIntRecv.TabIndex = 9;
			this.TextBoxArgIntRecv.Text = "";
			// 
			// LabelArgStringRecv
			// 
			this.LabelArgStringRecv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LabelArgStringRecv.Location = new System.Drawing.Point(8, 144);
			this.LabelArgStringRecv.Name = "LabelArgStringRecv";
			this.LabelArgStringRecv.Size = new System.Drawing.Size(60, 20);
			this.LabelArgStringRecv.TabIndex = 7;
			this.LabelArgStringRecv.Text = "ArgString:";
			// 
			// TextBoxArgStringRecv
			// 
			this.TextBoxArgStringRecv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgStringRecv.AutoSize = false;
			this.TextBoxArgStringRecv.Location = new System.Drawing.Point(73, 144);
			this.TextBoxArgStringRecv.Name = "TextBoxArgStringRecv";
			this.TextBoxArgStringRecv.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgStringRecv.TabIndex = 10;
			this.TextBoxArgStringRecv.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 173);
			this.Controls.Add(this.LabelArgIntSend);
			this.Controls.Add(this.TextBoxArgIntSend);
			this.Controls.Add(this.LabelArgStringSend);
			this.Controls.Add(this.TextBoxArgStringSend);
			this.Controls.Add(this.ButtonSend);
			this.Controls.Add(this.LabelSender);
			this.Controls.Add(this.TextBoxSender);
			this.Controls.Add(this.LabelArgIntRecv);
			this.Controls.Add(this.TextBoxArgIntRecv);
			this.Controls.Add(this.LabelArgStringRecv);
			this.Controls.Add(this.TextBoxArgStringRecv);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Closed += new System.EventHandler(this.MainForm_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void ButtonSend_Click(object sender, System.EventArgs e)
		{
			int
				ArgInt=int.MinValue;

			try
			{
				ArgInt=Convert.ToInt32(TextBoxArgIntSend.Text);
			}
			catch
			{
				ArgInt=int.MinValue;
			}

			EventClass.EventClassArgs
				args=new EventClass.EventClassArgs(ArgInt,TextBoxArgStringSend.Text.Trim());

			evt.OnSomeEvent(sender,args);
		}

		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			if(evt!=null)
				evt.SomeEvent-=new EventClass.EventClassHandler(ReceiverEventHandler);		
		}
	}
}
