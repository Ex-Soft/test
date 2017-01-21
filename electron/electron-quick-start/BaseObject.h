#ifndef __BASEOBJECT_H__
#define __BASEOBJECT_H__

#include <Windows.h>
#include "Log.h"

#define WM_MSGCMD_SEND (WM_USER+6)
#define WM_MSGCMD_POST (WM_USER+12)

typedef void WINAPI tSayHelloFunc(void);
typedef BOOL WINAPI tSetHookFunc(DWORD, HWND);

class BaseObject
{
  HINSTANCE dllInstance;
  tSayHelloFunc *ptrSayHelloFunc;
	tSetHookFunc *ptrSetHookFunc;
	HWND hWnd;
	HMODULE moduleHandle;

	LPCWSTR
		szWindowClass,
		szTitle;

	int
		WM_NCLBUTTONDBLCLK_COUNT,
		WM_NCRBUTTONDBLCLK_COUNT,
		WM_RBUTTONDBLCLK_COUNT,
    WM_LBUTTONDBLCLK_COUNT;

  Log *_log;

	BOOL Register(HINSTANCE hInstance);
	BOOL InitInstance(HINSTANCE hInstance, int nCmdShow);
	static LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);
	LRESULT HandleMessage(UINT message, WPARAM wParam, LPARAM lParam);

public:
  BaseObject();
  BaseObject(const BaseObject &obj);
  virtual ~BaseObject(void);

	void Init(void);
  void SayHello(void);

  int GetNCLButtonDblClk(void);
  int GetNCRButtonDblClk(void);
  int GetRButtonDblClk(void);
  int GetLButtonDblClk(void);
};

#endif
