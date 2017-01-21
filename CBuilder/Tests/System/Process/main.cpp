//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

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
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   bool Result;
   STARTUPINFO sinfo;
   PROCESS_INFORMATION pinfo;
   DWORD dw,dwExitCode;

   setmem(&sinfo,sizeof(sinfo),0);
   sinfo.cb=sizeof(sinfo);
   sinfo.dwFlags=STARTF_USESHOWWINDOW;
   //sinfo.wShowWindow=SW_SHOWDEFAULT;
   //sinfo.wShowWindow=SW_SHOWMINNOACTIVE;
   sinfo.wShowWindow=SW_HIDE;
   Result=CreateProcess(0,"run_me_.bat", 0, 0, false, NORMAL_PRIORITY_CLASS, 0, 0, &sinfo, &pinfo);
   if(Result)
     {
        CloseHandle(pinfo.hThread);
        dw=WaitForSingleObject(pinfo.hProcess,5000);
        switch(dw)
          {
             case WAIT_OBJECT_0: {
                                    break;
                                 }
             case WAIT_TIMEOUT:  {
                                    TerminateProcess(pinfo.hProcess,-1);
                                    break;
                                 }
             case WAIT_FAILED:   {
                                    break;
                                 }
          }
        GetExitCodeProcess(pinfo.hProcess,&dwExitCode);
        CloseHandle(pinfo.hProcess);
     }
   else
     {
        LPVOID lpMsgBuf;
        DWORD ErrNo=GetLastError();
        AnsiString Mess="Error: "+IntToStr(ErrNo);

        if(FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER|FORMAT_MESSAGE_FROM_SYSTEM,0,ErrNo,MAKELANGID(LANG_NEUTRAL,SUBLANG_DEFAULT),(LPTSTR)&lpMsgBuf,0,0))
          {
             Mess+="\nMessage: "+AnsiString((const char*)lpMsgBuf);
             int Len=Mess.Length();

             do{
                  if(Mess[Len]=='\r' || Mess[Len]=='\n')
                    Mess.Delete(Len--,1);
               }while(Mess[Len]=='\r' || Mess[Len]=='\n');
          }

        LocalFree(lpMsgBuf);
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
     }
}
//---------------------------------------------------------------------------


