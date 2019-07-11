using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace TestXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            string
               currentDirectory = Directory.GetCurrentDirectory();

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                fileName = currentDirectory + "AddApp.config";

            if (!File.Exists(fileName))
                return;

            XmlDocument
                doc = new XmlDocument();

            try
            {
                doc.Load(fileName);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                return;
            }

            var nonExistent = doc.DocumentElement.SelectNodes("//nonExistent");

            XmlNodeList
                connectionStringNodes;

            // http://stackoverflow.com/questions/5580372/testing-for-an-xml-attribute
            connectionStringNodes = doc.DocumentElement.SelectNodes("//connectionString");
            connectionStringNodes = doc.DocumentElement.SelectNodes("//connectionString[not(@value)]");
            //connectionStringNodes = doc.DocumentElement.SelectNodes("//connectionString[@value[not string()]]"); // XPathException "'//connectionString[@value[not string()]]' has an invalid token."
            connectionStringNodes = doc.DocumentElement.SelectNodes("//connectionString[string(@value)]");

            if (connectionStringNodes != null && connectionStringNodes.Count > 0)
            {
                XmlNode connectionStringNode = connectionStringNodes[0];
                XmlAttribute valueAttribute = connectionStringNode != null && connectionStringNode.Attributes != null ? connectionStringNode.Attributes["value"] : null;

                if (valueAttribute != null && !string.IsNullOrWhiteSpace(valueAttribute.Value))
                {
                    Regex regex = new Regex("(?<=password\\s*=\\s*)[^;]*", RegexOptions.IgnoreCase);
                    Match match = regex.Match(valueAttribute.Value);

                    if (match.Success)
                    {
                        valueAttribute.Value = regex.Replace(valueAttribute.Value, "blah-blah-blah");
                        doc.Save(fileName);
                    }
                }

                connectionStringNode = doc.DocumentElement.SelectSingleNode("//connectionString[string(@value)]");
            }

            var pathToConfigurationFiles = doc.DocumentElement.SelectNodes("//pathToConfigurationFiles");

            // https://stackoverflow.com/questions/2407781/get-nth-child-of-a-node-using-xpath/2407881 -> http://saxon.sourceforge.net/saxon6.5.3/expressions.html
            var pathToConfigurationFile = doc.DocumentElement.SelectSingleNode("//pathToConfigurationFiles[position()=3]");
            pathToConfigurationFile = doc.DocumentElement.SelectSingleNode("//pathToConfigurationFiles[4]");
        }
    }
}
