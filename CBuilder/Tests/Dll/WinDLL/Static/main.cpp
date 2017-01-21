//---------------------------------------------------------------------------

#include <vcl.h>
#include <shlwapi.h>
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

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";

   long
     btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);

   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   char
     in[1024],
     out[1024];

   DWORD
        len=1024;

   strcpy(in,"Привет");

   HRESULT
     Result=UrlEscape(in,out,&len,0);

   strcpy(in,out);
}
//---------------------------------------------------------------------------



