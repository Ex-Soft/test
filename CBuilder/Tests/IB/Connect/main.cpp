//---------------------------------------------------------------------------

#include <vcl.h>
#include <StrUtils.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   ConnectToDatabase();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::EditInputChange(TObject *Sender)
{
   AnsiString
     Signature=EditInput->Text.Trim();

   if(Signature.IsEmpty())
     return;

   try
   {
      if(!IBTransaction->InTransaction)
        IBTransaction->StartTransaction();

      if(!IBQuery->Prepared)
      {
         IBQuery->SQL->Text="select * from \"TOVAR\" where \"NAME\" like :\"Signature\"";
         IBQuery->Prepare();
      }

      if(IBQuery->Active)
        IBQuery->Close();

      IBQuery->ParamByName("Signature")->AsString=Signature+"%";
      IBQuery->Open();
   }
   catch(EIBClientError &eException)
   {
      if(eException.SQLCode==33 /* Dataset open */)
        ;
   }
   catch(EIBInterBaseError &eException)
   {
      if(eException.IBErrorCode==isc_lost_db_connection)
      {
         int
           CountAttempts=3,
           Attempt;

         bool
           Connect=false;

         for(Attempt=0; !Connect && Attempt<CountAttempts; ++Attempt)
            Connect=ConnectToDatabase();

         if(!Connect && Attempt==CountAttempts)
           throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): Кердык!!!");

         try
         {
            if(IBQuery->Prepared)
              IBQuery->UnPrepare();
         }
         catch(EIBClientError &eException)
         {
            if(eException.SQLCode==33 /* Dataset open */)
              ;
         }
      }
   }
   catch(EIBError &eException)
   {
   }
   catch(EDatabaseError &eException)
   {
   }
   catch(Exception &eException)
   {
   }
}
//---------------------------------------------------------------------------

bool __fastcall TMainForm::ConnectToDatabase(void)
{
   bool
     Connect=false;

   try
   {
      IBDatabase->Open();
      Connect=true;
   }
   catch(EIBClientError &eException)
   {
   }
   catch(EIBInterBaseError &eException)
   {
      if(eException.IBErrorCode==isc_unavailable)
        ;
   }
   catch(EIBError &eException)
   {
   }
   catch(EDatabaseError &eException)
   {
   }
   catch(Exception &eException)
   {
   }

   return(Connect);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IBSQLMonitorSQL(AnsiString EventText, TDateTime EventTime)
{
   Memo->Lines->Add(AnsiReplaceStr(EventText,"\r\n"," "));
}
//---------------------------------------------------------------------------

