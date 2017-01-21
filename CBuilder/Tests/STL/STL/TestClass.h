//---------------------------------------------------------------------------

#ifndef TestClassH
#define TestClassH
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TBase
//---------------------------------------------------------------------------
class TBase
{
protected:
  static const int TBaseStaticConstInt=1;

public:
  int TBaseInt;

  TBase(int aBaseInt=0);
  TBase(const TBase &aBase);

  int GetTBaseStaticConstInt(void);

  TBase & operator= (const TBase &aBase);
};
//---------------------------------------------------------------------------
#endif