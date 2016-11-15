using System;
using System.Collections.Specialized;

namespace AnyTest
{
	public class TestSubmit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(IsPostBack)
			{
				string
					tmpString=string.Empty;

				NameObjectCollectionBase.KeysCollection
					inpt=Request.Form.Keys;

				for(int i=0; i<inpt.Count; ++i)
				{
					if(tmpString!=string.Empty)
						tmpString+="<br>";

					tmpString+=inpt[i];
				}

				Label1.Text=tmpString;
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