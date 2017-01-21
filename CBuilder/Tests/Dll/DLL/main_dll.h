#ifndef main_dllH
#define main_dllH

  #if defined(__DLL__)
     #define DLL_EI __declspec(dllexport)
  #else
     #define DLL_EI __declspec(dllimport)
  #endif

  extern "C" void DLL_EI WINAPI ShowDynamicTestForm(HWND Parent,AnsiString ShowString="");
  extern "C" void DLL_EI WINAPI ShowStaticTestForm(HWND Parent, AnsiString ShowString="");

#endif
