
// ApplicationDlg.h : header file
//

#pragma once

typedef BOOL WINAPI hook(DWORD);

// CApplicationDlg dialog
class CApplicationDlg : public CDialogEx
{
	HINSTANCE dllInstance;
	hook *ptrHook;
	DllWrapper *dllWrapper;

// Construction
public:
	CApplicationDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_APPLICATION_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonHook();
	afx_msg void OnBnClickedButtonUnhook();
	afx_msg void OnClose();
	afx_msg void OnBnClickedButtonbywrapper();
};
