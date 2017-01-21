//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Testing.h"
//---------------------------------------------------------------------------

#pragma argsused
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   return 1;
}
//---------------------------------------------------------------------------

void VoidFunction(void)
{
   AnsiString a,b,c;
   b="b";
   a=b;
   char *ptr=b.c_str();
   *ptr='a';
   b="c";
   c=a;

   try
     {
        TDateTime dtDate=EncodeDate(2003,2,29);
     }
   catch(...)
     {
        a="";
     }
}
//---------------------------------------------------------------------------

