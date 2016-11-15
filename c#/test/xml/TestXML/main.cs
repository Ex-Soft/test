// http://msdn.microsoft.com/en-us/library/ms256086%28v=vs.110%29.aspx

#define TEST_XML
//#define TEST_BR

using System;
using System.Linq;
using System.Xml;

namespace TestXML
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
                XmlDocument
                    doc = null;

                #if TEST_XML
                    doc = new XmlDocument();
                    doc.Load("TestConfig.xml");
                #endif

			    const string
                    AttrId="id",
			        Id = "TestId",
                    AttrIntId="FInt",
                    AttrDateTimeId="FDateTime";

				doc = new XmlDocument();

                XmlNode
                    node = doc.CreateXmlDeclaration("1.0", "utf-8", null),
                    RootNode;

                XmlNodeList
                    xmlNodeList;

                doc.AppendChild(node);
                RootNode = doc.CreateElement("root");

			    XmlAttribute
			        attr = doc.CreateAttribute(AttrId);

			    attr.Value = Id;

			    RootNode.Attributes.Append(attr);

                doc.AppendChild(RootNode);

			    XmlText
			        xmlText;

                #if TEST_BR
                    TestBr(RootNode);
                    if ((xmlNodeList = doc.GetElementsByTagName("rootTable")) != null
                        && xmlNodeList.Count > 0)
                    {
                        node = xmlNodeList[0];
                        Console.WriteLine("ChildNodes.Count={0}", node.ChildNodes.Count);
                        xmlText = (XmlText)node.ChildNodes.Cast<XmlNode>().Where(n => n.NodeType == XmlNodeType.Text).Select(n => n).SingleOrDefault();
                    }
                #endif

			    node = doc.CreateElement("SmthElement");

                attr = doc.CreateAttribute(AttrId);
			    attr.Value = Id + Id;
			    node.Attributes.Append(attr);

                attr = doc.CreateAttribute(AttrIntId);
                attr.Value = "13";
                node.Attributes.Append(attr);

                attr = doc.CreateAttribute(AttrDateTimeId);
                attr.Value = DateTime.Now.ToString("o");
                node.Attributes.Append(attr);

                xmlText = (XmlText)node.ChildNodes.Cast<XmlNode>().Where(n => n.NodeType == XmlNodeType.Text).Select(n => n).SingleOrDefault();
                node.AppendChild(doc.CreateTextNode("Test"));
			    xmlText = (XmlText)node.ChildNodes.Cast<XmlNode>().Where(n => n.NodeType == XmlNodeType.Text).Select(n => n).SingleOrDefault();

			    RootNode.AppendChild(node);

                Console.WriteLine(doc.InnerXml);

			    XmlElement
			        e;

                if ((e = doc.GetElementById(Id)) != null)
                    ;
                if ((e = doc.GetElementById(Id+Id)) != null)
                    ;

                xmlNodeList = doc.GetElementsByTagName("SmthElement");
                if (xmlNodeList != null
                    && xmlNodeList.Count>0)
                {
                    node = xmlNodeList[0];
                }

                if ((node = doc.SelectSingleNode(string.Format("//*[@{0}=\"{1}\"]", AttrId, Id+Id))) != null)
                {
                    Console.WriteLine(node.Attributes.Count);

                    if ((attr=node.Attributes[AttrIntId]) != null)
                    {
                        int
                            tmpInt = Convert.ToInt32(attr.Value);

                        Console.WriteLine(tmpInt);
                    }                        

                    if ((attr=node.Attributes[AttrDateTimeId]) != null)
                    {
                        DateTime
                            tmpDateTime = Convert.ToDateTime(attr.Value);

                        Console.WriteLine(tmpDateTime);
                    }
                }

                if((e=doc.DocumentElement)!=null
                    && e.HasChildNodes)
                {
                    foreach (XmlNode n in e.ChildNodes)
                        Console.WriteLine(n.Name);

                    node = e.FirstChild;
                    while(node!=null)
                    {
                        Console.WriteLine(node.Name);
                        node = node.NextSibling;
                    }
                }
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}

			Console.ReadLine();
		}

        #if TEST_BR
            static void TestBr(XmlNode node)
            {
                XmlElement
                    rootTable = node.OwnerDocument.CreateElement("rootTable");

                for (int r = 0; r < 3; ++r)
                {
                    XmlElement
                        row = node.OwnerDocument.CreateElement("row");

                    for (int c = 0; c < 3; ++c)
                    {
                        XmlElement
                            cell = node.OwnerDocument.CreateElement("cell");

                        string
                            text = string.Format("{0}{1}", r, c);

                        XmlText
                            xmlText = node.OwnerDocument.CreateTextNode(text);

                        cell.AppendChild(xmlText);

                        row.AppendChild(cell);
                    }

                        rootTable.AppendChild(row);
                }

                    node.AppendChild(rootTable);
            }
        #endif
	}
}
