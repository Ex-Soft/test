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
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(TestTable->Active)
     TestTable->Close();
   if(Query->Active)
     Query->Close();
}
//---------------------------------------------------------------------------

