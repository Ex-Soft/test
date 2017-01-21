//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "test_prn.h"
#include "test_mail.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TTestForm *TestForm;
//---------------------------------------------------------------------------

__fastcall TTestForm::TTestForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TTestForm::Testprint1Click(TObject *Sender)
{
   test_prn();
}
//---------------------------------------------------------------------------

void __fastcall TTestForm::Testmail1Click(TObject *Sender)
{
   test_mail();
}
//---------------------------------------------------------------------------

void __fastcall TTestForm::Exit1Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------


