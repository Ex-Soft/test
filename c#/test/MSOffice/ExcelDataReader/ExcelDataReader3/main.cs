// https://github.com/ExcelDataReader/ExcelDataReader
// https://www.nuget.org/packages/ExcelDataReader/

using System;
using System.Data;
using System.IO;
using ExcelDataReader;

using static System.Console;

namespace ExcelDataReader3
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
                fileName = Path.Combine(currentDirectory, "LibreOfficeTestColumnTypes.xlsx");

            if (!File.Exists(fileName))
                return;

            DataSet dataSet;
            var excelDataSetConfiguration = new ExcelDataSetConfiguration()
            {
                // Gets or sets a value indicating whether to set the DataColumn.DataType 
                // property in a second pass.
                //UseColumnDataType = true,

                // Gets or sets a callback to obtain configuration options for a DataTable. 
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {

                    // Gets or sets a value indicating the prefix of generated column names.
                    //EmptyColumnNamePrefix = "Column",

                    // Gets or sets a value indicating whether to use a row from the 
                    // data as column names.
                    UseHeaderRow = true,

                    // Gets or sets a callback to determine which row is the header row. 
                    // Only called when UseHeaderRow = true.
                    //ReadHeaderRow = (rowReader) => {
                        // F.ex skip the first row and use the 2nd row as column headers:
                    //    rowReader.Read();
                    //},

                    // Gets or sets a callback to determine whether to include the 
                    // current row in the DataTable.
                    //FilterRow = (rowReader) =>
                    //{
                        //return rowReader[2].ToString() != "bad value";
                        //return true;
                    //},
                }
            };

            try
            {
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        dataSet = reader.AsDataSet(excelDataSetConfiguration);
                    }
                }
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                return;
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
                        WriteLine("{0} != {1}", columnType, valueType);
                }
            }
        }
    }
}
