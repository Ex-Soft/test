using System.Xml;

namespace TestXmlExtensions
{
    public static class XmlDocumentExtensions
    {
        public static XmlNode AppendDeclaration(this XmlDocument xmlDocument)
        {
            XmlNode declaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(declaration);
            return declaration;
        }

        public static XmlElement CreateAndSetElement(this XmlDocument xmlDocument, string elementName, string value)
        {
            XmlElement element = xmlDocument.CreateElement(elementName);
            element.AppendChild(xmlDocument.CreateTextNode(value));
            return element;
        }

        public static XmlElement AppendElement(this XmlDocument xmlDocument, string elementName)
        {
            XmlElement element = xmlDocument.CreateElement(elementName);
            xmlDocument.AppendChild(element);
            return element;
        }
    }
}
