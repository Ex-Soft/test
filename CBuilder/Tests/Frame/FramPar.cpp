//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "FramPar.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TFrameWithParam *FrameWithParam;
//---------------------------------------------------------------------------

__fastcall TFrameWithParam::TFrameWithParam(TComponent* Owner):TFrame(Owner)
{
}
//---------------------------------------------------------------------------

__fastcall TFrameWithParam::TFrameWithParam(TComponent* Owner, AnsiString aAnsiString, int aInt, TDateTime aDateTime):TFrame(Owner)
{
   AnsiStringParam=aAnsiString;
   IntParam=aInt;
   DateTimeParam=aDateTime;
}
//---------------------------------------------------------------------------

void __fastcall TFrameWithParam::ButtonShowClick(TObject *Sender)
{
   LabelParam->Caption=AnsiStringParam+" "+IntToStr(IntParam)+" "+DateTimeParam.DateTimeString();
}
//---------------------------------------------------------------------------
