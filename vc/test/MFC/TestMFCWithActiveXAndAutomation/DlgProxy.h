
// DlgProxy.h: header file
//

#pragma once

class CTestMFCWithActiveXAndAutomationDlg;


// CTestMFCWithActiveXAndAutomationDlgAutoProxy command target

class CTestMFCWithActiveXAndAutomationDlgAutoProxy : public CCmdTarget
{
	DECLARE_DYNCREATE(CTestMFCWithActiveXAndAutomationDlgAutoProxy)

	CTestMFCWithActiveXAndAutomationDlgAutoProxy();           // protected constructor used by dynamic creation

// Attributes
public:
	CTestMFCWithActiveXAndAutomationDlg* m_pDialog;

// Operations
public:

// Overrides
	public:
	virtual void OnFinalRelease();

// Implementation
protected:
	virtual ~CTestMFCWithActiveXAndAutomationDlgAutoProxy();

	// Generated message map functions

	DECLARE_MESSAGE_MAP()
	DECLARE_OLECREATE(CTestMFCWithActiveXAndAutomationDlgAutoProxy)

	// Generated OLE dispatch map functions

	DECLARE_DISPATCH_MAP()
	DECLARE_INTERFACE_MAP()
};

