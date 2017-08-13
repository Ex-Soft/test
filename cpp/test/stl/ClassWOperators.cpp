#include <iostream>
#include "ClassWOperators.h"

//---------------------------------------------------------------------------
// ClassWOperators
//---------------------------------------------------------------------------
ClassWOperators::ClassWOperators(int aX)
{
   X=aX;
   std::cout<<"ClassWOperators::ClassWOperators(int aX)"<<std::endl;
}
//---------------------------------------------------------------------------

ClassWOperators::ClassWOperators(const ClassWOperators &aClassWOperators)
{
   X=aClassWOperators.X;
   std::cout<<"ClassWOperators::ClassWOperators(const ClassWOperators &aClassWOperators)"<<std::endl;
}
//---------------------------------------------------------------------------

ClassWOperators::~ClassWOperators(void)
{
   std::cout<<"ClassWOperators::~ClassWOperators(void)"<<std::endl;
}
//---------------------------------------------------------------------------

bool operator < (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(aClassWOperatorsL.X<aClassWOperatorsR.X);
}
//---------------------------------------------------------------------------

bool operator > (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(aClassWOperatorsL.X>aClassWOperatorsR.X);
}
//---------------------------------------------------------------------------

