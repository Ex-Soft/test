//---------------------------------------------------------------------------

#include <vcl.h>
#include <ComObj.hpp>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#pragma alias "@System@@CheckAutoResult$qqrv"="@System@@CheckAutoResult$qqrl"

#define USE_ADO_CONNECTION

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
   Provider="Microsoft.Jet.OLEDB.4.0";
   ConnectionString="User Id=admin;Password=;Data Source="+ExtractFilePath(Application->ExeName)+"..\\TestAccess.mdb;";
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleCreate(TObject *Sender)
{
   try
   {
      ADOConnection->Provider=WideString(Provider);
      ADOConnection->ConnectionString=WideString(ConnectionString);
      ADOConnection->LoginPrompt=false;

      static_cast<TCustomConnection*>(ADOConnection)->Open();
      if(ADOConnection->Connected)
      {
         #if defined(USE_ADO_CONNECTION)
           ADOQuery1->Connection=ADOConnection;
         #else
           ADOQuery1->ConnectionString=WideString("Provider=")+WideString(Provider)+WideString(";")+WideString(ConnectionString);
         #endif

         ADOQuery1->SQL->Text="select * from staff where birthdate = :pdate";
         ADOQuery1->Parameters->ParamByName(WideString("pdate"))->Value=Now();
         ADOQuery1->Open();
         if(!ADOQuery1->RecordCount)
           ADOQuery1->Close();
      }
   }
   catch(EOleException &eException)
     {
        AnsiString
          Str="EOleException: Source=\""+eException.Source+"\" ErrorCode="+IntToStr(eException.ErrorCode)+" Message=\""+eException.Message+"\"";

        ShowMessage(Str);
     }
   catch(EOleSysError &eException)
     {
        AnsiString
          Str="EOleSysError: ErrorCode="+IntToStr(eException.ErrorCode)+" Message=\""+eException.Message+"\"";

        ShowMessage(Str);
     }
   catch(EOleError &eException)
     {
        AnsiString
          Str="EOleError: Message=\""+eException.Message+"\"";

        ShowMessage(Str);
     }
   catch(EDatabaseError &eException)
     {
        AnsiString
          Str="EDatabaseError: Message=\""+eException.Message+"\"";

        ShowMessage(Str);
     }
   catch(Exception &eException)
     {
        AnsiString
          Str="Exception: Message=\""+eException.Message+"\"";

        ShowMessage(Str);
     }
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   if(ADOQuery1->Active)
     ADOQuery1->Close();

   if(ADOConnection->Connected)
     ADOConnection->Close();
}
//---------------------------------------------------------------------------

