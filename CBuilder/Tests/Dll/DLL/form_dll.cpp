//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "form_dll.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TDFMForm *DFMForm;
//---------------------------------------------------------------------------

__fastcall TDFMForm::TDFMForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDFMForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   Action=caFree;
}
//---------------------------------------------------------------------------
