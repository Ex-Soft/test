
// ApplicationDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Application.h"
#include "ApplicationDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CApplicationDlg dialog



CApplicationDlg::CApplicationDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_APPLICATION_DIALOG, pParent)
{
	dllInstance = 0;
	ptrHook = 0;
	dllWrapper = NULL;

	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CApplicationDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CApplicationDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_HOOK, &CApplicationDlg::OnBnClickedButtonHook)
	ON_BN_CLICKED(IDC_BUTTON_UNHOOK, &CApplicationDlg::OnBnClickedButtonUnhook)
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTONBYWRAPPER, &CApplicationDlg::OnBnClickedButtonbywrapper)
END_MESSAGE_MAP()


// CApplicationDlg message handlers

BOOL CApplicationDlg::OnInitDialog()
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

void CApplicationDlg::OnPaint()
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
HCURSOR CApplicationDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CApplicationDlg::OnBnClickedButtonHook()
{
	if (!dllInstance)
	{
		if (!(dllInstance = LoadLibrary(TEXT("Hook.dll"))))
			return;
	}

	if (!ptrHook)
	{
		if (!(ptrHook = (hook *)GetProcAddress(dllInstance, "SetHook")))
			return;

		ptrHook(GetCurrentThreadId());
	}
}

void CApplicationDlg::OnBnClickedButtonUnhook()
{
	if (!dllInstance || !ptrHook)
		return;

	ptrHook(0);
}

void CApplicationDlg::OnClose()
{
	if (dllWrapper)
		delete dllWrapper;

	if (dllInstance)
		FreeLibrary(dllInstance);
	
	CDialogEx::OnClose();
}

void CApplicationDlg::OnBnClickedButtonbywrapper()
{
	if (!dllWrapper)
	{
		dllWrapper = new DllWrapper();
		dllWrapper->Init();
	}
}
