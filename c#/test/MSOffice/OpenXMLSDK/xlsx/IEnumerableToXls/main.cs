using System;
using System.Collections.Generic;
using System.IO;
using IEnumerableToXls.Export;
using IEnumerableToXls.Export.Xlsx;

namespace IEnumerableToXls
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                fileName = Path.Combine(currentDirectory, "result.xlsx");

            if(File.Exists(fileName))
                File.Delete(fileName);

            var data = new List<ClassVictim>(new[]
            {
                new ClassVictim { FBool = true, FDateTimeForDate = new DateTime(2000, 11, 22), FString = "FString1", FChar = 'A' },
                new ClassVictim { FBool = false, FBoolNullable = false, FDateTimeForDateNullable = new DateTime(2000, 1, 1), FDateTimeForTime = new DateTime(2000, 11, 22, 17, 30, 0), FString = "FString2", FChar = 'Я' },
                new ClassVictim { FBool = false, FBoolNullable = true, FDateTimeForTimeNullable = new DateTime(2000, 1, 1, 13, 13, 13), FDateTimeForDateTime = DateTime.Now, FString = "FString2",  FChar = 'ї' }
            });

            var exportInfos = new Dictionary<string, ExportInfo>
            {
                { "FString", new ExportInfo("ФСтринг", 1) }
            };

            IExport exporter = new Exporter();

            MemoryStream result = null;

            try
            {
                if ((result = exporter.Export(data, exportInfos)) != null)
                    File.WriteAllBytes(fileName, result.ToArray());
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            finally
            {
                if (result != null)
                    result.Dispose();
            }
        }
    }
}
