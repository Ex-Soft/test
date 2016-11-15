using System;
using System.IO;
using System.Web;
using System.Xml;

namespace ExtJSI
{
	public class TestGridDataXmlHandler : IHttpHandler
	{
			public void ProcessRequest(HttpContext context)
			{
				context.Response.CacheControl = "no-cache";
				context.Response.AppendHeader("Pragma", "no-cache");
				context.Response.Expires = -1;
				context.Response.AppendHeader("Content-type", "text/xml");

				XmlDocument
					doc = new XmlDocument();

				XmlNode
					docNode = doc.CreateXmlDeclaration("1.0", "windows-1251", null),
					NNode = doc.CreateElement("TestGridDataXml");

				doc.AppendChild(docNode);
				doc.AppendChild(NNode);
				for (int i = 0; i < 5; ++i)
				{
					XmlNode
						Node = doc.CreateElement("movie"),
						Field;

					Field=doc.CreateElement("id");
					Field.AppendChild(doc.CreateTextNode(Convert.ToString(i)));
					Node.AppendChild(Field);

					Field=doc.CreateElement("title");
					Field.AppendChild(doc.CreateTextNode("title"+Convert.ToString(i)));
					Node.AppendChild(Field);

					Field=doc.CreateElement("year");
					Field.AppendChild(doc.CreateTextNode(Convert.ToString(1980+i)));
					Node.AppendChild(Field);

					Field=doc.CreateElement("rating");
					Field.AppendChild(doc.CreateTextNode(Convert.ToString(33+i)));
					Node.AppendChild(Field);

					doc.DocumentElement.AppendChild(Node);
				}

				doc.Save(context.Server.MapPath(null) + Path.DirectorySeparatorChar + "TestGridDataXml.xml");

				XmlTextWriter
					w = new XmlTextWriter(context.Response.Output);

				doc.WriteContentTo(w);
				w.Flush();
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
