// https://github.com/micjahn/ZXing.Net
// https://www.luisllamas.es/en/csharp-zxing/
// https://www.codeproject.com/Articles/5357944/Create-Your-Own-QR-Codes-with-ZXing-NET
// PlatformNotSupportedException

using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Windows.Compatibility;

using static System.Console;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

var barcodeWriter = new BarcodeWriter();
barcodeWriter.Format = BarcodeFormat.EAN_13;
var myBarcode = barcodeWriter.Write(barcode);
myBarcode.Save(outputFileName, ImageFormat.Jpeg);

var bitmap = new Bitmap(outputFileName);
var reader = new BarcodeReader();
var resultFromFile = reader.Decode(bitmap);
WriteLine(resultFromFile);

outputFileName = Path.Combine(currentDirectory, "barcodeResized.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

barcodeWriter.Options.Width = 400; 
barcodeWriter.Options.Height = 100;
myBarcode = barcodeWriter.Write(barcode);
myBarcode.Save(outputFileName, ImageFormat.Jpeg);

bitmap = new Bitmap(outputFileName);
resultFromFile = reader.Decode(bitmap);
WriteLine(resultFromFile);
