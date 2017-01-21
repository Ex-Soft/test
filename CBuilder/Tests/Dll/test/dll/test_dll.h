#if !defined(__TEST_DLL_H)
  #define __TEST_DLL_H

  #if defined(__BUILD__DLL__)
     #define DLL_EI __declspec(dllexport)
  #else
     #define DLL_EI __declspec(dllimport)
  #endif

  extern "C" void DLL_EI test_prn(void);
  extern "C" void DLL_EI test_mail(void);
#endif