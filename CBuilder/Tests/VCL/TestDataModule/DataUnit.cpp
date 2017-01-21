//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

extern std::fstream
  File;

TDataModule1 *DataModule1;
//---------------------------------------------------------------------------

__fastcall TDataModule1::TDataModule1(TComponent* Owner):TDataModule(Owner)
{
   File<<"TDataModule1::TDataModule1()"<<std::endl;

   ADOConnection=new TADOConnection(0);
   ADOQuery=new TADOQuery(0);
}
//---------------------------------------------------------------------------

void __fastcall TDataModule1::DataModuleCreate(TObject *Sender)
{
   File<<"TDataModule1::DataModuleCreate()"<<std::endl;

   AnsiString
     Provider=
     "Sybase.ASEOLEDBProvider",
     //"ASEOLEDB",

     ConnectionString=
     "Server Name=localhost;Server Port Address=5000;User ID=sa;Password=";
     //"Server=localhost;Port=5000;Language=russian;Initial Catalog=master;User ID=sa;Password=";

   ADOConnection->Provider=WideString(Provider);
   ADOConnection->ConnectionString=WideString(ConnectionString);
   ADOConnection->LoginPrompt=false;
   static_cast<TCustomConnection*>(ADOConnection)->Open();
   if(ADOConnection->Connected)
   {
      File<<"ADOConnection->Connected"<<std::endl;

      ADOQuery->Connection=ADOConnection;

      ADOQuery->SQL->Text="select * from sysobjects";
      ADOQuery->Open();
   }
}
//---------------------------------------------------------------------------

void __fastcall TDataModule1::DataModuleDestroy(TObject *Sender)
{
   if(ADOQuery)
   {
      if(ADOQuery->Active)
        ADOQuery->Close();

      delete ADOQuery;
   }

   if(ADOConnection)
   {
      if(ADOConnection->Connected)
        ADOConnection->Close();

      delete ADOConnection;
   }

   if(File.is_open() && File.good())
     File<<"TDataModule1::DataModuleDestroy()"<<std::endl;
}
//---------------------------------------------------------------------------

