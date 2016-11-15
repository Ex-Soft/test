#include "stdafx.h"

using namespace std;

//---------------------------------------------------------------------------
// ClassWithStaticMethod
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
int
  ClassWithStaticMethod::staticX;
//---------------------------------------------------------------------------

ClassWithStaticMethod::ClassWithStaticMethod(int aX)
{
   X=aX;
   cout<<"ClassWithStaticMethod::ClassWithStaticMethod(int aX)"<<endl;
}
//---------------------------------------------------------------------------

ClassWithStaticMethod::ClassWithStaticMethod(const ClassWithStaticMethod &aClassWithStaticMethod)
{
   X=aClassWithStaticMethod.X;
   cout<<"ClassWithStaticMethod::ClassWithStaticMethod(const ClassWithStaticMethod &aClassWithStaticMethod)"<<endl;
}
//---------------------------------------------------------------------------

ClassWithStaticMethod::~ClassWithStaticMethod(void)
{
   cout<<"ClassWithStaticMethod::~ClassWithStaticMethod(void)"<<endl;
}
//---------------------------------------------------------------------------

void ClassWithStaticMethod::StaticMethod(void)
{
   cout<<"void ClassWithStaticMethod::StaticMethod(void)"<<endl;
}
//---------------------------------------------------------------------------

void ClassWithStaticMethod::SetStatic(int aX)
{
   cout<<"void ClassWithStaticMethod::SetStatic(int aX)"<<endl;
   staticX=aX;
}
//---------------------------------------------------------------------------

int ClassWithStaticMethod::GetStatic(void)
{
   cout<<"int ClassWithStaticMethod::GetStatic(void)"<<endl;
   return staticX;
}
//---------------------------------------------------------------------------

