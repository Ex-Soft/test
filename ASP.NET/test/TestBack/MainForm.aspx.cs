using System;
using System.Web.UI.WebControls;

namespace TestBack
{
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.ListBox ListBox2;
		protected System.Web.UI.WebControls.ListBox ListBox3;

		protected System.Web.UI.WebControls.Button ButtonSubmit;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				ListBox1.Items.Add(new ListItem("# 1","1"));
				ListBox1.Items.Add(new ListItem("# 2","2"));
				ListBox1.Items.Add(new ListItem("# 3","3"));
				ListBox1.Items.Add(new ListItem("# 4","4"));
				ListBox1.Items.Add(new ListItem("# 5","5"));

				ListBox2.Items.Add(new ListItem("# 1","1"));
				ListBox2.Items.Add(new ListItem("# 2","2"));
				ListBox2.Items.Add(new ListItem("# 3","3"));
				ListBox2.Items.Add(new ListItem("# 4","4"));
				ListBox2.Items.Add(new ListItem("# 5","5"));

				ListBox3.Items.Add(new ListItem("# 1","1"));
				ListBox3.Items.Add(new ListItem("# 2","2"));
				ListBox3.Items.Add(new ListItem("# 3","3"));
				ListBox3.Items.Add(new ListItem("# 4","4"));
				ListBox3.Items.Add(new ListItem("# 5","5"));
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
			this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonSubmit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("RedirectForm.aspx");
		}
	}
}
