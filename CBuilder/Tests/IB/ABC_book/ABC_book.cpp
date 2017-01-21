//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop
//---------------------------------------------------------------------------

USEFORM("main.cpp", MainForm);
USEFORM("DataUnit.cpp", DataBase); /* TDataModule: File Type */
//---------------------------------------------------------------------------

void __fastcall WriteToLogFile(AnsiString aStr);

std::fstream
  OutputFile;

WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
   AnsiString
     FileName=ExtractFilePath(Application->ExeName)+"log.log";

   OutputFile.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
   if(!OutputFile.good() || !OutputFile.is_open())
     {
        FileName="Can't open file: \""+FileName+"\"";
        Application->MessageBox(FileName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return(-1);
     }

   try
     {
        Application->Initialize();
        Application->Title="ABC book";
        Application->CreateForm(__classid(TMainForm), &MainForm);
        Application->CreateForm(__classid(TDataBase), &DataBase);
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
        catch (Exception &exception)
          {
             Application->ShowException(&exception);
          }
     }

   if(OutputFile.is_open())
     OutputFile.close();

   return(0);
}
//---------------------------------------------------------------------------

void __fastcall WriteToLogFile(AnsiString aStr)
{
   if(OutputFile.is_open() && OutputFile.good())
     OutputFile<<Now().DateTimeString().c_str()<<" "<<aStr.c_str()<<std::endl;
}
//---------------------------------------------------------------------------
