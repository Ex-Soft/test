using System;
using System.Web.UI;

namespace AnyTest
{
	public class TestAutoPostBackIIIForm : System.Web.UI.Page
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

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			System.IO.StringWriter
				stringWriter=new System.IO.StringWriter();

			HtmlTextWriter
				htmlWriter=new HtmlTextWriter(stringWriter);

			base.Render(htmlWriter);

			string
				html=stringWriter.ToString();

			int
				Pos;

			if((Pos=html.IndexOf("theform.submit();"))>=0)
				html=html.Insert(Pos,"DoOnSubmit();\r\n\t\t");

			writer.Write(html);
		}

		private void CheckBoxAutoPostBack_CheckedChanged(object sender, EventArgs e)
		{
			LabelInfo.Text+=" CheckBoxAutoPostBack_CheckedChanged (CheckBoxAutoPostBack.Checked=\""+CheckBoxAutoPostBack.Checked.ToString().ToLower()+"\")";
		}
	}
}
