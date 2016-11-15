using System;

namespace AnyTest2_1
{
	public partial class TestDataBindFormForm : System.Web.UI.Page
	{
		protected string tmpString
		{
			get
			{
				return string.Empty;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.DataBind();
				// ||
				//Page.DataBind();

				HtmlTd2.Visible = !string.IsNullOrEmpty(tmpString);
			}
		}
	}
}
