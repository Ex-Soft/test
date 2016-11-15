//#define TEST_STREAM
//#define TEST_TEMPLATE
//#define TEST_TABLE
#define TEST_BOOKMARK
//#define TEST_PARAGRAPH

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TestOpenXMLSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string
                    currentDirectory = System.IO.Directory.GetCurrentDirectory();

                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                string
                    inputFileName = currentDirectory + "Word_tst.docx";

                #if TEST_STREAM
                    Stream
                        stream = File.Open(inputFileName, FileMode.Open);
                #endif

                WordprocessingDocument
                    wordprocessingDocument = WordprocessingDocument.Open(
                    #if TEST_STREAM
                        stream
                    #else
                        inputFileName
                    #endif
                        , true);

                #if TEST_PARAGRAPH
                    Body
                        body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    Paragraph
                        para = body.AppendChild(new Paragraph());

                    Run
                        run = para.AppendChild(new Run());

                    RunProperties
                        runProperties = run.AppendChild(new RunProperties(new Bold()));

                    run.AppendChild(new Text("Test Open XML SDK"));
                #endif

                #if TEST_BOOKMARK
                    IDictionary<String, BookmarkStart>
                        bookmarkMap = new Dictionary<String, BookmarkStart>();

                    foreach (BookmarkStart bookmarkStart in wordprocessingDocument.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
                    {
                        if (bookmarkStart.Name == "_GoBack")
                            continue;

                        bookmarkMap[bookmarkStart.Name] = bookmarkStart;
                    }

                    foreach (BookmarkStart bookmarkStart in bookmarkMap.Values)
                    {
                        TableCell
                            cell;

                        if ((cell = bookmarkStart.Parent.Parent as TableCell) != null)
                        {
                            TableRow
                                row;

                            if ((row = cell.Parent as TableRow) != null)
                            {
                                Table
                                    table;

                                int
                                    cellCount = row.Descendants<TableCell>().Count();

                                if ((table = row.Parent as Table) != null)
                                {
                                    TableRow
                                        newTableRow = new TableRow();

                                    for (int i = 0; i < cellCount; ++i)
                                    {
                                        TableCell
                                            newTableCell = new TableCell();

                                        newTableCell.Append(new Paragraph(new Run(new Text(i.ToString()))));

                                        newTableRow.Append(newTableCell);
                                    }

                                    table.Append(newTableRow);
                                }
                            }
                        }
                        /*
                        Run
                            bookmarkText = bookmarkStart.InsertAfterSelf(new Run(new Text("1234567890")));*/
                    }
                #endif

                #if TEST_TABLE
                    Table
                        table = new Table();

                    TableProperties
                        tblProp = new TableProperties(
                            new TableBorders(
                            new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 }
                        )
                    );

                    table.AppendChild<TableProperties>(tblProp);

                    TableRow
                        tr = new TableRow();

                    TableCell
                        tc1 = new TableCell();

                    tc1.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
                    tc1.Append(new Paragraph(new Run(new Text("some text"))));

                    tr.Append(tc1);

                    TableCell
                        tc2 = new TableCell(tc1.OuterXml);

                    tr.Append(tc2);

                    table.Append(tr);

                    tr=new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge(){ Val = MergedCellValues.Restart }));
                    tc1.Append(new Paragraph(new Run(new Text("1"))));
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("21"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Continue }));
                    tc1.Append(new Paragraph());
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("22"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Continue }));
                    tc1.Append(new Paragraph());
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("23"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Restart }));
                    tc1.Append(new Paragraph(new Run(new Text("2"))));
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("24"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Continue }));
                    tc1.Append(new Paragraph());
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("25"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Restart }));
                    tr.Append(tc1);
                    tc2 = new TableCell();
                    tc2.Append(new TableCellProperties());
                    tc2.Append(new Paragraph(new Run(new Text("26"))));
                    tr.Append(tc2);
                    table.Append(tr);

                    wordprocessingDocument.MainDocumentPart.Document.Body.Append(table);

                    table = new Table();
                    tblProp = new TableProperties(
                                new TableBorders(
                                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 }
                            )
                        );
                    table.AppendChild<TableProperties>(tblProp);

                    tc1.Append(table);
                    tc1.Append(new Paragraph());

                    tr=new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties());
                    tc1.Append(new Paragraph(new Run(new Text("some text"))));
                    tr.Append(tc1);
                    tc2 = new TableCell(tc1.OuterXml);
                    tr.Append(tc2);
                    table.Append(tr);

                    wordprocessingDocument.MainDocumentPart.Document.Body.Append(new Paragraph(new Run(new Text("Paragraph"))));

                    table = new Table();
                    tblProp = new TableProperties(
                                new TableBorders(
                                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 }
                            )
                        );
                    table.AppendChild<TableProperties>(tblProp);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties());
                    tc1.Append(new Paragraph(new Run(new Text("some text"))));
                    tr.Append(tc1);
                    tc2 = new TableCell(tc1.OuterXml);
                    tr.Append(tc2);
                    tc2 = new TableCell(tc1.OuterXml);
                    tr.Append(tc2);
                    tc2 = new TableCell(tc1.OuterXml);
                    tr.Append(tc2);
                    table.Append(tr);

                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new TableCellProperties());
                    tc1.Append(new Paragraph(new Run(new Text("some text"))));
                    tc1.Append(new GridSpan() { Val = 2 });
                    tr.Append(tc1);
                    tc2 = new TableCell(tc1.OuterXml);
                    tr.Append(tc2);
                    table.Append(tr);

                    wordprocessingDocument.MainDocumentPart.Document.Body.Append(table);
                #endif

                wordprocessingDocument.Close();

                #if TEST_STREAM
                    stream.Close();
                #endif
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
