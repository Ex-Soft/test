using System;
using System.Collections;

namespace AnyTest
{
	/// <summary>
	/// Summary description for CheckAllLoad.
	/// </summary>
	public class CheckAllLoad : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Definitions;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				tmpString=string.Empty,
				key;

			IEnumerator
				keys=Definitions.Attributes.Keys.GetEnumerator();

			while(keys.MoveNext()) 
			{
				if(tmpString!=string.Empty)
					tmpString+="<br>";

				tmpString+=(key=(String)keys.Current)+"='"+Definitions.Attributes[key]+"'";
			}
			LabelInfo.Text=tmpString;
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
