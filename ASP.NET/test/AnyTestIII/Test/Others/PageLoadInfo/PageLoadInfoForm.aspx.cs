using System;

namespace AnyTest
{
	public class PageLoadInfoForm : System.Web.UI.Page
	{
		private void Page_Init(object sender, System.EventArgs e)
		{
			Response.Write("\n<SCRIPT TYPE=\"text/javascript\">\n<!--\nvar PLS=new Date();\n// -->\n</SCRIPT>");
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//
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
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion
	}
}
