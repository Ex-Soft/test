
// TestMFCWithActiveXAndAutomationDlg.h : header file
//

#pragma once

class CTestMFCWithActiveXAndAutomationDlgAutoProxy;


// CTestMFCWithActiveXAndAutomationDlg dialog
class CTestMFCWithActiveXAndAutomationDlg : public CDialogEx
{
	DECLARE_DYNAMIC(CTestMFCWithActiveXAndAutomationDlg);
	friend class CTestMFCWithActiveXAndAutomationDlgAutoProxy;

// Construction
public:
	CTestMFCWithActiveXAndAutomationDlg(CWnd* pParent = NULL);	// standard constructor
	virtual ~CTestMFCWithActiveXAndAutomationDlg();

// Dialog Data
	enum { IDD = IDD_TESTMFCWITHACTIVEXANDAUTOMATION_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	CTestMFCWithActiveXAndAutomationDlgAutoProxy* m_pAutoProxy;
	HICON m_hIcon;

	BOOL CanExit();

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	virtual void OnOK();
	virtual void OnCancel();
	DECLARE_MESSAGE_MAP()
};
