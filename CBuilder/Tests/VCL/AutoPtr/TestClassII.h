//---------------------------------------------------------------------------

#ifndef TestClassIIH
#define TestClassIIH
//---------------------------------------------------------------------------

#include <vcl.h>
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TTestClassII
//---------------------------------------------------------------------------
class TTestClassII
{
   int
     tmpInt;

   void CopyData(const TTestClassII &oTestClassII);

public:
   TTestClassII(int aTmpInt=999);
   TTestClassII(const TTestClassII &oTestClassII);
   virtual ~TTestClassII(void);

   void SetNonStaticVariable(int Value);
   int GetNonStaticVariable(void);

   TTestClassII & operator= (const TTestClassII &oTestClassII);
};
//---------------------------------------------------------------------------

#endif