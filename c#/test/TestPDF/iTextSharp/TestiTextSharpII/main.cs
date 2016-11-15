using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TestiTextSharpII
{
	class Program
	{
		static void Main(string[] args)
		{
			string
				CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

			CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));

			string
				OutputFileName = CurrentDirectory + "TestiTextSharp.pdf",
				ImageName = CurrentDirectory + "TestImage.jpg";

			Document
				doc = new Document(PageSize.A4.Rotate());

			PdfWriter
				writer = PdfWriter.GetInstance(doc, new FileStream(OutputFileName, FileMode.Create));

			MyHeaderFooter
				PageEventHandler = new MyHeaderFooter();

			writer.PageEvent = PageEventHandler;

			doc.Open();

			PdfPTable
				table = new PdfPTable(3);

			PdfPCell
				cell;

			cell = new PdfPCell();
			cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
			cell.BorderWidthBottom = 10f;
			cell.BorderWidthRight = 5f;
			cell.Phrase = new Phrase("blah-blah-blah", new Font(Font.FontFamily.HELVETICA, 18f, Font.BOLD | Font.ITALIC | Font.UNDERLINE, BaseColor.WHITE));
			cell.Padding = 15f;
			cell.BackgroundColor = BaseColor.BLUE;
			table.AddCell(cell);

			Image
				image = Image.GetInstance(CurrentDirectory + "pdf.gif");

			cell = new PdfPCell();
			cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
			//cell.Phrase = new Phrase("blah-blah-blah");
			cell.Padding = 15f;
			cell.Image = image;
			//cell.AddElement(image);
			//cell.Phrase = new Phrase("blah-blah-blah");
			table.AddCell(cell);
			
			//cell = new PdfPCell(image, true);
			cell = new PdfPCell(image, false);
			cell.Border = Rectangle.BOTTOM_BORDER;
			table.AddCell(cell);

			doc.Add(table);

			doc.NewPage();

			doc.Add(new Paragraph("blah-blah-blah"));

			doc.Close();
		}
	}
}
