//---------------------------------------------------------------------------

#include <vcl.h>
#include <tlhelp32.h>
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

void __fastcall TMainForm::Button1Click(TObject *Sender)
{

   DWORD
     ProcId=GetCurrentProcessId();

   HANDLE
     ss=CreateToolhelp32Snapshot(TH32CS_SNAPMODULE,ProcId);

   MODULEENTRY32
     lpme={sizeof(MODULEENTRY32)};

   bool
     ok;

   Memo1->Lines->Add("MODULEENTRY32");
   for(ok=Module32First(ss,&lpme); ok; ok=Module32Next(ss,&lpme))
      {
         Memo1->Lines->Add(AnsiString(lpme.szModule)+" "+lpme.szExePath);
      }
   Memo1->Lines->Add("");
   CloseHandle(ss);

   ss=CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS,ProcId);

   PROCESSENTRY32
     pe32={sizeof(tagPROCESSENTRY32)};

   Memo1->Lines->Add("PROCESSENTRY32");
   for(ok=Process32First(ss,&pe32); ok; ok=Process32Next(ss,&pe32))
     {
        Memo1->Lines->Add(pe32.szExeFile);
     }
   Memo1->Lines->Add("");  
   CloseHandle(ss);
}
//---------------------------------------------------------------------------

