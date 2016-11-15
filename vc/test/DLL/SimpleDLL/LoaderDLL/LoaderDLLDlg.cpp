
// LoaderDLLDlg.cpp : implementation file
//

#include "stdafx.h"
#include "LoaderDLL.h"
#include "LoaderDLLDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CLoaderDLLDlg dialog



CLoaderDLLDlg::CLoaderDLLDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_LOADERDLL_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	dllCaller = new DllCaller();
}

void CLoaderDLLDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CLoaderDLLDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTONINIT, &CLoaderDLLDlg::OnBnClickedButtoninit)
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTONWM_NCLBUTTONDBLCLK_COUNT, &CLoaderDLLDlg::OnBnClickedButtonwmNclbuttondblclkCount)
	ON_BN_CLICKED(IDC_BUTTONWM_NCRBUTTONDBLCLK_COUNT, &CLoaderDLLDlg::OnBnClickedButtonwmNcrbuttondblclkCount)
	ON_BN_CLICKED(IDC_BUTTONWM_RBUTTONDBLCLK_COUNT, &CLoaderDLLDlg::OnBnClickedButtonwmRbuttondblclkCount)
	ON_BN_CLICKED(IDC_BUTTONWM_LBUTTONDBLCLK_COUNT, &CLoaderDLLDlg::OnBnClickedButtonwmLbuttondblclkCount)
END_MESSAGE_MAP()


// CLoaderDLLDlg message handlers

BOOL CLoaderDLLDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CLoaderDLLDlg::OnPaint()
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
HCURSOR CLoaderDLLDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CLoaderDLLDlg::OnBnClickedButtoninit()
{
	HMODULE
		moduleHandle = GetModuleHandle(NULL),
		hModule = AfxGetStaticModuleState()->m_hCurrentInstanceHandle;

	if (moduleHandle != hModule)
	{

	}

	dllCaller->Init();
}

void CLoaderDLLDlg::OnClose()
{
	delete dllCaller;

	CDialogEx::OnClose();
}

void CLoaderDLLDlg::OnBnClickedButtonwmNclbuttondblclkCount()
{
	int tmp = dllCaller->GetNCLButtonDblClk();
}

void CLoaderDLLDlg::OnBnClickedButtonwmNcrbuttondblclkCount()
{
	int tmp = dllCaller->GetNCRButtonDblClk();
}

void CLoaderDLLDlg::OnBnClickedButtonwmRbuttondblclkCount()
{
	int tmp = dllCaller->GetRButtonDblClk();
}

void CLoaderDLLDlg::OnBnClickedButtonwmLbuttondblclkCount()
{
	int tmp = dllCaller->GetLButtonDblClk();
}
