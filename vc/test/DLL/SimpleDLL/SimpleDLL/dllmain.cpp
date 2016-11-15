#include <windows.h>
#include "Log.h"

#pragma data_seg("Shared")
HHOOK g_hhook = NULL;
DWORD g_dwThreadIdDIPS = 0;
HWND g_hWnd = NULL;
#pragma data_seg()

#pragma comment(linker, "/section:Shared,rws")

HINSTANCE g_hinstDll = NULL;

Log *_log;

BOOL WINAPI DllMain(HINSTANCE hinstDll, DWORD fdwReason, PVOID fImpLoad)
{
	switch (fdwReason)
	{
		case DLL_PROCESS_ATTACH:
		{
			g_hinstDll = hinstDll;

			_log = new Log("DllMain");

			TCHAR buffer[MAX_PATH];
			GetModuleFileName(hinstDll, buffer, MAX_PATH);
			std::string moduleFileName;

			#ifndef UNICODE
				moduleFileName = buffer;
			#else
				std::wstring wStr = buffer;
				moduleFileName = std::string(wStr.begin(), wStr.end());
			#endif

			moduleFileName += " DLL_PROCESS_ATTACH";

			_log->Write(moduleFileName);

			break;
		}
		case DLL_THREAD_ATTACH:
		{
			if (_log)
				_log->Write("DLL_THREAD_ATTACH");

			break;
		}
		case DLL_THREAD_DETACH:
		{
			if (_log)
				_log->Write("DLL_THREAD_DETACH");

			break;
		}
		case DLL_PROCESS_DETACH:
		{
			if (_log)
			{
				_log->Write("DLL_PROCESS_DETACH");
				delete _log;
			}

			break;
		}
	}

	return TRUE;
}
