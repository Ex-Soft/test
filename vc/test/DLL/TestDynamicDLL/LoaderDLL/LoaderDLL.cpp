// LoaderDLL.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
    TCHAR szPath[MAX_PATH];
    DWORD length;
    
    if(!(length = GetModuleFileName(NULL, szPath, MAX_PATH)))
    {
        std::cout<<"!GetModuleFileName"<<std::endl;
        return 0;
    }
    else
        std::cout<<szPath<<std::endl;

    HINSTANCE
        dllInstance=0;

    int (*Add)(int, int);
    bool (*Copy)(const unsigned char *, unsigned char *, unsigned long);

    if(!(dllInstance=LoadLibrary(TEXT("TestDLL.dll"))))
        return 0;

    if(Add=(int (*)(int, int))GetProcAddress(dllInstance, "Add"))
    {
        int a = Add(1, 2);
    }

    if(Copy=(bool (*)(const unsigned char *, unsigned char *, unsigned long))GetProcAddress(dllInstance, "Copy"))
    {
        unsigned char
            inp[5] = { 65, 66, 67, 68, 69 },
            out[5];

        bool result = Copy(inp, out, 5);
    }

    if(dllInstance)
        FreeLibrary(dllInstance);

	return 0;
}
