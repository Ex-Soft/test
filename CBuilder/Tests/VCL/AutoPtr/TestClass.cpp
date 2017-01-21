//---------------------------------------------------------------------------

#include "TestClass.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TTestClass
//---------------------------------------------------------------------------

//------------------------------------------------------------------------------
AnsiString
  TTestClass::StaticAnsiString;

int
  TTestClass::StaticInt;

TTestClassII
  TTestClass::StaticTestClassII;
//------------------------------------------------------------------------------

TTestClass::TTestClass(AnsiString aTmpAnsiString)
{
   tmpAnsiString=aTmpAnsiString;
}
//---------------------------------------------------------------------------

TTestClass::TTestClass(const TTestClass &oTestClass)
{
   CopyData(oTestClass);
}
//---------------------------------------------------------------------------

TTestClass::~TTestClass(void)
{
}
//---------------------------------------------------------------------------

void TTestClass::CopyData(const TTestClass &oTestClass)
{
   tmpAnsiString=oTestClass.tmpAnsiString;
}
//---------------------------------------------------------------------------

void TTestClass::SetStaticAnsiString(AnsiString Value)
{
   if(StaticAnsiString!=Value)
     StaticAnsiString=Value;
}
//---------------------------------------------------------------------------

AnsiString TTestClass::GetStaticAnsiString(void)
{
   return(StaticAnsiString);
}
//---------------------------------------------------------------------------

void TTestClass::SetNonStaticVariable(AnsiString Value)
{
   if(tmpAnsiString!=Value)
     tmpAnsiString=Value;
}
//---------------------------------------------------------------------------

AnsiString TTestClass::GetNonStaticVariable(void)
{
   return(tmpAnsiString);
}
//---------------------------------------------------------------------------

void TTestClass::SetStaticInt(int Value)
{
   if(StaticInt!=Value)
     StaticInt=Value;
}
//---------------------------------------------------------------------------

int TTestClass::GetStaticInt(void)
{
   return(StaticInt);
}
//---------------------------------------------------------------------------

TTestClass & TTestClass::operator= (const TTestClass &oTestClass)
{
   if(this!=&oTestClass)
     CopyData(oTestClass);

   return(*this);
}
//---------------------------------------------------------------------------


