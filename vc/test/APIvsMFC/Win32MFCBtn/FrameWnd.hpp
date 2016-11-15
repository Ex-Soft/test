#ifndef _FrameWnd_hpp
#define _FrameWnd_hpp

#include <afxwin.h>

class FrameWnd : public CFrameWnd
{
private:
	CButton
		*m_pBtnExit,
		*m_pBtnAbout;

public:
	FrameWnd(void);
	~FrameWnd(void);

	virtual void CreateChildControls(void);

protected:
	afx_msg void OnPaint(void);
	afx_msg void OnBtnAboutClick(void);
	afx_msg void OnBtnExitClick(void);

	DECLARE_MESSAGE_MAP();
};

#endif