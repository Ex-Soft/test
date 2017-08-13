#include "classwoperators.h"

using namespace std;

//---------------------------------------------------------------------------
// ClassWOperators
//---------------------------------------------------------------------------
ClassWOperators::ClassWOperators(int aX, int aY)
{
   X=aX;
   Y=aY;
}
//---------------------------------------------------------------------------

ClassWOperators::ClassWOperators(const ClassWOperators &aClassWOperators)
{
   X=aClassWOperators.X;
   Y=aClassWOperators.Y;
}
//---------------------------------------------------------------------------

ClassWOperators::~ClassWOperators(void)
{
}
//---------------------------------------------------------------------------

ClassWOperators & ClassWOperators::operator = (const ClassWOperators &aClassWOperators)
{
   if(this!=&aClassWOperators)
   {
      X=aClassWOperators.X;
      Y=aClassWOperators.Y;
   }
   return(*this);
}
//---------------------------------------------------------------------------

ClassWOperators::operator int () const
{
   return(X+Y);
}

ClassWOperators::operator double () const
{
   return(double(X)+Y);
}

ClassWOperators operator + (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   /*
   ClassWOperators
     tmpClassWOperators(aClassWOperatorsL.X+aClassWOperatorsR.X,aClassWOperatorsL.Y+aClassWOperatorsR.Y);

   return(tmpClassWOperators);
   */

   return(ClassWOperators(aClassWOperatorsL.X+aClassWOperatorsR.X,aClassWOperatorsL.Y+aClassWOperatorsR.Y));
}
//---------------------------------------------------------------------------

ClassWOperators operator - (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(ClassWOperators(aClassWOperatorsL.X-aClassWOperatorsR.X,aClassWOperatorsL.Y-aClassWOperatorsR.Y));
}
//---------------------------------------------------------------------------

ClassWOperators operator * (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(ClassWOperators(aClassWOperatorsL.X*aClassWOperatorsR.X,aClassWOperatorsL.Y*aClassWOperatorsR.Y));
}
//---------------------------------------------------------------------------

ClassWOperators operator / (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(ClassWOperators(aClassWOperatorsL.X/aClassWOperatorsR.X,aClassWOperatorsL.Y/aClassWOperatorsR.Y));
}
//---------------------------------------------------------------------------

bool operator == (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(aClassWOperatorsL.X==aClassWOperatorsR.X && aClassWOperatorsL.Y==aClassWOperatorsR.Y);
}
//---------------------------------------------------------------------------

bool operator != (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR)
{
   return(!(aClassWOperatorsL==aClassWOperatorsR));
}
//---------------------------------------------------------------------------

ostream& operator << (ostream& os, const ClassWOperators &aA)
{
    os<<"{ x: "<<aA.X<<", y: "<<aA.Y<<" }";

    return os;
}
//---------------------------------------------------------------------------

