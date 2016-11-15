using System;

namespace AnyTest2_1
{
	public partial class TestDetailsViewForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				DetailsView1.DataSource = TestDataData.GetStaff();
				DetailsView1.DataBind();
			}
		}
	}
}
