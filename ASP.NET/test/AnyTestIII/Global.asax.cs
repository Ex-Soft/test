using System;

namespace AnyTest 
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
			Log.Log.WriteToLog("Application_Start",true);
			Application["UserOnline"]=0;
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Session_Start (Session.SessionID: "+Session.SessionID+")",true);
			Application["UserOnline"]=(int)Application["UserOnline"]+1;
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

		}

		protected void Session_End(Object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Session_End (Session.SessionID: "+Session.SessionID+")",true);
			Application["UserOnline"]=(int)Application["UserOnline"]-1;
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			Log.Log.WriteToLog("Application_End",true);
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

		public static string GetFormValueFromRequest(System.Web.HttpRequest aRequest, string aParamName)
		{
			string[]
				ParamArray=aRequest.Form.GetValues(aParamName);

			string
				ParamValue=string.Empty;

			if(ParamArray!=null && ParamArray.Length>0)
				ParamValue=ParamArray[0];

			return(ParamValue);
		}
		//---------------------------------------------------------------------------

		public static string GetQueryStringValueFromRequest(System.Web.HttpRequest aRequest, string aParamName)
		{
			string[]
				ParamArray=aRequest.QueryString.GetValues(aParamName);

			string
				ParamValue=string.Empty;

			if(ParamArray!=null && ParamArray.Length>0)
				ParamValue=ParamArray[0];

			return(ParamValue);
		}
		//---------------------------------------------------------------------------

		public static void CheckDataGridPageIndex(System.Web.UI.WebControls.DataGrid aDataGrid, int aRecordCount)
		{
			if(!aDataGrid.AllowPaging)
				return;

			int
				MaxPage=aRecordCount/aDataGrid.PageSize+(aRecordCount%aDataGrid.PageSize!=0 ? 1 : 0);

			if(aDataGrid.CurrentPageIndex>=MaxPage)
				aDataGrid.CurrentPageIndex = MaxPage>0 ? MaxPage-1 : 0;
		}
		//---------------------------------------------------------------------------
	}
}

