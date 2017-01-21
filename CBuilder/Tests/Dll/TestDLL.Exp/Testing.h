#ifndef TestingH
#define TestingH

#include <stdio.h>

#if defined(__DLL__)
   #define DLL_EI __declspec(dllexport)
#else
   #define DLL_EI __declspec(dllimport)
#endif

//void DLL_EI __stdcall VoidFunction(void); // @VoidFunction$qqsv
//extern "C" void DLL_EI __stdcall VoidFunction(void); // VoidFunction
//extern "C" void DLL_EI __fastcall VoidFunction(void); // @VoidFunction
extern "C" void DLL_EI VoidFunction(void); // _VoidFunction

//void DLL_EI __stdcall FileFunction(FILE *FilePtr, AnsiString WriteString); // @FileFunction$qqsp8std@FILE17System@AnsiString
//extern "C" void DLL_EI __stdcall FileFunction(FILE *FilePtr, AnsiString WriteString); // FileFunction
extern "C" void DLL_EI FileFunction(FILE *FilePtr, AnsiString WriteString); // _FileFunction

int DLL_EI cdecl CdeclFunction(int, int);
extern "C" int DLL_EI cdecl ExternCCdeclFunction(int, int);
int DLL_EI _cdecl Cdecl_Function(int, int);
extern "C" int DLL_EI _cdecl ExternCCdecl_Function(int, int);
int DLL_EI __cdecl Cdecl__Function(int, int);
extern "C" int DLL_EI __cdecl ExternCCdecl__Function(int, int);

int DLL_EI _stdcall Stdcall_Function(int, int);
extern "C" int DLL_EI _stdcall ExternCStdcall_Function(int, int);
int DLL_EI __stdcall Stdcall__Function(int, int);
extern "C" int DLL_EI __stdcall ExternCStdcall__Function(int, int);

int DLL_EI _fastcall Fastcall_Function(int, int);
extern "C" int DLL_EI _fastcall ExternCFastcall_Function(int, int);
int DLL_EI __fastcall Fastcall__Function(int, int);
extern "C" int DLL_EI __fastcall ExternCFastcall__Function(int, int);

int DLL_EI pascal PascalFunction(int, int);
extern "C" int DLL_EI pascal ExternCPascalFunction(int, int);
int DLL_EI _pascal Pascal_Function(int, int);
extern "C" int DLL_EI _pascal ExternCPascal_Function(int, int);
int DLL_EI __pascal Pascal__Function(int, int);
extern "C" int DLL_EI __pascal ExternCPascal__Function(int, int);

#endif

