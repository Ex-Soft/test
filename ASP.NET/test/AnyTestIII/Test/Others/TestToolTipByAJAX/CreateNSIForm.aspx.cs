#define TEST_STRING_IN_XML_WITH_1251

using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;

namespace AnyTest
{
	public class CreateNSIForm : System.Web.UI.Page
	{
		enum CModeType:byte
		{
			mt_Unknown,
			mt_Text,
			mt_XML
		}

		CModeType
			Mode=CModeType.mt_Unknown;

		const int
			Max=10;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Session[TestToolTipByAJAXForm.TestToolTipByAJAXFormDataSessionSignature]!=null)
				Session[TestToolTipByAJAXForm.TestToolTipByAJAXFormDataSessionSignature]=DateTime.Now;

			string[]
				ParamArray=Request.QueryString.GetValues("mode");

			string
				ParamValue=string.Empty;

			if(ParamArray!=null && ParamArray.Length>0)
				ParamValue=ParamArray[0].ToLower().Trim();

			if(ParamValue!=string.Empty)
			{
				switch(ParamValue)
				{
					case "txt" :
					{
						Mode=CModeType.mt_Text;
						break;
					}
					case "xml" :
					{
						Mode=CModeType.mt_XML;
						break;
					}
					default :
					{
						throw(new Exception("Unknown mode: \""+ParamValue+"\""));
					}
				}
			}
		}
		//---------------------------------------------------------------------------

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
			System.Threading.Thread.Sleep(3000);

			Response.CacheControl="no-cache";
			Response.AppendHeader("Pragma","no-cache");
			Response.Expires=-1;

			switch(Mode)
			{
				case CModeType.mt_Text :
				{
					StringBuilder
						outString=new StringBuilder();

					for(int i=0; i<Max; i+=2)
						outString.Append("NSITxt["+i+"]="+i*2+";");

					writer.Write(outString.ToString());

					break;
				}
				case CModeType.mt_XML :
				{
					Response.AppendHeader("Content-type","text/xml");

					XmlDocument
						doc=new XmlDocument();

					XmlNode
						docNode = doc.CreateXmlDeclaration("1.0", "windows-1251", null),
						NNode=doc.CreateElement("NSIXmlData");

					doc.AppendChild(docNode);
					doc.AppendChild(NNode);
					for(int i=0; i<Max; i+=2)
					{
						XmlNode
							Node=doc.CreateElement("NSIXml");

						Node.Attributes.Append(doc.CreateAttribute("Index"));
						Node.Attributes["Index"].Value=Convert.ToString(i);
						Node.Attributes.Append(doc.CreateAttribute("Value"));
						#if TEST_STRING_IN_XML_WITH_1251
							Node.Attributes["Value"].Value="Иванов";
						#else
							Node.Attributes["Value"].Value=Convert.ToString(i*3);
						#endif
						Node.AppendChild(doc.CreateTextNode(Convert.ToString(i*4)));
						doc.DocumentElement.AppendChild(Node);
					}
					doc.Save(Server.MapPath(null)+Path.DirectorySeparatorChar+"NSIXmlData.xml"); 

					XmlTextWriter
						w=new XmlTextWriter(writer);

					doc.WriteContentTo(w);
					w.Flush();

					break;	
				}
			}
		}
		//---------------------------------------------------------------------------
	}
}
