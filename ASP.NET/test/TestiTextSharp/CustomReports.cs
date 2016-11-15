using System.IO;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace TestiTextSharp
{
	public class CustomReports
	{
		public MemoryStream CreatePDF(string Title)
		{
			MemoryStream PDFData = new MemoryStream();
			Document document = new Document(PageSize.LETTER, 50, 50, 80, 50);
			PdfWriter PDFWriter = PdfWriter.GetInstance(document, PDFData);
			PDFWriter.ViewerPreferences = PdfWriter.PageModeUseOutlines;

			// Our custom Header and Footer is done using Event Handler
			TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
			PDFWriter.PageEvent = PageEventHandler;

			// Define the page header
			PageEventHandler.Title = Title;
			PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, Font.BOLD);
			PageEventHandler.HeaderLeft = "Group";
			PageEventHandler.HeaderRight = "1";

			document.Open();

			for (int i = 1; i <= 2; i++)
			{
				// Define the page header
				PageEventHandler.HeaderRight = i.ToString();

				if (i != 1)
				{
					document.NewPage();
				}

				// New outline must be created after the page is added
				AddOutline(PDFWriter, "Group " + i.ToString(), document.PageSize.Height);

				for (int j = 1; j <= 30; j++)
				{
					PdfPTable
						ItemTable = new PdfPTable(2);

					/*
					ItemTable.TableFitsPage = true;
					ItemTable.Width = 95;
					ItemTable.Offset = 0;
					ItemTable.Border = 0;
					ItemTable.DefaultCellBorder = 0;
					*/
					ItemTable.AddCell(new PdfPCell(new Phrase(string.Format("blah blah {0} - {1} ...", i, j))));
					document.Add(ItemTable);
					document.Add(new Paragraph("\r\n"));
				}
			}

			document.Close();

			return PDFData;
		}

		public void AddOutline(PdfWriter writer, string Title, float Position)
		{
			PdfDestination destination = new PdfDestination(PdfDestination.FITH, Position);
			PdfOutline outline = new PdfOutline(writer.DirectContent.RootOutline, destination, Title);
			writer.DirectContent.AddOutline(outline, "Name = " + Title);
		}
	}
}