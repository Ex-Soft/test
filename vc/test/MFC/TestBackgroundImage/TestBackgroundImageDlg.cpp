
// TestBackgroundImageDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TestBackgroundImage.h"
#include "TestBackgroundImageDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTestBackgroundImageDlg dialog



CTestBackgroundImageDlg::CTestBackgroundImageDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_TESTBACKGROUNDIMAGE_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	#ifndef __USE_CDIALOGEX__
		BrushHol.CreateStockObject(HOLLOW_BRUSH);
	#endif
}

void CTestBackgroundImageDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CTestBackgroundImageDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	#ifndef __USE_CDIALOGEX__
		ON_WM_ERASEBKGND()
		ON_WM_DESTROY()
		ON_WM_CTLCOLOR()
	#endif
END_MESSAGE_MAP()


// CTestBackgroundImageDlg message handlers

BOOL CTestBackgroundImageDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	#if __USE_CDIALOGEX__
		this->SetBackgroundImage(/*IDR_JPG1*/IDB_BITMAP1, BACKGR_TOPLEFT, TRUE);
	#else
		Background.LoadBitmap(IDB_BITMAP1); //Load bitmap
		BITMAP bm; //Create bitmap Handle to get dimensions
		Background.GetBitmap(&bm); //Load bitmap into handle
		bitmapSize = CSize(bm.bmWidth, bm.bmHeight); // Get bitmap Sizes;
		Invalidate(1);
	#endif

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTestBackgroundImageDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CTestBackgroundImageDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

#ifndef __USE_CDIALOGEX__
BOOL CTestBackgroundImageDlg::OnEraseBkgnd(CDC* pDC)
{
	CDC dcMemory;
	dcMemory.CreateCompatibleDC(pDC);
	CBitmap* pOldbitmap = dcMemory.SelectObject(&Background);
	CRect rcClient;
	GetClientRect(&rcClient);
	const CSize& sbitmap = bitmapSize;
	pDC->BitBlt(0, 0, sbitmap.cx, sbitmap.cy, &dcMemory, 0, 0, SRCCOPY);
	dcMemory.SelectObject(pOldbitmap);
	return TRUE;
}

void CTestBackgroundImageDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	Background.DeleteObject(); // Delete Background bitmap
	BrushHol.DeleteObject();
}

HBRUSH CTestBackgroundImageDlg::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)
{
	// HBRUSH hbr = CDialog::OnCtlColor(pDC, pWnd, nCtlColor);

	pDC->SetBkMode(TRANSPARENT);
	if (pWnd->GetDlgCtrlID() == IDC_STATIC)
		//Example of changing Text colour specific to a certain 
		//Static Text Contol in this case IDC_STATIC.
	{
		pDC->SetTextColor(RGB(255, 0, 0));
	}

	// TODO: Return a different brush if the default is not desired
	return BrushHol;
}
#endif
