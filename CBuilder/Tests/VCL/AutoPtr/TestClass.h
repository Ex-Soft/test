//---------------------------------------------------------------------------

#ifndef TestClassH
#define TestClassH
//---------------------------------------------------------------------------

#include <vcl.h>
#include "TestClassII.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TTestClass
//---------------------------------------------------------------------------
class TTestClass
{
   AnsiString
     tmpAnsiString;

   void CopyData(const TTestClass &oTestClass);

public:
   static AnsiString
     StaticAnsiString;

   static int
     StaticInt;

   static TTestClassII
     StaticTestClassII;
     
   TTestClass(AnsiString aTmpAnsiString="");
   TTestClass(const TTestClass &oTestClass);
   virtual ~TTestClass(void);

   void SetStaticAnsiString(AnsiString Value);
   AnsiString GetStaticAnsiString(void);

   void SetNonStaticVariable(AnsiString Value);
   AnsiString GetNonStaticVariable(void);

   void SetStaticInt(int Value);
   int GetStaticInt(void);

   TTestClass & operator= (const TTestClass &oTestClass);
};
//---------------------------------------------------------------------------

#endif