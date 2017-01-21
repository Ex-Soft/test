//---------------------------------------------------------------------------

#include <vcl.h>
#include <comobj.hpp>
#pragma hdrstop

#include "Word_2K_SRVR.h"

#include "main.h"

//#define TEST_SELECTION
//#define TEST_IF
#define TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION
//#define TEST_PRINT
//#define TEST_HEADERS_FOOTERS
//#define TEST_TABLES
//#define TEST_CUSTOM_DOCUMENT_PROPERTIES
//#define TEST_BUILTIN_DOCUMENT_PROPERTIES
//#define TEST_FIND
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::WordBasicButtonClick(TObject *Sender)
{
   Variant
     MSWord;

   float
     cm=Edit1->Text.ToDouble(); //CentimetersToPoints(2)

   AnsiString
     CurrDir=ExtractFilePath(Application->ExeName),
     SignatureDoc=CurrDir+"Word_tst.doc",
     OutputDoc=CurrDir+"Word_out.doc";

   try
     {
        MSWord=CreateOleObject("Word.Basic");
     }
   catch(...)
     {
        Application->MessageBox("Помилка Microsoft Word. Спробуйте закрити програму та запустити її знову.\nЯкщо помилка не зникне, зверніться до фірми Microsoft.",Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   try
     {
        MSWord.Exec(Procedure("FileOpen")<<SignatureDoc);
     }
   catch(...)
     {
        Application->MessageBox((AnsiString("Помилка відкриття файлу '") + SignatureDoc + "'.\nПеревірте його існування.").c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

//   MSWord.Exec(Procedure("AppShow"));

   MSWord.Exec(Procedure("FilePrint"));

   MSWord.Exec(Procedure("FileSaveAs")<<OutputDoc);

   MSWord.Exec(Procedure("FilePageSetup")<<NamedParm("TopMargin",wdCentimeters)<<NamedParm("Value",5));
   MSWord.Exec(Procedure("FileSave"));
   MSWord.Exec(Procedure("FileClose"));
   MSWord.Exec(Procedure("AppClose"));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TWordApplicationButtonClick(TObject *Sender)
{
   AnsiString CurrDir=GetCurrentDir();
   TVariant NameSrc=CurrDir+"\\Word_tst.doc";
   TVariant NameDst=CurrDir+"\\Word_out.doc";
   float sm=1.6/0.035281;

   TWordApplication *WordApplication = new TWordApplication(0);
   WordApplication->Connect();
   WordApplication->Options->CheckSpellingAsYouType = False;
   WordApplication->Options->CheckGrammarAsYouType = False;
   WordApplication->Documents->OpenOld(&NameSrc);
   TWordDocument *WordDocument = new TWordDocument(0);
   WordDocument->ConnectTo(WordApplication->ActiveDocument);
   WordDocument->PageSetup->set_TopMargin(sm);
   WordDocument->SaveAs(&NameDst);
   WordApplication->set_Visible(1);
   if(WordDocument)
     delete WordDocument;
   if(WordApplication)
     delete WordApplication;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::WordApplicationButtonClick(TObject *Sender)
{
   Variant
     MSWord=Unassigned,
     Documents,
     Document,
     Bookmarks,
     Bookmark,
     Range,
     BuiltInDocumentProperties,
     BuiltInDocumentProperty,
     CustomDocumentProperties,
     CustomDocumentProperty,
     Tables,
     Table,
     Cell,
     Value,
     ActiveWindow,
     ActivePane,
     Selection;

   AnsiString
     Mess,
     CurrDir=ExtractFilePath(Application->ExeName),
     SignatureDoc,
     OutputDoc=CurrDir+"Word_out.doc";

   int
     Count;

   bool
     tmpBool;

   try
     {
        try
        {
           MSWord=Variant::GetActiveObject("Word.Application");
        }
        catch(EOleSysError &e)
        {
           if(e.ErrorCode==-2147221021L)
             MSWord=CreateOleObject("Word.Application");
           else
             throw;
        }

        if(MSWord.IsEmpty())
          Mess="MSWord.IsEmpty()";
        if(MSWord.IsNull())
          Mess="MSWord.IsNull()";

        MSWord.OlePropertySet("Visible",(Variant)true);
        MSWord.OlePropertySet("DisplayAlerts",0 /*wdAlertsNone */);

        Documents=MSWord.OlePropertyGet("Documents");

        #if defined(TEST_TABLES)
           Document=Documents.OleFunction("Add");
           Tables=Document.OlePropertyGet("Tables");
           Table=Tables.OleFunction("Add",MSWord.OlePropertyGet("Selection").OlePropertyGet("Range"),5,5);
           Value=Table.OlePropertyGet("Rows").OlePropertyGet("Count");
           Cell=Table.OleFunction("Cell",2,2);
           Cell.OleProcedure("Merge",Table.OleFunction("Cell",4,4));
           Document.OleFunction("Close");
        #endif
        
        #if defined(TEST_IF)
           SignatureDoc=CurrDir+"Test_IF.doc";
           Document=Documents.OleFunction("Open",(TVariant)SignatureDoc);
           Bookmarks=Document.OlePropertyGet("Bookmarks");
           MSWord.OlePropertyGet("Selection").OleProcedure("GoTo",0xFFFFFFFF,EmptyParam,EmptyParam,"Test");
           Range=MSWord.OlePropertyGet("Selection");
           Range.OlePropertySet("Text","1234567890");
           //MSWord.OlePropertyGet("Selection").OleProcedure("GoTo",7 /* wdGoToField */,EmptyParam,EmptyParam,"Test");
           Bookmarks=Document.OlePropertyGet("Fields");
           Bookmark=Bookmarks.OleFunction("Item",(Variant)1);
           //Bookmark.OleProcedure("Select");
           Bookmark.OleProcedure("Update");
           Document.OleFunction("Close");
        #endif

        SignatureDoc=CurrDir+"Word_tst.doc";
        Document=Documents.OleFunction("Open",(TVariant)SignatureDoc);

        #if defined(TEST_SELECTION)
           Range=Document.OleFunction("Range",2,4);
           Range.OleProcedure("Select");
       #endif

        #if defined(TEST_FIND)
           Selection=MSWord.OlePropertyGet("Selection");
           Range=Selection.OlePropertyGet("Find");
           Value=Range.OleFunction("Execute", /* FindText= */ "4", /* MatchCase= */ true, /* MatchWholeWord= */ false, /* MatchWildcards= */ false, /* MatchSoundsLike= */ false, /* MatchAllWordForms= */ false, /* Forward= */ true, /* Wrap= wdFindContinue */ wdFindContinue /* 0 */, /* Format= */ false, /* ReplaceWith= */ "", /* Replace= */ wdReplaceAll /* 0 */);
           tmpBool=Value;
        #endif

        #if defined(TEST_HEADERS_FOOTERS)
           ActiveWindow=MSWord.OlePropertyGet("ActiveWindow");
           Value=ActiveWindow.OlePropertyGet("View").OlePropertyGet("SplitSpecial");
           if(Value!=wdPaneNone /* 0 */)
             ActiveWindow.OlePropertyGet("Panes").OleFunction("Item",2).OleProcedure("Close");
           ActivePane=ActiveWindow.OlePropertyGet("ActivePane");
           Value=ActivePane.OlePropertyGet("View").OlePropertyGet("Type");
           if(Value==wdNormalView /* 1 */
              || Value==wdOutlineView /* 2 */
              || Value==wdMasterView /* 5 */)
             ActivePane.OlePropertyGet("View").OlePropertySet("Type",wdPageView /* 3 */);
           ActivePane.OlePropertyGet("View").OlePropertySet("SeekView",wdSeekCurrentPageHeader /* 9 */);
           Selection=MSWord.OlePropertyGet("Selection");
           Selection.OlePropertyGet("Fields").OleFunction("Add",Selection.OlePropertyGet("Range"),wdFieldPage /* 33 */);
           Selection.OlePropertyGet("ParagraphFormat").OlePropertySet("Alignment",wdAlignParagraphCenter /* 1 */);
           Selection.OleProcedure("TypeText"," ");
           Selection.OlePropertyGet("Fields").OleFunction("Add",Selection.OlePropertyGet("Range"),wdFieldNumPages /* 26 */);
           ActivePane.OlePropertyGet("View").OlePropertySet("SeekView",wdSeekMainDocument /* 0 */);
        #endif

        Value=Documents.OlePropertyGet("Count");

        int
          _Count_=Value;

        for(int i=1; i<=_Count_; ++i)
        {
           Document=Documents.OleFunction("Item",i);
           Value=Document.OlePropertyGet("FullName");
           Document.OleProcedure("Activate");
        }

        float
          c2p=10;

        try
        {
           c2p=MSWord.OleFunction("CentimetersToPoints",c2p);
           Document.OlePropertyGet("PageSetup").OlePropertySet("TopMargin",c2p);
        }
        catch(EOleSysError &e)
        {
           if(e.ErrorCode==-2147467259L)
             Mess="Fucking M$ Word!!! Ж8-/ \"For some reason these routines don't seem to work with late binding. There is no problem if you call them with an early-bound _Application-type variable.\" (http://www.djpate.freeserve.co.uk/WordPrbs.htm)";
           else
             throw;
        }
        #if defined(TEST_BUILTIN_DOCUMENT_PROPERTIES)
        BuiltInDocumentProperties=Document.OlePropertyGet("BuiltInDocumentProperties");
        Range=BuiltInDocumentProperties.OlePropertyGet("Count");

        int
          Count=(int)Range;

        MsoDocProperties
          PropertiesType;

        Mess="";
        for(int i=0; i<=Count; ++i)
        {
           if(!Mess.IsEmpty())
             Mess+="\n";

           BuiltInDocumentProperty=BuiltInDocumentProperties.OlePropertyGet("Item",i);
           Range=BuiltInDocumentProperty.OlePropertyGet("Name");
           Mess+=AnsiString(Range)+"=";
           Range=BuiltInDocumentProperty.OlePropertyGet("Type");
           PropertiesType=(Office_2k::MsoDocProperties)((int)Range);
           Range=BuiltInDocumentProperty.OlePropertyGet("Value");
           switch(PropertiesType)
           {
              case msoPropertyTypeNumber :
              {
                 Mess+=IntToStr((__int64)Range)+" (Type=msoPropertyTypeNumber)";
                 break;
              }
              case msoPropertyTypeBoolean :
              {
                 Mess+=BoolToStr((bool)Range,true)+" (Type=msoPropertyTypeBoolean)";
                 break;
              }
              case msoPropertyTypeDate :
              {
                 Mess+=TDateTime(Range).DateTimeString()+" (Type=msoPropertyTypeDate)";
                 break;
              }
              case msoPropertyTypeString :
              {
                 Mess+=AnsiString(Range)+" (Type=msoPropertyTypeString)";
                 break;
              }
              case msoPropertyTypeFloat :
              {
                 Mess+=FloatToStr((double)Range)+" (Type=msoPropertyTypeFloat)";
                 break;
              }
           }
        }
        #endif

        #if defined(TEST_CUSTOM_DOCUMENT_PROPERTIES)
        CustomDocumentProperties=Document.OlePropertyGet("CustomDocumentProperties");
        Range=CustomDocumentProperties.OlePropertyGet("Count");

        int
          Count=(int)Range;

        MsoDocProperties
          PropertiesType;

        Mess="";
        for(int i=1; i<=Count; ++i)
        {
           if(!Mess.IsEmpty())
             Mess+="\n";

           CustomDocumentProperty=CustomDocumentProperties.OlePropertyGet("Item",i);
           Range=CustomDocumentProperty.OlePropertyGet("Name");
           Mess+=AnsiString(Range)+"=";
           Range=CustomDocumentProperty.OlePropertyGet("Type");
           PropertiesType=(Office_2k::MsoDocProperties)((int)Range);
           Range=CustomDocumentProperty.OlePropertyGet("Value");
           switch(PropertiesType)
           {
              case msoPropertyTypeNumber :
              {
                 Mess+=IntToStr((__int64)Range)+" (Type=msoPropertyTypeNumber)";
                 break;
              }
              case msoPropertyTypeBoolean :
              {
                 Mess+=BoolToStr((bool)Range,true)+" (Type=msoPropertyTypeBoolean)";
                 break;
              }
              case msoPropertyTypeDate :
              {
                 Mess+=TDateTime(Range).DateTimeString()+" (Type=msoPropertyTypeDate)";
                 break;
              }
              case msoPropertyTypeString :
              {
                 Mess+=AnsiString(Range)+" (Type=msoPropertyTypeString)";
                 break;
              }
              case msoPropertyTypeFloat :
              {
                 Mess+=FloatToStr((double)Range)+" (Type=msoPropertyTypeFloat)";
                 break;
              }
           }
        }
        #endif

        Bookmarks=Document.OlePropertyGet("Bookmarks");
        //Bookmarks.OleFunction("Add","AddedBookmark");
        Range=Bookmarks.OlePropertyGet("Count");
        if(Count=int(Range))
          {
             Range=Bookmarks.OleFunction("Exists","MyBookmark");

             bool
               Exists=bool(Range);

             if(Exists)
               {
                  #if defined(TEST_BOOKMARK_BY_BOOKMARKS_COLLECTION)
                    Bookmark=Bookmarks.OleFunction("Item",StringToOleStr("MyBookmark"));
                    // ||
                    //Bookmark=Bookmarks.OleFunction("Item",(Variant)1);
                    Range.Clear();
                    Range=Bookmark.OlePropertyGet("Name");
                    Mess=AnsiString(Range);
                    Bookmark.OleProcedure("Select");
                  #else
                    MSWord.OlePropertyGet("Selection").OleProcedure("GoTo",/*What*/ 0xFFFFFFFF /*wdGoToBookmark*/, /*Which*/ EmptyParam, /*Count*/ EmptyParam, /*Name*/ "MyBookmark");
                  #endif

                  Range=MSWord.OlePropertyGet("Selection");
                  Range.OlePropertySet("Text","1234567890");
               }
          }

        MSWord.OlePropertyGet("Selection").OleFunction("EndKey",6 /*wdStory*/);
        Range=MSWord.OlePropertyGet("Selection").OlePropertyGet("Range");
        // ||
        // Range=Document.OleFunction("Range",0,0);
        Tables=Document.OlePropertyGet("Tables");
        Tables.OleFunction("Add",Range,3,5);
        Table=Tables.OleFunction("Item",1);
        Cell=Table.OleFunction("Cell",2,2);
        Cell.OlePropertyGet("Range").OlePropertySet("Text","Text");
        Cell.OleFunction("SetHeight",20,/* wdRowHeightAuto */ /* wdRowHeightAtLeast */ wdRowHeightExactly);
        Cell.OleFunction("SetWidth",30,/* wdAdjustNone */ /* wdAdjustProportional */ wdAdjustFirstColumn /* wdAdjustSameWidth */         );
        Value=Cell.OlePropertyGet("Range").OlePropertyGet("Text");
        Cell.OlePropertyGet("Borders").OleFunction("Item",0xFFFFFFFD /*wdBorderBottom*/).OlePropertySet("LineStyle",0 /*wdLineStyleNone*/);

        #if defined(TEST_PRINT)
           MSWord.OlePropertyGet("ActiveDocument").OleProcedure("PrintOut", EmptyParam /* Background */, EmptyParam /* Append */, EmptyParam /* Range */, EmptyParam /* OutputFileName */, EmptyParam /* From */, EmptyParam /* To */, EmptyParam /* Item */, EmptyParam /* Copies */, EmptyParam /* Pages */, wdPrintOddPagesOnly /* PageType */, EmptyParam /* PrintToFile */, EmptyParam /* Collate */, EmptyParam /* FileName */, EmptyParam /* ActivePrinterMacGX */); //, EmptyParam /* ManualDuplexPrint */ /* EOleSysError Error code -2147352571 (Type mismatch) */);
        #endif

        Document.OleProcedure("SaveAs",(TVariant)OutputDoc);
        Document.OleFunction("Close");
        MSWord.OleProcedure("Quit");

        Selection.Clear();
        VarClear(Selection);
        Selection=Unassigned;

        ActivePane.Clear();
        VarClear(ActivePane);
        ActivePane=Unassigned;

        ActiveWindow.Clear();
        VarClear(ActiveWindow);
        ActiveWindow=Unassigned;

        Cell.Clear();
        VarClear(Cell);
        Cell=Unassigned;

        Table.Clear();
        VarClear(Table);
        Table=Unassigned;

        Tables.Clear();
        VarClear(Tables);
        Tables=Unassigned;

        BuiltInDocumentProperty.Clear();
        VarClear(BuiltInDocumentProperty);
        BuiltInDocumentProperty=Unassigned;

        BuiltInDocumentProperties.Clear();
        VarClear(BuiltInDocumentProperties);
        BuiltInDocumentProperties=Unassigned;

        CustomDocumentProperty.Clear();
        VarClear(CustomDocumentProperty);
        CustomDocumentProperty=Unassigned;

        CustomDocumentProperties.Clear();
        VarClear(CustomDocumentProperties);
        CustomDocumentProperties=Unassigned;

        Range.Clear();
        VarClear(Range);
        Range=Unassigned;

        Bookmark.Clear();
        VarClear(Bookmark);
        Bookmark=Unassigned;

        Bookmarks.Clear();
        VarClear(Bookmarks);
        Bookmarks=Unassigned;

        Document.Clear();
        VarClear(Document);
        Document=Unassigned;

        Documents.Clear();
        VarClear(Documents);
        Documents=Unassigned;

        MSWord.Clear();
        VarClear(MSWord);
        MSWord=Unassigned;
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
        Application->MessageBox("Помилка Microsoft Word. Спробуйте закрити програму та запустити її знову.\nЯкщо помилка не зникне, зверніться до фірми Microsoft.",Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

