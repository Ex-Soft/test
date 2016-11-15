using System.Configuration;

namespace TestFormAuthentication
{
	using System;

	public class SignInII : System.Web.UI.UserControl
	{
		public enum UserRight:long
		{
			ur_Unknown,						// 00000000b
			ur_SetVIPEnabled,				// 00000001b
			ur_MakeReportsEnabled=2,		// 00000010b
			ur_IsRoot=4,					// 00000100b
			ur_AccessPermissionsEnabled=8	// 00001000b
		}

		protected System.Web.UI.WebControls.Panel PanelLoginPassword;
		protected System.Web.UI.WebControls.Panel PanelAdditionalInfo;
		protected System.Web.UI.WebControls.Label LabelMessage;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorLogin;
		protected System.Web.UI.WebControls.TextBox TextBoxLogin;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorPassword;
		protected System.Web.UI.WebControls.TextBox TextBoxPassword;
		protected System.Web.UI.WebControls.Button btnSignIn;

		private string
			FDataSource=string.Empty,
			FAppSettingsKeyLogin=string.Empty,
			FAppSettingsKeyPassword=string.Empty,
			FDatabaseFieldNameUserId=string.Empty,
			FDatabaseFieldNamePassword=string.Empty,
			FDatabaseFieldNameRight=string.Empty,
			FRightValue=string.Empty,
			InvalidUserOrPasswordMessage="<br>Не підійшли ваш логін та пароль.<br>Спробуйте ще раз!";

		private long
			FUserId=long.MinValue;

		public string InputLogin
		{
			get
			{
				return(TextBoxLogin.Text.Trim());
			}
			set
			{
				if(TextBoxLogin.Text.Trim()!=value)
					TextBoxLogin.Text=value;
			}
		}
		//---------------------------------------------------------------------------

		public string InputPassword
		{
			get
			{
				return(TextBoxPassword.Text.Trim());
			}
			set
			{
				if(TextBoxPassword.Text.Trim()!=value)
					TextBoxPassword.Text=value;
			}
		}
		//---------------------------------------------------------------------------

		public string DataSource
		{
			get
			{
				return(FDataSource);
			}
			set
			{
				if(FDataSource!=value)
					FDataSource=value;
			}
		}
		//---------------------------------------------------------------------------

		public string AppSettingsKeyLogin
		{
			get
			{
				return(FAppSettingsKeyLogin);
			}
			set
			{
				if(FAppSettingsKeyLogin!=value)
					FAppSettingsKeyLogin=value;
			}
		}
		//---------------------------------------------------------------------------

		public string AppSettingsKeyPassword
		{
			get
			{
				return(FAppSettingsKeyPassword);
			}
			set
			{
				if(FAppSettingsKeyPassword!=value)
					FAppSettingsKeyPassword=value;
			}
		}
		//---------------------------------------------------------------------------

		public string DatabaseFieldNameUserId
		{
			get
			{
				return(FDatabaseFieldNameUserId);
			}
			set
			{
				if(FDatabaseFieldNameUserId!=value)
					FDatabaseFieldNameUserId=value;
			}
		}
		//---------------------------------------------------------------------------

		public string DatabaseFieldNamePassword
		{
			get
			{
				return(FDatabaseFieldNamePassword);
			}
			set
			{
				if(FDatabaseFieldNamePassword!=value)
					FDatabaseFieldNamePassword=value;
			}
		}
		//---------------------------------------------------------------------------

		public string DatabaseFieldNameRight
		{
			get
			{
				return(FDatabaseFieldNameRight);
			}
			set
			{
				if(FDatabaseFieldNameRight!=value)
					FDatabaseFieldNameRight=value;
			}
		}
		//---------------------------------------------------------------------------

		public string RightValue
		{
			get
			{
				return(FRightValue);
			}
			set
			{
				if(FRightValue!=value)
					FRightValue=value;
			}
		}
		//---------------------------------------------------------------------------

		public long UserId
		{
			get
			{
				return(FUserId);
			}
			set
			{
				if(FUserId!=value)
					FUserId=value;
			}
		}
		//---------------------------------------------------------------------------

		public delegate void SignInIIEventHandler(object sender, SignInIIEventArgs e);

		public event SignInIIEventHandler Login;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSignIn.Click +=new EventHandler(btnSignIn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSignIn_Click(object sender, EventArgs e)
		{
			if(Login!=null)
			{
				bool
					IsValid=false;

				string
					AppSettingsLogin,
					AppSettingsPassword;

				switch(DataSource)
				{
					case "WebConfig" :
					{
						if(AppSettingsKeyLogin==string.Empty)
							LabelMessage.Text="\"AppSettingsKeyLogin\" is undefined!!!";
						else if(AppSettingsKeyPassword==string.Empty)
							LabelMessage.Text="\"AppSettingsKeyPassword\" is undefined!!!";
						else if((AppSettingsLogin=ConfigurationSettings.AppSettings[AppSettingsKeyLogin])==null || AppSettingsLogin==string.Empty)
							LabelMessage.Text="ConfigurationSettings.AppSettings[\""+AppSettingsKeyLogin+"\"] is empty!!!";
						else if((AppSettingsPassword=ConfigurationSettings.AppSettings[AppSettingsKeyPassword])==null || AppSettingsPassword==string.Empty)
							LabelMessage.Text="ConfigurationSettings.AppSettings[\""+AppSettingsKeyPassword+"\"] is empty!!!";
						else if(InputLogin!=AppSettingsLogin || InputPassword!=AppSettingsPassword)
							LabelMessage.Text=InvalidUserOrPasswordMessage;
						else
							IsValid=true;

						if(!PanelAdditionalInfo.Visible)
						{
							PanelLoginPassword.Visible=false;
							PanelAdditionalInfo.Visible=true;
							IsValid=false;
						}

						break;
					}
					case "DataBase" :
					{
						if(DatabaseFieldNamePassword==string.Empty)
							LabelMessage.Text="\"DatabaseFieldNamePassword\" is undefined!!!";
						else
						{
						}

						break;	
					}
					default :
					{
						LabelMessage.Text="\"DataSource\" is undefined!!!";
						break;	
					}
				}
				Login(this,new SignInIIEventArgs(IsValid,UserId));
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------

	public class SignInIIEventArgs
	{
		private bool
			LoginValid=false;

		private long
			LoginUserId=long.MinValue;

		public SignInIIEventArgs(bool IsValid, long UserId)
		{
			LoginValid=IsValid;
			LoginUserId=UserId;
		}
		//---------------------------------------------------------------------------

		public bool IsValid
		{
			get
			{
				return(LoginValid);
			}
		}
		//---------------------------------------------------------------------------

		public long UserId
		{
			get
			{
				return(LoginUserId);
			}
		}
		//---------------------------------------------------------------------------
	}
	//---------------------------------------------------------------------------
}