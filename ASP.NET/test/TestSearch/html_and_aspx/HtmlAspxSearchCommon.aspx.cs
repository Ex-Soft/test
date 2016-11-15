using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web.UI;

namespace TestSearch
{
	public class HtmlAspxSearchCommonForm : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			NameObjectCollectionBase.KeysCollection
				inpt=Request.Form.Keys;

			string
				tmpString=string.Empty;

			string[]
				tmpStrings;

			for(int i=0; i<inpt.Count; ++i)
			{
				tmpStrings=Request.Form.GetValues(inpt[i]);

				if(tmpString!=string.Empty)
					tmpString+=" ";

				tmpString+=inpt[i];

				if(tmpStrings!=null)
				{
					tmpString+="=";
					for(int j=0; j<tmpStrings.Length; ++j)
						tmpString+="\""+tmpStrings[j]+"\"";
				}
			}

			Session[HtmlAspxSearchResultForm.HtmlAspxSearchResultFormDataSessionSignature]=tmpString;

			Response.Redirect(Request.UrlReferrer.AbsolutePath,true);
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

		protected override void Render(HtmlTextWriter writer)
		{
			/*
			StreamReader
				sr=null;

			try
			{
				try
				{
					string
						HtmlFileName=Server.MapPath(Request.UrlReferrer.AbsolutePath);

					if(File.Exists(HtmlFileName))
					{
						sr=new StreamReader(HtmlFileName);

						string
							tmpString;

						StringBuilder
							outString=new StringBuilder();

						while((tmpString=sr.ReadLine())!=null)
							outString.Append(tmpString+Environment.NewLine);

						sr.Close();
						sr=null;

						writer.Write(outString.ToString());
					}
					else
						writer.Write("The file \""+HtmlFileName+"\" doesn't exist");
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(sr!=null)
					sr.Close();
			}
			*/
		}
	}
}
