//---------------------------------------------------------------------------

#include <vcl.h>
#include <windows.h>
#pragma hdrstop

#include "maindll.h"

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
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
        return 1;
}
//---------------------------------------------------------------------------

void DLL_EI __stdcall STACKSTDCALL(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];

   char sChar=0;
   unsigned char sUChar=0;
   int sInt=0;
   __int32 sInt32=0;
   __int64 sInt64=0;

   asm{
         mov ecx,0x0100
         mov esi,0x08
         xor edi,edi
      }
loop:
   asm{
         xor eax,eax
         mov al, byte ptr [ebp+esi]
         mov byte ptr tmp[edi],al
         cmp esi,0x08
         jne lUChar
         mov al,byte ptr [ebp+esi]
         mov byte ptr sChar,al
         jmp next
      }
lUChar:
   asm{
         cmp esi,0x0c
         jne lInt
         mov al,byte ptr [ebp+esi]
         mov byte ptr sUChar,al
         jmp next
      }
lInt:
   asm{
         cmp esi,0x010
         jne lInt32
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt,eax
         jmp next
      }
lInt32:
   asm{
         cmp esi,0x014
         jne lInt64
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt32,eax
         jmp next
      }
lInt64:
   asm{
         cmp esi,0x018
         jne next
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt64,eax
         mov eax,dword ptr [ebp+esi+4]
         mov dword ptr sInt64[4],eax
      }
next:
   asm{
         inc esi
         inc edi
         dec ecx
         jnz loop
      }

   AnsiString StrOut="";
   for(int i=0,j=0; i<0x0100; i++, j++)
      {
         StrOut+=IntToHex(*(tmp+i),2);
         if(j==3)
           {
              StrOut+=" ";
              j=-1;
           }
      }

   Application->MessageBox(StrOut.c_str(),"STACKSTDCALL()",MB_ICONINFORMATION|MB_OK);

   StrOut="";
   StrOut+="char="+IntToHex(sChar,2);
   StrOut+="\n";
   StrOut+="unsigned char="+IntToHex(sUChar,2);
   StrOut+="\n";
   StrOut+="int="+IntToHex(sInt,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(sInt32,2);
   StrOut+="\n";
   StrOut+="__int64="+IntToHex(sInt64,2);

   Application->MessageBox(StrOut.c_str(),"STACKSTDCALL()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void DLL_EI __stdcall STACKSTDCALLMIN(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];

   Application->MessageBox(IntToHex((int)aChar,2).c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aUChar,2).c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt,2).c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt32,2).c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt64,2).c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);

   asm{
         mov ecx,0x0100
         mov esi,0x08
         xor edi,edi
      }
loop:
   asm{
         xor eax,eax
         mov al, byte ptr [ebp+esi]
         mov byte ptr tmp[edi],al
         inc esi
         inc edi
         dec ecx
         jnz loop
      }

   AnsiString StrOut="";
   for(int i=0,j=0; i<0x0100; i++, j++)
      {
         StrOut+=IntToHex(*(tmp+i),2);
         if(j==3)
           {
              StrOut+=" ";
              j=-1;
           }
      }

   Application->MessageBox(StrOut.c_str(),"STACKSTDCALLMIN()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void DLL_EI __cdecl STACKCDECL(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];

   char sChar=0;
   unsigned char sUChar=0;
   int sInt=0;
   __int32 sInt32=0;
   __int64 sInt64=0;

   asm{
         mov ecx,0x0100
         mov esi,0x08
         xor edi,edi
      }
loop:
   asm{
         xor eax,eax
         mov al, byte ptr [ebp+esi]
         mov byte ptr tmp[edi],al
         cmp esi,0x08
         jne lUChar
         mov al,byte ptr [ebp+esi]
         mov byte ptr sChar,al
         jmp next
      }
lUChar:
   asm{
         cmp esi,0x0c
         jne lInt
         mov al,byte ptr [ebp+esi]
         mov byte ptr sUChar,al
         jmp next
      }
lInt:
   asm{
         cmp esi,0x010
         jne lInt32
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt,eax
         jmp next
      }
lInt32:
   asm{
         cmp esi,0x014
         jne lInt64
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt32,eax
         jmp next
      }
lInt64:
   asm{
         cmp esi,0x018
         jne next
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt64,eax
         mov eax,dword ptr [ebp+esi+4]
         mov dword ptr sInt64[4],eax
      }
next:
   asm{
         inc esi
         inc edi
         dec ecx
         jnz loop
      }

   AnsiString StrOut="";
   for(int i=0,j=0; i<0x0100; i++, j++)
      {
         StrOut+=IntToHex(*(tmp+i),2);
         if(j==3)
           {
              StrOut+=" ";
              j=-1;
           }
      }

   Application->MessageBox(StrOut.c_str(),"STACKCDECL()",MB_ICONINFORMATION|MB_OK);

   StrOut="";
   StrOut+="char="+IntToHex(sChar,2);
   StrOut+="\n";
   StrOut+="unsigned char="+IntToHex(sUChar,2);
   StrOut+="\n";
   StrOut+="int="+IntToHex(sInt,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(sInt32,2);
   StrOut+="\n";
   StrOut+="__int64="+IntToHex(sInt64,2);

   Application->MessageBox(StrOut.c_str(),"STACKCDECL()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void DLL_EI __pascal StackPascal(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int32 pInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];

   char sChar=0;
   unsigned char sUChar=0;
   int sInt=0;
   __int32 sInt32=0;
   __int32 spInt32=0;
   __int64 sInt64=0;

   Application->MessageBox(IntToHex((int)aChar,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aUChar,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt32,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(pInt32,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt64,2).c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   asm{
         mov ecx,0x0100
         mov esi,0x08
         xor edi,edi
      }
loop:
   asm{
         xor eax,eax
         mov al, byte ptr [ebp+esi]
         mov byte ptr tmp[edi],al
         cmp esi,0x08
         jne lpInt32
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt64,eax
         mov eax,dword ptr [ebp+esi+4]
         mov dword ptr sInt64[4],eax
         jmp next
      }
lpInt32:
   asm{
         cmp esi,0x10
         jne lInt32
         mov eax,dword ptr [ebp+esi]
         mov dword ptr spInt32,eax
         jmp next
      }
lInt32:
   asm{
         cmp esi,0x14
         jne lInt
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt32,eax
         jmp next
      }
lInt:
   asm{
         cmp esi,0x018
         jne lUChar
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt,eax
         jmp next
      }
lUChar:
   asm{
         cmp esi,0x01c
         jne lChar
         mov al,byte ptr [ebp+esi]
         mov byte ptr sUChar,al
         jmp next
      }
lChar:
   asm{
         cmp esi,0x020
         jne next
         mov al,byte ptr [ebp+esi]
         mov byte ptr sChar,al
      }
next:
   asm{
         inc esi
         inc edi
         dec ecx
         jnz loop
      }

   AnsiString StrOut="";
   for(int i=0,j=0; i<0x0100; i++, j++)
      {
         StrOut+=IntToHex(*(tmp+i),2);
         if(j==3)
           {
              StrOut+=" ";
              j=-1;
           }
      }

   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   StrOut="";
   StrOut+="char="+IntToHex(sChar,2);
   StrOut+="\n";
   StrOut+="unsigned char="+IntToHex(sUChar,2);
   StrOut+="\n";
   StrOut+="int="+IntToHex(sInt,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(sInt32,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(spInt32,2);
   StrOut+="\n";
   StrOut+="__int64="+IntToHex(sInt64,2);

   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   __int32 *ppInt32=(__int32 *)spInt32;
   StrOut="(__int32 *)"+IntToHex(spInt32,2)+"="+IntToHex(*ppInt32,2);
   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   asm{
         xor eax,eax
         push cs
         pop eax
         mov sInt32,eax
      }
   StrOut="CS="+IntToHex(sInt32,4)+"\n";
   asm{
         xor eax,eax
         mov esi,spInt32
         mov eax,cs:[esi]
         mov sInt32,eax
      }
   StrOut+="CS:["+IntToHex(spInt32,2)+"]="+IntToHex(sInt32,2);
   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   asm{
         xor eax,eax
         push ds
         pop eax
         mov sInt32,eax
      }
   StrOut="DS="+IntToHex(sInt32,4)+"\n";
   asm{
         xor eax,eax
         mov esi,spInt32
         mov eax,ds:[esi]
         mov sInt32,eax
      }
   StrOut+="DS:["+IntToHex(spInt32,2)+"]="+IntToHex(sInt32,2);
   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);

   asm{
         xor eax,eax
         push es
         pop eax
         mov sInt32,eax
      }
   StrOut="ES="+IntToHex(sInt32,4)+"\n";
   asm{
         xor eax,eax
         mov esi,spInt32
         mov eax,es:[esi]
         mov sInt32,eax
      }
   StrOut+="ES:["+IntToHex(spInt32,2)+"]="+IntToHex(sInt32,2);
   Application->MessageBox(StrOut.c_str(),"StackPascal()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void DLL_EI __fastcall StackFastcall(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];
   char sChar=0;
   unsigned char sUChar=0;
   int sInt=0;
   __int32 sInt32=0;
   __int64 sInt64=0;

   Application->MessageBox(IntToHex((int)aChar,2).c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aUChar,2).c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt,2).c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt32,2).c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt64,2).c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);

   asm{
         mov ecx,0x0100
         mov esi,0x08
         xor edi,edi
      }
loop:
   asm{
         xor eax,eax
         mov al, byte ptr [ebp+esi]
         mov byte ptr tmp[edi],al
         cmp esi,0x08
         jne lInt32
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt64,eax
         mov eax,dword ptr [ebp+esi+4]
         mov dword ptr sInt64[4],eax
         jmp next
      }
lInt32:
   asm{
         cmp esi,0x10
         jne next
         mov eax,dword ptr [ebp+esi]
         mov dword ptr sInt32,eax
      }
next:
   asm{
         inc esi
         inc edi
         dec ecx
         jnz loop

         lea esi,sChar
         inc esi
         mov eax,dword ptr [esi]
         mov dword ptr sInt,eax

         add esi, 6
         xor eax,eax
         mov al,byte ptr [esi]
         mov byte ptr sUChar,al

         inc esi
         xor eax,eax
         mov al,byte ptr [esi]
         mov byte ptr sChar,al
      }

   AnsiString StrOut="";
   for(int i=0,j=0; i<0x0100; i++, j++)
      {
         StrOut+=IntToHex(*(tmp+i),2);
         if(j==3)
           {
              StrOut+=" ";
              j=-1;
           }
      }

   Application->MessageBox(StrOut.c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);

   StrOut="";
   StrOut+="char="+IntToHex(sChar,2);
   StrOut+="\n";
   StrOut+="unsigned char="+IntToHex(sUChar,2);
   StrOut+="\n";
   StrOut+="int="+IntToHex(sInt,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(sInt32,2);
   StrOut+="\n";
   StrOut+="__int64="+IntToHex(sInt64,2);

   Application->MessageBox(StrOut.c_str(),"StackFastcall()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

