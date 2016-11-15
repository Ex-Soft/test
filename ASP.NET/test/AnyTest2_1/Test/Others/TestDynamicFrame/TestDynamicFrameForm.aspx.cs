using System;

namespace AnyTest2_1
{
	public partial class TestDynamicFrameForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			IFrameDynamic.Attributes["src"] = "TestDynamicFrameHandler.ashx?By=" + RadioButtonList1.SelectedValue + "&SmthParam=" + IsPostBack.ToString().ToLower();
		}
	}
}
