using System;

namespace AnyTest
{
	/// <summary>
	/// Summary description for TestActionDestForm.
	/// </summary>
	public class TestActionDestForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;

		private void Page_Init(object sender, System.EventArgs e)
		{

		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			TextBox1.Text=Request.Form["TextBox1"];
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new EventHandler(this.Page_Init);

		}
		#endregion
	}
}
