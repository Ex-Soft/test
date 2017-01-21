//---------------------------------------------------------------------------
/*
Table->Cell(aRow, aCol)->Range->set_Text(WideString(L" "));
WordApplication1->Selection->get_Rows()->set_SpaceBetweenColumns(0);
*/
#include <vcl.h>
#include <new>
#include <StrUtils.hpp>
#pragma hdrstop

#include "main.h"
#include "Word_2K_SRVR.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define TEST_TABLE
//#define TEST_FIND_REPLACE

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
   TWordApplication
     *WordApplication=0;

   TWordDocument
     *WordDocument=0;

   AnsiString
     Mess="",
     tmpAnsiString;

   TVariant
     Text,
     SaveChanges;

   try
     {
        try
          {
             WordApplication=new TWordApplication(0);
             WordDocument=new TWordDocument(0);
          }
        catch(std::bad_alloc)
          {
             if(WordDocument)
               {
                  delete WordDocument;
                  WordDocument=0;
               }
             if(WordApplication)
               {
                  delete WordApplication;
                  WordApplication=0;
               }
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): Insufficient memory");
          }

        try
          {
             WordApplication->ConnectKind=ckNewInstance;
             //WordApplication->AutoQuit=false;
             WordApplication->Connect();
             WordApplication->set_Visible(true);
             WordApplication->Options->CheckSpellingAsYouType=False;
             WordApplication->Options->CheckGrammarAsYouType=False;

             #if defined(TEST_FIND_REPLACE)
               short
                 ReplaceSelectionOrg=WordApplication->Options->ReplaceSelection;

               tmpAnsiString=ExtractFilePath(Application->ExeName)+"test.doc";
               if(FileExists(tmpAnsiString))
               {
                  Text=tmpAnsiString;
                  WordApplication->Documents->OpenOld(&Text);
                  WordDocument->ConnectTo(WordApplication->ActiveDocument);

                  Variant
                    FindText="второй",
                    MatchCase=false,
                    MatchWholeWord=true,
                    Forward=true,
                    Wrap=wdFindContinue,
                    ReplaceWith="послепервый",
                    Replace=wdReplaceAll;

                  WordDocument->Range(EmptyParam,EmptyParam)->Find->ExecuteOld(&FindText,
                                                                               &MatchCase,
                                                                               &MatchWholeWord,
                                                                               TNoParam(),
                                                                               TNoParam(),
                                                                               TNoParam(),
                                                                               &Forward,
                                                                               &Wrap,
                                                                               TNoParam(),
                                                                               &ReplaceWith,
                                                                               &Replace);

                  WordDocument->Close();
                  WordDocument->Disconnect();
               }
               WordApplication->Options->ReplaceSelection=ReplaceSelectionOrg;
             #endif

             #if defined(TEST_TABLE)
               tmpAnsiString=ExtractFilePath(Application->ExeName)+"table_tst.doc";
               if(FileExists(tmpAnsiString))
                 {
                    Text=tmpAnsiString;
                    WordApplication->Documents->OpenOld(&Text);
                    tmpAnsiString=IncludeTrailingPathDelimiter(WordApplication->ActiveDocument->Path);
                    tmpAnsiString+=WordApplication->ActiveDocument->Name;
                    tmpAnsiString=WordApplication->ActiveDocument->FullName;
                    WordDocument->ConnectTo(WordApplication->ActiveDocument);
                    Text=IncludeTrailingPathDelimiter(WordApplication->ActiveDocument->Path)+"table_tst_out.doc";
                    WordDocument->SaveAs(&Text);

                    long
                      CountRows=WordDocument->Tables->Item(1)->get_Rows()->get_Count(),
                      CountColumns=WordDocument->Tables->Item(1)->get_Columns()->get_Count(),
                      Col,
                      Count;

                    Office_2k::DocumentProperties
                      *CustomDocumentProperties=(Office_2k::DocumentProperties *)WordDocument->get_CustomDocumentProperties();

                    //CustomDocumentProperties->get_Count(&Count);
                    /*
                    Office_2k::DocumentProperty
                      *DocumentProperty;

                    wchar_t
                      *tmp_wchar_t;

                    for(long i=0; i<Count; ++i)
                    {
                       CustomDocumentProperties->get_Item(TVariant(i),TDefLCID(),&DocumentProperty);
                       DocumentProperty->get_Name(TDefLCID(),&tmp_wchar_t);
                    }
                    */
                    for(long Row=1; Row<=CountRows; ++Row)
                       for(Col=1; Col<=CountColumns; ++Col)
                          tmpAnsiString=WordDocument->Tables->Item(1)->Cell(Row,Col)->Range->get_Text();

                    Cell
                      *cell=WordDocument->Tables->Item(1)->Cell(1,1);

                    for(Col=0; cell && Col<CountColumns; cell=cell->Next, ++Col)
                       tmpAnsiString=cell->Range->get_Text();

                    tmpAnsiString="";
                    for(cell=WordDocument->Tables->Item(1)->Cell(1,1), Col=0; cell; cell=cell->Next,++Col)
                       {
                          if(Col==CountColumns)
                            {
                               tmpAnsiString+="\n";
                               Col=0;
                            }
                          tmpAnsiString+=AnsiReplaceStr(cell->Range->get_Text(),"\r\a","");
                          if(Col!=CountColumns-1)
                            tmpAnsiString+=", ";
                       }
                    ShowMessage(tmpAnsiString);

                    WordDocument->Close();
                    WordDocument->Disconnect();
                 }
             #endif

             WdAlertLevel
               AlertLevel;

             AlertLevel=WordApplication->get_DisplayAlerts();
             if(AlertLevel!=wdAlertsNone)
               WordApplication->set_DisplayAlerts(wdAlertsNone);

             WordDocument->ConnectTo(WordApplication->Documents->AddOld());

             float
               TopMargin=1;

             WordDocument->PageSetup->set_TopMargin(WordApplication->CentimetersToPoints(TopMargin));
             WordDocument->PageSetup->set_BottomMargin(WordApplication->CentimetersToPoints(1));
             WordDocument->PageSetup->set_LeftMargin(WordApplication->CentimetersToPoints(2.5));
             WordDocument->PageSetup->set_RightMargin(WordApplication->CentimetersToPoints(1));
             WordDocument->PageSetup->set_HeaderDistance(WordApplication->CentimetersToPoints(0));
             WordDocument->PageSetup->set_FooterDistance(WordApplication->CentimetersToPoints(0));
             WordDocument->PageSetup->set_Orientation(wdOrientPortrait);

             WdParagraphAlignment
               ParagraphAlignment;

             int
               PageCount=2,
               ColCount=5,
               RowCount=1;

             AnsiString
               EmptyCellStr="\r\a";

             Cell
               *cell;

             float
               FontSize=8;

             OleVariant
               Start;

             int
               len=0;

             for(int i=0; i<PageCount; ++i)
                {
                   if(!i)
                     {
                        tmpAnsiString="Это простой пример использования таблицы в Word";
                        WordDocument->Range(EmptyParam,EmptyParam)->InsertAfter(StringToOleStr(tmpAnsiString));
                        len+=tmpAnsiString.Length();
                        Start=(OleVariant)len;
                        WordDocument->Tables->AddOld(WordDocument->Range(Start,Start),RowCount,ColCount);
                        WordDocument->Tables->Item(1)->Rows->Add();
                        cell=WordDocument->Tables->Item(1)->Cell(++RowCount,ColCount);
                        tmpAnsiString="["+IntToStr(RowCount)+"]["+IntToStr(ColCount)+"]";
                        cell->set_VerticalAlignment(wdCellAlignVerticalCenter);
                        cell->Range->ParagraphFormat->Alignment=wdAlignParagraphCenter;
                        cell->Range->Font->set_Size(FontSize);
                        cell->Range->set_Text(StringToOleStr(tmpAnsiString));
                        Text=WordApplication->CentimetersToPoints(5);
                        cell->SetHeight(&Text, /* wdRowHeightAuto */ /* wdRowHeightAtLeast */ wdRowHeightExactly);
                        cell->SetWidth(WordApplication->CentimetersToPoints(5),/* wdAdjustNone */ /* wdAdjustProportional */ wdAdjustFirstColumn /* wdAdjustSameWidth */);
                        for(cell=WordDocument->Tables->Item(1)->Cell(1,1); cell; cell=cell->Next)
                           {
                              tmpAnsiString=cell->Range->get_Text();
                              ++len;
                              if(tmpAnsiString!=EmptyCellStr)
                                len+=tmpAnsiString.Length()-EmptyCellStr.Length();
                           }
                        len+=3;
                        Start=(OleVariant)len;
                        WordDocument->Range(Start,Start)->Select();

                        tmpAnsiString="Это простой пример использования таблицы в Word #2";
                        WordDocument->Range(EmptyParam,EmptyParam)->InsertAfter(StringToOleStr(tmpAnsiString));
                        len+=tmpAnsiString.Length();
                        Start=(OleVariant)len;

                        Table
                          *table_ptr=WordDocument->Tables->AddOld(WordDocument->Range(Start,Start),RowCount,ColCount);

                        table_ptr->Cell(1,1)->Select();

                        WordApplication->Selection->TypeText(TVariant("[1][1] QWERTY ASDFGH"));
                        table_ptr->Cell(1,1)->Range->Words->Item(1)->Bold=true;
                        WordApplication->Selection->EndOf(TVariant(wdTable),TVariant(wdMove));
                        WordApplication->Selection->TypeText(TVariant("EndOf(wdTable,wdMove)"));
                        WordApplication->Selection->EndKey(TVariant(wdStory/*wdTable*/),EmptyParam);
                        WordApplication->Selection->TypeText(TVariant("EndKey(wdStory,EmptyParam)"));
                     }

                   ParagraphAlignment=wdAlignParagraphCenter;
                   Text="Paragraph #1";
                   WordApplication->Selection->TypeText(Text);
                   WordApplication->Selection->ParagraphFormat->Alignment=ParagraphAlignment;
                   WordApplication->Selection->TypeParagraph();

                   ParagraphAlignment=wdAlignParagraphLeft;
                   Text="Paragraph #2";
                   WordApplication->Selection->TypeText(Text);
                   WordApplication->Selection->ParagraphFormat->Alignment=ParagraphAlignment;
                   WordApplication->Selection->TypeParagraph();

                   WordApplication->Selection->Font->Size=20;
                   WordApplication->Selection->TypeParagraph();

                   WordApplication->Selection->Font->Size=10;
                   ParagraphAlignment=wdAlignParagraphRight;
                   Text="Paragraph #3";
                   WordApplication->Selection->TypeText(Text);
                   WordApplication->Selection->ParagraphFormat->Alignment=ParagraphAlignment;

                   if(i < PageCount-1)
                     {
                        Text=wdPageBreak;
                        WordApplication->Selection->InsertBreak(&Text);
                     }
                 }

             SaveChanges=false;
             WordDocument->Close(&SaveChanges);
             WordDocument->Disconnect();

             WordApplication->Quit(&SaveChanges);
             WordApplication->Disconnect();
          }
        catch(EOleException &e)
          {
             Mess+=e.ClassName();
             Mess+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+Mess);
          }
        catch(EOleSysError &e)
          {
             Mess+=e.ClassName();
             Mess+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+Mess);
          }
        catch(EOleError &e)
          {
             Mess+=e.ClassName();
             Mess+=" Error: "+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+Mess);
          }
        catch(EOleCtrlError &e)
          {
             Mess+=e.ClassName();
             Mess+=" Error: "+e.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+Mess);
          }
        catch(Exception &eException)
          {
             Mess+=eException.Message;
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+Mess);
          }
     }
   __finally
     {
        if(WordDocument)
          {
             delete WordDocument;
             WordDocument=0;
          }
        if(WordApplication)
          {
             delete WordApplication;
             WordApplication=0;
          }
     }
}
//---------------------------------------------------------------------------

