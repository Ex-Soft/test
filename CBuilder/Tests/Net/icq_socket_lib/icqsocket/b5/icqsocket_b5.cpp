//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
USERES("icqsocket_b5.res");
USERES("..\icqsocket.dcr");
USEUNIT("..\ICQSocket.pas");
USEUNIT("..\..\ICQ_Socket_pas.pas");
USEUNIT("..\..\ICQ_Type_pas.pas");
USELIB("..\..\icq_socket_bcc.lib");
USEPACKAGE("vcl50.bpi");
//---------------------------------------------------------------------------
#pragma package(smart_init)
//---------------------------------------------------------------------------
//   Package source.
//---------------------------------------------------------------------------
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void*)
{
        return 1;
}
//---------------------------------------------------------------------------
