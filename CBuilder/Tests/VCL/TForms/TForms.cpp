//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop
//---------------------------------------------------------------------------

USEFORM("main.cpp", MainForm);
USEFORM("child.cpp", ChildForm);
USEFORM("FrameTst.cpp", TestFrame); /* TFrame: File Type */
//---------------------------------------------------------------------------
std::fstream
  File;

WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
   File.open("log.log",std::ios_base::out|std::ios_base::trunc);

   try
     {
        Application->Initialize();
        Application->CreateForm(__classid(TMainForm), &MainForm);
                 Application->Run();
     }
   catch(Exception &exception)
     {
        Application->ShowException(&exception);
     }
   catch(...)
     {
        try
          {
             throw Exception("");
          }
        catch(Exception &exception)
          {
             Application->ShowException(&exception);
          }
     }

   return 0;
}
//---------------------------------------------------------------------------
