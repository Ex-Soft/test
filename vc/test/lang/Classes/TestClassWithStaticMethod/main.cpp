#include <iostream>

#include "ClassWithStaticMethod.h"

using namespace std;

int main(int argc, char **argv)
{
   ClassWithStaticMethod
     c1(1),
	 c2(2);

   c1.PrintMethodAddress();
   c2.PrintMethodAddress();

   c1.PrintStaticMethodAddress();
   c2.PrintStaticMethodAddress();

   c1.Foo();
   c2.Foo();

   ClassWithStaticMethod::staticX=13;

   cout<<ClassWithStaticMethod::staticX<<endl;

   ClassWithStaticMethod::StaticMethod();
   ClassWithStaticMethod::SetStatic(169);
   cout<<ClassWithStaticMethod::GetStatic()<<endl;
   cout<<ClassWithStaticMethod::staticX<<endl;

   return 0;
}
