using System;

namespace AnyTest
{
	public class TestHtcWValidatorForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxDate1;
		protected System.Web.UI.WebControls.TextBox TextBoxDate2;
		protected System.Web.UI.WebControls.TextBox TextBoxDate3;
		protected System.Web.UI.WebControls.TextBox TextBoxDate4;
		protected System.Web.UI.WebControls.CustomValidator CustomValidatorDate4;
		protected System.Web.UI.WebControls.Button ButtonSave;
	
		private void Page_Init(object sender, System.EventArgs e)
		{
			//
		}
		//---------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			TextBoxDate3.Text=DateTime.Now.AddYears(-1).ToShortDateString();
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
			this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void ButtonSave_Click(object sender, EventArgs e)
		{

		}
		//---------------------------------------------------------------------------
	}
}
