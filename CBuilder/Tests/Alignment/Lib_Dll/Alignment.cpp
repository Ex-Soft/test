//---------------------------------------------------------------------------

#include <vcl.h>
#include <windows.h>
#pragma hdrstop

#include "Alignment.h"
//---------------------------------------------------------------------------

#if defined(__DLL__)
#pragma argsused
int WINAPI DllEntryPoint(HINSTANCE hinst, unsigned long reason, void* lpReserved)
{
   return 1;
}
#endif
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TClassByte
//---------------------------------------------------------------------------
__fastcall TClassByte::TClassByte(void)
{
   FUChar=0x0ff;
   setmem(FChar11,sizeof(FChar11),'\x11');
   FChar=0x07f;
   setmem(FChar13,sizeof(FChar13),'\x13');
   FShortInt=0x0aaaa;
   setmem(FChar15,sizeof(FChar15),'\x15');
   FInt=0x0bbbbbbbb;
   setmem(FChar17,sizeof(FChar17),'\x17');
   Ptr=0;
}
//---------------------------------------------------------------------------

void __fastcall TClassByte::SetUChar(unsigned char aUChar)
{
   FUChar=aUChar;
}
//---------------------------------------------------------------------------

unsigned char __fastcall TClassByte::GetUChar(void)
{
   return FUChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassByte::SetChar(char aChar)
{
   FChar=aChar;
}
//---------------------------------------------------------------------------

char __fastcall TClassByte::GetChar(void)
{
   return FChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassByte::SetShortInt(short int aShortInt)
{
   FShortInt=aShortInt;
}
//---------------------------------------------------------------------------

short int __fastcall TClassByte::GetShortInt(void)
{
   return FShortInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassByte::SetInt(int aInt)
{
   FInt=aInt;
}
//---------------------------------------------------------------------------

int __fastcall TClassByte::GetInt(void)
{
   return FInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassByte::SetPtr(TClassByte *aPtr)
{
   Ptr=aPtr;
}
//---------------------------------------------------------------------------

TClassByte * __fastcall TClassByte::GetPtr(void)
{
   return Ptr;
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TClassWord
//---------------------------------------------------------------------------
__fastcall TClassWord::TClassWord(void)
{
   FUChar=0x0ff;
   setmem(FChar11,sizeof(FChar11),'\x11');
   FChar=0x07f;
   setmem(FChar13,sizeof(FChar13),'\x13');
   FShortInt=0x0aaaa;
   setmem(FChar15,sizeof(FChar15),'\x15');
   FInt=0x0bbbbbbbb;
   setmem(FChar17,sizeof(FChar17),'\x17');
   Ptr=0;
}
//---------------------------------------------------------------------------

void __fastcall TClassWord::SetUChar(unsigned char aUChar)
{
   FUChar=aUChar;
}
//---------------------------------------------------------------------------

unsigned char __fastcall TClassWord::GetUChar(void)
{
   return FUChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassWord::SetChar(char aChar)
{
   FChar=aChar;
}
//---------------------------------------------------------------------------

char __fastcall TClassWord::GetChar(void)
{
   return FChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassWord::SetShortInt(short int aShortInt)
{
   FShortInt=aShortInt;
}
//---------------------------------------------------------------------------

short int __fastcall TClassWord::GetShortInt(void)
{
   return FShortInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassWord::SetInt(int aInt)
{
   FInt=aInt;
}
//---------------------------------------------------------------------------

int __fastcall TClassWord::GetInt(void)
{
   return FInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassWord::SetPtr(TClassWord *aPtr)
{
   Ptr=aPtr;
}
//---------------------------------------------------------------------------

TClassWord * __fastcall TClassWord::GetPtr(void)
{
   return Ptr;
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TClassDoubleWord
//---------------------------------------------------------------------------
__fastcall TClassDoubleWord::TClassDoubleWord(void)
{
   FUChar=0x0ff;
   setmem(FChar11,sizeof(FChar11),'\x11');
   FChar=0x07f;
   setmem(FChar13,sizeof(FChar13),'\x13');
   FShortInt=0x0aaaa;
   setmem(FChar15,sizeof(FChar15),'\x15');
   FInt=0x0bbbbbbbb;
   setmem(FChar17,sizeof(FChar17),'\x17');
   Ptr=0;
}
//---------------------------------------------------------------------------

void __fastcall TClassDoubleWord::SetUChar(unsigned char aUChar)
{
   FUChar=aUChar;
}
//---------------------------------------------------------------------------

unsigned char __fastcall TClassDoubleWord::GetUChar(void)
{
   return FUChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassDoubleWord::SetChar(char aChar)
{
   FChar=aChar;
}
//---------------------------------------------------------------------------

char __fastcall TClassDoubleWord::GetChar(void)
{
   return FChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassDoubleWord::SetShortInt(short int aShortInt)
{
   FShortInt=aShortInt;
}
//---------------------------------------------------------------------------

short int __fastcall TClassDoubleWord::GetShortInt(void)
{
   return FShortInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassDoubleWord::SetInt(int aInt)
{
   FInt=aInt;
}
//---------------------------------------------------------------------------

int __fastcall TClassDoubleWord::GetInt(void)
{
   return FInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassDoubleWord::SetPtr(TClassDoubleWord *aPtr)
{
   Ptr=aPtr;
}
//---------------------------------------------------------------------------

TClassDoubleWord * __fastcall TClassDoubleWord::GetPtr(void)
{
   return Ptr;
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TClassQuadWord
//---------------------------------------------------------------------------
__fastcall TClassQuadWord::TClassQuadWord(void)
{
   FUChar=0x0ff;
   setmem(FChar11,sizeof(FChar11),'\x11');
   FChar=0x07f;
   setmem(FChar13,sizeof(FChar13),'\x13');
   FShortInt=0x0aaaa;
   setmem(FChar15,sizeof(FChar15),'\x15');
   FInt=0x0bbbbbbbb;
   setmem(FChar17,sizeof(FChar17),'\x17');
   Ptr=0;
}
//---------------------------------------------------------------------------

void __fastcall TClassQuadWord::SetUChar(unsigned char aUChar)
{
   FUChar=aUChar;
}
//---------------------------------------------------------------------------

unsigned char __fastcall TClassQuadWord::GetUChar(void)
{
   return FUChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassQuadWord::SetChar(char aChar)
{
   FChar=aChar;
}
//---------------------------------------------------------------------------

char __fastcall TClassQuadWord::GetChar(void)
{
   return FChar;
}
//---------------------------------------------------------------------------

void __fastcall TClassQuadWord::SetShortInt(short int aShortInt)
{
   FShortInt=aShortInt;
}
//---------------------------------------------------------------------------

short int __fastcall TClassQuadWord::GetShortInt(void)
{
   return FShortInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassQuadWord::SetInt(int aInt)
{
   FInt=aInt;
}
//---------------------------------------------------------------------------

int __fastcall TClassQuadWord::GetInt(void)
{
   return FInt;
}
//---------------------------------------------------------------------------

void __fastcall TClassQuadWord::SetPtr(TClassQuadWord *aPtr)
{
   Ptr=aPtr;
}
//---------------------------------------------------------------------------

TClassQuadWord * __fastcall TClassQuadWord::GetPtr(void)
{
   return Ptr;
}
//---------------------------------------------------------------------------

