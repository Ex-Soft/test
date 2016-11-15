//#define TEST_ERROR

using System;
using System.IO;
using System.Web;
using System.Xml;

namespace AnyTestII
{
	public class TestInputByAJAXHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				SubStr;

			if (string.IsNullOrEmpty(SubStr = context.Request.Form["substr"]))
				return;

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ClearHeaders();
			context.Response.ClearContent();

			#if TEST_ERROR
				//context.Response.StatusCode = 333;
				//context.Response.StatusDescription = "Ашипка";
				// equ
				context.Response.Status = "333 Ашипка";

				context.Response.Write("blah-blah-blah");

				//context.Response.Write("HTTP/1.1 333 Ашипка");
				//context.Response.Write("Server: ASP.NET Development Server/9.0.0.0");
				//context.Response.Write("Date: Thu, 19 Aug 2010 12:38:25 GMT");
				//context.Response.Write("X-AspNet-Version: 2.0.50727");
				//context.Response.Write("Cache-Control: private");
				//context.Response.Write("Content-Type: text/html");
				//context.Response.Write("Connection: Close");

				context.Response.Flush();
				return;
			#endif

			context.Response.AppendHeader("Content-type", "text/xml");

			XmlDocument
				doc = new XmlDocument();

			XmlNode
				tmpXmlNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);

			doc.AppendChild(tmpXmlNode);
			tmpXmlNode = doc.CreateElement("NSIData");
			doc.AppendChild(tmpXmlNode);
			for (int i = 0; i < SubStr.Length; ++i)
			{
				XmlNode
					Node = doc.CreateElement("NSI");

				Node.Attributes.Append(doc.CreateAttribute("value"));
				Node.Attributes["value"].Value = Convert.ToString(i);
				Node.Attributes.Append(doc.CreateAttribute("text"));
				Node.Attributes["text"].Value=SubStr;
				doc.DocumentElement.AppendChild(Node);
			}
			doc.Save(context.Server.MapPath(null) + Path.DirectorySeparatorChar + "NSIXmlData.xml");

			XmlTextWriter
				w = new XmlTextWriter(context.Response.OutputStream,null);

			doc.WriteContentTo(w);
			w.Flush();
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}
}
