using System;

namespace TestFormsAuthentication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.User != null && Context.User.Identity.IsAuthenticated)
                ;
        }
    }
}