//---------------------------------------------------------------------------

#ifndef ClassWOperatorsH
#define ClassWOperatorsH
//---------------------------------------------------------------------------

#include <iostream>

class ClassWOperators
{
public:
  int
    X,
    Y;

   ClassWOperators(int aX=0, int aY=0);
   ClassWOperators(const ClassWOperators &aClassWOperators);
   virtual ~ClassWOperators(void);

   ClassWOperators & operator = (const ClassWOperators &aClassWOperators);

   operator int () const;
   operator double () const;

   friend ClassWOperators operator + (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend ClassWOperators operator - (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend ClassWOperators operator * (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend ClassWOperators operator / (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend bool operator == (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend bool operator != (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);

   friend std::ostream& operator << (std::ostream& os, const ClassWOperators&);
};
//---------------------------------------------------------------------------

#endif
