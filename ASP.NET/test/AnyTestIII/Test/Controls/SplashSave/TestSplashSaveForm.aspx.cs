using System;
using System.Threading;

namespace AnyTest
{
	public class TestSplashSaveForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxSmth;
		protected System.Web.UI.WebControls.CheckBox CheckBoxWithRedirect;
		protected System.Web.UI.WebControls.Button SaveButton;
	
		private void Page_Init(object sender, System.EventArgs e)
		{
			//
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{

			}
		}
		//---------------------------------------------------------------------------

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
			this.SaveButton.Click+=new EventHandler(SaveButton_Click);
			this.Load+=new System.EventHandler(this.Page_Load);
			this.Init+=new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Thread.Sleep(10*1000);
			if(CheckBoxWithRedirect.Checked)
			{
				Response.Redirect("SaveDone.html");
			}
		}
		//---------------------------------------------------------------------------
	}
}
