<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application["UserOnline"] = 0;

        ConnectionStringSettings
            connectionStrings = WebConfigurationManager.ConnectionStrings["SybaseASEServer"];

        Application["connectionString"] = "Provider=" + connectionStrings.ProviderName + ";" + connectionStrings.ConnectionString;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Log.Log.WriteToLog("Session_Start (Session.SessionID: " + Session.SessionID + ")", true);
        Application["UserOnline"] = (int)Application["UserOnline"] + 1; 
    }

    void Session_End(object sender, EventArgs e) 
    {
        Log.Log.WriteToLog("Session_End (Session.SessionID: " + Session.SessionID + ")", true);
        Application["UserOnline"] = (int)Application["UserOnline"] - 1;
    }
       
</script>
