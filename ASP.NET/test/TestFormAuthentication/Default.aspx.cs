using System;
using System.Web;

namespace TestFormAuthentication
{
	public partial class TestFormAuthenticationForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			System.Security.Principal.IPrincipal
				usr = HttpContext.Current.User;

			LabelInfo.Text = "AuthenticationType: \"" + usr.Identity.AuthenticationType + "\" IsAuthenticated: " + usr.Identity.IsAuthenticated.ToString().ToLower() + " Name: \"" + usr.Identity.Name + "\"";
		}
	}
}
