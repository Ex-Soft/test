using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TestUrlRewriting
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Debug.WriteLine("Application_Start");

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Init()
        {
            Debug.WriteLine("Application_Init");
        }

        protected void Application_Disposed()
        {
            Debug.WriteLine("Application_Disposed");
        }

        protected void Application_Error()
        {
            Debug.WriteLine("Application_Error");
        }

        protected void Application_End()
        {
            Debug.WriteLine("Application_End");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (sender is HttpApplication app)
            {
                Debug.WriteLine($"Application_BeginRequest event fired {app.Context.Request.Url}");
            }
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_EndRequest");
        }

        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PreRequestHandlerExecute");
        }

        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PostRequestHandlerExecute");

        }

        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PreSendRequestHeaders");
        }

        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PreSendRequestContent");
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AcquireRequestState");
        }

        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_ReleaseRequestState");
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AuthenticateRequest");
        }

        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AuthorizeRequest");
        }

        protected void Application_ProcessRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_ProcessRequest");
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Debug.WriteLine("Session_Start");
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Debug.WriteLine("Session_End");
        }
    }
}
