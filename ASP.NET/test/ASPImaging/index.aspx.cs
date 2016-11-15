using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ASPImaging
{
	/// <summary>
	/// Summary description for index.
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPosX;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPosY;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
	
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
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//note down x position of click
			if (txtPosX.Value ==string.Empty )
				txtPosX.Value = e.X.ToString();
			else
				txtPosX.Value += "," + e.X;

			//note down y position of click
			if (txtPosY.Value ==string.Empty )
				txtPosY.Value = e.Y.ToString();
			else
				txtPosY.Value += "," + e.Y;

			//passValues to imager.aspx to create the new enlarged image
			ImageButton1.ImageUrl="imager.aspx?type=zoom&x=" + 
							txtPosX.Value + "&y=" + txtPosY.Value;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			ImageButton1.ImageUrl="imager.aspx";
			txtPosX.Value="";
			txtPosY.Value="";
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Image1.ImageUrl ="imager.aspx?type=enlarge";
		}
	}
}
