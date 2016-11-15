using System;
using System.Web;

namespace WebApplicationSimple
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LabelInfo.Text = string.Format("Name=\"{0}\" IsAuthenticated=\"{1}\" AuthenticationType=\"{2}\"", HttpContext.Current.User.Identity.Name, HttpContext.Current.User.Identity.IsAuthenticated, HttpContext.Current.User.Identity.AuthenticationType);
		}
	}
}
