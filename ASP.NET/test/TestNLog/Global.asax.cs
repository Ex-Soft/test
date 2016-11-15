using System;

namespace TestNLog
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        void Application_Start(object sender, EventArgs e)
        {
            Logger.Info("Application_Start");
        }

        void Application_End(object sender, EventArgs e)
        {
            Logger.Info("Application_End");
        }

        void Application_Error(object sender, EventArgs e)
        {
            Logger.Info("Application_Error");
        }

        void Session_Start(object sender, EventArgs e)
        {
            Logger.Info("Session_Start");
            
            Request.RequestContext.HttpContext.Application.Lock();
            Request.RequestContext.HttpContext.Application["ApplicationVariable"] = "TestApplicationVariable";
            Request.RequestContext.HttpContext.Application.UnLock();

            Request.RequestContext.HttpContext.Session["SessionVariable"] = "TestSessionVariable";
        }

        void Session_End(object sender, EventArgs e)
        {
            Logger.Info("Session_End");
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Logger.Info("Application_BeginRequest");
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Logger.Info("Application_AuthenticateRequest");
        }

        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            Logger.Info("Application_PostAuthenticateRequest");
        }

        void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            Logger.Info("Application_AuthorizeRequest");
        }

        void Application_PostAuthorizeRequest(object sender, EventArgs e)
        {
            Logger.Info("Application_PostAuthorizeRequest");
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Logger.Info("Application_AcquireRequestState");
        }

        void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            Logger.Info("Application_PostAcquireRequestState");
        }
    }
}
