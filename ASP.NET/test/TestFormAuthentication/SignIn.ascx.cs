using System;
using System.Web;

namespace TestFormAuthentication
{
	public partial class SignIn : System.Web.UI.UserControl
	{
		private string
			FUserName = string.Empty;

		public string InputLogin
		{
			get
			{
				return TextBoxLogin.Text.Trim();
			}
			set
			{
				if (TextBoxLogin.Text.Trim() != value)
					TextBoxLogin.Text = value;
			}
		}

		public string InputPassword
		{
			get
			{
				return TextBoxPassword.Text.Trim();
			}
			set
			{
				if (TextBoxPassword.Text.Trim() != value)
					TextBoxPassword.Text = value;
			}
		}

		public string UserName
		{
			get
			{
				return FUserName;
			}
			set
			{
				if (FUserName != value)
					FUserName = value;
			}
		}

		public delegate void SignInEventHandler(object sender, SignInEventArgs e);

		public event SignInEventHandler Login;

		protected void btnSignIn_Click(object sender, EventArgs e)
		{
			if (Login != null)
			{
				bool
					IsValid = false;

				if (IsValid = InputLogin == "login" && InputPassword == "1")
					UserName = "UserName";
				else
					LabelMessage.Text = "U R wrong!!!";

				Login(this, new SignInEventArgs(IsValid, UserName));
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}

	public class SignInEventArgs
	{
		private bool
			LoginValid = false;

		private string
			LoginUserName = string.Empty;

		public SignInEventArgs(bool IsValid, string UserName)
		{
			LoginValid = IsValid;
			LoginUserName = UserName;
		}

		public bool IsValid
		{
			get { return LoginValid; }
		}

		public string UserName
		{
			get { return LoginUserName; }
		}
	}
}