// http://msdn.microsoft.com/en-us/library/gg278309%28v=office.14%29

#define ADD_NUMBERING_FORMAT

using System;
using System.Globalization;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TestOpenXMLSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            string
               currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                outputFileName = Path.Combine(currentDirectory, "xlsx_tst.xlsx");

            if(File.Exists(outputFileName))
                File.Delete(outputFileName);

            SpreadsheetDocument
                spreadsheetDocument = SpreadsheetDocument.Create(outputFileName, SpreadsheetDocumentType.Workbook);

            WorkbookPart
                workbookpart = spreadsheetDocument.AddWorkbookPart();

            #if ADD_NUMBERING_FORMAT
                WorkbookStylesPart
                    workbookStylesPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorkbookStylesPart>();

                workbookStylesPart.Stylesheet = new Stylesheet();

                Stylesheet
                    stylesheet = spreadsheetDocument.WorkbookPart.WorkbookStylesPart.Stylesheet;

                stylesheet.Append(GenerateNumberingFormats());
                stylesheet.Append(GenerateFonts());
                stylesheet.Append(GenerateFills());
                stylesheet.Append(GenerateBorders());
                stylesheet.Append(GenerateCellStyleFormats());
                stylesheet.Append(GenerateCellFormats());
                stylesheet.Append(GenerateCellStyles());
            #endif

            workbookpart.Workbook = new Workbook();

            WorksheetPart
                worksheetPart = workbookpart.AddNewPart<WorksheetPart>();

            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets
                sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            Sheet
                sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Test" };

            sheets.Append(sheet);

            SheetData
                sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            Row
                row;

            row = new Row() { RowIndex = 1 };
            sheetData.Append(row);
 
            Cell
                cell;

            cell = new Cell() { CellReference = "A1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)1U, CellValue = new CellValue("100") };
            row.Append(cell);

            cell = new Cell() { CellReference = "B1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)2U, CellValue = new CellValue("100.1") };
            row.Append(cell);

            cell = new Cell() { CellReference = "C1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)3U, CellValue = new CellValue("100.12") };
            row.Append(cell);

            cell = new Cell() { CellReference = "D1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)4U, CellValue = new CellValue("100.1234") };
            row.Append(cell);

            cell = new Cell() { CellReference = "E1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)5U, CellValue = new CellValue("100.123456") };
            row.Append(cell);

            cell = new Cell() { CellReference = "F1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)6U, CellValue = new CellValue(DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture)) };
            row.Append(cell);

            cell = new Cell() { CellReference = "G1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)7U, CellValue = new CellValue(DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture)) };
            row.Append(cell);

            cell = new Cell() { CellReference = "H1", DataType = new EnumValue<CellValues>(CellValues.Number), StyleIndex = (UInt32Value)8U, CellValue = new CellValue(DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture)) };
            row.Append(cell);

            cell = new Cell() { CellReference = "I1", DataType = new EnumValue<CellValues>(CellValues.Boolean), StyleIndex = (UInt32Value)10U, CellValue = new CellValue("1") };
            row.Append(cell);

            cell = new Cell() { CellReference = "J1", DataType = new EnumValue<CellValues>(CellValues.Boolean), StyleIndex = (UInt32Value)10U, CellValue = new CellValue("0") };
            row.Append(cell);
            
            cell = new Cell() { CellReference = "K1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)9U, InlineString = new InlineString() { Text = new Text() { Text = "string" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "L1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)10U, InlineString = new InlineString() { Text = new Text() { Text = "string" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "M1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)11U, InlineString = new InlineString() { Text = new Text() { Text = "string" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "N1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)12U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "O1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)13U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "P1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)14U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "Q1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)15U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "R1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)16U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            cell = new Cell() { CellReference = "S1", DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = (UInt32Value)17U, InlineString = new InlineString() { Text = new Text() { Text = "Line#1 Line#2 Line#3 Line#4 Line#5" } } };
            row.Append(cell);

            workbookpart.Workbook.Save();

            spreadsheetDocument.Close();
        }

        public static NumberingFormats GenerateNumberingFormats()
        {
            NumberingFormats numberingFormats1 = new NumberingFormats() { Count = (UInt32Value)5U };
            NumberingFormat numberingFormat1 = new NumberingFormat() { NumberFormatId = (UInt32Value)164U, FormatCode = "0.0" };
            NumberingFormat numberingFormat2 = new NumberingFormat() { NumberFormatId = (UInt32Value)165U, FormatCode = "0.0000" };
            NumberingFormat numberingFormat3 = new NumberingFormat() { NumberFormatId = (UInt32Value)166U, FormatCode = "0.000000" };
            NumberingFormat numberingFormat4 = new NumberingFormat() { NumberFormatId = (UInt32Value)167U, FormatCode = "dd/mm/yyyy\\ hh:mm:ss;@" };
            NumberingFormat numberingFormat5 = new NumberingFormat() { NumberFormatId = (UInt32Value)168U, FormatCode = "h:mm:ss;@" };

            numberingFormats1.Append(numberingFormat1);
            numberingFormats1.Append(numberingFormat2);
            numberingFormats1.Append(numberingFormat3);
            numberingFormats1.Append(numberingFormat4);
            numberingFormats1.Append(numberingFormat5);

            return numberingFormats1;
        }

        public static Fonts GenerateFonts()
        {
            Fonts fonts1 = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 10D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Times New Roman" };
            //FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 1 };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = 204 };
            //FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontCharSet1);
            //font1.Append(fontScheme1);

            fonts1.Append(font1);
            return fonts1;
        }

        public static Fills GenerateFills()
        {
            Fills fills1 = new Fills() { Count = (UInt32Value)3U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            Fill fill3 = new Fill();
            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { /*Theme = (UInt32Value)0U, Tint = -0.14999847407452621D*/ Rgb = "FFDDDDDD" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { /*Indexed = (UInt32Value)64U*/ Rgb = "FFCCFFCC" };

            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);

            fill3.Append(patternFill3);

            fills1.Append(fill1);
            fills1.Append(fill2);
            fills1.Append(fill3);
            return fills1;
        }

        public static Borders GenerateBorders()
        {
            Borders borders1 = new Borders() { Count = (UInt32Value)2U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            Border border2 = new Border();
            LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };
            Color color1 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder2.Append(color1);

            RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.Thin };
            Color color2 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder2.Append(color2);

            TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Thin };
            Color color3 = new Color() { Indexed = (UInt32Value)64U };

            topBorder2.Append(color3);

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color4 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color4);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            borders1.Append(border1);
            borders1.Append(border2);
            return borders1;
        }

        public static CellStyleFormats GenerateCellStyleFormats()
        {
            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);
            return cellStyleFormats1;
        }

        public static CellFormats GenerateCellFormats()
        {
            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)18U };

            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };

            //NumericX0
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)1U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment2 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat2.Append(alignment2);

            //NumericX1
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)164U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment3 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat3.Append(alignment3);

            //NumericX2
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)2U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment4 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat4.Append(alignment4);

            //NumericX4
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)165U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment5 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat5.Append(alignment5);

            //NumericX6
            CellFormat cellFormat6 = new CellFormat() { NumberFormatId = (UInt32Value)166U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment6 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat6.Append(alignment6);

            //Date
            CellFormat cellFormat7 = new CellFormat() { NumberFormatId = (UInt32Value)14U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment7 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat7.Append(alignment7);

            //DateTime
            CellFormat cellFormat8 = new CellFormat() { NumberFormatId = (UInt32Value)167U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment8 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat8.Append(alignment8);

            //Time
            CellFormat cellFormat9 = new CellFormat() { NumberFormatId = (UInt32Value)168U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyAlignment = true };
            Alignment alignment9 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat9.Append(alignment9);

            //AlignmentLeft
            CellFormat cellFormat10 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment10 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left };
            cellFormat10.Append(alignment10);

            //AlignmentCenter
            CellFormat cellFormat11 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment11 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat11.Append(alignment11);
            
            //AlignmentRight
            CellFormat cellFormat12 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment12 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat12.Append(alignment12);

            //AlignmentLeftWrapText
            CellFormat cellFormat13 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment13 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, WrapText = true };
            cellFormat13.Append(alignment13);

            //AlignmentCenterWrapText
            CellFormat cellFormat14 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment14 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, WrapText = true };
            cellFormat14.Append(alignment14);

            //AlignmentRightWrapText
            CellFormat cellFormat15 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            Alignment alignment15 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right, WrapText = true };
            cellFormat15.Append(alignment15);

            //TextAlignmentLeftWrapTextBorderFill
            CellFormat cellFormat16 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            Alignment alignment16 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, WrapText = true };
            cellFormat16.Append(alignment16);

            //TextAlignmentCenterWrapTextBorderFill
            CellFormat cellFormat17 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            Alignment alignment17 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, WrapText = true };
            cellFormat17.Append(alignment17);

            //TextAlignmentRightWrapTextBorderFill
            CellFormat cellFormat18 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            Alignment alignment18 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right, WrapText = true };
            cellFormat18.Append(alignment18);

            cellFormats1.Append(cellFormat1);
            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);
            cellFormats1.Append(cellFormat8);
            cellFormats1.Append(cellFormat9);
            cellFormats1.Append(cellFormat10);
            cellFormats1.Append(cellFormat11);
            cellFormats1.Append(cellFormat12);
            cellFormats1.Append(cellFormat13);
            cellFormats1.Append(cellFormat14);
            cellFormats1.Append(cellFormat15);
            cellFormats1.Append(cellFormat16);
            cellFormats1.Append(cellFormat17);
            cellFormats1.Append(cellFormat18);

            return cellFormats1;
        }

        public static CellStyles GenerateCellStyles()
        {
            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Standard", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            return cellStyles1;
        }
    }
}
