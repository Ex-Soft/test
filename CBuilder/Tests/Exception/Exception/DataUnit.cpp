//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner)
        : TDataModule(Owner)
{
   IBUser="sysdba";
   IBUserPassword="_masterkey";
   IBServerName="localhost";
   IBDatabaseName=ExtractFilePath(Application->ExeName)+"test.gdb";
}
//---------------------------------------------------------------------------

bool __fastcall TDataBases::OpenDatbase(void)
{
   AnsiString Mess;

   IBDatabase->DatabaseName=IBServerName+":"+IBDatabaseName;
   IBDatabase->LoginPrompt=false;
   IBDatabase->DefaultTransaction=DataBases->IBTransaction;
   IBDatabase->Params->Clear();
   IBDatabase->Params->Add("user_name="+IBUser);
   IBDatabase->Params->Add("password="+IBUserPassword);
   IBDatabase->Params->Add("lc_ctype=WIN1251");

   IBTransaction->DefaultDatabase=IBDatabase;
   IBTransaction->Params->Clear();
   IBTransaction->Params->Add("nowait");
   IBTransaction->Params->Add("read_committed");
   IBTransaction->Params->Add("rec_version");

   EIBError *eIBError=0;

   try
     {
        try
          {
             IBDatabase->Open();
          }
        catch(EIBError &eException)
          {
             if(eException.IBErrorCode==isc_login)
               {
                  eIBError=new EIBError(eException.SQLCode,eException.IBErrorCode,eException.Message);
                  throw *eIBError;
               }
             else
               {
                  Mess="Помилка відкриття БД "+IBDatabaseName.LowerCase()+" на сервері "+IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
                  Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
                  return false;
               }
          }
     }
   __finally
     {
        if(eIBError);
//          delete eIBError;
     }
   IBSQL->Database=IBDatabase;
   IBSQL->Transaction=IBTransaction;

   return true;
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(IBSQL->Open)
     IBSQL->Close();

   if(IBTransaction->InTransaction)
     IBTransaction->Rollback();

   if(IBDatabase->Connected)
     IBDatabase->Close();
}
//---------------------------------------------------------------------------


