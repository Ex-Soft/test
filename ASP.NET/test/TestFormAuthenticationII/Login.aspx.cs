using System;
using System.Web.Security;

namespace TestFormAuthentication
{
	public class LoginForm : System.Web.UI.Page
	{
		protected SignInII objSignInII;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("TestFormAuthentication::LoginForm::Page_Load() (IsPostBack="+IsPostBack.ToString().ToLower()+")",true);
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
			this.objSignInII.Login += new SignInII.SignInIIEventHandler(objSignInII_Login);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void objSignInII_Login(object sender, SignInIIEventArgs e)
		{
			if(e.IsValid)
			{
				// throw(new Exception("Test"));

				FormsAuthentication.RedirectFromLoginPage(e.UserId.ToString(),false);
			}
		}
	}
}
