using System;
using System.Web.Security;

namespace TestFormsAuthentication
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoginClick(object sender, EventArgs e)
        {
            var userName = UserName.Text;
            var pwd = Pwd.Text;

            FormsAuthentication.RedirectFromLoginPage(userName, false);
        }
    }
}