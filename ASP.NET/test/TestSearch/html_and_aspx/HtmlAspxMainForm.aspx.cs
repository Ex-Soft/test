using System;

namespace TestSearch
{
	public class HtmlAspxMainForm : System.Web.UI.Page
	{
		protected  System.Web.UI.HtmlControls.HtmlGenericControl IFrameSearchParameters;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				string[]
					ParamArray=Request.QueryString.GetValues("searchid");

				string
					ParamValue=string.Empty;

				if(ParamArray!=null && ParamArray.Length>0)
					ParamValue=ParamArray[0];

				if(ParamValue!=string.Empty)
				{
					string
						SearchHtmlURL=string.Empty;

					switch(Convert.ToInt64(ParamValue))
					{
						case 1 :
						{
							SearchHtmlURL="HtmlAspxSearch_1.html";
							break;	
						}
						default :
						{
							throw(new Exception("Unknown searchid=\""+ParamValue+"\""));	
						}
					}

					if(SearchHtmlURL!=string.Empty)
						IFrameSearchParameters.Attributes["src"]=SearchHtmlURL;
				}
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
