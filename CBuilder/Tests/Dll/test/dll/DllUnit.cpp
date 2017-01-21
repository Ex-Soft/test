//---------------------------------------------------------------------------

#include <vcl.h>
#include <ole2.h>
#include <windows.h>
#include <comobj.hpp>
#include <dir.h>
#pragma hdrstop

#include "test_dll.h"
#include "MailBase.h"
//---------------------------------------------------------------------------

#pragma argsused
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   return 1;
}
//---------------------------------------------------------------------------

void test_prn(void)
{
   Variant MSWord=Unassigned;
   AnsiString CurrPath=GetCurrentDir(),SignatureDoc,OutputDoc,FileNameDoc="test.doc";
   int point;
   HRESULT hRes=OleInitialize(NULL);

   if(hRes!=S_OK && hRes!=S_FALSE)
     {
        MessageBox(NULL,"Can\'t initialize the OLE library!!!","Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }

   SignatureDoc=CurrPath+"\\"+FileNameDoc;
   point=SignatureDoc.LastDelimiter(".");
   OutputDoc=SignatureDoc.SubString(1,point-1)+"_.doc";

   if(!FileExists(SignatureDoc))
     {
        SignatureDoc="Can\'t find file: "+SignatureDoc+"!!!";
        MessageBox(NULL,SignatureDoc.c_str(),"Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }

   try
     {
        MSWord.Exec(Procedure("FileOpen")<<SignatureDoc);
     }
   catch(...)
     {
        try
          {
             MSWord=CreateOleObject("Word.Basic");
          }
        catch(...)
          {
             MessageBox(NULL,"Помилка Microsoft Word!!! Спробуйте закрити програму та запустити її знову.\r\nЯкщо помилка не зникне, зверніться до фірми Microsoft.","Dll Error!!!",MB_OK|MB_ICONERROR);
             return;
          }
        try
          {
             MSWord.Exec(Procedure("FileOpen")<<SignatureDoc);
          }
        catch(...)
          {
             SignatureDoc="Помилка відкриття файлу: "+ SignatureDoc+ "!!!\r\nПеревірте його існування!!!";
             MessageBox(NULL,SignatureDoc.c_str(),"Dll Error!!!",MB_OK|MB_ICONERROR);
             return;
          }
     }

   MSWord.Exec(Procedure("EditFind")<<"Line1");
   MSWord.Exec(Procedure("Insert")<<"Test Test Test");

   MSWord.Exec(Procedure("EditFind")<<"Line2");
   MSWord.Exec(Procedure("Insert")<<"UkrSotsStrakh UkrSotsStrakh UkrSotsStrakh");

   MSWord.Exec(Procedure("EditFind")<<"Line3");
   MSWord.Exec(Procedure("Insert")<<"Ex_Soft Ex_Soft Ex_Soft");

   MSWord.Exec(Procedure("FileSaveAs")<<OutputDoc);

   MSWord.Exec(Procedure("FilePrint"));
   MSWord.Exec(Procedure("FileClose"));
   MSWord.Exec(Procedure("AppClose"));
   OleUninitialize();
}
//---------------------------------------------------------------------------

void test_mail(void)
{
   ffblk ffblk;

   AnsiString MailDir="Mail";

   AnsiString MailOutDir=MailDir+"\\Out";
   AnsiString MailOutDirS=MailOutDir+"\\";

   AnsiString FileOutDir="test";
   AnsiString FileOutDirS=FileOutDir+"\\";

   AnsiString ext="123",file_name="test.txt";
   int FilialPoint=ext.ToInt();

   if(findfirst(MailDir.c_str(),&ffblk,FA_DIREC) && !CreateDir(MailDir))
     {
        MailDir="Can\'t create directory: "+MailDir+"!!!";
        MessageBox(NULL,MailDir.c_str(),"Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }

   if(findfirst(MailOutDir.c_str(),&ffblk,FA_DIREC) && !CreateDir(MailOutDir))
     {
        MailDir="Can\'t create directory: "+MailOutDir+"!!!";
        MessageBox(NULL,MailDir.c_str(),"Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }

   if(findfirst(FileOutDir.c_str(),&ffblk,FA_DIREC) && !CreateDir(FileOutDir))
     {
        MailDir="Can\'t create directory: "+FileOutDir+"!!!";
        MessageBox(NULL,MailDir.c_str(),"Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }
   if(!FileExists(FileOutDirS+file_name))
     {
        MailDir="Can\'t find file: "+FileOutDirS+file_name+"!!!";
        MessageBox(NULL,MailDir.c_str(),"Dll Error!!!",MB_OK|MB_ICONSTOP);
        return;
     }

   //
   //------------------------------
   TUSIEnvelope Env("Civil",'P',AnsiString(ext+"INS").c_str(),"*","INSZM","*");
   PackEnvelope(MailOutDirS,FilialPoint,Env,FileOutDirS);
   //------------------------------
   //
}
//---------------------------------------------------------------------------
