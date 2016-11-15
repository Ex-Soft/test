using System;
using System.Web.Security;

namespace TestImpersonation
{
    public partial class Login : System.Web.UI.Page
    {
        protected void BtnLoginClick(object sender, EventArgs e)
        {
            var userName = UserName.Text;
            var password = Password.Text;

            if(userName=="admin" && password=="1")
                FormsAuthentication.RedirectFromLoginPage(userName, false);
        }
    }
}