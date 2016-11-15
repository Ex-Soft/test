using System;

namespace AnyTest
{
	public class TestPostBackUrlEmulationMainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonSubmit.Click += new EventHandler(ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		public string GetTextBox1()
		{
			return TextBox1.Text;
		}

		public string GetTextBox2()
		{
			return TextBox2.Text;
		}

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Server.Transfer("TestPostBackUrlEmulationChildForm.aspx");
		}
	}
}
