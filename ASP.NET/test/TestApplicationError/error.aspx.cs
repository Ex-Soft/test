using System;

namespace TestApplicationError
{
	public class error : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelMessage;
		protected System.Web.UI.WebControls.Label LabelSource;
		protected System.Web.UI.WebControls.Label LabelStackTrace;
		protected System.Web.UI.WebControls.Label LabelTargetSite;
		protected System.Web.UI.WebControls.Label LabelInnerExceptionMessage;
		protected System.Web.UI.WebControls.Label LabelInnerExceptionSource;
		protected System.Web.UI.WebControls.Label LabelInnerExceptionStackTrace;
		protected System.Web.UI.WebControls.Label LabelInnerExceptionTargetSite;
	
		private void Page_Init(object sender, System.EventArgs e)
		{
			//
		}
		//---------------------------------------------------------------------------
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				tmpString="LastExceptionMessage";
			
			LabelMessage.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastExceptionSource";
			LabelSource.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastExceptionStackTrace";
			LabelStackTrace.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastExceptionTargetSite";
			LabelTargetSite.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastInnerExceptionMessage";
			LabelInnerExceptionMessage.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastInnerExceptionSource";
			LabelInnerExceptionSource.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastInnerExceptionStackTrace";
			LabelInnerExceptionStackTrace.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
			tmpString="LastInnerExceptionTargetSite";
			LabelInnerExceptionTargetSite.Text = "\""+(Session[tmpString]!=null ? Convert.ToString(Session[tmpString]) : "null")+"\"";
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion
	}
}
