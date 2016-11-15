using System;

namespace TestMSAppCenterTest
{
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnDoIt;
	
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
			this.btnDoIt.Click += new System.EventHandler(this.btnDoIt_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDoIt_Click(object sender, EventArgs e)
		{
			Label1.Text=TextBox1.Text;
		}
	}
}
