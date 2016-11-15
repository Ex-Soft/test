using System;
using System.Web;
using System.Web.Security;

namespace TestFormAuthenticationSimple
{
	public partial class LoginForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ButtonLogin_Click(object sender, EventArgs e)
		{
			string
				Login;

			if ((Login = TextBoxLogin.Text.Trim()) == "igor" && TextBoxPassword.Text.Trim() == "1")
				FormsAuthentication.RedirectFromLoginPage(Login, false);
			else
				LabelInfo.Text = "Login failed. Please check your user name and password and try again.";
		}
	}
}
