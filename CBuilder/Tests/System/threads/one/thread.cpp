//---------------------------------------------------------------------------

#include <vcl.h>
#include <math.h>
#pragma hdrstop

#include "thread.h"
#include "main.h"
#pragma package(smart_init)
//---------------------------------------------------------------------------

//   Important: Methods and properties of objects in VCL can only be
//   used in a method called using Synchronize, for example:
//
//      Synchronize(UpdateCaption);
//
//   where UpdateCaption could look like:
//
//      void __fastcall Unit2::UpdateCaption()
//      {
//        Form1->Caption = "Updated in a thread";
//      }
//---------------------------------------------------------------------------

__fastcall MyTestThread::MyTestThread(bool CreateSuspended)
        : TThread(CreateSuspended)
{
   Answer=0;
}
//---------------------------------------------------------------------------

void __fastcall MyTestThread::Execute()
{
   FreeOnTerminate=true;
   for(int i=0;i<2000000;i++)
      {
         if(Terminated)
           break;
         Answer++;
         abs(sin(sqrt(i)));
         Synchronize(GiveAnswer);
      }
}
//---------------------------------------------------------------------------

void __fastcall MyTestThread::GiveAnswer(void)
{
   MainForm->Edit1->Text=IntToStr(Answer);
}
//---------------------------------------------------------------------------
