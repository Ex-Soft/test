using System;

namespace AnyTest
{
	public class SimpleValidatorForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;

		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.Button1.Click += new EventHandler(Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void Button1_Click(object sender, EventArgs e)
		{
			Label1.Text=DateTime.Now.ToLongTimeString();
		}
	}
}
