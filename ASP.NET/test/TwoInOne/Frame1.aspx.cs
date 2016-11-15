using System;

namespace TwoInOne
{
	/// <summary>
	/// Summary description for Frame1.
	/// </summary>
	public class Frame1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownListFrame1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				ComboBoxData
					Data=new ComboBoxData();

				string
					Filter="    Id>=3    ";

				Response.Write("Filter=\""+Filter+"\" (b4)");
				Response.Write("<br>");
				Common.FillDropDownList(Data.Info,"Id","Description",Filter,DropDownListFrame1,true);
				Response.Write("Filter=\""+Filter+"\" (after)");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
