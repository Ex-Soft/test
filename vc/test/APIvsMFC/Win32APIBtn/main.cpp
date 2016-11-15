#include "stdafx.h"

LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);
BOOL InitApplication(HINSTANCE hInstance);
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow);

HWND
  hWnd1;

#define BTN1 1

LPCSTR
  szClassName="TestWin32API",
  szTitle="Test Win32 API";

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	if(!hPrevInstance)
	{
		if(!InitApplication(hInstance))
			return FALSE;
	}

	if(!InitInstance(hInstance,nCmdShow))
		return FALSE;

	MSG
		msg;

	while(GetMessage(&msg,NULL,0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return static_cast<int>(msg.wParam);
}

BOOL InitApplication(HINSTANCE hInstance)
{
	WNDCLASS
		wc;

	wc.style=CS_HREDRAW|CS_VREDRAW;
	wc.lpfnWndProc=static_cast<WNDPROC>(WndProc);
	wc.cbClsExtra=0;
	wc.cbWndExtra=0;
	wc.hInstance=hInstance;
	wc.hIcon=LoadIcon(NULL,IDI_ASTERISK);
	wc.hCursor=LoadCursor(NULL,IDC_CROSS);
	wc.hbrBackground=reinterpret_cast<HBRUSH>(COLOR_WINDOW+1);
	wc.lpszMenuName=NULL;
	wc.lpszClassName=szClassName;

	return RegisterClass(&wc);
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	HWND
		hWnd;

	hWnd=CreateWindow(
		szClassName,
		szTitle,
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		NULL,
		NULL,
		hInstance,
		NULL);

	if(!hWnd)
		return FALSE;

	if(ShowWindow(hWnd,nCmdShow))
		return FALSE;

	if(!UpdateWindow(hWnd))
		return FALSE;

	hWnd1=CreateWindow(
		"BUTTON",
		"Button",
		WS_VISIBLE|WS_CHILD,
		210,
		20,
		80,
		20,
		hWnd,
		reinterpret_cast<HMENU>(BTN1),
		hInstance,
		NULL);

	if(!hWnd1)
	{
		MessageBox(NULL,"!hWnd1","Error",MB_OK|MB_ICONERROR);
		exit(1);
	}

	return TRUE;
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	HDC
		hDC;

	PAINTSTRUCT
		ps;

	switch(message)
	{
		case WM_PAINT :
		{
			COLORREF
				oldColor,
				oldBkColor;

			HBRUSH
				hNewBrush,
				hOldBrush;

			HPEN
				hNewPen,
				hOldPen;

			char
				*TxtOut;

			hDC=BeginPaint(hwnd,&ps);
			if(!hDC)
			{
				MessageBox(NULL,"!BeginPaint","Error",MB_OK);
				exit(1);
			}

			oldColor=SetTextColor(hDC,RGB(0,255,0));
			if(oldColor==CLR_INVALID)
			{
				MessageBox(NULL,"oldColor","Error",MB_OK);
				exit(2);
			}

			oldBkColor=SetBkColor(hDC,RGB(0,0,0));
			if(oldBkColor==CLR_INVALID)
			{
				MessageBox(NULL,"oldBkColor","Error",MB_OK);
				exit(3);
			}

			TxtOut="义耱 TextOut()";
			if(!TextOut(hDC,150,0,TxtOut,strlen(TxtOut)))
			{
				MessageBox(NULL,"TextOut","Error",MB_OK);
				exit(4);
			}
			SetTextColor(hDC,oldColor);
			SetBkColor(hDC,oldBkColor);

			TxtOut="义耱 LineTo()";
			TextOut(hDC,50,30,TxtOut,strlen(TxtOut));
			if(!MoveToEx(hDC,125,50,NULL))
			{
				MessageBox(NULL,"MoveToEx","Error",MB_OK);
				exit(5);
			}
			if(!LineTo(hDC,175,100))
			{
				MessageBox(NULL,"LineTo","Error",MB_OK);
				exit(6);
			}
			
			TxtOut="义耱 Ellipse()";
			TextOut(hDC,50,120,TxtOut,strlen(TxtOut));
			hNewBrush=CreateSolidBrush(RGB(255,0,0));
			if(!hNewBrush)
			{
				MessageBox(NULL,"CreateSolidBrush","Error",MB_OK);
				exit(7);
			}
			
			hOldBrush=static_cast<HBRUSH>(SelectObject(hDC,hNewBrush));
			if(!hOldBrush)
			{
				MessageBox(NULL,"SelectObject","Error",MB_OK);
				exit(8);
			}

			if(!Ellipse(hDC,100,140,200,240))
			{
				MessageBox(NULL,"Ellipce","Error",MB_OK);
				exit(9);
			}
			
			if(!DeleteObject(hNewBrush))
			{
				MessageBox(NULL,"DeleteObject","Error",MB_OK);
				exit(10);
			}
			SelectObject(hDC,hOldBrush);

			TxtOut="义耱 Rectangle()";
			TextOut(hDC,50,250,TxtOut,strlen(TxtOut));
			hNewPen=CreatePen(PS_DOT,1,RGB(255,0,0));
			if(!hNewPen)
			{
				MessageBox(NULL,"CreatePen","Error",MB_OK);
				exit(11);
			}
			hOldPen=static_cast<HPEN>(SelectObject(hDC,hNewPen));
			if(!Rectangle(hDC,100,270,200,370))
			{
				MessageBox(NULL,"Rectangle","Error",MB_OK);
				exit(12);
			}
			DeleteObject(hNewPen);
			SelectObject(hDC,hOldPen);

			if(!EndPaint(hwnd,&ps))
			{
				MessageBox(NULL,"!EndPaint","Error",MB_OK);
				exit(13);
			}

			break;
		}
		case WM_DESTROY :
		{
			PostQuitMessage(0);
			break;
		}
		case WM_COMMAND :
		{
			switch(LOWORD(wParam))
			{
				case BTN1 :
				{
					if(!MessageBeep(MB_OK))
					{
						MessageBox(NULL,"!MessageBeep","Error",MB_OK|MB_ICONERROR);
						exit(14);
					}
					MessageBox(NULL,"OnClick","OnClick",MB_OK|MB_ICONINFORMATION);

					break;
				}
			}
			break;
		}
		default :
		{
			return DefWindowProc(hwnd,message,wParam,lParam);
		}
	}

	return 0;
}