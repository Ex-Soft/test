#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include "ClassWithStaticMethod.h"

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

void ClassWithStaticMethod::PrintMethodAddress(void)
{
	void (ClassWithStaticMethod::*f_ptr)(void) = &ClassWithStaticMethod::Foo;
	char address[32];
	sprintf(address, "%p", f_ptr);
	cout << "&ClassWithStaticMethod::Foo=" << address << endl;
}
//---------------------------------------------------------------------------

void ClassWithStaticMethod::PrintStaticMethodAddress(void)
{
	void (* f_ptr)(void) = &ClassWithStaticMethod::StaticMethod;
	char address[32];
	sprintf(address, "%p", f_ptr);
	cout << "&ClassWithStaticMethod::StaticMethod=" << address << endl;
}
//---------------------------------------------------------------------------

void ClassWithStaticMethod::Foo(void)
{
	int i;
	int* int_ptr = &i;
	char address[32];
	sprintf(address, "%p", int_ptr);
	cout << "&i=" << address << endl;
}
//---------------------------------------------------------------------------
