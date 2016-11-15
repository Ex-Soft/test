using System;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace TestFormsAuthentication
{
    public class Global : HttpApplication
    {
        void Application_PreRequestHandlerExecute(object send, EventArgs e)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated && HttpContext.Current.Session != null)
            {
                var windowsPrincipal = (WindowsPrincipal)Session["principal"];
                Session["principal"] = Thread.CurrentPrincipal;
                Thread.CurrentPrincipal = windowsPrincipal;
                HttpContext.Current.User = windowsPrincipal;
                HttpContext.Current.Items["identity"] = ((WindowsIdentity)windowsPrincipal.Identity).Impersonate();
            }
        }

        void Application_PostRequestHandlerExecute(object send, EventArgs e)
        {
            if (HttpContext.Current.Session != null && Session["principal"] as GenericPrincipal != null)
            {
                var genericPrincipal = (GenericPrincipal)Session["principal"];
                Session["principal"] = Thread.CurrentPrincipal;
                Thread.CurrentPrincipal = genericPrincipal;
                HttpContext.Current.User = genericPrincipal;
                ((WindowsImpersonationContext)HttpContext.Current.Items["identity"]).Undo();
            }
        }
    }
}
