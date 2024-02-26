// https://ironsoftware.com/csharp/barcode/

using IronBarCode;
using static System.Console;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

var myBarcode = BarcodeWriter.CreateBarcode(barcode, BarcodeWriterEncoding.EAN13);
myBarcode.SaveAsImage(outputFileName);
var resultFromFile = BarcodeReader.Read(outputFileName);
WriteLine(resultFromFile);

outputFileName = Path.Combine(currentDirectory, "barcodeResized.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

myBarcode.ResizeTo(400, 100);
myBarcode.SaveAsImage(outputFileName);
resultFromFile = BarcodeReader.Read(outputFileName);
WriteLine(resultFromFile);

//var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf");
