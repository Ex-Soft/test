#include "stdafx.h"

DllCaller::DllCaller(void)
{
	dllInstance = NULL;
	ptrSayHelloFunc = NULL;
	ptrSetHookFunc = NULL;
	hWnd = NULL;

	szWindowClass = _T("TestElectron");
	szTitle = _T("TestElectron");

	WM_NCLBUTTONDBLCLK_COUNT = WM_NCRBUTTONDBLCLK_COUNT = WM_RBUTTONDBLCLK_COUNT = WM_LBUTTONDBLCLK_COUNT = 0;
}

DllCaller::~DllCaller()
{
	if (ptrSetHookFunc)
		ptrSetHookFunc(0, 0);

	if (hWnd)
		DestroyWindow(hWnd);

	if (dllInstance)
		FreeLibrary(dllInstance);

	if (_log)
		delete _log;
}

void DllCaller::Init(void)
{
	_log = new Log();

	if (!(dllInstance = LoadLibrary(TEXT("SimpleDLL.dll"))))
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

	ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");

	if (!(ptrSetHookFunc = (tSetHookFunc *)GetProcAddress(dllInstance, "SetHook")))
		return;

	HMODULE moduleHandle = GetModuleHandle(NULL);

	if (!Register(moduleHandle))
		return;

	if (!InitInstance(moduleHandle, /*SW_HIDE*/ SW_SHOWNORMAL))
		return;

	ptrSetHookFunc(GetCurrentThreadId(), hWnd);
}

void DllCaller::SayHello(void)
{
	if (ptrSayHelloFunc)
		ptrSayHelloFunc();
}

BOOL DllCaller::Register(HINSTANCE hInstance)
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

BOOL DllCaller::InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND hWnd = CreateWindow(
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

LRESULT CALLBACK DllCaller::WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	DllCaller *self;

	if (message == WM_NCCREATE)
	{
		LPCREATESTRUCT lpcs = reinterpret_cast<LPCREATESTRUCT>(lParam);
		self = reinterpret_cast<DllCaller *>(lpcs->lpCreateParams);
		self->hWnd = hwnd;
		SetWindowLongPtr(hwnd, GWLP_USERDATA, reinterpret_cast<LPARAM>(self));
	}
	else
	{
		self = reinterpret_cast<DllCaller *>(GetWindowLongPtr(hwnd, GWLP_USERDATA));
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

LRESULT DllCaller::HandleMessage(UINT message, WPARAM wParam, LPARAM lParam)
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

int DllCaller::GetNCLButtonDblClk(void)
{
	char buffer[256];

#pragma warning(disable:4996)
	_log->Write(std::string("WM_NCLBUTTONDBLCLK_COUNT") + std::string(itoa(WM_NCLBUTTONDBLCLK_COUNT, buffer, 10)));
#pragma warning(default:4996)

	return WM_NCLBUTTONDBLCLK_COUNT;
}

int DllCaller::GetNCRButtonDblClk(void)
{
	char buffer[256];

#pragma warning(disable:4996)
	_log->Write(std::string("WM_NCRBUTTONDBLCLK_COUNT") + std::string(itoa(WM_NCRBUTTONDBLCLK_COUNT, buffer, 10)));
#pragma warning(default:4996)

	return WM_NCRBUTTONDBLCLK_COUNT;
}

int DllCaller::GetRButtonDblClk(void)
{
	char buffer[256];

#pragma warning(disable:4996)
	_log->Write(std::string("WM_RBUTTONDBLCLK_COUNT") + std::string(itoa(WM_RBUTTONDBLCLK_COUNT, buffer, 10)));
#pragma warning(default:4996)

	return WM_RBUTTONDBLCLK_COUNT;
}

int DllCaller::GetLButtonDblClk(void)
{
	char buffer[256];

#pragma warning(disable:4996)
	_log->Write(std::string("WM_LBUTTONDBLCLK_COUNT") + std::string(itoa(WM_LBUTTONDBLCLK_COUNT, buffer, 10)));
#pragma warning(default:4996)

	return WM_LBUTTONDBLCLK_COUNT;
}
