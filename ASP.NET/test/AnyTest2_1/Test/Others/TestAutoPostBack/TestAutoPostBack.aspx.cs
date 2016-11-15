using System;

namespace AnyTest2_1
{
	public partial class TestAutoPostBack : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LabelInfo.Text = "Page_Load IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\"";
		}

		protected void CheckBoxAutoPostBack_CheckedChanged(object sender, EventArgs e)
		{
			LabelInfo.Text += " CheckBoxAutoPostBack_CheckedChanged (CheckBoxAutoPostBack.Checked=\"" + CheckBoxAutoPostBack.Checked.ToString().ToLower() + "\")";
		}
	}
}
