//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("events.res");
USEFORM("main.cpp", MainForm);
USEFORM("DataUnit.cpp", DataBases); /* TDataModule: File Type */
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TMainForm), &MainForm);
                 Application->CreateForm(__classid(TDataBases), &DataBases);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
