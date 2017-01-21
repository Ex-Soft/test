//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "U1Mess1.h"
#include "U2Mess1.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
   Form2->Show();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
   Form2->Perform(WM_CLOSE,0,0);
//   SendMessage(Form2->Handle,WM_CLOSE,0,0);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button3Click(TObject *Sender)
{
   WinExec("PMess2.exe",SW_RESTORE);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button4Click(TObject *Sender)
{
   SendMessage(FindWindow("TForm1","Приложение PMess2"),WM_CLOSE,0,0);
}
//---------------------------------------------------------------------------

