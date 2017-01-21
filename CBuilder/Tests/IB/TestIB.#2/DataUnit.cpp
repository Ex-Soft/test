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
   IBUserPassword="masterkey";
   IBServerName="localhost";
   IBDatabaseName="e:\\igor.usi\\reinsur.new\\insuranc.gdb";
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleCreate(TObject *Sender)
{
   AnsiString Mess;

   if(!IBServerName.IsEmpty())
     IBDatabase->DatabaseName=IBServerName+":"+IBDatabaseName;
   else
     IBDatabase->DatabaseName=IBDatabaseName;
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

   try
     {
//        IBDatabase->Open();
     }
   catch(EIBError &eException)
     {
        Mess="Помилка відкриття БД "+IBDatabaseName.LowerCase()+" на сервері "+IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

//   if(!IBDatabase->TestConnected())
//     {
//        Mess="Помилка відкриття БД "+IBDatabaseName+" на сервері "+IBServerName;
//        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
//        return;
//     }

   IBSQL1->Database=IBDatabase;
   IBSQL1->Transaction=IBTransaction;

   IBSQL2->Database=IBDatabase;
   IBSQL2->Transaction=IBTransaction;

   IBStoredProc->Database=IBDatabase;
   IBStoredProc->Transaction=IBTransaction;

   IBQuery1->Database=IBDatabase;
   IBQuery1->Transaction=IBTransaction;

   IBQuery2->Database=IBDatabase;
   IBQuery2->Transaction=IBTransaction;

}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
  if(IBDatabase->Connected)
     {
        if(IBTransaction->InTransaction)
          IBTransaction->Rollback();
        IBSQL1->Close();
        IBSQL2->Close();
        IBQuery1->Close();
        IBQuery2->Close();
        IBDatabase->Close();
     }
}
//---------------------------------------------------------------------------

