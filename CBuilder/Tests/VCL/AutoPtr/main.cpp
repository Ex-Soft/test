//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   tmpAutoPtr.reset(new TTestClass("1"));
   tmpAutoPtr->SetStaticAnsiString("SetStaticVariable");
   tmpAutoPtr->SetStaticInt(999);

   AnsiString
     tmpAnsiString=tmpAutoPtr->GetStaticAnsiString();

   int
     tmpInt=tmpAutoPtr->GetStaticInt();

   tmpAnsiString=tmpAutoPtr->GetNonStaticVariable();
}
//---------------------------------------------------------------------------

__fastcall TMainForm::~TMainForm(void)
{
   AnsiString
     tmpAnsiString=tmpAutoPtr->GetStaticAnsiString();

   tmpAnsiString=tmpAutoPtr->GetNonStaticVariable();

   int
     tmpInt=tmpAutoPtr->GetStaticInt();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   AnsiString
     tmpAnsiString=tmpAutoPtr->GetStaticAnsiString();

   tmpAnsiString=tmpAutoPtr->GetNonStaticVariable();

   int
     tmpInt=tmpAutoPtr->GetStaticInt();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   AnsiString
     tmpAnsiString=tmpAutoPtr->GetStaticAnsiString();

   tmpAnsiString=tmpAutoPtr->GetNonStaticVariable();

   int
     tmpInt=tmpAutoPtr->GetStaticInt();
}
//---------------------------------------------------------------------------

