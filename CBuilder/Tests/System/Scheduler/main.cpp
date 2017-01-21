//---------------------------------------------------------------------------

#include <vcl.h>
#include <ole2.h>
#include <mstask.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

void __fastcall CreateTask(void);
void __fastcall SetApplicationName(void);
void __fastcall SetTaskComment(void);
void __fastcall SetTaskAccountInformation(void);
void __fastcall SetAllInformation(void);
void __fastcall GetTaskInformation(void);
void __fastcall CreateTaskFull(void);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";

   long
     btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);

   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
//   CreateTaskFull();
//   CreateTask();
//   SetApplicationName();
//   SetTaskComment();
//   SetTaskAccountInformation();
//   SetAllInformation();
   GetTaskInformation();
}
//---------------------------------------------------------------------------

void __fastcall CreateTask(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;
        if(!SUCCEEDED(hr))
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             LPCWSTR
               pwszTaskName=L"Test Task";

             ITask
               *pITask;

             IPersistFile
               *pIPersistFile;

             hr=pITS->NewWorkItem(pwszTaskName,CLSID_CTask,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
                  pITask->Release();

                  if(hr==S_OK)
                    {
                       hr=pIPersistFile->Save(0,true);
                       pIPersistFile->Release();

                       if(hr==S_OK)
                         {
                            ShowMessage("Created task");
                         }
                       else
                         {
                            ShowMessage("Failed calling Save, error = "+IntToHex((int)hr,2));
                         }
                    }
                  else
                    {
                       ShowMessage("Failed calling QueryInterface, error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling NewWorkItem, error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall SetApplicationName(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             ITask
               *pITask;

             LPCWSTR
               lpcwszTaskName=L"Test Task";

             hr=pITS->Activate(lpcwszTaskName,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  LPCWSTR
                    pwszApplicationName=L"C:\\WINNT\\system32\\notepad.exe";

                  hr=pITask->SetApplicationName(pwszApplicationName);

                  if(hr==S_OK)
                    {
                       IPersistFile
                         *pIPersistFile;
                         
                       hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
                       pITask->Release();

                       if(hr==S_OK)
                         {
                            hr=pIPersistFile->Save(0,true);
                            pIPersistFile->Release();

                            if(hr==S_OK)
                              {
                                 ShowMessage("Set the application name for Test Task");
                              }
                            else
                              {
                                 ShowMessage("Failed calling Save, error = "+IntToHex((int)hr,2));
                              }
                         }
                       else
                         {
                            ShowMessage("Failed calling QueryInterface, error = "+IntToHex((int)hr,2));
                         }
                    }
                  else
                    {
                       ShowMessage("Failed calling ITask::SetApplicationName: error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling ITaskScheduler::Activate: error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall SetTaskComment(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             ITask
               *pITask;

             LPCWSTR
               lpcwszTaskName=L"Test Task";

             hr=pITS->Activate(lpcwszTaskName,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  LPCWSTR
                    pwszComment = L"This task is used to test the Task Scheduler APIs.";

                  hr=pITask->SetComment(pwszComment);

                  if(hr==S_OK)
                    {
                       IPersistFile
                         *pIPersistFile;

                       hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
                       pITask->Release();

                       if(hr==S_OK)
                         {
                            hr=pIPersistFile->Save(0,true);
                            pIPersistFile->Release();

                            if(hr==S_OK)
                              {
                                 ShowMessage("Set the comment for Test Task");
                              }
                            else
                              {
                                 ShowMessage("Failed calling Save, error = "+IntToHex((int)hr,2));
                              }
                         }
                       else
                         {
                            ShowMessage("Failed calling QueryInterface, error = "+IntToHex((int)hr,2));
                         }
                    }
                  else
                    {
                       ShowMessage("Failed calling ITask::SetComment: error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling ITaskScheduler::Activate: error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall SetTaskAccountInformation(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             ITask
               *pITask;

             LPCWSTR
               lpcwszTaskName=L"Test Task";

             hr=pITS->Activate(lpcwszTaskName,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  LPCWSTR
                    pwszAccountName=L"",
                    pwszPassword=0; //L"";

                  hr=pITask-> SetAccountInformation(pwszAccountName,pwszPassword);

                  if(hr==S_OK)
                    {
                       IPersistFile
                         *pIPersistFile;

                       hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
                       pITask->Release();

                       if(hr==S_OK)
                         {
                            hr=pIPersistFile->Save(0,true);
                            pIPersistFile->Release();

                            if(hr==S_OK)
                              {
                                 ShowMessage("Set the account information for Test Task");
                              }
                            else
                              {
                                 ShowMessage("Failed calling Save, error = "+IntToHex((int)hr,2));
                              }
                         }
                       else
                         {
                            ShowMessage("Failed calling QueryInterface, error = "+IntToHex((int)hr,2));
                         }
                    }
                  else
                    {
                       ShowMessage("Failed calling ITask::SetApplicationName: error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling ITaskScheduler::Activate: error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall SetAllInformation(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             ITask
               *pITask;

             LPCWSTR
               lpcwszTaskName=L"Test Task";

             hr=pITS->Activate(lpcwszTaskName,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  WORD
                    wIdleMinutes=9,
                    wDeadlineMinutes=33;

                  //hr=pITask->SetIdleWait(wIdleMinutes,wDeadlineMinutes);

                  unsigned long
                    TaskFlags=0,
                    Flags=8192;

                  hr=pITask->SetTaskFlags(TaskFlags);
                  hr=pITask->SetFlags(Flags);

                  LPCWSTR
                    Creator=L"SYSTEM";

                  hr=pITask->SetCreator(Creator);

                  ITaskTrigger
                    *pITaskTrigger;

                  WORD
                    piNewTrigger;

                  hr=pITask->CreateTrigger(&piNewTrigger,&pITaskTrigger);

                  TASK_TRIGGER
                     pTrigger;

                  setmem(&pTrigger,sizeof(pTrigger),'\x0');

                  pTrigger.cbTriggerSize=sizeof(pTrigger);
                  pTrigger.wBeginYear=2004;
                  pTrigger.wBeginMonth=6;
                  pTrigger.wBeginDay=22;
                  pTrigger.wStartHour=14;
                  pTrigger.wStartMinute=0;
                  pTrigger.MinutesDuration=1440;
                  pTrigger.MinutesInterval=200;
                  //pTrigger.rgFlags=TASK_TRIGGER_FLAG_KILL_AT_DURATION_END;
                  pTrigger.TriggerType=TASK_TIME_TRIGGER_DAILY;
                  pTrigger.Type.Daily.DaysInterval=1;

                  hr=pITaskTrigger->SetTrigger(&pTrigger);

                  hr=pITask->CreateTrigger(&piNewTrigger,&pITaskTrigger);

                  setmem(&pTrigger,sizeof(pTrigger),'\x0');

                  pTrigger.cbTriggerSize=sizeof(pTrigger);
                  pTrigger.wBeginYear=2004;
                  pTrigger.wBeginMonth=6;
                  pTrigger.wBeginDay=22;
                  pTrigger.wStartHour=14;
                  pTrigger.wStartMinute=0;
                  pTrigger.TriggerType=TASK_EVENT_TRIGGER_AT_LOGON;
                  pTrigger.Type.Daily.DaysInterval=1;

                  hr=pITaskTrigger->SetTrigger(&pTrigger);

                  if(hr==S_OK)
                    {
                       IPersistFile
                         *pIPersistFile;

                       hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
                       pITask->Release();

                       if(hr==S_OK)
                         {
                            hr=pIPersistFile->Save(0,true);
                            pIPersistFile->Release();

                            if(hr==S_OK)
                              {
                                 ShowMessage("Set all information for Test Task");
                              }
                            else
                              {
                                 ShowMessage("Failed calling Save, error = "+IntToHex((int)hr,2));
                              }
                         }
                       else
                         {
                            ShowMessage("Failed calling QueryInterface, error = "+IntToHex((int)hr,2));
                         }
                    }
                  else
                    {
                       ShowMessage("Failed calling ITask::SetComment: error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling ITaskScheduler::Activate: error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall GetTaskInformation(void)
{
   HRESULT
     hr=S_OK;

   ITaskScheduler
     *pITS=0;

   try
     {
        if((hr=CoInitialize(0))!=S_OK)
          return;

        if((hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS))==S_OK)
          {
             ITask
               *pITask;

             LPCWSTR
               lpcwszTaskName=L"Norton AntiVirus - Scan my computer.job"; //"Symantec NetDetect";

             hr=pITS->Activate(lpcwszTaskName,IID_ITask,(IUnknown**)&pITask);
             pITS->Release();

             if(hr==S_OK)
               {
                  LPWSTR
                    ppwszComment,
                    User,
                    Pwd;

                  hr=pITask->GetComment(&ppwszComment);

                  unsigned long
                    TaskFlags,
                    Flags;

                  unsigned short
                    wIdleMinutes,
                    wDeadlineMinutes;

                  hr=pITask->GetTaskFlags(&TaskFlags);
                  hr=pITask->GetFlags(&Flags);
                  hr=pITask->GetIdleWait(&wIdleMinutes,&wDeadlineMinutes);
                  hr=pITask->GetParameters(&ppwszComment);
                  hr=pITask->GetAccountInformation(&User);
                  hr=pITask->GetCreator(&ppwszComment);

                  ITaskTrigger
                    *pITaskTrigger;

                  unsigned short
                    TriggerCount;

                  hr=pITask->GetTriggerCount(&TriggerCount);

                  TASK_TRIGGER
                     pTrigger;

                  for(unsigned short i=0; i<TriggerCount; i++)
                     {
                        hr=pITask->GetTrigger(i,&pITaskTrigger);
                        hr=pITaskTrigger->GetTrigger(&pTrigger);
                        hr=pITaskTrigger->GetTriggerString(&ppwszComment);
                     }

                  if(hr==S_OK)
                    {
                       AnsiString
                         tmpAnsiString=ppwszComment;

                       ShowMessage(tmpAnsiString);
                    }
                  else
                    {
                       ShowMessage("Failed calling ITask::SetApplicationName: error = "+IntToHex((int)hr,2));
                    }
               }
             else
               {
                  ShowMessage("Failed calling ITaskScheduler::Activate: error = "+IntToHex((int)hr,2));
               }
          }
     }
   __finally
     {
        CoUninitialize();
     }
}
//---------------------------------------------------------------------------

void __fastcall CreateTaskFull(void)
{
   bool
     CoInit=false,
     pITaskInit=false;

   ITask
     *pITask;

   try
     {
        int
          errno;

        AnsiString
          Mess;

        HRESULT
          hr=S_OK;

        hr=CoInitialize(0);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="CoInitialize error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        CoInit=true;

        ITaskScheduler
          *pITS=0;

        hr=CoCreateInstance(CLSID_CTaskScheduler,0,CLSCTX_INPROC_SERVER,IID_ITaskScheduler,(void **)&pITS);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="CoCreateInstance error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        LPCWSTR
          pwszTaskName=L"Test Task";

        IPersistFile
          *pIPersistFile;

        hr=pITS->NewWorkItem(pwszTaskName,CLSID_CTask,IID_ITask,(IUnknown**)&pITask);
        pITS->Release();
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="NewWorkItem error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        hr=pITask->QueryInterface(IID_IPersistFile,(void **)&pIPersistFile);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="QueryInterface error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }
        pITaskInit=true;

        LPCWSTR
          pwszApplicationName=L"C:\\WINNT\\system32\\notepad.ex_";

        hr=pITask->SetApplicationName(pwszApplicationName);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="QueryInterface error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        LPCWSTR
          pwszWorkingDirectory=L"C:\\WINNT\\system32";

        hr=pITask->SetWorkingDirectory(pwszWorkingDirectory);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="QueryInterface error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        LPCWSTR
          pwszComment=L"This task is used to test the Task Scheduler APIs.";

        hr=pITask->SetComment(pwszComment);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="QueryInterface error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        LPCWSTR
          pwszAccountName=L"",
          pwszPassword=0; //L"";

        hr=pITask->SetAccountInformation(pwszAccountName,pwszPassword);
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="QueryInterface error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }

        WORD
          wIdleMinutes=9,
          wDeadlineMinutes=33;

        //hr=pITask->SetIdleWait(wIdleMinutes,wDeadlineMinutes);

        unsigned long
          TaskFlags=0,
          Flags=8192;

        hr=pITask->SetTaskFlags(TaskFlags);
        hr=pITask->SetFlags(Flags);

        LPCWSTR
          Creator=L"SYSTEM";

        hr=pITask->SetCreator(Creator);

        ITaskTrigger
          *pITaskTrigger;

        WORD
          piNewTrigger;

        hr=pITask->CreateTrigger(&piNewTrigger,&pITaskTrigger);

        TASK_TRIGGER
          pTrigger;

        setmem(&pTrigger,sizeof(pTrigger),'\x0');

        pTrigger.cbTriggerSize=sizeof(pTrigger);
        pTrigger.wBeginYear=2004;
        pTrigger.wBeginMonth=6;
        pTrigger.wBeginDay=22;
        pTrigger.wStartHour=14;
        pTrigger.wStartMinute=0;
        pTrigger.MinutesDuration=1440;
        pTrigger.MinutesInterval=200;
        //pTrigger.rgFlags=TASK_TRIGGER_FLAG_KILL_AT_DURATION_END;
        pTrigger.TriggerType=TASK_TIME_TRIGGER_DAILY;
        pTrigger.Type.Daily.DaysInterval=1;

        hr=pITaskTrigger->SetTrigger(&pTrigger);

        hr=pITask->CreateTrigger(&piNewTrigger,&pITaskTrigger);

        setmem(&pTrigger,sizeof(pTrigger),'\x0');

        pTrigger.cbTriggerSize=sizeof(pTrigger);
        pTrigger.wBeginYear=2004;
        pTrigger.wBeginMonth=6;
        pTrigger.wBeginDay=22;
        pTrigger.wStartHour=14;
        pTrigger.wStartMinute=0;
        pTrigger.TriggerType=TASK_EVENT_TRIGGER_AT_LOGON;
        pTrigger.Type.Daily.DaysInterval=1;

        hr=pITaskTrigger->SetTrigger(&pTrigger);

        hr=pIPersistFile->Save(0,true);
        pIPersistFile->Release();
        if(FAILED(hr))
          {
             errno=GetLastError();
             Mess="Save error "+IntToStr(errno)+"\nMessage: "+SysErrorMessage(errno)+"\n("+IntToHex((int)hr,8)+" "+IntToStr(hr)+")";
             throw Exception(Mess);
          }
     }
   __finally
     {
        if(pITaskInit)
          pITask->Release();

        if(CoInit)
          CoUninitialize();
     }
}
//---------------------------------------------------------------------------
