using System;

namespace AnyTest
{
	public class TestRadioDivForm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl DivUp;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DivDown;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DivCheckBox;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton HtmlInputRadioVisibleUp;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton HtmlInputRadioVisibleDown;
		protected System.Web.UI.WebControls.CheckBox CheckBoxOnOff;

		private void Page_Load(object sender, System.EventArgs e)
		{
			DivUp.Style["DISPLAY"] = HtmlInputRadioVisibleUp.Checked ? "block" : "none";
			DivDown.Style["DISPLAY"] = HtmlInputRadioVisibleDown.Checked ? "block" : "none";
			DivCheckBox.Style["DISPLAY"] = CheckBoxOnOff.Checked ? "block" : "none";
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
