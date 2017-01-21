//---------------------------------------------------------------------------

#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

class A
{
public:
   void DoA(void){ cout<<"A"<<endl; };
};

class B
{
public:
   void DoB(void){ cout<<"B"<<endl; };
};

class C:public A, public B
{
};

#pragma argsused
int main(int argc, char* argv[])
{
   A
     a;

   B
     b;

   C
     c;

   a.DoA();
   b.DoB();
   c.DoA();
   c.DoB();

   return 0;
}
//---------------------------------------------------------------------------
 