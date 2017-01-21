//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "Alignment.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#define UCHAR unsigned char
#define USHORT unsigned short

typedef struct ____CTRL_TOKEN
{
UCHAR synchro1;
USHORT data1;
UCHAR synchro2;
USHORT data2;
} CTRL_TOKEN ;

#pragma pack( push, 1 )
typedef struct ____CTRL_TOKEN1
{
UCHAR synchro1;
USHORT data1;
UCHAR synchro2;
USHORT data2;
} CTRL_TOKEN1 ;
#pragma pack( pop ) ;

void __fastcall FillStructByte(sStructByte S);
void __fastcall FillStructWord(sStructWord S);
void __fastcall FillStructDoubleWord(sStructDoubleWord S);
void __fastcall FillStructQuadWord(sStructQuadWord S);

void __fastcall FillClassByte(TClassByte C);
void __fastcall FillClassWord(TClassWord C);
void __fastcall FillClassDoubleWord(TClassDoubleWord C);
void __fastcall FillClassQuadWord(TClassQuadWord C);

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
  CTRL_TOKEN t ;
  t.synchro1 = 1 ;
  t.data1 = 1 ;
  t.synchro2 = 1 ;
  t.data2 = 1 ;

  CTRL_TOKEN1 t1 ;
  t1.synchro1 = 1 ;
  t1.data1 = 1 ;
  t1.synchro2 = 1 ;
  t1.data2 = 1 ;
  int size1 = sizeof( ____CTRL_TOKEN ) ;
  int size2 = sizeof( ____CTRL_TOKEN1 ) ;

  char buff[sizeof( ____CTRL_TOKEN ) ] ;
  memset( buff, 'a', sizeof( ____CTRL_TOKEN ) ) ;
  memcpy( buff, &t, sizeof( t )) ;

  char buff1[sizeof( ____CTRL_TOKEN1 ) ] ;
  memset( buff1, 'a', sizeof( ____CTRL_TOKEN1 ) ) ;
  memcpy( buff1, &t1, sizeof( t1 )) ;

   sStructByte
     S1,
     *S1Ptr;

   sStructWord
     S2,
     *S2Ptr;

   sStructDoubleWord
     S4,
     *S4Ptr;

   sStructQuadWord
     S8,
     *S8Ptr;

   int
     Size;

   Size=sizeof(S1);
   setmem(&S1,Size,'\x0');

   S1.FUChar=0x0ff;
   Size=sizeof(S1.FChar11);
   setmem(S1.FChar11,Size,'\x11');
   S1.FChar=0x07f;
   Size=sizeof(S1.FChar13);
   setmem(S1.FChar13,Size,'\x13');
   S1.FShortInt=0x0aaaa;
   Size=sizeof(S1.FChar15);
   setmem(S1.FChar15,Size,'\x15');
   S1.FInt=0x0bbbbbbbb;
   Size=sizeof(S1.FChar17);
   setmem(S1.FChar17,Size,'\x17');
   S1Ptr=new sStructByte;
   S1.Ptr=S1Ptr;

   Size=sizeof(S2);
   setmem(&S2,Size,'\x0');

   S2.FUChar=0x0ff;
   Size=sizeof(S2.FChar11);
   setmem(S2.FChar11,Size,'\x11');
   S2.FChar=0x07f;
   Size=sizeof(S2.FChar13);
   setmem(S2.FChar13,Size,'\x13');
   S2.FShortInt=0x0aaaa;
   Size=sizeof(S2.FChar15);
   setmem(S2.FChar15,Size,'\x15');
   S2.FInt=0x0bbbbbbbb;
   Size=sizeof(S2.FChar17);
   setmem(S2.FChar17,Size,'\x17');
   S2Ptr=new sStructWord;
   S2.Ptr=S2Ptr;

   Size=sizeof(S4);
   setmem(&S4,Size,'\x0');

   S4.FUChar=0x0ff;
   Size=sizeof(S4.FChar11);
   setmem(S4.FChar11,Size,'\x11');
   S4.FChar=0x07f;
   Size=sizeof(S4.FChar13);
   setmem(S4.FChar13,Size,'\x13');
   S4.FShortInt=0x0aaaa;
   Size=sizeof(S4.FChar15);
   setmem(S4.FChar15,Size,'\x15');
   S4.FInt=0x0bbbbbbbb;
   Size=sizeof(S4.FChar17);
   setmem(S4.FChar17,Size,'\x17');
   S4Ptr=new sStructDoubleWord;
   S4.Ptr=S4Ptr;

   Size=sizeof(S8);
   setmem(&S8,Size,'\x0');

   S8.FUChar=0x0ff;
   Size=sizeof(S8.FChar11);
   setmem(S8.FChar11,Size,'\x11');
   S8.FChar=0x07f;
   Size=sizeof(S8.FChar13);
   setmem(S8.FChar13,Size,'\x13');
   S8.FShortInt=0x0aaaa;
   Size=sizeof(S8.FChar15);
   setmem(S8.FChar15,Size,'\x15');
   S8.FInt=0x0bbbbbbbb;
   Size=sizeof(S8.FChar17);
   setmem(S8.FChar17,Size,'\x17');
   S8Ptr=new sStructQuadWord;
   S8.Ptr=S8Ptr;

   FillStructByte(S1);
   FillStructWord(S2);
   FillStructDoubleWord(S4);
   FillStructQuadWord(S8);

   delete S1Ptr;
   delete S2Ptr;
   delete S4Ptr;
   delete S8Ptr;

   TClassByte C1,*C1Ptr;
   C1.SetUChar(0x0ee);
   C1.SetChar(0x06f);
   C1.SetShortInt(0x0cccc);
   C1.SetInt(0x0dddddddd);
   C1Ptr=new TClassByte;
   C1.SetPtr(C1Ptr);
   FillClassByte(C1);

   TClassWord C2,*C2Ptr;
   C2.SetUChar(0x0ee);
   C2.SetChar(0x06f);
   C2.SetShortInt(0x0cccc);
   C2.SetInt(0x0dddddddd);
   C2Ptr=new TClassWord;
   C2.SetPtr(C2Ptr);
   FillClassWord(C2);

   TClassDoubleWord C4,*C4Ptr;
   C4.SetUChar(0x0ee);
   C4.SetChar(0x06f);
   C4.SetShortInt(0x0cccc);
   C4.SetInt(0x0dddddddd);
   C4Ptr=new TClassDoubleWord;
   C4.SetPtr(C4Ptr);
   FillClassDoubleWord(C4);

   TClassQuadWord C8,*C8Ptr;
   C8.SetUChar(0x0ee);
   C8.SetChar(0x06f);
   C8.SetShortInt(0x0cccc);
   C8.SetInt(0x0dddddddd);
   C8Ptr=new TClassQuadWord;
   C8.SetPtr(C8Ptr);
   FillClassQuadWord(C8);

   delete C1Ptr;
   delete C2Ptr;
   delete C4Ptr;
   delete C8Ptr;
}
//---------------------------------------------------------------------------

void __fastcall FillStructByte(sStructByte S)
{
   int
     Size;

   S.Ptr->FUChar = S.FUChar;
   Size=sizeof(S.Ptr->FChar11);
   memcpy(S.Ptr->FChar11,S.FChar11,Size);
   S.Ptr->FChar = S.FChar;
   Size=sizeof(S.Ptr->FChar13);
   memcpy(S.Ptr->FChar13,S.FChar13,Size);
   S.Ptr->FShortInt = S.FShortInt;
   Size=sizeof(S.Ptr->FChar15);
   memcpy(S.Ptr->FChar15,S.FChar15,Size);
   S.Ptr->FInt = S.FInt;
   Size=sizeof(S.Ptr->FChar17);
   memcpy(S.Ptr->FChar17,S.FChar17,Size);
   S.Ptr->Ptr = S.Ptr;
}
//---------------------------------------------------------------------------

void __fastcall FillStructWord(sStructWord S)
{
   int
     Size;

   S.Ptr->FUChar = S.FUChar;
   Size=sizeof(S.Ptr->FChar11);
   memcpy(S.Ptr->FChar11,S.FChar11,Size);
   S.Ptr->FChar = S.FChar;
   Size=sizeof(S.Ptr->FChar13);
   memcpy(S.Ptr->FChar13,S.FChar13,Size);
   S.Ptr->FShortInt = S.FShortInt;
   Size=sizeof(S.Ptr->FChar15);
   memcpy(S.Ptr->FChar15,S.FChar15,Size);
   S.Ptr->FInt = S.FInt;
   Size=sizeof(S.Ptr->FChar17);
   memcpy(S.Ptr->FChar17,S.FChar17,Size);
   S.Ptr->Ptr = S.Ptr;
}
//---------------------------------------------------------------------------

void __fastcall FillStructDoubleWord(sStructDoubleWord S)
{
   int
     Size;

   S.Ptr->FUChar = S.FUChar;
   Size=sizeof(S.Ptr->FChar11);
   memcpy(S.Ptr->FChar11,S.FChar11,Size);
   S.Ptr->FChar = S.FChar;
   Size=sizeof(S.Ptr->FChar13);
   memcpy(S.Ptr->FChar13,S.FChar13,Size);
   S.Ptr->FShortInt = S.FShortInt;
   Size=sizeof(S.Ptr->FChar15);
   memcpy(S.Ptr->FChar15,S.FChar15,Size);
   S.Ptr->FInt = S.FInt;
   Size=sizeof(S.Ptr->FChar17);
   memcpy(S.Ptr->FChar17,S.FChar17,Size);
   S.Ptr->Ptr = S.Ptr;
}
//---------------------------------------------------------------------------

void __fastcall FillStructQuadWord(sStructQuadWord S)
{
   int
     Size;

   S.Ptr->FUChar = S.FUChar;
   Size=sizeof(S.Ptr->FChar11);
   memcpy(S.Ptr->FChar11,S.FChar11,Size);
   S.Ptr->FChar = S.FChar;
   Size=sizeof(S.Ptr->FChar13);
   memcpy(S.Ptr->FChar13,S.FChar13,Size);
   S.Ptr->FShortInt = S.FShortInt;
   Size=sizeof(S.Ptr->FChar15);
   memcpy(S.Ptr->FChar15,S.FChar15,Size);
   S.Ptr->FInt = S.FInt;
   Size=sizeof(S.Ptr->FChar17);
   memcpy(S.Ptr->FChar17,S.FChar17,Size);
   S.Ptr->Ptr = S.Ptr;
}
//---------------------------------------------------------------------------

void __fastcall FillClassByte(TClassByte C)
{
   int
     Size;

   C.GetPtr()->SetUChar(C.GetUChar()-1);
   C.GetPtr()->SetChar(C.GetChar()-1);
   C.GetPtr()->SetShortInt(C.GetShortInt()-1);
   C.GetPtr()->SetInt(C.GetInt()-1);
   C.GetPtr()->SetPtr(C.GetPtr());
}
//---------------------------------------------------------------------------

void __fastcall FillClassWord(TClassWord C)
{
   int
     Size;

   C.GetPtr()->SetUChar(C.GetUChar()-1);
   C.GetPtr()->SetChar(C.GetChar()-1);
   C.GetPtr()->SetShortInt(C.GetShortInt()-1);
   C.GetPtr()->SetInt(C.GetInt()-1);
   C.GetPtr()->SetPtr(C.GetPtr());
}
//---------------------------------------------------------------------------

void __fastcall FillClassDoubleWord(TClassDoubleWord C)
{
   int
     Size;

   C.GetPtr()->SetUChar(C.GetUChar()-1);
   C.GetPtr()->SetChar(C.GetChar()-1);
   C.GetPtr()->SetShortInt(C.GetShortInt()-1);
   C.GetPtr()->SetInt(C.GetInt()-1);
   C.GetPtr()->SetPtr(C.GetPtr());
}
//---------------------------------------------------------------------------

void __fastcall FillClassQuadWord(TClassQuadWord C)
{
   int
     Size;

   C.GetPtr()->SetUChar(C.GetUChar()-1);
   C.GetPtr()->SetChar(C.GetChar()-1);
   C.GetPtr()->SetShortInt(C.GetShortInt()-1);
   C.GetPtr()->SetInt(C.GetInt()-1);
   C.GetPtr()->SetPtr(C.GetPtr());
}
//---------------------------------------------------------------------------

