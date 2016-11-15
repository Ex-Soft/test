#include "StdAfx.h"
#include "FrameWnd.hpp"

#define IDC_BTNABOUT	100
#define IDC_BTNEXIT		101

BEGIN_MESSAGE_MAP(FrameWnd, CFrameWnd)
	ON_COMMAND(IDC_BTNABOUT,OnBtnAboutClick)
	ON_COMMAND(IDC_BTNEXIT,OnBtnExitClick)
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

FrameWnd::FrameWnd(void)
{
	m_pBtnAbout=0;
	m_pBtnExit=0;
}

FrameWnd::~FrameWnd(void)
{
	if(m_pBtnAbout)
	{
		delete m_pBtnAbout;
		m_pBtnAbout=0;
	}

	if(m_pBtnExit)
	{
		delete m_pBtnExit;
		m_pBtnExit=0;
	}
}

void FrameWnd::CreateChildControls(void)
{
	m_pBtnAbout=new CButton;
	ASSERT_VALID(m_pBtnAbout);

	BOOL
		rc=m_pBtnAbout->Create(
			"About Button",
			WS_VISIBLE|WS_CHILD|BS_DEFPUSHBUTTON,
			CRect(424,40,513,65),
			this,
			IDC_BTNABOUT);

	if(!rc)
	{
		TRACE0("\n Error 2. !rc");
		exit(2);
	}

	m_pBtnExit=new CButton;
	ASSERT_VALID(m_pBtnExit);
	rc=m_pBtnExit->Create(
		"Exit Button",
		WS_VISIBLE|WS_CHILD|BS_PUSHBUTTON,
		CRect(424,8,513,33),
		this,
		IDC_BTNEXIT);

	if(!rc)
	{
		TRACE0("\n Error 3. !rc");
		exit(3);
	}

}

afx_msg void FrameWnd::OnBtnAboutClick(void)
{
	BOOL
		rc=MessageBeep(-1);

	if(!rc)
	{
		TRACE0("\n Error 4. !rc");
		exit(4);
	}

	AfxMessageBox("AboutButton");

	return afx_msg void();
}

afx_msg void FrameWnd::OnBtnExitClick(void)
{
	BOOL
		rc=MessageBeep(-1);

	if(!rc)
	{
		TRACE0("\n Error 5. !rc");
		exit(5);
	}

	rc=DestroyWindow();
	if(!rc)
	{
		TRACE0("\n Error 6. !rc");
		exit(6);
	}


	return afx_msg void();
}