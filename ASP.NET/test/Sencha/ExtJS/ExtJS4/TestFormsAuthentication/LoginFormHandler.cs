using System.Web;
using System.Web.Security;

namespace TestFormsAuthentication
{
    public class LoginFormHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
           	string
				login = context.Request.Form["login"],
				password = context.Request.Form["password"];

            if(login=="igor" && password=="1")
                FormsAuthentication.SetAuthCookie(login, false);
        }

        public bool IsReusable { get { return false; } }
    }
}