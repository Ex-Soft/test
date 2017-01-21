//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Frame.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TFrameTest *FrameTest;
//---------------------------------------------------------------------------

__fastcall TFrameTest::TFrameTest(TComponent* Owner):TFrame(Owner)
{
}
//---------------------------------------------------------------------------
