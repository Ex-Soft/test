//---------------------------------------------------------------------------

#include <vcl.h>
#include <mmsystem.h>
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
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   HRSRC hRsrc;
   DWORD Size;
   HGLOBAL hGlbl;
   bool Result;

   if(!(hRsrc=FindResource(MainInstance,"IDB_ResSirenData",RT_RCDATA)))
     return;
   if(!(Size=SizeofResource(MainInstance,hRsrc)))
     return;
   if(!(hGlbl=LoadResource(MainInstance,hRsrc)))
     return;
   Result=PlaySound((const char *)hGlbl,0,SND_MEMORY|SND_ASYNC);
   FreeResource(hGlbl);

   if(!(hRsrc=FindResource(MainInstance,"IDB_ResSirenWave","WAVE")))
     return;
   if(!(Size=SizeofResource(MainInstance,hRsrc)))
     return;
   if(!(hGlbl=LoadResource(MainInstance,hRsrc)))
     return;
   Result=PlaySound((const char *)hGlbl,0,SND_MEMORY|SND_ASYNC);
   FreeResource(hGlbl);

   Result=PlaySound("IDB_ResSirenWave",MainInstance,SND_RESOURCE|SND_ASYNC);
}
//---------------------------------------------------------------------------

