// WinFormAppMFCView.cpp : implementation of the CWinFormAppMFCView class
//

#include "stdafx.h"
#include "WinFormAppMFC.h"

#include "WinFormAppMFCDoc.h"
#include "WinFormAppMFCView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CWinFormAppMFCView

IMPLEMENT_DYNCREATE(CWinFormAppMFCView, CView)

BEGIN_MESSAGE_MAP(CWinFormAppMFCView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CWinFormAppMFCView construction/destruction

CWinFormAppMFCView::CWinFormAppMFCView()
{
	// TODO: add construction code here

}

CWinFormAppMFCView::~CWinFormAppMFCView()
{
}

BOOL CWinFormAppMFCView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CWinFormAppMFCView drawing

void CWinFormAppMFCView::OnDraw(CDC* /*pDC*/)
{
	CWinFormAppMFCDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CWinFormAppMFCView printing

BOOL CWinFormAppMFCView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CWinFormAppMFCView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CWinFormAppMFCView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CWinFormAppMFCView diagnostics

#ifdef _DEBUG
void CWinFormAppMFCView::AssertValid() const
{
	CView::AssertValid();
}

void CWinFormAppMFCView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CWinFormAppMFCDoc* CWinFormAppMFCView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CWinFormAppMFCDoc)));
	return (CWinFormAppMFCDoc*)m_pDocument;
}
#endif //_DEBUG


// CWinFormAppMFCView message handlers
