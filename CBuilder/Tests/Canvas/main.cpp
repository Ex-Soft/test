//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "Splash.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Top=0;
   ForReallyAnyTestBitBtn->Left=0;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   Application->CreateForm(__classid(TSplashForm),&SplashForm);
   SplashForm->ShowModal();
   SplashForm->Free();
}
//---------------------------------------------------------------------------
