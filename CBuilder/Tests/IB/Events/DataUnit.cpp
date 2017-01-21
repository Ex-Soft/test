//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
#include "main.h"
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

   try
     {
        IBDatabase->Open();
     }
   catch(EIBError &eException)
     {
        Mess="Помилка відкриття БД "+IBDatabaseName.LowerCase()+" на сервері "+IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return false;
     }

   IBQuery->Database=IBDatabase;
   IBQuery->Transaction=IBTransaction;

   IBViewQuery->Database=IBDatabase;
   IBViewQuery->Transaction=IBTransaction;

   DataSource->DataSet=IBViewQuery;

   IBEvents->Database=IBDatabase;
   IBEvents->Events->Clear();
   IBEvents->Events->Add("InsertBefore");
   IBEvents->Events->Add("InsertAfter");
   IBEvents->Events->Add("DeleteBefore");
   IBEvents->Events->Add("DeleteAfter");
   IBEvents->Events->Add("UpdateBefore");
   IBEvents->Events->Add("UpdateAfter");
   IBEvents->RegisterEvents();

   return true;
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(IBQuery->Active)
     IBQuery->Close();
   if(IBViewQuery->Active)
     IBViewQuery->Close();

   if(IBTransaction->InTransaction)
     IBTransaction->Rollback();

   if(IBDatabase->Connected)
     {
        IBEvents->UnRegisterEvents();
        IBDatabase->Close();
     }
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::IBEventsEventAlert(TObject *Sender,
      AnsiString EventName, int EventCount, bool &CancelAlerts)
{
   if(EventName=="InsertBefore")
     MainForm->IBEvent=1;
   if(EventName=="InsertAfter")
     MainForm->IBEvent=2;
   if(EventName=="DeleteBefore")
     MainForm->IBEvent=3;
   if(EventName=="DeleteAfter")
     MainForm->IBEvent=4;
   if(EventName=="UpdateBefore")
     MainForm->IBEvent=5;
   if(EventName=="UpdateAfter")
     MainForm->IBEvent=6;
   MainForm->IBEventCount=EventCount;
   MainForm->IBCancelAlerts=CancelAlerts;
}
//---------------------------------------------------------------------------

