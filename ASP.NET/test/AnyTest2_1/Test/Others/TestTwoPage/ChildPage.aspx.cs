using System;

namespace AnyTest2_1
{
	public partial class TestTwoPageChildPage : System.Web.UI.Page
	{
		public const string
			TestTwoPageChildPageSessionSignature = "TestTwoPageChildPageSession";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack && Session[TestTwoPageChildPageSessionSignature] != null)
				Session.Remove(TestTwoPageChildPageSessionSignature);
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Session[TestTwoPageChildPageSessionSignature] = LabelSubmit.Text = TextBoxOnChildPage.Text + " (Submit @ " + DateTime.Now.ToString() + ")";
		}
	}
}
