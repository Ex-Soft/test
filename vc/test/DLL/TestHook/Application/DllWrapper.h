#ifndef __DLL_WRAPPER_H__
#define __DLL_WRAPPER_H__

#define WM_MSGCMD_SEND (WM_USER+6)

typedef BOOL WINAPI hookWithWndProc(DWORD, HWND);

class DllWrapper
{
	HINSTANCE dllInstance;
	hookWithWndProc *ptrHook;
	HWND hWnd;

	LPCWSTR
		szWindowClass,
		szTitle;

	int
		WM_NCLBUTTONDBLCLK_COUNT,
		WM_NCRBUTTONDBLCLK_COUNT,
		WM_RBUTTONDBLCLK_COUNT,
		WM_LBUTTONDBLCLK_COUNT;

	BOOL Register(HINSTANCE hInstance);
	BOOL InitInstance(HINSTANCE hInstance, int nCmdShow);
	static LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);
	LRESULT HandleMessage(UINT message, WPARAM wParam, LPARAM lParam);
public:
	DllWrapper(void);
	~DllWrapper();

	void Init(void);
};


#endif
