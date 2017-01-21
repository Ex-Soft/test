//---------------------------------------------------------------------------

#include <vcl.h>
#include <new>
#include <OleCtrls.hpp>
#pragma hdrstop

#include "main.h"
#include "access_2k_srvr.h"
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
     tmpAnsiString;
     
   TAccessApplication
     *AccessApplication=0;

   try
   {
      try
      {
         try
         {
            AccessApplication=new TAccessApplication(0);
         }
         catch(std::bad_alloc)
         {
            if(AccessApplication)
            {
               delete AccessApplication;
               AccessApplication=0;
            }
         }

         AccessApplication->ConnectKind=ckNewInstance;
         AccessApplication->Connect();
      }
      catch(EOleException &e)
      {
         tmpAnsiString=e.ClassName();
         tmpAnsiString+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
         throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
      }
      catch(EOleSysError &e)
      {
         tmpAnsiString=e.ClassName();
         tmpAnsiString+=" Error code#"+IntToStr(e.ErrorCode)+"=="+e.Message;
         throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
      }
      catch(EOleError &e)
      {
         tmpAnsiString=e.ClassName();
         tmpAnsiString+=" Error: "+e.Message;
         throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
      }
      catch(EOleCtrlError &e)
      {
         tmpAnsiString=e.ClassName();
         tmpAnsiString+=" Error: "+e.Message;
         throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
      }
      catch(Exception &eException)
      {
         tmpAnsiString=eException.Message;
         throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+tmpAnsiString);
      }
   }
   __finally
   {
      if(AccessApplication)
      {
         AccessApplication->Quit(acQuitSaveNone);
         AccessApplication->Disconnect();
         delete AccessApplication;
         AccessApplication=0;
      }
   }
}
//---------------------------------------------------------------------------

