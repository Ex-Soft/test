#define TEST_CONNECTION_STRING

using System;
using System.IO;
using DocumentFormat.OpenXml.Packaging;

namespace TestModify
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
                fileName = Path.Combine(currentDirectory, "SaleBuyPoints.xlsx");

            if (!File.Exists(fileName))
                return;

            SpreadsheetDocument spreadsheetDocument = null;

            try
            {
                spreadsheetDocument = SpreadsheetDocument.Open(fileName, true);

                foreach (var connection in spreadsheetDocument.WorkbookPart.ConnectionsPart.Connections)
                {
                    
                }
                
                spreadsheetDocument.Close();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            finally
            {
                if (spreadsheetDocument != null)
                    spreadsheetDocument.Dispose();
            }
        }
    }
}
