// WinFormAppMFCDoc.h : interface of the CWinFormAppMFCDoc class
//


#pragma once

class CWinFormAppMFCDoc : public CDocument
{
protected: // create from serialization only
	CWinFormAppMFCDoc();
	DECLARE_DYNCREATE(CWinFormAppMFCDoc)

// Attributes
public:

// Operations
public:

// Overrides
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CWinFormAppMFCDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


