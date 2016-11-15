
// DlgProxy.cpp : implementation file
//

#include "stdafx.h"
#include "TestMFCWithActiveXAndAutomation.h"
#include "DlgProxy.h"
#include "TestMFCWithActiveXAndAutomationDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CTestMFCWithActiveXAndAutomationDlgAutoProxy

IMPLEMENT_DYNCREATE(CTestMFCWithActiveXAndAutomationDlgAutoProxy, CCmdTarget)

CTestMFCWithActiveXAndAutomationDlgAutoProxy::CTestMFCWithActiveXAndAutomationDlgAutoProxy()
{
	EnableAutomation();
	
	// To keep the application running as long as an automation 
	//	object is active, the constructor calls AfxOleLockApp.
	AfxOleLockApp();

	// Get access to the dialog through the application's
	//  main window pointer.  Set the proxy's internal pointer
	//  to point to the dialog, and set the dialog's back pointer to
	//  this proxy.
	ASSERT_VALID(AfxGetApp()->m_pMainWnd);
	if (AfxGetApp()->m_pMainWnd)
	{
		ASSERT_KINDOF(CTestMFCWithActiveXAndAutomationDlg, AfxGetApp()->m_pMainWnd);
		if (AfxGetApp()->m_pMainWnd->IsKindOf(RUNTIME_CLASS(CTestMFCWithActiveXAndAutomationDlg)))
		{
			m_pDialog = reinterpret_cast<CTestMFCWithActiveXAndAutomationDlg*>(AfxGetApp()->m_pMainWnd);
			m_pDialog->m_pAutoProxy = this;
		}
	}
}

CTestMFCWithActiveXAndAutomationDlgAutoProxy::~CTestMFCWithActiveXAndAutomationDlgAutoProxy()
{
	// To terminate the application when all objects created with
	// 	with automation, the destructor calls AfxOleUnlockApp.
	//  Among other things, this will destroy the main dialog
	if (m_pDialog != NULL)
		m_pDialog->m_pAutoProxy = NULL;
	AfxOleUnlockApp();
}

void CTestMFCWithActiveXAndAutomationDlgAutoProxy::OnFinalRelease()
{
	// When the last reference for an automation object is released
	// OnFinalRelease is called.  The base class will automatically
	// deletes the object.  Add additional cleanup required for your
	// object before calling the base class.

	CCmdTarget::OnFinalRelease();
}

BEGIN_MESSAGE_MAP(CTestMFCWithActiveXAndAutomationDlgAutoProxy, CCmdTarget)
END_MESSAGE_MAP()

BEGIN_DISPATCH_MAP(CTestMFCWithActiveXAndAutomationDlgAutoProxy, CCmdTarget)
END_DISPATCH_MAP()

// Note: we add support for IID_ITestMFCWithActiveXAndAutomation to support typesafe binding
//  from VBA.  This IID must match the GUID that is attached to the 
//  dispinterface in the .IDL file.

// {D2303C8A-E76A-473B-A69D-595EC1382663}
static const IID IID_ITestMFCWithActiveXAndAutomation =
{ 0xD2303C8A, 0xE76A, 0x473B, { 0xA6, 0x9D, 0x59, 0x5E, 0xC1, 0x38, 0x26, 0x63 } };

BEGIN_INTERFACE_MAP(CTestMFCWithActiveXAndAutomationDlgAutoProxy, CCmdTarget)
	INTERFACE_PART(CTestMFCWithActiveXAndAutomationDlgAutoProxy, IID_ITestMFCWithActiveXAndAutomation, Dispatch)
END_INTERFACE_MAP()

// The IMPLEMENT_OLECREATE2 macro is defined in StdAfx.h of this project
// {BB224350-E6E2-4DD1-92F5-8B6818E0EDB7}
IMPLEMENT_OLECREATE2(CTestMFCWithActiveXAndAutomationDlgAutoProxy, "TestMFCWithActiveXAndAutomation.Application", 0xbb224350, 0xe6e2, 0x4dd1, 0x92, 0xf5, 0x8b, 0x68, 0x18, 0xe0, 0xed, 0xb7)


// CTestMFCWithActiveXAndAutomationDlgAutoProxy message handlers
