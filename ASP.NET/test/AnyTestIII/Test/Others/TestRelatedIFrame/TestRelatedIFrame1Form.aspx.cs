using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestRelatedIFrame1Form : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal JS;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.Label LabelInfo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				string
					JSString=TableForm.StrBeginJS+"parent.document.getElementById(\"iframe2\").contentWindow.location.reload();"+TableForm.StrEndJS;

				//Response.Write(JSString);
				//JS.Text=JSString;

				if(!IsStartupScriptRegistered("OnLoad"))
					RegisterStartupScript("OnLoad",JSString); 
			}

			SetLabelInfo(LabelInfo);
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
			this.ButtonSubmit.Click += new EventHandler(ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature] = Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature]!=null ? (int)Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature]+1 : 0;
			SetLabelInfo(LabelInfo);
		}

		public static void SetLabelInfo(Label lbl)
		{
			lbl.Text = System.Web.HttpContext.Current.Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature]!=null ? ((int)System.Web.HttpContext.Current.Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature]).ToString() : "null";
		}
	}
}