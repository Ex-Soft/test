using System;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TestiTextSharpII
{
	public class MyHeaderFooter : PdfPageEventHelper
	{
		string
			CurrentDirectory;

		public override void OnOpenDocument(PdfWriter writer, Document document)
		{
			try
			{
				CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
				CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));
			}
			catch (DocumentException de)
			{
			}
			catch (System.IO.IOException ioe)
			{
			}
		}

		public override void OnStartPage(PdfWriter writer, Document document)
		{
			// http://kuujinbo.info/cs/itext_img_hdr.aspx

			base.OnStartPage(writer, document);

			PdfPTable
				Table = new PdfPTable(1);

			Table.TotalWidth = document.PageSize.Width;

			PdfPCell
				Cell = new PdfPCell(Image.GetInstance(CurrentDirectory + "top.jpg"), true);

			Cell.Border = Rectangle.NO_BORDER;
			Cell.VerticalAlignment = Element.ALIGN_TOP;
			Cell.HorizontalAlignment = Element.ALIGN_CENTER;
			//Cell.PaddingTop = 10f;
			Table.AddCell(Cell);
			
			Table.WriteSelectedRows(0, -1, 0, document.PageSize.Height - document.TopMargin + Table.TotalHeight, writer.DirectContent);
		}

		public override void OnEndPage(PdfWriter writer, Document document)
		{
			//http://www.developerbarn.com/blogs/richyrich/32-using-itextsharp-generate-pdf-header-footer.html

			base.OnEndPage(writer, document);

			PdfPTable
				Table = new PdfPTable(1);

			Table.TotalWidth = document.PageSize.Width;

			PdfPCell
				Cell = new PdfPCell(Image.GetInstance(CurrentDirectory + "bottom.jpg"), true);
				//Cell = new PdfPCell(Image.GetInstance(CurrentDirectory + "top.jpg"), true);

			Cell.Border = Rectangle.NO_BORDER;
			Cell.VerticalAlignment = Element.ALIGN_TOP;
			Cell.HorizontalAlignment = Element.ALIGN_CENTER;
			Table.AddCell(Cell);

			Table.WriteSelectedRows(0, -1, 0, document.BottomMargin + Table.TotalHeight, writer.DirectContent);
		}
	}
}
