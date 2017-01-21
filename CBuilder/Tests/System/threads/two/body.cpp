//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "body.h"
#include "main.h"
#pragma package(smart_init)

enum ESynchronizeMode{md_CriticalSection,md_Mutex,md_Semaphore,md_NotSynchronize};
//---------------------------------------------------------------------------

//   Important: Methods and properties of objects in VCL can only be
//   used in a method called using Synchronize, for example:
//
//      Synchronize(UpdateCaption);
//
//   where UpdateCaption could look like:
//
//      void __fastcall Unit1::UpdateCaption()
//      {
//        Form1->Caption = "Updated in a thread";
//      }
//---------------------------------------------------------------------------

#define MAXSIZE 128

int __fastcall GetNextNumber(void);

__fastcall MyThread::MyThread(bool CreateSuspended):TThread(CreateSuspended)
{
}
//---------------------------------------------------------------------------

void __fastcall MyThread::DisplayList(void)
{
   MainForm->ListBox1->Items->Add(Text);
}
//---------------------------------------------------------------------------

void __fastcall MyThread::Execute()
{
   extern int GlobalArray[];

   extern ESynchronizeMode SynchronizeMode;

   extern TRTLCriticalSection CS;
   extern HANDLE hMutex;
   extern HANDLE hSem;

   int i;
   HANDLE hTmp;
   DWORD WaitReturn;

   FreeOnTerminate=true;
   OnTerminate=MainForm->ThreadsDone;

   switch(SynchronizeMode)
     {
        case md_CriticalSection : {
                                     EnterCriticalSection(&CS);
                                     break;
                                  }
        case md_Mutex :           {
                                     hTmp=hMutex;
                                     break;
                                  }
        case md_Semaphore :       {
                                     hTmp=hSem;
                                     break;
                                  }
     }

   if(SynchronizeMode==md_Mutex || SynchronizeMode==md_Semaphore)
     WaitReturn=WaitForSingleObject(hTmp,INFINITE);
   if((SynchronizeMode==md_CriticalSection) || (SynchronizeMode==md_NotSynchronize) || ((SynchronizeMode==md_Mutex || SynchronizeMode==md_Semaphore) && (WaitReturn==WAIT_OBJECT_0)))
     {
        for(i=0;i<MAXSIZE;i++)
           {
              MainForm->ListText.Insert("=====",1);
              Text=MainForm->ListText;
              Synchronize(DisplayList);
              MainForm->ListText.SetLength(MainForm->ListText.Length()-5);

              GlobalArray[i]=GetNextNumber();
              Sleep(5);
           }
     }
   switch(SynchronizeMode)
     {
        case md_CriticalSection : {
                                     LeaveCriticalSection(&CS);
                                     break;
                                  }
        case md_Mutex :           {
                                     ReleaseMutex(hMutex);
                                     break;
                                  }
        case md_Semaphore :       {
                                     ReleaseSemaphore(hSem,1,NULL);
                                     break;
                                  }
     }
}
//---------------------------------------------------------------------------

int __fastcall GetNextNumber(void)
{
   extern int NextNumber;

   return(NextNumber++);
}
//---------------------------------------------------------------------------
