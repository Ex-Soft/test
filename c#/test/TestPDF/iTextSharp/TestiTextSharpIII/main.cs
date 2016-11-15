using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace TestiTextSharpIII
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                CurrentDirectory = Directory.GetCurrentDirectory();

            CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));

            string
                PdfFileName = CurrentDirectory + "TestPdf.pdf";

            if(File.Exists(PdfFileName))
                File.Delete(PdfFileName);

            Document
                pdfDocument = new Document();

            PdfWriter
                writer = PdfWriter.GetInstance(pdfDocument, new FileStream(PdfFileName, FileMode.Create));

            pdfDocument.Open();

            pdfDocument.AddTitle("Title");
            pdfDocument.AddAuthor("Author");
            pdfDocument.AddSubject("Subject");
            pdfDocument.AddCreator("Creator");

            string
                tmpString="tmpString";

            pdfDocument.Add(new Paragraph(tmpString));

            pdfDocument.Close();

            PdfReader
                reader=new PdfReader(PdfFileName);

            string
                PdfFileNameOut = CurrentDirectory + "TestPdfOut.pdf";

            if (File.Exists(PdfFileNameOut))
                File.Delete(PdfFileNameOut);

            PdfStamper
                stamper = new PdfStamper(reader, new FileStream(PdfFileNameOut, FileMode.Create));

            AcroFields
                fields = stamper.AcroFields;

            bool
                result;

            result = fields.SetField("name", "name", "name");
            result = fields.SetField("address", "address", "address");
            result = fields.SetField("postal_code", "postal_code", "postal_code");
            result = fields.SetField("email", "email", "email");

            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();

            reader = new PdfReader(PdfFileNameOut);
            fields = reader.AcroFields;

            List<string>
                allNames = fields.GetSignatureNames(),
                blankNames = fields.GetBlankSignatureNames();

            reader.Close();
        }
    }
}
