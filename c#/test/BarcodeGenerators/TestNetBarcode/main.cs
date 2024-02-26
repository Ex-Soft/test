// https://github.com/Tagliatti/NetBarcode

using NetBarcode;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

var bc = new Barcode(barcode, NetBarcode.Type.EAN13, true);
bc.SaveImageFile(outputFileName);
