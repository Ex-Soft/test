using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace AnyTest
{
	public class OthersAnyTestSmlForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnGetProcessesByName;
		protected System.Web.UI.WebControls.Label LabelGetProcessesByName;
		protected System.Web.UI.WebControls.Button btnSetSessionSmthValue;
		protected System.Web.UI.WebControls.Label LabelServerMapPath;
		protected System.Web.UI.WebControls.Button ButtonAppSettingsTestVariableGet;
		protected System.Web.UI.WebControls.TextBox TextBoxAppSettingsTestVariableGet;
		protected System.Web.UI.WebControls.Button ButtonAppSettingsTestVariableSet;
		protected System.Web.UI.WebControls.TextBox TextBoxAppSettingsTestVariableSet;
		protected System.Web.UI.WebControls.TextBox TextBoxWCS;
		protected System.Web.UI.WebControls.Button ButtonDisabled;
		protected System.Web.UI.WebControls.TextBox TextBoxInputText;
		protected System.Web.UI.WebControls.TextBox TextBoxInputDate;
		protected System.Web.UI.WebControls.Button ButtonInputTextDateSubmit;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlInputButtonWithCheckSubmit;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIVTest;
		protected System.Web.UI.WebControls.TextBox TextBoxApp;
		protected System.Web.UI.WebControls.TextBox TextBoxParameters;
		protected System.Web.UI.WebControls.Button ButtonRunProcess;
		protected System.Web.UI.HtmlControls.HtmlInputButton ButtonParent;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				LabelServerMapPath.Text="Server.MapPath(null)=\""+Server.MapPath(null)+"\"<br>"+
					"Server.MapPath(\"bill\")=\""+Server.MapPath("bill")+"\"<br>"+
					"Server.MapPath(\""+Request.ApplicationPath+"\")=\""+Server.MapPath(Request.ApplicationPath)+"\"<br>"+
					"System.IO.Path.GetDirectoryName(new Uri(System.Web.HttpContext.Current.Request.PhysicalApplicationPath).LocalPath)=\""+System.IO.Path.GetDirectoryName(new Uri(System.Web.HttpContext.Current.Request.PhysicalApplicationPath).LocalPath)+"\"<br>";

				TextBoxWCS.Attributes.Add("onkeydown","alert('onkeydown')");
				//ButtonDisabled.Attributes.Add("onclick","alert('onclick')");
				ButtonDisabled.Attributes.Add("onclick","alert('onclick');this.disabled=true");

				DIVTest.InnerHtml="InnerHtml";
				
				string
					tmpString="КСП \"Пам'яті леніна\"";

				ButtonParent.Attributes.Add("onclick","Birth('DivParent','<span style=\x22color: red\x22>"+tmpString.Replace("\\","\\\\").Replace("'","\\'").Replace("\"","\\x22")+"</span>');");
			}
			else
			{
				// Thread.Sleep(5000);
			}

			string
				scriptString="<script type=\"text/javascript\">\n<!--\n";

			scriptString+="function OnLoad(){alert('OnLoad()');}";
			scriptString+="\n// -->\n";
			scriptString+="<";
			scriptString+="/";
			scriptString+="script>";
        
			if(!this.IsStartupScriptRegistered("Startup"))
				this.RegisterStartupScript("Startup",scriptString);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonRunProcess.Click+=new EventHandler(ButtonRunProcess_Click);
			this.HtmlInputButtonWithCheckSubmit.ServerClick+=new EventHandler(HtmlInputButtonWithCheckSubmit_ServerClick);
			this.ButtonInputTextDateSubmit.Click+=new EventHandler(ButtonInputTextDateSubmit_Click);
			this.ButtonDisabled.Click+=new EventHandler(ButtonDisabled_Click);
			this.ButtonAppSettingsTestVariableGet.Click+=new EventHandler(ButtonAppSettingsTestVariableGetSet_Click);
			this.ButtonAppSettingsTestVariableSet.Click+=new EventHandler(ButtonAppSettingsTestVariableGetSet_Click);
			this.btnSetSessionSmthValue.Click+=new EventHandler(btnSetSessionSmthValue_Click);
			this.btnGetProcessesByName.Click+=new System.EventHandler(this.btnGetProcessesByName_Click);
			this.Load+=new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGetProcessesByName_Click(object sender, EventArgs e)
		{
			LabelGetProcessesByName.Text=string.Empty;

			try
			{
				Process[]
					ProcessList=Process.GetProcessesByName("Explorer"/*,"127.0.0.1"*/);

				for(int ii=0; ii<ProcessList.Length; ++ii)
				{
					LabelGetProcessesByName.Text+="ProcessList["+ii+"].StartTime="+ProcessList[ii].StartTime.ToString()+"<br>";
					LabelGetProcessesByName.Text+="ProcessList["+ii+"].HasExited="+ProcessList[ii].HasExited.ToString()+"<br>";
				}
			}
			catch(Exception eException)
			{
				LabelGetProcessesByName.Text+=eException.GetType().FullName+"<br>Message: "+eException.Message+"<br>StackTrace:<br>"+eException.StackTrace;
			}
		}

		private void btnSetSessionSmthValue_Click(object sender, EventArgs e)
		{
			Session["SmthValue"]=true;
		}

		private void ButtonAppSettingsTestVariableGetSet_Click(object sender, EventArgs e)
		{
			System.Web.UI.WebControls.Button
				tmpButton;

			if((tmpButton=sender as System.Web.UI.WebControls.Button)==null)
				return;

			switch(tmpButton.ID)
			{
				case "ButtonAppSettingsTestVariableGet" :
				{
					string
						tmpString=ConfigurationSettings.AppSettings["appSettingsTestVariable"];

					TextBoxAppSettingsTestVariableGet.Text = tmpString!=null ? tmpString : "undefined";

					break;
				}
				case "ButtonAppSettingsTestVariableSet" :
				{
					//ConfigurationSettings.AppSettings["appSettingsTestVariable"]=TextBoxAppSettingsTestVariableGet.Text;
					TextBoxAppSettingsTestVariableSet.Text="Collection is read-only!!!";

					break;
				}
			}
		}

		private void ButtonDisabled_Click(object sender, EventArgs e)
		{
			Response.Write("<script type=\"text/javascript\">\n<!--\n");
			Response.Write("alert('ButtonDisabled_Click');");
			Response.Write("\n// -->\n</script>");
		}

		private void ButtonInputTextDateSubmit_Click(object sender, EventArgs e)
		{
			Response.Write("<script type=\"text/javascript\">\n<!--\n");
			Response.Write("alert('ButtonInputTextDateSubmit_Click\\r\\nTextBoxInputText=\x22"+TextBoxInputText.Text.Trim()+"\x22\\r\\nTextBoxInputDate=\x22"+TextBoxInputDate.Text.Trim()+"\x22');");
			Response.Write("\n// -->\n</script>");
		}

		private void HtmlInputButtonWithCheckSubmit_ServerClick(object sender, EventArgs e)
		{
			Response.Write("<script type=\"text/javascript\">\n<!--\n");
			Response.Write("alert('HtmlInputButtonWithCheckSubmit_ServerClick');");
			Response.Write("\n// -->\n</script>");
		}

		private void ButtonRunProcess_Click(object sender, EventArgs e)
		{
			string
				tmpString;

			try
			{
				string
					AppName,
					Param;

				if((AppName=TextBoxApp.Text.Trim())==string.Empty)
					return;

				Process
					App=new Process();

				App.StartInfo.FileName=AppName;
				if((Param=TextBoxParameters.Text.Trim())!=string.Empty)
					App.StartInfo.Arguments=Param;

				try
				{
					if(App.Start())
					{
						App.WaitForExit();
						tmpString="App.ExitCode="+App.ExitCode.ToString();
						App.Close();
					}					
				}
				catch(Exception eException)
				{
						tmpString=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
				}
			}
			catch(Exception eException)
			{
					tmpString=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;
			}
		}
	}
}
