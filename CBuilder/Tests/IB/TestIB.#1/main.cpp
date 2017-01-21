//---------------------------------------------------------------------------

#include <vcl.h>
#include <time.h>
#include <DateUtils.hpp>

//#define __TEST_IBQUERY2EXCEL__

#if defined(__TEST_IBQUERY2EXCEL__)
   #include <comobj.hpp>
#endif

#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define __IBX_INTERNAL_DBKEY__
//#define __TEST_IBQUERY__
//#define __TEST_IBQUERY_WITH_LIKE_WITH_PARAM__
//#define BLOB_SAVE
//#define BLOB_LOAD
//#define __TEST_IBSTOREDPROC__
//#define TEST_COMMENT
#define TEST_OPEN_ACTIVE_QUERY

extern void __fastcall CloseIB(void);

unsigned long __fastcall ToHash(int Cnt, int Inst, int Nd, int Yr, int Kd, int Br, int Ct, int Cr);
void __fastcall FromHash(unsigned long Key, int &Cnt, int &Inst, int &Nd, int &Yr, int &Kd, int &Br, int &Ct, int &Cr);
void __fastcall ListByIBTable(void);
void __fastcall ListByIBQuery(void);
void __fastcall ListByIBSQL(void);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   DataBaseEdit->Text=ExtractFilePath(Application->ExeName)+"Test.gdb";
   PageControl->ActivePage=DatabaseTabSheet;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::OpenButtonClick(TObject *Sender)
{
   DataBases->IBDatabase->DatabaseName=(!ServerEdit->Text.IsEmpty() ? ServerEdit->Text+":" : AnsiString(""))+DataBaseEdit->Text;
   DataBases->IBDatabase->LoginPrompt=false;
   DataBases->IBDatabase->DefaultTransaction=DataBases->IBTransaction1;

   DataBases->IBDatabase->Params->Clear();
   for(int i=0;i<DataBaseMemo->Lines->Count;i++)
      DataBases->IBDatabase->Params->Add(DataBaseMemo->Lines->Strings[i]);

   try
     {
        DataBases->IBDatabase->Open();
     }
   catch(EIBError &eException)
     {
        AnsiString tmp="Can\'t open database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Can\'t open database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   DataBases->IBDatabase->SQLDialect=DataBases->IBDatabase->DBSQLDialect;

   DataBases->IBTransaction1->DefaultDatabase=DataBases->IBDatabase;
   DataBases->IBTransaction2->DefaultDatabase=DataBases->IBDatabase;

   DataBases->IBSQL1->Database=DataBases->IBDatabase;
   DataBases->IBSQL1->Transaction=DataBases->IBTransaction1;
   DataBases->IBSQL2->Database=DataBases->IBDatabase;
   DataBases->IBSQL2->Transaction=DataBases->IBTransaction2;

   DataBases->IBStoredProc1->Database=DataBases->IBDatabase;
   DataBases->IBStoredProc1->Transaction=DataBases->IBTransaction1;
   DataBases->IBStoredProc2->Database=DataBases->IBDatabase;
   DataBases->IBStoredProc2->Transaction=DataBases->IBTransaction2;

   DataBases->IBQuery->Database=DataBases->IBDatabase;
   DataBases->IBQuery->Transaction=DataBases->IBTransaction1;

   DataBases->IBTable->Database=DataBases->IBDatabase;
   DataBases->IBTable->TableName="TestDataTypes";
   DataBases->IBTable->Transaction=DataBases->IBTransaction1;

   DataBases->IBTableDBF->Database=DataBases->IBDatabase;
   DataBases->IBTableDBF->TableName="TestDBF";
   DataBases->IBTableDBF->Transaction=DataBases->IBTransaction1;

   OpenButton->Enabled=false;
   CloseButton->Enabled=true;

   GetIBDatabaseInfoButton->Enabled=true;

   StartButton1->Enabled=true;
   StartButton2->Enabled=true;

   ExecSP1Button->Enabled=true;
   ExecSP2Button->Enabled=true;

   FillTableCertifErsatz->Enabled=true;
   FillTableCertifHash->Enabled=true;
   SelectFromCertifErsatz->Enabled=true;
   SelectFromCertifHash->Enabled=true;

   DoReadDatatypesButton->Enabled=true;

//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
   AnsiString
     SQLBody;

#if defined (__TEST_IBSTOREDPROC__)
   DataBases->IBSQL1->SQL->Text="select * from \"sp_Staff_N\"(:MaxCount)";
   if(!DataBases->IBSQL1->Transaction->InTransaction)
     DataBases->IBSQL1->Transaction->StartTransaction();
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ParamByName("MaxCount")->AsInteger=2;
   DataBases->IBSQL1->ExecQuery();
   for(; !DataBases->IBSQL1->Eof; DataBases->IBSQL1->Next())
      if(!DataBases->IBSQL1->FieldByName("Name")->IsNull)
        SQLBody=DataBases->IBSQL1->FieldByName("Name")->AsString;
   DataBases->IBSQL1->Close();
   DataBases->IBSQL1->Transaction->Rollback();
#endif

#if defined (__IBX_INTERNAL_DBKEY__)
   SQLBody="\
select t.*, t.RDB$DB_KEY as IBX_INTERNAL_DBKEY \
from \"Insurant\" t \
order by t.\"CentId\", t.\"InstId\", t.\"NodeId\", t.\"PersonId\"\
";
   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   DataBases->IBTransaction1->StartTransaction();
   DataBases->IBSQL1->ExecQuery();

   int
     SQLType;

   for(; !DataBases->IBSQL1->Eof; DataBases->IBSQL1->Next())
      {
         SQLType=DataBases->IBSQL1->FieldByName("IBX_INTERNAL_DBKEY")->SQLType;
         switch(SQLType)
           {
              case SQL_TEXT :
                {
                   SQLBody=DataBases->IBSQL1->FieldByName("IBX_INTERNAL_DBKEY")->AsTrimString;
                }
           }
      }
   DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Rollback();
#endif

   bool
     TrIsActive=false;

#if defined(__TEST_IBQUERY__)
   SQLBody="\
select * \
from \"Insurant\" \
where \
(\"CentId\" = :\"CentId\") and \
(\"InstId\" = :\"InstId\") and \
(\"NodeId\" = :\"NodeId\") and \
(\"PersonId\" = :\"PersonId\")\
";

   if(!(TrIsActive=DataBases->IBQuery->Transaction->InTransaction))
     DataBases->IBQuery->Transaction->StartTransaction();

   if(DataBases->IBQuery->Active)
     DataBases->IBQuery->Close();

   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);
   if(!DataBases->IBQuery->Prepared)
     DataBases->IBQuery->Prepare();

   TParamType
     ParamType;

   Db::TFieldType
     DataType;

   TParam
     *Param;

   for(int i=0; i<DataBases->IBQuery->ParamCount; ++i)
      {
         Param=DataBases->IBQuery->Params->Items[i];
         ParamType=Param->ParamType;
         DataType=Param->DataType;
      }

   DataBases->IBQuery->ParamByName("CentId")->AsSmallInt=1;
   DataBases->IBQuery->ParamByName("InstId")->AsSmallInt=1;
   DataBases->IBQuery->ParamByName("NodeId")->AsSmallInt=1;
   DataBases->IBQuery->ParamByName("PersonId")->AsSmallInt=1;

   AnsiString
     FieldsList="";

   DataBases->IBQuery->Open();
   if(!DataBases->IBQuery->Eof)
     for(int i=0; i<DataBases->IBQuery->Fields->Count; ++i)
        {
           if(!FieldsList.IsEmpty())
             FieldsList+=" ";
           FieldsList+=DataBases->IBQuery->Fields->Fields[i]->FieldName;
        }

   DataBases->IBQuery->Close();
   DataBases->IBQuery->Transaction->Rollback();

   if(TrIsActive)
     DataBases->IBQuery->Transaction->StartTransaction();

   if(!(TrIsActive=DataBases->IBSQL1->Transaction->InTransaction))
     DataBases->IBSQL1->Transaction->StartTransaction();

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();

   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();

   TIBXSQLVAR
     *IBSQLParam;

   TSQLVAR
     *SqlVar,
     *Data;

   for(int i=0; i<DataBases->IBSQL1->Params->Count; ++i)
      {
         IBSQLParam=DataBases->IBSQL1->Params->Vars[i];
         SQLType=IBSQLParam->SQLType;
         SqlVar=IBSQLParam->SqlVar;
         Data=IBSQLParam->Data;
      }

   DataBases->IBQuery->Transaction->Rollback();

   if(TrIsActive)
     DataBases->IBSQL1->Transaction->StartTransaction();
#endif

#if defined(__TEST_IBQUERY_WITH_LIKE_WITH_PARAM__)
   SQLBody="\
select * \
from \"Staff\" \
where \
(\"Name\" like :\"Name\")\
";

   if(!(TrIsActive=DataBases->IBQuery->Transaction->InTransaction))
     DataBases->IBQuery->Transaction->StartTransaction();

   if(DataBases->IBQuery->Active)
     DataBases->IBQuery->Close();

   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);
   if(!DataBases->IBQuery->Prepared)
     DataBases->IBQuery->Prepare();

   TParamType
     ParamType;

   Db::TFieldType
     DataType;

   TParam
     *Param;

   for(int i=0; i<DataBases->IBQuery->ParamCount; ++i)
      {
         Param=DataBases->IBQuery->Params->Items[i];
         ParamType=Param->ParamType;
         DataType=Param->DataType;
      }

   DataBases->IBQuery->ParamByName("Name")->AsString="%Äåì'ÿí%";
   //DataBases->IBQuery->ParamByName("Name")->AsString="%ÄÅÌ'ßÍ%";
   //DataBases->IBQuery->ParamByName("Name")->AsString="%Äåì''ÿí%"; // Wrong!!! Never do so!!!

   AnsiString
     FieldsList="";

   DataBases->IBQuery->Open();
   if(!DataBases->IBQuery->Eof)
   {
     for(int i=0; i<DataBases->IBQuery->Fields->Count; ++i)
        {
           if(!FieldsList.IsEmpty())
             FieldsList+=" ";
           FieldsList+=DataBases->IBQuery->Fields->Fields[i]->FieldName;
        }

     SQLBody="";
     for(DataBases->IBQuery->First(); !DataBases->IBQuery->Eof; DataBases->IBQuery->Next())
     {
        if(!SQLBody.IsEmpty())
          SQLBody+=" ";
        SQLBody+=DataBases->IBQuery->FieldByName("Name")->AsString;
     }
   }
   DataBases->IBQuery->Close();
   DataBases->IBQuery->Transaction->Rollback();
#endif

#if defined(__TEST_IBQUERY2EXCEL__)
   SQLBody="\
select * \
from \"TestDataTypes\"\
";

   if(!(TrIsActive=DataBases->IBQuery->Transaction->InTransaction))
     DataBases->IBQuery->Transaction->StartTransaction();

   if(DataBases->IBQuery->Active)
     DataBases->IBQuery->Close();

   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);
   DataBases->IBQuery->Open();
   if(!DataBases->IBQuery->Eof)
     {
        Variant
          Excel,
          Workbooks,
          Workbook,
          Sheets,
          sheet,
          cell,
          tmpVariant;

        Excel.Clear();

        try
          {
             try
               {
                  Excel=CreateOleObject("Excel.Application");
               }
             catch(...)
               {
                  SQLBody="Object Excel was not created";
                  throw Exception(SQLBody);
               }
             if(Excel.IsEmpty())
               {
                  SQLBody="Object Excel was not created";
                  throw Exception(SQLBody);
               }

             tmpVariant=true;
             Excel.OlePropertySet("Visible",tmpVariant);
             tmpVariant=false;
             Excel.OlePropertySet("DisplayAlerts",tmpVariant);

             Workbooks=Excel.OlePropertyGet("Workbooks");
             tmpVariant=1;
             Excel.OlePropertySet("SheetsInNewWorkbook",tmpVariant);

             Workbook=Workbooks.OleFunction("Add");
             Sheets=Workbook.OlePropertyGet("Sheets");
             sheet=Workbook.OlePropertyGet("ActiveSheet");

             int
               rows=DataBases->IBQuery->Fields->Count,
               row;

             for(row=1, DataBases->IBQuery->First(); !DataBases->IBQuery->Eof; DataBases->IBQuery->Next(), ++row)
                {
                   for(int i=0; i<rows; ++i)
                      {
                         SQLBody=DataBases->IBQuery->Fields->Fields[i]->FieldName;
                         switch(DataBases->IBQuery->Fields->Fields[i]->DataType)
                           {
                              case ftBlob :
                                {
                                   continue;
                                }
                              case ftFMTBcd :
                                {
                                   tmpVariant=DataBases->IBQuery->Fields->Fields[i]->AsFloat;

                                   break;
                                }
                              case ftLargeint :
                                {
                                   tmpVariant=DataBases->IBQuery->Fields->Fields[i]->AsInteger;

                                   break;
                                }
                              case ftString :
                                {
                                   tmpVariant=DataBases->IBQuery->Fields->Fields[i]->AsString.c_str(); // VType == 8U == varOleStr

                                   break;
                                }
                              default :
                                {
                                    tmpVariant=DataBases->IBQuery->Fields->Fields[i]->Value;
                                }
                           }
                         cell=sheet.OlePropertyGet("Cells").OlePropertyGet("Item",row,i+1);
                         cell.OlePropertySet("Value",tmpVariant);
                      }
                }
             Excel.OleProcedure("Quit");
          }
        catch(...)
          {
          }
     }
   DataBases->IBQuery->Close();
   DataBases->IBQuery->Transaction->Rollback();

   if(TrIsActive)
     DataBases->IBQuery->Transaction->StartTransaction();
#endif

/*
SQLBody="\
update \"TestDataTypes\" \
set \
\"CInteger\" = :\"CInteger\", \
\"CSmallInt\" = :\"CSmallInt\", \
\"CFloat\" = :\"CFloat\", \
\"CDoublePrecision\" = :\"CDoublePrecision\", \
\"CNumeric_4_3\" = :\"CNumeric_4_3\", \
\"CNumeric_5_4\" = :\"CNumeric_5_4\", \
\"CNumeric_9_8\" = :\"CNumeric_9_8\", \
\"CNumeric_10_9\" = :\"CNumeric_10_9\", \
\"CNumeric_18_17\" = :\"CNumeric_18_17\", \
\"CNumeric_18_0\" = :\"CNumeric_18_0\", \
\"CDecimal_4_3\" = :\"CDecimal_4_3\", \
\"CDecimal_5_4\" = :\"CDecimal_5_4\", \
\"CDecimal_9_8\" = :\"CDecimal_9_8\", \
\"CDecimal_10_9\" = :\"CDecimal_10_9\", \
\"CDecimal_18_17\" = :\"CDecimal_18_17\", \
\"CDecimal_18_0\" = :\"CDecimal_18_0\", \
\"CDate\" = :\"CDate\", \
\"CTime\" = :\"CTime\", \
\"CTimeStamp\" = :\"CTimeStamp\", \
\"CChar\" = :\"CChar\", \
\"CVarChar\" = :\"CVarChar\"\
";

   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   DataBases->IBTransaction1->StartTransaction();
   DataBases->IBSQL1->Prepare();
   for(int i=0; i<DataBases->IBSQL1->Params->Count; i++)
      DataBases->IBSQL1->Params->Vars[i]->Clear();
   DataBases->IBSQL1->ParamByName("CInteger")->AsInteger=999999;
   DataBases->IBSQL1->ExecQuery();
   DataBases->IBTransaction1->Commit();
*/
/*
SQLBody="\
select count(*) as \"RecordCount\" from \"TestDataTypes\"\
";

   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   DataBases->IBTransaction1->StartTransaction();
   DataBases->IBSQL1->ExecQuery();
   __int64 RecordCount=DataBases->IBSQL1->FieldByName("RecordCount")->AsInt64;
   DataBases->IBTransaction1->Rollback();
   ShowMessage(IntToStr(RecordCount));
*/

#if defined(BLOB_SAVE)
SQLBody="\
update \"TestDataTypes\" set \"CBlob\" = :\"CBlob\"\
";
   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   SQLBody=ExtractFilePath(Application->ExeName)+"welcome.bmp";
   //SQLBody=ExtractFilePath(Application->ExeName)+"xpfirewall.bmp";
   DataBases->IBTransaction1->StartTransaction();
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ParamByName("CBlob")->LoadFromFile(SQLBody);
   DataBases->IBSQL1->ExecQuery();
   DataBases->IBTransaction1->Commit();
#endif

#if defined(BLOB_LOAD)
SQLBody="\
select * from \"TestDataTypes\"\
";
   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(FileExists(SQLBody=ExtractFilePath(Application->ExeName)+"FromBLOB.bmp"))
     DeleteFile(SQLBody);
   if(!DataBases->IBSQL1->Transaction->InTransaction)
     DataBases->IBSQL1->Transaction->StartTransaction();
   DataBases->IBSQL1->ExecQuery();
   if(!DataBases->IBSQL1->FieldByName("CBlob")->IsNull)
     DataBases->IBSQL1->FieldByName("CBlob")->SaveToFile(SQLBody);
   DataBases->IBSQL1->Transaction->Rollback();
#endif

#if defined (TEST_COMMENT)
   DataBases->IBSQL1->SQL->Text="select 5/**/ *3 from rdb$database";
   if(!DataBases->IBSQL1->Transaction->InTransaction)
     DataBases->IBSQL1->Transaction->StartTransaction();
   DataBases->IBSQL1->ExecQuery();
   DataBases->IBSQL1->Transaction->Rollback();
#endif

#if defined (TEST_OPEN_ACTIVE_QUERY)
   DataBases->IBSQL1->SQL->Text="select * from \"Staff\"";
   if(!DataBases->IBSQL1->Transaction->InTransaction)
     DataBases->IBSQL1->Transaction->StartTransaction();
   DataBases->IBSQL1->ExecQuery();

   if(!DataBases->IBSQL1->Open)
   {
      DataBases->IBSQL1->SQL->Text="select * from T1";
      DataBases->IBSQL1->ExecQuery();
   }

   DataBases->IBQuery->SQL->Text="select * from \"Staff\"";
   DataBases->IBQuery->Open();

   if(DataBases->IBQuery->Active)
   {
      DataBases->IBQuery->SQL->Text="select * from T1";
      DataBases->IBQuery->Open();
   }

   DataBases->IBQuery->Close();
   DataBases->IBSQL1->Close();

   DataBases->IBSQL1->Transaction->Rollback();
#endif
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StartButton1Click(TObject *Sender)
{
   TButton *TmpButton;
   TIBTransaction *IBTransaction=0;
   TMemo *TransactionMemo=0;

   TmpButton=dynamic_cast<TButton *>(Sender);

   if(!TmpButton)
     return;

   switch(TmpButton->Tag)
     {
        case 1: {
                   IBTransaction=DataBases->IBTransaction1;
                   TransactionMemo=TransactionMemo1;
                   break;
                }
        case 2: {
                   IBTransaction=DataBases->IBTransaction2;
                   TransactionMemo=TransactionMemo2;
                   break;
                }
     }

   IBTransaction->Params->Clear();
   for(int i=0;i<TransactionMemo->Lines->Count;i++)
      IBTransaction->Params->Add(TransactionMemo->Lines->Strings[i]);

   try
     {
        IBTransaction->StartTransaction();
     }
   catch(EIBError &eException)
     {
        AnsiString tmp="Can\'t start transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Can\'t start transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   switch(TmpButton->Tag)
     {
        case 1: {
                   StartButton1->Enabled=false;
                   ShowTPBButton1->Enabled=true;
                   CommitButton1->Enabled=true;
                   RollbackButton1->Enabled=true;
                   ExecButton1->Enabled=true;
                   break;
                }
        case 2: {
                   StartButton2->Enabled=false;
                   ShowTPBButton2->Enabled=true;
                   CommitButton2->Enabled=true;
                   RollbackButton2->Enabled=true;
                   ExecButton2->Enabled=true;
                   break;
                }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CommitButton1Click(TObject *Sender)
{
   TButton *TmpButton;
   TIBTransaction *IBTransaction=0;

   TmpButton=dynamic_cast<TButton *>(Sender);

   if(!TmpButton)
     return;

   switch(TmpButton->Tag)
     {
        case 1: {
                   IBTransaction=DataBases->IBTransaction1;
                   break;
                }
        case 2: {
                   IBTransaction=DataBases->IBTransaction2;
                   break;
                }
     }

   try
     {
        IBTransaction->Commit();
     }
   catch(EIBError &eException)
     {
        AnsiString tmp="Can\'t commit transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Can\'t commit transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   switch(TmpButton->Tag)
     {
        case 1: {
                  StartButton1->Enabled=true;
                  ShowTPBButton1->Enabled=false;
                  CommitButton1->Enabled=false;
                  RollbackButton1->Enabled=false;
                  ExecButton1->Enabled=false;
                  break;
                }
        case 2: {
                  StartButton2->Enabled=true;
                  ShowTPBButton2->Enabled=false;
                  CommitButton2->Enabled=false;
                  RollbackButton2->Enabled=false;
                  ExecButton2->Enabled=false;
                  break;
                }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::RollbackButton1Click(TObject *Sender)
{
   TButton *TmpButton;
   TIBTransaction *IBTransaction=0;

   TmpButton=dynamic_cast<TButton *>(Sender);

   if(!TmpButton)
     return;

   switch(TmpButton->Tag)
     {
        case 1: {
                   IBTransaction=DataBases->IBTransaction1;
                   break;
                }
        case 2: {
                   IBTransaction=DataBases->IBTransaction2;
                   break;
                }
     }

   try
     {
        IBTransaction->Rollback();
     }
   catch(EIBError &eException)
     {
        AnsiString tmp="Can\'t rollback transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Can\'t rollback transaction #"+IntToStr(TmpButton->Tag)+" for database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   switch(TmpButton->Tag)
     {
        case 1: {
                  StartButton1->Enabled=true;
                  ShowTPBButton1->Enabled=false;
                  CommitButton1->Enabled=false;
                  RollbackButton1->Enabled=false;
                  ExecButton1->Enabled=false;
                  break;
                }
        case 2: {
                  StartButton2->Enabled=true;
                  ShowTPBButton2->Enabled=false;
                  CommitButton2->Enabled=false;
                  RollbackButton2->Enabled=false;
                  ExecButton2->Enabled=false;
                  break;
                }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ExecButton1Click(TObject *Sender)
{
   TButton
     *TmpButton;

   TComboBox
     *SQLComboBox=0;

   TEdit
     *ResultEdit=0;

   TIBSQL
     *IBSQL=0;

   TMemo
     *Memo=0;

   TCheckBox
     *CheckBox=0;

   if(!(TmpButton=dynamic_cast<TButton *>(Sender)))
     return;

   switch(TmpButton->Tag)
     {
        case 1: {
                   SQLComboBox=SQLComboBox1;
                   ResultEdit=ResultEdit1;
                   IBSQL=DataBases->IBSQL1;
                   Memo=MemoPlan1;
                   CheckBox=CheckBoxFetchAll1;
                   break;
                }
        case 2: {
                   SQLComboBox=SQLComboBox2;
                   ResultEdit=ResultEdit2;
                   IBSQL=DataBases->IBSQL2;
                   Memo=MemoPlan2;
                   CheckBox=CheckBoxFetchAll2;
                   break;
                }
     }

   AnsiString
     tmp=SQLComboBox->Text,
     Mess;

   ResultEdit->Text="";

   IBSQL->Close();
   IBSQL->SQL->Clear();
   IBSQL->SQL->Add(tmp);

   time_t
     start,
     stop;

   double
     dValue;

   DWORD
     GTCStart,
     GTCStop,
     GTCDiff;

   Memo->Clear();

   start=time(0);
   GTCStart=GetTickCount();

   try
     {
        IBSQL->ExecQuery();
        if(tmp.Pos("select"))
          {
             if(CheckBox->Checked)
               {
                  for(; !IBSQL->Eof; IBSQL->Next())
                     {
                     }
               }
          }
     }
   catch(EIBClientError &eException)
     {
        tmp="Error: ExecQuery() error with database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nSQLMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(EIBError &eException)
     {
        tmp="Error: ExecQuery() error with database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nSQLMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Error: ExecQuery() error with database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   tmp=tmp.LowerCase();
   if(tmp.Pos("select"))
     {
        if(tmp.Pos("TestValue"))
          ResultEdit->Text=IBSQL->FieldByName("TestValue")->AsString;
        Memo->Lines->Add(IBSQL->Plan);
     }
   stop=time(0);
   GTCStop=GetTickCount();

   dValue=difftime(stop,start);
   Mess="DiffTime="+FloatToStrF(dValue,ffFixed,18,2)+" sec";
   Memo->Lines->Add(Mess);

   GTCDiff=GTCStop-GTCStart;
   Mess="DiffTickCount="+IntToStr(GTCDiff)+" ms";
   Memo->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CloseButtonClick(TObject *Sender)
{
   CloseIB();

   OpenButton->Enabled=true;
   CloseButton->Enabled=false;

   GetIBDatabaseInfoButton->Enabled=false;

   StartButton1->Enabled=false;
   ShowTPBButton1->Enabled=false;
   CommitButton1->Enabled=false;
   RollbackButton1->Enabled=false;
   ExecButton1->Enabled=false;

   StartButton2->Enabled=false;
   ShowTPBButton2->Enabled=false;
   CommitButton2->Enabled=false;
   RollbackButton2->Enabled=false;
   ExecButton2->Enabled=false;

   ExecSP1Button->Enabled=false;
   ExecSP2Button->Enabled=false;

   FillTableCertifErsatz->Enabled=false;
   FillTableCertifHash->Enabled=false;
   SelectFromCertifErsatz->Enabled=false;
   SelectFromCertifHash->Enabled=false;

   DoReadDatatypesButton->Enabled=false;
   GetValueButton->Enabled=false;
   SetValueButton->Enabled=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ShowTPBButton1Click(TObject *Sender)
{
   TButton *TmpButton;
   TIBTransaction *IBTransaction=NULL;
   TListBox *TPBListBox=NULL;
   AnsiString TPBParams;

   TmpButton=dynamic_cast<TButton *>(Sender);

   if(!TmpButton)
     return;

   switch(TmpButton->Tag)
     {
        case 1: {
                   IBTransaction=DataBases->IBTransaction1;
                   TPBListBox=TPBListBox1;
                   break;
                }
        case 2: {
                   IBTransaction=DataBases->IBTransaction2;
                   TPBListBox=TPBListBox2;
                   break;
                }
     }

   TPBListBox->Items->Clear();
   for(int i=0;i<IBTransaction->TPBLength;i++)
      {
         TPBParams="";
         if(!i)
           {
              switch(IBTransaction->TPB[i])
                {
                   case isc_tpb_version1 : {
                                              TPBParams="isc_tpb_version1";
                                              break;
                                           }
                   case isc_tpb_version3 : {
                                              TPBParams="isc_tpb_version3";
                                              break;
                                           }
                   default               : {
                                              TPBParams="unknown tpb parameter";
                                              break;
                                           }
                }
           }
         else
           {
              switch(IBTransaction->TPB[i])
                {
                   case isc_tpb_consistency      : {
                                                      TPBParams="isc_tpb_consistency";
                                                      break;
                                                   }
                   case isc_tpb_concurrency      : {
                                                      TPBParams="isc_tpb_concurrency";
                                                      break;
                                                   }
                   case isc_tpb_shared           : {
                                                      TPBParams="isc_tpb_shared";
                                                      break;
                                                   }
                   case isc_tpb_protected        : {
                                                      TPBParams="isc_tpb_protected";
                                                      break;
                                                   }
                   case isc_tpb_exclusive        : {
                                                      TPBParams="isc_tpb_exclusive";
                                                      break;
                                                   }
                   case isc_tpb_wait             : {
                                                      TPBParams="isc_tpb_wait";
                                                      break;
                                                   }
                   case isc_tpb_nowait           : {
                                                      TPBParams="isc_tpb_nowait";
                                                      break;
                                                   }
                   case isc_tpb_read             : {
                                                      TPBParams="isc_tpb_read";
                                                      break;
                                                   }
                   case isc_tpb_write            : {
                                                      TPBParams="isc_tpb_write";
                                                      break;
                                                   }
                   case isc_tpb_lock_read        : {
                                                      TPBParams="isc_tpb_lock_read";
                                                      break;
                                                   }
                   case isc_tpb_lock_write       : {
                                                      TPBParams="isc_tpb_lock_write";
                                                      break;
                                                   }
                   case isc_tpb_verb_time        : {
                                                     TPBParams="isc_tpb_verb_time";
                                                      break;
                                                   }
                   case isc_tpb_commit_time      : {
                                                      TPBParams="isc_tpb_commit_time";
                                                      break;
                                                   }
                   case isc_tpb_ignore_limbo     : {
                                                      TPBParams="isc_tpb_ignore_limbo";
                                                      break;
                                                   }
                   case isc_tpb_read_committed   : {
                                                      TPBParams="isc_tpb_read_committed";
                                                      break;
                                                   }
                   case isc_tpb_autocommit       : {
                                                      TPBParams="isc_tpb_autocommit";
                                                      break;
                                                   }
                   case isc_tpb_rec_version      : {
                                                      TPBParams="isc_tpb_rec_version";
                                                      break;
                                                   }
                   case isc_tpb_no_rec_version   : {
                                                      TPBParams="isc_tpb_no_rec_version";
                                                      break;
                                                   }
                   case isc_tpb_restart_requests : {
                                                      TPBParams="isc_tpb_restart_requests";
                                                      break;
                                                   }
                   case isc_tpb_no_auto_undo     : {
                                                      TPBParams="isc_tpb_no_auto_undo";
                                                      break;
                                                   }
                   default                       : {
                                                      while(IBTransaction->TPB[i]>isc_tpb_last_tpb_constant)
                                                        TPBParams+=IBTransaction->TPB[i++];
                                                      i--;
                                                      break;
                                                   }
                }
           }
         TPBListBox->Items->Append(TPBParams);
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::GetIBDatabaseInfoButtonClick(TObject *Sender)
{
   AnsiString tmp;

   try
     {
        DataBases->IBDatabaseInfo->Database=DataBases->IBDatabase;

        IBExtractMemo->Clear();

        IBExtractMemo->Lines->Add("Allocation="+IntToStr(DataBases->IBDatabaseInfo->Allocation));

        IBExtractMemo->Lines->Add("BackoutCount->Count="+IntToStr(DataBases->IBDatabaseInfo->BackoutCount->Count));
        if(DataBases->IBDatabaseInfo->BackoutCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->BackoutCount);

        IBExtractMemo->Lines->Add("BaseLevel="+IntToStr(DataBases->IBDatabaseInfo->BaseLevel));
        IBExtractMemo->Lines->Add("CurrentMemory="+IntToStr(DataBases->IBDatabaseInfo->CurrentMemory));
        IBExtractMemo->Lines->Add("DBFileName="+DataBases->IBDatabaseInfo->DBFileName);
        IBExtractMemo->Lines->Add("DBImplementationClass="+IntToStr(DataBases->IBDatabaseInfo->DBImplementationClass));
        IBExtractMemo->Lines->Add("DBImplementationNo="+IntToStr(DataBases->IBDatabaseInfo->DBImplementationNo));
        IBExtractMemo->Lines->Add("DBSiteName="+DataBases->IBDatabaseInfo->DBSiteName);
        IBExtractMemo->Lines->Add("DBSQLDialect="+IntToStr(DataBases->IBDatabaseInfo->DBSQLDialect));

        IBExtractMemo->Lines->Add("DeleteCount->Count="+IntToStr(DataBases->IBDatabaseInfo->DeleteCount->Count));
        if(DataBases->IBDatabaseInfo->DeleteCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->DeleteCount);

        IBExtractMemo->Lines->Add("ExpungeCount->Count="+IntToStr(DataBases->IBDatabaseInfo->ExpungeCount->Count));
        if(DataBases->IBDatabaseInfo->ExpungeCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->ExpungeCount);

        IBExtractMemo->Lines->Add("Fetches="+IntToStr(DataBases->IBDatabaseInfo->Fetches));
        IBExtractMemo->Lines->Add("ForcedWrites="+IntToStr(DataBases->IBDatabaseInfo->ForcedWrites));

        IBExtractMemo->Lines->Add("InsertCount->Count="+IntToStr(DataBases->IBDatabaseInfo->InsertCount->Count));
        if(DataBases->IBDatabaseInfo->InsertCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->InsertCount);

        IBExtractMemo->Lines->Add("Marks="+IntToStr(DataBases->IBDatabaseInfo->Marks));
        IBExtractMemo->Lines->Add("MaxMemory="+IntToStr(DataBases->IBDatabaseInfo->MaxMemory));
        IBExtractMemo->Lines->Add("NoReserve="+IntToStr(DataBases->IBDatabaseInfo->NoReserve));
        IBExtractMemo->Lines->Add("NumBuffers="+IntToStr(DataBases->IBDatabaseInfo->NumBuffers));
        IBExtractMemo->Lines->Add("ODSMajorVersion="+IntToStr(DataBases->IBDatabaseInfo->ODSMajorVersion));
        IBExtractMemo->Lines->Add("ODSMinorVersion="+IntToStr(DataBases->IBDatabaseInfo->ODSMinorVersion));
        IBExtractMemo->Lines->Add("PageSize="+IntToStr(DataBases->IBDatabaseInfo->PageSize));

        IBExtractMemo->Lines->Add("PurgeCount->Count="+IntToStr(DataBases->IBDatabaseInfo->PurgeCount->Count));
        if(DataBases->IBDatabaseInfo->PurgeCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->PurgeCount);

        IBExtractMemo->Lines->Add("ReadIdxCount->Count="+IntToStr(DataBases->IBDatabaseInfo->ReadIdxCount->Count));
        if(DataBases->IBDatabaseInfo->ReadIdxCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->ReadIdxCount);

        IBExtractMemo->Lines->Add("ReadOnly="+IntToStr(DataBases->IBDatabaseInfo->ReadOnly));
        IBExtractMemo->Lines->Add("Reads="+IntToStr(DataBases->IBDatabaseInfo->Reads));

        IBExtractMemo->Lines->Add("ReadSeqCount->Count="+IntToStr(DataBases->IBDatabaseInfo->ReadSeqCount->Count));
        if(DataBases->IBDatabaseInfo->ReadSeqCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->ReadSeqCount);

        IBExtractMemo->Lines->Add("SweepInterval="+IntToStr(DataBases->IBDatabaseInfo->SweepInterval));

        IBExtractMemo->Lines->Add("UpdateCount->Count="+IntToStr(DataBases->IBDatabaseInfo->UpdateCount->Count));
        if(DataBases->IBDatabaseInfo->UpdateCount->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->UpdateCount);

        IBExtractMemo->Lines->Add("UserNames->Count="+IntToStr(DataBases->IBDatabaseInfo->UserNames->Count));
        if(DataBases->IBDatabaseInfo->UserNames->Count)
          IBExtractMemo->Lines->AddStrings(DataBases->IBDatabaseInfo->UserNames);

        IBExtractMemo->Lines->Add("Version="+DataBases->IBDatabaseInfo->Version);
        IBExtractMemo->Lines->Add("Writes="+IntToStr(DataBases->IBDatabaseInfo->Writes));
        IBExtractMemo->Lines->Add("");
        
        ServerVersion->Text=DataBases->IBDatabaseInfo->Version;
        DBFileName->Text=DataBases->IBDatabaseInfo->DBFileName;
        DBSQLDialect->Text=IntToStr(DataBases->IBDatabaseInfo->DBSQLDialect);

        DataBases->IBExtract->Database=DataBases->IBDatabase;
        DataBases->IBExtract->Transaction=DataBases->IBTransaction1;

        TExtractObjectTypes ExtractObjectTypes;

        switch(ExtractObjectTypesComboBox->ItemIndex)
          {
             case  0 : {
                          ExtractObjectTypes=eoDatabase;
                          break;
                       }
             case  1 : {
                          ExtractObjectTypes=eoDomain;
                          break;
                       }
             case  2 : {
                          ExtractObjectTypes=eoTable;
                          break;
                       }
             case  3 : {
                          ExtractObjectTypes=eoView;
                          break;
                       }
             case  4 : {
                          ExtractObjectTypes=eoProcedure;
                          break;
                       }
             case  5 : {
                          ExtractObjectTypes=eoFunction;
                          break;
                       }
             case  6 : {
                          ExtractObjectTypes=eoGenerator;
                          break;
                       }
             case  7 : {
                          ExtractObjectTypes=eoException;
                          break;
                       }
             case  8 : {
                          ExtractObjectTypes=eoBLOBFilter;
                          break;
                       }
             case  9 : {
                          ExtractObjectTypes=eoRole;
                          break;
                       }
             case 10 : {
                          ExtractObjectTypes=eoTrigger;
                          break;
                       }
             case 11 : {
                          ExtractObjectTypes=eoForeign;
                          break;
                       }
             case 12 : {
                          ExtractObjectTypes=eoIndexes;
                          break;
                       }
             case 13 : {
                          ExtractObjectTypes=eoChecks;
                          break;
                       }
             case 14 : {
                          ExtractObjectTypes=eoData;
                          break;
                       }
             default : {
                         ExtractObjectTypes=eoDatabase;
                         break;
                       }
          }

        TExtractTypes ExtractTypes;
        ExtractTypes.Clear();

        switch(ExtractTypeComboBox->ItemIndex)
          {
             case  0 : {
                          ExtractTypes.Clear();
                          break;
                       }
             case  1 : {
                          ExtractTypes<<etDomain;
                          break;
                       }
             case  2 : {
                          ExtractTypes<<etTable;
                          break;
                       }
             case  3 : {
                          ExtractTypes<<etRole;
                          break;
                       }
             case  4 : {
                          ExtractTypes<<etTrigger;
                          break;
                       }
             case  5 : {
                          ExtractTypes<<etForeign;
                          break;
                       }
             case  6 : {
                          ExtractTypes<<etIndex;
                          break;
                       }
             case  7 : {
                          ExtractTypes<<etData;
                          break;
                       }
             case  8 : {
                          ExtractTypes<<etGrant;
                          break;
                       }
             case  9 : {
                          ExtractTypes<<etCheck;
                          break;
                       }
             case 10 : {
                          ExtractTypes<<etAlterProc;
                          break;
                       }
             default : {
                          ExtractTypes.Clear();
                       }
          }

        DataBases->IBExtract->ExtractObject(ExtractObjectTypes,ObjectNameLabeledEdit->Text.Trim(),ExtractTypes);
        IBExtractMemo->Lines->AddStrings(DataBases->IBExtract->Items);
     }
   catch(EIBError &eException)
     {
        tmp="Error with database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nSQLMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Error with database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ExecSP1ButtonClick(TObject *Sender)
{
   AnsiString tmp;

   try
     {
        DataBases->IBStoredProc1->UnPrepare();
        DataBases->IBStoredProc1->StoredProcName="SP1";
        if(!DataBases->IBStoredProc1->Prepared)
          DataBases->IBStoredProc1->Prepare();
        DataBases->IBStoredProc1->ParamByName("ArgFirst")->AsFloat=StrToFloatDef(SP1Arg1->Text,0);
        DataBases->IBStoredProc1->ParamByName("ArgSecond")->AsFloat=StrToFloatDef(SP1Arg2->Text,0);
        DataBases->IBStoredProc1->ExecProc();
        SP1Result->Text=FloatToStrF(DataBases->IBStoredProc1->ParamByName("Result")->AsFloat,ffFixed,18,2);
     }
   catch(EIBError &eException)
     {
        tmp="Error: ExecProc() error with database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nSQLMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Error: ExecProc() error with database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ExecSP2ButtonClick(TObject *Sender)
{
   AnsiString tmp;

   try
     {
        DataBases->IBStoredProc2->UnPrepare();
        DataBases->IBStoredProc2->StoredProcName="SP2";
        if(!DataBases->IBStoredProc2->Prepared)
          DataBases->IBStoredProc2->Prepare();
        DataBases->IBStoredProc2->ParamByName("TestId")->AsInteger=StrToIntDef(SP2Arg1->Text,0);
        DataBases->IBStoredProc2->ExecProc();
        SP2Result->Text=DataBases->IBStoredProc2->ParamByName("TestValue")->AsString;
     }
   catch(EIBError &eException)
     {
        tmp="Error: ExecProc() error with database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nSQLMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
   catch(Exception &eException)
     {
        AnsiString tmp="Error: ExecProc() error with database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
        Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FillTableCertifErsatzClick(TObject *Sender)
{
   int Cnt,Inst,Nd,Yr,Kd,Br,Ct,Cr,i;

   TLabeledEdit *pLabeledEdit;

   for(i=0; i<PrimaryKeyTabSheet->ControlCount; i++)
      if(pLabeledEdit=dynamic_cast<TLabeledEdit *>(PrimaryKeyTabSheet->Controls[i]))
        {
          pLabeledEdit->Text=pLabeledEdit->Text.Trim();
          if(pLabeledEdit->Name!="Diff" && pLabeledEdit->Text.IsEmpty())
            {
               pLabeledEdit->SetFocus();
               return;
            }
        }

   FillTableCertifErsatz->Enabled=false;
   Cursor=crSQLWait;

   Cnt=StrToIntDef(Centre->Text,0);
   Inst=StrToIntDef(Institution->Text,0);
   Nd=StrToIntDef(Node->Text,0);
   Yr=StrToIntDef(Year->Text,0);
   Kd=StrToIntDef(Kind->Text,0);
   Br=StrToIntDef(Branch->Text,0);
   Ct=StrToIntDef(ContrNo->Text,0);
   Cr=StrToIntDef(CertNo->Text,0);

   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   AnsiString SQLBody;

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   SQLBody="delete from \"CertifErsatz\"";
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ExecQuery();

   time_t first, second;
   first=time(0);
   for(int a=1; a<=Cnt; a++)
      for(int b=Inst; b>0; b--)
         for(int c=1; c<=Nd; c++)
            for(int d=Yr; d>0; d--)
               for(int e=1; e<=Kd; e++)
                  for(int f=Br; f>0; f--)
                     for(int g=1; g<=Ct; g++)
                        for(int h=Cr; h>0; h--)
                           {
                              if(DataBases->IBSQL1->Open)
                                DataBases->IBSQL1->Close();
                              DataBases->IBSQL1->SQL->Clear();
                              SQLBody="select gen_id(\"GenCertifId\",1) as \"CertId\" FROM RDB$DATABASE";
                              DataBases->IBSQL1->SQL->Add(SQLBody);
                              if(!DataBases->IBSQL1->Prepared)
                                DataBases->IBSQL1->Prepare();
                              DataBases->IBSQL1->ExecQuery();
                              i=DataBases->IBSQL1->FieldByName("CertId")->AsInteger;

                              if(DataBases->IBSQL1->Open)
                                DataBases->IBSQL1->Close();
                              DataBases->IBSQL1->SQL->Clear();
                              SQLBody="insert into \"CertifErsatz\" (\"CertId\", \"CentreId\", \"InstId\", \"NodeId\", \"Year\", \"Kind\", \"Branch\", \"ContrNo\", \"CertNo\", \"Value\") values (:\"CertId\", :\"CentreId\", :\"InstId\", :\"NodeId\", :\"Year\", :\"Kind\", :\"Branch\", :\"ContrNo\", :\"CertNo\", :\"Value\")";
                              DataBases->IBSQL1->SQL->Add(SQLBody);
                              if(!DataBases->IBSQL1->Prepared)
                                DataBases->IBSQL1->Prepare();
                              DataBases->IBSQL1->ParamByName("CertId")->AsInteger=i;
                              DataBases->IBSQL1->ParamByName("CentreId")->AsInteger=a;
                              DataBases->IBSQL1->ParamByName("InstId")->AsInteger=b;
                              DataBases->IBSQL1->ParamByName("NodeId")->AsInteger=c;
                              DataBases->IBSQL1->ParamByName("Year")->AsInteger=d;
                              DataBases->IBSQL1->ParamByName("Kind")->AsInteger=e;
                              DataBases->IBSQL1->ParamByName("Branch")->AsInteger=f;
                              DataBases->IBSQL1->ParamByName("ContrNo")->AsInteger=g;
                              DataBases->IBSQL1->ParamByName("CertNo")->AsInteger=h;
                              DataBases->IBSQL1->ParamByName("Value")->AsString="Value";
                              DataBases->IBSQL1->ExecQuery();
                           };
   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Commit();

   second=time(0);
   Diff->Text=FloatToStrF(difftime(second,first),ffFixed,18,2);

   FillTableCertifErsatz->Enabled=true;
   Cursor=crDefault;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SelectFromCertifErsatzClick(TObject *Sender)
{
   int Cnt,Inst,Nd,Yr,Kd,Br,Ct,Cr,i;

   TLabeledEdit *pLabeledEdit;

   for(i=0; i<PrimaryKeyTabSheet->ControlCount; i++)
      if(pLabeledEdit=dynamic_cast<TLabeledEdit *>(PrimaryKeyTabSheet->Controls[i]))
        {
          pLabeledEdit->Text=pLabeledEdit->Text.Trim();
          if(pLabeledEdit->Name!="Diff" && pLabeledEdit->Text.IsEmpty())
            {
               pLabeledEdit->SetFocus();
               return;
            }
        }

   SelectFromCertifErsatz->Enabled=false;
   Cursor=crSQLWait;

   Cnt=StrToIntDef(Centre->Text,0);
   Inst=StrToIntDef(Institution->Text,0);
   Nd=StrToIntDef(Node->Text,0);
   Yr=StrToIntDef(Year->Text,0);
   Kd=StrToIntDef(Kind->Text,0);
   Br=StrToIntDef(Branch->Text,0);
   Ct=StrToIntDef(ContrNo->Text,0);
   Cr=StrToIntDef(CertNo->Text,0);

   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   AnsiString SQLBody;

   time_t first, second;
   first=time(0);

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   SQLBody="select \"CertId\" from \"CertifErsatz\" where (\"CentreId\" = :\"CentreId\") and (\"InstId\" = :\"InstId\") and (\"NodeId\" = :\"NodeId\") and (\"Year\" = :\"Year\") and (\"Kind\" = :\"Kind\") and (\"Branch\" = :\"Branch\") and (\"ContrNo\" = :\"ContrNo\") and (\"CertNo\" = :\"CertNo\")";
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ParamByName("CentreId")->AsInteger=Cnt;
   DataBases->IBSQL1->ParamByName("InstId")->AsInteger=Inst;
   DataBases->IBSQL1->ParamByName("NodeId")->AsInteger=Nd;
   DataBases->IBSQL1->ParamByName("Year")->AsInteger=Yr;
   DataBases->IBSQL1->ParamByName("Kind")->AsInteger=Kd;
   DataBases->IBSQL1->ParamByName("Branch")->AsInteger=Br;
   DataBases->IBSQL1->ParamByName("ContrNo")->AsInteger=Ct;
   DataBases->IBSQL1->ParamByName("CertNo")->AsInteger=Cr;
   DataBases->IBSQL1->ExecQuery();

   if(!DataBases->IBSQL1->Eof)
     {
        i=DataBases->IBSQL1->FieldByName("CertId")->AsInteger;
        if(DataBases->IBSQL1->Open)
          DataBases->IBSQL1->Close();
        DataBases->IBSQL1->SQL->Clear();
        SQLBody="select * from \"CertifErsatz\" where (\"CertId\" = :\"CertId\")";
        DataBases->IBSQL1->SQL->Add(SQLBody);
        if(!DataBases->IBSQL1->Prepared)
          DataBases->IBSQL1->Prepare();
        DataBases->IBSQL1->ParamByName("CertId")->AsInteger=i;
        DataBases->IBSQL1->ExecQuery();
     }
   else
     ShowMessage("Rec not found");

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Rollback();

   second=time(0);
   Diff->Text=FloatToStrF(difftime(second,first),ffFixed,18,2);

   SelectFromCertifErsatz->Enabled=true;
   Cursor=crDefault;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FillTableCertifHashClick(TObject *Sender)
{
   int Cnt,Inst,Nd,Yr,Kd,Br,Ct,Cr,i;

   TLabeledEdit *pLabeledEdit;

   for(i=0; i<PrimaryKeyTabSheet->ControlCount; i++)
      if(pLabeledEdit=dynamic_cast<TLabeledEdit *>(PrimaryKeyTabSheet->Controls[i]))
        {
          pLabeledEdit->Text=pLabeledEdit->Text.Trim();
          if(pLabeledEdit->Name!="Diff" && pLabeledEdit->Text.IsEmpty())
            {
               pLabeledEdit->SetFocus();
               return;
            }
        }

   FillTableCertifHash->Enabled=false;
   Cursor=crSQLWait;

   Cnt=StrToIntDef(Centre->Text,0);
   Inst=StrToIntDef(Institution->Text,0);
   Nd=StrToIntDef(Node->Text,0);
   Yr=StrToIntDef(Year->Text,0);
   Kd=StrToIntDef(Kind->Text,0);
   Br=StrToIntDef(Branch->Text,0);
   Ct=StrToIntDef(ContrNo->Text,0);
   Cr=StrToIntDef(CertNo->Text,0);

   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   AnsiString SQLBody;

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   SQLBody="delete from \"CertifHash\"";
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ExecQuery();

   time_t first, second;
   first=time(0);
   for(int a=1; a<=Cnt; a++)
      for(int b=Inst; b>0; b--)
         for(int c=1; c<=Nd; c++)
            for(int d=Yr; d>0; d--)
               for(int e=1; e<=Kd; e++)
                  for(int f=Br; f>0; f--)
                     for(int g=1; g<=Ct; g++)
                        for(int h=Cr; h>0; h--)
                           {
                              if(DataBases->IBSQL1->Open)
                                DataBases->IBSQL1->Close();
                              DataBases->IBSQL1->SQL->Clear();
                              SQLBody="insert into \"CertifHash\" (\"CertId\", \"CentreId\", \"InstId\", \"NodeId\", \"Year\", \"Kind\", \"Branch\", \"ContrNo\", \"CertNo\", \"Value\") values (:\"CertId\", :\"CentreId\", :\"InstId\", :\"NodeId\", :\"Year\", :\"Kind\", :\"Branch\", :\"ContrNo\", :\"CertNo\", :\"Value\")";
                              DataBases->IBSQL1->SQL->Add(SQLBody);
                              if(!DataBases->IBSQL1->Prepared)
                                DataBases->IBSQL1->Prepare();
                              DataBases->IBSQL1->ParamByName("CertId")->AsInteger=ToHash(a,b,c,d,e,f,g,h);
                              DataBases->IBSQL1->ParamByName("CentreId")->AsInteger=a;
                              DataBases->IBSQL1->ParamByName("InstId")->AsInteger=b;
                              DataBases->IBSQL1->ParamByName("NodeId")->AsInteger=c;
                              DataBases->IBSQL1->ParamByName("Year")->AsInteger=d;
                              DataBases->IBSQL1->ParamByName("Kind")->AsInteger=e;
                              DataBases->IBSQL1->ParamByName("Branch")->AsInteger=f;
                              DataBases->IBSQL1->ParamByName("ContrNo")->AsInteger=g;
                              DataBases->IBSQL1->ParamByName("CertNo")->AsInteger=h;
                              DataBases->IBSQL1->ParamByName("Value")->AsString="Value";
                              DataBases->IBSQL1->ExecQuery();
                           };
   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Commit();

   second=time(0);
   Diff->Text=FloatToStrF(difftime(second,first),ffFixed,18,2);

   FillTableCertifHash->Enabled=true;
   Cursor=crDefault;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SelectFromCertifHashClick(TObject *Sender)
{
   int Cnt,Inst,Nd,Yr,Kd,Br,Ct,Cr,i;

   TLabeledEdit *pLabeledEdit;

   for(i=0; i<PrimaryKeyTabSheet->ControlCount; i++)
      if(pLabeledEdit=dynamic_cast<TLabeledEdit *>(PrimaryKeyTabSheet->Controls[i]))
        {
          pLabeledEdit->Text=pLabeledEdit->Text.Trim();
          if(pLabeledEdit->Name!="Diff" && pLabeledEdit->Text.IsEmpty())
            {
               pLabeledEdit->SetFocus();
               return;
            }
        }

   SelectFromCertifErsatz->Enabled=false;
   Cursor=crSQLWait;

   Cnt=StrToIntDef(Centre->Text,0);
   Inst=StrToIntDef(Institution->Text,0);
   Nd=StrToIntDef(Node->Text,0);
   Yr=StrToIntDef(Year->Text,0);
   Kd=StrToIntDef(Kind->Text,0);
   Br=StrToIntDef(Branch->Text,0);
   Ct=StrToIntDef(ContrNo->Text,0);
   Cr=StrToIntDef(CertNo->Text,0);

   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   AnsiString SQLBody;

   time_t first, second;
   first=time(0);

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   SQLBody="select \"CertId\" from \"CertifHash\" where (\"CentreId\" = :\"CentreId\") and (\"InstId\" = :\"InstId\") and (\"NodeId\" = :\"NodeId\") and (\"Year\" = :\"Year\") and (\"Kind\" = :\"Kind\") and (\"Branch\" = :\"Branch\") and (\"ContrNo\" = :\"ContrNo\") and (\"CertNo\" = :\"CertNo\")";
   DataBases->IBSQL1->SQL->Add(SQLBody);
   if(!DataBases->IBSQL1->Prepared)
     DataBases->IBSQL1->Prepare();
   DataBases->IBSQL1->ParamByName("CentreId")->AsInteger=Cnt;
   DataBases->IBSQL1->ParamByName("InstId")->AsInteger=Inst;
   DataBases->IBSQL1->ParamByName("NodeId")->AsInteger=Nd;
   DataBases->IBSQL1->ParamByName("Year")->AsInteger=Yr;
   DataBases->IBSQL1->ParamByName("Kind")->AsInteger=Kd;
   DataBases->IBSQL1->ParamByName("Branch")->AsInteger=Br;
   DataBases->IBSQL1->ParamByName("ContrNo")->AsInteger=Ct;
   DataBases->IBSQL1->ParamByName("CertNo")->AsInteger=Cr;
   DataBases->IBSQL1->ExecQuery();

   if(!DataBases->IBSQL1->Eof)
     {
        i=DataBases->IBSQL1->FieldByName("CertId")->AsInteger;
        if(DataBases->IBSQL1->Open)
          DataBases->IBSQL1->Close();
        DataBases->IBSQL1->SQL->Clear();
        SQLBody="select * from \"CertifErsatz\" where (\"CertId\" = :\"CertId\")";
        DataBases->IBSQL1->SQL->Add(SQLBody);
        if(!DataBases->IBSQL1->Prepared)
          DataBases->IBSQL1->Prepare();
        DataBases->IBSQL1->ParamByName("CertId")->AsInteger=i;
        DataBases->IBSQL1->ExecQuery();
     }
   else
     ShowMessage("Rec not found");

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Rollback();

   second=time(0);
   Diff->Text=FloatToStrF(difftime(second,first),ffFixed,18,2);

   SelectFromCertifErsatz->Enabled=true;
   Cursor=crDefault;
}
//---------------------------------------------------------------------------

unsigned long __fastcall ToHash(int Cnt, int Inst, int Nd, int Yr, int Kd, int Br, int Ct, int Cr)
{
   return Cnt*10000000 + Inst*1000000 + Nd*100000 + Yr*10000 + Kd*1000 + Br*100 + Ct*10 + Cr;
}
//---------------------------------------------------------------------------

void __fastcall FromHash(unsigned long Key, int &Cnt, int &Inst, int &Nd, int &Yr, int &Kd, int &Br, int &Ct, int &Cr)
{
   Cnt=Key/10000000;
   Inst=(Key=Key-Cnt*10000000)/1000000;
   Nd=(Key=Key-Inst*1000000)/100000;
   Yr=(Key=Key-Nd*100000)/10000;
   Kd=(Key=Key-Yr*10000)/1000;
   Br=(Key=Key-Kd*1000)/100;
   Ct=(Key=Key-Br*100)/10;
   Cr=(Key=Key-Ct*10)/1;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ReadDatatypesClick(TObject *Sender)
{
   ColumnNameComboBox->Items->Clear();
   AsTypeComboBox->Items->Clear();
   ValueEdit->Text="";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoReadDatatypesButtonClick(TObject *Sender)
{
   void __fastcall (*ListStru)(void);

   switch(ReadDatatypes->ItemIndex)
     {
        case 0 : {
                    ListStru=ListByIBTable;
                    break;
                 }
        case 1 : {
                    ListStru=ListByIBQuery;
                    break;
                 }
        case 2 : {
                    ListStru=ListByIBSQL;
                    break;
                 }
     }

   ColumnNameComboBox->Items->Clear();
   AsTypeComboBox->Items->Clear();
   ValueEdit->Text="";

   ListStru();

   if(ColumnNameComboBox->Items->Count)
     {
        ColumnNameComboBox->ItemIndex=0;
        GetValueButton->Enabled=true;
        SetValueButton->Enabled=true;
     }
   else
     {
        GetValueButton->Enabled=false;
        SetValueButton->Enabled=false;
     }

   if(AsTypeComboBox->Items->Count)
     AsTypeComboBox->ItemIndex=0;
}
//---------------------------------------------------------------------------

void __fastcall ListByIBTable(void)
{
   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();
   if(!DataBases->IBTable->Active)
     DataBases->IBTable->Open();
   DataBases->IBTable->FieldDefs->Update();

   MainForm->ListView->Items->Clear();
   TListItem *item;
   AnsiString Datatype;
   for(int i=0; i<DataBases->IBTable->FieldDefs->Count; i++)
      {
         item=MainForm->ListView->Items->Add();
         item->Caption=DataBases->IBTable->FieldDefs->Items[i]->Name;
         MainForm->ColumnNameComboBox->Items->Add(item->Caption);
         switch(DataBases->IBTable->FieldDefs->Items[i]->DataType)
           {
              case ftUnknown     : {
                                      Datatype="ftUnknown";
                                      break;
                                   }
              case ftString      : {
                                      Datatype="ftString";
                                      break;
                                   }
              case ftSmallint    : {
                                      Datatype="ftSmallint";
                                      break;
                                   }
              case ftInteger     : {
                                      Datatype="ftInteger";
                                      break;
                                   }
              case ftWord        : {
                                      Datatype="ftWord";
                                      break;
                                   }
              case ftBoolean     : {
                                      Datatype="ftBoolean";
                                      break;
                                   }
              case ftFloat       : {
                                      Datatype="ftFloat";
                                      break;
                                   }
              case ftCurrency    : {
                                      Datatype="ftCurrency";
                                      break;
                                   }
              case ftBCD         : {
                                      Datatype="ftBCD";
                                      break;
                                   }
              case ftDate        : {
                                      Datatype="ftDate";
                                      break;
                                   }
              case ftTime        : {
                                      Datatype="ftTime";
                                      break;
                                   }
              case ftDateTime    : {
                                      Datatype="ftDateTime";
                                      break;
                                   }
              case ftBytes       : {
                                      Datatype="ftBytes";
                                      break;
                                   }
              case ftVarBytes    : {
                                      Datatype="ftVarBytes";
                                      break;
                                   }
              case ftAutoInc     : {
                                      Datatype="ftAutoInc";
                                      break;
                                   }
              case ftBlob        : {
                                      Datatype="ftBlob";
                                      break;
                                   }
              case ftMemo        : {
                                      Datatype="ftMemo";
                                      break;
                                   }
              case ftGraphic     : {
                                      Datatype="ftGraphic";
                                      break;
                                   }
              case ftFmtMemo     : {
                                      Datatype="ftFmtMemo";
                                      break;
                                   }
              case ftParadoxOle  : {
                                      Datatype="ftParadoxOle";
                                      break;
                                   }
              case ftDBaseOle    : {
                                      Datatype="ftDBaseOle";
                                      break;
                                   }
              case ftTypedBinary : {
                                      Datatype="ftTypedBinary";
                                      break;
                                   }
              case ftCursor      : {
                                      Datatype="ftCursor";
                                      break;
                                   }
              case ftFixedChar   : {
                                      Datatype="ftFixedChar";
                                      break;
                                   }
              case ftWideString  : {
                                      Datatype="ftWideString";
                                      break;
                                   }
              case ftLargeint    : {
                                      Datatype="ftLargeint";
                                      break;
                                   }
              case ftADT         : {
                                      Datatype="ftADT";
                                      break;
                                   }
              case ftArray       : {
                                      Datatype="ftArray";
                                      break;
                                   }
              case ftReference   : {
                                      Datatype="ftReference";
                                      break;
                                   }
              case ftDataSet     : {
                                      Datatype="ftDataSet";
                                      break;
                                   }
              case ftOraBlob     : {
                                      Datatype="ftOraBlob";
                                      break;
                                   }
              case ftOraClob     : {
                                      Datatype="ftOraClob";
                                      break;
                                   }
              case ftVariant     : {
                                      Datatype="ftVariant";
                                      break;
                                   }
              case ftInterface   : {
                                      Datatype="ftInterface";
                                      break;
                                   }
              case ftIDispatch   : {
                                      Datatype="ftIDispatch";
                                      break;
                                   }
              case ftGuid        : {
                                      Datatype="ftGuid";
                                      break;
                                   }
              case ftTimeStamp	 : {
                                      Datatype="ftTimeStamp";
                                      break;
                                   }
              case ftFMTBcd      : {
                                      Datatype="ftFMTBcd";
                                      break;
                                   }
              default            : {
                                      Datatype="Unknown";
                                      break;
                                   }
           }
         item->SubItems->Add(Datatype);
         item->SubItems->Add(IntToStr(DataBases->IBTable->FieldDefs->Items[i]->Precision));
         item->SubItems->Add(IntToStr(DataBases->IBTable->FieldDefs->Items[i]->Size));
      }

   DataBases->IBTable->Close();
   DataBases->IBTransaction1->Rollback();

   MainForm->AsTypeComboBox->Items->Add("BCD");
   MainForm->AsTypeComboBox->Items->Add("Boolean");
   MainForm->AsTypeComboBox->Items->Add("Currency");
   MainForm->AsTypeComboBox->Items->Add("DateTime");
   MainForm->AsTypeComboBox->Items->Add("Float");
   MainForm->AsTypeComboBox->Items->Add("Integer");
   MainForm->AsTypeComboBox->Items->Add("SQLTimeStamp");
   MainForm->AsTypeComboBox->Items->Add("String");
   MainForm->AsTypeComboBox->Items->Add("Variant");
}
//---------------------------------------------------------------------------

void __fastcall ListByIBQuery(void)
{
   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();
   if(DataBases->IBQuery->Active)
     DataBases->IBQuery->Close();
   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add("select * from \"TestDataTypes\"");
   DataBases->IBQuery->Open();

   MainForm->ListView->Items->Clear();
   TListItem *item;
   AnsiString Datatype;
   for(int i=0; i<DataBases->IBQuery->FieldDefs->Count; i++)
      {
         item=MainForm->ListView->Items->Add();
         item->Caption=DataBases->IBQuery->FieldDefs->Items[i]->Name;
         MainForm->ColumnNameComboBox->Items->Add(item->Caption);
         switch(DataBases->IBQuery->FieldDefs->Items[i]->DataType)
           {
              case ftUnknown     : {
                                      Datatype="ftUnknown";
                                      break;
                                   }
              case ftString      : {
                                      Datatype="ftString";
                                      break;
                                   }
              case ftSmallint    : {
                                      Datatype="ftSmallint";
                                      break;
                                   }
              case ftInteger     : {
                                      Datatype="ftInteger";
                                      break;
                                   }
              case ftWord        : {
                                      Datatype="ftWord";
                                      break;
                                   }
              case ftBoolean     : {
                                      Datatype="ftBoolean";
                                      break;
                                   }
              case ftFloat       : {
                                      Datatype="ftFloat";
                                      break;
                                   }
              case ftCurrency    : {
                                      Datatype="ftCurrency";
                                      break;
                                   }
              case ftBCD         : {
                                      Datatype="ftBCD";
                                      break;
                                   }
              case ftDate        : {
                                      Datatype="ftDate";
                                      break;
                                   }
              case ftTime        : {
                                      Datatype="ftTime";
                                      break;
                                   }
              case ftDateTime    : {
                                      Datatype="ftDateTime";
                                      break;
                                   }
              case ftBytes       : {
                                      Datatype="ftBytes";
                                      break;
                                   }
              case ftVarBytes    : {
                                      Datatype="ftVarBytes";
                                      break;
                                   }
              case ftAutoInc     : {
                                      Datatype="ftAutoInc";
                                      break;
                                   }
              case ftBlob        : {
                                      Datatype="ftBlob";
                                      break;
                                   }
              case ftMemo        : {
                                      Datatype="ftMemo";
                                      break;
                                   }
              case ftGraphic     : {
                                      Datatype="ftGraphic";
                                      break;
                                   }
              case ftFmtMemo     : {
                                      Datatype="ftFmtMemo";
                                      break;
                                   }
              case ftParadoxOle  : {
                                      Datatype="ftParadoxOle";
                                      break;
                                   }
              case ftDBaseOle    : {
                                      Datatype="ftDBaseOle";
                                      break;
                                   }
              case ftTypedBinary : {
                                      Datatype="ftTypedBinary";
                                      break;
                                   }
              case ftCursor      : {
                                      Datatype="ftCursor";
                                      break;
                                   }
              case ftFixedChar   : {
                                      Datatype="ftFixedChar";
                                      break;
                                   }
              case ftWideString  : {
                                      Datatype="ftWideString";
                                      break;
                                   }
              case ftLargeint    : {
                                      Datatype="ftLargeint";
                                      break;
                                   }
              case ftADT         : {
                                      Datatype="ftADT";
                                      break;
                                   }
              case ftArray       : {
                                      Datatype="ftArray";
                                      break;
                                   }
              case ftReference   : {
                                      Datatype="ftReference";
                                      break;
                                   }
              case ftDataSet     : {
                                      Datatype="ftDataSet";
                                      break;
                                   }
              case ftOraBlob     : {
                                      Datatype="ftOraBlob";
                                      break;
                                   }
              case ftOraClob     : {
                                      Datatype="ftOraClob";
                                      break;
                                   }
              case ftVariant     : {
                                      Datatype="ftVariant";
                                      break;
                                   }
              case ftInterface   : {
                                      Datatype="ftInterface";
                                      break;
                                   }
              case ftIDispatch   : {
                                      Datatype="ftIDispatch";
                                      break;
                                   }
              case ftGuid        : {
                                      Datatype="ftGuid";
                                      break;
                                   }
              case ftTimeStamp	 : {
                                      Datatype="ftTimeStamp";
                                      break;
                                   }
              case ftFMTBcd      : {
                                      Datatype="ftFMTBcd";
                                      break;
                                   }
              default            : {
                                      Datatype="Unknown";
                                      break;
                                   }
           }
         item->SubItems->Add(Datatype);
         item->SubItems->Add(IntToStr(DataBases->IBQuery->FieldDefs->Items[i]->Precision));
         item->SubItems->Add(IntToStr(DataBases->IBQuery->FieldDefs->Items[i]->Size));
      }

   DataBases->IBQuery->Close();
   DataBases->IBTransaction1->Rollback();

   MainForm->AsTypeComboBox->Items->Add("BCD");
   MainForm->AsTypeComboBox->Items->Add("Boolean");
   MainForm->AsTypeComboBox->Items->Add("Currency");
   MainForm->AsTypeComboBox->Items->Add("DateTime");
   MainForm->AsTypeComboBox->Items->Add("Float");
   MainForm->AsTypeComboBox->Items->Add("Integer");
   MainForm->AsTypeComboBox->Items->Add("SQLTimeStamp");
   MainForm->AsTypeComboBox->Items->Add("String");
   MainForm->AsTypeComboBox->Items->Add("Variant");
}
//---------------------------------------------------------------------------

void __fastcall ListByIBSQL(void)
{
   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();
   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add("select * from \"TestDataTypes\"");
   DataBases->IBSQL1->ExecQuery();

   MainForm->ListView->Items->Clear();
   TListItem *item;
   AnsiString Datatype;
   for(int i=0; i<DataBases->IBSQL1->FieldCount; i++)
      {
         item=MainForm->ListView->Items->Add();
         item->Caption=DataBases->IBSQL1->Fields[i]->Data->SqlName;
         MainForm->ColumnNameComboBox->Items->Add(item->Caption);
         switch(DataBases->IBSQL1->Fields[i]->SQLType)
           {
              case SQL_VARYING   : {
                                      Datatype="SQL_VARYING";
                                      break;
                                   }
              case SQL_TEXT      : {
                                      Datatype="SQL_TEXT";
                                      break;
                                   }
              case SQL_DOUBLE    : {
                                      Datatype="SQL_DOUBLE";
                                      break;
                                   }
              case SQL_FLOAT     : {
                                      Datatype="SQL_FLOAT";
                                      break;
                                   }
              case SQL_LONG      : {
                                      Datatype="SQL_LONG";
                                      break;
                                   }
              case SQL_SHORT     : {
                                      Datatype="SQL_SHORT";
                                      break;
                                   }
              case SQL_TIMESTAMP : {
                                      Datatype="SQL_TIMESTAMP";
                                      break;
                                   }
              case SQL_BLOB      : {
                                      Datatype="SQL_BLOB";
                                      break;
                                   }
              case SQL_D_FLOAT   : {
                                      Datatype="SQL_D_FLOAT";
                                      break;
                                   }
              case SQL_ARRAY     : {
                                      Datatype="SQL_ARRAY";
                                      break;
                                   }
              case SQL_QUAD      : {
                                      Datatype="SQL_QUAD";
                                      break;
                                   }
              case SQL_TYPE_TIME : {
                                      Datatype="SQL_TYPE_TIME";
                                      break;
                                   }
              case SQL_TYPE_DATE : {
                                      Datatype="SQL_TYPE_DATE";
                                      break;
                                   }
              case SQL_INT64     : {
                                      Datatype="SQL_INT64";
                                      break;
                                   }
              case SQL_BOOLEAN   : {
                                      Datatype="SQL_BOOLEAN";
                                      break;
                                   }
              default            : {
                                      Datatype="Unknown";
                                      break;
                                   }
           }
         item->SubItems->Add(Datatype);
         item->SubItems->Add("");
         item->SubItems->Add(IntToStr(DataBases->IBSQL1->Fields[i]->Size));
      }

   DataBases->IBSQL1->Close();
   DataBases->IBTransaction1->Rollback();

   MainForm->AsTypeComboBox->Items->Add("Boolean");
   MainForm->AsTypeComboBox->Items->Add("Currency");
   MainForm->AsTypeComboBox->Items->Add("Date");
   MainForm->AsTypeComboBox->Items->Add("DateTime");
   MainForm->AsTypeComboBox->Items->Add("Double");
   MainForm->AsTypeComboBox->Items->Add("Float");
   MainForm->AsTypeComboBox->Items->Add("Int64");
   MainForm->AsTypeComboBox->Items->Add("Integer");
   MainForm->AsTypeComboBox->Items->Add("Long");
   MainForm->AsTypeComboBox->Items->Add("Pointer");
   MainForm->AsTypeComboBox->Items->Add("Quad");
   MainForm->AsTypeComboBox->Items->Add("Short");
   MainForm->AsTypeComboBox->Items->Add("String");
   MainForm->AsTypeComboBox->Items->Add("Time");
   MainForm->AsTypeComboBox->Items->Add("TrimString");
   MainForm->AsTypeComboBox->Items->Add("Variant");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::GetValueButtonClick(TObject *Sender)
{
   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   switch(ReadDatatypes->ItemIndex)
     {
        case 0 : {
                    if(!DataBases->IBTable->Active)
                      DataBases->IBTable->Open();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      TBcd Bcd=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBCD;
                                      ValueEdit->Text=BcdToStr(Bcd);
                                      break;
                                   }
                         case  1 : {
                                      ValueEdit->Text=BoolToStr(DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean,true);
                                      break;
                                   }
                         case  2 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency;
                                      break;
                                   }
                         case  3 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime;
                                      break;
                                   }
                         case  4 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat;
                                      break;
                                   }
                         case  5 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger;
                                      break;
                                   }
                         case  6 : {
                                      TSQLTimeStamp SQLTimeStamp=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsSQLTimeStamp;
                                      ValueEdit->Text=IntToStr(SQLTimeStamp.Year)+" "+IntToStr(SQLTimeStamp.Month)+" "+IntToStr(SQLTimeStamp.Day)+" "+IntToStr(SQLTimeStamp.Hour)+" "+IntToStr(SQLTimeStamp.Minute)+" "+IntToStr(SQLTimeStamp.Second)+" "+IntToStr(SQLTimeStamp.Fractions);
                                      break;
                                   }
                         case  7 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString;
                                      break;
                                   }
                         case  8 : {
                                      ValueEdit->Text=DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant;
                                      break;
                                   }
                      }
                    DataBases->IBTable->Close();
                    break;
                 }
        case 1 : {
                    if(DataBases->IBQuery->Active)
                      DataBases->IBQuery->Close();
                    DataBases->IBQuery->SQL->Clear();
                    DataBases->IBQuery->SQL->Add("select * from \"TestDataTypes\"");
                    DataBases->IBQuery->Open();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      TBcd Bcd=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBCD;
                                      ValueEdit->Text=BcdToStr(Bcd);
                                      break;
                                   }
                         case  1 : {
                                      ValueEdit->Text=BoolToStr(DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean,true);
                                      break;
                                   }
                         case  2 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency;
                                      break;
                                   }
                         case  3 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime;
                                      break;
                                   }
                         case  4 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat;
                                      break;
                                   }
                         case  5 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger;
                                      break;
                                   }
                         case  6 : {
                                      TSQLTimeStamp SQLTimeStamp=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsSQLTimeStamp;
                                      ValueEdit->Text=IntToStr(SQLTimeStamp.Year)+" "+IntToStr(SQLTimeStamp.Month)+" "+IntToStr(SQLTimeStamp.Day)+" "+IntToStr(SQLTimeStamp.Hour)+" "+IntToStr(SQLTimeStamp.Minute)+" "+IntToStr(SQLTimeStamp.Second)+" "+IntToStr(SQLTimeStamp.Fractions);
                                      break;
                                   }
                         case  7 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString;
                                      break;
                                   }
                         case  8 : {
                                      ValueEdit->Text=DataBases->IBQuery->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant;
                                      break;
                                   }
                      }
                    DataBases->IBQuery->Close();
                    break;
                 }
        case 2 : {
                    if(DataBases->IBSQL1->Open)
                      DataBases->IBSQL1->Close();
                    DataBases->IBSQL1->SQL->Clear();
                    DataBases->IBSQL1->SQL->Add("select * from \"TestDataTypes\"");
                    DataBases->IBSQL1->ExecQuery();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      ValueEdit->Text=BoolToStr(DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean,true);
                                      break;
                                   }
                         case  1 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency;
                                      break;
                                   }
                         case  2 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDate;
                                      break;
                                   }
                         case  3 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime;
                                      break;
                                   }
                         case  4 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDouble;
                                      break;
                                   }
                         case  5 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat;
                                      break;
                                   }
                         case  6 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInt64;
                                      break;
                                   }
                         case  7 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger;
                                      break;
                                   }
                         case  8 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsLong;
                                      break;
                                   }
                         case  9 : {
                                      void *ptr=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsPointer;
                                      break;
                                   }
                         case 10 : {
                                      TISC_QUAD ISC_QUAD=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsQuad;
                                      break;
                                   }
                         case 11 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsShort;
                                      break;
                                   }
                         case 12 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString;
                                      break;
                                   }
                         case 13 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsTime;
                                      break;
                                   }
                         case 14 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsTrimString;
                                      break;
                                   }
                         case 15 : {
                                      ValueEdit->Text=DataBases->IBSQL1->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant;
                                      break;
                                   }
                      }
                    DataBases->IBSQL1->Close();
                    break;
                 }
     }
   DataBases->IBTransaction1->Rollback();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SetValueButtonClick(TObject *Sender)
{
   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();
   DataBases->IBTransaction1->Params->Clear();
   DataBases->IBTransaction1->Params->Add("nowait");
   DataBases->IBTransaction1->Params->Add("read_committed");
   DataBases->IBTransaction1->Params->Add("rec_version");

   DataBases->IBTransaction1->StartTransaction();

   switch(ReadDatatypes->ItemIndex)
     {
        case 0 : {
                    if(!DataBases->IBTable->Active)
                      DataBases->IBTable->Open();

                    DataBases->IBTable->Edit();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      TBcd Bcd=StrToBcd(ValueEdit->Text);
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBCD=Bcd;
                                      break;
                                   }
                         case  1 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean=StrToBool(ValueEdit->Text);
                                      break;
                                   }
                         case  2 : {
                                      Currency tmp=StrToCurr(ValueEdit->Text);
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency=tmp;
                                      break;
                                   }
                         case  3 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime=Now();
                                      break;
                                   }
                         case  4 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat=ValueEdit->Text.ToDouble();
                                      break;
                                   }
                         case  5 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger=ValueEdit->Text.ToInt();
                                      break;
                                   }
                         case  6 : {
                                      TSQLTimeStamp SQLTimeStamp;

                                      SQLTimeStamp.Year=YearOf(Now());
                                      SQLTimeStamp.Month=MonthOf(Now());
                                      SQLTimeStamp.Day=DayOf(Now());
                                      SQLTimeStamp.Hour=HourOf(Now());
                                      SQLTimeStamp.Minute=MinuteOf(Now());
                                      SQLTimeStamp.Second=SecondOf(Now());
                                      SQLTimeStamp.Fractions=0;
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsSQLTimeStamp=SQLTimeStamp;
                                      break;
                                   }
                         case  7 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString=ValueEdit->Text;
                                      break;
                                   }
                         case  8 : {
                                      DataBases->IBTable->FieldByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant=ValueEdit->Text;
                                      break;
                                   }
                      }
                    DataBases->IBTable->Post();
                    DataBases->IBTable->Close();
                    break;
                 }
        case 1 : {
                    if(DataBases->IBQuery->Active)
                      DataBases->IBQuery->Close();
                    DataBases->IBQuery->SQL->Clear();
                    DataBases->IBQuery->SQL->Add("update \"TestDataTypes\" set \""+ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex]+"\" = :\""+ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex]+"\"");
                    if(!DataBases->IBQuery->Prepared)
                      DataBases->IBQuery->Prepare();
                    DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->Clear();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      TBcd Bcd=StrToBcd(ValueEdit->Text);
//                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBCD=Bcd;
                                      break;
                                   }
                         case  1 : {
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean=StrToBool(ValueEdit->Text);
                                      break;
                                   }
                         case  2 : {
                                      Currency tmp=StrToCurr(ValueEdit->Text);
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency=tmp;
                                      break;
                                   }
                         case  3 : {
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime=Now();
                                      break;
                                   }
                         case  4 : {
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat=ValueEdit->Text.ToDouble();
                                      break;
                                   }
                         case  5 : {
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger=ValueEdit->Text.ToInt();
                                      break;
                                   }
                         case  6 : {
                                      TSQLTimeStamp SQLTimeStamp;

                                      SQLTimeStamp.Year=YearOf(Now());
                                      SQLTimeStamp.Month=MonthOf(Now());
                                      SQLTimeStamp.Day=DayOf(Now());
                                      SQLTimeStamp.Hour=HourOf(Now());
                                      SQLTimeStamp.Minute=MinuteOf(Now());
                                      SQLTimeStamp.Second=SecondOf(Now());
                                      SQLTimeStamp.Fractions=0;

                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsSQLTimeStamp=SQLTimeStamp;
                                      break;
                                   }
                         case  7 : {
                                      DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString=ValueEdit->Text;
                                      break;
                                   }
                         case  8 : {
                                      //DataBases->IBQuery->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant=ValueEdit->Text;
                                      break;
                                   }
                      }
                    DataBases->IBQuery->ExecSQL();
                    break;
                 }
        case 2 : {
                    if(DataBases->IBSQL1->Open)
                      DataBases->IBSQL1->Close();
                    DataBases->IBSQL1->SQL->Clear();
                    DataBases->IBSQL1->SQL->Add("update \"TestDataTypes\" set \""+ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex]+"\" = :\""+ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex]+"\"");
                    if(!DataBases->IBSQL1->Prepared)
                      DataBases->IBSQL1->Prepare();
                    DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->Clear();

                    switch(AsTypeComboBox->ItemIndex)
                      {
                         case  0 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsBoolean=StrToBool(ValueEdit->Text);
                                      break;
                                   }
                         case  1 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        {
                                           Currency tmp=StrToCurr(ValueEdit->Text);
                                           DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsCurrency=tmp;
                                        }
                                      break;
                                   }
                         case  2 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDate=Now();
                                      break;
                                   }
                         case  3 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDateTime=Now();
                                      break;
                                   }
                         case  4 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsDouble=ValueEdit->Text.ToDouble();
                                      break;
                                   }
                         case  5 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsFloat=ValueEdit->Text.ToDouble();
                                      break;
                                   }
                         case  6 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInt64=StrToInt64(ValueEdit->Text);
                                      break;
                                   }
                         case  7 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsInteger=ValueEdit->Text.ToInt();
                                      break;
                                   }
                         case  8 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsLong=ValueEdit->Text.ToInt();
                                      break;
                                   }
                         case  9 : {
//                                      void *ptr=DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsPointer;
                                      break;
                                   }
                         case 10 : {
  //                                    TISC_QUAD ISC_QUAD=DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsQuad;
                                      break;
                                   }
                         case 11 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsShort=ValueEdit->Text.ToInt();
                                      break;
                                   }
                         case 12 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsString=ValueEdit->Text;
                                      break;
                                   }
                         case 13 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsTime=Now();
                                      break;
                                   }
                         case 14 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsTrimString=ValueEdit->Text;
                                      break;
                                   }
                         case 15 : {
                                      if(!ValueEdit->Text.Trim().IsEmpty())
                                        DataBases->IBSQL1->ParamByName(ColumnNameComboBox->Items->Strings[ColumnNameComboBox->ItemIndex])->AsVariant=ValueEdit->Text;
                                      break;
                                   }
                      }
                    DataBases->IBSQL1->ExecQuery();
                    break;
                 }
     }
   DataBases->IBTransaction1->Commit();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IBDatabaseINIButtonClick(TObject *Sender)
{
   DataBases->IBDatabaseINI->FileName="TestIB.ini";
   //DataBases->IBDatabaseINI->UseAppPath=ipoPathNone;
   //DataBases->IBDatabaseINI->UseAppPath=ipoPathToServer;
   //DataBases->IBDatabaseINI->UseAppPath=ipoPathRelative;
   DataBases->IBDatabaseINI->FileName=DataBases->IBDatabaseINI->IniFileName();
   if(!DataBases->IBDatabaseINI->Database)
     DataBases->IBDatabaseINI->Database=DataBases->IBDatabase;

   switch(RadioGroupIBDatabaseINIAction->ItemIndex)
     {
        case 0 : {
                    DataBases->IBDatabaseINI->ReadFromINI();
                    DataBases->IBDatabaseINI->WriteToDatabase(DataBases->IBDatabase);
                    break;
                 }
        case 1 : {
                    DataBases->IBDatabaseINI->ReadFromDatabase();
                    DataBases->IBDatabaseINI->SaveToINI();
                    break;
                 }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IBScriptButtonClick(TObject *Sender)
{
   AnsiString
     ScriptFileName=ExtractFilePath(Application->ExeName)+"TestTest.sql";

   DataBases->IBScript->Terminator=";";
   DataBases->IBScript->Script->Clear();
   DataBases->IBScript->Script->LoadFromFile(ScriptFileName);
   if(!DataBases->IBScript->ValidateScript())
     return;
   /*
   if(!DataBases->IBDatabase->Connected)
     {
        DataBases->IBDatabase->DatabaseName=ServerEdit->Text+":"+ExtractFilePath(Application->ExeName)+"TestTest.gdb";
        DataBases->IBDatabase->LoginPrompt=false;
        DataBases->IBDatabase->DefaultTransaction=DataBases->IBTransaction1;

        DataBases->IBDatabase->Params->Clear();
        for(int i=0;i<DataBaseMemo->Lines->Count;i++)
           DataBases->IBDatabase->Params->Add(DataBaseMemo->Lines->Strings[i]);

        try
          {
             DataBases->IBDatabase->Open();
          }
        catch(EIBError &eException)
          {
             AnsiString tmp="Can\'t open database "+DataBases->IBDatabase->DatabaseName+"\nInterBase error #: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
             Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
             return;
          }
        catch(Exception &eException)
          {
             AnsiString tmp="Can\'t open database "+DataBases->IBDatabase->DatabaseName+"\nMessage: "+eException.Message;
             Application->MessageBox(tmp.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
             return;
          }
     }


   if(!DataBases->IBScript->Transaction)
     DataBases->IBScript->Transaction=DataBases->IBTransaction1;


   if(DataBases->IBScript->Terminator!=";")
     DataBases->IBScript->Terminator=";";
   */

   if(!DataBases->IBScript->Database)
     DataBases->IBScript->Database=DataBases->IBDatabase;

   AnsiString tmp="";

   for(int i=0; i<DataBases->IBScript->CurrentTokens->Count; i++)
      {
         if(!tmp.IsEmpty())
           tmp+=" ";
         tmp+=DataBases->IBScript->CurrentTokens->Strings[i];
      }

   DataBases->IBScript->ExecuteScript();

   /*DataBases->IBScript->Script
   Terminator
   Dataset
   Validating
   Stats
   Params
   Paused
   ParamByName()
   */
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IBSQLParserButtonClick(TObject *Sender)
{
   AnsiString
     ScriptFileName=ExtractFilePath(Application->ExeName)+"TestTest.sql";

   DataBases->IBSQLParser->Terminator=";";
   DataBases->IBSQLParser->Script->LoadFromFile(ScriptFileName);

   AnsiString
      tmp="";

   for(int i=0; i<DataBases->IBSQLParser->CurrentTokens->Count; i++)
      {
         if(!tmp.IsEmpty())
           tmp+=" ";
         tmp+=DataBases->IBSQLParser->CurrentTokens->Strings[i];
      }

   DataBases->IBSQLParser->Parse();
}
//---------------------------------------------------------------------------

