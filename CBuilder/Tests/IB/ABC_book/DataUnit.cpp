//---------------------------------------------------------------------------

#include <vcl.h>
#include <StrUtils.hpp>
#pragma hdrstop

#include "DataUnit.h"
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

extern void __fastcall WriteToLogFile(AnsiString aStr);

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
   AnsiString
     ToLog="TDataBase::TDataBase()";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataUnitColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleCreate(TObject *Sender)
{
   AnsiString
     ToLog="TDataBase::DataModuleCreate()";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataUnitColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   try
     {
        OpenDatabase();
     }
   catch(Exception &eException)
     {
        throw(Exception(eException.Message));
     }
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   // !!!
   // Call after return (Project.cpp)
   // !!!

   AnsiString
     ToLog="TDataBase::DataModuleDestroy()";

   WriteToLogFile(ToLog);
   //MainForm->WriteToLog(ToLog,MainForm->DataUnitColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   CloseDatabase();
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::OpenDatabase(void)
{
   try
     {
        IBDatabase->DatabaseName=ExtractFilePath(Application->ExeName)+"test.gdb";
        IBDatabase->LoginPrompt=false;
        IBDatabase->Params->Clear();
        IBDatabase->Params->Add("user_name=sysdba");
        IBDatabase->Params->Add("password=masterkey");
        IBDatabase->Params->Add("lc_ctype=WIN1251");
        IBDatabase->TraceFlags=TTraceFlags()<<tfQPrepare<<tfQExecute<<tfQFetch<<tfError<<tfStmt<<tfConnect<<tfTransact<<tfBlob<<tfService<<tfMisc;
        IBDatabase->DefaultTransaction=IBTransactionRead;

        IBTransactionRead->DefaultDatabase=IBDatabase;
        IBTransactionRead->Params->Clear();
        IBTransactionRead->Params->Add("read");
        IBTransactionRead->Params->Add("nowait");
        IBTransactionRead->Params->Add("read_committed");
        IBTransactionRead->Params->Add("rec_version");

        IBTransactionWrite->DefaultDatabase=IBDatabase;
        IBTransactionWrite->Params->Clear();
        IBTransactionWrite->Params->Add("nowait");
        IBTransactionWrite->Params->Add("read_committed");
        IBTransactionWrite->Params->Add("rec_version");

        IBTableInsurant->Database=IBDatabase;
        IBTableInsurant->Transaction=IBTransactionWrite;
        IBTableInsurant->TableName="Insurant";

        IBTableJuridPerson->Database=IBDatabase;
        IBTableJuridPerson->Transaction=IBTransactionWrite;
        IBTableJuridPerson->TableName="JuridPerson";

        IBTableNaturPerson->Database=IBDatabase;
        IBTableNaturPerson->Transaction=IBTransactionWrite;
        IBTableNaturPerson->TableName="NaturPerson";

        DataSourceInsurant->DataSet=IBTableInsurant;
        DataSourceJuridPerson->DataSet=IBTableJuridPerson;
        DataSourceNaturPerson->DataSet=IBTableNaturPerson;

        IBDataSetInsurant->Database=IBDatabase;
        IBDataSetInsurant->Transaction=IBTransactionWrite;
        IBDataSetInsurant->DataSource=DataSourceInsurant;
        IBDataSetInsurant->SelectSQL->Text="select * from \"Insurant\"";
        IBDataSetInsurant->Open();

        IBQueryInsurant->Database=IBDatabase;
        IBQueryInsurant->Transaction=IBTransactionRead;

        IBSQLInsurant->Database=IBDatabase;
        IBSQLInsurant->Transaction=IBTransactionRead;

        IBDatabase->Open();
        IBDatabase->SQLDialect=IBDatabase->DBSQLDialect;
        IBTableInsurant->Open();
        IBTableJuridPerson->Open();

        if(!IBTransactionRead->Active)
          IBTransactionRead->StartTransaction();

        IBQueryInsurant->SQL->Text="select * from \"Insurant\" where \"NodeId\"= :\"NodeId\"";
        if(!IBQueryInsurant->Prepared)
          IBQueryInsurant->Prepare();
        IBQueryInsurant->ParamByName("NodeId")->AsSmallInt=1;
        IBQueryInsurant->Open();
        IBQueryInsurant->FetchAll();

        IBSQLInsurant->SQL->Text="select * from \"Insurant\" where \"NodeId\"= :\"NodeId\"";
        if(!IBSQLInsurant->Prepared)
          IBSQLInsurant->Prepare();
        IBSQLInsurant->ParamByName("NodeId")->AsShort=2;
        IBSQLInsurant->ExecQuery();
        for(; !IBSQLInsurant->Eof; IBSQLInsurant->Next())
           ;
        if(IBSQLInsurant->RecordCount!=IBQueryInsurant->RecordCount)
          ;
     }
   catch(EIBError &eException)
     {
        throw Exception("\""+IBDatabase->DatabaseName+"\"\nInterBase error: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message);
     }
   catch(Exception &eException)
     {
        throw Exception(eException.Message);
     }
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::CloseDatabase(void)
{
   try
     {
        if(IBSQLInsurant->Open)
          IBSQLInsurant->Close();

        if(IBQueryInsurant->Active)
          IBQueryInsurant->Close();

        if(IBTableNaturPerson->Active)
          IBTableNaturPerson->Close();
        if(IBTableJuridPerson->Active)
          IBTableJuridPerson->Close();
        if(IBTableInsurant->Active)
          IBTableInsurant->Close();

        if(IBTransactionWrite->InTransaction)
          IBTransactionWrite->Rollback();
        if(IBTransactionRead->InTransaction)
          IBTransactionRead->Rollback();

        if(IBDatabase->Connected)
          IBDatabase->Close();
     }
   catch(EIBError &eException)
     {
        throw Exception("\""+IBDatabase->DatabaseName+"\"\nInterBase error: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message);
     }
   catch(Exception &eException)
     {
        throw Exception(eException.Message);
     }
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TIBDatabase
//---------------------------------------------------------------------------
void __fastcall TDataBase::IBDatabaseAfterConnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase AfterConnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseAfterDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase AfterDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseBeforeConnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase BeforeConnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseBeforeDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase BeforeDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseDialectDowngradeWarning(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase OnDialectDowngradeWarning";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseIdleTimer(TObject *Sender)
{
   AnsiString
     ToLog="TIBDatabase OnIdleTimer";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDatabaseLogin(TIBDatabase *Database, TStrings *LoginParams)
{
   AnsiString
     ToLog="TIBDatabase OnDatabaseLogin";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   for(int i=0; i<LoginParams->Count; i++)
      {
         ToLog="LoginParams->Strings[i]="+LoginParams->Strings[i];
         WriteToLogFile(ToLog);
         MainForm->WriteToLog(ToLog,MainForm->IBDatabaseColor);
      }
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
//  TIBSQLMonitor
//---------------------------------------------------------------------------
void __fastcall TDataBase::IBSQLMonitorSQL(AnsiString EventText, TDateTime EventTime)
{
   AnsiString
     ToLog="TIBSQLMonitor OnSQL";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBSQLMonitorColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   ToLog+=" "+AnsiReplaceStr(EventText,"\r\n"," ");
   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBSQLMonitorColor);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
//  TIBTransaction
//---------------------------------------------------------------------------
void __fastcall TDataBase::IBTransactionReadIdleTimer(TObject *Sender)
{
   AnsiString
     ToLog="TIBTransaction OnIdleTimer";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTransactionColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
//  TIBTable
//---------------------------------------------------------------------------
void __fastcall TDataBase::IBTableInsurantAfterCancel(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterCancel(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterClose(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterClose(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterDatabaseDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable AfterDatabaseDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterDelete(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterDelete(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterEdit(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterEdit(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterInsert(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterInser(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterOpen(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterOpen(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterPost(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterPost(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterRefresh(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterRefresh(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterScroll(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable AfterScroll(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantAfterTransactionEnd(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable AfterTransactionEnd";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeCancel(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeCancel(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeClose(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeClose(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeDatabaseDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable BeforeDatabaseDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeDelete(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeDelete(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeEdit(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeEdit(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeInsert(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeInsert(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeOpen(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeOpen(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforePost(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforePost(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeRefresh(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable BeforeRefresh(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeScroll(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable Before Scroll(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantBeforeTransactionEnd(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable BeforeTransactionEnd";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantDatabaseFree(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable DatabaseFree";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantCalcFields(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable OnCalcFields(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBTable OnDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBTable OnEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantFilterRecord(TDataSet *DataSet, bool &Accept)
{
   AnsiString
     ToLog="TIBTable OnFilterRecord(TDataSet *DataSet, bool &Accept)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantNewRecord(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBTable OnNewRecord(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBTable OnPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)
{
   AnsiString
     ToLog="TIBTable OnUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)
{
   AnsiString
     ToLog="TIBTable OnUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBTableInsurantTransactionFree(TObject *Sender)
{
   AnsiString
     ToLog="TIBTable TransactionFree";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBTableColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
//  TIBDataSet
//---------------------------------------------------------------------------
void __fastcall TDataBase::IBDataSetInsurantAfterCancel(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterCancel(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterClose(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterClose(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterDatabaseDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet AfterDatabaseDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterDelete(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterDelete(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterEdit(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterEdit(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterInsert(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterInser(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterOpen(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterOpen(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterPost(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterPost(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterRefresh(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterRefresh(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterScroll(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet AfterScroll(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantAfterTransactionEnd(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet AfterTransactionEnd";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeCancel(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeCancel(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeClose(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeClose(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeDatabaseDisconnect(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet BeforeDatabaseDisconnect";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeDelete(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeDelete(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeEdit(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeEdit(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeInsert(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeInsert(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeOpen(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeOpen(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforePost(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforePost(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeRefresh(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet BeforeRefresh(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeScroll(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet Before Scroll(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantBeforeTransactionEnd(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet BeforeTransactionEnd";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantDatabaseFree(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet DatabaseFree";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantCalcFields(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet OnCalcFields(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBDataSet OnDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBDataSet OnEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantFilterRecord(TDataSet *DataSet, bool &Accept)
{
   AnsiString
     ToLog="TIBDataSet OnFilterRecord(TDataSet *DataSet, bool &Accept)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantNewRecord(TDataSet *DataSet)
{
   AnsiString
     ToLog="TIBDataSet OnNewRecord(TDataSet *DataSet)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)
{
   AnsiString
     ToLog="TIBDataSet OnPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)
{
   AnsiString
     ToLog="TIBDataSet OnUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)
{
   AnsiString
     ToLog="TIBDataSet OnUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction)";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBDataSetInsurantTransactionFree(TObject *Sender)
{
   AnsiString
     ToLog="TIBDataSet TransactionFree";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->IBDataSetColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TDataSource
//---------------------------------------------------------------------------
void __fastcall TDataBase::DataSourceInsurantDataChange(TObject *Sender, TField *Field)
{
   TDataSource
     *DataSource=dynamic_cast<TDataSource *>(Sender);

   AnsiString
     ToLog="TDataSource",
     OldValue,
     NewValue;

   if(DataSource)
     ToLog+=" ("+DataSource->Name+") ";
   ToLog+="OnDataChange";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataSourceColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   if(Field)
     {
        ToLog="FieldName=";
        if(IBDatabase->DBSQLDialect==3)
          ToLog+="\"";
        if(IBDatabase->DBSQLDialect==3)
          ToLog+=Field->FieldName;
        else
          ToLog+=Field->FieldName.UpperCase();
        if(IBDatabase->DBSQLDialect==3)
          ToLog+="\"";

        OldValue=NewValue="";
        switch(Field->DataType)
          {
             case ftString :
               {
                  OldValue=(AnsiString)Field->OldValue;
                  NewValue=(AnsiString)Field->NewValue;

                  break;
               }
          }
        ToLog+=" ";
        ToLog+="OldValue=\""+OldValue+"\" NewValue=\""+NewValue+"\"";
        WriteToLogFile(ToLog);
        MainForm->WriteToLog(ToLog,MainForm->DataSourceColor);
     }
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataSourceInsurantStateChange(TObject *Sender)
{
   TDataSource
     *DataSource=dynamic_cast<TDataSource *>(Sender);

   AnsiString
     ToLog="TDataSource";

   if(DataSource)
     ToLog+=" ("+DataSource->Name+") ";
   ToLog+="OnStateChange";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataSourceColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   switch(DataSource->State)
     {
        case dsInactive :
          {
             ToLog="dsInactive";

             break;
          }
        case dsBrowse :
          {
             ToLog="dsBrowse";

             break;
          }
        case dsEdit :
          {
             ToLog="dsEdit";

             break;
          }
        case dsInsert :
          {
             ToLog="dsInsert";

             break;
          }
        case dsSetKey :
          {
             ToLog="dsSetKey";

             break;
          }
        case dsCalcFields :
          {
             ToLog="dsCalcFields";

             break;
          }
        case dsFilter :
          {
             ToLog="dsFilter";

             break;
          }
        case dsNewValue	:
          {
             ToLog="dsNewWalue";

             break;
          }
        case dsOldValue	:
          {
             ToLog="dsOldValue";

             break;
          }
        case dsCurValue	:
          {
             ToLog="dsCurValue";

             break;
          }
        case dsBlockRead :
          {
             ToLog="dsBlockRead";

             break;
          }
        case dsInternalCalc :
          {
             ToLog="dsInternalCalc";

             break;
          }
        case dsOpening :
          {
             ToLog="dsOpening";

             break;
          }
        default :
          {
             ToLog="Unknown";
          }
     }
   ToLog="DataSource->State=\""+ToLog+"\"";
   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataSourceColor);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataSourceInsurantUpdateData(TObject *Sender)
{
   TDataSource
     *DataSource=dynamic_cast<TDataSource *>(Sender);

   AnsiString
     ToLog="TDataSource";

   if(DataSource)
     ToLog+=" ("+DataSource->Name+") ";
   ToLog+="OnUpdateData";

   WriteToLogFile(ToLog);
   MainForm->WriteToLog(ToLog,MainForm->DataSourceColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

