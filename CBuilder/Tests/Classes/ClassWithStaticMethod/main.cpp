//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#pragma hdrstop

using namespace std;

#include "ClassWithStaticMethod.h"

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   /*
   ClassWithStaticMethod
     c(0);
   */

   ClassWithStaticMethod::staticX=13;

   cout<<ClassWithStaticMethod::staticX<<endl;

   ClassWithStaticMethod::StaticMethod();
   ClassWithStaticMethod::SetStatic(169);
   cout<<ClassWithStaticMethod::GetStatic()<<endl;
   cout<<ClassWithStaticMethod::staticX<<endl;
 
   return 0;
}
//---------------------------------------------------------------------------

