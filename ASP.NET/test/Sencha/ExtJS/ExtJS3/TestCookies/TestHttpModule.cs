using System;
using System.Collections.Specialized;
using System.Web;
using log4net;

namespace TestCookies
{
	public class TestHttpModule : IHttpModule
	{
		public void Dispose()
		{ }

		public void Init(HttpApplication context)
		{
			//context.BeginRequest += new System.EventHandler(context_BeginRequest);

			//context.PostMapRequestHandler += new System.EventHandler(context_PostMapRequestHandler);
			//context.AcquireRequestState += new System.EventHandler(context_AcquireRequestState);
			//context.PostAcquireRequestState += new System.EventHandler(context_PostAcquireRequestState);
			//context.PreRequestHandlerExecute += new System.EventHandler(context_PreRequestHandlerExecute);
			
			//context.EndRequest += new System.EventHandler(context_EndRequest);
		}

		void context_BeginRequest(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.BeginRequest");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			ShowCookiesRequest();

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		void context_PostMapRequestHandler(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.PostMapRequestHandler");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		void context_AcquireRequestState(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.AcquireRequestState");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		void context_PostAcquireRequestState(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.PostAcquireRequestState");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		void context_PreRequestHandlerExecute(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.PreRequestHandlerExecute");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		void context_EndRequest(object sender, System.EventArgs e)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("HttpModule.EndRequest");

			try
			{
				log.Info("SessionId=\"" + HttpContext.Current.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("HttpContext.Current.Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}

			ShowCookiesResponse();

			HttpApplication
				app;

			if ((app = sender as HttpApplication) == null)
				return;

			try
			{
				log.Info("SessionId=\"" + app.Session.SessionID + "\"");
			}
			catch (Exception eException)
			{
				log.Info("(sender as HttpApplication).Session.SessionID: " + eException.GetType().FullName + " Message: " + eException.Message);
			}
		}

		public static void ShowCookiesRequest()
		{
			ShowCookies(HttpContext.Current.Request.Cookies, "Request");
		}

		public static void ShowCookiesResponse()
		{
			ShowCookies(HttpContext.Current.Response.Cookies,"Response");
		}

		public static void ShowCookies(HttpCookieCollection cs, string Prefix)
		{
			ILog
				log = LogManager.GetLogger("System"); 

			log.Info("--------------------");

			NameObjectCollectionBase.KeysCollection
				keys = cs.Keys;

			string
				tmpString;

			HttpCookie
				c;

			foreach (string key in keys)
			{
				tmpString = Prefix +" Cookies[\"" + key + "\"]=\"" + cs[key].Value + "\"";

				log.Info(tmpString);

				c = cs[key];
			}
		}
	}
}
