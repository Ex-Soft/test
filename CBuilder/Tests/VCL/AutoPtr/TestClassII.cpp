//---------------------------------------------------------------------------

#include "TestClassII.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TTestClassII
//---------------------------------------------------------------------------

TTestClassII::TTestClassII(int aTmpInt)
{
   tmpInt=aTmpInt;
}
//---------------------------------------------------------------------------

TTestClassII::TTestClassII(const TTestClassII &oTestClassII)
{
   CopyData(oTestClassII);
}
//---------------------------------------------------------------------------

TTestClassII::~TTestClassII(void)
{
}
//---------------------------------------------------------------------------

void TTestClassII::CopyData(const TTestClassII &oTestClassII)
{
   tmpInt=oTestClassII.tmpInt;
}
//---------------------------------------------------------------------------

void TTestClassII::SetNonStaticVariable(int Value)
{
   if(tmpInt!=Value)
     tmpInt=Value;
}
//---------------------------------------------------------------------------

int TTestClassII::GetNonStaticVariable(void)
{
   return(tmpInt);
}
//---------------------------------------------------------------------------

TTestClassII & TTestClassII::operator= (const TTestClassII &oTestClassII)
{
   if(this!=&oTestClassII)
     CopyData(oTestClassII);

   return(*this);
}
//---------------------------------------------------------------------------


