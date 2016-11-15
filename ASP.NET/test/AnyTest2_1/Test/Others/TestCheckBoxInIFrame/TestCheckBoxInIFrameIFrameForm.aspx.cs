using System;

namespace AnyTest2_1
{
	public partial class TestCheckBoxInIFrameIFrameForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string
				CheckBoxSessionSignature = "CheckBoxSession";

			if(!IsPostBack)
			{
				if (Session[CheckBoxSessionSignature] != null)
					CheckBox1.Checked = (bool)Session[CheckBoxSessionSignature];
			}
			else
				Session[CheckBoxSessionSignature] = CheckBox1.Checked;
		}
	}
}
