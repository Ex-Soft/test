//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("main.cpp", Form1);
USEFORM("DataUnit.cpp", DataModule1); /* TDataModule: File Type */
//---------------------------------------------------------------------------

std::fstream
  File;

WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
   AnsiString
     FileName=ExtractFilePath(Application->ExeName)+"Log.log";

   File.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);

        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TForm1), &Form1);
                 Application->CreateForm(__classid(TDataModule1), &DataModule1);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        catch (...)
        {
                 try
                 {
                         throw Exception("");
                 }
                 catch (Exception &exception)
                 {
                         Application->ShowException(&exception);
                 }
        }

        File.close();

        return 0;
}
//---------------------------------------------------------------------------
