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
