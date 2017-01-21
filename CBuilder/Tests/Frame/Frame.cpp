//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------

USEFORM("main.cpp", MainForm);
USEFORM("FramUnit.cpp", LabelFrame); /* TFrame: File Type */
USEFORM("FramUni_.cpp", OpenFileFrame); /* TFrame: File Type */
USEFORM("FramPar.cpp", FrameWithParam); /* TFrame: File Type */
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
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

   return(0);
}
//---------------------------------------------------------------------------
