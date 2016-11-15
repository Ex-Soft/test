#include "StdAfx.h"
#include "FrameWnd.hpp"

BEGIN_MESSAGE_MAP(FrameWnd, CFrameWnd)
	ON_WM_PAINT()
END_MESSAGE_MAP()

afx_msg void FrameWnd::OnPaint(void)
{
	COLORREF
		oldColor,
		oldBkColor;

	CBrush
		NewBrush,
		*OldBrush;

	CPen
		NewPen,
		*OldPen;

	CPaintDC
		PaintDC(this);

	/*
	HDC
		hDC;

	PAINTSTRUCT
		ps;

	char
		*TxtOut;

	hDC=::BeginPaint(this->m_hWnd,&ps);
	if(!hDC)
	{
		MessageBox("!BeginPaint","Error",MB_OK);
		exit(1);
	}

	if(hDC!=PaintDC.m_hDC)
		MessageBox("hDC!=PaintDC.m_hDC","Warning",MB_OK|MB_ICONINFORMATION);

	TxtOut="WM_PAINT";
	//if(!TextOut(hDC,150,0,TxtOut,strlen(TxtOut)))
	if(!TextOut(PaintDC.m_hDC,150,0,TxtOut,strlen(TxtOut)))
	{
		MessageBox("!TextOut","Error",MB_OK);
		exit(2);
	}
	if(!::EndPaint(this->m_hWnd,&ps))
	{
		MessageBox("!EndPaint","Error",MB_OK);
		exit(3);
	}
	*/

	PaintDC.TextOut(0,0,"PaintDC.TextOut()");
	oldColor=PaintDC.SetTextColor(RGB(0,255,0));
	oldBkColor=PaintDC.SetBkColor(RGB(0,0,0));
	PaintDC.TextOut(250,0,"PaintDC.TextOut()");
	PaintDC.SetTextColor(oldColor);
	PaintDC.SetBkColor(oldBkColor);

	PaintDC.TextOut(50,30,"Тест PaintDC.LineTo()");
	PaintDC.MoveTo(125,50);
	PaintDC.LineTo(175,100);

	PaintDC.TextOut(50,120,"Тест PaintDC.Ellipse()");
	NewBrush.CreateSolidBrush(RGB(255,0,0));
	OldBrush=PaintDC.SelectObject(&NewBrush);
	PaintDC.Ellipse(100,140,200,240);
	NewBrush.DeleteObject();
	PaintDC.SelectObject(OldBrush);

	PaintDC.TextOut(300,120,"Тест PaintDC.Rectangle()");
	NewPen.CreatePen(PS_DOT,1,RGB(255,0,0));
	OldPen=PaintDC.SelectObject(&NewPen);
	PaintDC.Rectangle(370,140,470,200);
	NewPen.DeleteObject();
	PaintDC.SelectObject(OldPen);

	return afx_msg void();
}