using System;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestRelatedIFrame1Form : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				string
					JSString = MainForm.StrBeginJS + "parent.document.getElementById(\"iframe2\").contentWindow.location.reload();" + MainForm.StrEndJS;

				//Response.Write(JSString);
				//JS.Text=JSString;

				if (!ClientScript.IsStartupScriptRegistered("OnLoad"))
					ClientScript.RegisterStartupScript(this.GetType(),"OnLoad", JSString);
			}

			SetLabelInfo(LabelInfo);
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature] = Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature] != null ? (int)Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature] + 1 : 0;
			SetLabelInfo(LabelInfo);
		}

		public static void SetLabelInfo(Label lbl)
		{
			lbl.Text = System.Web.HttpContext.Current.Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature] != null ? ((int)System.Web.HttpContext.Current.Session[TestRelatedIFrameMainForm.TestRelatedIFrameSessionSignature]).ToString() : "null";
		}
	}
}
