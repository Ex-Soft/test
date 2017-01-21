//---------------------------------------------------------------------------

#include "TestClass.h"
//---------------------------------------------------------------------------

TBase::TBase(int aBaseInt)
{
   TBaseInt=aBaseInt;
}
//---------------------------------------------------------------------------

TBase::TBase(const TBase &aBase)
{
   TBaseInt=aBase.TBaseInt;
}
//---------------------------------------------------------------------------

int TBase::GetTBaseStaticConstInt(void)
{
   return(TBaseStaticConstInt);
}
//---------------------------------------------------------------------------

TBase & TBase::operator= (const TBase &aBase)
{
   if(this!=&aBase)
     TBaseInt=aBase.TBaseInt;
     
   return(*this);
}
//---------------------------------------------------------------------------

