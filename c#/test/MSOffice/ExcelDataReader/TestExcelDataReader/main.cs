// https://github.com/ExcelDataReader/ExcelDataReader

using System.Data;
using System.Text;
using ExcelDataReader;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

string currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.IndexOf("bin") != -1)
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

string fileName = Path.Combine(currentDirectory, "LibreOfficeTestColumnTypes.xlsx");

if (!File.Exists(fileName))
    return;

DataSet dataSet;
Stream stream = null;
IExcelDataReader excelDataReader = null;

try
{
    stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

    excelDataReader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration
    {
        FallbackEncoding = Encoding.GetEncoding(1252)
    });

    //excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    //excelDataReader = ExcelReaderFactory.CreateBinaryReader(stream);

    dataSet = excelDataReader.AsDataSet(new ExcelDataSetConfiguration
    {
        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
        {
            UseHeaderRow = true
        }
    });
}
catch (Exception eException)
{
    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
    return;
}
finally
{
    stream?.Dispose();
    excelDataReader?.Dispose();
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
