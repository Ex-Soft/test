//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "child.h"
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "FrameTst"
#pragma resource "*.dfm"

//#define EXC_IN_CONSTRUCTOR
//#define EXC_IN_ON_CREATE

extern std::fstream
  File;

TChildForm *ChildForm;
//---------------------------------------------------------------------------

__fastcall TChildForm::TChildForm(TComponent* Owner, int aInt1, int aInt2):TForm(Owner)
{
   if(File.is_open() && File.good())
     File<<"TChildForm::TChildForm()"<<std::endl;

   AnsiString
     Mess=" Owner=0x"+LowerCase(IntToHex((int)Owner,8))+" aInt1="+IntToStr(aInt1)+" aInt2="+IntToStr(aInt2);

   #if defined(EXC_IN_CONSTRUCTOR)
     throw Exception(__FUNC__+Mess);
   #endif
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormActivate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnActivate"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnClose"<<std::endl;
   if(MainForm->caFreeCheckBox->Checked)
     Action=caFree;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormCloseQuery(TObject *Sender, bool &CanClose)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnCloseQuery"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormCreate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnCreate"<<std::endl;

   #if defined(EXC_IN_ON_CREATE)
     throw Exception(__FUNC__);
   #endif
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormDeactivate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnDeactivate"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormDestroy(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnDestroy"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormHide(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnHide"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormPaint(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnPaint"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TChildForm::FormShow(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"ChildForm OnShow"<<std::endl;
}
//---------------------------------------------------------------------------
