#include <vcl.h>
#include <Filectrl.hpp>

#include "MailBase.h"

void test_mail(void)
{
   AnsiString MailDir="Mail";

   AnsiString MailOutDir=MailDir+"\\Out";
   AnsiString MailOutDirS=MailOutDir+"\\";

   AnsiString FileOutDir="test";
   AnsiString FileOutDirS=FileOutDir+"\\";

   AnsiString ext="123",file_name="test.txt";
   int FilialPoint=ext.ToInt();

   if(!DirectoryExists(MailDir) && !CreateDir(MailDir))
     {
        MailDir="Can\'t create directory: "+MailDir+"!!!";
        Application->MessageBox(MailDir.c_str(),Application->Title.c_str(),MB_OK|MB_ICONSTOP);
        return;
     }

   if(!DirectoryExists(MailOutDir) && !CreateDir(MailOutDir))
     {
        MailDir="Can\'t create directory: "+MailOutDir+"!!!";
        Application->MessageBox(MailDir.c_str(),Application->Title.c_str(),MB_OK|MB_ICONSTOP);
        return;
     }

   if(!DirectoryExists(FileOutDir) && !CreateDir(FileOutDir))
     {
        MailDir="Can\'t create directory: "+FileOutDir+"!!!";
        Application->MessageBox(MailDir.c_str(),Application->Title.c_str(),MB_OK|MB_ICONSTOP);
        return;
     }
   if(!FileExists(FileOutDirS+file_name))
     {
        MailDir="Can\'t find file: "+FileOutDirS+file_name+"!!!";
        Application->MessageBox(MailDir.c_str(),Application->Title.c_str(),MB_OK|MB_ICONSTOP);
        return;
     }

   //
   //------------------------------
   TUSIEnvelope Env("Civil",'P',AnsiString(ext+"INS").c_str(),"*","INSZM","*");
   PackEnvelope(MailOutDirS,FilialPoint,Env,FileOutDirS);
   //------------------------------
   //
}
