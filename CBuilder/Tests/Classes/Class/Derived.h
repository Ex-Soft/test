//---------------------------------------------------------------------------

#ifndef DerivedH
#define DerivedH
//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TBase
//---------------------------------------------------------------------------
class TBase
{
private:

   char Private;

protected:

   char Protected;

public:
   char TBaseChar;
   int TBaseInt;
   long TBaseLong;

   char Char;
   int Int;
   long Long;

   std::fstream Log;

   TBase(char aTBaseChar=0, int aTBaseInt=0, long aTBaseLong=0, char aChar=0, int aInt=0, long aLong=0);
   TBase(const TBase &aBase);
   virtual ~TBase(void);

   void Initialize(void);
   void CopyData(const TBase &aBase);

   virtual void Test(void);
   virtual void TestTest(void);
   void TestTestTest(void);

   virtual void Delete(void);
   void Clear(void);

   TBase & operator= (const TBase &aBase);
};
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TDerived1
//---------------------------------------------------------------------------
class TDerived1:public TBase
{
public:
//   __property char Protected;
   
   char TDerived1Char;
   int TDerived1Int;
   long TDerived1Long;

   TDerived1(char aTDerived1Char=0, int aTDerived1Int=0, long aTDerived1Long=0, char aTBaseChar=0, int aTBaseInt=0, long aTBaseLong=0, char aChar=0, int aInt=0, long aLong=0);
   TDerived1(const TDerived1 &aDerived1);
   virtual ~TDerived1(void);

   void Initialize(void);
   void CopyData(const TDerived1 &aDerived1);

   void Test(void);
   void TestTest(void);
   virtual void TestTestTest(void);
   virtual void TestTestTestTest(void);

   void Delete(void);

   TDerived1 & operator= (const TDerived1 &aDerived1);
};
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TDerived2
//---------------------------------------------------------------------------
class TDerived2:public TDerived1
{
public:
   char TDerived2Char;
   int TDerived2Int;
   long TDerived2Long;

   TDerived2(char aTDerived2Char=0, int aTDerived2Int=0, long aTDerived2Long=0, char aTDerived1Char=0, int aTDerived1Int=0, long aTDerived1Long=0, char aTBaseChar=0, int aTBaseInt=0, long aTBaseLong=0, char aChar=0, int aInt=0, long aLong=0);
   TDerived2(const TDerived2 &aDerived2);
   virtual ~TDerived2(void);

   void Initialize(void);
   void CopyData(const TDerived2 &aDerived2);

   void Test(void);
   void TestTest(void);
   void TestTestTest(void);
   void TestTestTestTest(void);

   void Delete(void);

   TDerived2 & operator= (const TDerived2 &aDerived2);
};
//---------------------------------------------------------------------------

#endif
