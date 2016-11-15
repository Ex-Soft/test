using System;
using System.Threading;

namespace AnyTest
{
	public class TestSubmitWDisabledForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxSleep;
		protected System.Web.UI.WebControls.TextBox TextBoxHTMLSubmit;
		protected System.Web.UI.WebControls.Label LabelHTMLSubmit;
		protected System.Web.UI.WebControls.TextBox TextBoxASPSubmit;
		protected System.Web.UI.WebControls.Button btnASPSubmit;
		protected System.Web.UI.WebControls.Label LabelASPSubmit;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				LabelHTMLSubmit.Text="'"+TextBoxHTMLSubmit.Text+"'";

				int
					SleepMS=5000;

				string
					tmpString;

				if((tmpString=TextBoxSleep.Text.Trim())!=string.Empty)
				{
					try
					{
						SleepMS=Convert.ToInt32(tmpString);
						SleepMS*=1000;
					}
					catch
					{
						;
					}
				}
				Thread.Sleep(SleepMS);
			}
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
			this.btnASPSubmit.Click+=new EventHandler(btnASPSubmit_Click);
			this.Load+=new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnASPSubmit_Click(object sender, EventArgs e)
		{
			LabelASPSubmit.Text="'"+TextBoxASPSubmit.Text+"'";
		}
	}
}
