using System;

namespace AnyTest
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Application_Start", true);
			Application.Lock();
			Application["UserOnline"] = 0;
			Application.UnLock();
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Session_Start (Session.SessionID: " + Session.SessionID + ")", true);
			Application.Lock();
			Application["UserOnline"] = (int)Application["UserOnline"] + 1;
			Application.UnLock();
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
            if (Context != null)
            {
                
            }
		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Session_End (Session.SessionID: " + Session.SessionID + ")", true);
			Application.Lock();
			Application["UserOnline"] = (int)Application["UserOnline"] - 1;
			Application.UnLock();
		}

		protected void Application_End(object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Application_End", true);
		}
	}
}