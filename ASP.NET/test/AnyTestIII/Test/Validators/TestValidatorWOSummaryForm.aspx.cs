using System;

namespace AnyTest
{
	public class TestValidatorWOSummaryForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Label LabelTextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorTextBox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorTextBox2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorTextBox3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorTextBox4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorTextBox5;
		protected System.Web.UI.WebControls.Button ASPButtonSubmit;

		private void Page_Load(object sender, System.EventArgs e)
		{
			LabelInfo.Text=DateTime.Now.ToString()+" IsPostBack=\""+IsPostBack.ToString().ToLower()+"\"";
			LabelTextBox2.Text="\""+TextBox2.Text.Trim()+"\"";
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
