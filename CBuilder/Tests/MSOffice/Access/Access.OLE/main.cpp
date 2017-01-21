//---------------------------------------------------------------------------

#include <vcl.h>
#include <OleCtrls.hpp>
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
   AnsiString
     Mess;
     
   Variant
     Access,
     CodeData;

   try
   {
      try
      {
         Access=Variant::GetActiveObject("Access.Application");
      }
      catch(EOleSysError &eException)
      {
         if(eException.ErrorCode==-2147221021)
         {
            try
            {
               Access=CreateOleObject("Access.Application");
            }
            catch(...)
            {
               Application->MessageBox("Object Access was not created!!!",Application->Title.c_str(),MB_OK|MB_ICONERROR);
               return;
            }
         }
      }
      Mess="c:\\Program Files\\Microsoft Office\\Office\\Samples\\Борей.mdb";
      Access.OleProcedure("OpenCurrentDatabase",Mess.c_str());
      //CodeData=Access.OlePropertyGet("CodeData");
      //CodeData=Access.OleFunction("CodeData");
      Access.OleProcedure("CloseCurrentDatabase");
      Access.OleProcedure("Quit");

      CodeData.Clear();
      VarClear(CodeData);
      CodeData=Unassigned;

      Access.Clear();
      VarClear(Access);
      Access=Unassigned;
   }
   catch(EOleException &e)
   {
      Mess=e.ClassName();
      Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
      Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
   catch(EOleSysError &e)
   {
      Mess=e.ClassName();
      Mess+=" Error code "+IntToStr(e.ErrorCode)+" == \""+e.Message+"\"";
      Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
   catch(EOleError &e)
   {
      Mess=e.ClassName();
      Mess+=" Error \""+e.Message+"\"";
      Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
   catch(EOleCtrlError &e)
   {
      Mess=e.ClassName();
      Mess+=" Error \""+e.Message+"\"";
      Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
   catch(Exception &e)
   {
      Mess=e.ClassName();
      Mess+=" Error \""+e.Message+"\"";
      Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
   catch(...)
   {
      Application->MessageBox("Run Excel error!!!",Application->Title.c_str(),MB_OK|MB_ICONERROR);
      return;
   }
}
//---------------------------------------------------------------------------
