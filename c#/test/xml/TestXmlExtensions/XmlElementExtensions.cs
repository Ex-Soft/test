using System.Linq;
using System.Xml;

namespace TestXmlExtensions
{
    public static class XmlElementExtensions
    {
        public static XmlText SetValue (this XmlElement xmlElement, string value)
        {
            XmlText xmlText = (XmlText)xmlElement.ChildNodes.Cast<XmlNode>().SingleOrDefault(n => n.NodeType == XmlNodeType.Text);

            if (xmlText == null)
            {
                if (xmlElement.OwnerDocument != null)
                {
                    xmlText = xmlElement.OwnerDocument.CreateTextNode(value);
                    xmlElement.AppendChild(xmlText);
                }
            }
            else
                xmlText.Value = value;

            return xmlText;
        }
    }
}
