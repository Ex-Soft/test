#ifndef _FrameWnd_hpp
#define _FrameWnd_hpp

#include <afxwin.h>

class FrameWnd : public CFrameWnd
{
protected:
	afx_msg void OnPaint(void);

	DECLARE_MESSAGE_MAP();
};

#endif