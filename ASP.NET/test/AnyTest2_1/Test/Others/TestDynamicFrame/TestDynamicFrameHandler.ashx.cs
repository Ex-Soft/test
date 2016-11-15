using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.IO;
using System.Web.UI;

namespace AnyTest2_1
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class TestDynamicFrameHandler : IHttpHandler, IReadOnlySessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				By = HttpUtility.HtmlEncode(context.Request.QueryString["By"]),
				SmthParam = HttpUtility.HtmlEncode(context.Request.QueryString["SmthParam"]);

			context.Response.ContentType = "text/html";

			switch(By)
			{
				case "File" :
				{
					context.Response.WriteFile("DynamicFrame.html");

					break;
				}
				case "HtmlTextWriter" :
				{
					StringWriter
						tmpStringWriter = new StringWriter();

					HtmlTextWriter
						tmpHtmlTextWriter = new HtmlTextWriter(tmpStringWriter);

					tmpHtmlTextWriter.WriteFullBeginTag("html");
					tmpHtmlTextWriter.WriteFullBeginTag("head");
					tmpHtmlTextWriter.WriteBeginTag("meta");
					tmpHtmlTextWriter.WriteAttribute("http-equiv", "Content-Type");
					tmpHtmlTextWriter.WriteAttribute("content", "text/html; charset=windows-1251");
					tmpHtmlTextWriter.Write(HtmlTextWriter.SelfClosingTagEnd);
					tmpHtmlTextWriter.WriteFullBeginTag("title");
					tmpHtmlTextWriter.Write("Dynamic Frame");
					tmpHtmlTextWriter.WriteEndTag("title");
					tmpHtmlTextWriter.WriteEndTag("head");
					tmpHtmlTextWriter.WriteFullBeginTag("body");
					tmpHtmlTextWriter.WriteFullBeginTag("h1");
					tmpHtmlTextWriter.Write("Dynamic Frame");
					tmpHtmlTextWriter.WriteEndTag("h1");
					if (!string.IsNullOrEmpty(SmthParam))
					{
						tmpHtmlTextWriter.WriteBeginTag("hr");
						tmpHtmlTextWriter.Write(HtmlTextWriter.SelfClosingTagEnd);
						tmpHtmlTextWriter.Write("SmthParam=" + SmthParam);
					}
					tmpHtmlTextWriter.WriteEndTag("body");
					tmpHtmlTextWriter.WriteEndTag("html");

					context.Response.Write(tmpStringWriter);

					break;
				}
			}

			context.Response.Flush();
			context.Response.End();
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
