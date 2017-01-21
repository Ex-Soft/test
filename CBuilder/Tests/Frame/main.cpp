//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "FramUnit"
#pragma link "FramUni_"
#pragma link "FramPar"
#pragma resource "*.dfm"

extern int
  D;

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   if(FrameWithParam1)
     delete FrameWithParam1;
   FrameWithParam1=new TFrameWithParam(MainForm,"FrameWithParam1",1,Now()+1);
   FrameWithParam1->Parent=MainForm;
   FrameWithParam1->Left=9;
   FrameWithParam1->Top=400;

   /*if(FrameWithParam2)
     delete FrameWithParam2;
   FrameWithParam2=new TFrameWithParam(MainForm,"FrameWithParam2",2,Now()+2);
   FrameWithParam2->Parent=MainForm;
   FrameWithParam2->Left=233;
   FrameWithParam2->Top=400;*/
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ShowButtonClick(TObject *Sender)
{
   Label1->Caption="B (Frame11)="+IntToStr(LabelFrame11->B)+" B (Frame12)="+IntToStr(LabelFrame12->B)+" C="+IntToStr(TLabelFrame::C)+" D="+IntToStr(D);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(FrameWithParam1)
     delete FrameWithParam1;
   //if(FrameWithParam2)
   //  delete FrameWithParam2;
}
//---------------------------------------------------------------------------

