// WinFormAppMFCView.h : interface of the CWinFormAppMFCView class
//


#pragma once


class CWinFormAppMFCView : public CView
{
protected: // create from serialization only
	CWinFormAppMFCView();
	DECLARE_DYNCREATE(CWinFormAppMFCView)

// Attributes
public:
	CWinFormAppMFCDoc* GetDocument() const;

// Operations
public:

// Overrides
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CWinFormAppMFCView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in WinFormAppMFCView.cpp
inline CWinFormAppMFCDoc* CWinFormAppMFCView::GetDocument() const
   { return reinterpret_cast<CWinFormAppMFCDoc*>(m_pDocument); }
#endif

