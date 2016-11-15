//#define TEST_MULTI_LINE
//#define TEST_DATE
//#define TEST_SCREEN_UPDATING
//#define CREATE_CHART
//#define TEST_CHART
//#define LOCATION_B4
//#define TEST_SAVE_AS

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExcelLate
{
    class ExcelLate
    {
        static void Main(string[] args)
        {
            object
                Excel = null,
                Workbooks = null,
                Workbook1 = null,
                Workbook2 = null,
                Sheets = null,
                Sheet1 = null,
                Sheet2 = null,
                PageSetup = null,
                Range1 = null,
                Range2 = null,
                Cells = null,
                Charts = null,
                Chart = null,
                Series = null,
                Seria = null,
                ChartObjects = null,
                tmpObject;
            try
            {
                try
                {
                    string
                        ExcelIDStr = "Excel.Application",
                        CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                    CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));

                    string
                        InputFileName = CurrentDirectory + "test.xls",
                        OutputDbf = CurrentDirectory + "xls2dbf.dbf";

                    try
                    {
                        Excel = Marshal.GetActiveObject(ExcelIDStr);
                    }
                    catch (COMException eException)
                    {
                        if (eException.ErrorCode == -2147221021)
                        {
                            Type
                                ExcelType = Type.GetTypeFromProgID(ExcelIDStr);

                            Excel = Activator.CreateInstance(ExcelType);
                        }
                        else
                            throw;
                    }

                    IntPtr
                        ptr = Marshal.GetIDispatchForObject(Excel);

                    object
                        wObj2 = Marshal.GetObjectForIUnknown(ptr);

                    foreach (MethodInfo methodInfo in wObj2.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                        Console.WriteLine(methodInfo.Name);

                    foreach (PropertyInfo propertyInfo in wObj2.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                        Console.WriteLine(propertyInfo.Name);

                    foreach (FieldInfo fieldInfo in wObj2.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                        Console.WriteLine(fieldInfo.Name);

                    foreach (MethodInfo methodInfo in Excel.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                        Console.WriteLine(methodInfo.Name);

                    foreach (PropertyInfo propertyInfo in Excel.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                        Console.WriteLine(propertyInfo.Name);

                    foreach (FieldInfo fieldInfo in Excel.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                        Console.WriteLine(fieldInfo.Name);

                    Excel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, Excel, new object[] { true });
                    Excel.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, Excel, new object[] { false });
                    Excel.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, Excel, new object[] { false });
                    
                    int
                        SheetsInNewWorkbook = Convert.ToInt32(Excel.GetType().InvokeMember("SheetsInNewWorkbook", BindingFlags.GetProperty, null, Excel, null));

                    if (SheetsInNewWorkbook != 3)
                        Excel.GetType().InvokeMember("SheetsInNewWorkbook", BindingFlags.SetProperty, null, Excel, new object[] { 3 });
                    
                    Workbooks = Excel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, Excel, null);

                    #if TEST_MULTI_LINE
                        Workbook1 = Workbooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, Workbooks, null);
                        Sheet1 = Workbook1.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, Workbook1, null);
                        Range1 = Sheet1.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, Sheet1, new object[] { "A" });
                        Range1.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range1, new object[] { 3 });
                        Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "A1" });
                        Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { "Line1\nLine2" });
                        tmpObject = Range1.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range1, null);
                        Workbook1.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, Workbook1, null);
                    #endif

                    #if TEST_CHART
                        InputFileName = CurrentDirectory + "xls_with_chart.xls";
                        /*Workbook1 = */ Workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, Workbooks, new object[] { InputFileName });
                        Workbook1 = Workbooks.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, Workbooks, new object[] { 1 });
                        Sheets = Workbook1.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, Workbook1, null);
                        Sheet1 = Sheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, Sheets, new object[] { 1 });
                        ChartObjects = Sheet1.GetType().InvokeMember("ChartObjects", BindingFlags.GetProperty, null, Sheet1, null);
                        tmpObject = ChartObjects.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, ChartObjects, null);
                        Chart = ChartObjects.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, ChartObjects, new object[] { 1 });
                        Chart.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, Chart, null);
                        Workbook1.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, Workbook1, null);
                    #endif

                    #if TEST_DATE
                        Workbook1 = Excel.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, Workbooks, null);
                        Sheet1 = Workbook1.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, Workbook1, null);
                        Range1 = Sheet1.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, Sheet1, new object[] { "A" });
                        Range1.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range1, new object[] { 3 });
                        Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "A1" });
                        Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { "01.01.2001" });
                        tmpObject = Range1.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range1, null);
                        Workbook1.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, Workbook1, null);
                    #endif

                    Workbook1 = Excel.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, Workbooks, null);

                    int
                        tmpInt;

                    string
                        tmpString;

                    #if TEST_SCREEN_UPDATING
						Sheets=Workbook1.GetType().InvokeMember("Sheets",BindingFlags.GetProperty,null,Workbook1,null);
						Sheet1=Sheets.GetType().InvokeMember("Item",BindingFlags.GetProperty,null,Sheets,new object[]{2});
						Sheet1.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Sheet1,new object[]{"ScreenUpdating=false"});
						Sheet1.GetType().InvokeMember("Activate",BindingFlags.InvokeMethod,null,Sheet1,null);

						object[,]
							tmpObjects=new object[24,12];

						for(int row=0; row<24; ++row)
							for(char col='A'; col<'M'; ++col)
								tmpObjects[row,(col-'A')]=new string(new char[]{col})+(row+1);

						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A1","L24"});

						DateTime
							start=DateTime.Now;

						Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{tmpObjects});

						DateTime
							stop=DateTime.Now;

						TimeSpan
							diff=stop-start;

						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A25"});
						Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{diff.ToString()});

						Excel.GetType().InvokeMember("Interactive",BindingFlags.SetProperty,null,Excel,new object[]{false});
						Excel.GetType().InvokeMember("ScreenUpdating",BindingFlags.SetProperty,null,Excel,new object[]{false});
						//Excel.GetType().InvokeMember("Visible",BindingFlags.SetProperty,null,Excel,new object[]{false});
						start=DateTime.Now;
						for(int row=0; row<24; ++row)
							for(char col='A'; col<'M'; ++col)
							{
								tmpString=new string(new char[]{col})+(row+1);
								Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{tmpString});
								Range1.GetType().InvokeMember("BorderAround",BindingFlags.InvokeMethod,null,Range1,new object[]{1,3});
							}
						stop=DateTime.Now;
						diff=stop-start;
						Excel.GetType().InvokeMember("Interactive",BindingFlags.SetProperty,null,Excel,new object[]{true});
						Excel.GetType().InvokeMember("ScreenUpdating",BindingFlags.SetProperty,null,Excel,new object[]{true});
						//Excel.GetType().InvokeMember("Visible",BindingFlags.SetProperty,null,Excel,new object[]{true});
						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A26"});
						Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{diff.ToString()});

						Sheet1=Sheets.GetType().InvokeMember("Item",BindingFlags.GetProperty,null,Sheets,new object[]{3});
						Sheet1.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Sheet1,new object[]{"ScreenUpdating=true"});
						Sheet1.GetType().InvokeMember("Activate",BindingFlags.InvokeMethod,null,Sheet1,null);

						start=DateTime.Now;
						for(int row=0; row<24; ++row)
							for(char col='A'; col<'M'; ++col)
							{
								tmpString=new string(new char[]{col})+(row+1);
								Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{tmpString});
								Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{tmpString});
							}
						stop=DateTime.Now;
						diff=stop-start;
						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A25"});
						Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{diff.ToString()});

						start=DateTime.Now;
						for(int row=0; row<24; ++row)
							for(char col='A'; col<'M'; ++col)
							{
								tmpString=new string(new char[]{col})+(row+1);
								Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{tmpString});
								Range1.GetType().InvokeMember("BorderAround",BindingFlags.InvokeMethod,null,Range1,new object[]{1,3});
							}
						stop=DateTime.Now;
						diff=stop-start;
						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A26"});
						Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{diff.ToString()});
						Range1.GetType().InvokeMember("BorderAround",BindingFlags.InvokeMethod,null,Range1,new object[]{1,3});
						Range2=Range1.GetType().InvokeMember("Columns",BindingFlags.GetProperty,null,Range1,null);
						Range2.GetType().InvokeMember("AutoFit",BindingFlags.InvokeMethod,null,Range2,null);

						Range2=Range1.GetType().InvokeMember("Borders",BindingFlags.GetProperty,null,Range1,new object[]{9 /* xlEdgeBottom */});
						Range2.GetType().InvokeMember("Color",BindingFlags.SetProperty,null,Range2,new object[]{255});
						Range2.GetType().InvokeMember("Weight",BindingFlags.SetProperty,null,Range2,new object[]{1 /* xlHairline */});

						Range2=Range1.GetType().InvokeMember("Borders",BindingFlags.GetProperty,null,Range1,new object[]{7 /* xlEdgeLeft */});
						Range2.GetType().InvokeMember("Color",BindingFlags.SetProperty,null,Range2,new object[]{255});
						Range2.GetType().InvokeMember("Weight",BindingFlags.SetProperty,null,Range2,new object[]{2 /* xlThin */});

						Range2=Range1.GetType().InvokeMember("Borders",BindingFlags.GetProperty,null,Range1,new object[]{8 /* xlEdgeTop */});
						Range2.GetType().InvokeMember("Color",BindingFlags.SetProperty,null,Range2,new object[]{255});
						Range2.GetType().InvokeMember("Weight",BindingFlags.SetProperty,null,Range2,new object[]{-4138 /* (long)0xFFFFEFD6 */ /* xlMedium */});

						Range2=Range1.GetType().InvokeMember("Borders",BindingFlags.GetProperty,null,Range1,new object[]{10 /* xlEdgeRight */});
						Range2.GetType().InvokeMember("Color",BindingFlags.SetProperty,null,Range2,new object[]{255});
						Range2.GetType().InvokeMember("Weight",BindingFlags.SetProperty,null,Range2,new object[]{4 /* xlThick */});

						Sheet1=Sheets.GetType().InvokeMember("Item",BindingFlags.GetProperty,null,Sheets,new object[]{1});
						Sheet1.GetType().InvokeMember("Activate",BindingFlags.InvokeMethod,null,Sheet1,null);
                    #endif

                    #if CREATE_CHART
						Sheets=Workbook1.GetType().InvokeMember("Sheets",BindingFlags.GetProperty,null,Workbook1,null);
						Sheet1=Workbook1.GetType().InvokeMember("ActiveSheet",BindingFlags.GetProperty,null,Workbook1,null);

						for(int i=1; i<=20; ++i)
						{
							Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"A"+i});
							Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{i});

							Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"B"+i});
							Range1.GetType().InvokeMember("Formula",BindingFlags.SetProperty,null,Range1,new object[]{"=SIN(A"+i+")"});

							Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"C"+i});
							Range1.GetType().InvokeMember("Formula",BindingFlags.SetProperty,null,Range1,new object[]{"=COS(A"+i+")"});

							Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"D"+i});
							Range1.GetType().InvokeMember("Formula",BindingFlags.SetProperty,null,Range1,new object[]{"=B"+i+"+C"+i});
						}

						Charts=Excel.GetType().InvokeMember("Charts",BindingFlags.GetProperty,null,Excel,null);
						Chart=Charts.GetType().InvokeMember("Add",BindingFlags.InvokeMethod,null,Charts,null);
						//Chart.GetType().InvokeMember("ChartType",BindingFlags.SetProperty,null,Chart,new object[]{65 /*xlLineMarkers*/});
						Chart.GetType().InvokeMember("ChartType",BindingFlags.SetProperty,null,Chart,new object[]{4 /*xlLine*/});

						Cells=Sheet1.GetType().InvokeMember("Cells",BindingFlags.GetProperty,null,Sheet1,null);
						Range1=Cells.GetType().InvokeMember("SpecialCells",BindingFlags.GetProperty,null,Cells,new object[]{11 /*xlCellTypeLastCell*/});
						tmpInt=Convert.ToInt32(Range1.GetType().InvokeMember("Column",BindingFlags.GetProperty,null,Range1,null));
						tmpString=new string((char)('A'+tmpInt-1-1 /* last -1 especially 4 'C' */),1);
						tmpInt=Convert.ToInt32(Range1.GetType().InvokeMember("Row",BindingFlags.GetProperty,null,Range1,null));
						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"B1:"+tmpString+tmpInt});
						Chart.GetType().InvokeMember("SetSourceData",BindingFlags.InvokeMethod,null,Chart,new object[]{Range1, 2 /*xlColumns*/});

                        #if LOCATION_B4
							Chart.GetType().InvokeMember("Location",BindingFlags.InvokeMethod,null,Chart,new object[]{2 /*xlLocationAsObject*/,"Лист1"});

							ChartObjects=Sheet1.GetType().InvokeMember("ChartObjects",BindingFlags.GetProperty,null,Sheet1,null);
							Chart=ChartObjects.GetType().InvokeMember("Item",BindingFlags.GetProperty,null,ChartObjects,new object[]{1});
							Chart=Chart.GetType().InvokeMember("Chart",BindingFlags.GetProperty,null,Chart,null);
                        #endif

						Series=Chart.GetType().InvokeMember("SeriesCollection",BindingFlags.InvokeMethod,null,Chart,null);
						//Series=Chart.GetType().InvokeMember("SeriesCollection",BindingFlags.GetProperty,null,Chart,null);

						Seria=Series.GetType().InvokeMember("NewSeries",BindingFlags.InvokeMethod,null,Series,null);
						tmpInt=Convert.ToInt32(Series.GetType().InvokeMember("Count",BindingFlags.GetProperty,null,Series,null));

						for(int i=tmpInt; i>0; --i)
						{
							Range2=Chart.GetType().InvokeMember("SeriesCollection",BindingFlags.GetProperty,null,Chart,new object[]{i});
							Range2.GetType().InvokeMember("XValues",BindingFlags.SetProperty,null,Range2,new object[]{Range1});
							switch(i)
							{
								case 1 :
								{
									Range2.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Range2,new object[]{"sin"});
									break;	
								}
								case 2 :
								{
									Range2.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Range2,new object[]{"cos"});
									break;	
								}
							}
						}

						Range1=Sheet1.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,Sheet1,new object[]{"D1:D20"});
						Seria.GetType().InvokeMember("Values",BindingFlags.SetProperty,null,Seria,new object[]{Range1});
						Seria.GetType().InvokeMember("Name",BindingFlags.SetProperty,null,Seria,new object[]{"sin+cos"});
                        #if !LOCATION_B4
							Chart.GetType().InvokeMember("Location",BindingFlags.InvokeMethod,null,Chart,new object[]{2 /*xlLocationAsObject*/,"Лист1"});
                        #endif
                    #endif

                    Workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, Workbooks, new object[] { InputFileName });
                    Workbook2 = Excel.GetType().InvokeMember("ActiveWorkbook", BindingFlags.GetProperty, null, Excel, null);

                    #if TEST_SAVE_AS
						if(File.Exists(OutputDbf))
							File.Delete(OutputDbf);
						Workbook2.GetType().InvokeMember("SaveAs",BindingFlags.InvokeMethod,null,Workbook2,new object[]{OutputDbf,11 /* xlDBF4 *//*,Type.Missing,Type.Missing,Type.Missing,Type.Missing,1 xlNoChange,Type.Missing,Type.Missing,Type.Missing,Type.Missing*/});
                    #endif

                    Sheets = Workbook2.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, Workbook2, null);
                    tmpInt = Convert.ToInt32(Sheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, Sheets, null));
                    Sheets.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, Sheets, null);
                    tmpInt = Convert.ToInt32(Sheets.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, Sheets, null));
                    Sheet1 = Workbook1.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, Workbook1, null);

                    PageSetup = Sheet1.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, null, Sheet1, null);
                    PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, PageSetup, new object[] { 2 });

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "A1" });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { "Some Value" });

                    tmpObject = Range1.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range1, null);
                    tmpString = Convert.ToString(tmpObject);

                    Range1.GetType().InvokeMember("Copy", BindingFlags.InvokeMethod, null, Range1, null);
                    Range2 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "A10" });
                    Sheet1.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, Sheet1, new object[] { Range2 });
                    Range2 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "A11" });
                    Workbook1.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, Workbook1, null);
                    Range2.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, Range2, null);
                    Sheet1.GetType().InvokeMember("Paste", BindingFlags.InvokeMethod, null, Sheet1, null);

                    object[,]
                        values = { { 11, 12 }, { 21, 22 }, { 31, 32 } };

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "F1", "G3" });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { values });

                    object[,]
                        values_out;

                    values_out = (object[,])Range1.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range1, null);

                    Cells = Sheet1.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, Sheet1, null);
                    Range1 = Cells.GetType().InvokeMember("SpecialCells", BindingFlags.GetProperty, null, Cells, new object[] { 11 });
                    tmpInt = Convert.ToInt32(Range1.GetType().InvokeMember("Column", BindingFlags.GetProperty, null, Range1, null));
                    tmpInt = Convert.ToInt32(Range1.GetType().InvokeMember("Row", BindingFlags.GetProperty, null, Range1, null));

                    Range1 = Sheet1.GetType().InvokeMember("Cells", BindingFlags.GetProperty, null, Sheet1, new object[] { 10, 10 });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { "[10,10]" });
                    Range2 = Range1.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Range1, null);
                    Range2.GetType().InvokeMember("Bold", BindingFlags.SetProperty, null, Range2, new object[] { true });
                    Range2.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Range2, new object[] { 25 });

                    for (int _i = 1; _i <= 10; ++_i)
                    {
                        Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B" + _i });
                        Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { _i });
                    }
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "C5" });
                    Range1.GetType().InvokeMember("FormulaR1C1", BindingFlags.SetProperty, null, Range1, new object[] { "=СУММ(R[-4]C[-1]:RC[-1])" });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B11" });
                    Range1.GetType().InvokeMember("Formula", BindingFlags.SetProperty, null, Range1, new object[] { "=СУММ(B1:B10)" });
                    Range1.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, Range1, new object[] { 30 });
                    Range2 = Range1.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Range1, null);
                    Range2.GetType().InvokeMember("Bold", BindingFlags.SetProperty, null, Range2, new object[] { true });
                    Range2.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Range2, new object[] { 25 });

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B2" });
                    Range2 = Range1.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, Range1, null);
                    Range2.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, Range2, null);

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B2" });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 999 });

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B5" });
                    Range2 = Range1.GetType().InvokeMember("Rows", BindingFlags.GetProperty, null, Range1, null);
                    //tmpLong=unchecked((long)0xFFFFFFFFFFFFEFD6L);
                    Range2.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, Range2, new object[] { -4121 /* 0xFFFFEFE7 == xlShiftDown */});

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "B1", "B10" });
                    values = (object[,])Range1.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, Range1, null);

                    int
                        MaxI = values.GetLength(0), // Row
                        MaxJ = values.GetLength(1); // Col

                    tmpString = string.Empty;
                    for (int i = 1; i <= MaxI; ++i) // Row
                    {
                        for (int j = 1; j <= MaxJ; ++j) // Col
                        {
                            tmpString += "[" + i + "," + j + "]=" + (values[i, j] != null ? values[i, j] : "null");
                            if (j <= MaxJ - 1)
                                tmpString += "\t";
                        }
                        tmpString += Environment.NewLine;
                    }

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { "H1", "I2" });
                    Range1.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod, null, Range1, null);

                    string
                        CellDirect,
                        CellObject;

                    #region bool
                    CellDirect = "E1";
                    CellObject = "E2";
                    tmpString = "bool";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F1";
                    CellObject = "F2";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { true });

                    bool
                        tmpBool = true;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpBool });
                    #endregion

                    #region byte
                    CellDirect = "E3";
                    CellObject = "E4";
                    tmpString = "byte";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F3";
                    CellObject = "F4";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 255 });

                    byte
                        tmpByte = 255;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpByte });
                    #endregion

                    #region sbyte
                    CellDirect = "E5";
                    CellObject = "E6";
                    tmpString = "sbyte";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F5";
                    CellObject = "F6";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 127 });

                    sbyte
                        tmpSByte = 127;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (int)tmpSByte });
                    #endregion

                    #region short
                    CellDirect = "E7";
                    CellObject = "E8";
                    tmpString = "short";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F7";
                    CellObject = "F8";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 32767 });

                    short
                        tmpShort = 32767;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpShort });
                    #endregion

                    #region ushort
                    CellDirect = "E9";
                    CellObject = "E10";
                    tmpString = "ushort";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F9";
                    CellObject = "F10";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 65535 });

                    ushort
                        tmpUShort = 65535;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (int)tmpUShort });
                    #endregion

                    #region int
                    CellDirect = "E11";
                    CellObject = "E12";
                    tmpString = "int";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F11";
                    CellObject = "F12";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 2147483647 });
                    tmpInt = 2147483647;
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpInt });
                    #endregion

                    #region uint
                    CellDirect = "E13";
                    CellObject = "E14";
                    tmpString = "uint";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F13";
                    CellObject = "F14";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)4294967295U });

                    uint
                        tmpUInt = 4294967295U;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)tmpUInt });
                    #endregion

                    #region long
                    CellDirect = "E15";
                    CellObject = "E16";
                    tmpString = "long";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F15";
                    CellObject = "F16";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)999999999999999L });
                    //Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{9223372036854775807L});

                    long
                        tmpLong = 999999999999999L; //9223372036854775807L;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)tmpLong });
                    #endregion

                    #region ulong
                    CellDirect = "E17";
                    CellObject = "E18";
                    tmpString = "ulong";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F17";
                    CellObject = "F18";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    //Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{18446744073709551615UL});

                    ulong
                        tmpULong = 18446744073709551615UL;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    //Range1.GetType().InvokeMember("Value",BindingFlags.SetProperty,null,Range1,new object[]{tmpULong});
                    #endregion

                    #region DateTime
                    CellDirect = "E19";
                    CellObject = "E20";
                    tmpString = "DateTime";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F19";
                    CellObject = "F20";
                    tmpString = "ДД.ММ.ГГ";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { DateTime.Now });
                    Range1.GetType().InvokeMember("NumberFormat", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    DateTime
                        tmpDateTime = DateTime.Now;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpDateTime });
                    Range1.GetType().InvokeMember("NumberFormat", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    #endregion

                    #region TimeSpan
                    CellDirect = "E21";
                    CellObject = "E22";
                    tmpString = "TimeSpan";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F21";
                    CellObject = "F22";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    tmpDateTime = new DateTime(0L);
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpDateTime + (new TimeSpan(1, 2, 3)) });

                    TimeSpan
                        tmpTimeSpan = new TimeSpan(1, 2, 3);

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    tmpDateTime = new DateTime(0L);
                    tmpDateTime += tmpTimeSpan;
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpDateTime });
                    #endregion

                    #region float
                    CellDirect = "E23";
                    CellObject = "E24";
                    tmpString = "float";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F23";
                    CellObject = "F24";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 9999.9999F });

                    float
                        tmpFloat = 9999.9999F;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpFloat });
                    #endregion

                    #region double
                    CellDirect = "E25";
                    CellObject = "E26";
                    tmpString = "double";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F25";
                    CellObject = "F26";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 1.7E+3 });

                    double
                        tmpDouble = 1.7E+3;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpDouble });
                    #endregion

                    #region decimal
                    CellDirect = "E27";
                    CellObject = "E28";
                    tmpString = "decimal";

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    CellDirect = "F27";
                    CellObject = "F28";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)999999999.99m });

                    decimal
                        tmpDecimal = 999999999.99m;

                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellObject });
                    // !!!
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { (double)tmpDecimal });
                    #endregion

                    CellDirect = "F29";
                    //tmpString="#,##0.00р.;-#,##0.00р.";
                    tmpString = "# ##0,00р.;-# ##0,00р.";
                    Range1 = Sheet1.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, Sheet1, new object[] { CellDirect });
                    Range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range1, new object[] { 123.45 });
                    Range1.GetType().InvokeMember("NumberFormat", BindingFlags.SetProperty, null, Range1, new object[] { tmpString });

                    Sheets = Workbook1.GetType().InvokeMember("Sheets", BindingFlags.GetProperty, null, Workbook1, null);
                    Sheet1 = Sheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, Sheets, new object[] { "Лист1" });
                    Sheet2 = Sheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, Sheets, new object[] { "Лист3" });
                    Sheet1.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, Sheet1, new object[] { Type.Missing, Sheet2 });

                    Workbook2.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, Workbook2, new object[] { CurrentDirectory + "test_out.xls" });
                    Workbook2.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, Workbook2, null);

                    Workbook1.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, Workbook1, new object[] { CurrentDirectory + "out_add.xls" });
                    Workbook1.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, Workbook1, null);
                }
                catch (COMException eException)
                {
                    string
                        tmp = eException.Message;

                    Console.WriteLine(tmp);
                }
                catch (TargetInvocationException eException)
                {
                    string
                        tmp = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace;

                    Console.WriteLine(tmp);
                }
                catch (Exception eException)
                {
                    string
                        tmp = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace;

                    Console.WriteLine(tmp);
                }
            }
            finally
            {
                if (ChartObjects != null)
                {
                    Marshal.ReleaseComObject(ChartObjects);
                    ChartObjects = null;
                }
                if (Seria != null)
                {
                    Marshal.ReleaseComObject(Seria);
                    Seria = null;
                }
                if (Series != null)
                {
                    Marshal.ReleaseComObject(Series);
                    Series = null;
                }
                if (Chart != null)
                {
                    Marshal.ReleaseComObject(Chart);
                    Chart = null;
                }
                if (Charts != null)
                {
                    Marshal.ReleaseComObject(Charts);
                    Charts = null;
                }
                if (Cells != null)
                {
                    Marshal.ReleaseComObject(Cells);
                    Cells = null;
                }
                if (Range1 != null)
                {
                    Marshal.ReleaseComObject(Range1);
                    Range1 = null;
                }
                if (Range2 != null)
                {
                    Marshal.ReleaseComObject(Range2);
                    Range2 = null;
                }
                if (PageSetup != null)
                {
                    Marshal.ReleaseComObject(PageSetup);
                    PageSetup = null;
                }
                if (Sheet2 != null)
                {
                    Marshal.ReleaseComObject(Sheet1);
                    Sheet1 = null;
                }
                if (Sheet1 != null)
                {
                    Marshal.ReleaseComObject(Sheet1);
                    Sheet1 = null;
                }
                if (Sheets != null)
                {
                    Marshal.ReleaseComObject(Sheets);
                    Sheets = null;
                }
                if (Workbook1 != null)
                {
                    Marshal.ReleaseComObject(Workbook1);
                    Workbook1 = null;
                }
                if (Workbook2 != null)
                {
                    Marshal.ReleaseComObject(Workbook2);
                    Workbook2 = null;
                }
                if (Workbooks != null)
                {
                    Marshal.ReleaseComObject(Workbooks);
                    Workbooks = null;
                }
                if (Excel != null)
                {
                    Excel.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, Excel, null);
                    Marshal.ReleaseComObject(Excel);
                    Excel = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
                //GC.SuppressFinalize(this);
            }
        }
    }
}