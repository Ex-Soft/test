#include "StdAfx.h"
#include "MainThread.hpp"
#include "FrameWnd.hpp"

BOOL MainThread::InitInstance(void)
{
	FrameWnd
		*pFrame;

	pFrame=new FrameWnd;
	ASSERT_VALID(pFrame);

	/*
	pFrame->Create(NULL,"Win32MFC");
	pFrame->MoveWindow(100,200,700,500,FALSE);
	pFrame->ShowWindow(SW_SHOW);
	pFrame->UpdateWindow();
	*/

	pFrame->Create(NULL,"Win32MFC",WS_VISIBLE|WS_OVERLAPPEDWINDOW,CRect(100,200,700,500));
	this->m_pMainWnd=pFrame;

	return TRUE;
}