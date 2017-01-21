//---------------------------------------------------------------------------

#include <corbapch.h>
#pragma hdrstop

//---------------------------------------------------------------------------

#include "PostServer.h"

#include <corba.h>
#include <condefs.h>
USEIDL("PostServ.idl");
USEUNIT("PostServ_c.cpp");
USEUNIT("PostServ_s.cpp");
USEUNIT("PostServer.cpp"); /* PostServ.idl: CORBAIdlFile */
//---------------------------------------------------------------------------
#pragma argsused
main(int argc, char* argv[])
{
        try
        {
                 // Initialize the ORB and BOA
                 CORBA::ORB_var orb = CORBA::ORB_init(argc, argv);
                 CORBA::BOA_var boa = orb->BOA_init(argc, argv);
                 PostImpl post_PostObject("PostObject");
                 boa->obj_is_ready(&post_PostObject);
                 // Wait for incoming requests
                 boa->impl_is_ready();
        }
        catch(const CORBA::Exception& e)
        {
                 Cerr << e << endl;
                 return(1);
        }
        return 0;
}
//---------------------------------------------------------------------------
