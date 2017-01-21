//---------------------------------------------------------------------------

#include <vcl.h>
#include <stdio.h>
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
   HINSTANCE dllInstance=NULL;
   void (*TestingVoidPtr)(void);
   void (*TestingFilePtr)(FILE *, AnsiString);
   FILE *FilePtr=NULL;

   typedef void (*VOID_VOID_TYP)(void);

   VOID_VOID_TYP
     VoidVoidPtr=0;

   try
     {
        if(!LoadLibraryCheckBox->Checked)
          return;

        if(!(dllInstance=LoadLibrary("Testing.dll")))
          return;

        if(!InitializePointerCheckBox->Checked)
          return;

        switch(TypeFunctionRadioGroup->ItemIndex)
          {
             case 0 : {
                         TestingVoidPtr=(void (*)(void))GetProcAddress(dllInstance,"_VoidFunction");
                         VoidVoidPtr=(VOID_VOID_TYP)GetProcAddress(dllInstance,"_VoidFunction");

                         if(!CallFunctionCheckBox->Checked)
                           return;

                         if(TestingVoidPtr)
                           TestingVoidPtr();

                         if(VoidVoidPtr)
                           VoidVoidPtr();

                         break;
                      }
             case 1 : {
                         TestingFilePtr=(void (*)(FILE *, AnsiString))GetProcAddress(dllInstance,"_FileFunction");

                         if(!CallFunctionCheckBox->Checked)
                           return;

                         if(TestingFilePtr)
                           {
                              if(!(FilePtr=fopen("Test.txt","a+t")))
                                return;

                              fputs("Test from main (b4)\n",FilePtr);
                                           //FilePtr
                              TestingFilePtr(FilePtr,"Test FILE *FilePtr\n");

                              fputs("Test from main (after)\n",FilePtr);
                           }
                         break;
                      }
          }
     }
   __finally
     {
        if(FilePtr)
          fclose(FilePtr);

        if(dllInstance)
          FreeLibrary(dllInstance);

        DoItBitBtn->Enabled=true;
        DoItBitBtn->SetFocus();
     }
}
//---------------------------------------------------------------------------




