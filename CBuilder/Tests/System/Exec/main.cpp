//---------------------------------------------------------------------------

#include <vcl.h>
#include <dir.h>
#include <process.h>
#include <errno.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------


void __fastcall TMainForm::Pack1Click(TObject *Sender)
{
   AnsiString Mess;
   AnsiString FullPathToFile;
   AnsiString ExecFileName;
   AnsiString PathTo="d:\\1 1\\2 2\\upgrade";
   AnsiString ArchiveFileName="upgrade.arj";
   AnsiString Com="a";
   AnsiString Sw="-x*.cgl";
   AnsiString FileToPack="*.c* *.h* *.dfm";

   ExecFileName=("arj.exe");

   FullPathToFile=searchpath(ExecFileName.c_str());

   if(FullPathToFile.IsEmpty())
     {
        Mess="Can\'t find executable file: "+ExecFileName+"!!!";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   ShowMessage(FullPathToFile);
   FullPathToFile=ExtractShortPathName(FullPathToFile);
   ShowMessage(FullPathToFile);
   ExecFileName=FullPathToFile;
   ArchiveFileName="\""+PathTo+"\\"+ArchiveFileName+"\"";
   ShowMessage(ArchiveFileName);
//   ArchiveFileName=ExtractShortPathName(ArchiveFileName);
//   ShowMessage(ArchiveFileName);

   if(FileExists(ArchiveFileName))
     DeleteFile(ArchiveFileName);

   if(spawnlp(P_WAIT,ExecFileName.c_str(),ExecFileName.c_str(),Com.c_str(),Sw.c_str(),ArchiveFileName.c_str(),FileToPack.c_str(),NULL))
     {
        Mess="Can\'t execute: "+ExecFileName+"!!!\r\nError #"+IntToStr(errno)+" ("+sys_errlist[errno]+")";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UnPack1Click(TObject *Sender)
{
   AnsiString Mess;
   AnsiString FullPathToFile;
   AnsiString ExecFileName;
   AnsiString PathTo="upgrade";
   AnsiString ArchiveFileName="upgrade.arj";
   AnsiString Com="e";
   AnsiString Sw="-y";
   AnsiString FileToPack="";

   ExecFileName="arj.exe";
   FullPathToFile=searchpath(ExecFileName.c_str());

   if(FullPathToFile.IsEmpty())
     {
        Mess="Can\'t find executable file: "+ExecFileName+"!!!";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   ArchiveFileName=PathTo+"\\"+ArchiveFileName;

   if(spawnlp(P_WAIT,ExecFileName.c_str(),ExecFileName.c_str(),Com.c_str(),Sw.c_str(),ArchiveFileName.c_str(),PathTo.c_str(),NULL))
     {
        Mess="Can\'t execute: "+ExecFileName+"!!!\r\nError #"+IntToStr(errno)+" ("+sys_errlist[errno]+")";
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Exit1Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------

