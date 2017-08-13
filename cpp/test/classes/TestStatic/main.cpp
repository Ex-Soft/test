#include <iostream>
#include "ClassWithStaticMethod.h"

using namespace std;

int main(void)
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
