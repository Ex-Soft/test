//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "FramUni_.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

AnsiString
  FileName;

TOpenFileFrame *OpenFileFrame;
//---------------------------------------------------------------------------

__fastcall TOpenFileFrame::TOpenFileFrame(TComponent* Owner):TFrame(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TOpenFileFrame::ApplicationEvents1ShowHint(AnsiString &HintStr, bool &CanShow, THintInfo &HintInfo)
{
   if(HintInfo.HintControl==Edit1)
     if(Label1->Canvas->TextWidth(Edit1->Text)>Edit1->ClientWidth)
       {
          HintStr=Edit1->Text;
          ApplicationEvents1->CancelDispatch();
       }
}
//---------------------------------------------------------------------------

void __fastcall TOpenFileFrame::ViewButtonClick(TObject *Sender)
{
   if(OpenDialog1->Execute())
     {
        Edit1->Text=OpenDialog1->FileName;
        FileName=OpenDialog1->FileName;
     }
}
//---------------------------------------------------------------------------

void __fastcall TOpenFileFrame::Edit1Exit(TObject *Sender)
{
   FileName=Edit1->Text;
}
//---------------------------------------------------------------------------
