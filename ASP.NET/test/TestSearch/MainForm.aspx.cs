using System;

namespace TestSearch
{
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl MainFrameSet;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				if(MainFrameSet!=null)
				{
					;
				}
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
