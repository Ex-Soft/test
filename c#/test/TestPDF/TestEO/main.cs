using System;
using System.IO;
using EO.Pdf;

namespace TestEO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var memoryStream = new MemoryStream();
                EO.Pdf.Runtime.AddLicense("+fIYrqy+9cEit6W73fjovHWm9/oS7Zrr+QMQvUaBwMAX6Jzc8gQQvUaBdePt9BDtrNzCnrWfWZekzRfonNzyBBDInbW6x+Owcay6wtuxdabw+g7kp+rp2g+9RoGkscufdePt9BDtrNzpz+eupeDn9hnyntzCnrWfWZekzQzrpeb7z7iJWZekscufWZfA8g/jWev9ARC8W7zTv/vjn5mkBxDxrODz/+ihaqyywc2faLWRm8ufWZfAwAzrpeb7z7iJWZeksefuq9vpA/Ttn+ak9QzznrSmwtyua6ezw9uwbZmkBCDhfu/0+h3krLj4zs2waqa2wdqxaai5s8v1nun3+hrtdpm6s8uud4SOscufWbP3+hLtmuv5AxC9ht3F0hzIqePw");
                HtmlToPdf.Options.PageSize = PdfPageSizes.A4;
                HtmlToPdf.Options.OutputArea = new System.Drawing.RectangleF(0.5f, 0.5f, 200f, 200f);

                HtmlToPdf.ConvertHtml("<strong>blah-blah-blah</strong>", memoryStream);
                memoryStream.Position = 0;
                var result = memoryStream.ToArray();

                HtmlToPdf.ClearResult();

                string fileName;

                if(File.Exists(fileName = "test.pdf"))
                    File.Delete(fileName);

                File.WriteAllBytes(fileName, result);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
