//---------------------------------------------------------------------------

#include <vcl.h>
#include <DateUtils.hpp>
#include <OleCtrls.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#define TEST_CELLS
//#define TEST_DATE
//#define TEST_SAVE_AS
//#define TEST_SUBTOTAL
//#define TEST_PICTURES
//#define TEST_CHARACTERS
//#define TEST_COMMENT
//#define CREATE_CHART
//#define USE_TEMPLATE
//#define TEST_COPYSHEET

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   Excel.Clear();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Exit1Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::RunExcel1Click(TObject *Sender)
{
   AnsiString
     Mess,
     XlsFileName;

   Variant
     Workbooks,
     Workbook1,
     Workbook2,
     Sheets,
     Sheet1,
     Sheet2,
     Range1,
     Range2,
     Borders,
     Columns,
     Rows,
     PageSetup,
     Orientation,
     DataArray,
     Value,
     MyChart,
     Series,
     Cells,
     Cell;

   int
     tmpInt;

   try
   {
      try
      {
         Excel=Variant::GetActiveObject("Excel.Application");
      }
      catch(EOleSysError &eException)
      {
         if(eException.ErrorCode==-2147221021)
         {
            try
            {
               Excel=CreateOleObject("Excel.Application");
            }
            catch(...)
            {
               Application->MessageBox("Object Excel was not created!!!",Application->Title.c_str(),MB_OK|MB_ICONERROR);
               return;
            }
         }
      }

        if(Excel.IsEmpty())
          {
             Application->MessageBox("Object Excel was not created!!!",Application->Title.c_str(),MB_OK|MB_ICONERROR);
             return;
          }

        Value=Excel.OleFunction("CentimetersToPoints",20);
        Excel.OlePropertySet("Visible",true);
        Excel.OlePropertySet("DisplayAlerts",false);

        Workbooks=Excel.OlePropertyGet("Workbooks");

        //Количество рабочих листов в новой книге
        //Excel.OlePropertySet("SheetsInNewWorkbook",1);

        #if defined(TEST_CELLS)
           Workbook1=Workbooks.OleFunction("Add");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
           Range1=Sheet1.OlePropertyGet("Range","A1:C7"); // Диaпaзoн
           Range1.OlePropertySet("Value","Some Value");
           Cells=Sheet1.OlePropertyGet("Cells");
           int
             _row_=1;

           Value=(Cell=Cells.OlePropertyGet("Item",_row_++,1)).OlePropertyGet("Value");

           Cell.Clear();
           VarClear(Cell);
           Cell=Unassigned;

           Cells.Clear();
           VarClear(Cells);
           Cells=Unassigned;

           Range1.Clear();
           VarClear(Range1);
           Range1=Unassigned;

           Sheet1.Clear();
           VarClear(Sheet1);
           Sheet1=Unassigned;

           Workbook1.OleProcedure("Close");
           Workbook1.Clear();
           VarClear(Workbook1);
           Workbook1=Unassigned;
        #endif

        #if defined(TEST_DATE)
           Workbook1=Workbooks.OleFunction("Add");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
           Range1=Sheet1.OlePropertyGet("Columns","A");
           Range1.OlePropertySet("ColumnWidth",3);
           Range1=Sheet1.OlePropertyGet("Range","A1");
           //Range1.OlePropertySet("NumberFormat","ДД/ММ/ГГ");
           Range1.OlePropertySet("Value","01.01.2001");
           Value=Range1.OlePropertyGet("Value");
           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(TEST_SAVE_AS)
           Workbook1=Workbooks.OleFunction("Add");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
           for(int i=0; i<10; ++i)
           {
              Mess="A"+IntToStr(i+1);
              Range1=Sheet1.OlePropertyGet("Range",Mess.c_str());
              Range1.OlePropertySet("Value",i);
           }

           Mess=ExtractFilePath(Application->ExeName)+"xls2dbf.dbf";

           Workbook1.OleProcedure("SaveAs",Mess.c_str(),11/* xlDBF4 */);

           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(TEST_SUBTOTAL)
           Workbook1=Workbooks.OleFunction("Add");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
           for(int i=0; i<10; ++i)
           {
              if(!i)
                Value="Caption# 1";
              else
                Value=i;
              Mess="A"+IntToStr(i+1);
              Range1=Sheet1.OlePropertyGet("Range",Mess.c_str());
              Range1.OlePropertySet("Value",Value);

              if(!i)
                Value="Caption# 2";
              else
                Value=i*2;
              Mess="B"+IntToStr(i+1);
              Range1=Sheet1.OlePropertyGet("Range",Mess.c_str());
              Range1.OlePropertySet("Value",Value);

              if(!i)
                Value="Caption# 3";
              else
                Value=i*i;
              Mess="C"+IntToStr(i+1);
              Range1=Sheet1.OlePropertyGet("Range",Mess.c_str());
              Range1.OlePropertySet("Value",Value);
           }

           Variant
             TotalList=VarArrayCreate(OPENARRAY(int,(1,2)),varVariant);

           TotalList.PutElement(3,1);
           TotalList.PutElement(2,2);

           Value=VarArrayDimCount(TotalList);
           Value=VarArrayHighBound(TotalList,1);

           Value=TotalList.GetElement(1);
           Value=TotalList.GetElement(2);

           Range1=Sheet1.OlePropertyGet("Range","A1:C10");
           Range1.OleProcedure("Select");
           Excel.OlePropertyGet("Selection").OleProcedure("Subtotal",1L,(long)0xFFFFEFC3 /* xlSum */,TotalList,true,false,true);
           Sheet1.OlePropertyGet("Outline").OleProcedure("ShowLevels",2);

           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(TEST_PICTURES)
           Workbook1=Workbooks.OleFunction("Add");
           Excel.OlePropertyGet("ActiveSheet").OlePropertyGet("Pictures").OleProcedure("Insert","F:\\My_Doc\\avatara.gif"/*"c:\\WINNT\\vertriver800.bmp"*/);
           //Excel.OlePropertyGet("ActiveSheet").OlePropertyGet("Pictures").OleFunction("Insert","c:\\WINNT\\vertriver800.bmp");
           Excel.OlePropertyGet("ActiveSheet").OlePropertyGet("Shapes").OleFunction("Item","Picture 1").OleProcedure("Select");
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(TEST_CHARACTERS)
           Workbook1=Workbooks.OleFunction("Add");
           Sheets=Workbook1.OlePropertyGet("Sheets");
           Sheet1=Sheets.OlePropertyGet("Item",1);
           Range1=Sheet1.OlePropertyGet("Range","A1:A1");
           Value="aaabbbccc";
           Range1.OlePropertySet("Value",Value);
           Range2=Range1.OlePropertyGet("Characters",4,3);
           Range2.OlePropertyGet("Font").OlePropertySet("Size",20);
           Range2.OlePropertyGet("Font").OlePropertySet("Name","Comic Sans MS");
           Range2.OlePropertyGet("Font").OlePropertySet("Bold",true);
           Range2.OlePropertyGet("Font").OlePropertySet("Italic",true);
           Range2.OlePropertyGet("Font").OlePropertySet("Underline",true);
           Range2.OlePropertyGet("Font").OlePropertySet("ColorIndex",3);

           Range2=Unassigned;
           Range2.Clear();
           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Sheets=Unassigned;
           Sheets.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif


        #if defined(TEST_COMMENT)
           Workbook1=Workbooks.OleFunction("Add");
           Sheets=Workbook1.OlePropertyGet("Sheets");
           Sheet1=Sheets.OlePropertyGet("Item",1);
           Range1=Sheet1.OlePropertyGet("Range","A3:A3");
           Value="This is a comment";
           Range2=Range1.OleFunction("AddComment",Value);
           Range2.OlePropertySet("Visible",true);

           Range2=Range1.OlePropertyGet("Comment");
           Mess = Range2.IsEmpty() ? "IsEmpty()" : "!IsEmpty()";
           Mess = Range2.IsEmpty() ? "IsNull()" : "!IsNull()";
           Mess = VarIsClear(Range2) ? "VarIsClear()" : "!VarIsClear()";
           Mess = VarIsNull(Range2) ? "VarIsNull()" : "!VarIsNull()";
           Mess=Range2.OleFunction("Text");

           Range1=Sheet1.OlePropertyGet("Range","A1:A1");
           Range2=Range1.OlePropertyGet("Comment");
           Mess = Range2.IsEmpty() ? "IsEmpty()" : "!IsEmpty()";
           Mess = Range2.IsEmpty() ? "IsNull()" : "!IsNull()";
           Mess = VarIsClear(Range2) ? "VarIsClear()" : "!VarIsClear()";
           Mess = VarIsNull(Range2) ? "VarIsNull()" : "!VarIsNull()";
           
           Range2=Unassigned;
           Range2.Clear();
           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Sheets=Unassigned;
           Sheets.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(TEST_COPYSHEET)
           Workbook1=Workbooks.OleFunction("Add");
           Sheets=Workbook1.OlePropertyGet("Sheets");
           Sheet1=Sheets.OlePropertyGet("Item",1);
           Range1=Sheet1.OlePropertyGet("Range","A1:A10");

           Value=1000000;
           Range1.OlePropertySet("Value",Value);
           Range1=Sheets.OlePropertyGet("Item",1);
           Sheet1.OleProcedure("Copy",EmptyParam,Range1);

           Range1=Unassigned;
           Range1.Clear();
           Sheet1=Unassigned;
           Sheet1.Clear();
           Sheets=Unassigned;
           Sheets.Clear();
           Workbook1.OleProcedure("Close");
           Workbook1=Unassigned;
           Workbook1.Clear();
        #endif

        #if defined(USE_TEMPLATE)
           XlsFileName=ExtractFilePath(Application->ExeName)+"template.xlt";
           Workbooks.OleProcedure("Open",XlsFileName.c_str());
           Workbook1=Excel.OlePropertyGet("ActiveWorkbook");
           Sheets=Workbook1.OlePropertyGet("Sheets");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");


           Range1=Sheet1.OlePropertyGet("Range","A1");
           Value=1000000;
           Range1.OlePropertySet("Value",Value);
           Range1.OlePropertyGet("Columns").OleProcedure("AutoFit");

           Range1=Sheet1.OlePropertyGet("Range","B1");
           Value=2000000;
           Range1.OlePropertySet("Value",Value);
           Range1.OlePropertyGet("Columns").OleProcedure("AutoFit");

           Range1=Sheet1.OlePropertyGet("Range","C1");
           Value=DateOf(Now());
           Range1.OlePropertySet("Value",Value);
           Range1.OlePropertyGet("Columns").OleProcedure("AutoFit");

           Range1=Sheet1.OlePropertyGet("Range","D1");
           Value=TimeOf(Now());
           Range1.OlePropertySet("Value",Value);
           Range1.OlePropertyGet("Columns").OleProcedure("AutoFit");

           Range1=Sheet1.OlePropertyGet("Range","E1");
           Value="555";
           Range1.OlePropertySet("Value",Value);
           Range1.OlePropertyGet("Columns").OleProcedure("AutoFit");

           Mess=ExtractFilePath(Application->ExeName)+"template_out.xls";
           tmpInt=0xFFFFEFD1; /* xlWorkbookNormal */
           tmpInt=0xFFFFEFD1; /* xlNormal */

           //tmpInt=21; /* xlTextMSDOS */
           //Mess=ExtractFilePath(Application->ExeName)+"template_out.txt";

           Value=Mess.c_str();
           Range1=tmpInt;
           Workbook1.OleProcedure("SaveAs",Value,Range1,"" /*"Password"*/,"" /*"WritePassword"*/, false /*true*/, false);
           Workbook1.OleProcedure("Close");
        #endif

        #if defined(CREATE_CHART)
           Workbook1=Workbooks.OleFunction("Add");
           Sheets=Workbook1.OlePropertyGet("Sheets");
           Sheet1=Workbook1.OlePropertyGet("ActiveSheet");

           char
             buff[0x0ffff];

           for(int i=1; i<=20; ++i)
              {
                 Mess="A"+IntToStr(i);
                 strcpy(buff,Mess.c_str());
                 Range1=Sheet1.OlePropertyGet("Range",buff);

                 Range1.OlePropertySet("Value",i);

                 Mess="B"+IntToStr(i);
                 strcpy(buff,Mess.c_str());
                 Range1=Sheet1.OlePropertyGet("Range",buff);

                 Mess="=SIN(A"+IntToStr(i)+")";
                 strcpy(buff,Mess.c_str());
                 Range1.OlePropertySet("Formula",buff);

                 Mess="C"+IntToStr(i);
                 strcpy(buff,Mess.c_str());
                 Range1=Sheet1.OlePropertyGet("Range",buff);

                 Mess="=COS(A"+IntToStr(i)+")";
                 strcpy(buff,Mess.c_str());
                 Range1.OlePropertySet("Formula",buff);

                 Mess="D"+IntToStr(i);
                 strcpy(buff,Mess.c_str());
                 Range1=Sheet1.OlePropertyGet("Range",buff);

                 Mess="=B"+IntToStr(i)+"+C"+IntToStr(i);
                 strcpy(buff,Mess.c_str());
                 Range1.OlePropertySet("Formula",buff);
              }

           MyChart=Excel.OlePropertyGet("Charts").OleFunction("Add");
           //MyChart.OlePropertySet("ChartType",65 /*xlLineMarkers*/);
           MyChart.OlePropertySet("ChartType",4 /*xlLine*/);

           Mess="B1:";
           Cells=Sheet1.OlePropertyGet("Cells");
           Range1=Cells.OlePropertyGet("SpecialCells",11 /*xlCellTypeLastCell*/);
           tmpInt=Range1.OlePropertyGet("Column");
           Mess+=AnsiString(char('A'+tmpInt-1 -1 /* last -1 especially 4 'C' */));
           tmpInt=Range1.OlePropertyGet("Row");
           Mess+=IntToStr(tmpInt);
           strcpy(buff,Mess.c_str());
           Range1=Sheet1.OlePropertyGet("Range",buff);
           MyChart.OleProcedure("SetSourceData",Range1,2 /*xlColumns*/);

           MyChart=MyChart.OleFunction("Location",2 /*xlLocationAsObject*/,"Лист1");
           //Series=MyChart.OlePropertyGet("SeriesCollection").OleFunction("NewSeries");
           Series=MyChart.OleFunction("SeriesCollection").OleFunction("NewSeries");

           Value=MyChart.OlePropertyGet("SeriesCollection").OlePropertyGet("Count");

           Mess="A1:A20";
           strcpy(buff,Mess.c_str());
           Range1=Sheet1.OlePropertyGet("Range",buff);

           for(int i=Value; i>0; --i)
              {
                 MyChart.OlePropertyGet("SeriesCollection",i).OlePropertySet("XValues",Range1);
                 switch(i)
                   {
                      case 1 :
                        {
                           MyChart.OlePropertyGet("SeriesCollection",i).OlePropertySet("Name","sin");

                           break;
                        }
                      case 2 :
                        {
                           MyChart.OlePropertyGet("SeriesCollection",i).OlePropertySet("Name","cos");

                           break;
                        }
                   }
              }

           Mess="D1:D20";
           strcpy(buff,Mess.c_str());
           Range1=Sheet1.OlePropertyGet("Range",buff);
           Series.OlePropertySet("Values",Range1);
           Series.OlePropertySet("Name","sin+cos");

           MyChart.OlePropertySet("HasTitle",true);
           MyChart.OlePropertyGet("ChartTitle").OlePropertyGet("Characters").OlePropertySet("Text","Name of Chart");
           MyChart.OlePropertyGet("Axes",1 /*xlCategory*/, 1 /*xlPrimary*/).OlePropertySet("HasTitle",true);
           MyChart.OlePropertyGet("Axes",1 /*xlCategory*/, 1 /*xlPrimary*/).OlePropertyGet("AxisTitle").OlePropertyGet("Characters").OlePropertySet("Text","Name of Category");
           MyChart.OlePropertyGet("Axes",2 /*xlValue*/, 1 /*xlPrimary*/).OlePropertySet("HasTitle",true);
           MyChart.OlePropertyGet("Axes",2 /*xlValue*/, 1 /*xlPrimary*/).OlePropertyGet("AxisTitle").OlePropertyGet("Characters").OlePropertySet("Text","Name of Value");

           MyChart.OlePropertySet("HasLegend",true);

           int
             Position=0xFFFFEFF5; /*xlBottom*/

           MyChart.OlePropertyGet("Legend").OlePropertySet("Position",Position);

           Range2=MyChart.OlePropertyGet("SeriesCollection",1).OlePropertyGet("Values");
           Mess=Range2.OlePropertyGet("Address");
           DataArray=VarArrayCreate(OPENARRAY(int,(0,1,0,20)),varVariant);
           if(DataArray.IsArray())
           {
              DataArray=Range2.OlePropertyGet("Value");

              int
                MaxI=VarArrayDimCount(DataArray),
                MaxJ=VarArrayHighBound(DataArray,1);

              Mess="";
              for(int i=0; i<=MaxI; i++)
              {
                 for(int j=0; j<MaxJ; j++)
                 {
                    if(!Mess.IsEmpty())
                      Mess+=" ";
                    Mess+="["+IntToStr(i)+"]["+IntToStr(j)+"]=";
                    Mess+=DataArray.GetElement(j+1,i+1);
                 }
                 if(!Mess.IsEmpty())
                   Mess+="\n";
              }
              ShowMessage(Mess);
           }

           Mess=ExtractFilePath(Application->ExeName)+"chart.xls";
           strcpy(buff,Mess.c_str());
           Workbook1.OleProcedure("SaveAs",buff);
           Workbook1.OleProcedure("Close");
        #endif

        // Создать новую книгу
        Workbook1=Workbooks.OleFunction("Add");

        // Открыть существующую
        XlsFileName=ExtractFilePath(Application->ExeName)+"test.xls";
        Workbooks.OleProcedure("Open",XlsFileName.c_str());

        Value=Excel.OlePropertyGet("ActiveWorkbook").OlePropertyGet("Name");
        Workbook2=Excel.OlePropertyGet("ActiveWorkbook");

        Sheets=Workbook1.OlePropertyGet("Sheets");

        // Узнать кол-во листов
        tmpInt=Sheets.OlePropertyGet("Count");

        // Дoбaвить лиcт
        Sheets.OleProcedure("Add");
        tmpInt=Sheets.OlePropertyGet("Count");

        Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
        tmpInt=Sheet1.OlePropertyGet("Index");

        PageSetup=Sheet1.OlePropertyGet("PageSetup");
        PageSetup.OlePropertySet("Orientation",2);
        PageSetup.OlePropertySet("Zoom",false);

        Range1=Sheet1.OlePropertyGet("Range","A1");
        Range1.OlePropertySet("Value","Some Value");
        Range1.OleProcedure("Copy");
        Range2=Sheet1.OlePropertyGet("Range","A10");
        Sheet1.OleProcedure("Paste",Range2);
        Range2=Sheet1.OlePropertyGet("Range","A11");
        Sheet1.OleProcedure("Activate");
        Range2.OleProcedure("Select");
        Sheet1.OleProcedure("Paste");

        // Вставить строку перед 1-й
        Rows=Range1.OlePropertyGet("Rows");
        Rows.OleProcedure("Insert");

        //Объединяем ячейки
        Range1=Sheet1.OlePropertyGet("Range","A1:A3");
        Range1.OleProcedure("Merge");

        // Проверка на попадание ячейки в обЪединение
        Cells=Sheet1.OlePropertyGet("Cells",1,1); // "A1"
        Value=Cells.OlePropertyGet("MergeArea");
        Mess=Value.OlePropertyGet("Address"); // =="$A$1:$A$3"

        Cells=Sheet1.OlePropertyGet("Cells",2,1); // "A2"
        Mess=Cells.OlePropertyGet("MergeArea").OlePropertyGet("Address"); // =="$A$1:$A$3"

        Cells=Sheet1.OlePropertyGet("Cells",3,1); // "A3"
        Mess=Cells.OlePropertyGet("MergeArea").OlePropertyGet("Address"); // =="$A$1:$A$3"

        Cells=Sheet1.OlePropertyGet("Cells",4,1); // "A4"
        Mess=Cells.OlePropertyGet("MergeArea").OlePropertyGet("Address"); // =="$A$4"

        Cells=Sheet1.OlePropertyGet("Cells",1,2); // "B1"
        Mess=Cells.OlePropertyGet("MergeArea").OlePropertyGet("Address"); // =="$B$1"

        Range1=Sheet1.OlePropertyGet("Range","D1");
        Range1.OlePropertySet("Value","Some Value");
        Range1=Sheet1.OlePropertyGet("Range","D1:E1");
        Range1.OleProcedure("Merge");
        Range1=Sheet1.OlePropertyGet("Range","D2");
        Range1.OlePropertySet("Value","Some Value Some Value");
        Range1=Sheet1.OlePropertyGet("Range","D2:E2");
        Range1.OleProcedure("Merge");
        Range1=Sheet1.OlePropertyGet("Range","D3");
        Range1.OlePropertySet("Value","Some Value Some Value Some Value");
        Range1=Sheet1.OlePropertyGet("Range","D3:E3");
        Range1.OleProcedure("Merge");
        Sheet1.OlePropertyGet("Range","E1").OlePropertyGet("Columns").OleProcedure("AutoFit");
        Sheet1.OlePropertyGet("Range","D1").OlePropertyGet("Columns").OleProcedure("AutoFit");
        Sheet1.OlePropertyGet("Range","D3").OlePropertyGet("Columns").OleProcedure("AutoFit");
        Sheet1.OlePropertyGet("Range","D3:E3").OlePropertyGet("Columns").OleProcedure("AutoFit");

        // Удaлить лиcт
        Sheet1.OleProcedure("Delete");

        // Oбoзвaть лиcт
        Sheet1=Workbook1.OlePropertyGet("ActiveSheet");
        Sheet1.OlePropertySet("Name","SheetName");

        // Aктивиpoвaть лиcт
        Sheet1.OleProcedure("Activate");

        // Bыбpaть лиcт
        Sheet2=Sheets.OlePropertyGet("Item",3);

        Range1=Sheet1.OlePropertyGet("Range","A1"); // Caмaя пepвaя ячeйкa
        Range2=Sheet2.OlePropertyGet("Range","A1:C7;E1:G7"); // Диaпaзoн

        // 3aпиcaть знaчeни(вo вce ячeйки)
        Range1.OlePropertySet("Value","Some Value");
        Range2.OlePropertySet("Value","Some Value");

        // Пoлyчить знaчeния(Variant Array)
        DataArray=VarArrayCreate(OPENARRAY(int,(0,3,0,7)),varVariant);
        if(DataArray.IsArray())
          {
             DataArray=Range2.OlePropertyGet("Value");

             int
               MaxI=VarArrayDimCount(DataArray),
               MaxJ=VarArrayHighBound(DataArray,1);

             Mess="";
             for(int i=0; i<=MaxI; i++)
                {
                   for(int j=0; j<MaxJ; j++)
                      {
                         if(!Mess.IsEmpty())
                           Mess+=" ";
                         Mess+="["+IntToStr(i)+"]["+IntToStr(j)+"]=";
                         Mess+=DataArray.GetElement(j+1,i+1);
                      }
                    if(!Mess.IsEmpty())
                      Mess+="\n";
                }
              ShowMessage(Mess);

             for(int i=0; i<=MaxI; i++)
                for(int j=0; j<MaxJ; j++)
                   DataArray.PutElement("["+IntToStr(i)+"]["+IntToStr(j)+"]",j+1,i+1);
             Range2.OlePropertySet("Value",DataArray);
          }

        Range2=Sheet2.OlePropertyGet("Range","D1:D7"); // Диaпaзoн
        Range2.OlePropertySet("Value",1);
        Range2=Sheet2.OlePropertyGet("Range","D8");

        // 3aпиcaть фyнкцию(aккypaтнee c pycкими вepcиями)
        Range2.OlePropertySet("Formula","=СУММ(D1:D7)");

        Cells=Sheet2.OlePropertyGet("Cells",8,4); // "D8"
        Value=Cells.OlePropertyGet("Value");

        Range2=Sheet2.OlePropertyGet("Range","D1:D7");
        // Пoвopoт тeкcтa нa Angle гpaдycoв
        Value=30;
        Range2.OlePropertySet("Orientation",Value);

        // Paмкa вoкpyг oблacти
        Range2.OleProcedure("BorderAround",1,3);

        // Paмкa вoкpyг кaждoй ячeйки oблacти
        Borders=Range2.OlePropertyGet("Borders");
        Borders.OlePropertySet("Weight",3); // 3-жиpнaя, 2- тoньшe

        // Aвтoпoдгoн шиpины и выcoты
        Columns=Range2.OlePropertyGet("Columns");
        Columns.OleProcedure("AutoFit");
        Rows=Range2.OlePropertyGet("Rows");
        Rows.OleProcedure("AutoFit");

        Sheet2.OlePropertyGet("Columns").OlePropertyGet("Item",1).OlePropertySet("ColumnWidth", 12);
        Sheet2.OlePropertyGet("Columns").OlePropertyGet("Item",2).OleProcedure("AutoFit");

        //ActiveSheet.Range("D5").Rows.Delete Shift:=xlShiftUp
        //Sheet2.OlePropertyGet("Range","D5").OlePropertyGet("Rows").OleFunction("Delete",Variant(0xFFFFEFBE));

        //ActiveSheet.Range("D5").EntireRow.Delete Shift:=xlShiftUp
        //Sheet2.OlePropertyGet("Range","D5").OlePropertyGet("EntireRow").OleFunction("Delete",0xFFFFEFBE);

        Sheet2.OlePropertyGet("Range","D5").OlePropertyGet("EntireRow").OleFunction("Delete");

        //ActiveSheet.Range("D5").Delete Shift:=xlShiftUp
        //Sheet2.OlePropertyGet("Range","D5").OleFunction("Delete",0xFFFFEFBE);

        Sheets=Workbook1.OlePropertyGet("Sheets");
        Sheet1=Sheets.OlePropertyGet("Item","SheetName");
        Sheet2=Sheets.OlePropertyGet("Item","Лист3");
        Sheet1.OleProcedure("Move",EmptyParam,Sheet2);
        Sheet1.OlePropertyGet("Hyperlinks").OleFunction("Add",Sheet1.OlePropertyGet("Range","C1"),"http://google.com/");

        Procedure
          SaveAs("SaveAs");

        Mess=ExtractFilePath(Application->ExeName)+"out.xls";
        Workbook1.Exec(SaveAs<<Mess.c_str());
//        Workbook1.OleProcedure("SaveAs",Mess.c_str());
     }
   catch(EOleException &e)
     {
        Mess=e.ClassName();
        Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
   catch(EOleSysError &e)
     {
        Mess=e.ClassName();
        Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
   catch(EOleError &e)
     {
        Mess=e.ClassName();
        Mess+=" Error \""+e.Message+"\"";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
   catch(EOleCtrlError &e)
     {
        Mess=e.ClassName();
        Mess+=" Error \""+e.Message+"\"";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
   catch(Exception &e)
     {
        Mess=e.ClassName();
        Mess+=" Error \""+e.Message+"\"";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
   catch(...)
     {
        Application->MessageBox("Run Excel error!!!",Application->Title.c_str(),MB_OK|MB_ICONERROR);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(!Excel.IsEmpty())
     {
        Excel.OleProcedure("Quit");
        Excel.Clear();
        VarClear(Excel);
        Excel=Unassigned;
     }
}
//---------------------------------------------------------------------------

