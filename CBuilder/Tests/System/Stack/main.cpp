//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "maindll.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

void __stdcall ShowStackEmpty(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
void __stdcall ShowStack(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
void __fastcall ShowStackFastcall(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64);
void ShowStackReference(char &aChar);
void ShowStackValue(char aChar);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   char pChar=0x07f;
   unsigned char pUChar=0x0ff;
   int pInt=0x0aabb;
   __int32 pInt32=0x0ccccdddd;
   __int64 pInt64=0x0eeeeeeeeffffffff;
   AnsiString StrOut="";

   //ShowStackReference(pChar);
   //ShowStackValue(pChar);

   StrOut+="char="+IntToHex(pChar,2);
   StrOut+="\n";
   StrOut+="unsigned char="+IntToHex(pUChar,2);
   StrOut+="\n";
   StrOut+="int="+IntToHex(pInt,2);
   StrOut+="\n";
   StrOut+="__int32="+IntToHex(pInt32,2);
   StrOut+="\n";
   StrOut+="__int64="+IntToHex(pInt64,2);

   Application->MessageBox(StrOut.c_str(),"Main()",MB_ICONINFORMATION|MB_OK);

//   ShowStackEmpty(pChar,pUChar,pInt,pInt32,pInt64);
   ShowStack(pChar,pUChar,pInt,pInt32,pInt64);
//   ShowStackFastcall(pChar,pUChar,pInt,pInt32,pInt64);

//   STACKSTDCALL(pChar,pUChar,pInt,pInt32,pInt64);
//   STACKSTDCALLMIN(pChar,pUChar,pInt,pInt32,pInt64);
//   STACKCDECL(pChar,pUChar,pInt,pInt32,pInt64);
//   StackPascal(pChar,pUChar,pInt,pInt32,(__int32)&pInt32,pInt64);
//   StackFastcall(pChar,pUChar,pInt,pInt32,pInt64);
}
//---------------------------------------------------------------------------

void __stdcall ShowStackEmpty(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   Application->MessageBox("ShowStackEmpty()","ShowStackEmpty()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void __stdcall ShowStack(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
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

   Application->MessageBox(StrOut.c_str(),"ShowStack()",MB_ICONINFORMATION|MB_OK);

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

   Application->MessageBox(StrOut.c_str(),"ShowStack()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void __fastcall ShowStackFastcall(char aChar, unsigned char aUChar, int aInt, __int32 aInt32, __int64 aInt64)
{
   unsigned char tmp[0x0100];
   char sChar=0;
   unsigned char sUChar=0;
   int sInt=0;
   __int32 sInt32=0;
   __int64 sInt64=0;

   Application->MessageBox(IntToHex((int)aChar,2).c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aUChar,2).c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt,2).c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt32,2).c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);
   Application->MessageBox(IntToHex(aInt64,2).c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);

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

   Application->MessageBox(StrOut.c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);

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

   Application->MessageBox(StrOut.c_str(),"ShowStackFastcall()",MB_ICONINFORMATION|MB_OK);
}
//---------------------------------------------------------------------------

void ShowStackReference(char &aChar)
{
   aChar=0x06f;
   Application->MessageBox("ShowStackReference()","ShowStackReference()",MB_ICONINFORMATION|MB_OK);
   aChar=0x07f;
}
//---------------------------------------------------------------------------

void ShowStackValue(char aChar)
{
   aChar=0x06f;
   Application->MessageBox("ShowStackValue()","ShowStackValue()",MB_ICONINFORMATION|MB_OK);
   aChar=0x07f;
}
//---------------------------------------------------------------------------
