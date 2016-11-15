using System;

namespace TestApplicationError 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Session["LastExceptionMessage"]=Server.GetLastError().Message;
			Session["LastExceptionSource"]=Server.GetLastError().Source;
			Session["LastExceptionStackTrace"]=Server.GetLastError().StackTrace;
			Session["LastExceptionTargetSite"]=Server.GetLastError().TargetSite;
			
			Session["LastInnerExceptionMessage"]=Server.GetLastError().InnerException.Message;
			Session["LastInnerExceptionSource"]=Server.GetLastError().InnerException.Source;
			Session["LastInnerExceptionStackTrace"]=Server.GetLastError().InnerException.StackTrace;
			Session["LastInnerExceptionTargetSite"]=Server.GetLastError().InnerException.TargetSite;
			
			Server.ClearError();

			Response.Redirect("error.aspx");
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

