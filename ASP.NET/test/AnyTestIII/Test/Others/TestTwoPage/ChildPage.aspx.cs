using System;

namespace AnyTest
{
	public class TestTwoPageChildPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxOnChildPage;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.Label LabelSubmit;

		public const string
			TestTwoPageChildPageSessionSignature="TestTwoPageChildPageSession";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack && Session[TestTwoPageChildPageSessionSignature]!=null)
				Session.Remove(TestTwoPageChildPageSessionSignature);
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
			this.ButtonSubmit.Click +=new EventHandler(ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Session[TestTwoPageChildPageSessionSignature]=LabelSubmit.Text=TextBoxOnChildPage.Text+" (Submit @ "+DateTime.Now.ToString()+")";
		}
	}
}
