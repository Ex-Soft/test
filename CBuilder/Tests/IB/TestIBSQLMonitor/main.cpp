//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   dllInstance=0;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonOpenClick(TObject *Sender)
{
   DataBase->IBDatabase->Open();
   ButtonOpen->Enabled=false;
   ButtonClose->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonCloseClick(TObject *Sender)
{
   DataBase->CloseIB();
   ButtonOpen->Enabled=true;
   ButtonClose->Enabled=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonLoadClick(TObject *Sender)
{
   dllInstance=LoadLibrary("IBSQLMonitor.dll");
   ButtonLoad->Enabled=false;
   ButtonFree->Enabled=true;
   ButtonEnabled->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonFreeClick(TObject *Sender)
{
   if(dllInstance)
   {
      FreeLibrary(dllInstance);
      ButtonLoad->Enabled=true;
      ButtonFree->Enabled=false;
      ButtonEnabled->Enabled=false;
      ButtonDisabled->Enabled=false;
   }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonEnabledDisabledClick(TObject *Sender)
{
   TButton
     *tmpButton;

   if(!(tmpButton=dynamic_cast<TButton *>(Sender)))
     return;

   char
     *FunctionName;

   if(tmpButton->Name=="ButtonEnabled")
   {
      FunctionName="IBSQLMonitorEnabled";
      ButtonEnabled->Enabled=false;
      ButtonDisabled->Enabled=true;
   }
   else if(tmpButton->Name=="ButtonDisabled")
   {
      FunctionName="IBSQLMonitorDisabled";
      ButtonEnabled->Enabled=true;
      ButtonDisabled->Enabled=false;
   }

   if(dllInstance)
   {
      void (*FunctionPtr)(void);
      if(FunctionPtr=(void (*)(void))GetProcAddress(dllInstance,FunctionName))
        FunctionPtr();
   }
}
//---------------------------------------------------------------------------

