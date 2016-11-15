#ifndef __SIMPLEDLL_H__
#define __SIMPLEDLL_H__

#ifdef _WINDLL
	#define DLL_EI __declspec(dllexport)
#else
	#define DLL_EI __declspec(dllimport)
#endif

#include <Windows.h>

#define WM_MSGCMD_SEND (WM_USER+6)
#define WM_MSGCMD_POST (WM_USER+12)

extern "C" DLL_EI void WINAPI SayHello(void);
extern "C" DLL_EI BOOL WINAPI SetHook(DWORD dwThreadId, HWND hWnd);

#endif
