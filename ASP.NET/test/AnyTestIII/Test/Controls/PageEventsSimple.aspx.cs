using System;

namespace AnyTest
{
	public class PageEventsSimple : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Init(object sender, EventArgs e)
		{
			Label1.Text+="Page_Init<br />";
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Label1.Text+="Page_Load<br />";
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
			this.TextBox1.TextChanged += new EventHandler(TextBox1_TextChanged);
			this.DropDownList1.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);
		}
		#endregion

		private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Label1.Text+="DropDownList_SelectedIndexChanged<br />";
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			Label1.Text+="TextBox_TextChanged<br />";
		}
	}
}
