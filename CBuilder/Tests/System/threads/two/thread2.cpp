//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USEFORM("main.cpp", MainForm);
//---------------------------------------------------------------------------

#define MAXSIZE 128

enum ESynchronizeMode
{
   md_CriticalSection,
   md_Mutex,
   md_Semaphore,
   md_NotSynchronize
};

int
  NextNumber=0,
  DoneFlag,
  GlobalArray[MAXSIZE];

ESynchronizeMode
  SynchronizeMode=md_CriticalSection;

TRTLCriticalSection
  CS;

HANDLE
  hSem=0,
  hMutex=0;

WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
   try
   {
      Application->Initialize();
      Application->CreateForm(__classid(TMainForm), &MainForm);
      Application->Run();
   }
   catch(Exception &exception)
   {
      Application->ShowException(&exception);
   }

   return 0;
}
//---------------------------------------------------------------------------
