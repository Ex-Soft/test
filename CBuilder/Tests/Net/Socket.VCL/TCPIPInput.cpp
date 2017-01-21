//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "TCPIPInput.h"
#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TPreference1 *Preference1;
//---------------------------------------------------------------------------

__fastcall TPreference1::TPreference1(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TPreference1::IsServerClick(TObject *Sender)
{
    MainForm->IsServer=true;
}
//---------------------------------------------------------------------------

void __fastcall TPreference1::IsClientClick(TObject *Sender)
{
    MainForm->IsServer=false;
}
//---------------------------------------------------------------------------


void __fastcall TPreference1::BitBtn1Click(TObject *Sender)
{
    NickName->Text=NickName->Text.Trim();
    if(NickName->Text.IsEmpty())
      {
         NickName->SetFocus();
         ModalResult=mrNone;
         return;
      }
    else
      MainForm->NickName=NickName->Text;
}
//---------------------------------------------------------------------------

void __fastcall TPreference1::FormClose(TObject *Sender, TCloseAction &Action)
{
   Action=caFree;
}
//---------------------------------------------------------------------------

