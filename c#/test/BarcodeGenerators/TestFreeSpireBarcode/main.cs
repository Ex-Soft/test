// https://www.e-iceblue.com/Tutorials/Spire.Barcode/Spire.Barcode-Program-Guide/How-to-create-Code39-barcodes-in-C.html
// https://www.nuget.org/packages/FreeSpire.Barcode

using Spire.Barcode;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

var bs = new BarcodeSettings
{
    Type = BarCodeType.EAN13,
    Data = barcode,
    ShowTopText = false,
    ShowTextOnBottom = true
};

var bg = new BarCodeGenerator(bs);
bg.GenerateImage().Save(outputFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
