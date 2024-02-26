// https://github.com/barnhill/barcodelib

using BarcodeStandard;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

var bc = new Barcode();
bc.IncludeLabel = true;
_ = bc.Encode(BarcodeStandard.Type.Ean13, barcode);
bc.SaveImage(outputFileName, SaveTypes.Jpg);
