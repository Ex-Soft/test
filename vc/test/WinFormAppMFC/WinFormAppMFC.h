// WinFormAppMFC.h : main header file for the WinFormAppMFC application
//
#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols


// CWinFormAppMFCApp:
// See WinFormAppMFC.cpp for the implementation of this class
//

class CWinFormAppMFCApp : public CWinApp
{
public:
	CWinFormAppMFCApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CWinFormAppMFCApp theApp;