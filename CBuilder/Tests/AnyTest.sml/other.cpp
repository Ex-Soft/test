//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "other.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TOtherForm *OtherForm;
//---------------------------------------------------------------------------

__fastcall TOtherForm::TOtherForm(TComponent* Owner):TForm(Owner)
{
   HandleNeeded();
}
//---------------------------------------------------------------------------

void __fastcall TOtherForm::FormCreate(TObject *Sender)
{
   HandleNeeded();
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TOtherForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
//
}
//---------------------------------------------------------------------------

void __fastcall TOtherForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   Action=caFree;
}
//---------------------------------------------------------------------------

