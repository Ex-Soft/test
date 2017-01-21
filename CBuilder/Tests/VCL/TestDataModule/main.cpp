//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

extern std::fstream
  File;

TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner):TForm(Owner)
{
   File<<"TForm1::TForm1()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
   File<<"TForm1::FormCreate()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormActivate(TObject *Sender)
{
   File<<"TForm1::FormActivate()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormShow(TObject *Sender)
{
   File<<"TForm1::FormShow()"<<std::endl;
}
//---------------------------------------------------------------------------


void __fastcall TForm1::FormCloseQuery(TObject *Sender, bool &CanClose)
{
   if(File.is_open() && File.good())
     File<<"TForm1::FormCloseQuery()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(File.is_open() && File.good())
     File<<"TForm1::FormClose()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormDeactivate(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"TForm1::FormDeactivate()"<<std::endl;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormDestroy(TObject *Sender)
{
   if(File.is_open() && File.good())
     File<<"TForm1::FormDestroy()"<<std::endl;
}
//---------------------------------------------------------------------------

