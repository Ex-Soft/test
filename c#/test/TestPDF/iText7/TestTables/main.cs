using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.Contains("bin"))
    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal)];

try
{
    string outFileName = Path.Combine(currentDirectory, "TestTables.pdf");
    if (File.Exists(outFileName))
        File.Delete(outFileName);

    string imageFileName = Path.Combine(currentDirectory, "TestImage.jpg");

    PdfDocument pdfDoc = new PdfDocument(new PdfWriter(outFileName));
    Document doc = new Document(pdfDoc);

    doc.Add(new Paragraph("With 3 columns:"));

    Table table = new Table(UnitValue.CreatePercentArray([33.33f, 33.33f, 33.33f]));
    table.SetMarginTop(5);
    table.AddCell("Col a");
    table.AddCell("Col b");
    table.AddCell("Col c");
    table.AddCell("Value a");
    table.AddCell("Value b");
    table.AddCell("This is a long description for column c. "
                  + "It needs much more space hence we made sure that the third column is wider.");
    doc.Add(table);

    doc.Add(new Paragraph("With 2 columns:"));

    table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
    table.SetMarginTop(5);
    table.AddCell("Col a");
    table.AddCell("Col b");
    table.AddCell("Value a");
    table.AddCell("Value b");
    table.AddCell(new Cell(1, 2).Add(new Paragraph("Value b")));
    table.AddCell(new Cell(1, 2).Add(new Paragraph("This is a long description for column c. "
                                                   + "It needs much more space hence we made sure that the third column is wider.")));
    table.AddCell("Col a");
    table.AddCell("Col b");
    table.AddCell("Value a");
    table.AddCell("Value b");
    table.AddCell(new Cell(1, 2).Add(new Paragraph("Value b")));
    table.AddCell(new Cell(1, 2).Add(new Paragraph("This is a long description for column c. "
                                                   + "It needs much more space hence we made sure that the third column is wider.")));

    doc.Add(table);

    if (File.Exists(imageFileName))
    {
        table = new Table(UnitValue.CreatePercentArray([5f, 10f, 85f]))
            .UseAllAvailableWidth();

        table.AddHeaderCell(new Cell().Add(new Paragraph("ID")).SetTextAlignment(TextAlignment.CENTER));
        table.AddHeaderCell(new Cell().Add(new Paragraph("Name")).SetTextAlignment(TextAlignment.CENTER));
        table.AddHeaderCell(new Cell().Add(new Paragraph("Image")).SetTextAlignment(TextAlignment.CENTER));

        table.AddCell("0");
        table.AddCell("Widget");

        Cell cell = new Cell();

        Table nestedTable = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

        Image img0 = new Image(ImageDataFactory.Create(imageFileName));
        img0.SetWidth(UnitValue.CreatePercentValue(100));
        Cell imageCell = new Cell().Add(img0);
        imageCell.SetBorder(Border.NO_BORDER);
        nestedTable.AddCell(imageCell);

        Paragraph text = new Paragraph("This is a sample text to the right of the image. (nested table)");
        Cell textCell = new Cell().Add(text);
        textCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
        textCell.SetBorder(Border.NO_BORDER);
        nestedTable.AddCell(textCell);

        cell.Add(nestedTable);

        table.AddCell(cell);

        table.AddCell("1");
        table.AddCell("Widget");

        Image img1 = new Image(ImageDataFactory.Create(imageFileName));
        img1.SetWidth(UnitValue.CreatePercentValue(80)); // Scale to 80% of cell width
        table.AddCell(new Cell().Add(img1).SetTextAlignment(TextAlignment.CENTER));

        table.AddCell("2");
        table.AddCell("Widget");

        Cell imageAndTextCell = new Cell()
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetTextAlignment(TextAlignment.CENTER);

        Div div = new Div()
            .SetWidth(UnitValue.CreatePercentValue(100))
            .SetTextAlignment(TextAlignment.LEFT)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);

        Image img2 = new Image(iText.IO.Image.ImageDataFactory.Create(imageFileName));
        img2.SetWidth(UnitValue.CreatePercentValue(40));
        img2.SetMarginRight(10f);
        div.Add(img2);

        text = new Paragraph("Price: $9.99 (div)")
            .SetVerticalAlignment(VerticalAlignment.MIDDLE);
        div.Add(text);

        imageAndTextCell.Add(div);
        table.AddCell(imageAndTextCell);

        table.AddCell("3");
        table.AddCell("Widget");

        Image img3 = new Image(ImageDataFactory.Create(imageFileName));
        img3.SetWidth(40);  // Adjust width
        img3.SetHeight(40); // Adjust height

        // Create a paragraph to hold image and text side by side
        Paragraph paragraph = new Paragraph()
            .Add(img3) // Image on the left
            .Add(" Text aligned to the right of the image. (paragraph)") // Text on the right
            .SetTextAlignment(TextAlignment.LEFT); // Align content

        // Add the paragraph inside a table cell
        cell = new Cell().Add(paragraph);
        table.AddCell(cell);

        table.AddCell("4");
        table.AddCell("Widget");

        // Cell with image on top, text below, both centered vertically
        imageAndTextCell = new Cell()
            .SetVerticalAlignment(VerticalAlignment.MIDDLE) // Center contents vertically
            .SetTextAlignment(TextAlignment.CENTER);        // Center contents horizontally

        // Add image
        Image img4 = new Image(iText.IO.Image.ImageDataFactory.Create(imageFileName));
        img4.SetWidth(UnitValue.CreatePercentValue(80)); // Scale to 80% of cell width
        imageAndTextCell.Add(img4);

        // Add text below image
        text = new Paragraph("Price: $9.99 (cell)")
            .SetMarginTop(5f); // Gap between image and text
        imageAndTextCell.Add(text);

        table.AddCell(imageAndTextCell);

        doc.Add(table);
    }

    doc.Close();
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e);
}
