//#define TEST_SERIALIZE
#define TEST_DESERIALIZE

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestSerializationII
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));
            var fileName = Path.Combine(currentDirectory, "Test.xml");
            var xmlSerializer = new XmlSerializer(typeof(Container));
            Container data;

            try
            {
                #if TEST_SERIALIZE
                    if (File.Exists(fileName))
                        File.Delete(fileName);

                    data = new Container();
                    data.ContainerField = 1;
                    data.SmthObjects = new List<SmthObject>(new[] { new SmthObject(), new SmthObject(), new SmthObject() });

                    var streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);

                    xmlSerializer.Serialize(streamWriter, data);
                    streamWriter.Close();
                #endif

                #if TEST_DESERIALIZE
                    if (File.Exists(fileName))
                    {
                        var streamReader = new StreamReader(fileName, Encoding.UTF8);

                        data = (Container)xmlSerializer.Deserialize(streamReader);
                        streamReader.Close();
                    }
                #endif
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
