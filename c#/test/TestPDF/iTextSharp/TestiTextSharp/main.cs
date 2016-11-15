#define TEST_COLUMN_TEXT
//#define TEST_TABLE_WITH_ABSOLUTE_WIDTH_OF_CELL
//#define TEST_DIRECT_TEXT_IN_CELL
//#define TEST_NESTED_TABLES
//#define TEST_LEADING
//#define TEST_DIRECT_CONTENT
//#define TEST_ATTACHMENTS

//http://kuujinbo.info/cs/itext.aspx

using System;
using System.IO;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TestiTextSharp
{
	class Program
	{
		static void Main(string[] args)
		{
		    int
		        MaxCell;

			string
				CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

			CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));

			string
				OutputFileName = CurrentDirectory + "wdpt.pdf",
				ImageName = CurrentDirectory + "TestImage.jpg";

		    Document
                pdfDocument = new Document(PageSize.A4);

			PdfWriter
				writer=PdfWriter.GetInstance(pdfDocument, new FileStream(OutputFileName, FileMode.Create));

			pdfDocument.Open();

			Phrase
				phrase = new Phrase(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " GMT", new Font(Font.FontFamily.COURIER, 8));

			Rectangle
				page = pdfDocument.PageSize;

			PdfPTable
				head = new PdfPTable(1);

			head.TotalWidth = page.Width;

			PdfPCell
				cell = new PdfPCell(phrase);

			cell.Border = Rectangle.NO_BORDER;
			cell.VerticalAlignment = Element.ALIGN_TOP;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;
			head.AddCell(cell);
			head.WriteSelectedRows(
				// first/last row; -1 writes all rows
			  0, -1,
				// left offset
			  0,
				// ** bottom** yPos of the table
			  page.Height - pdfDocument.TopMargin + head.TotalHeight + 20,
			  writer.DirectContent
			);

			pdfDocument.Add(new Paragraph("Here is a test of creating a PDF"));

            Paragraph
                p = new Paragraph();

		    Font
		        font = FontFactory.GetFont("Times New Roman", 16, Font.NORMAL);

		    p.Font = font;
            p.Add("Times New Roman");
            pdfDocument.Add(p);

		    Chunk
		        c = new Chunk("Times New Roman", FontFactory.GetFont("Times New Roman", 16));

		    c.SetCharacterSpacing(10);
            p=new Paragraph(c);
            pdfDocument.Add(p);

			BaseFont
				bfComic=BaseFont.CreateFont("c:\\windows\\fonts\\comic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

			font = new Font(bfComic, 12);
			pdfDocument.Add(new Paragraph("Some cyrillic characters: \u0418\u044f", font));

		    c = new Chunk("Some text in Verdana \n", FontFactory.GetFont("Verdana", 12));

            Chunk
				c2 = new Chunk("More text in Tahoma", FontFactory.GetFont("Tahoma", 14));

            p = new Paragraph();
			p.Add(c);
			p.Add(c2);
			pdfDocument.Add(p);

			Image
				image = Image.GetInstance(ImageName);

			c = new Chunk("Check out this wicked graphic: \n", FontFactory.GetFont("Verdana", 12));
			p = new Paragraph();
			p.Add(c);
			p.Add(image);
			pdfDocument.Add(p);

			PdfPTable
				table = new PdfPTable(3);

			cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
			cell.Colspan = 3;
			cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
			table.AddCell(cell);
			table.AddCell("Col 1 Row 1");
			table.AddCell("Col 2 Row 1");
			table.AddCell("Col 3 Row 1");
			table.AddCell("Col 1 Row 2");
			table.AddCell("Col 2 Row 2");
			table.AddCell("Col 3 Row 2");
			pdfDocument.Add(table);

			table = new PdfPTable(2);
			//actual width of table in points
			table.TotalWidth = 216f;
			//fix the absolute width of the table
			table.LockedWidth = true;

			//relative col widths in proportions - 1/3 and 2/3
			float[] widths = new float[] { 1f, 2f };
			table.SetWidths(widths);
			table.HorizontalAlignment = 0;
			//leave a gap before and after the table
			table.SpacingBefore = 20f;
			table.SpacingAfter = 30f;

			cell = new PdfPCell(new Phrase("Products"));
			cell.Colspan = 2;
			cell.Border = 0;
			cell.HorizontalAlignment = 1;
			table.AddCell(cell);

			string
				//connect = "Server=NOZHENKO-PC\\SQLEXPRESS;database=testdb;Integrated Security=SSPI";
                connect = "Server=nozhenko-s8k;Database=testdb;Trusted_Connection=True;";

			using (SqlConnection conn = new SqlConnection(connect))
			{
				string
					query = "SELECT ID, Name FROM Staff";

				SqlCommand
					cmd = new SqlCommand(query, conn);

				try
				{
					conn.Open();
					using (SqlDataReader rdr = cmd.ExecuteReader())
					{
						BaseFont
							baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

						font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

						while (rdr.Read())
						{
							table.AddCell(rdr[0].ToString());
							table.AddCell(new Paragraph(rdr[1].ToString(),font));
						}
					}
				}
				catch (Exception eException)
				{
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}

				pdfDocument.Add(table);
			}

			table = new PdfPTable(3);

			cell = new PdfPCell();
			cell.Phrase = new Phrase("Cell 1");
			cell.Image = Image.GetInstance(CurrentDirectory + "pdf.gif");
			table.AddCell(cell);

			cell = new PdfPCell(new Phrase("Cell 2", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.YELLOW)));
			cell.BackgroundColor = new BaseColor(0, 150, 0);
			cell.BorderColor = new BaseColor(255, 242, 0);
			cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER;
			cell.BorderWidthBottom = 3f;
			cell.BorderWidthTop = 3f;
			cell.PaddingBottom = 10f;
			cell.PaddingLeft = 20f;
			cell.PaddingTop = 4f;
			table.AddCell(cell);
			table.AddCell("Cell 3");
			pdfDocument.Add(table);

			table = new PdfPTable(4);
			table.TotalWidth = 400f;
			table.LockedWidth = true;

			PdfPCell
				header = new PdfPCell(new Phrase("Header"));

			header.Colspan = 4;
			table.AddCell(header);
			table.AddCell("Cell 1");
			table.AddCell("Cell 2");
			table.AddCell("Cell 3");
			table.AddCell("Cell 4");

			PdfPTable
				nested = new PdfPTable(1);

			nested.AddCell("Nested Row 1");
			nested.AddCell("Nested Row 2");
			nested.AddCell("Nested Row 3");

			PdfPCell
				nesthousing = new PdfPCell(nested);

			nesthousing.Padding = 0f;
			table.AddCell(nesthousing);

			PdfPCell
				bottom = new PdfPCell(new Phrase("bottom"));

			bottom.Colspan = 3;
			table.AddCell(bottom);
			pdfDocument.Add(table);

			table = new PdfPTable(3);
			table.TotalWidth = 144f;
			table.LockedWidth = true;
			table.HorizontalAlignment = 0;

			PdfPCell
				left = new PdfPCell(new Paragraph("Rotated"));

			left.Rotation = 90;
			table.AddCell(left);

			PdfPCell
				middle = new PdfPCell(new Paragraph("Rotated"));

			middle.Rotation = -90;
			table.AddCell(middle);
			table.AddCell("Not Rotated");
			pdfDocument.Add(table);

			string
				text = "This is a paragraph. It is represted" +
" by a Paragraph object in the iTextSharp " +
"library. Here, we're creating paragraphs with " +
"various styles in order to test out iTextSharp." +
" This paragraph will take up multiple lines " +
"and allow for a more complete example.";

			// Add a basic paragraph
			pdfDocument.Add(new Paragraph(text));


			// Add a paragraph that's underlined and indented
			Paragraph
				p2 = new Paragraph(text);

			p2.IndentationLeft = 36;
			p2.Font.SetStyle(Font.UNDERLINE);
			pdfDocument.Add(p2);

			// Add a paragraph that's underlined and in bold
			pdfDocument.Add(new Paragraph(text, FontFactory.GetFont("Courier", Font.DEFAULTSIZE, Font.UNDERLINE | Font.BOLD)));

			// Add a really big paragraph
			pdfDocument.Add(new Paragraph(text, new Font(Font.FontFamily.HELVETICA, 36)));

			// Add a green, centered paragraph
			Paragraph
				p5 = new Paragraph(text, new Font(Font.FontFamily.TIMES_ROMAN, Font.DEFAULTSIZE, Font.NORMAL, BaseColor.GREEN));

			p5.Alignment = Element.ALIGN_CENTER;
			pdfDocument.Add(p5);

			// Add a double-spaced paragraph with
			// an indented first line
			Paragraph
				p6 = new Paragraph(text);

			p6.FirstLineIndent = 36;
			p6.MultipliedLeading = 2;
			pdfDocument.Add(p6);

			// Add a paragraph with multiple styles
			// Each word gets bigger
			Paragraph
				ascending = new Paragraph();

			ascending.SpacingBefore = 72;
			for (int i = 1; i <= 5; i++)
			{
				ascending.Add(new Chunk("Hello", new Font(Font.FontFamily.HELVETICA, i * 5)));
			}
			pdfDocument.Add(ascending);

			Paragraph
				hello = new Paragraph("Hello. This is a paragraph.");

			hello.Font.SetStyle(Font.ITALIC);
			pdfDocument.Add(hello);

			Paragraph
				fancy = new Paragraph();

			Chunk
				bold = new Chunk("This ");

			bold.Font.SetStyle(Font.BOLD);
			fancy.Add(bold);

			Chunk
				italics = new Chunk("is a");

			italics.Font.SetStyle(Font.ITALIC);
			fancy.Add(italics);

			Chunk
				big = new Chunk("fancy");

			big.Font.Size = 20;
			big.Font.SetStyle(Font.BOLD);
			fancy.Add(big);

			Chunk
				struck = new Chunk("paragraph.");

			struck.Font.SetStyle(Font.STRIKETHRU);
			fancy.Add(struck);
			pdfDocument.Add(fancy);

			Paragraph
				spaced = new Paragraph("This has a lot of space around it.");

			spaced.SpacingBefore = 72;
			spaced.SpacingAfter = 72;
			spaced.IndentationLeft = 72;
			spaced.IndentationRight = 72;
			pdfDocument.Add(spaced);

			p = new Paragraph("p.FirstLineIndent = 36");
			p.FirstLineIndent = 36;
			pdfDocument.Add(p);

			p = new Paragraph("p.Alignment = Element.ALIGN_JUSTIFIED;");
			p.Alignment = Element.ALIGN_LEFT;
			p.Alignment = Element.ALIGN_CENTER;
			p.Alignment = Element.ALIGN_RIGHT;
			p.Alignment = Element.ALIGN_JUSTIFIED;
			pdfDocument.Add(p);

			Paragraph
				spacy = new Paragraph();

			spacy.Leading = 72;
			pdfDocument.Add(spacy);

			Paragraph
				spacy2 = new Paragraph(72);

			Paragraph
				spacy3 = new Paragraph(72, "The leading is an inch.");

			pdfDocument.Add(spacy2);
			pdfDocument.Add(spacy3);

			Paragraph
				doubleSpaced = new Paragraph("doubleSpaced.MultipliedLeading = 2");

			doubleSpaced.MultipliedLeading = 2;
			pdfDocument.Add(doubleSpaced);

			Chunk
				boo = new Chunk("Boo!");

			boo.Font.SetStyle(Font.BOLD);
			boo.Font.Size = 72;
			boo.Font.SetStyle("bold");

			Font
				small = new Font(Font.FontFamily.TIMES_ROMAN, 5);

			Chunk
				smallText = new Chunk("This is small.", small);

			Font
				redItalic = new Font(Font.FontFamily.HELVETICA, Font.DEFAULTSIZE, Font.ITALIC, BaseColor.RED);

			Chunk
				hey = new Chunk("Hey.", FontFactory.GetFont("Courier", 12, Font.ITALIC));

			table = new PdfPTable(3);
			table.AddCell(new PdfPCell(new Phrase("Cell# 1")));
			table.AddCell(new PdfPCell(new Phrase("Cell# 2")));
			table.AddCell(new PdfPCell(new Phrase("Cell# 3")));
			pdfDocument.Add(table);

            #if TEST_ATTACHMENTS
		        PdfFileSpecification
		            pdfFileSpecification = PdfFileSpecification.FileEmbedded(writer, ImageName, Path.GetFileName(ImageName), null);

                writer.AddFileAttachment("Description", pdfFileSpecification);

		        FileStream
		            fs = File.OpenRead(ImageName);

                byte[]
                    img=new byte[fs.Length];

		        fs.Read(img, 0, img.Length);
                pdfFileSpecification = PdfFileSpecification.FileEmbedded(writer, ImageName, Path.GetFileName(ImageName), img);
                writer.AddFileAttachment("DescriptionDescription", pdfFileSpecification);
            #endif

		    PdfContentByte
		        pdfContentByte;

            float
                x,
                y;

            #if TEST_DIRECT_CONTENT
		        pdfDocument.NewPage();

                pdfContentByte = writer.DirectContent;

                pdfContentByte.MoveTo(x = 400f, 0f);
                pdfContentByte.LineTo(x, page.Height);
                pdfContentByte.MoveTo(x = 300f, 0f);
                pdfContentByte.LineTo(x, page.Height);
                pdfContentByte.MoveTo(0f, y=10f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y=50f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y=90f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y = 130f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y = 170f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y = 600f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.MoveTo(0f, y = 700f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.Stroke();

                pdfContentByte.BeginText();
                pdfContentByte.SetFontAndSize(BaseFont.CreateFont(/*BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED*/), iTextSharp.text.Font.DEFAULTSIZE);
                pdfContentByte.ShowText("pdfContentByte.ShowText()");
                pdfContentByte.SetTextMatrix(x, 170f);
                pdfContentByte.ShowText("pdfContentByte.ShowText()");
		        pdfContentByte.ShowText(string.Format("Width: {0}, Height: {1}", page.Width, page.Height));
                pdfContentByte.ShowTextAlignedKerned(PdfContentByte.ALIGN_RIGHT, "pdfContentByte.ShowTextAlignedKerned(RIGHT)", x, 130f, 0f);
                pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "pdfContentByte.ShowTextAligned(RIGHT)", x, 90f, 0f);
                pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "pdfContentByte.ShowTextAligned(CENTER)", x, 50f, 0f);
                pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "pdfContentByte.ShowTextAligned(LEFT)", x, 10f, 0f);

                pdfContentByte.SetTextMatrix(0, 1, -1, 0, 300, 600);
                pdfContentByte.ShowText("Position 300,600, rotated 90 degrees.");

                for (int i = 0; i < 360; i += 30)
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rotated Text", 400f, 700f, i);

                pdfContentByte.EndText();
            #endif

            #if TEST_NESTED_TABLES
                pdfDocument.NewPage();

                table = new PdfPTable(3);
                for (int i = 0; i < 3; ++i)
                {
                    nested=new PdfPTable(1);
                    cell=new PdfPCell(new Phrase(i.ToString()));
                    cell.BorderColor = BaseColor.RED;
                    nested.AddCell(cell);
                    nesthousing=new PdfPCell(nested);
                    nesthousing.BorderColor = BaseColor.BLUE;
                    nesthousing.Padding = 10;
                    table.AddCell(nesthousing);
                }
		        pdfDocument.Add(table);
            #endif

            #if TEST_LEADING
                pdfDocument.NewPage();

                table = new PdfPTable(10);
                cell = new PdfPCell(new Paragraph("Quick brown fox jumps over the lazy dog.\nQuick brown fox jumps over the lazy dog."));
                table.AddCell("default leading / spacing");
                table.AddCell(cell);
                table.AddCell("absolute leading: 20");
                cell.SetLeading(20f, 0f);
                table.AddCell(cell);
                table.AddCell("absolute leading: 3; relative leading: 1.2");
                cell.SetLeading(3f, 1.2f);
                table.AddCell(cell);
                table.AddCell("absolute leading: 0; relative leading: 1.2");
                cell.SetLeading(0f, 1.2f);
                table.AddCell(cell);
                table.AddCell("no leading at all");
                cell.SetLeading(0f, 0f);
                table.AddCell(cell);
                pdfDocument.Add(table);
            #endif

            #if TEST_DIRECT_TEXT_IN_CELL
                pdfDocument.NewPage();

                table = new PdfPTable(MaxCell=3);
                for (int i = 0; i < MaxCell; ++i)
                {
                    cell = new PdfPCell(new Paragraph(i.ToString()));
                    table.AddCell(cell);    
                }
                pdfDocument.Add(table);
                
                pdfContentByte = writer.DirectContent;
                pdfContentByte.BeginText();
                pdfContentByte.SetFontAndSize(BaseFont.CreateFont(), iTextSharp.text.Font.DEFAULTSIZE);
                pdfContentByte.SetTextMatrix(230,792);
                pdfContentByte.ShowText(string.Format("Width: {0}, Height: {1} - blah-blah-blah", page.Width, page.Height));
                pdfContentByte.EndText();
            #endif

            #if TEST_TABLE_WITH_ABSOLUTE_WIDTH_OF_CELL
                pdfDocument.NewPage();

                widths = new float[] { (PageSize.A4.Width * 50) / 210f, (PageSize.A4.Width * 25) / 210f, (PageSize.A4.Width * 25) / 210f };
                table = new PdfPTable(MaxCell = 3);
                table.SetTotalWidth(widths);
		        table.LockedWidth = true;
                for (int i = 0; i < MaxCell; ++i)
                {
                    cell = new PdfPCell(new Paragraph(i.ToString()));
                    table.AddCell(cell);
                }
                pdfDocument.Add(table);
            #endif

		    ColumnText
		        columnText;

            #if TEST_COLUMN_TEXT
                pdfDocument.NewPage();

		        pdfContentByte = writer.DirectContent;

                pdfContentByte.MoveTo(x = 80f, 0f);
                pdfContentByte.LineTo(x, page.Height);
                pdfContentByte.MoveTo(0f, y = 80f);
                pdfContentByte.LineTo(page.Width, y);
                pdfContentByte.Stroke();

                columnText = new ColumnText(pdfContentByte);
		        phrase = new Phrase("blah-blah-blah1\nblah-blah-blah2 blah-blah-blah3 blah-blah-blah4 blah-blah-blah5");
                columnText.AddText(phrase);
                //columnText.AddElement(phrase);
                columnText.SetSimpleColumn(0,0,x,y);
		        columnText.Go();
            #endif

            pdfDocument.Close();
		}
	}
}
