//---------------------------------------------------------------------------

#include <vcl.h>
#include <assert.h>
#include <fstream>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

bool __fastcall IsWindowsNT();

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
   std::fstream File;
   AnsiString FileName=ExtractFilePath(Application->ExeName)+"Log.log";

   File.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
   if(!File.good())
     {
        FileName="Can't create file: \""+FileName+"\"";
        Application->MessageBox(FileName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   SECURITY_DESCRIPTOR sd;
   SECURITY_ATTRIBUTES sa;
   LPSECURITY_ATTRIBUTES lpsa=0;

   if(IsWindowsNT())
     {
        InitializeSecurityDescriptor(&sd,SECURITY_DESCRIPTOR_REVISION);
        SetSecurityDescriptorDacl(&sd,true,0,false);
        sa.nLength=sizeof(SECURITY_ATTRIBUTES);
        sa.bInheritHandle=true;
        sa.lpSecurityDescriptor=&sd;
        lpsa=&sa;
     }

   HANDLE hReadPipe;
   HANDLE hWritePipe;
   assert(CreatePipe(&hReadPipe,&hWritePipe,lpsa,2500000));

   STARTUPINFO si;

   memset(&si,0,sizeof(STARTUPINFO));
   si.cb=sizeof(STARTUPINFO);
   si.dwFlags=STARTF_USESHOWWINDOW|STARTF_USESTDHANDLES;
   si.wShowWindow=SW_SHOWDEFAULT;
   //si.wShowWindow=SW_HIDE;
   si.hStdOutput=hWritePipe;
   si.hStdError=hWritePipe;

   PROCESS_INFORMATION pi;

   assert(hWritePipe);
   //if(CreateProcess(0,"subproc 1 2 3 4 5",0,0,true,0,0,0,&si,&pi))
   if(CreateProcess(0,"tomail",0,0,true,0,0,0,&si,&pi))
     {
        CloseHandle(pi.hThread);
        WaitForSingleObject(pi.hProcess,90000);

        assert(hReadPipe);

        DWORD BytesRead;
        unsigned int Size=0x0ffff;
        char *dest=0,*outpuT=0;

        while(!dest && Size)
          {
             dest=new char [Size];
             if(!dest)
               Size>>=1;
          }
        if(dest)
          {
             outpuT=new char [Size];
             if(outpuT)
               {
                  DWORD TotalBytesAvail=0,BytesLeftThisMessage=0;

                  assert(PeekNamedPipe(hReadPipe,dest,Size,&BytesRead,&TotalBytesAvail,&BytesLeftThisMessage));
                  if(BytesRead)
                    assert(ReadFile(hReadPipe,dest,Size,&BytesRead,0));

                  *(dest+BytesRead)='\x0';

                  unsigned i=0;

                  while(*(dest+i))
                    {
                       if(*(dest+i)=='\r')
                         memmove(dest+i,dest+i+1,(BytesRead--)-i);
                       else
                         i++;
                    }
                  OemToChar(dest,outpuT);
                  File<<outpuT<<std::endl;
               }
          }
        if(dest)
          delete []dest;
        if(outpuT)
          delete []outpuT;
     }

   CloseHandle(hReadPipe);
   CloseHandle(hWritePipe);
   CloseHandle(pi.hProcess);

   File.close();

}
//---------------------------------------------------------------------------

bool __fastcall IsWindowsNT()
{
   OSVERSIONINFO osv;

   osv.dwOSVersionInfoSize=sizeof(osv);
   GetVersionEx(&osv);
   return(osv.dwPlatformId==VER_PLATFORM_WIN32_NT);
}
//---------------------------------------------------------------------------
