using System;

namespace AnyTest2_1
{
	public partial class TestTwoPageMainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//
		}

		protected void ButtonGetSessionValue_Click(object sender, EventArgs e)
		{
			LabelSessionValue.Text = (Session[TestTwoPageChildPage.TestTwoPageChildPageSessionSignature] != null ? (string)Session[TestTwoPageChildPage.TestTwoPageChildPageSessionSignature] : "null") + " (Get @ " + DateTime.Now.ToString() + ")";
		}
	}
}
