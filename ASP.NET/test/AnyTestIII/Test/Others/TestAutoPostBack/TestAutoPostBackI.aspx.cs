using System;

namespace AnyTest
{
	public class TestAutoPostBackIForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBox CheckBoxAutoPostBack;
		protected System.Web.UI.WebControls.Label LabelInfo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			LabelInfo.Text="IsPostBack=\""+IsPostBack.ToString().ToLower()+"\"";
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
			this.CheckBoxAutoPostBack.CheckedChanged += new EventHandler(CheckBoxAutoPostBack_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void CheckBoxAutoPostBack_CheckedChanged(object sender, EventArgs e)
		{
			LabelInfo.Text+=" CheckBoxAutoPostBack_CheckedChanged (CheckBoxAutoPostBack.Checked=\""+CheckBoxAutoPostBack.Checked.ToString().ToLower()+"\")";
		}
	}
}
