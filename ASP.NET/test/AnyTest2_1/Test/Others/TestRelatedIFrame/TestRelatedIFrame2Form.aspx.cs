using System;

namespace AnyTest2_1
{
	public partial class TestRelatedIFrame2Form : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string[]
				Data;

			if ((Data = Request.QueryString.GetValues("data")) != null
				&& Data.Length > 0)
				TextBox1.Text = Data[0];

			TestRelatedIFrame1Form.SetLabelInfo(LabelInfo);
		}
	}
}
