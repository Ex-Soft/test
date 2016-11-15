#include <windows.h>
#include "Log.h"

// Instruct the compiler to put the g_hhook data variable in 
// its own data section called Shared. We then instruct the 
// linker that we want to share the data in this section 
// with all instances of this application.
#pragma data_seg("Shared")
HHOOK g_hhook = NULL;
DWORD g_dwThreadIdDIPS = 0;
#pragma data_seg()

// Instruct the linker to make the Shared section
// readable, writable, and shared.
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
			_log = new Log();
			break;
		}
		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
			break;
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
