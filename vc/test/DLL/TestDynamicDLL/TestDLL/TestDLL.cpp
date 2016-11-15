// TestDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"

int Add(int left, int right)
{
    return left + right;
}

bool Copy(const unsigned char *inp, unsigned char *out, unsigned long length)
{
    for(unsigned long i = 0; i < length; ++i)
        *(out + i) = *(inp + i);

    return true;
}

int DLL_EI cdecl CdeclFunction(int left, int right)
{
   return left + right;
}

int DLL_EI cdecl ExternCCdeclFunction(int left, int right)
{
   return left + right;
}

int DLL_EI _cdecl Cdecl_Function(int left, int right)
{
   return left + right;
}

int DLL_EI _cdecl ExternCCdecl_Function(int left, int right)
{
   return left + right;
}

int DLL_EI __cdecl Cdecl__Function(int left, int right)
{
   return left + right;
}

int DLL_EI __cdecl ExternCCdecl__Function(int left, int right)
{
   return left + right;
}

int DLL_EI _stdcall Stdcall_Function(int left, int right)
{
   return left + right;
}

int DLL_EI _stdcall ExternCStdcall_Function(int left, int right)
{
   return left + right;
}

int DLL_EI __stdcall Stdcall__Function(int left, int right)
{
   return left + right;
}

int DLL_EI __stdcall ExternCStdcall__Function(int left, int right)
{
   return left + right;
}

int DLL_EI _fastcall Fastcall_Function(int left, int right)
{
   return left + right;
}

int DLL_EI _fastcall ExternCFastcall_Function(int left, int right)
{
   return left + right;
}

int DLL_EI __fastcall Fastcall__Function(int left, int right)
{
   return left + right;
}

int DLL_EI __fastcall ExternCFastcall__Function(int left, int right)
{
   return left + right;
}

int DLL_EI pascal PascalFunction(int left, int right)
{
   return left + right;
}

int DLL_EI pascal ExternCPascalFunction(int left, int right)
{
   return left + right;
}
