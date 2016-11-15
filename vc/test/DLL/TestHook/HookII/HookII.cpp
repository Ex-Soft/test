#include <windows.h>
#include <assert.h>

#include "HookII.h"
#include "..\Hook\Log.h"

extern HINSTANCE g_hinstDll;
extern HHOOK g_hhook;
extern DWORD g_dwThreadIdDIPS;
extern HWND g_hWnd;
extern Log *_log;

LRESULT WINAPI GetMsgProc(int nCode, WPARAM wParam, LPARAM lParam);

BOOL WINAPI SetHook(DWORD dwThreadId, HWND hWnd) {

	g_hWnd = hWnd;

	BOOL fOk = FALSE;

	if (dwThreadId != 0) {
		// Make sure that the hook is not already installed.
		assert(g_hhook == NULL);

		// Save our thread ID in a shared variable so that our GetMsgProc 
		// function can post a message back to to thread when the server 
		// window has been created.
		g_dwThreadIdDIPS = GetCurrentThreadId();

		// Install the hook on the specified thread
		g_hhook = SetWindowsHookEx(/*WH_GETMESSAGE*/ WH_MOUSE, GetMsgProc, g_hinstDll, dwThreadId);

		fOk = (g_hhook != NULL);
		if (fOk) {
			// The hook was installed successfully; force a benign message to 
			// the thread's queue so that the hook function gets called.
			fOk = PostThreadMessage(dwThreadId, WM_NULL, 0, 0);
		}
	}
	else {

		// Make sure that a hook has been installed.
		assert(g_hhook != NULL);
		fOk = UnhookWindowsHookEx(g_hhook);
		g_hhook = NULL;
	}

	return(fOk);
}

LRESULT WINAPI GetMsgProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if (nCode < 0)
		return(CallNextHookEx(g_hhook, nCode, wParam, lParam));

	char buffer[255];
	std::string nCodeStr, wParamStr, lParamStr;

#pragma warning(disable:4996)
	sprintf(buffer, "%#x", nCode);
#pragma warning(default:4996)
	nCodeStr = buffer;

#pragma warning(disable:4996)
	sprintf(buffer, "%#x", wParam);
#pragma warning(default:4996)
	wParamStr = buffer;

#pragma warning(disable:4996)
	sprintf(buffer, "%#x", lParam);
#pragma warning(default:4996)
	lParamStr = buffer;

	switch (nCode)
	{
		case HC_ACTION:
		{
			nCodeStr = "HC_ACTION";

			switch (wParam)
			{
				case WM_MOUSEMOVE:
				{
					wParamStr = "WM_MOUSEMOVE";

					PMOUSEHOOKSTRUCT p = (PMOUSEHOOKSTRUCT)lParam;

#pragma warning(disable:4996)
					sprintf(buffer, "x = %d, y = %d, wHitTestCode = %#x, hwnd = %#x", p->pt.x, p->pt.y, p->wHitTestCode, p->hwnd);
#pragma warning(default:4996)
					lParamStr = buffer;

					break;
				}
				case WM_NCMOUSEMOVE:
				{
					wParamStr = "WM_NCMOUSEMOVE";

					PMOUSEHOOKSTRUCT p = (PMOUSEHOOKSTRUCT)lParam;

#pragma warning(disable:4996)
					sprintf(buffer, "x = %d, y = %d, wHitTestCode = %#x, hwnd = %#x", p->pt.x, p->pt.y, p->wHitTestCode, p->hwnd);
#pragma warning(default:4996)
					lParamStr = buffer;

					break;
				}
				case WM_NCLBUTTONDOWN: wParamStr = "WM_NCLBUTTONDOWN"; break;
				case WM_NCLBUTTONUP: wParamStr = "WM_NCLBUTTONUP"; break;
				case WM_NCLBUTTONDBLCLK:
				{
					wParamStr = "WM_NCLBUTTONDBLCLK";
					SendMessage(g_hWnd, WM_MSGCMD_SEND, 0, 0);
					break;
				}
				case WM_NCRBUTTONDOWN: wParamStr = "WM_NCRBUTTONDOWN"; break;
				case WM_NCRBUTTONUP: wParamStr = "WM_NCRBUTTONUP"; break;
				case WM_NCRBUTTONDBLCLK:
				{
					wParamStr = "WM_NCRBUTTONDBLCLK";
					SendMessage(g_hWnd, WM_MSGCMD_SEND, 0, 1);
					break;
				}
				case WM_NCMBUTTONDOWN: wParamStr = "WM_NCMBUTTONDOWN"; break;
				case WM_NCMBUTTONUP: wParamStr = "WM_NCMBUTTONUP"; break;
				case WM_NCMBUTTONDBLCLK: wParamStr = "WM_NCMBUTTONDBLCLK"; break;
				case WM_MOUSEWHEEL: wParamStr = "WM_MOUSEWHEEL"; break;
				case WM_RBUTTONDOWN: wParamStr = "WM_RBUTTONDOWN"; break;
				case WM_RBUTTONUP: wParamStr = "WM_RBUTTONUP"; break;
				case WM_RBUTTONDBLCLK:
				{
					wParamStr = "WM_RBUTTONDBLCLK";
					SendMessage(g_hWnd, WM_MSGCMD_SEND, 1, 0);
					break;
				}
				case WM_LBUTTONDOWN: wParamStr = "WM_LBUTTONDOWN"; break;
				case WM_LBUTTONUP: wParamStr = "WM_LBUTTONUP"; break;
				case WM_LBUTTONDBLCLK:
				{
					wParamStr = "WM_LBUTTONDBLCLK";
					SendMessage(g_hWnd, WM_MSGCMD_SEND, 1, 1);
					break;
				}
			}

			break;
		}
	}

#pragma warning(disable:4996)
	sprintf(buffer, "nCode = %s, wParam = %s, lParam = %s", nCodeStr.c_str(), wParamStr.c_str(), lParamStr.c_str());
#pragma warning(default:4996)

	_log->Write(buffer);

	/*
	static BOOL fFirstTime = TRUE;

	if (fFirstTime) {
	// The DLL just got injected.
	fFirstTime = FALSE;

	// Uncomment the line below to invoke the debugger
	// on the process that just got the injected DLL.
	// ForceDebugBreak();

	// Create the DTIS Server window to handle the client request.
	//CreateDialog(g_hinstDll, MAKEINTRESOURCE(IDD_DIPS), NULL, Dlg_Proc);

	// Tell the DIPS application that the server is up
	// and ready to handle requests.
	PostThreadMessage(g_dwThreadIdDIPS, WM_NULL, 0, 0);
	}
	*/

	return(CallNextHookEx(g_hhook, nCode, wParam, lParam));
}
