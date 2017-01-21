//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("main.res");
USEFORM("MainUnit.cpp", TestDllForm);
USELIB("test_dll.lib");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TTestDllForm), &TestDllForm);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
