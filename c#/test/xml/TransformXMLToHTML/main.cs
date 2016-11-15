// http://stackoverflow.com/questions/1778299/simplest-way-to-transform-xml-to-html-with-xslt-in-c

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace TransformXMLToHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string
               currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
               fileXml,
               fileXslt,
               xml,
               xslt,
               outputFile;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            if (!File.Exists(fileXml = Path.Combine(currentDirectory, "data.xml"))
                || !File.Exists(fileXslt = Path.Combine(currentDirectory, "data.xslt"))
                || string.IsNullOrWhiteSpace(xml = File.ReadAllText(fileXml, Encoding.UTF8))
                || string.IsNullOrWhiteSpace(xslt = File.ReadAllText(fileXslt, Encoding.UTF8)))
                return;

            if (File.Exists(outputFile = Path.Combine(currentDirectory, "data.html")))
                File.Delete(outputFile);

            File.WriteAllText(outputFile, TransformXMLToHTML(xml, xslt), Encoding.UTF8);
        }

        public static string TransformXMLToHTML(string inputXml, string xsltString)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader readerXslt = XmlReader.Create(new StringReader(xsltString)))
            {
                transform.Load(readerXslt);
            }
            StringWriter results = new StringWriter();
            using (XmlReader readerXml = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(readerXml, null, results);
            }
            return results.ToString();
        }
    }
}
