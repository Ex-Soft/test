//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main_exe.h"
#include "main_dll.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NewButtonClick(TObject *Sender)
{
   ShowDynamicTestForm(Handle,"Test ICO from New");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DFMButtonClick(TObject *Sender)
{
   ShowStaticTestForm(Handle,"Test ICO from DFM");
}
//---------------------------------------------------------------------------

