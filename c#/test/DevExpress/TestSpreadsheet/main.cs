// http://documentation.devexpress.com/#DocumentServer/CustomDocument15072

#define TEST_WRITE
#define TEST_WRITE_ARRAY
#define TEST_WRITE_IENUMERABLE
#define TEST_WRITE_DATA_TABLE
#define TEST_WRITE_XP_COLLECTION
#define TEST_READ

using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Xpo;
using DevExpress.Spreadsheet;

namespace TestSpreadsheet
{
    #if TEST_WRITE_XP_COLLECTION
        class TmpClass : XPObject
        {
            public long Id { get; set; }
            public byte FByte { get; set; }
            public short FShort { get; set; }
            public int FInt { get; set; }
            public long FLong { get; set; }
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            Workbook
                workbook;

            Worksheet
                worksheet;

            Cell
                cell;
            
            #if TEST_WRITE
                workbook = new Workbook();
                worksheet = workbook.Worksheets[0];
                worksheet.Name = "Direct Access";
                cell = worksheet.Cells["A1"];
                cell.Value = 1;
                worksheet.Range["A2:A10"].Formula = "=SUM(A1+1)";
                worksheet.Range["B1:B10"].Formula = "=A1+2";
                worksheet.Range["C1:C10"].ArrayFormula = "=A1:A10*B1:B10";
                cell = worksheet.Cells["D1"];
                cell.NumberFormat = "dd.mm.yyyy";
                cell.Value = DateTime.Now;

                #if TEST_WRITE_ARRAY
                    string[]
                        array = new string[] { "AAA", "BBB", "CCC", "DDD" };

                    if (workbook.Worksheets.Count == 1)
                        workbook.Worksheets.Add();

                    worksheet = workbook.Worksheets[1];
                    worksheet.Name = "Array";
                    worksheet.Import(array, 1, 0, true);
                    worksheet.Import(array, 0, 1, false);

                    string[,]
                        names = new String[2, 4]{
                            {"Ann", "Edward", "Angela", "Alex"},
                            {"Rachel", "Bruce", "Barbara", "George"}
                        };

                    worksheet.Import(names, 1, 1);
                #endif

                #if TEST_WRITE_IENUMERABLE
                    List<string>
                        cities = new List<string>() { "New York", "Rome", "Beijing", "Delhi" };

                    if (workbook.Worksheets.Count == 2)
                        workbook.Worksheets.Add();

                    worksheet = workbook.Worksheets[2];
                    worksheet.Name = "IEnumerable";
                    worksheet.Import(cities, 0, 0, true);
                #endif

                #if TEST_WRITE_DATA_TABLE
                    DataTable
                        tmpDataTable = new DataTable("tmpDataTable");

                    DataColumn
                        tmpDataColumn;

                    DataRow
                        tmpDataRow;

                    tmpDataColumn = tmpDataTable.Columns.Add("id", typeof(int));
                    tmpDataColumn.AllowDBNull = false;
                    tmpDataColumn.Unique = true;
                    tmpDataColumn.AutoIncrement = true;
                    tmpDataColumn.AutoIncrementSeed = -1;
                    tmpDataColumn.AutoIncrementStep = -1;
                    tmpDataTable.Columns.Add("fByte", typeof(byte));
                    tmpDataTable.Columns.Add("fShort", typeof(short));
                    tmpDataTable.Columns.Add("fInt", typeof(int));
                    tmpDataTable.Columns.Add("fLong", typeof(long));
                    tmpDataTable.Columns.Add("fFloat", typeof(float));
                    tmpDataTable.Columns.Add("fDouble", typeof(double));
                    tmpDataTable.Columns.Add("fDecimal", typeof(decimal));
                    tmpDataTable.Columns.Add("fDateTime", typeof(DateTime));
                    tmpDataTable.Columns.Add("fTimeSpan", typeof(TimeSpan));
                    tmpDataTable.Columns.Add("fDateTimeOffset", typeof(DateTimeOffset));
                    tmpDataTable.Columns.Add("fBool", typeof(bool));
                    tmpDataTable.Columns.Add("fChar", typeof(char));
                    tmpDataTable.Columns.Add("fString", typeof(string));
                    tmpDataTable.Columns.Add("fGuid", typeof(Guid));
                    tmpDataTable.Columns.Add("fNull", typeof(string));
                    tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["id"] };

                    tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["fByte"] = 255;
                    tmpDataRow["fShort"] = 1;
                    tmpDataRow["fInt"] = 11;
                    tmpDataRow["fLong"] = 111;
                    tmpDataRow["fFloat"] = 1.1;
                    tmpDataRow["fDouble"] = 11.11;
                    tmpDataRow["fDecimal"] = 111.111;
                    tmpDataRow["fDateTime"] = DateTime.Now;
                    tmpDataRow["fDateTimeOffset"] = DateTimeOffset.Now;
                    tmpDataRow["fTimeSpan"] = DateTime.Now.Date - new DateTime(2013, 1, 5);
                    tmpDataRow["fBool"] = true;
                    tmpDataRow["fChar"] = 'я';
                    tmpDataRow["fString"] = "string строка ёъяЁЪЯ іїєІЇЄ";
                    tmpDataRow["fGuid"] = Guid.NewGuid();
                    tmpDataRow["fNull"] = DBNull.Value;
                    tmpDataTable.Rows.Add(tmpDataRow);

                    tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["fByte"] = 0;
                    tmpDataRow["fShort"] = 1;
                    tmpDataRow["fInt"] = 11;
                    tmpDataRow["fLong"] = 111;
                    tmpDataRow["fFloat"] = 1.1;
                    tmpDataRow["fDouble"] = 11.11;
                    tmpDataRow["fDecimal"] = 111.111;
                    tmpDataRow["fDateTime"] = DateTime.Now;
                    tmpDataRow["fDateTimeOffset"] = DateTimeOffset.Now;
                    tmpDataRow["fTimeSpan"] = DateTime.Now.Date - new DateTime(2013, 1, 5);
                    tmpDataRow["fBool"] = false;
                    tmpDataRow["fChar"] = '\x41';
                    tmpDataRow["fString"] = "string строка ёъяЁЪЯ іїєІЇЄ";
                    tmpDataRow["fGuid"] = Guid.NewGuid();
                    tmpDataRow["fNull"] = DBNull.Value;
                    tmpDataTable.Rows.Add(tmpDataRow);

                    worksheet = workbook.Worksheets.Add();
                    worksheet.Name = "DataTable";
                    worksheet.Import(tmpDataTable, true, 0, 0);
                #endif

                #if TEST_WRITE_XP_COLLECTION
                    XPCollection<TmpClass>
                        tmpCollection = new XPCollection<TmpClass>
                                            {
                                                new TmpClass { Id = 1, FByte = 255, FShort = 1, FInt = 11, FLong = 111 },
                                                new TmpClass { Id = 2, FByte = 0, FShort = 1, FInt = 11, FLong = 111 }
                                            };

                    Console.WriteLine(string.Format("Count = {0}", tmpCollection.Count));
                    foreach(TmpClass tmpClass in tmpCollection)
                    {
                        Console.WriteLine(tmpClass.Id);
                    }

                    worksheet = workbook.Worksheets.Add();
                    worksheet.Name = "XPCollection";
                    worksheet.Import(tmpCollection, 0, 0, false);
                #endif

                workbook.SaveDocument("Test.xlsx", DocumentFormat.OpenXml);
                worksheet.PrintOptions.PrintGridlines = true;
                workbook.ExportToPdf("TestDoc.pdf");
            #endif

            #if TEST_READ
                workbook = new Workbook();
                workbook.LoadDocument("Test.xlsx", DocumentFormat.OpenXml);
                worksheet = workbook.Worksheets[0];
                cell = worksheet.Cells["A1"];
                cell = worksheet.Cells["D1"];
            #endif
        }
    }
}
