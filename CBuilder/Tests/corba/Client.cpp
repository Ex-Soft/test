//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <corba.h>
USERES("Client.res");
USEFORM("ClientMain.cpp", Form1);
USEIDL("PostServ.idl");
USEUNIT("PostServ_c.cpp");
USEUNIT("PostServ_s.cpp");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 // Initialize the ORB and BOA
                 CORBA::ORB_var orb = CORBA::ORB_init(__argc, __argv);
                 CORBA::BOA_var boa = orb->BOA_init(__argc, __argv);
                 Application->CreateForm(__classid(TForm1), &Form1);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
