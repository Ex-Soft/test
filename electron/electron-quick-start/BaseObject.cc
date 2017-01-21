#define _UNICODE
#define UNICODE

#include <tchar.h>
#include "BaseObject.h"

BaseObject::BaseObject()
{
  dllInstance = NULL;
	ptrSayHelloFunc = NULL;
	ptrSetHookFunc = NULL;
	hWnd = NULL;
	moduleHandle = NULL;

	szWindowClass = _T("TestElectron");
	szTitle = _T("TestElectron");

	WM_NCLBUTTONDBLCLK_COUNT = WM_NCRBUTTONDBLCLK_COUNT = WM_RBUTTONDBLCLK_COUNT = WM_LBUTTONDBLCLK_COUNT = 0;

  _log = new Log();
  _log->Write("BaseObject::BaseObject()");

  TCHAR buffer[MAX_PATH];
	GetModuleFileName(NULL, buffer, MAX_PATH);
	std::string moduleFileName;

	#ifndef UNICODE
	  moduleFileName = buffer;
	#else
		std::wstring wStr = buffer;
		moduleFileName = std::string(wStr.begin(), wStr.end());
	#endif

	_log->Write(moduleFileName);

/*
  if (dllInstance = LoadLibrary(TEXT("SimpleDLL.dll")))
  {
      _log->Write("dll has been loaded");

      ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");
  }
  else
  {
    HLOCAL hLocal = NULL;
    DWORD dwError = GetLastError();
    char b[10];
    itoa(dwError, b, 10);
    _log->Write(b);

    BOOL fOk = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL, dwError, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPTSTR)&hLocal, 0, NULL);

 		if (fOk)
		{
      if(hLocal)
      {
			PCTSTR message = (PCTSTR)LocalLock(hLocal);
      _log->Write(message);
			LocalFree(hLocal);
      }
		}
    else
    {
      dwError = GetLastError();
      itoa(dwError, b, 10);
      std::string m = "!fOk ";
      m += b;
      _log->Write(m);
    }
  }
*/
}

BaseObject::BaseObject(const BaseObject &obj)
{
  _log = new Log();
  _log->Write("BaseObject::BaseObject(const BaseObject &obj)");

/*
  if (dllInstance = LoadLibrary(TEXT("SimpleDLL.dll")))
  {
    _log->Write("dll has been loaded");
    ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");
  }
  else
    _log->Write("dll has not been loaded");
*/
}

BaseObject::~BaseObject(void)
{
  if (ptrSetHookFunc)
		ptrSetHookFunc(0, 0);

	if (hWnd)
		DestroyWindow(hWnd);

  if (dllInstance)
		FreeLibrary(dllInstance);

  if(_log)
  {
    _log->Write("BaseObject::~BaseObject()");
    delete _log;
  }
}

void BaseObject::Init(void)
{
	_log->Write("BaseObject::Init()");

  if (dllInstance = LoadLibrary(TEXT("SimpleDLL.dll")))
  {
      _log->Write("dll has been loaded");

      ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");

      if (!(ptrSetHookFunc = (tSetHookFunc *)GetProcAddress(dllInstance, "SetHook")))
		    return;

			moduleHandle = GetModuleHandle(NULL);

	    if (!Register(moduleHandle))
		    return;

	    if (!InitInstance(moduleHandle, SW_HIDE /*SW_SHOWNORMAL*/))
		    return;

	    ptrSetHookFunc(GetCurrentThreadId(), hWnd);
  }
  else
  {
    HLOCAL hLocal = NULL;
    DWORD dwError = GetLastError();
    char b[10];
    itoa(dwError, b, 10);
    _log->Write(b);

    BOOL fOk = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL, dwError, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPTSTR)&hLocal, 0, NULL);

 		if (fOk)
		{
      if(hLocal)
      {
			PCTSTR message = (PCTSTR)LocalLock(hLocal);
      _log->Write((char *)message);
			LocalFree(hLocal);
      }
		}
    else
    {
      dwError = GetLastError();
      itoa(dwError, b, 10);
      std::string m = "!fOk ";
      m += b;
      _log->Write(m);
    }
  }

}

void BaseObject::SayHello(void)
{
  if (ptrSayHelloFunc)
    ptrSayHelloFunc();
}

BOOL BaseObject::Register(HINSTANCE hInstance)
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

BOOL BaseObject::InitInstance(HINSTANCE hInstance, int nCmdShow)
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
/*
	if (ShowWindow(hWnd, nCmdShow))
		return FALSE;

	if (!UpdateWindow(hWnd))
		return FALSE;
*/
	return TRUE;
}

LRESULT CALLBACK BaseObject::WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	BaseObject *self;

	if (message == WM_NCCREATE)
	{
		LPCREATESTRUCT lpcs = reinterpret_cast<LPCREATESTRUCT>(lParam);
		self = reinterpret_cast<BaseObject *>(lpcs->lpCreateParams);
		self->hWnd = hwnd;
		SetWindowLongPtr(hwnd, GWLP_USERDATA, reinterpret_cast<LPARAM>(self));
	}
	else
	{
		self = reinterpret_cast<BaseObject *>(GetWindowLongPtr(hwnd, GWLP_USERDATA));
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

LRESULT BaseObject::HandleMessage(UINT message, WPARAM wParam, LPARAM lParam)
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

int BaseObject::GetNCLButtonDblClk(void)
{
  return WM_NCLBUTTONDBLCLK_COUNT;
}

int BaseObject::GetNCRButtonDblClk(void)
{
  return WM_NCRBUTTONDBLCLK_COUNT;
}

int BaseObject::GetRButtonDblClk(void)
{
  return WM_RBUTTONDBLCLK_COUNT;
}

int BaseObject::GetLButtonDblClk(void)
{
  return WM_LBUTTONDBLCLK_COUNT;
}
