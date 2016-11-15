using System;
using System.Configuration;
using System.Web.Configuration;

namespace AnyTest2_1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["UserOnline"] = 0;

            ConnectionStringSettings
                connectionStrings = WebConfigurationManager.ConnectionStrings["SybaseASEServer"];

            Application["connectionString"] = "Provider=" + connectionStrings.ProviderName + ";" + connectionStrings.ConnectionString;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            Log.Log.WriteToLog("Session_Start (Session.SessionID: " + Session.SessionID + ")", true);
            Application["UserOnline"] = (int)Application["UserOnline"] + 1;
        }

        protected void Session_End(Object sender, EventArgs e)
        {
            Log.Log.WriteToLog("Session_End (Session.SessionID: " + Session.SessionID + ")", true);
            Application["UserOnline"] = (int)Application["UserOnline"] - 1;
        }
    }
}