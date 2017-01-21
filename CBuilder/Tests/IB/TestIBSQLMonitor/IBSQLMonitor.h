#ifndef IBSQLMonitorH
#define IBSQLMonitorH

#if defined(__DLL__)
   #define DLL_EI __declspec(dllexport)
#else
   #define DLL_EI __declspec(dllimport)
#endif

extern "C" void DLL_EI __stdcall IBSQLMonitorEnabled(void);
extern "C" void DLL_EI __stdcall IBSQLMonitorDisabled(void);

#endif

