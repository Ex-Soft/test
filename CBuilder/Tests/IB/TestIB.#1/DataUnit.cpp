//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "IBDatabaseINI"
#pragma link "IBFilterDialog"
#pragma link "IBScript"
#pragma resource "*.dfm"

//#define CHECK_COUNTS
#define TEST_CREATE_DATABASE_BY_IBX

void __fastcall CloseIB(void);
int __fastcall CreateDatabase(void);

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner):TDataModule(Owner)
{
   #if defined(TEST_CREATE_DATABASE_BY_IBX)
      TIBDatabase
        *cdb=new TIBDatabase(0);

      cdb->DatabaseName="localhost:e:\\TestCreateDatabase.gdb"; // "+ExtractFilePath(Application->ExeName)+"
      cdb->Params->Clear();
      cdb->Params->Add("user_name=sysdba");
      cdb->Params->Add("password=masterkey");
      cdb->Params->Add("lc_ctype=WIN1251");
      cdb->LoginPrompt=false;
      try
      {
         cdb->Open();
      }
      catch(EIBError &eException)
      {
         if(eException.IBErrorCode==isc_io_error)
         {
            cdb->Params->Clear();
            cdb->Params->Add("user \"sysdba\"");
            cdb->Params->Add("password \"masterkey\"");
            cdb->Params->Add("default character set WIN1251");
            cdb->Params->Add("page_size 4096");
            try
            {
               cdb->CreateDatabase();
               cdb->Open();
            }
            catch(EIBInterBaseError &eException)
            {
               ;
            }
            catch(EIBError &eException)
            {
               ;
            }
         }
      }

      if(cdb->Connected)
        cdb->Close();

      delete cdb;
   #endif

#if defined(CHECK_COUNTS)
   TIBDatabase
     *db=new TIBDatabase(0);

   db->DatabaseName=ExtractFilePath(Application->ExeName)+"test.gdb";
   db->LoginPrompt=false;
   db->Params->Clear();
   db->Params->Add("user_name=sysdba");
   db->Params->Add("password=masterkey");
   db->Params->Add("lc_ctype=WIN1251");
   db->Open();

   TIBTransaction
     *tr=new TIBTransaction(0);

   tr->DefaultDatabase=db;

   TIBSQL
     *sql=new TIBSQL(0);

   sql->Database=db;
   sql->Transaction=tr;

   sql->Close();
   delete sql;

   if(tr->InTransaction)
     tr->Rollback();
   delete tr;

   db->Close();
   delete db;
#endif
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   CloseIB();
}
//---------------------------------------------------------------------------

void __fastcall CloseIB(void)
{
   if(DataBases->IBStoredProc1->Active)
     DataBases->IBStoredProc1->Close();
   if(DataBases->IBStoredProc2->Active)
     DataBases->IBStoredProc2->Close();

   if(DataBases->IBSQL1->Open)
     DataBases->IBSQL1->Close();
   if(DataBases->IBSQL2->Open)
     DataBases->IBSQL2->Close();

   if(DataBases->IBQuery->Active)
     DataBases->IBQuery->Close();

   if(DataBases->IBTable->Active)
     DataBases->IBTable->Close();

   if(DataBases->IBTableDBF->Active)
     DataBases->IBTableDBF->Close();

   if(DataBases->IBTransaction1->InTransaction)
     DataBases->IBTransaction1->Rollback();

   if(DataBases->IBTransaction2->InTransaction)
     DataBases->IBTransaction2->Rollback();

   if(DataBases->IBDatabase->Connected)
     DataBases->IBDatabase->Close();
}
//---------------------------------------------------------------------------

int __fastcall CreateDatabase(void)
{
   ISC_STATUS
     status_vector[20];

   char
     *statement="CREATE DATABASE 'd:\\INVENTORY.GDB' USER 'SYSDBA' PASSWORD 'masterkey'";

   TISC_DB_HANDLE
     db_handle=0;

   TISC_TR_HANDLE
     dummy_handle=0;

   _di_IGDSLibrary
     gdsInterface=GetGDSLibrary();

   gdsInterface->isc_dsql_execute_immediate(status_vector,&db_handle,&dummy_handle,0,statement,1,0);

   if(status_vector[0]==1 && status_vector[1])
     {
        return status_vector[1];
     }

   return 0;
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBScriptExecuteError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex, bool &Ignore)
{
   AnsiString
     tmpAnsiString="IBScriptExecuteError\nError \""+Error+"\"\nSQLText \""+SQLText+"\"\n Line #"+IntToStr(LineIndex);

   ShowMessage(tmpAnsiString);
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBScriptParamCheck(TIBScript *Sender, bool &Pause)
{
   //
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBScriptParse(TObject *Sender, TIBParseKind AKind, AnsiString SQLText)
{
   AnsiString
     s="Processed Statement ";

   switch(AKind)
     {
        case Ibscript::stmtDDL : s = "stmtDDL"; break;
        case Ibscript::stmtDML : s = "stmtDML"; break;
        case Ibscript::stmtSET : s = "stmtSET"; break;
        case Ibscript::stmtCONNECT : s = "stmtCONNECT"; break;
        case Ibscript::stmtDrop : s = "stmtDrop"; break;
        case Ibscript::stmtCREATE : s = "stmtCREATE"; break;
        case Ibscript::stmtINPUT : s = "stmtINPUT"; break;
        case Ibscript::stmtUNK : s = "stmtUNK"; break;
        case Ibscript::stmtEMPTY : s = "stmtEMPTY"; break;
        case Ibscript::stmtTERM : s = "stmtTERM"; break;
        case Ibscript::stmtERR : s = "stmtERR"; break;
        case Ibscript::stmtCOMMIT : s = "stmtCOMMIT"; break;
        case Ibscript::stmtROLLBACK : s = "stmtROLLBACK"; break;
     }
  s="Processed Statement "+s+"\nSQLText \""+SQLText+"\"";
  ShowMessage(s);
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBScriptParseError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex)
{
   AnsiString
     tmpAnsiString="IBScriptParcerError Error\nError \""+Error+"\"\nSQLText \""+SQLText+"\"\n Line #"+IntToStr(LineIndex);

   ShowMessage(tmpAnsiString);
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBSQLParserError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex)
{
   AnsiString
     tmpAnsiString="IBSQLParcerError Error\nError \""+Error+"\"\nSQLText \""+SQLText+"\"\n Line #"+IntToStr(LineIndex);

   ShowMessage(tmpAnsiString);
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBSQLParserParse(TObject *Sender, TIBParseKind AKind, AnsiString SQLText)
{
   static
     AnsiString term="";

   AnsiString
     tmp=IBSQLParser->CurrentTokens->Strings[1];

   for(int i=0; i<IBSQLParser->CurrentTokens->Count; i++)
      {
         if(!tmp.IsEmpty())
           tmp+=" ";
         tmp+=IBSQLParser->CurrentTokens->Strings[i];
      }

   if(term!=IBSQLParser->Terminator)
     term=IBSQLParser->Terminator;

   int CL=IBSQLParser->CurrentLine;

   bool f=IBSQLParser->Finished,p=IBSQLParser->Paused;

   if(f)
     CL++;

   if(p)
     CL++;
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBDatabaseLogin(TIBDatabase *Database, TStrings *LoginParams)
{
   return;
}
//---------------------------------------------------------------------------

