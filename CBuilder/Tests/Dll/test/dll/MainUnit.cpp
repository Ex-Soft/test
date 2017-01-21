//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MainUnit.h"
#include "test_dll.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TTestDllForm *TestDllForm;
//---------------------------------------------------------------------------

__fastcall TTestDllForm::TTestDllForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TTestDllForm::TestPrintClick(TObject *Sender)
{
   test_prn();
}
//---------------------------------------------------------------------------

void __fastcall TTestDllForm::TestMailClick(TObject *Sender)
{
   test_mail();
}
//---------------------------------------------------------------------------

void __fastcall TTestDllForm::Exit1Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------


