//---------------------------------------------------------------------------
#include <iostream>
#pragma hdrstop

//---------------------------------------------------------------------------

class A
{
public:
   virtual void Test() { std::cout << ("A"); }
};

class B : public A
{
public:
   virtual void Test() { std::cout << ("B"); }
};

class C : public B
{
public:
   virtual void Test() volatile { std::cout << ("C"); }
};

class D : public C
{
public:
   virtual void Test() volatile { std::cout << ("D"); }
};

#pragma argsused
int main(int argc, char* argv[])
{
   std::auto_ptr<A>
     a(new D());

   a->Test(); //"B"

   std::auto_ptr<C>
     c(new D());

   c->Test(); //"D"

   return 0;
}
//---------------------------------------------------------------------------
