#ifndef MaindllH
#define MaindllH

  #if defined(__BUILD_DLL__)
     #define DLL_EI __declspec(dllexport)
  #else
     #define DLL_EI __declspec(dllimport)
  #endif

  extern "C" void DLL_EI __stdcall STACKSTDCALL(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
  extern "C" void DLL_EI __stdcall STACKSTDCALLMIN(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
  extern "C" void DLL_EI __cdecl STACKCDECL(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
  extern "C" void DLL_EI __pascal StackPascal(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int32 pInt32, __int64 aInt64);
  extern "C" void DLL_EI __fastcall StackFastcall(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
#endif
