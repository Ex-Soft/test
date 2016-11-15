using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.Web;

namespace TestPivotReportWithPaging
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            PreStartApp.Logger.Info("Application_Start()");

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ASPxWebControl.CallbackError += Application_Error;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = HttpContext.Current.Server.GetLastError();
            PreStartApp.Logger.Error(exception);

            if (exception is HttpUnhandledException)
                PreStartApp.Logger.Error(exception.InnerException);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            PreStartApp.Logger.Info("Application_BeginRequest");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            PreStartApp.Logger.Info("Application_EndRequest");
        }

        /*
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            PreStartApp.Logger.Info("Application_PreSendRequestHeaders");
        }

        protected void Application_PreSendRequestContent(object sender, EventArgs e)
        {
            PreStartApp.Logger.Info("Application_PreSendRequestContent");
        }
        */
    }
}
