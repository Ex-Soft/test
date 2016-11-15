#include "stdafx.h"

DllWrapper::DllWrapper(void)
{
	dllInstance = NULL;
	ptrHook = NULL;
	hWnd = NULL;

	szWindowClass = _T("TestWin32API"),
	szTitle = _T("Test Win32 API");

	WM_NCLBUTTONDBLCLK_COUNT = WM_NCRBUTTONDBLCLK_COUNT = WM_RBUTTONDBLCLK_COUNT = WM_LBUTTONDBLCLK_COUNT = 0;
}

DllWrapper::~DllWrapper()
{
	if (ptrHook)
		ptrHook(0, 0);

	if (hWnd)
		DestroyWindow(hWnd);

	if (dllInstance)
		FreeLibrary(dllInstance);
}

void DllWrapper::Init(void)
{
	if (!(dllInstance = LoadLibrary(TEXT("HookII.dll"))))
	{
		HLOCAL hLocal = NULL;
		DWORD dwError = GetLastError();

		if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL, dwError, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPTSTR)&hLocal, 0, NULL) && hLocal)
		{
			PCTSTR message = (PCTSTR)LocalLock(hLocal);
			LocalFree(hLocal);
		}

		return;
	}

	if (!(ptrHook = (hookWithWndProc *)GetProcAddress(dllInstance, "SetHook")))
		return;

	if (!Register(dllInstance))
		return;

	if (!InitInstance(dllInstance, /*SW_HIDE*/ SW_SHOWNORMAL ))
		return;

	ptrHook(GetCurrentThreadId(), hWnd);
}

BOOL DllWrapper::Register(HINSTANCE hInstance)
{
	WNDCLASS wc;

	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = static_cast<WNDPROC>(WndProc);
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_ASTERISK);
	wc.hCursor = LoadCursor(NULL, IDC_CROSS);
	wc.hbrBackground = reinterpret_cast<HBRUSH>(COLOR_WINDOW + 1);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = szWindowClass;

	return RegisterClass(&wc);
}

BOOL DllWrapper::InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND hWnd;

	hWnd = CreateWindow(
		szWindowClass,
		szTitle,
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		NULL,
		NULL,
		hInstance,
		this);

	if (!hWnd)
		return FALSE;

	if (ShowWindow(hWnd, nCmdShow))
		return FALSE;

	if (!UpdateWindow(hWnd))
		return FALSE;

	return TRUE;
}

LRESULT CALLBACK DllWrapper::WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	DllWrapper *self;

	if (message == WM_NCCREATE)
	{
		LPCREATESTRUCT lpcs = reinterpret_cast<LPCREATESTRUCT>(lParam);
		self = reinterpret_cast<DllWrapper *>(lpcs->lpCreateParams);
		self->hWnd = hwnd;
		SetWindowLongPtr(hwnd, GWLP_USERDATA, reinterpret_cast<LPARAM>(self));
	}
	else
	{
		self = reinterpret_cast<DllWrapper *>(GetWindowLongPtr(hwnd, GWLP_USERDATA));
	}

	if (self)
	{
		return self->HandleMessage(message, wParam, lParam);
	}
	else
	{
		return DefWindowProc(hwnd, message, wParam, lParam);
	}
}

LRESULT DllWrapper::HandleMessage(UINT message, WPARAM wParam, LPARAM lParam)
{
	LRESULT lres;

	switch (message)
	{
		case WM_NCDESTROY:
		{
			lres = DefWindowProc(hWnd, message, wParam, lParam);
			SetWindowLongPtr(hWnd, GWLP_USERDATA, 0);
			//delete this;
			return lres;
		}
		case WM_DESTROY:
		{
			PostQuitMessage(0);
			break;
		}
		case WM_MSGCMD_SEND:
		{
			if (!wParam && !lParam)
				++WM_NCLBUTTONDBLCLK_COUNT;
			else if (!wParam && lParam)
				++WM_NCRBUTTONDBLCLK_COUNT;
			else if (wParam && !lParam)
				++WM_RBUTTONDBLCLK_COUNT;
			else if (wParam && lParam)
				++WM_LBUTTONDBLCLK_COUNT;

			break;
		}
	}

	return DefWindowProc(hWnd, message, wParam, lParam);
}
