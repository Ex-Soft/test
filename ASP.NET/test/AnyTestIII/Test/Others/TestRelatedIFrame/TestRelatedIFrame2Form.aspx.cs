using System;

namespace AnyTest
{
	public class TestRelatedIFrame2Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label LabelInfo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string[]
				Data;

			if((Data=Request.QueryString.GetValues("data"))!=null
				&& Data.Length>0)
				TextBox1.Text=Data[0];

			TestRelatedIFrame1Form.SetLabelInfo(LabelInfo);
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
