//---------------------------------------------------------------------------

#include <vcl.h>
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
   DoItBitBtn->Left=0;
   DoItBitBtn->Width=ClientWidth;
   DoItBitBtn->Caption=AnsiString("Do\r\n")+"It!\r\n"+"Button";
   long btnstyle=GetWindowLong(DoItBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(DoItBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LoadLibraryCheckBoxClick(TObject *Sender)
{
   if(!LoadLibraryCheckBox->Checked)
     {
        InitializePointerCheckBox->Checked=false;
        CallFunctionCheckBox->Checked=false;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::InitializePointerCheckBoxClick(TObject *Sender)
{
   if(!InitializePointerCheckBox->Checked)
     CallFunctionCheckBox->Checked=false;
   else
     LoadLibraryCheckBox->Checked=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CallFunctionCheckBoxClick(TObject *Sender)
{
   if(CallFunctionCheckBox->Checked)
     {
        LoadLibraryCheckBox->Checked=true;
        InitializePointerCheckBox->Checked=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoItBitBtnClick(TObject *Sender)
{
   AnsiString a,b;

   b="b";
   a=b;
   *b.c_str()='A';
   b="B";

   HINSTANCE dllInstance=0;
   void (*TestingVoidPtr)(void);

   try
     {
        if(!LoadLibraryCheckBox->Checked)
          return;

        if(!(dllInstance=LoadLibrary("Testing.dll")))
          return;

        if(!InitializePointerCheckBox->Checked)
          return;

        TestingVoidPtr=(void (*)(void))GetProcAddress(dllInstance,"_VoidFunction");

        if(!CallFunctionCheckBox->Checked)
          return;

        if(TestingVoidPtr)
          TestingVoidPtr();
     }
   __finally
     {
        if(dllInstance)
          FreeLibrary(dllInstance);

        DoItBitBtn->Enabled=true;
        DoItBitBtn->SetFocus();
     }
}
//---------------------------------------------------------------------------




