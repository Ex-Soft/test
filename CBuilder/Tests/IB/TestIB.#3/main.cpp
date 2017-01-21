//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonCreateByIBXClick(TObject *Sender)
{
   DataBase->IBDatabase->DatabaseName="localhost:"+ExtractFilePath(Application->ExeName)+"TestCreateDatabase.gdb";
   DataBase->IBDatabase->Params->Clear();
   DataBase->IBDatabase->Params->Add("user_name=sysdba");
   DataBase->IBDatabase->Params->Add("password=masterkey");
   DataBase->IBDatabase->Params->Add("lc_ctype=WIN1251");
   DataBase->IBDatabase->LoginPrompt=false;
   try
   {
      DataBase->IBDatabase->Open();
   }
   catch(EIBError &eException)
   {
      if(eException.IBErrorCode==isc_io_error)
      {
         DataBase->IBDatabase->Params->Clear();
         DataBase->IBDatabase->Params->Add("user 'sysdba'");
         DataBase->IBDatabase->Params->Add("password 'masterkey'");
         DataBase->IBDatabase->Params->Add("page_size 8192");
         DataBase->IBDatabase->Params->Add("default character set WIN1251");
         try
         {
            DataBase->IBDatabase->CreateDatabase();
            DataBase->IBDatabase->Open();
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
}
//---------------------------------------------------------------------------

