using System;
using System.Web;

namespace AnyTestII
{
	public partial class TestIFrameSubmitIFrameForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LabelInfo.Text = DateTime.Now.ToString()+" IsPostBack="+IsPostBack.ToString().ToLower();
		}
	}
}
