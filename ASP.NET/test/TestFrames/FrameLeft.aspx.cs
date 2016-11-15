using System;
using System.Web.UI.WebControls;

namespace TestFrames
{
	public class FrameLeftForm : System.Web.UI.Page
	{
		protected LinkButton LinkButton1;
		protected Button Button1;
		protected Label LabelInfo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				LinkButton1.Attributes.Add("onclick","FrameRightSet()");
				Button1.Attributes.Add("onclick","FrameRightSet()");
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
			this.LinkButton1.Click+=new EventHandler(Smth_Click);
			this.Button1.Click+=new EventHandler(Smth_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Smth_Click(object sender, EventArgs e)
		{
			LabelInfo.Text=DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.ffff")+" (IsPostBack="+IsPostBack.ToString().ToLower()+")";
		}
	}
}
