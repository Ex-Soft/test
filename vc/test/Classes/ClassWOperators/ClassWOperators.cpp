// ClassWOperators.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    CharClass
        charClassChar('\x61'),
        charClassInt(97),
        charClassLong(97L),
        charClassClass(charClassChar);

    char
        _a = '0',
        _b = '1',
        _c = _a + _b;

    const int
        max = 10;

    A
        a(3,3),
        b(9,9),
        ab = a + b,
        aInt = a + 1;

    Container
        c(max);

    c[3] = a;

    for(int i=0; i<max; ++i)
        cout<<"["<<i<<"]="<<c[i]<<endl;

	return 0;
}

