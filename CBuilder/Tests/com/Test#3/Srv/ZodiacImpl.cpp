// ZODIACIMPL : Implementation of TZodiacImpl (CoClass: Zodiac, Interface: IZodiac)

#include <vcl.h>
#pragma hdrstop

#include "ZODIACIMPL.H"

/////////////////////////////////////////////////////////////////////////////
// TZodiacImpl

static TCOMCriticalSection CS;

STDMETHODIMP TZodiacImpl::GetZodiacSign(long Day, long Month, BSTR* Sign)
{
   TCOMCriticalSection::Lock Lock(CS);

   ::GetZodiakSign(Day, Month, *Sign);

   return S_OK;
}

STDMETHODIMP TZodiacImpl::GetZodiacSignAsync(long Day, long Month)
{ 

}

 