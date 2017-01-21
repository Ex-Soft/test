//---------------------------------------------------------------------------

#pragma hdrstop

#include "TestClass.h"
//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   TBase
     a;

   int
     sw=a.GetTBaseStaticConstInt();

   if(sw==1)
     a.TBaseInt=1;

   return 0;
}
//---------------------------------------------------------------------------
 