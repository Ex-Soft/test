
// TestImageDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TestImage.h"
#include "TestImageDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTestImageDlg dialog



CTestImageDlg::CTestImageDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_TESTIMAGE_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTestImageDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CTestImageDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTONLOAD, &CTestImageDlg::OnBnClickedButtonload)
END_MESSAGE_MAP()


// CTestImageDlg message handlers

BOOL CTestImageDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	m_picture = (CStatic *)GetDlgItem(IDC_STATIC1);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTestImageDlg::OnPaint()
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
HCURSOR CTestImageDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CTestImageDlg::OnBnClickedButtonload()
{
	LPCTSTR lpszResourceName = MAKEINTRESOURCE(IDB_BITMAP1 /*IDR_JPG1*/);
	HINSTANCE hinstRes = AfxFindResourceHandle(lpszResourceName, RT_BITMAP /*RT_RCDATA*/);

	if (hinstRes == NULL)
		return;

	UINT uiLoadImageFlags = LR_CREATEDIBSECTION | LR_LOADMAP3DCOLORS;
	HBITMAP hbmp = NULL;
	hbmp = (HBITMAP)::LoadImage(hinstRes, lpszResourceName, IMAGE_BITMAP, 0, 0, uiLoadImageFlags);

	if (hbmp != NULL)
	{
		m_picture->ModifyStyle(0xF, SS_BITMAP, SWP_NOSIZE);
		m_picture->SetBitmap(hbmp);
	}
}
