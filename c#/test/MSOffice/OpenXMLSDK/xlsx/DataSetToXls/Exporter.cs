using System;
using System.Data;
using System.Globalization;
using System.IO;
using DocumentFormat.OpenXml;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using Excel = DocumentFormat.OpenXml.Office.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Border = DocumentFormat.OpenXml.Spreadsheet.Border;
using BottomBorder = DocumentFormat.OpenXml.Spreadsheet.BottomBorder;
using Color = DocumentFormat.OpenXml.Spreadsheet.Color;
using Fill = DocumentFormat.OpenXml.Spreadsheet.Fill;
using Font = DocumentFormat.OpenXml.Spreadsheet.Font;
using FontCharSet = DocumentFormat.OpenXml.Spreadsheet.FontCharSet;
using FontSize = DocumentFormat.OpenXml.Spreadsheet.FontSize;
using Fonts = DocumentFormat.OpenXml.Spreadsheet.Fonts;
using HorizontalAlignmentValues = DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues;
using LeftBorder = DocumentFormat.OpenXml.Spreadsheet.LeftBorder;
using NumberingFormat = DocumentFormat.OpenXml.Spreadsheet.NumberingFormat;
using Path = System.IO.Path;
using PatternFill = DocumentFormat.OpenXml.Spreadsheet.PatternFill;
using RightBorder = DocumentFormat.OpenXml.Spreadsheet.RightBorder;
using Text = DocumentFormat.OpenXml.Spreadsheet.Text;
using TopBorder = DocumentFormat.OpenXml.Spreadsheet.TopBorder;

namespace DataSetToXls
{
    class Exporter
    {
        const int MaxMSExcelNumberOfDigits = 15;
        const uint HeaderRowIndex = 1U;
        const string WorksheetExtensionUri = "{CCE6A557-97BC-4b89-ADB6-D9C93CAAB3DF}";

        public bool Export(DataSet dataSet, string path, out string errorMessage)
        {
            errorMessage = null;
            var result = false;

            if (dataSet == null || dataSet.Tables.Count == 0)
                return result;

            var outputFileName = Path.Combine(path, dataSet.DataSetName + ".xlsx");

            try
            {
                if (File.Exists(outputFileName))
                    File.Delete(outputFileName);

                using (var spreadsheetDocument = SpreadsheetDocument.Create(outputFileName, SpreadsheetDocumentType.Workbook))
                {
                    CreateParts(spreadsheetDocument, dataSet);
                    spreadsheetDocument.Close();
                }

                result = true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        static void CreateParts(SpreadsheetDocument document, DataSet dataSet)
        {
            var workbookPart = document.AddWorkbookPart();
            GenerateWorkbookPartContent(workbookPart, dataSet);

            for (var i = 0; i < dataSet.Tables.Count; ++i)
            {
                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>(string.Format("rId{0}", i + 1));
                GenerateWorksheetPartContent(worksheetPart, dataSet.Tables[i]);
            }

            var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>(string.Format("rId{0}", dataSet.Tables.Count + 1));
            GenerateWorkbookStylesPartContent(workbookStylesPart);

            workbookPart.Workbook.Save();
        }

        static void GenerateWorkbookPartContent(WorkbookPart workbookPart, DataSet dataSet)
        {
            var workbook = new Workbook();
            var sheets = new Sheets();

            for (var i = 0; i < dataSet.Tables.Count; ++i)
            {
                var sheet = new Sheet { Name = dataSet.Tables[i].TableName, SheetId = (uint) (i + 1), Id = string.Format("rId{0}", i + 1) };
                sheets.Append(sheet);
            }

            workbook.Append(sheets);
            workbookPart.Workbook = workbook;
        }

        static void GenerateWorksheetPartContent(WorksheetPart worksheetPart, DataTable dataTable)
        {
            var worksheet = new Worksheet();
            var sheetData = new SheetData();

            ExportDataTable(sheetData, dataTable);
            worksheet.Append(sheetData);

            if (dataTable.TableName != "Дата")
            {
                var worksheetExtensionList = new WorksheetExtensionList();
                var worksheetExtension = new WorksheetExtension { Uri = WorksheetExtensionUri };
                var dataValidations = new X14.DataValidations { Count = (UInt32Value)1U };
                var dataValidation = new X14.DataValidation { Type = DataValidationValues.List, AllowBlank = true, ShowInputMessage = true, ShowErrorMessage = true };
                var dataValidationForumla1 = new X14.DataValidationForumla1();
                var formula = new Excel.Formula { Text = "Дата!$B$2:$B$4" };

                dataValidationForumla1.Append(formula);
                var referenceSequence = new Excel.ReferenceSequence { Text = "F2:F4" };

                dataValidation.Append(dataValidationForumla1);
                dataValidation.Append(referenceSequence);
                dataValidations.Append(dataValidation);
                worksheetExtension.Append(dataValidations);
                worksheetExtensionList.Append(worksheetExtension);

                worksheet.Append(worksheetExtensionList);    
            }

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
            var fontSize1 = new FontSize { Val = 10D };
            var color1 = new Color { Theme = 1U };
            var fontName1 = new FontName { Val = "Times New Roman" };
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
            var fills = new Fills { Count = 2U };

            var fill1 = new Fill();
            var patternFill1 = new PatternFill { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            var fill2 = new Fill();
            var patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            fills.Append(fill1);
            fills.Append(fill2);

            return fills;
        }

        static Borders GenerateBorders()
        {
            var borders = new Borders { Count = 1U };

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

            borders.Append(border1);

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
            var cellFormats = new CellFormats { Count = 12U };

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

        static void ExportDataTable(SheetData sheetData, DataTable dataTable)
        {
            GenerateColumnsHeaders(sheetData, dataTable);

            for (var iRow = 0; iRow < dataTable.Rows.Count; ++iRow)
            {
                var dataTableRow = dataTable.Rows[iRow];
                var rowIndex = HeaderRowIndex + (uint)iRow + 1;
                var xlsRow = new Row { RowIndex = rowIndex };

                sheetData.Append(xlsRow);

                for (var iColumn = 0; iColumn < dataTable.Columns.Count; ++iColumn)
                {
                    var dataTableColumn = dataTable.Columns[iColumn];

                    if (dataTableRow.IsNull(dataTableColumn.ColumnName))
                        continue;

                    var xlsColumnName = ColNoToName(iColumn + 1);
                    var cell = new Cell { CellReference = xlsColumnName + rowIndex };

                    switch (Type.GetTypeCode(dataTableColumn.DataType))
                    {
                        case TypeCode.Boolean:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
                                cell.StyleIndex = 10U;
                                cell.CellValue = new CellValue(Convert.ToBoolean(dataTableRow[dataTableColumn.ColumnName]) ? "1" : "0");
                                break;
                            }
                        case TypeCode.DateTime:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                cell.StyleIndex = 7U;
                                cell.CellValue = new CellValue(Convert.ToDateTime(dataTableRow[dataTableColumn.ColumnName]).ToOADate().ToString(CultureInfo.InvariantCulture));
                                break;
                            }
                        case TypeCode.Char:
                        case TypeCode.String:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
                                cell.StyleIndex = 9U;

                                //string[]
                                //    newLineArray = new[] {Environment.NewLine},
                                //    lines = Convert.ToString(dataTableRow[dataTableColumn.ColumnName]).Split(newLineArray, StringSplitOptions.None);

                                //InlineString
                                //    inlineString = new InlineString();

                                //for (int i = 0; i < lines.Length; ++i)
                                //{
                                //    inlineString.Append(new Text {Text = lines[i]});

                                //    if(i<lines.Length-1)
                                //        inlineString.Append(new DocumentFormat.OpenXml.Wordprocessing.Break { Type = BreakValues.TextWrapping });
                                //}

                                //cell.InlineString = inlineString;

                                //cell.InlineString = new InlineString { Text = new Text { Text = Convert.ToString(dataTableRow[dataTableColumn.ColumnName]) } };
                                cell.InlineString = new InlineString { Text = new Text { Text = Convert.ToString(dataTableRow[dataTableColumn.ColumnName]).Replace("\r", string.Empty) } };
                                
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
                                var value = dataTableRow[dataTableColumn.ColumnName].ToString();

                                if (value.Length <= MaxMSExcelNumberOfDigits)
                                {
                                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                    cell.StyleIndex = 1U;
                                    cell.CellValue = new CellValue(value);
                                }
                                else
                                {
                                    cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
                                    cell.StyleIndex = 9U;
                                    cell.InlineString = new InlineString { Text = new Text { Text = value } };
                                }
                                break;
                            }
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            {
                                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                cell.StyleIndex = 3U;
                                cell.CellValue = new CellValue(string.Format(CultureInfo.InvariantCulture, "{0}", dataTableRow[dataTableColumn.ColumnName]));
                                break;
                            }
                    }
                    xlsRow.Append(cell);
                }
            }
        }

        static void GenerateColumnsHeaders(SheetData sheetData, DataTable dataTable)
        {
            var xlsRow = new Row { RowIndex = HeaderRowIndex };
            sheetData.Append(xlsRow);

            for (var iColumn = 0; iColumn < dataTable.Columns.Count; ++iColumn)
            {
                var xlsColumnName = ColNoToName(iColumn + 1);
                var cell = new Cell { CellReference = xlsColumnName + HeaderRowIndex, DataType = new EnumValue<CellValues>(CellValues.InlineString), StyleIndex = 10U, InlineString = new InlineString { Text = new Text { Text = dataTable.Columns[iColumn].ColumnName } } };

                xlsRow.Append(cell);
            }
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
    }
}
