// TestClassWithStaticMethod.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
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

