#ifndef TestingH
#define TestingH

#if defined(__DLL__)
   #define DLL_EI __declspec(dllexport)
#else
   #define DLL_EI __declspec(dllimport)
#endif

extern "C" void DLL_EI VoidFunction(void);

#endif

