//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------

//#define TEST_CONCATENATION
//#define TEST_CONSTRUCTOR

#pragma argsused
int main(int argc, char* argv[])
{
   AnsiString
     tmpAnsiString;

   #if defined(TEST_CONSTRUCTOR)
     char
       *c="123456789";

     AnsiString
       a; //=AnsiString(c,3);
       //a(c,3);

     a=AnsiString(c,3);
   #endif

   #if defined(TEST_CONCATENATION)
     tmpAnsiString=AnsiString("1st")+"2nd";
   #endif

   return 0;
}
//---------------------------------------------------------------------------
