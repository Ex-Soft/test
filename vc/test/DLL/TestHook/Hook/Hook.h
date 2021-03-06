#ifndef __HOOK_H__
#define __HOOK_H__

#ifdef _WINDLL
	#define DLL_EI __declspec(dllexport)
#else
	#define DLL_EI __declspec(dllimport)
#endif

// https://msdn.microsoft.com/en-us/library/d91k01sh.aspx
// https://msdn.microsoft.com/en-us/library/28d6s79h.aspx
extern "C" DLL_EI BOOL WINAPI SetHook(DWORD dwThreadId);

#endif
