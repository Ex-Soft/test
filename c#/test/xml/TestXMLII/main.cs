using System;
using System.Xml;

namespace TestXMLII
{
	class TestXML
	{
		[STAThread]
		static void Main(string[] args)
		{
			XmlDocument
				tmpXmlDocument=new XmlDocument();

			XmlNode
				tmpXmlNode=tmpXmlDocument.CreateXmlDeclaration("1.0", "windows-1251", null);

			tmpXmlDocument.AppendChild(tmpXmlNode);
			tmpXmlNode=tmpXmlDocument.CreateElement("NSIXmlData");
			tmpXmlDocument.AppendChild(tmpXmlNode);

			DateTime
				DateBegin=DateTime.Now;

			tmpXmlNode=tmpXmlDocument.CreateElement("DateBegin");
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("Y"));
			tmpXmlNode.Attributes["Y"].Value=Convert.ToString(DateBegin.Year);
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("M"));
			tmpXmlNode.Attributes["M"].Value=Convert.ToString(DateBegin.Month-1);
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("D"));
			tmpXmlNode.Attributes["D"].Value=Convert.ToString(DateBegin.Day);
			tmpXmlDocument.DocumentElement.AppendChild(tmpXmlNode);

			string
				tmpString;

			if(tmpXmlNode.Attributes.Count>0)
			{
				tmpString=tmpXmlNode.Attributes["Y"].Value;
				tmpString+=tmpXmlNode.Attributes["M"].Value;
				tmpString+=tmpXmlNode.Attributes["D"].Value;
			}

			XmlElement
				tmpXmlElement=(XmlElement)tmpXmlNode;

			if(tmpXmlElement.Attributes.Count>0)
			{
				tmpString=tmpXmlElement.GetAttribute("Y");
				tmpString+=tmpXmlElement.GetAttribute("M");
				tmpString+=tmpXmlElement.GetAttribute("D");
			}

			XmlNodeList
				tmpXmlNodeList=tmpXmlDocument.GetElementsByTagName("DateBegin");

			foreach(XmlNode n in tmpXmlNodeList)
				if(n.Attributes.Count>0)
				{
					tmpString=n.Attributes["Y"].Value;
					tmpString+=n.Attributes["M"].Value;
					tmpString+=n.Attributes["D"].Value;
				}

			tmpXmlNode=tmpXmlDocument.CreateElement("DateBegin");
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("id"));
			tmpXmlNode.Attributes["id"].Value="DateBegin1";
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("Y"));
			tmpXmlNode.Attributes["Y"].Value=Convert.ToString(DateBegin.Year);
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("M"));
			tmpXmlNode.Attributes["M"].Value=Convert.ToString(DateBegin.Month-1);
			tmpXmlNode.Attributes.Append(tmpXmlDocument.CreateAttribute("D"));
			tmpXmlNode.Attributes["D"].Value=Convert.ToString(DateBegin.Day);
			tmpXmlDocument.DocumentElement.AppendChild(tmpXmlNode);

			tmpXmlElement=tmpXmlDocument.GetElementById("DateBegin1");
			tmpXmlElement=tmpXmlDocument.GetElementById("DateBegin2");

			tmpXmlDocument.Save("NSIXmlData.xml");
		}
	}
}
