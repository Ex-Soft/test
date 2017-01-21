//---------------------------------------------------------------------------

#include <vcl.h>
#include <set>
#pragma hdrstop

#define TEST_IOMANIP

#if defined(TEST_IOMANIP)
   #include <iostream>
   #include <iomanip>
#endif

#include "ClassWOperators.h"
//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   std::set<ClassWOperators>
     a;

   ClassWOperators
     c(0);

   a.insert(c);
   // a.insert(ClassWOperators(0));

   #if defined(TEST_IOMANIP)
      for(int i=32; i<39; ++i)
         std::cout<<"0x"<<std::hex<<i<<" ("<<std::dec<<i<<")="<<(char)i<<std::endl;
   #endif
   
   return 0;
}
//---------------------------------------------------------------------------
