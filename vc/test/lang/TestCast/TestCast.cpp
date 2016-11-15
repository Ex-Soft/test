// TestCast.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int _tmain(int argc, _TCHAR* argv[])
{
    int
        i = 0;

    const int
        *pi = &i;

    //*pi = 10; //Error C3892: 'pi' : you cannot assign to a variable that is const

    int
        *j = const_cast<int *>(pi);

    *j=10;

	return 0;
}

