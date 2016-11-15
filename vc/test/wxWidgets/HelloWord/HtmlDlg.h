#ifndef __HTMLVIEW_H_
#define __HTMLVIEW_H_

// wxWidgets "Hello world" Program
// For compilers that support precompilation, includes "wx/wx.h".
#include <wx/wxprec.h>
#ifndef WX_PRECOMP
#include <wx/wx.h>
#endif

#include <wx/webview.h>

class HtmlDlg : public wxDialog
{
	wxWebView *cWindow;
	wxButton *cCloseButton;
	wxString cButText;

public:
	HtmlDlg();
	HtmlDlg(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &pos = wxDefaultPosition, const wxSize &size = wxDefaultSize, long style = wxDEFAULT_DIALOG_STYLE, const wxString &name = wxDialogNameStr);

	void CreateControls(void);
};

#endif
