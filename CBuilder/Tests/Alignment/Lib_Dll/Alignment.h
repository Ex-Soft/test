#ifndef AlignmentH
#define AlignmentH

#if defined(__DLL__)
   #define DLL_EI __declspec(dllexport)
#else
   #define DLL_EI __declspec(dllimport)
#endif

#pragma pack(push,1)
struct sStructByte
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   sStructByte *Ptr;
};

class DLL_EI TClassByte
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   TClassByte *Ptr;

public:

   __fastcall TClassByte(void);

   void __fastcall SetUChar(unsigned char aUChar);
   unsigned char __fastcall GetUChar(void);

   void __fastcall SetChar(char aChar);
   char __fastcall GetChar(void);

   void __fastcall SetShortInt(short int aShortInt);
   short int __fastcall GetShortInt(void);

   void __fastcall SetInt(int aInt);
   int __fastcall GetInt(void);

   void __fastcall SetPtr(TClassByte *aPtr);
   TClassByte * __fastcall GetPtr(void);
};
#pragma pack(pop)

#pragma pack(push,2)
struct sStructWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   sStructWord *Ptr;
};

class DLL_EI TClassWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   TClassWord *Ptr;

public:

   __fastcall TClassWord(void);

   void __fastcall SetUChar(unsigned char aUChar);
   unsigned char __fastcall GetUChar(void);

   void __fastcall SetChar(char aChar);
   char __fastcall GetChar(void);

   void __fastcall SetShortInt(short int aShortInt);
   short int __fastcall GetShortInt(void);

   void __fastcall SetInt(int aInt);
   int __fastcall GetInt(void);

   void __fastcall SetPtr(TClassWord *aPtr);
   TClassWord * __fastcall GetPtr(void);
};
#pragma pack(pop)

#pragma pack(push,4)
struct sStructDoubleWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   sStructDoubleWord *Ptr;
};

class DLL_EI TClassDoubleWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   TClassDoubleWord *Ptr;

public:

   __fastcall TClassDoubleWord(void);

   void __fastcall SetUChar(unsigned char aUChar);
   unsigned char __fastcall GetUChar(void);

   void __fastcall SetChar(char aChar);
   char __fastcall GetChar(void);

   void __fastcall SetShortInt(short int aShortInt);
   short int __fastcall GetShortInt(void);

   void __fastcall SetInt(int aInt);
   int __fastcall GetInt(void);

   void __fastcall SetPtr(TClassDoubleWord *aPtr);
   TClassDoubleWord * __fastcall GetPtr(void);
};
#pragma pack(pop)

#pragma pack(push,8)
struct sStructQuadWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   sStructQuadWord *Ptr;
};

class DLL_EI TClassQuadWord
{
   unsigned char FUChar;
   char FChar11[11];
   char FChar;
   char FChar13[13];
   short int FShortInt;
   char FChar15[15];
   int FInt;
   char FChar17[17];
   TClassQuadWord *Ptr;

public:

   __fastcall TClassQuadWord(void);

   void __fastcall SetUChar(unsigned char aUChar);
   unsigned char __fastcall GetUChar(void);

   void __fastcall SetChar(char aChar);
   char __fastcall GetChar(void);

   void __fastcall SetShortInt(short int aShortInt);
   short int __fastcall GetShortInt(void);

   void __fastcall SetInt(int aInt);
   int __fastcall GetInt(void);

   void __fastcall SetPtr(TClassQuadWord *aPtr);
   TClassQuadWord * __fastcall GetPtr(void);
};
#pragma pack(pop)

#endif

