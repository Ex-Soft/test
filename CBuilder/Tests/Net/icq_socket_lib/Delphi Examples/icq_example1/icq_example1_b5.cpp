//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
USERES("icq_example1_b5.res");
USEFORMNS("Unit2.pas", Unit2, ICQFrame); /* TFrame: File Type */
USEFORMNS("Unit3.pas", Unit3, DemoForm);
USEFORMNS("Unit1.pas", Unit1, Form1);
USEFORMNS("Unit4.pas", Unit4, MetaInfoForm);
USEUNIT("..\..\icqsocket\ICQSocket.pas");
USELIB("..\..\icq_socket_bcc.lib");
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TForm1), &Form1);
                 Application->CreateForm(__classid(TDemoForm), &DemoForm);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        return 0;
}
//---------------------------------------------------------------------------
