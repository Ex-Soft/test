using System;
using System.Windows.Forms;

namespace Receiver
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label LabelArgInt;
		private System.Windows.Forms.TextBox TextBoxArgInt;
		private System.Windows.Forms.Label LabelArgString;
		private System.Windows.Forms.TextBox TextBoxArgString;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label LabelSender;
		private System.Windows.Forms.TextBox TextBoxSender;

		private EventClass.EventClass
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
			TextBoxArgInt.Text=Convert.ToString(args.ArgInt);
			TextBoxArgString.Text=args.ArgString;
			TextBoxSender.Text=sender.ToString();

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
			this.LabelArgInt = new System.Windows.Forms.Label();
			this.LabelArgString = new System.Windows.Forms.Label();
			this.TextBoxArgInt = new System.Windows.Forms.TextBox();
			this.TextBoxArgString = new System.Windows.Forms.TextBox();
			this.LabelSender = new System.Windows.Forms.Label();
			this.TextBoxSender = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LabelArgInt
			// 
			this.LabelArgInt.Location = new System.Drawing.Point(8, 16);
			this.LabelArgInt.Name = "LabelArgInt";
			this.LabelArgInt.Size = new System.Drawing.Size(60, 20);
			this.LabelArgInt.TabIndex = 0;
			this.LabelArgInt.Text = "ArgInt:";
			// 
			// LabelArgString
			// 
			this.LabelArgString.Location = new System.Drawing.Point(8, 41);
			this.LabelArgString.Name = "LabelArgString";
			this.LabelArgString.Size = new System.Drawing.Size(60, 20);
			this.LabelArgString.TabIndex = 1;
			this.LabelArgString.Text = "ArgString:";
			// 
			// TextBoxArgInt
			// 
			this.TextBoxArgInt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgInt.AutoSize = false;
			this.TextBoxArgInt.Location = new System.Drawing.Point(73, 16);
			this.TextBoxArgInt.Name = "TextBoxArgInt";
			this.TextBoxArgInt.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgInt.TabIndex = 3;
			this.TextBoxArgInt.Text = "";
			// 
			// TextBoxArgString
			// 
			this.TextBoxArgString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxArgString.AutoSize = false;
			this.TextBoxArgString.Location = new System.Drawing.Point(73, 41);
			this.TextBoxArgString.Name = "TextBoxArgString";
			this.TextBoxArgString.Size = new System.Drawing.Size(217, 20);
			this.TextBoxArgString.TabIndex = 4;
			this.TextBoxArgString.Text = "";
			// 
			// LabelSender
			// 
			this.LabelSender.Location = new System.Drawing.Point(8, 66);
			this.LabelSender.Name = "LabelSender";
			this.LabelSender.Size = new System.Drawing.Size(60, 20);
			this.LabelSender.TabIndex = 2;
			this.LabelSender.Text = "sender:";
			// 
			// TextBoxSender
			// 
			this.TextBoxSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxSender.AutoSize = false;
			this.TextBoxSender.Location = new System.Drawing.Point(73, 66);
			this.TextBoxSender.Name = "TextBoxSender";
			this.TextBoxSender.Size = new System.Drawing.Size(217, 20);
			this.TextBoxSender.TabIndex = 5;
			this.TextBoxSender.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 101);
			this.Controls.Add(this.TextBoxSender);
			this.Controls.Add(this.LabelSender);
			this.Controls.Add(this.TextBoxArgString);
			this.Controls.Add(this.TextBoxArgInt);
			this.Controls.Add(this.LabelArgString);
			this.Controls.Add(this.LabelArgInt);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm (Receiver)";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
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

		private void MainForm_Closed(object sender, System.EventArgs e)
		{
			if(evt!=null)
				evt.SomeEvent-=new EventClass.EventClassHandler(ReceiverEventHandler);		
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}
	}
}
