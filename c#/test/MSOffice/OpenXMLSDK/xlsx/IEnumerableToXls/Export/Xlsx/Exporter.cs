using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace IEnumerableToXls.Export.Xlsx
{
    public class Exporter : IExport
    {
        const int MaxMSExcelNumberOfDigits = 15;
        const uint HeaderRowIndex = 1U;
        const string FontName = "Times New Roman";
        const double FontSize = 10D;
        static readonly System.Drawing.Font Font = new System.Drawing.Font(FontName, (float)FontSize);
        static readonly DateTime OADate0 = new DateTime(1899, 12, 30);

        public MemoryStream Export<T>(IEnumerable<T> data, Dictionary<string, ExportInfo> exportInfos)
        {
            MemoryStream result = null;

            if (data == null)
                return result;

            SpreadsheetDocument spreadsheetDocument = null;

            try
            {
                spreadsheetDocument = SpreadsheetDocument.Create(result = new MemoryStream(), SpreadsheetDocumentType.Workbook);
                CreateParts(spreadsheetDocument, data, exportInfos);
                spreadsheetDocument.Close();
            }
            finally
            {
                if(spreadsheetDocument != null)
                    spreadsheetDocument.Dispose();
            }

            return result;
        }

        static void CreateParts<T>(SpreadsheetDocument document, IEnumerable<T> data, Dictionary<string, ExportInfo> exportInfos)
        {
            var workbookPart = document.AddWorkbookPart();
            GenerateWorkbookPartContent(workbookPart);
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>("rId1");
            GenerateWorksheetPartContent(worksheetPart, data, exportInfos);
            var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>("rId2");
            GenerateWorkbookStylesPartContent(workbookStylesPart);
            workbookPart.Workbook.Save();
        }

        static void GenerateWorkbookPartContent(WorkbookPart workbookPart)
        {
            var workbook = new Workbook();
            var sheets = new Sheets();
            var sheet = new Sheet { Name = "Sheet1", SheetId = 1, Id = "rId1" };

            sheets.Append(sheet);
            workbook.Append(sheets);
            workbookPart.Workbook = workbook;
        }

        static void GenerateWorksheetPartContent<T>(WorksheetPart worksheetPart, IEnumerable<T> data, Dictionary<string, ExportInfo> exportInfos)
        {
            var worksheet = new Worksheet();
            var columns = new Columns();
            List<Column> columnsList;
            var sheetData = new SheetData();

            ExportData(sheetData, data, exportInfos, out columnsList);

            if (columnsList != null)
                columns.Append(columnsList);

            worksheet.Append(columns);
            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;
        }

        static void GenerateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart)
        {
            var stylesheet = new Stylesheet();

            stylesheet.Append(GenerateNumberingFormats());
            stylesheet.Append(GenerateFonts());
            stylesheet.Append(GenerateFills());
            stylesheet.Append(GenerateBorders());
            stylesheet.Append(GenerateCellStyleFormats());
            stylesheet.Append(GenerateCellFormats());
            stylesheet.Append(GenerateCellStyles());

            workbookStylesPart.Stylesheet = stylesheet;
        }

        #region WorkbookStyles generators

        static NumberingFormats GenerateNumberingFormats()
        {
            var numberingFormats = new NumberingFormats { Count = 5U };
            var numberingFormat1 = new NumberingFormat { NumberFormatId = 164U, FormatCode = "0.0" };
            var numberingFormat2 = new NumberingFormat { NumberFormatId = 165U, FormatCode = "0.0000" };
            var numberingFormat3 = new NumberingFormat { NumberFormatId = 166U, FormatCode = "0.000000" };
            var numberingFormat4 = new NumberingFormat { NumberFormatId = 167U, FormatCode = "dd/mm/yyyy\\ hh:mm:ss;@" };
            var numberingFormat5 = new NumberingFormat { NumberFormatId = 168U, FormatCode = "h:mm:ss;@" };

            numberingFormats.Append(numberingFormat1);
            numberingFormats.Append(numberingFormat2);
            numberingFormats.Append(numberingFormat3);
            numberingFormats.Append(numberingFormat4);
            numberingFormats.Append(numberingFormat5);

            return numberingFormats;
        }

        static Fonts GenerateFonts()
        {
            var fonts = new Fonts { Count = 1U, KnownFonts = true };

            var font1 = new Font();
            var fontSize1 = new FontSize { Val = FontSize };
            var color1 = new Color { Theme = 1U };
            var fontName1 = new FontName { Val = FontName };
            var fontFamilyNumbering1 = new FontFamilyNumbering { Val = 1 };
            var fontCharSet1 = new FontCharSet { Val = 204 };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontCharSet1);

            fonts.Append(font1);

            return fonts;
        }

        static Fills GenerateFills()
        {
            var fills = new Fills { Count = 3U };

            var fill1 = new Fill();
            var patternFill1 = new PatternFill { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            var fill2 = new Fill();
            var patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            var fill3 = new Fill();
            var patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            var foregroundColor1 = new ForegroundColor() { Theme = (UInt32Value)0U, Tint = -0.14999847407452621D };
            var backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);

            fill3.Append(patternFill3);

            fills.Append(fill1);
            fills.Append(fill2);
            fills.Append(fill3);

            return fills;
        }

        static Borders GenerateBorders()
        {
            var borders = new Borders { Count = 2U };

            var border1 = new Border();
            var leftBorder1 = new LeftBorder();
            var rightBorder1 = new RightBorder();
            var topBorder1 = new TopBorder();
            var bottomBorder1 = new BottomBorder();
            var diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            var border2 = new Border();
            var leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };
            var color1 = new Color() { Indexed = (UInt32Value)64U };

            leftBorder2.Append(color1);

            var rightBorder2 = new RightBorder() { Style = BorderStyleValues.Thin };
            var color2 = new Color() { Indexed = (UInt32Value)64U };

            rightBorder2.Append(color2);

            var topBorder2 = new TopBorder() { Style = BorderStyleValues.Thin };
            var color3 = new Color() { Indexed = (UInt32Value)64U };

            topBorder2.Append(color3);

            var bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };
            var color4 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color4);

            var diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            borders.Append(border1);
            borders.Append(border2);

            return borders;
        }

        static CellStyleFormats GenerateCellStyleFormats()
        {
            var cellStyleFormats = new CellStyleFormats { Count = 1U };
            var cellFormat1 = new CellFormat { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U };

            cellStyleFormats.Append(cellFormat1);

            return cellStyleFormats;
        }

        static CellFormats GenerateCellFormats()
        {
            var cellFormats = new CellFormats { Count = 18U };

            var cellFormat1 = new CellFormat { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U };

            //NumericX0
            var cellFormat2 = new CellFormat { NumberFormatId = 1U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment2 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat2.Append(alignment2);

            //NumericX1
            var cellFormat3 = new CellFormat { NumberFormatId = 164U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment3 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat3.Append(alignment3);

            //NumericX2
            var cellFormat4 = new CellFormat { NumberFormatId = 2U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment4 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat4.Append(alignment4);

            //NumericX4
            var cellFormat5 = new CellFormat { NumberFormatId = 165U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment5 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat5.Append(alignment5);

            //NumericX6
            var cellFormat6 = new CellFormat { NumberFormatId = 166U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment6 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat6.Append(alignment6);

            //Date
            var cellFormat7 = new CellFormat { NumberFormatId = 14U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment7 = new Alignment { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat7.Append(alignment7);

            //DateTime
            var cellFormat8 = new CellFormat { NumberFormatId = 167U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment8 = new Alignment { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat8.Append(alignment8);

            //Time
            var cellFormat9 = new CellFormat { NumberFormatId = 168U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyNumberFormat = true, ApplyAlignment = true };
            var alignment9 = new Alignment { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat9.Append(alignment9);

            //AlignmentLeft
            var cellFormat10 = new CellFormat { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyAlignment = true };
            var alignment10 = new Alignment { Horizontal = HorizontalAlignmentValues.Left };
            cellFormat10.Append(alignment10);

            //AlignmentCenter
            var cellFormat11 = new CellFormat { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyAlignment = true };
            var alignment11 = new Alignment { Horizontal = HorizontalAlignmentValues.Center };
            cellFormat11.Append(alignment11);

            //AlignmentRight
            var cellFormat12 = new CellFormat { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U, FormatId = 0U, ApplyAlignment = true };
            var alignment12 = new Alignment { Horizontal = HorizontalAlignmentValues.Right };
            cellFormat12.Append(alignment12);

            //AlignmentLeftWrapText
            var cellFormat13 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            var alignment13 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, WrapText = true };
            cellFormat13.Append(alignment13);

            //AlignmentCenterWrapText
            var cellFormat14 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            var alignment14 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, WrapText = true };
            cellFormat14.Append(alignment14);

            //AlignmentRightWrapText
            var cellFormat15 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyAlignment = true };
            var alignment15 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right, WrapText = true };
            cellFormat15.Append(alignment15);

            //TextAlignmentLeftWrapTextBorderFill
            var cellFormat16 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            var alignment16 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, WrapText = true };
            cellFormat16.Append(alignment16);

            //TextAlignmentCenterWrapTextBorderFill
            var cellFormat17 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            var alignment17 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, WrapText = true };
            cellFormat17.Append(alignment17);

            //TextAlignmentRightWrapTextBorderFill
            var cellFormat18 = new CellFormat() { NumberFormatId = (UInt32Value)49U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyAlignment = true, ApplyBorder = true, ApplyNumberFormat = true };
            var alignment18 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right, WrapText = true };
            cellFormat18.Append(alignment18);

            cellFormats.Append(cellFormat1);
            cellFormats.Append(cellFormat2);
            cellFormats.Append(cellFormat3);
            cellFormats.Append(cellFormat4);
            cellFormats.Append(cellFormat5);
            cellFormats.Append(cellFormat6);
            cellFormats.Append(cellFormat7);
            cellFormats.Append(cellFormat8);
            cellFormats.Append(cellFormat9);
            cellFormats.Append(cellFormat10);
            cellFormats.Append(cellFormat11);
            cellFormats.Append(cellFormat12);
            cellFormats.Append(cellFormat13);
            cellFormats.Append(cellFormat14);
            cellFormats.Append(cellFormat15);
            cellFormats.Append(cellFormat16);
            cellFormats.Append(cellFormat17);
            cellFormats.Append(cellFormat18);

            return cellFormats;
        }

        static CellStyles GenerateCellStyles()
        {
            var cellStyles = new CellStyles { Count = 1U };
            var cellStyle1 = new CellStyle { Name = "Standard", FormatId = 0U, BuiltinId = 0U };

            cellStyles.Append(cellStyle1);

            return cellStyles;
        }

        #endregion

        static void ExportData<T>(SheetData sheetData, IEnumerable<T> data, Dictionary<string, ExportInfo> exportInfos, out List<Column> columns)
        {
            var propertiesInfos = GetProperetiesForExport(typeof(T), exportInfos);

            GenerateColumnsHeaders(sheetData, propertiesInfos, out columns);

            var arr = data.ToArray();
            for (var iRow = 0; iRow < arr.Length; ++iRow)
            {
                var rowIndex = HeaderRowIndex + (uint)iRow + 1;
                var xlsRow = new Row { RowIndex = rowIndex };

                sheetData.Append(xlsRow);

                for (var iColumn = 0; iColumn < propertiesInfos.Length; ++iColumn)
                {
                    var value = propertiesInfos[iColumn].PropertyInfo.GetValue(arr[iRow]);

                    if (value == null)
                        continue;

                    var xlsColumnName = ColNoToName(iColumn + 1);
                    var cell = new Cell { CellReference = xlsColumnName + rowIndex };
                    var cellValue = value.ToString();

                    switch (Type.GetTypeCode(GetPropertyType(propertiesInfos[iColumn].PropertyInfo.PropertyType)))
                    {
                        case TypeCode.Boolean:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
                                cell.StyleIndex = 10U; // AlignmentCenter
                                cell.CellValue = new CellValue(Convert.ToBoolean(value) ? "1" : "0");
                                break;
                            }
                        case TypeCode.DateTime:
                        {
                                var valueDateTime = Convert.ToDateTime(value);

                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);

                                if (valueDateTime.Date == OADate0)
                                {
                                    cell.StyleIndex = 8U; // Time
                                    cellValue = "00:00:00";
                                }
                                else if (valueDateTime.TimeOfDay == TimeSpan.Zero)
                                {
                                    cell.StyleIndex = 6U; // Date
                                    cellValue = "00/00/0000";
                                }
                                else
                                {
                                    cell.StyleIndex = 7U; // DateTime
                                    cellValue = "00/00/0000 00:00:00";
                                }

                                cell.CellValue = new CellValue(valueDateTime.ToOADate().ToString(CultureInfo.InvariantCulture));
                                break;
                            }
                        case TypeCode.Char:
                        case TypeCode.String:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
                                cell.StyleIndex = 9U; // AlignmentLeft
                                cell.InlineString = new InlineString { Text = new Text { Text = cellValue = Convert.ToString(value).Replace("\r", string.Empty) } };

                                break;
                            }
                        case TypeCode.Byte:
                        case TypeCode.SByte:
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                            {
                                var valueStr = cellValue = value.ToString();

                                if (valueStr.Length <= MaxMSExcelNumberOfDigits)
                                {
                                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                    cell.StyleIndex = 1U; // NumericX0
                                    cell.CellValue = new CellValue(valueStr);
                                }
                                else
                                {
                                    cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
                                    cell.StyleIndex = 11U; // AlignmentRight
                                    cell.InlineString = new InlineString { Text = new Text { Text = valueStr } };
                                }
                                break;
                            }
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                cell.StyleIndex = 3U; // NumericX2
                                cell.CellValue = new CellValue(cellValue = string.Format(CultureInfo.InvariantCulture, "{0}", value));
                                break;
                            }
                    }
                    xlsRow.Append(cell);

                    var width = GetWidth(Font, cellValue);

                    if (!columns[iColumn].Width.HasValue || columns[iColumn].Width.Value < width)
                        columns[iColumn].Width.Value = width;
                }
            }
        }

        private static PropertyInfoForExport[] GetProperetiesForExport(IReflect type, Dictionary<string, ExportInfo> exportInfos)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .GroupJoin(exportInfos, propertyInfo => propertyInfo.Name, exportInfo => exportInfo.Key, (pi, ei) => new { PropertyInfo = pi, ExportInfo = ei.Select(item => new { item.Value.Order, item.Value.ColumnName }) })
                .SelectMany(groupJoinItem => groupJoinItem.ExportInfo.DefaultIfEmpty(), (pi, ei) => new { Order = ei != null ? ei.Order : 0, pi.PropertyInfo, ColumnName = ei !=null ? ei.ColumnName : string.Empty })
                .OrderBy(item => item.Order)
                .Select(item => new PropertyInfoForExport(item.PropertyInfo, item.ColumnName))
                .ToArray();
        }

        static void GenerateColumnsHeaders(SheetData sheetData, PropertyInfoForExport[] propertyInfos, out List<Column> columns)
        {
            columns = propertyInfos.Length != 0 ? new List<Column>() : null;

            var xlsRow = new Row { RowIndex = HeaderRowIndex };
            sheetData.Append(xlsRow);

            for (var iColumn = 0; iColumn < propertyInfos.Length; ++iColumn)
            {
                var xlsColumnName = ColNoToName(iColumn + 1);
                var cell = new Cell { CellReference = xlsColumnName + HeaderRowIndex, DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = 10U, InlineString = new InlineString { Text = new Text { Text = !string.IsNullOrWhiteSpace(propertyInfos[iColumn].ColumnName) ? propertyInfos[iColumn].ColumnName : propertyInfos[iColumn].PropertyInfo.Name } } };

                xlsRow.Append(cell);

                columns.Add(new Column { Min = (uint)(iColumn + 1), Max = (uint)(iColumn + 1), Width = GetWidth(Font, cell.InlineString.Text.Text), BestFit = true, CustomWidth = true });
            }
        }

        static Type GetPropertyType(Type propertyType)
        {
            return propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>) ? Nullable.GetUnderlyingType(propertyType) : propertyType;
        }

        static string ColNoToName(int colNo)
        {
            var colName = string.Empty;

            if (colNo <= 0)
                return (colName);

            char[] buff;

            if (colNo <= 'Z' - 'A' + 1)
                buff = new[] { (char)('A' + colNo - 1) };
            else
            {
                var hi = colNo / ('Z' - 'A' + 1);

                buff = new[] { (char)(hi + 'A' - 1), (char)(colNo - hi * ('Z' - 'A' + 1) + 'A' - 1) };
            }

            colName = new string(buff);

            return (colName);
        }

        static double GetWidth(System.Drawing.Font stringFont, string text)
        {
            const int maximumDigitWidthInPixels = 7;

            if (string.IsNullOrWhiteSpace(text))
                return maximumDigitWidthInPixels;

            System.Drawing.Size textSize = TextRenderer.MeasureText(text, stringFont);
            //double width = (double)(((textSize.Width / (double)7) * 256) - (128 / 7)) / 256;
            //width = (double)decimal.Round((decimal)width + 0.2M, 2);

            return (double)decimal.Round((decimal)(((textSize.Width + 5) / (double)maximumDigitWidthInPixels * 256) / 256), 2);
        }

        static void Test()
        {
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 10f);
            string text = "ИСТИНА";
            System.Drawing.Size textSize = TextRenderer.MeasureText(text, font);
            int maximumDigitWidthInPixels = 7;
            double width = ((text.Length * maximumDigitWidthInPixels + 5) / (double)maximumDigitWidthInPixels * 256d) / 256;
            width = ((textSize.Width + 4)/(double)maximumDigitWidthInPixels * 256d) / 256d;

            //text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯабвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            text = "0123456789";

            maximumDigitWidthInPixels = 0;

            foreach (var c in text)
            {
                textSize = TextRenderer.MeasureText(new string(c, 1), font);

                if (maximumDigitWidthInPixels < textSize.Width)
                    maximumDigitWidthInPixels = textSize.Width;
            }

            using (var g = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(200, 200)))
            {
                System.Drawing.SizeF sizeF = g.MeasureString(text, font);

                double max = 0d;

                foreach (var c in text)
                {
                    sizeF = g.MeasureString(new string(c, 1), font);

                    if (max < sizeF.Width)
                        max = sizeF.Width;
                }
            }
        }
    }
}
