// http://blogs.msdn.com/b/habibh/archive/2009/06/12/visual-studio-debugger-break-when-expression-has-changed.aspx
// http://msdn.microsoft.com/en-us/library/350dyxd0%28VS.80%29.aspx

// AnyTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

#define TEST_ASSERT
//#define TEST_STRLEN
//#define TEST_BREAK_WHEN_VARIABLE_HAS_CHANGED
//#define TEST_INITIALIZATION

#ifdef TEST_INITIALIZATION
int foo(int param)
{
    cout<<"foo("<<param<<")"<<endl;

    return param;
}

int fooL(int param)
{
    cout<<"fooL("<<param<<")"<<endl;

    return param;
}

int fooR(int param)
{
    cout<<"fooR("<<param<<")"<<endl;

    return param;
}
#endif

int _tmain(int argc, _TCHAR* argv[])
{
    int
        tmpIntI(1),
        tmpIntII=1;

#ifdef TEST_ASSERT
    char
        *buff = 0;

    //assert(buff); // fire

    buff = new char[10];

    assert(buff); // doesn't fire

    if(buff)
        delete []buff;
#endif

#ifdef TEST_STRLEN
     const int
        max = 10;

     char
        *buff;

     if(buff=new char[max])
     {
        cout<<strlen(buff)<<endl;

        for(int i=0; i<max; ++i)
            cout<<"*(buff+"<<i<<")="<<(int)*(buff+i)<<endl;

        delete []buff;
     }
#endif

#ifdef TEST_INITIALIZATION
    const int
        max = 10;

    int
        arr[max],
        idx;

    //arr[idx=3] = foo(idx); // foo(3) [3]=3
    //arr[fooL(idx=3)] = fooR(3); // fooL(3) fooR(3) [3]=3
    arr[idx] = foo(idx=3); // foo(3) [3]=3
    //arr[fooL(idx)] = fooR(idx=3); // fooR(3) fooL(3) [3]=3

    for(int i=0; i<max; ++i)
        cout<<"["<<i<<"]="<<arr[i]<<endl;
    cout<<endl;

    Container
        c(max);

    //c[idx=3] = foo(idx); // foo(-858993460) [3] = { -858993460, 0}
    //c[fooL(idx=3)] = fooR(idx); // fooR(-858993460) fooL(3) [3] = { -858993460, 0}
    //c[idx] = foo(idx=3); // foo(3) [3] = { 3, 0}
    //c[fooL(idx)] = fooR(idx=3); // fooR(3) fooL(3) [3] = { 3, 0}
    //cout<<c[3]<<endl;
#endif

#ifdef TEST_BREAK_WHEN_VARIABLE_HAS_CHANGED
	int
		number,
		remainder;

    printf("Enter number: ");
	scanf_s("%i", &number);
	remainder = number % 2;

	if (remainder == 0)
		printf("Number is even\n");
	else
		printf("Number is odd\n");
#endif

	return 0;
}
