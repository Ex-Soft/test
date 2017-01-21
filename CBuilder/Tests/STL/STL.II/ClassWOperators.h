//---------------------------------------------------------------------------

#ifndef ClassWOperatorsH
#define ClassWOperatorsH
//---------------------------------------------------------------------------

class ClassWOperators
{
public:
  int
    X;

   ClassWOperators(int aX=0);
   ClassWOperators(const ClassWOperators &aClassWOperators);
   virtual ~ClassWOperators(void);

   friend bool operator < (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
   friend bool operator > (const ClassWOperators &aClassWOperatorsL, const ClassWOperators &aClassWOperatorsR);
};
//---------------------------------------------------------------------------
#endif
