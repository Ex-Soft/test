//---------------------------------------------------------------------------

#include "Exeption.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TExeption
//---------------------------------------------------------------------------
TExeption::TExeption(void)
{
   try
     {
        Initialize();
     }
   catch(Exception &eException)
     {
        if(Buff)
          delete []Buff;
        Buff=0;

        throw Exception(eException.Message);  
     }
}
//---------------------------------------------------------------------------

TExeption::TExeption(const TExeption &aExeption)
{
   Initialize();
   CopyData(aExeption);
}
//---------------------------------------------------------------------------

TExeption::~TExeption(void)
{
   if(Buff)
     delete []Buff;
}
//---------------------------------------------------------------------------

void TExeption::Initialize(void)
{
   Buff=0;
   BuffSize=0x0ffff;

   while(!Buff&&BuffSize)
     {
        Buff=new char [BuffSize];
        if(!Buff)
          BuffSize>>=1;
     }
   if(!Buff&&!BuffSize)
     throw Exception("Insufficient memory");

   throw Exception("Exception");
}
//---------------------------------------------------------------------------

void TExeption::CopyData(const TExeption &aExeption)
{
}
//---------------------------------------------------------------------------

TExeption & TExeption::operator= (const TExeption &aExeption)
{
   if(this!=&aExeption)
     CopyData(aExeption);
   return(*this);
}
//---------------------------------------------------------------------------

