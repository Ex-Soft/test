//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Splash.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TSplashForm *SplashForm;
//---------------------------------------------------------------------------

__fastcall TSplashForm::TSplashForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TSplashForm::FormShow(TObject *Sender)
{
   TypeText("Test text");
}
//---------------------------------------------------------------------------

void __fastcall TSplashForm::TypeText(AnsiString Text)
{
   //#define WithFormName_

   #if defined(WithFormName)
      SplashForm->Canvas->Font->Color=clRed;
      SplashForm->Canvas->Font->Size=25;
      SplashForm->Canvas->TextOut((SplashForm->ClientWidth-SplashForm->Canvas->TextWidth(Text))/2,SplashForm->ClientHeight-SplashForm->Canvas->Font->Size-13,Text);

      SplashForm->Canvas->MoveTo(140,10);
      SplashForm->Canvas->Pen->Color = clWhite;
      SplashForm->Canvas->LineTo(170,60);
      SplashForm->Canvas->LineTo(110,60);
      SplashForm->Canvas->Pen->Color = clBlack;
      SplashForm->Canvas->LineTo(140,10);
   #else
      Canvas->Font->Color=clRed;
      Canvas->Font->Size=25;
      Canvas->TextOut((ClientWidth-Canvas->TextWidth(Text))/2,ClientHeight-Canvas->Font->Size-13,Text);

      Canvas->MoveTo(140,10);
      Canvas->Pen->Color = clWhite;
      Canvas->LineTo(170,60);
      Canvas->LineTo(110,60);
      Canvas->Pen->Color = clBlack;
      Canvas->LineTo(140,10);
   #endif
}
//---------------------------------------------------------------------------

void __fastcall TSplashForm::ButtonClick(TObject *Sender)
{
   TypeText("Test text");
}
//---------------------------------------------------------------------------

void __fastcall TSplashForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   Action=caFree;
}
//---------------------------------------------------------------------------

void __fastcall TSplashForm::FormPaint(TObject *Sender)
{
//   ShowMessage("OnPain");
   TypeText("Test text");
}
//---------------------------------------------------------------------------

