// WinFormAppMFCDoc.cpp : implementation of the CWinFormAppMFCDoc class
//

#include "stdafx.h"
#include "WinFormAppMFC.h"

#include "WinFormAppMFCDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CWinFormAppMFCDoc

IMPLEMENT_DYNCREATE(CWinFormAppMFCDoc, CDocument)

BEGIN_MESSAGE_MAP(CWinFormAppMFCDoc, CDocument)
END_MESSAGE_MAP()


// CWinFormAppMFCDoc construction/destruction

CWinFormAppMFCDoc::CWinFormAppMFCDoc()
{
	// TODO: add one-time construction code here

}

CWinFormAppMFCDoc::~CWinFormAppMFCDoc()
{
}

BOOL CWinFormAppMFCDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CWinFormAppMFCDoc serialization

void CWinFormAppMFCDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}


// CWinFormAppMFCDoc diagnostics

#ifdef _DEBUG
void CWinFormAppMFCDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CWinFormAppMFCDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CWinFormAppMFCDoc commands
