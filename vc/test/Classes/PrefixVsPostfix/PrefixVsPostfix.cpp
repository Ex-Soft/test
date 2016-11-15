// PrefixVsPostfix.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    A
        a1(1, 1),
        a2(a1),
        a3=a2,
        a4,
        aMax(5,5);

    a4=a3;
    ++a4;
    a4++;

    for(A a=A(0,0); a!=aMax; ++a)
        cout<<a.x<<endl;

    for(A a=A(0,0); a!=aMax; a++)
        cout<<a.x<<endl;

    return 0;
}

