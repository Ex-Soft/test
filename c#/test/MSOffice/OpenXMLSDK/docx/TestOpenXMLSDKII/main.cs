using System;
using System.Linq;
using System.Xml;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TestOpenXMLSDKII
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string
                    currentDirectory = Directory.GetCurrentDirectory();

                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                XmlDocument
                    data = new XmlDocument();

                data.Load(currentDirectory + "data.xml");

                byte[]
                    bytesTemplate = File.ReadAllBytes(currentDirectory + "template.docx");

                MemoryStream
                    memoryStream = new MemoryStream();

                memoryStream.Write(bytesTemplate, 0, bytesTemplate.Length);

                FillTemplate(memoryStream, data);

                byte[]
                    bytesOutput = memoryStream.ToArray();

                memoryStream.Close();

                string
                    outputFilename;

                if (File.Exists(outputFilename = currentDirectory + "output.docx"))
                    File.Delete(outputFilename);

                FileStream
                    fileStream = File.Open(outputFilename, FileMode.Create);

                fileStream.Write(bytesOutput, 0, bytesOutput.Length);

                fileStream.Close();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                Console.ReadLine();
            }
        }

        static void FillTemplate(Stream stream, XmlDocument data)
        {
            WordprocessingDocument
                wordprocessingDocument = WordprocessingDocument.Open(stream, true);

            var
                bookmarksCollection = wordprocessingDocument.MainDocumentPart.RootElement.Descendants<BookmarkStart>();

            foreach (XmlNode node in data.DocumentElement.ChildNodes)
            {
                string
                    nodeName = node.Name;

                BookmarkStart
                    bookmarkStart;

                if ((bookmarkStart = bookmarksCollection.Where(b => b.Name == nodeName).Select(b => b).FirstOrDefault()) != null)
                {
                    if(node.ChildNodes.Count==1)
                        Fill(node, bookmarkStart);
                    else
                        Fill(node, GetTable(bookmarkStart));
                }
            }

            wordprocessingDocument.Close();
        }

        static Table GetTable(BookmarkStart bookmarkStart)
        {
            return bookmarkStart.Parent.Parent.Parent.Parent as Table;
        }

        static void Fill(XmlNode node, BookmarkStart bookmarkStart)
        {
            bookmarkStart.InsertAfterSelf(CreateRun(node));
        }

        static void Fill(XmlNode node, Table table)
        {
            if (table == null)
                return;

            int
                cellsCount = 0;

            TableGrid
                tableGrid;

            if ((tableGrid = table.Descendants<TableGrid>().FirstOrDefault()) != null)
                cellsCount = tableGrid.Descendants<GridColumn>().Count();

            foreach (XmlNode row in node.ChildNodes)
            {
                TableRow
                    newTableRow = new TableRow();

                for (int i = 0; i < row.ChildNodes.Count && i < cellsCount; ++i)
                {
                    TableCell
                        newTableCell = new TableCell();

                    newTableCell.Append(new Paragraph(CreateRun(row.ChildNodes[i])));

                    newTableRow.Append(newTableCell);
                }

                table.Append(newTableRow);
            }
        }

        static string GetNodeTextValue(XmlNode node)
        {
            return node.ChildNodes.Count > 0 ? node.ChildNodes[0].Value : string.Empty;
        }

        static Run CreateRun(XmlNode node)
        {
            Run
                run=new Run();

            string[]
                textLines = GetNodeTextValue(node).Split('\n');

            for (int i = 0; i < textLines.Length; ++i)
            {
                run.AppendChild(new Text(textLines[i]));
                if (i < (textLines.Length - 1))
                    run.AppendChild(new Break() {Type = BreakValues.TextWrapping});
            }

            return run;
        }
    }
}
