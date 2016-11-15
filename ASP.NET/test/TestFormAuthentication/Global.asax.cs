// http://msdn.microsoft.com/en-us/library/system.web.httpapplication.aspx
// http://developmentfootprints.blogspot.com/2013/03/proper-configuring-log4net-in-aspnet-in.html

using System;

using log4net;

namespace TestFormAuthentication
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			log4net.Config.XmlConfigurator.Configure();

			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_Start");
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Session_Start");
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_BeginRequest");
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_AuthenticateRequest (Context.User.Identity.IsAuthenticated=" + (Context.User != null ? Context.User.Identity.IsAuthenticated.ToString().ToLower() : "null") + ")");

			string
				XRequestedWithSignature = "X-Requested-With",
				StatusCodeSignature = "statuscode",
				WriteToResponseSignature = "writetoresponse",
                userInfo = Context.Request.Url.UserInfo;

			int
				StatusCode;

			if ((Context.User == null || !Context.User.Identity.IsAuthenticated)
				&& Context.Request.Headers[XRequestedWithSignature] != null
				&& Context.Request.Headers[XRequestedWithSignature].Trim().ToLower() == "xmlhttprequest"
				&& Context.Request.Form[StatusCodeSignature] != null
				&& int.TryParse(Context.Request.Form[StatusCodeSignature], out StatusCode))
			{
				Context.Response.StatusCode = StatusCode;
				if (Context.Request.Form[WriteToResponseSignature] != null
					&& Context.Request.Form[WriteToResponseSignature].Trim().ToLower() == "true")
					Context.Response.Write("blah-blah-blah");
				Context.Response.End();
			}
		}

		protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_PostAuthenticateRequest (Context.User.Identity.IsAuthenticated=" + (Context.User != null ? Context.User.Identity.IsAuthenticated.ToString().ToLower() : "null") + ")");
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_Error");
		}

		protected void Session_End(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Session_End");
		}

		protected void Application_End(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_End");
		}

		protected void Application_AuthorizeRequest(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_AuthorizeRequest");
		}

		protected void Application_PostAuthorizeRequest(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_PostAuthorizeRequest");
		}

		protected void Application_AcquireRequestState(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_AcquireRequestState");
		}

		protected void Application_PostAcquireRequestState(object sender, EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System");

			log.Info("Application_PostAcquireRequestState");
		}
	}
}