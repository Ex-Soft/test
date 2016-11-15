using System;

namespace TestSession
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Label1.Text = Session.SessionID;
		}
	}
}
