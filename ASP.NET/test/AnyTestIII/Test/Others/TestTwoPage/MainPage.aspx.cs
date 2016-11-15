using System;

namespace AnyTest
{
	public class TestTwoPageMainPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button ButtonGetSessionValue;
		protected System.Web.UI.WebControls.Label LabelSessionValue;

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
			this.ButtonGetSessionValue.Click+=new EventHandler(ButtonGetSessionValue_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void ButtonGetSessionValue_Click(object sender, EventArgs e)
		{
			LabelSessionValue.Text=(Session[TestTwoPageChildPage.TestTwoPageChildPageSessionSignature]!=null ? (string)Session[TestTwoPageChildPage.TestTwoPageChildPageSessionSignature] : "null")+" (Get @ "+DateTime.Now.ToString()+")";
		}
	}
}
