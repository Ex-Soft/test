//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleCreate(TObject *Sender)
{
   AnsiString
     tmpString;

   IBDatabase->DatabaseName="E:\\Soft.src\\CBuilder\\Tests\\IB\\TestIB.#1\\test.gdb";
   IBDatabase->LoginPrompt=false;
   IBDatabase->Params->Clear();
   IBDatabase->Params->Add("user_name=sysdba");
   IBDatabase->Params->Add("password=masterkey");
   IBDatabase->Params->Add("lc_ctype=WIN1251");
   try
   {
      IBDatabase->Open();
   }
   catch(EIBClientError &eException)
   {
      tmpString=eException.Message;
   }
   catch(EIBInterBaseError &eException)
   {
      tmpString="EIBInterBaseError: IBErrorCode="+IntToStr(eException.IBErrorCode)+" SQLCode="+IntToStr(eException.SQLCode)+" Message=\""+eException.Message+"\"";
      ShowMessage(tmpString);
   }
   catch(EIBInterBaseRoleError &eException)
   {
      tmpString=eException.Message;
   }
   catch(EIBError &eException)
   {
      tmpString=eException.Message;
   }
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(IBDatabase->Connected)
     IBDatabase->Close();
}
//---------------------------------------------------------------------------
