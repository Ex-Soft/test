using System;

namespace AnyTestII
{
	public partial class TestAnchorForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataBind();
			}
		}
	}
}
