using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestControlsForm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Test_Controls_Form;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlInputButton1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlInputButton2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlInputButton3;
		protected System.Web.UI.WebControls.Button ButtonDisable;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlButtonDisable;
		
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.HtmlButtonDisable.ServerClick+=new EventHandler(Disable_Click);
			this.ButtonDisable.Click+=new EventHandler(Disable_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Disable_Click(object sender, EventArgs e)
		{
			foreach(Control c in Test_Controls_Form.Controls)
			{
				DisableButtons(c);
			}
		}

		void DisableButtons(Control tmpControl)
		{
			if(!tmpControl.HasControls())
			{
				Button
					tmpButton=tmpControl as Button;

				HtmlInputButton
					tmpHtmlInputButton=tmpControl as HtmlInputButton;

				if(tmpButton!=null)
					tmpButton.Enabled=false;
				if(tmpHtmlInputButton!=null)
					tmpHtmlInputButton.Disabled=true;
			}
			else
				DisableButtons(tmpControl);
		}
	}
}