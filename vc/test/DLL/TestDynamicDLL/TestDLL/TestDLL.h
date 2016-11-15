#ifndef TestDllH
#define TestDllH

    #ifdef TESTDLL_EXPORTS
        #define DLL_EI __declspec(dllexport)
    #else
        #define DLL_EI __declspec(dllimport)
    #endif

    extern "C" int DLL_EI Add(int, int); // Add = @ILT+205(_Add)
    extern "C" bool DLL_EI Copy(const unsigned char *, unsigned char *, unsigned long); // Copy = @ILT+260(_Copy) 

    int DLL_EI cdecl CdeclFunction(int, int); // ?CdeclFunction@@YAHHH@Z = @ILT+270(?CdeclFunction@@YAHHH@Z)
    extern "C" int DLL_EI cdecl ExternCCdeclFunction(int, int); // ExternCCdeclFunction = @ILT+285(_ExternCCdeclFunction)
    int DLL_EI _cdecl Cdecl_Function(int, int); // ?Cdecl_Function@@YAHHH@Z = @ILT+365(?Cdecl_Function@@YAHHH@Z)
    extern "C" int DLL_EI _cdecl ExternCCdecl_Function(int, int); // ExternCCdecl_Function = @ILT+225(_ExternCCdecl_Function)
    int DLL_EI __cdecl Cdecl__Function(int, int); // ?Cdecl__Function@@YAHHH@Z = @ILT+190(?Cdecl__Function@@YAHHH@Z)
    extern "C" int DLL_EI __cdecl ExternCCdecl__Function(int, int); // ExternCCdecl__Function = @ILT+165(_ExternCCdecl__Function)

    int DLL_EI _stdcall Stdcall_Function(int, int); // ?Stdcall_Function@@YGHHH@Z = @ILT+415(?Stdcall_Function@@YGHHH@Z)
    extern "C" int DLL_EI _stdcall ExternCStdcall_Function(int, int); // _ExternCStdcall_Function@8 = @ILT+430(_ExternCStdcall_Function@8)
    int DLL_EI __stdcall Stdcall__Function(int, int); // ?Stdcall__Function@@YGHHH@Z = @ILT+175(?Stdcall__Function@@YGHHH@Z)
    extern "C" int DLL_EI __stdcall ExternCStdcall__Function(int, int); // _ExternCStdcall__Function@8 = @ILT+25(_ExternCStdcall__Function@8)

    int DLL_EI _fastcall Fastcall_Function(int, int); // ?Fastcall_Function@@YIHHH@Z = @ILT+0(?Fastcall_Function@@YIHHH@Z)
    extern "C" int DLL_EI _fastcall ExternCFastcall_Function(int, int); // @ExternCFastcall_Function@8 = @ILT+390(@ExternCFastcall_Function@8)
    int DLL_EI __fastcall Fastcall__Function(int, int); // ?Fastcall__Function@@YIHHH@Z = @ILT+120(?Fastcall__Function@@YIHHH@Z)
    extern "C" int DLL_EI __fastcall ExternCFastcall__Function(int, int); // @ExternCFastcall__Function@8 = @ILT+335(@ExternCFastcall__Function@8)

    int DLL_EI pascal PascalFunction(int, int); // ?PascalFunction@@YGHHH@Z = @ILT+295(?PascalFunction@@YGHHH@Z)
    extern "C" int DLL_EI pascal ExternCPascalFunction(int, int); // _ExternCPascalFunction@8 = @ILT+325(_ExternCPascalFunction@8)
  
#endif