using System;
using System.Web.Security;

namespace TestFormAuthentication
{
	public partial class LoginForm : System.Web.UI.Page
	{
		protected void objSignIn_Login(object sender, SignInEventArgs e)
		{
			if (e.IsValid)
			{
				// throw(new Exception("Test"));

				FormsAuthentication.RedirectFromLoginPage(e.UserName, false);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
