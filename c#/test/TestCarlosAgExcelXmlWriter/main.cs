//#define TEST_MERGE
#define TEST_DATE
//#define TEST_CREATE
//#define TEST_LOAD

using System;
using CarlosAg.ExcelXmlWriter;

namespace TestCarlosAgExcelXmlWriter
{
	class Program
	{
		static void Main(string[] args)
		{
			Workbook
				book = new Workbook();

			Worksheet
				sheet;

			WorksheetRow
				row;

			WorksheetCell
				cell;

			#if TEST_LOAD
				book.Load("template.xls");
				sheet = book.Worksheets[0];
				row = sheet.Table.Rows[3];
				cell = row.Cells[8];
				cell.Data.Text = "blah-blah-blah";

				int
					v;

				sheet.Table.Rows[11 - 1].Cells[(v = ColNameToNo("N")) - 2].Data.Text = "N11 (" + v + ":11)";	
				sheet.Table.Rows[18 - 1].Cells[(v = ColNameToNo("J")) - 2].Data.Text = "J18 (" + v + ":18)";
				
			#endif

			#if TEST_CREATE
				WorksheetStyle
					s31 = book.Styles.Add("s31");

				s31.Font.FontName = "Tahoma";
				s31.Font.Size = 8;
				s31.Font.Color = "#000000";
				s31.Alignment.Horizontal = StyleHorizontalAlignment.Center;
				s31.Alignment.Vertical = StyleVerticalAlignment.Center;
				s31.Alignment.WrapText = true;
				s31.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
				s31.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
				s31.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
				s31.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
				s31.NumberFormat = "@";

				sheet = book.Worksheets.Add("Sheet# 1");

				sheet.Table.Columns.Add(new WorksheetColumn(250));

				row = sheet.Table.Rows.Add();
				row.Height = 100;
				cell = row.Cells.Add();
				cell.Data.Text = "1";
				cell.Data.Type=DataType.Number;
				cell.StyleID = "s31";

				row = sheet.Table.Rows.Add();
				row.Cells.Add(new WorksheetCell("2", DataType.Number));
				row = sheet.Table.Rows.Add();
				row.Cells.Add(new WorksheetCell("3", DataType.Number));

				row = sheet.Table.Rows.Add();
				row.Cells.Add(new WorksheetCell("Group# 1", DataType.String));

				sheet.Table.ExpandedColumnCount = 1;
				sheet.Table.ExpandedRowCount = 4;
				sheet.Table.FullColumns = 1;
				sheet.Table.FullRows = 1;
			#endif

			#if TEST_DATE
				sheet = book.Worksheets.Add("Sheet# 1");

				WorksheetStyle
					dateStyle = book.Styles.Add("dateStyle");

				dateStyle.NumberFormat = "Dd Mmm Yy";

				row = sheet.Table.Rows.Add();
				row.Cells.Add(new WorksheetCell(DateTime.Now.ToString("s"), DataType.DateTime, "dateStyle"));

				row.Cells.Add();
				row.Cells[1].Data.Text = DateTime.Now.ToString("s");
				row.Cells[1].Data.Type = DataType.DateTime;
			#endif

			#if TEST_MERGE
				sheet = book.Worksheets.Add("Sheet# 1");

				row = sheet.Table.Rows.Add();
				cell = row.Cells.Add("1");

				row = sheet.Table.Rows.Add();
				row.Cells.Add("4");
				row = sheet.Table.Rows.Add();
				row.Cells.Add("4");
				row = sheet.Table.Rows.Add();
				row.Cells.Add("4");
				row = sheet.Table.Rows.Add();
				row.Cells.Add("4");

				cell.MergeAcross = 3;

				row = sheet.Table.Rows.Add();
				cell = row.Cells.Add("2");
			
				/*row = sheet.Table.Rows.Add();
				row.Cells.Add();
				row = sheet.Table.Rows.Add();
				row.Cells.Add();
				row = sheet.Table.Rows.Add();
				row.Cells.Add();
				row = sheet.Table.Rows.Add();
				row.Cells.Add();*/

				cell.MergeDown = 3;

				cell = row.Cells.Add("3");
				cell.Index = 2;

				row = sheet.Table.Rows.Add();
				cell = row.Cells.Add("3");
				cell.Index = 2;

				row = sheet.Table.Rows.Add();
				cell = row.Cells.Add("3");
				cell.Index = 2;

				row = sheet.Table.Rows.Add();
				cell = row.Cells.Add("3");
				cell.Index = 2;
			#endif

			book.Save("template_out.xls");
		}

		static int ColNameToNo(string ColName)
		{
			int
				ColNo = 0,
				Mul = 1;

			ColName = ColName.Trim().ToUpper();

			for (int i = ColName.Length - 1; i >= 0; i--)
			{
				ColNo += (ColName[i] - 'A' + 1) * Mul;
				Mul *= ('Z' - 'A' + 1);
			}

			return (ColNo);
		}
	}
}
