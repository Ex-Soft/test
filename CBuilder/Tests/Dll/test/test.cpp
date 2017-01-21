//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("test.res");
USEFORM("main.cpp", TestForm);
USEUNIT("test_prn.cpp");
USEUNIT("test_mail.cpp");
USELIB("Mailbase.lib");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TTestForm), &TestForm);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
