
// LoaderDLLDlg.h : header file
//

#pragma once


// CLoaderDLLDlg dialog
class CLoaderDLLDlg : public CDialogEx
{
// Construction
public:
	CLoaderDLLDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_LOADERDLL_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

private:
	DllCaller *dllCaller;

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtoninit();
	afx_msg void OnClose();
	afx_msg void OnBnClickedButtonwmNclbuttondblclkCount();
	afx_msg void OnBnClickedButtonwmNcrbuttondblclkCount();
	afx_msg void OnBnClickedButtonwmRbuttondblclkCount();
	afx_msg void OnBnClickedButtonwmLbuttondblclkCount();
};
