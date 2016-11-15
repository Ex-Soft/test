#define TEST_HEADER_FOOTER
//#define TEST_TABLE_WITH_STYLES
//#define COMMON_TEST
//#define TEST_MERGE_CELLS

using System;
using System.Xml;
using AODL.Document.TextDocuments;
using AODL.Document.Content;
using AODL.Document.Content.Text;
using AODL.Document.Content.Tables;
using AODL.Document.Content.Draw;
using AODL.Document.Styles;
using AODL.Document.Styles.Properties;
using AODL.Document.Styles.MasterStyles;

namespace TestAODL
{
	class Program
	{
		static void Main(string[] args)
		{
			TextDocument
				tmpTextDocument = new TextDocument();

			tmpTextDocument.New();

			Paragraph
				tmpParagraph;

			Table
				tmpTable;

			Row
				tmpRow;

			Cell
				tmpCell;

			int
				CellsCount = 6;

			Frame
				tmpFrame;

			string
					ImgFileName;

			#if TEST_HEADER_FOOTER
				TextMasterPage
					tmpMasterPage;

				if ((tmpMasterPage = tmpTextDocument.TextMasterPageCollection.GetDefaultMasterPage()) != null)
				{
					tmpParagraph = new Paragraph(tmpTextDocument);
					tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Paragraph"));
					tmpTextDocument.Content.Add(tmpParagraph);

					tmpMasterPage.ActivatePageHeaderAndFooter();

					tmpParagraph = new Paragraph(tmpTextDocument);
					ImgFileName = "top.jpg";
					tmpFrame = new Frame(tmpTextDocument, "frame1", "graphic1", ImgFileName);
					tmpParagraph.Content.Add(tmpFrame);
					tmpMasterPage.TextPageHeader.ContentCollection.Add(tmpParagraph);

					tmpParagraph = new Paragraph(tmpTextDocument);
					ImgFileName = "bottom.jpg";
					tmpFrame = new Frame(tmpTextDocument, "frame2", "graphic2", ImgFileName);
					tmpParagraph.Content.Add(tmpFrame);
					tmpMasterPage.TextPageFooter.ContentCollection.Add(tmpParagraph);
				}
			#endif

			#if TEST_TABLE_WITH_STYLES
				tmpTable = TableBuilder.CreateTextDocumentTable(tmpTextDocument, "Table1", "table", 1, CellsCount, 12, false, true);

				ColumnStyle
					tmpColumnStyle;

				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co00")) != null)
					tmpColumnStyle.ColumnProperties.Width = "1cm";
				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co01")) != null)
					tmpColumnStyle.ColumnProperties.Width = "2cm";
				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co02")) != null)
					tmpColumnStyle.ColumnProperties.Width = "3cm";
				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co03")) != null)
					tmpColumnStyle.ColumnProperties.Width = "3cm";
				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co04")) != null)
					tmpColumnStyle.ColumnProperties.Width = "2cm";
				if ((tmpColumnStyle = (ColumnStyle)tmpTextDocument.Styles.GetStyleByName("co05")) != null)
					tmpColumnStyle.ColumnProperties.Width = "1cm";

				ParagraphStyle
					tmpParagraphStyle = new ParagraphStyle(tmpTextDocument, "ParagraphWAlignCenterFontWeightBoldFontColorRedFontSize18ItalicUnderlineDotted");

				tmpParagraphStyle.ParagraphProperties.Alignment = TextAlignments.center.ToString();
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.FontName = FontFamilies.Arial;
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.FontColor = AODL.Document.Helper.Colors.GetColor(System.Drawing.Color.Red);
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.Bold = "bold";
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.FontSize = "18pt";
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.Italic = "italic";
				tmpParagraphStyle.ParagraphProperties.Paragraphstyle.TextProperties.Underline = "dotted";
				tmpTextDocument.Styles.Add(tmpParagraphStyle);
				
				CellStyle
					tmpCellStyle = new CellStyle(tmpTextDocument, "Cell_WO_Border");

				tmpCellStyle.CellProperties.Border = "none";
				tmpTextDocument.Styles.Add(tmpCellStyle);

				tmpCellStyle = new CellStyle(tmpTextDocument, "Cell_WTR_Border");
				tmpCellStyle.CellProperties.BorderTop = "2cm solid #00ff00";
				tmpCellStyle.CellProperties.BorderRight = "2cm solid #00ff00";
				tmpCellStyle.CellProperties.Padding = "1.5cm";
				tmpTextDocument.Styles.Add(tmpCellStyle);

				tmpRow = new Row(tmpTable, "");

				tmpCell = new Cell(tmpTextDocument, "CellWOBorder");
				tmpCell.ColumnRepeating = "2";
				tmpCell.CellStyle.CellProperties.Border = "none";
				tmpRow.Cells.Add(tmpCell);

				tmpParagraph = new Paragraph(tmpTextDocument, "ParagraphWAlignCenterFontWeightBoldFontColorRedFontSize18ItalicUnderlineDotted");
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Hello"));
				tmpCell.Content.Add(tmpParagraph);

				tmpCell = new Cell(tmpTextDocument, "CellWTRBorder");
				tmpCell.ColumnRepeating = "2";
				tmpCell.CellStyle.CellProperties.BorderTop = "2cm solid #00ff00";
				tmpCell.CellStyle.CellProperties.BorderRight = "2cm solid #00ff00";
				tmpRow.Cells.Add(tmpCell);

				tmpCell = new Cell(tmpTextDocument, "CellWTRBorder");
				tmpCell.ColumnRepeating = "2";
				tmpRow.Cells.Add(tmpCell);

				tmpTable.Rows.Add(tmpRow);

				tmpRow = new Row(tmpTable, "");

				tmpCell = new Cell(tmpTextDocument, "Cell_WO_Border");
				tmpCell.ColumnRepeating = "2";
				tmpRow.Cells.Add(tmpCell);

				tmpCell = new Cell(tmpTextDocument, "Cell_WTR_Border");
				tmpCell.ColumnRepeating = "2";
				tmpRow.Cells.Add(tmpCell);

				tmpCell = new Cell(tmpTextDocument, "Cell_WTR_Border");
				tmpCell.ColumnRepeating = "2";
				tmpRow.Cells.Add(tmpCell);

				tmpTable.Rows.Add(tmpRow);
				tmpTextDocument.Content.Add(tmpTable);
			#endif

			#if TEST_MERGE_CELLS
				int
					tmpInt;

				tmpTable = TableBuilder.CreateTextDocumentTable(tmpTextDocument, "Table1", "table", 1, CellsCount, 16.99, false, true);
				tmpInt = tmpTable.Rows[0].Cells.Count;
				//tmpTable.Rows[0].MergeCells(tmpTextDocument, 0, 6, true);
				//tmpTable.Rows[0].MergeCells(tmpTextDocument, 0, 2, true);
				//tmpTable.Rows[0].MergeCells(tmpTextDocument, 1, 2, true);

				tmpRow = new Row(tmpTable);

				tmpInt = tmpRow.Cells.Count;

				for (int i = 0; i < CellsCount; ++i)
					tmpRow.Cells.Add(new Cell(tmpTextDocument));

				tmpInt = tmpRow.Cells.Count;

				tmpTable.Rows.Add(tmpRow);

				tmpInt = tmpTable.Rows[1].Cells.Count;
				tmpTable.Rows[1].MergeCells(tmpTextDocument, 0, 2, false);
				tmpInt = tmpTable.Rows[1].Cells.Count;

				tmpTable.Rows[1].MergeCells(tmpTextDocument, 1, 2, false);
				tmpInt = tmpTable.Rows[1].Cells.Count;

				tmpTable.Rows[1].MergeCells(tmpTextDocument, 2, 2, false);
				tmpInt = tmpTable.Rows[1].Cells.Count;
				tmpTextDocument.Content.Add(tmpTable);
			#endif

			#if COMMON_TEST
				tmpParagraph = new Paragraph(tmpTextDocument, "P1");
				tmpParagraph.ParagraphStyle.ParagraphProperties.Alignment = TextAlignments.right.ToString();
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Hello"));
				tmpTextDocument.Content.Add(tmpParagraph);
				tmpTextDocument.Content.Add(new Paragraph(tmpTextDocument, ParentStyles.Standard.ToString()));

				tmpParagraph = new Paragraph(tmpTextDocument, "P2");
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Hello again"));
				tmpTextDocument.Content.Add(tmpParagraph);

				string
					ImgFileName = "xpfirewall.bmp";

				Frame
					tmpFrame = new Frame(tmpTextDocument, "frame1", "graphic1", ImgFileName);

				tmpParagraph.Content.Add(tmpFrame);

				tmpTable = TableBuilder.CreateTextDocumentTable(tmpTextDocument,"Table1","table",5,5,16.99,true,true);

				tmpParagraph = ParagraphBuilder.CreateStandardTextParagraph(tmpTextDocument);
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "F1"));
				tmpTable.RowHeader.RowCollection[0].Cells[0].Content.Add(tmpParagraph);

				tmpParagraph = new Paragraph(tmpTextDocument,"ParagraphWithAlignRight");
				tmpParagraph.ParagraphStyle.ParagraphProperties.Alignment = TextAlignments.right.ToString();
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Some cell text"));
				tmpTable.Rows[0].Cells[0].Content.Add(tmpParagraph);
				
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BackgroundColor = "#e6e8fa"; // Silver
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BackgroundColor = "#8c7853"; // Bronze
				tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BackgroundColor = "#c0c0c0"; // Grey
				
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.Border = null;
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm long-dash #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm dot-dash #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm dot-dot-dash #00ff00";
				tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm none #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm solid #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm dotted #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm dash #00ff00";
				//tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderLeft = "1cm wave #00ff00";
				tmpTable.Rows[0].Cells[0].CellStyle.CellProperties.BorderTop = "1cm solid #00ff00";

				ImgFileName = "TestImage.jpg";
				tmpFrame = new Frame(tmpTextDocument, "frame2", "graphic2", ImgFileName);
				tmpFrame.SvgHeight = "2.381cm";
				tmpFrame.SvgWidth = "3.205cm";
				tmpFrame.ZIndex = "1";
				tmpParagraph = ParagraphBuilder.CreateStandardTextParagraph(tmpTextDocument);
				tmpParagraph.Content.Add(tmpFrame);
				tmpTable.Rows[0].Cells[1].Content.Add(tmpParagraph);

				ParagraphStyle
					tmpParagraphStyle = new ParagraphStyle(tmpTextDocument,"ParagraphWithAlignCenter");

				tmpParagraphStyle.ParagraphProperties.Alignment = TextAlignments.center.ToString();

				tmpParagraph = new Paragraph(tmpTextDocument, "ParagraphWithAlignCenter");
				tmpParagraph.TextContent.Add(new SimpleText(tmpTextDocument, "Some cell text"));
				tmpTable.Rows[0].Cells[2].Content.Add(tmpParagraph);

				tmpTable.Rows[1].MergeCells(tmpTextDocument, 1, 2, true); 

				tmpTextDocument.Content.Add(tmpTable);
			#endif

			tmpTextDocument.SaveTo("TestOdt.odt");
		}
	}
}
