//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Priority.h"
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
//      void __fastcall PriorityThread::UpdateCaption()
//      {
//        Form1->Caption = "Updated in a thread";
//      }
//---------------------------------------------------------------------------

__fastcall TPriorityThread::TPriorityThread(bool IsFirst)
        : TThread(false)
{
   First=IsFirst;
}
//---------------------------------------------------------------------------

void __fastcall TPriorityThread::DisplayProgress(void)
{
   if(First)
     MainForm->FirstThreadProgressBar->Position++;
   else
     MainForm->SecondThreadProgressBar->Position++;

}
//---------------------------------------------------------------------------

void __fastcall TPriorityThread::Execute()
{
   FreeOnTerminate=true;
   OnTerminate=MainForm->PriorityDone;

   for(int i=0;i<=5000;i++)
      {
         if(Terminated)
           break;
         Synchronize(DisplayProgress);
      }
}
//---------------------------------------------------------------------------
