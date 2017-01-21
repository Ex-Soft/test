//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "body.h"
#include "Priority.h"

#define MAXSIZE 128
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

enum ESynchronizeMode
{
   md_CriticalSection,
   md_Mutex,
   md_Semaphore,
   md_NotSynchronize
};

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   ListText="=====";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SynchronizeModeRadioGroupClick(TObject *Sender)
{
   extern ESynchronizeMode
     SynchronizeMode;

   SynchronizeMode=SynchronizeModeRadioGroup->ItemIndex;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SynchronizeThreadsButtonClick(TObject *Sender)
{
   extern int
     DoneFlag;

   extern ESynchronizeMode
     SynchronizeMode;

   extern
     TRTLCriticalSection CS;

   extern HANDLE
     hSem,
     hMutex;

   ListBox1->Clear();
   DoneFlag=0;

   switch(SynchronizeMode)
     {
        case md_CriticalSection : {
                                     InitializeCriticalSection(&CS);
                                     break;
                                  }
        case md_Mutex :           {
                                     hMutex=CreateMutex(NULL,false,NULL);
                                     break;
                                  }
        case md_Semaphore :       {
                                     hSem=CreateSemaphore(NULL,1,1,NULL);
                                     break;
                                  }
     }

   MyThread
     *mythread1=new MyThread(false),
     *mythread2=new MyThread(false);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ThreadsDone(TObject *Sender)
{
   extern int
     GlobalArray[],
     DoneFlag;

   extern ESynchronizeMode
     SynchronizeMode;

   extern TRTLCriticalSection
     CS;

   extern HANDLE
     hSem,
     hMutex;

   int
     i;

   DoneFlag++;
   if(DoneFlag==2)
     {
        switch(SynchronizeMode)
          {
             case md_CriticalSection : {
                                          ListBox1->Items->Add("Critical Section");
                                          break;
                                       }
             case md_Mutex :           {
                                          ListBox1->Items->Add("Mutex");
                                          break;
                                       }
             case md_Semaphore :       {
                                          ListBox1->Items->Add("Semaphore");
                                          break;
                                       }
             case md_NotSynchronize :  {
                                          ListBox1->Items->Add("Not Synchronize");
                                          break;
                                       }
          }

        for(i=0;i<MAXSIZE;i++)
           ListBox1->Items->Add(IntToStr(GlobalArray[i]));

        switch(SynchronizeMode)
          {
             case md_CriticalSection : {
                                          DeleteCriticalSection(&CS);
                                          break;
                                       }
             case md_Mutex :           {
                                          CloseHandle(hMutex);
                                          break;
                                       }
             case md_Semaphore :       {
                                          CloseHandle(hSem);
                                          break;
                                       }
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PriorityThreadsButtonClick(TObject *Sender)
{
   FirstThreadProgressBar->Position=0;
   SecondThreadProgressBar->Position=0;

   TPriorityThread *First;
   First=new TPriorityThread(true);
   First->Priority=FirstThreadTrackBar->Position;

   TPriorityThread *Second;
   Second=new TPriorityThread(false);
   Second->Priority=SecondThreadTrackBar->Position;

   PriorityThreadsButton->Enabled=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PriorityDone(TObject *Sender)
{
   PriorityThreadsButton->Enabled=true;

}
//---------------------------------------------------------------------------
