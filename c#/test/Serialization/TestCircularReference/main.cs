#define TEST_SERIALIZE
#define TEST_DESERIALIZE

using System;
using System.IO;
using System.Runtime.Serialization;
using static System.Console;

namespace TestCircularReference
{
    class Program
    {
        static void Main(string[] args)
        {
            string
               currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
               fileName;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            fileName = Path.Combine(currentDirectory, "A.xml");

            if (File.Exists(fileName))
                File.Delete(fileName);

            A a = null;
            B b = null;
            C c = null;
            D d = null;

            var xmlSerializer = new DataContractSerializer(typeof(A));

            try
            { 

                #if TEST_SERIALIZE
                    a = new A();
                    b = new B();
                    c = new C();
                    d = new D();

                    d.Id = 1;
                    d.PInt = 13;

                    c.Id = 1;
                    c.PInt = 13;
                    c.PD = d;

                    b.Id = 1;
                    b.PC = c;
                    b.PD = d;

                    a.Id = 1;
                    a.PB = b;
                    a.PC = c;

                    var fileStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                    xmlSerializer.WriteObject(fileStream, a);
                    fileStream.Close();

                    c.PInt = 39;
                    d.PInt = 39;
                    fileName = Path.Combine(currentDirectory, "AAfter.xml");
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    fileStream = fileStream = File.Open(fileName, FileMode.OpenOrCreate);
                    xmlSerializer.WriteObject(fileStream, a);
                    fileStream.Close();

                    a.PB.PD.PInt = 129;
                    fileName = Path.Combine(currentDirectory, "AAfterAfter.xml");
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    fileStream = File.Open(fileName, FileMode.OpenOrCreate);
                    xmlSerializer.WriteObject(fileStream, a);
                    fileStream.Close();
                #endif

                #if TEST_DESERIALIZE
                    if (File.Exists(fileName))
                    {
                        fileStream = File.Open(fileName, FileMode.OpenOrCreate);

                        a = (A)xmlSerializer.ReadObject(fileStream);
                        fileStream.Close();

                        a.PB.PD.PInt = 639;
                        fileName = Path.Combine(currentDirectory, "AAfterAfterAfter.xml");
                        if (File.Exists(fileName))
                            File.Delete(fileName);
                        fileStream = File.Open(fileName, FileMode.OpenOrCreate);
                        xmlSerializer.WriteObject(fileStream, a);
                        fileStream.Close();
                    }
                #endif
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                ReadLine();
            }
        }
    }
}
