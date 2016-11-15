
// TestBackgroundImageDlg.h : header file
//

#pragma once


// CTestBackgroundImageDlg dialog
class CTestBackgroundImageDlg : public CDialogEx
{
// Construction
public:
	CTestBackgroundImageDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_TESTBACKGROUNDIMAGE_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	#ifndef __USE_CDIALOGEX__
		CBitmap Background; // For Holding The bitmap
		CBrush BrushHol; //For Handling Background of Text in Static Text
		CSize bitmapSize;
	#endif

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	#ifndef __USE_CDIALOGEX__
		afx_msg BOOL OnEraseBkgnd(CDC* pDC);
		afx_msg void OnDestroy();
		afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	#endif
};
