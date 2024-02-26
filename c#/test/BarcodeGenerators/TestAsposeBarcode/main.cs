// https://docs.aspose.com/barcode/net/
// https://docs.aspose.com/barcode/#asposebarcode-for-net

using Aspose.BarCode.BarCodeRecognition;
using Aspose.BarCode.Generation;

using static System.Console;

const string barcode = "9785932861219";

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

var outputFileName = Path.Combine(currentDirectory, "barcode.jpg");

if (File.Exists(outputFileName))
    File.Delete(outputFileName);

using (var generator = new BarcodeGenerator(EncodeTypes.EAN13, barcode))
{
    generator.Parameters.Barcode.XDimension.Millimeters *= 2;
    generator.Parameters.Barcode.CodeTextParameters.Location = CodeLocation.Below;

    generator.Save(outputFileName, BarCodeImageFormat.Jpeg);
}

using (var reader = new BarCodeReader(outputFileName, DecodeType.AllSupportedTypes))
{
    foreach (var _barcode in reader.ReadBarCodes())
    {
        WriteLine($"{_barcode.CodeTypeName}: {_barcode.CodeText}");
    }
}
