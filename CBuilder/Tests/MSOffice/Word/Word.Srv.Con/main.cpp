//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#include "Word_2K_SRVR.h"
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

#pragma argsused
int main(int argc, char* argv[])
{
   if(argc!=2)
   {
      cout<<"Usage: Test.exe <text_file_name>"<<endl;
      return(0);
   }

   AnsiString
     InDocFileName,
     OutDocFileName;

   if((OutDocFileName=ExtractFilePath(InDocFileName=*(argv+1))).IsEmpty())
     InDocFileName=ExtractFilePath(*argv)+InDocFileName;

   if(!FileExists(InDocFileName))
   {
      cout<<"Can't find \""<<InDocFileName.c_str()<<"\""<<endl;
      return(0);
   }

   if(FileExists(OutDocFileName=ChangeFileExt(InDocFileName,"_out.doc")))
     DeleteFile(OutDocFileName);

   HRESULT
     hRes=CoInitialize(0);

   if(hRes!=S_OK && hRes!=S_FALSE)
   {
      int
        tmpInt=GetLastError();

      cout<<"Can\'t initialize the OLE library (ErrorNo: "<<tmpInt<<" Message: \""<<SysErrorMessage(tmpInt).c_str()<<"\""<<endl;
      return(0);
   }

   TWordApplication
     *WordApplication=0;

   TWordDocument
     *WordDocument=0;

   try
   {
      try
      {
         WordApplication=new TWordApplication(0);
         WordDocument=new TWordDocument(0);
      }
      catch(std::bad_alloc)
      {
         if(WordDocument)
         {
            delete WordDocument;
            WordDocument=0;
         }
         if(WordApplication)
         {
            delete WordApplication;
            WordApplication=0;
         }

         cout<<"Insufficient memory"<<endl;
      }

      if(WordApplication && WordDocument)
      {
         try
         {
            WordApplication->ConnectKind=ckNewInstance;
            WordApplication->Connect();
            WordApplication->set_Visible(true);
            WordApplication->Options->CheckSpellingAsYouType=False;
            WordApplication->Options->CheckGrammarAsYouType=False;

            TVariant
              FileName=InDocFileName,
              Format=wdOpenFormatAuto;

            WordApplication->Documents->OpenOld(&FileName, /* FileName [in] */
                                                EmptyParam, /* ConfirmConversions [in,opt] */
                                                EmptyParam, /* ReadOnly [in,opt] */
                                                EmptyParam, /* AddToRecentFiles [in,opt] */
                                                EmptyParam, /* PasswordDocument [in,opt] */
                                                EmptyParam, /* PasswordTemplate [in,opt] */
                                                EmptyParam, /* Revert [in,opt] */
                                                EmptyParam, /* WritePasswordDocument [in,opt] */
                                                EmptyParam, /* WritePasswordTemplate [in,opt] */
                                                &Format /* Format [in,opt] */);

            WordDocument->ConnectTo(WordApplication->ActiveDocument);

            FileName=OutDocFileName;
            Format=wdFormatDocument;
            WordDocument->SaveAs(&FileName,&Format);

            WordDocument->Close();
            WordDocument->Disconnect();

            WordApplication->Quit();
            WordApplication->Disconnect();
         }
         catch(EOleException &e)
         {
            cout<<AnsiString(e.ClassName()).c_str()<<" Error code#"<<e.ErrorCode<<"=="<<e.Message.c_str()<<endl;
         }
         catch(EOleSysError &e)
         {
            cout<<AnsiString(e.ClassName()).c_str()<<" Error code#"<<e.ErrorCode<<"=="<<e.Message.c_str()<<endl;
         }
         catch(EOleError &e)
         {
            cout<<AnsiString(e.ClassName()).c_str()<<" Error: "<<e.Message.c_str()<<endl;
         }
         catch(EOleCtrlError &e)
         {
            cout<<AnsiString(e.ClassName()).c_str()<<" Error: "<<e.Message.c_str()<<endl;
         }
         catch(Exception &e)
         {
            cout<<e.Message.c_str()<<endl;
         }
      }
   }
   __finally
   {
      if(WordDocument)
        delete WordDocument;
      if(WordApplication)
        delete WordApplication;

      CoUninitialize();
   }

   return(0);
}
//---------------------------------------------------------------------------
