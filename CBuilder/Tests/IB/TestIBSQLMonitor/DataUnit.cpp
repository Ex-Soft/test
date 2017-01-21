//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleCreate(TObject *Sender)
{
   IBDatabase->DatabaseName=ExtractFilePath(Application->ExeName)+"test.gdb";
   IBDatabase->LoginPrompt=false;
   IBDatabase->Params->Clear();
   IBDatabase->Params->Add("user_name=sysdba");
   IBDatabase->Params->Add("password=masterkey");
   IBDatabase->Params->Add("lc_ctype=WIN1251");
   IBDatabase->Open();

   IBTransaction->DefaultDatabase=IBDatabase;
   IBTransaction->Params->Clear();
   IBTransaction->Params->Add("nowait");
   IBTransaction->Params->Add("read_committed");
   IBTransaction->Params->Add("rec_version");

   IBSQL->Database=IBDatabase;
   IBSQL->Transaction=IBTransaction;
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   CloseIB();
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::CloseIB(void)
{
   if(IBSQL->Open)
     IBSQL->Close();

   if(IBTransaction->InTransaction)
     IBTransaction->Rollback();

   if(IBDatabase->Connected)
     IBDatabase->Close();
}
//---------------------------------------------------------------------------
