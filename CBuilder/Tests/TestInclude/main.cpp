//---------------------------------------------------------------------------

//#include <stdlib.h>
#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------

#ifdef __cplusplus
  #pragma message("__cplusplus")
#else
  #pragma message("!__cplusplus")
#endif

#ifdef __STDC__
  #pragma message("__STDC__")
#else
  #pragma message("!__STDC__")
#endif

#ifdef __MFC_COMPAT__
  #pragma message("__MFC_COMPAT__")
#else
  #pragma message("!__MFC_COMPAT__")
#endif

#ifdef __MINMAX_DEFINED
  #pragma message("__MINMAX_DEFINED")
#else
  #pragma message("!__MINMAX_DEFINED")
#endif

#ifdef _USE_OLD_RW_STL
  #pragma message("_USE_OLD_RW_STL")
#else
  #pragma message("!_USE_OLD_RW_STL")
#endif

#ifdef NOMINMAX
  #pragma message("NOMINMAX")
#else
  #pragma message("!NOMINMAX")
#endif

#ifdef __max
  #pragma message("__max")
#else
  #pragma message("!__max")
#endif

#ifdef max
  #pragma message("max")
#else
  #pragma message("!max")
#endif

using namespace std;

#pragma argsused
int main(int argc, char* argv[])
{
   int
     i=max(5,10);

   cout<<i<<endl;
   
   return 0;
}
//---------------------------------------------------------------------------
 