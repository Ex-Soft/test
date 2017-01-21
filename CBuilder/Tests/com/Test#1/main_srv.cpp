//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main_srv.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SpeedButton1Click(TObject *Sender)
{
   Memo1->Lines->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SpeedButton2Click(TObject *Sender)
{
   if(OpenDialog1->Execute())
     Memo1->Lines->LoadFromFile(OpenDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SpeedButton3Click(TObject *Sender)
{
   if(SaveDialog1->Execute())
     Memo1->Lines->SaveToFile(SaveDialog1->FileName);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SpeedButton4Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------
