//---------------------------------------------------------------------------

#include <vcl.h>
#include <new>
#include <DateUtils.hpp>
#include <StrUtils.hpp>
#pragma hdrstop

#include "main.h"
#include "Excel_2K_SRVR.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define TEST_SAVE_AS
//#define TEST_AUTO_OPEN_MACRO
//#define TEST_CHARACTERS
//#define CREATE_CHART
//#define USE_TEMPLATE
//#define TEST_REPLACE
//#define MULTI_LINE
//#define TEST_DATE
//#define TEST_COPYSHEET

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   TExcelApplication
     *ExcelApplication=0;

   TExcelWorkbook
     *ExcelWorkbookSrc=0,
     *ExcelWorkbookDest=0;

   TExcelWorksheet
     *ExcelWorksheetSrc=0,
     *ExcelWorksheetDest=0;

   TExcelChart
     *ExcelChart=0;

   AnsiString
     tmpAnsiString="",
     ExcelFileNameSrc=ExtractFilePath(Application->ExeName)+"test_out.xls",
     ExcelFileNameDest=ExtractFilePath(Application->ExeName)+"out_out.xls",
     aBeginRange,
     aEndRange,
     aValue;

   TVariant
     BeginRange,
     EndRange,
     Range,
     Value;

   wchar_t
     *tmpWChar_tBuff=0;

   int
     tmpWChar_tBuffSize=0xffff;

   long
     tmpLong;

   try
     {
        while(!tmpWChar_tBuff && tmpWChar_tBuffSize)
          {
             tmpWChar_tBuff=new wchar_t [tmpWChar_tBuffSize];
             if(!tmpWChar_tBuff)
               tmpWChar_tBuffSize>>=1;
          }
        if(!tmpWChar_tBuff && !tmpWChar_tBuffSize)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): insufficient memory");
          }

        try
          {
             ExcelApplication=new TExcelApplication(0);
             ExcelWorkbookSrc=new TExcelWorkbook(0);
             ExcelWorkbookDest=new TExcelWorkbook(0);
             ExcelWorksheetSrc=new TExcelWorksheet(0);
             ExcelWorksheetDest=new TExcelWorksheet(0);
             ExcelChart=new TExcelChart(0);
          }
        catch(std::bad_alloc)
          {
             if(ExcelChart)
               {
                  delete ExcelChart;
                  ExcelChart=0;
               }
             if(ExcelWorksheetSrc)
               {
                  delete ExcelWorksheetSrc;
                  ExcelWorksheetSrc=0;
               }
             if(ExcelWorksheetDest)
               {
                  delete ExcelWorksheetDest;
                  ExcelWorksheetDest=0;
               }

             if(ExcelWorkbookSrc)
               {
                  delete ExcelWorkbookSrc;
                  ExcelWorkbookSrc=0;
               }
             if(ExcelWorkbookDest)
               {
                  delete ExcelWorkbookDest;
                  ExcelWorkbookDest=0;
               }

             if(ExcelApplication)
               {
                  delete ExcelApplication;
                  ExcelApplication=0;
               }
             if(tmpWChar_tBuff)
               {
                  delete []tmpWChar_tBuff;
                  tmpWChar_tBuff=0;
               }

             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): insufficient memory");
          }

        try
          {
             ExcelApplication->ConnectKind=ckNewInstance;
             //ExcelApplication->AutoQuit=false;
             ExcelApplication->Connect();
             ExcelApplication->set_DisplayAlerts(TDefLCID(),false);
             ExcelApplication->set_Visible(TDefLCID(),true);

             #if defined(TEST_SAVE_AS)
                ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
                ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

                for(int i=1; i<10; ++i)
                {
                   BeginRange="A"+IntToStr(i);
                   Value=i;
                   ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
                }

                tmpAnsiString=ExtractFilePath(Application->ExeName)+"xls2dbf.dbf";
                if(FileExists(tmpAnsiString))
                  DeleteFile(tmpAnsiString);
                Value=tmpAnsiString;
                ExcelWorkbookDest->SaveAs(Value,(TVariant)xlDBF4,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());

                ExcelWorksheetDest->Disconnect();
                ExcelWorkbookDest->Close();
                ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(TEST_AUTO_OPEN_MACRO)
                Value=ExtractFilePath(Application->ExeName)+"ot12102005.xls";
                ExcelApplication->set_EnableEvents(false);
                ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Open(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam, EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID()));
                ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

                ExcelWorksheetDest->Disconnect();
                ExcelWorkbookDest->Close();
                ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(TEST_CHARACTERS)
               ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
               ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

               tmpAnsiString="A1";
               BeginRange=tmpAnsiString;
               tmpAnsiString="aaabbbccc";
               Value=tmpAnsiString;

               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_Size(TVariant(20));
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_Name(TVariant("Comic Sans MS"));
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_Bold(TVariant(true));
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_Italic(TVariant(true));
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_Underline(TVariant(true));
               ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_Characters(TVariant(4),TVariant(3))->get_Font()->set_ColorIndex(TVariant(3));

               ExcelWorksheetDest->Disconnect();
               ExcelWorkbookDest->Close();
               ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(TEST_COPYSHEET)
               ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
               ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

               tmpAnsiString="Line1\r\nLine2";
               tmpAnsiString=AnsiReplaceText(tmpAnsiString,"\r","");
               Value=tmpAnsiString;

               for(int i=1; i<10; ++i)
                  {
                     BeginRange="A"+IntToStr(i);
                     ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
                  }
               Value=1;
               BeginRange=EmptyParam;
               EndRange=ExcelWorkbookDest->Sheets->get_Item(Value);
               ExcelWorksheetDest->Copy(BeginRange,EndRange,TDefLCID());
               ExcelWorksheetDest->Disconnect();
               ExcelWorkbookDest->Close();
               ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(TEST_DATE)
                ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
                ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

                /*
                LanguageSettings
                  *p=ExcelApplication->get_LanguageSettings(); // AV !!! в Office97 свойство LanguageSettings отсутствует

                if(p)
                  {
                     int
                       tmpInt=0;

                     long
                       id=p->get_LanguageID(msoLanguageIDUI,&tmpInt);
                  }
                */

                BeginRange="A1";

                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();

                Value=DateOf(Now());
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->Columns->AutoFit();
                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();
                /*
                Selection.NumberFormat = "d/m"
                Selection.NumberFormat = "d/m/yy"
                Selection.NumberFormat = "dd/mm/yy"
                Selection.NumberFormat = "d mmm"
                Selection.NumberFormat = "d mmm yy"
                Selection.NumberFormat = "dd mmm yy"
                Selection.NumberFormat = "mmm yy"
                Selection.NumberFormat = "mmmm yy"
                Selection.NumberFormat = "d mmmm, yyyy"
                Selection.NumberFormat = "dd/mm/yy h:mm am/pm"
                Selection.NumberFormat = "dd/mm/yy h:mm"
                Selection.NumberFormat = "mmmm"
                Selection.NumberFormat = "mmmmm-yy"
                Selection.NumberFormat = "mmmm yy"
                */
                Value=WideString("ММ.ДД.ГГГГ");
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_NumberFormat(Value);
                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_NumberFormatLocal(Value);
                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();

                Value=WideString("ММММ");
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_NumberFormat(Value);
                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();
                ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_NumberFormatLocal(Value);
                Value=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormat();
                EndRange=ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->get_NumberFormatLocal();

                tmpAnsiString=ExtractFilePath(Application->ExeName)+"temp1.xls";
                if(FileExists(tmpAnsiString))
                  DeleteFile(tmpAnsiString);
                Value=tmpAnsiString;
                ExcelWorkbookDest->SaveAs(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());

                ExcelWorksheetDest->Disconnect();
                ExcelWorkbookDest->Close();
                ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(MULTI_LINE)
               ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
               ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

               tmpAnsiString="Line1\r\nLine2";
               tmpAnsiString=AnsiReplaceText(tmpAnsiString,"\r","");
               Value=tmpAnsiString;

               for(int i=1; i<10; ++i)
                  {
                     BeginRange="A"+IntToStr(i);
                     ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
                  }

               ExcelWorksheetDest->Disconnect();
               ExcelWorkbookDest->Close();
               ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(TEST_REPLACE)
               ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
               ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

               Value="qq";
               for(int i=1; i<10; ++i)
                  {
                     BeginRange="A"+IntToStr(i);
                     ExcelWorksheetDest->get_Range(BeginRange,EmptyParam)->set_Value(Value);
                  }
               BeginRange="aa";
               EndRange=xlPart; /*xlWhole*/
               Range=xlByRows; /*xlByColumns*/
               ExcelWorksheetDest->get_Cells()->Replace(Value,BeginRange,EndRange,Range,TVariant(false));

               ExcelWorksheetDest->Disconnect();
               ExcelWorkbookDest->Close();
               ExcelWorkbookDest->Disconnect();
              #endif

             #if defined(USE_TEMPLATE)
                Value=ExtractFilePath(Application->ExeName)+"template.xlt";
                ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Open(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam, EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID()));
                ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

                BeginRange="A1";
                EndRange=AnsiString(char('A'+ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Column-1))+"1";
                Value=xlDown;
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Insert(Value);
                BeginRange=EndRange="A2";
                Value=1000000;
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Columns->AutoFit();

                BeginRange=EndRange="B2";
                Value=2000000;
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Columns->AutoFit();

                BeginRange=EndRange="C2";
                Value=DateOf(Now());
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Columns->AutoFit();

                BeginRange=EndRange="D2";
                Value=TimeOf(Now());
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Columns->AutoFit();

                BeginRange=EndRange="E2";
                Value="555";
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Columns->AutoFit();

                tmpAnsiString=ExtractFilePath(Application->ExeName)+"template_out.xls";
                if(FileExists(tmpAnsiString))
                  DeleteFile(tmpAnsiString);
                Value=tmpAnsiString;
                BeginRange=xlWorkbookNormal;
                ExcelWorkbookDest->SaveAs(Value,BeginRange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());
                ExcelWorksheetDest->Disconnect();
                ExcelWorkbookDest->Close();
                ExcelWorkbookDest->Disconnect();
             #endif

             #if defined(CREATE_CHART)
               ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
               ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);

               for(int Col=1; Col<20; ++Col)
                  {
                     BeginRange="A"+IntToStr(Col);
                     EndRange="A"+IntToStr(Col);
                     Value=Col;
                     ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);

                     BeginRange="B"+IntToStr(Col);
                     EndRange="B"+IntToStr(Col);
                     Value="=sin(A"+IntToStr(Col)+")";
                     ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Formula(Value);

                     BeginRange="C"+IntToStr(Col);
                     EndRange="C"+IntToStr(Col);
                     Value="=cos(A"+IntToStr(Col)+")";
                     ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Formula(Value);

                     BeginRange="D"+IntToStr(Col);
                     EndRange="D"+IntToStr(Col);
                     Value="=sin(A"+IntToStr(Col)+")+cos(A"+IntToStr(Col)+")";
                     ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Formula(Value);
                }

               Value=1;
               ExcelChart->ConnectTo(ExcelApplication->Charts->Add(EmptyParam,EmptyParam,Value,EmptyParam,TDefLCID()));
               tmpLong=ExcelChart->get_Index(TDefLCID());
               tmpWChar_tBuff=ExcelChart->get_Name();

               tmpAnsiString="Chart #1";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               ExcelChart->set_Name(tmpWChar_tBuff);
               ExcelChart->set_ChartType(xlLine);
               BeginRange="B1";
               EndRange="C"+IntToStr(ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Row);
               Value=xlColumns;
               ExcelChart->SetSourceData(ExcelWorksheetDest->get_Range(BeginRange,EndRange),Value);
               tmpAnsiString=ExcelWorksheetDest->get_Name();
               Value=tmpAnsiString;
               ExcelChart->ConnectTo(ExcelChart->Location(xlLocationAsObject,Value));

               tmpAnsiString="Chart";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               ExcelChart->set_Name(tmpWChar_tBuff);

               SeriesCollection
                 *SC;

               SC=(SeriesCollection *)ExcelChart->SeriesCollection(EmptyParam,TDefLCID());

               Series
                 *NewSeries=SC->NewSeries();

               BeginRange="A1";
               EndRange="A"+IntToStr(ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Row);
               Range=(LPDISPATCH)ExcelWorksheetDest->get_Range(BeginRange,EndRange);
               for(tmpLong=SC->get_Count(); tmpLong>0; --tmpLong)
                  {
                     Value=tmpLong;
                     SC->Item(Value)->set_XValues(Range);
                     switch(tmpLong)
                       {
                          case 1 :
                            {
                               tmpAnsiString="sin";
                               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
                               SC->Item(Value)->set_Name(tmpWChar_tBuff);

                               break;
                            }
                          case 2 :
                            {
                               tmpAnsiString="cos";
                               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
                               SC->Item(Value)->set_Name(tmpWChar_tBuff);

                               break;
                            }
                       }
                  }

               BeginRange="D1";
               EndRange="D"+IntToStr(ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Row);
               Range=(LPDISPATCH)ExcelWorksheetDest->get_Range(BeginRange,EndRange);
               NewSeries->set_Values(Range);
               tmpAnsiString="sin+cos";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               NewSeries->set_Name(tmpWChar_tBuff);

               ExcelChart->set_HasTitle(TDefLCID(),true);
               tmpAnsiString=ExcelChart->get_ChartTitle(TDefLCID())->get_Characters()->get_Text();
               tmpAnsiString="Name of Chart";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               ExcelChart->get_ChartTitle(TDefLCID())->get_Characters()->set_Text(tmpWChar_tBuff);

               //tmpAnsiString="Name of Text";
               //tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               //ExcelChart->get_ChartTitle(TDefLCID())->set_Text(tmpWChar_tBuff);

               //tmpAnsiString="Name of Caption";
               //tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               //ExcelChart->get_ChartTitle(TDefLCID())->set_Caption(tmpWChar_tBuff);

               Value=xlCategory;

               Axis
                 *A=(Axis *)ExcelChart->Axes(Value,xlPrimary,TDefLCID());

               tmpAnsiString="Name of Category";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               A->set_HasTitle(true);
               A->get_AxisTitle()->get_Characters()->set_Text(tmpWChar_tBuff);

               Value=xlValue;
               A=(Axis *)ExcelChart->Axes(Value,xlPrimary,TDefLCID());
               tmpAnsiString="Name of Value";
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
               A->set_HasTitle(true);
               A->get_AxisTitle()->get_Characters()->set_Text(tmpWChar_tBuff);

               ExcelChart->set_HasLegend(TDefLCID(),true);
               ExcelChart->get_Legend(TDefLCID())->set_Position(xlBottom);

               tmpAnsiString=ExtractFilePath(Application->ExeName)+"chart_out.xls";
               if(FileExists(tmpAnsiString))
                 DeleteFile(tmpAnsiString);
               Value=tmpAnsiString;
               ExcelWorkbookDest->SaveAs(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());
               ExcelWorksheetDest->Disconnect();
               ExcelWorkbookDest->Close();
               ExcelWorkbookDest->Disconnect();
             #endif

             ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
             ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->ActiveSheet);
             tmpAnsiString=ExcelWorksheetDest->get_Name();
             tmpAnsiString+=tmpAnsiString;
             if(tmpAnsiString.WideCharBufSize()<=tmpWChar_tBuffSize)
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
             else
               {
                  tmpAnsiString="Size of \""+tmpAnsiString+"\" is greater than buffer's size";
                  throw Exception(tmpAnsiString);
               }
             ExcelWorksheetDest->set_Name(tmpWChar_tBuff);
             tmpAnsiString="Страница &P из &N";
             if(tmpAnsiString.WideCharBufSize()<=tmpWChar_tBuffSize)
               tmpAnsiString.WideChar(tmpWChar_tBuff,tmpWChar_tBuffSize);
             else
               {
                  tmpAnsiString="Size of \""+tmpAnsiString+"\" is greater than buffer's size";
                  throw Exception(tmpAnsiString);
               }
             ExcelWorksheetDest->get_PageSetup()->set_RightHeader(tmpWChar_tBuff);
             tmpAnsiString="";

             for(int Col=1; Col<100; ++Col)
                {
                   aBeginRange="A"+IntToStr(Col);
                   aEndRange=aBeginRange;
                   aValue=aBeginRange;

                   BeginRange="A"+IntToStr(Col); //aBeginRange;
                   EndRange="A"+IntToStr(Col); //aEndRange;
                   Value="A"+IntToStr(Col); //aValue;

                   ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
                }

             BeginRange="A1";
             EndRange="D1";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_EntireColumn()->set_ColumnWidth((TVariant)25);

             BeginRange="E2";
             EndRange="E2";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_Columns()->set_ColumnWidth((TVariant)50);

             BeginRange="B1";
             EndRange="B99";
             Value="B1:B99";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);

             BeginRange="C1";
             EndRange="C99";
             Value="C1:C99";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->set_Value(Value);
             Value=true;
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_Font()->set_Bold(Value);

             BeginRange="A3";
             EndRange="A3";
             Value=xlToLeft;
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Delete(Value);

             BeginRange="A5";
             EndRange="A5";
             Value=xlUp;
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->Delete(Value);

             BeginRange="B1";
             EndRange="B1";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_EntireColumn()->Delete();

             BeginRange="A1";
             EndRange="A1";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_EntireRow()->Delete();

             BeginRange="A10";
             EndRange="B10";
             ExcelWorksheetDest->get_Range(BeginRange,EndRange)->get_EntireRow()->Delete(TVariant(xlShiftUp));

             long
               CountRow=ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Row,
               CountCol=ExcelWorksheetDest->Cells->SpecialCells(xlCellTypeLastCell)->Column;

             tmpAnsiString=IntToStr(CountRow)+" "+IntToStr(CountCol);
             tmpAnsiString=ExtractFilePath(Application->ExeName)+"4_test.xls";
             if(FileExists(tmpAnsiString))
               DeleteFile(tmpAnsiString);
             Value=tmpAnsiString;
             ExcelWorkbookDest->SaveAs(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());
             ExcelWorksheetDest->Disconnect();
             ExcelWorkbookDest->Close();
             ExcelWorkbookDest->Disconnect();

             Value=ExcelFileNameSrc; // VType == 256U == 0x0100 == varString
             ExcelWorkbookSrc->ConnectTo(ExcelApplication->Workbooks->Open(Value,EmptyParam,EmptyParam,EmptyParam,EmptyParam, EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID()));
             Value=2;
             ExcelWorksheetSrc->ConnectTo(ExcelWorkbookSrc->Sheets->get_Item(Value));
             ExcelWorksheetSrc->get_PageSetup()->set_RightHeader(tmpWChar_tBuff);
             ExcelWorkbookSrc->Save();

             /*
             BeginRange="D2";
             EndRange="E9";
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Copy();

             ExcelWorkbookDest->ConnectTo(ExcelApplication->Workbooks->Add());
             tmpVariant=1;
             ExcelWorksheetDest->ConnectTo(ExcelWorkbookDest->Sheets->get_Item(tmpVariant));
             tmpVariant="B2";
             //ExcelWorksheetDest->get_Range(tmpVariant,tmpVariant)->set_WrapText(Variant(true));
             ExcelWorksheetDest->get_Range(tmpVariant,tmpVariant)->Select();
             ExcelWorksheetDest->Paste();

             tmpVariant=ExcelFileNameDest;
             tmpVariant.ChangeType(varOleStr);
             //tmpVariant="D:\\My_Doc\\CBuilder\\Tests\\MSOffice\\Excel.Srv\\out_out.xls";
             ExcelWorkbookDest->SaveAs(tmpVariant,EmptyParam,EmptyParam,EmptyParam,EmptyParam,EmptyParam,xlNoChange,EmptyParam,EmptyParam,EmptyParam,EmptyParam,TDefLCID());

             bool Saved=ExcelWorkbookDest->get_Saved(TDefLCID());

             if(!Saved)
               ShowMessage(ExcelFileNameDest+" wasn't saved");

             ExcelWorksheetDest->Disconnect();
             ExcelWorkbookDest->Close();
             ExcelWorkbookDest->Disconnect();

             tmpVariant=1;
             ExcelWorksheetSrc->ConnectTo(ExcelWorkbookSrc->Sheets->get_Item(tmpVariant));
             tmpVariant="A10";
             ExcelWorksheetSrc->get_Range(tmpVariant,tmpVariant)->set_Value(tmpVariant);

             Variant Key2,Key3,SortType,OrderCustom,MatchCase;

             tmpVariant="D1";
             BeginRange="D1";
             EndRange="D10";
             //SortType=xlSortLabels;
             //SortType=xlSortValues;
             SortType=0;
             OrderCustom=1;
             MatchCase=false;
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,EmptyParam,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,EmptyParam,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlPinYin);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,EmptyParam,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,EmptyParam,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlPinYin);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,SortType,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,SortType,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlPinYin);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,SortType,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,EmptyParam,SortType,xlAscending,EmptyParam,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlPinYin);

             tmpVariant="D1";
             Key2="E1";
             SortType=xlSortValues;
             Key3="F1";
             BeginRange="D1";
             EndRange="F10";
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlPinYin);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlStroke);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlPinYin);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlTopToBottom);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortColumns,xlTopToBottom);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlTopToBottom);
             ExcelWorksheetSrc->get_Range(BeginRange,EndRange)->Sort(tmpVariant,xlAscending,Key2,SortType,xlAscending,Key3,xlAscending,xlGuess,OrderCustom,MatchCase,xlSortRows,xlTopToBottom);
             */
          }
        catch(EOleException &e)
          {
             tmpAnsiString=e.ClassName();
             tmpAnsiString+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
          }
        catch(EOleSysError &e)
          {
             tmpAnsiString=e.ClassName();
             tmpAnsiString+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
          }
        catch(EOleError &e)
          {
             tmpAnsiString=e.ClassName();
             tmpAnsiString+=" Error: "+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
          }
        catch(EOleCtrlError &e)
          {
             tmpAnsiString=e.ClassName();
             tmpAnsiString+=" Error: "+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
          }
        catch(Exception &eException)
          {
             tmpAnsiString=eException.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
          }
     }
   __finally
     {
        if(ExcelChart)
          {
             delete ExcelChart;
             ExcelChart=0;
          }

        if(ExcelWorksheetSrc)
          {
             delete ExcelWorksheetSrc;
             ExcelWorksheetSrc=0;
          }
        if(ExcelWorksheetDest)
          {
             delete ExcelWorksheetDest;
             ExcelWorksheetDest=0;
          }

        if(ExcelWorkbookSrc)
          {
             delete ExcelWorkbookSrc;
             ExcelWorkbookSrc=0;
          }
        if(ExcelWorkbookDest)
          {
             delete ExcelWorkbookDest;
             ExcelWorkbookDest=0;
          }

        if(ExcelApplication)
          {
             delete ExcelApplication;
             ExcelApplication=0;
          }

        if(tmpWChar_tBuff)
          {
             delete []tmpWChar_tBuff;
             tmpWChar_tBuff=0;
          }
     }
}
//---------------------------------------------------------------------------

/*
typedef enum XlSortMethod
{
  xlPinYin = 1,
  xlStroke = 2
} XlSortMethod;

typedef enum XlSortMethodOld
{
  xlCodePage = 2,
  xlSyllabary = 1
} XlSortMethodOld;

typedef enum XlSortOrder
{
  xlAscending = 1,
  xlDescending = 2
} XlSortOrder;

typedef enum XlSortOrientation
{
  xlSortRows = 2,
  xlSortColumns = 1
} XlSortOrientation;

typedef enum XlSortType
{
  xlSortLabels = 2,
  xlSortValues = 1
} XlSortType;

typedef enum XlYesNoGuess
{
  xlGuess = 0,
  xlNo = 2,
  xlYes = 1
} XlYesNoGuess;

typedef enum XlDirection
{
  xlDown = 0xFFFFEFE7,
  xlToLeft = 0xFFFFEFC1,
  xlToRight = 0xFFFFEFBF,
  xlUp = 0xFFFFEFBE
} XlDirection;

typedef enum XlDeleteShiftDirection
{
  xlShiftToLeft = 0xFFFFEFC1,
  xlShiftUp = 0xFFFFEFBE
} XlDeleteShiftDirection;

*/
