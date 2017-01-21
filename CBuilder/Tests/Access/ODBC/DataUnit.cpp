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
   try
   {
      Query->DatabaseName="TestAccessByODBC";
      Query->SQL->Text="select * from Staff";

      //Session->KeepConnections=true;

      int
        DatabasesCount=Session->DatabaseCount;

      //Session->Databases[0]->LoginPrompt=false;
      Query->Open();
      DatabasesCount=Session->DatabaseCount;
      Session->Databases[0]->LoginPrompt=false;

      DataSource->DataSet=Query;
   }
   catch(EListError &eException)
   {
      ShowMessage(eException.Message);
   }
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(Query->Active)
     Query->Close();
}
//---------------------------------------------------------------------------
