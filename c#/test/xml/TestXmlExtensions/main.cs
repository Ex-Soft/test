using System.IO;
using System.Xml;

namespace TestXmlExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument
                doc = new XmlDocument();

            doc.AppendDeclaration();

            XmlElement
                root = doc.AppendElement("root"),
                f2 = doc.CreateElement("Field2"),
                f3 = doc.CreateAndSetElement("Field3", "Field3Value");

            root.AppendChild(doc.CreateAndSetElement("Field1", "Field1Value"));
            f2.SetValue("Field2Value");
            root.AppendChild(f2);
            f3.SetValue("Field33Value");
            root.AppendChild(f3);

            string
                currentDirectory = Directory.GetCurrentDirectory();

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                fileName = currentDirectory + "data.xml";

            if(File.Exists(fileName))
                File.Delete(fileName);

            doc.Save(fileName);
       }
    }
}
