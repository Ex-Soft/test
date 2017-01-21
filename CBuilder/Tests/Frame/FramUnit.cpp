//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "FramUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

int
  TLabelFrame::C=1;

int
  D;

TLabelFrame *LabelFrame;
//---------------------------------------------------------------------------

__fastcall TLabelFrame::TLabelFrame(TComponent* Owner):TFrame(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TLabelFrame::SetupButtonClick(TObject *Sender)
{
   A=B=C=D=1;
   Label1->Caption="A="+IntToStr(A)+" B="+IntToStr(B)+" C="+IntToStr(C)+" D="+IntToStr(D);
}
//---------------------------------------------------------------------------

void __fastcall TLabelFrame::IncButtonClick(TObject *Sender)
{
   A++;
   B++;
   C++;
   D++;
   Label1->Caption="A="+IntToStr(A)+" B="+IntToStr(B)+" C="+IntToStr(C)+" D="+IntToStr(D);
}
//---------------------------------------------------------------------------

void __fastcall TLabelFrame::ShowButtonClick(TObject *Sender)
{
   Label1->Caption="A="+IntToStr(A)+" B="+IntToStr(B)+" C="+IntToStr(C)+" D="+IntToStr(D);
}
//---------------------------------------------------------------------------
