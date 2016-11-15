// TestCast.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
    int i;
    const int *pci = &i;
    //int *j = pi; // error C2440: 'initializing' : cannot convert from 'const int *' to 'int *'
    int *j = const_cast<int *>(pci);

    int *pi;
    void *vp=pi;
    //char *pch = vp; // error C2440: 'initializing' : cannot convert from 'void *' to 'char *'
    char *pch = static_cast<char *>(vp);

    unsigned *v_ptr;
    //pi=v_ptr; // error C2440: '=' : cannot convert from 'unsigned int *' to 'int *'
    //pi = static_cast<int *>(v_ptr); // error C2440: 'static_cast' : cannot convert from 'unsigned int *' to 'int *'
    pi = reinterpret_cast<int *>(v_ptr);

	return 0;
}

