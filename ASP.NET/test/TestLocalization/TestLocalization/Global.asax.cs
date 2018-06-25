using System;
using System.Diagnostics;

namespace TestLocalization
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_Start");

            PreSendRequestHeaders += new EventHandler(Application_PreSendRequestHeaders);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Debug.WriteLine("Session_Start");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_BeginRequest");
        }

        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PreRequestHandlerExecute");
        }

        protected void Application_ProcessRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_ProcessRequest");

            try
            {
                this.Response.Headers.Add("Content-Language", "uk");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PostRequestHandlerExecute");

            try
            {
                this.Response.Headers.Add("Content-Language", "uk");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_PreSendRequestHeaders");

            try
            {
                this.Response.Headers.Add("Content-Language", "uk");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            Debug.WriteLine("Application_EndRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_AuthenticateRequest");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_Error");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Debug.WriteLine("Session_End");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_End");
        }
    }
}