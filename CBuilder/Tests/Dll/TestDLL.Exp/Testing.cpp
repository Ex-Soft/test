//---------------------------------------------------------------------------

#include <vcl.h>
//#include <Dialogs.hpp>
#pragma hdrstop
//---------------------------------------------------------------------------
//   Important note about DLL memory management when your DLL uses the
//   static version of the RunTime Library:
//
//   If your DLL exports any functions that pass String objects (or structs/
//   classes containing nested Strings) as parameter or function results,
//   you will need to add the library MEMMGR.LIB to both the DLL project and
//   any other projects that use the DLL.  You will also need to use MEMMGR.LIB
//   if any other projects which use the DLL will be performing new or delete
//   operations on any non-TObject-derived classes which are exported from the
//   DLL. Adding MEMMGR.LIB to your project will change the DLL and its calling
//   EXE's to use the BORLNDMM.DLL as their memory manager.  In these cases,
//   the file BORLNDMM.DLL should be deployed along with your DLL.
//
//   To avoid using BORLNDMM.DLL, pass string information using "char *" or
//   ShortString parameters.
//
//   If your DLL uses the dynamic version of the RTL, you do not need to
//   explicitly add MEMMGR.LIB as this will be done implicitly for you
//---------------------------------------------------------------------------

#pragma argsused

#include "Testing.h"
//---------------------------------------------------------------------------

int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   return 1;
}
//---------------------------------------------------------------------------

//void DLL_EI __stdcall VoidFunction(void) // VoidFunction
//void DLL_EI __fastcall VoidFunction(void) // VoidFunction
void DLL_EI VoidFunction(void) // _VoidFunction
//void VoidFunction(void)
{
//   for(int i=0;i<999;i++)
//      ;

   AnsiString Mess;
   Sleep(5000);
   try
     {
        if(!DeleteFile("TestDLL.exe"))
          {
             Mess="DeleteFile() No!!! Error#"+IntToStr(GetLastError());
             ShowMessage(Mess);
          }
        else
          ShowMessage("DeleteFile() Yes!!!");
     }
   catch(...)
     {
        ShowMessage("catch() No!!!");
     }

   FreeLibrary(GetModuleHandle(0));
}
//---------------------------------------------------------------------------

//void DLL_EI __stdcall FileFunction(FILE *FilePtr, AnsiString WriteString) // FileFunction
void DLL_EI FileFunction(FILE *FilePtr, AnsiString WriteString) // _FileFunction
//void FileFunction(FILE *FilePtr, AnsiString WriteString)
{
   if(!FilePtr)
     return;

   if(fputs(WriteString.c_str(),FilePtr)==EOF)
     throw Exception("Error!!!");
}
//---------------------------------------------------------------------------

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

int DLL_EI _pascal Pascal_Function(int left, int right)
{
   return left + right;
}

int DLL_EI _pascal ExternCPascal_Function(int left, int right)
{
   return left + right;
}

int DLL_EI __pascal Pascal__Function(int left, int right)
{
   return left + right;
}

int DLL_EI __pascal ExternCPascal__Function(int left, int right)
{
   return left + right;
}

