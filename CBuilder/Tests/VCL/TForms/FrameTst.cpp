//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "FrameTst.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define EXC_IN_CONSTRUCTOR

extern std::fstream
  File;

TTestFrame *TestFrame;
//---------------------------------------------------------------------------

__fastcall TTestFrame::TTestFrame(TComponent* Owner):TFrame(Owner)
{
   if(File.is_open() && File.good())
     File<<"TTestFrame::TTestFrame()"<<std::endl;

   AnsiString
     Mess=" Owner=0x"+LowerCase(IntToHex((int)Owner,8));

   #if defined(EXC_IN_CONSTRUCTOR)
     throw Exception(__FUNC__+Mess);
   #endif
}
//---------------------------------------------------------------------------
