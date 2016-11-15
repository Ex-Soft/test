using System;
using System.Data;
using System.IO;
using Excel;

namespace ExcelDataReader
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
                fileName = Path.Combine(currentDirectory, "test1.xls");

            if (!File.Exists(fileName))
                return;

            DataSet
                dataSet = new DataSet();

            Stream stream = null;
            IExcelDataReader excelDataReader = null;

            try
            {
                stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

                //excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                excelDataReader = ExcelReaderFactory.CreateBinaryReader(stream);

                excelDataReader.IsFirstRowAsColumnNames = true;
                dataSet = excelDataReader.AsDataSet();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                return;
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();

                if (excelDataReader != null)
                    excelDataReader.Dispose();
            }

            if (dataSet == null || dataSet.Tables.Count == 0)
                return;

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                foreach (DataColumn column in dataSet.Tables[0].Columns)
                {
                    Type columnType = column.DataType;
                    Type valueType = !row.IsNull(column.ColumnName) ? row[column.ColumnName].GetType() : DBNull.Value.GetType();

                    if (columnType != valueType)
                        Console.WriteLine("{0} != {1}", columnType, valueType);
                }
            }
        }
    }
}
