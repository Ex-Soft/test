using System;

namespace AnyTest2_1
{
	public partial class TestActionDestForm : System.Web.UI.Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{

		}

		protected void Page_Load(object sender, EventArgs e)
		{
			TextBox1.Text = Request.Form["TextBox1"];
		}
	}
}
