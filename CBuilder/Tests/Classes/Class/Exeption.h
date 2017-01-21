//---------------------------------------------------------------------------

#ifndef ExeptionH
#define ExeptionH
//---------------------------------------------------------------------------

#include <vcl.h>
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TExeption
//---------------------------------------------------------------------------
class TExeption
{
public:
   char *Buff;
   unsigned int BuffSize;

   TExeption(void);
   TExeption(const TExeption &aExeption);
   ~TExeption(void);

   void Initialize(void);
   void CopyData(const TExeption &aExeption);

   TExeption & operator= (const TExeption &aExeption);
};
//---------------------------------------------------------------------------

#endif
