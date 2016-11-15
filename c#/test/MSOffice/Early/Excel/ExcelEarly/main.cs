//#define TEST_DATE
//#define TEST_SAVE_AS
//#define TEST_CHART

using System;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace ExcelEarly
{
	/// <summary>
	/// Summary description for ExcelEarly.
	/// </summary>
	class ExcelEarly
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			Application
				ExcelApp=null;

			Workbook
				Workbook=null;

			Sheets
				Sheets=null,
				Charts=null;

			Worksheet
				Sheet=null;

            Chart
				Chart=null;

            Series
				Series=null;

            Axes
				Axes=null;

            Axis
				Axis=null;

            Range
				Range=null,
				Range2=null;

			object
				tmpObject;

			try
			{
				try
				{
					string
						CurrentDirectory=System.IO.Directory.GetCurrentDirectory();

					CurrentDirectory=CurrentDirectory.Substring(0,CurrentDirectory.LastIndexOf("bin",CurrentDirectory.Length-1));

					string
						//InputFileName = CurrentDirectory + "test.xls",
                        InputFileName = "d:\\result.xlsx",
						OutputDbf=CurrentDirectory+"xls2dbf.dbf";

					try
					{
                        ExcelApp = (Application)Marshal.GetActiveObject("Excel.Application");
					}
					catch(COMException eException)
					{
						if(eException.ErrorCode==-2147221021)
                            ExcelApp = new Application();
					}
					
					ExcelApp.Visible=true;
					ExcelApp.DisplayAlerts=false;
					ExcelApp.UserControl=false;

					#if TEST_DATE
						Workbook=ExcelApp.Workbooks.Add(Type.Missing);
                        Sheet = (Worksheet)Workbook.ActiveSheet;
						Sheet.Columns.get_Range("A1","A1").ColumnWidth=3;
						Sheet.get_Range("A1",Type.Missing).Value="01.01.2001";
						tmpObject=Sheet.get_Range("A1",Type.Missing).Value;
						Workbook.Close(Type.Missing,Type.Missing,Type.Missing);
					#endif

					Workbook=ExcelApp.Workbooks.Open(InputFileName,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
					#if TEST_SAVE_AS
						if(File.Exists(OutputDbf))
							File.Delete(OutputDbf);
						Workbook.SaveAs(OutputDbf,XlFileFormat.xlDBF4,Type.Missing,Type.Missing,Type.Missing,Type.Missing,XlSaveAsAccessMode.xlNoChange,Type.Missing,Type.Missing,Type.Missing,Type.Missing);
					#endif
					Sheets=Workbook.Worksheets;
                    Sheet = (Worksheet)Workbook.ActiveSheet;

                    double
                        points = ExcelApp.CentimetersToPoints(1.93d);

                    points = ExcelApp.CentimetersToPoints(2.70d);
                    points = ExcelApp.CentimetersToPoints(3.55d);

					int
						MaxRow=Sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell,Type.Missing).Row,
						MaxCol=Sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell,Type.Missing).Column;

					Range=Sheet.get_Range("A1",Type.Missing);
					Range=Range.get_End(XlDirection.xlToRight);
					Range=Range.get_End(XlDirection.xlDown);

					string
						CurrAddress=Range.get_Address(false,false,XlReferenceStyle.xlA1,Type.Missing,Type.Missing);

					Range=Sheet.get_Range("A1",CurrAddress);

					CurrAddress=ColNoToName(MaxCol)+Convert.ToString(MaxRow);
					Range=Sheet.get_Range("A1",CurrAddress);

					object[,]
						values=(object[,])Range.Value2;

					int
						MaxI=values.GetLength(0), // Row
						MaxJ=values.GetLength(1); // Col

					string
						tmpString=string.Empty;

					for(int i=1; i<=MaxI; ++i) // Row
					{
						for(int j=1; j<=MaxJ; ++j) // Col
						{
							tmpString+="["+i+","+j+"]="+(values[i,j]!=null ? values[i,j] : "null");
							if(j<=MaxJ-1)
								tmpString+="\t";
						}
						tmpString+=Environment.NewLine;
					}
					Console.WriteLine(tmpString);
					
					Range=Sheet.get_Range("A10","E18");
					//Range.Formula=values;
					Range.Value=values;

					Range=Sheet.get_Range(Sheet.Cells[1,1],Sheet.Cells[10,10]);
                    tmpObject = ((Range)Range.get_Item(1, 1)).Value;

					Sheet.get_Range("A23",Type.Missing).Value="A23";
					tmpString=Convert.ToString(Sheet.get_Range("A23",Type.Missing).Value);
					Sheet.get_Range("A24","C24").Merge(true);

					for(int _i=1; _i<=10; ++_i)
						Sheet.get_Range("F"+_i,Type.Missing).Value=_i;
					Sheet.get_Range("F11",Type.Missing).Formula="=ÑÓÌÌ(F1:F10)";
					Sheet.get_Range("F11",Type.Missing).Orientation=30;
					Sheet.get_Range("F11",Type.Missing).Font.Bold=true;
					Sheet.get_Range("F11",Type.Missing).Font.Size=25;

					Range=Sheet.get_Range("F2",Type.Missing);

					tmpObject=-4121; // 0xFFFFEFE7; /* xlShiftDown */
					Range.Rows.Insert(tmpObject);

					Range.Rows.Insert(Type.Missing);
					Sheet.get_Range("F2",Type.Missing).Value=999;

                    Sheet = (Worksheet)Sheets.get_Item(2);
					Sheet.Activate();

					string
						CellDirect,
						CellObject;

					#region bool
					CellDirect="E1";
					CellObject="E2";
					tmpString="bool";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F1";
					CellObject="F2";
					Sheet.get_Range(CellDirect,Type.Missing).Value=true;

					bool
						tmpBool=true;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpBool;
					#endregion

					#region byte
					CellDirect="E3";
					CellObject="E4";
					tmpString="byte";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F3";
					CellObject="F4";
					Sheet.get_Range(CellDirect,Type.Missing).Value=255;

					byte
						tmpByte=255;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpByte;
					#endregion

					#region sbyte
					CellDirect="E5";
					CellObject="E6";
					tmpString="sbyte";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F5";
					CellObject="F6";
					Sheet.get_Range(CellDirect,Type.Missing).Value=127;

					sbyte
						tmpSByte=127;

					// !!!
					Sheet.get_Range(CellObject,Type.Missing).Value=(int)tmpSByte;
					#endregion

					#region short
					CellDirect="E7";
					CellObject="E8";
					tmpString="short";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F7";
					CellObject="F8";
					Sheet.get_Range(CellDirect,Type.Missing).Value=32767;

					short
						tmpShort=32767;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpShort;
					#endregion

					#region ushort
					CellDirect="E9";
					CellObject="E10";
					tmpString="ushort";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F9";
					CellObject="F10";
					Sheet.get_Range(CellDirect,Type.Missing).Value=65535;

					ushort
						tmpUShort=65535;

					// !!!
					Sheet.get_Range(CellObject,Type.Missing).Value=(int)tmpUShort;
					#endregion

					#region int
					CellDirect="E11";
					CellObject="E12";
					tmpString="int";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F11";
					CellObject="F12";
					Sheet.get_Range(CellDirect,Type.Missing).Value=2147483647;

					int
						tmpInt=2147483647;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpInt;
					#endregion

					#region uint
					CellDirect="E13";
					CellObject="E14";
					tmpString="uint";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F13";
					CellObject="F14";
                    // !!!
					Sheet.get_Range(CellDirect,Type.Missing).Value=(double)4294967295U;

					uint
						tmpUInt=4294967295U;

					// !!!
					Sheet.get_Range(CellObject,Type.Missing).Value=(double)tmpUInt;
					#endregion

					#region long
					CellDirect="E15";
					CellObject="E16";
					tmpString="long";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F15";
					CellObject="F16";
					Sheet.get_Range(CellDirect,Type.Missing).Value=(double)999999999999999L;
					//Sheet.get_Range(CellDirect,Type.Missing).Value=9223372036854775807L;

					long
						tmpLong=999999999999999L; //9223372036854775807L;

					Sheet.get_Range(CellObject,Type.Missing).Value=(double)tmpLong;
					#endregion

					#region ulong
					CellDirect="E17";
					CellObject="E18";
					tmpString="ulong";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F17";
					CellObject="F18";
					//Sheet.get_Range(CellDirect,Type.Missing).Value=18446744073709551615UL;

					ulong
						tmpULong=18446744073709551615UL;

					//Sheet.get_Range(CellObject,Type.Missing).Value=tmpULong;
					#endregion

					#region DateTime
					CellDirect="E19";
					CellObject="E20";
					tmpString="DateTime";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F19";
					CellObject="F20";
					Sheet.get_Range(CellDirect,Type.Missing).Value=DateTime.Now;

					DateTime
						tmpDateTime=DateTime.Now;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpDateTime;
					#endregion

					#region TimeSpan
					CellDirect="E21";
					CellObject="E22";
					tmpString="TimeSpan";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F21";
					CellObject="F22";
					tmpDateTime=new DateTime(0L);
					// !!!
					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpDateTime+(new TimeSpan(1,2,3));

					TimeSpan
						tmpTimeSpan=new TimeSpan(1,2,3);

					// !!!
					tmpDateTime=new DateTime(0L);
					tmpDateTime+=tmpTimeSpan;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpDateTime;
					#endregion

					#region float
					CellDirect="E23";
					CellObject="E24";
					tmpString="float";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F23";
					CellObject="F24";
					Sheet.get_Range(CellDirect,Type.Missing).Value=9999.9999F;

					float
						tmpFloat=9999.9999F;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpFloat;
					#endregion

					#region double
					CellDirect="E25";
					CellObject="E26";
					tmpString="double";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F25";
					CellObject="F26";
					Sheet.get_Range(CellDirect,Type.Missing).Value=1.7E+3;

					double
						tmpDouble=1.7E+3;

					Sheet.get_Range(CellObject,Type.Missing).Value=tmpDouble;
					#endregion

					#region decimal
					CellDirect="E27";
					CellObject="E28";
					tmpString="decimal";

					Sheet.get_Range(CellDirect,Type.Missing).Value=tmpString;
					Sheet.get_Range(CellObject,Type.Missing).Value=tmpString;

					CellDirect="F27";
					CellObject="F28";
					// !!!
					Sheet.get_Range(CellDirect,Type.Missing).Value=(double)999999999.99m;

					decimal
						tmpDecimal=999999999.99m;

					// !!!
					Sheet.get_Range(CellObject,Type.Missing).Value=(double)tmpDecimal;
					#endregion

                    Sheet = (Worksheet)Sheets.get_Item(3);
					
					Range=Sheet.get_Range("A1","A5");
					Range.Value="Some Value";
					Range2=Sheet.get_Range("A11","A15");
					Range.Copy(Range2);

					Range=Sheet.get_Range("B1","B5");
					Range.Value="Some Value";
					Range.Copy(Type.Missing);
					Range2=Sheet.get_Range("B11","B15");
					Sheet.Paste(Range2,Type.Missing);

					Range2=Sheet.get_Range("B20",Type.Missing);
					Sheet.Activate();
					Range2.Select();
					Sheet.Paste(Type.Missing,Type.Missing);
					

					#if TEST_CHART
					Sheet=(Excel.Worksheet)Sheets.get_Item(3);
					Sheet.Activate();

					for(int Col=1; Col<=20; ++Col)
					{
						Sheet.get_Range("A"+Col,Type.Missing).Value=Col;
						Sheet.get_Range("B"+Col,Type.Missing).Formula="=sin(A"+Col+")";
						Sheet.get_Range("C"+Col,Type.Missing).Formula="=cos(A"+Col+")";
						Sheet.get_Range("D"+Col,Type.Missing).Formula="=B"+Col+"+C"+Col;
					}

					Sheets.Add(Type.Missing,Type.Missing,Type.Missing,Type.Missing);
					Charts=ExcelApp.Charts;
					Chart=(Excel.Chart)Charts.Add(Type.Missing,Type.Missing,Type.Missing,Type.Missing);
					//Chart.Type=65; // xlLineMarkers
					Chart.Type=4; // xlLine
					Chart.SetSourceData(Sheet.get_Range("B1","C20"),2 /*xlColumns*/);
					Chart=Chart.Location(XlChartLocation.xlLocationAsObject,"Ëèñò4");
					Series=((Excel.SeriesCollection)Chart.SeriesCollection(Type.Missing)).NewSeries();
					MaxI=((Excel.SeriesCollection)Chart.SeriesCollection(Type.Missing)).Count;
					Range=Sheet.get_Range("A1","A20");
					for(int i=MaxI; i>0; --i)
					{
						((Excel.Series)Chart.SeriesCollection(i)).XValues=Range;
						switch(i)
						{
							case 1 :
							{
								((Excel.Series)Chart.SeriesCollection(i)).Name="sin";
								break;	
							}
							case 2 :
							{
								((Excel.Series)Chart.SeriesCollection(i)).Name="cos";
								break;	
							}
						}
					}
					
					Range=Sheet.get_Range("D1","D20");
					Series.Values=Range;
					Series.Name="sin+cos";

					Chart.HasTitle=true;
					Chart.ChartTitle.Caption="Name of Chart";
					Axis=(Excel.Axis)Chart.Axes(1 /*xlCategory*/,XlAxisGroup.xlPrimary);
					Axis.HasTitle=true;
					Axis.CategoryNames="Name of Category";
					Axis=(Excel.Axis)Chart.Axes(2 /*xlValue*/,XlAxisGroup.xlPrimary);
					Axis.HasTitle=true;

					Chart.HasLegend=true;
					Chart.Legend.Position=XlLegendPosition.xlLegendPositionBottom;
					#endif

					ExcelApp.Quit();
				}
				catch(COMException eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"ErrorCode: "+eException.ErrorCode+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
				catch(ArgumentException eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"ParamName: "+eException.ParamName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
				catch(Exception eException)
				{
					string
						tmp=eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace;

					Console.WriteLine(tmp);
				}
			}
			finally
			{
				if(Axes!=null)
				{
					Marshal.ReleaseComObject(Axes);
					Axes=null;
				}
				if(Axis!=null)
				{
					Marshal.ReleaseComObject(Axis);
					Axis=null;
				}
				if(Series!=null)
				{
					Marshal.ReleaseComObject(Series);
					Series=null;
				}
				if(Chart!=null)
				{
					Marshal.ReleaseComObject(Chart);
					Chart=null;
				}
				if(Charts!=null)
				{
					Marshal.ReleaseComObject(Charts);
					Charts=null;
				}
				if(Range2!=null)
				{
					Marshal.ReleaseComObject(Range2);
					Range2=null;
				}
				if(Range!=null)
				{
					Marshal.ReleaseComObject(Range);
					Range=null;
				}
				if(Sheets!=null)
				{
					Marshal.ReleaseComObject(Sheets);
					Sheets=null;
				}
				if(Sheet!=null)
				{
					Marshal.ReleaseComObject(Sheet);
					Sheet=null;
				}
				if(Workbook!=null)
				{
					Marshal.ReleaseComObject(Workbook);
					Workbook=null;
				}
				if(ExcelApp!=null)
				{
					ExcelApp.Quit();
					Marshal.ReleaseComObject(ExcelApp);
					ExcelApp=null;
				}
				//GC.Collect();
				GC.GetTotalMemory(true);
			}
		}

		static string ColNoToName(int ColNo)
		{
			string
				ColName=string.Empty;

			if(ColNo<=0)
				return(ColName);

			if(--ColNo<='Z'-'A')
				ColName=Convert.ToString((char)('A'+ColNo));
			else
			{
				int
					Hi=ColNo/('Z'-'A');

				ColName=Convert.ToString((char)(Hi+'A'-1))+Convert.ToString((char)(ColNo-Hi*('Z'-'A')+'A'-1));
			}

			if(!IsNameColumn(ColName))
				ColName=string.Empty;

			return(ColName);
		}
		//---------------------------------------------------------------------------

		static bool IsNameColumn(string Value)
		{
			int
				Len;

			Value=Value.Trim().ToUpper();

			if((Len=Value.Length)>2)
				return false;

			for(int i=0; i<Len; ++i)
				if(!Char.IsLetter(Value[i]))
					return false;
			if(Len==2 && Value[0]>'I' && Value[1]>'V')  // max IV == 256
				return false;

			return true;
		}
		//---------------------------------------------------------------------------
	}
}
