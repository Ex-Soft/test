using System;
using System.Web.UI.WebControls;

namespace TestFrames
{
	public class FrameRightButtonForm : System.Web.UI.Page
	{
		protected Label LabelInfo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			LabelInfo.Text=DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff")+" (IsPostBack="+IsPostBack.ToString().ToLower()+")";
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
