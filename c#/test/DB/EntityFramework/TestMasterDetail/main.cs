//#define WITH_SERIALIZE
//#define WITH_DESERIALIZE

using System.IO;
using System.Text;
using System.Xml.Serialization;
using TestMasterDetail.Models;

namespace TestMasterDetail
{
    class Program
    {
        static void Main(string[] args)
        {
            #if WITH_SERIALIZE || WITH_DESERIALIZE
                var currentDirectory = Directory.GetCurrentDirectory();
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));
                var fileName = Path.Combine(currentDirectory, "data.xml");
                var xmlSerializer = new XmlSerializer(typeof(Master));
            #endif

            Master data = null;

            #if WITH_SERIALIZE
                if(File.Exists(fileName))
                    File.Delete(fileName);

                data = new Master { Val = "Master Val" };
                data.Details.AddRange(new[] { new Detail { Val = "Detail Val# 1" }, new Detail { Val = "Detail Val# 2" }, new Detail { Val = "Detail Val# 3" } });

                var streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);

                xmlSerializer.Serialize(streamWriter, data);
                streamWriter.Close();
            #endif

            using (var db = new TestDbContext())
            {
                #if WITH_DESERIALIZE
                    if (File.Exists(fileName))
                    {
                        var streamReader = new StreamReader(fileName, Encoding.UTF8);

                        data = (Master)xmlSerializer.Deserialize(streamReader);
                        streamReader.Close();
                    }
                #endif

                if (data == null)
                {
                    data = new Master { Val = "Master Val" };
                    data.Details.AddRange(new[] { new Detail { Val = "Detail Val# 1" }, new Detail { Val = "Detail Val# 2" }, new Detail { Val = "Detail Val# 3" } });
                }

                db.Masters.Add(data);
                var count = db.SaveChanges();
            }
        }
    }
}
