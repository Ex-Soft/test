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
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonClick(TObject *Sender)
{
   TButton
     *tmpButton;

   if(!(tmpButton=dynamic_cast<TButton *>(Sender)))
     return;

   ShowWindow(Application->Handle,tmpButton->Name=="ButtonHide" ? SW_HIDE : SW_SHOW);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormActivate(TObject *Sender)
{
   ShowWindow(Application->Handle,SW_HIDE);
}
//---------------------------------------------------------------------------

