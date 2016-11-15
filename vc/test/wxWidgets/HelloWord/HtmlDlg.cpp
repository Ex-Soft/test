#include "HtmlDlg.h"

HtmlDlg::HtmlDlg()
{
	cButText = "Close";
	CreateControls();
}

HtmlDlg::HtmlDlg(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &pos, const wxSize &size, long style, const wxString &name) : wxDialog(parent, id, title, pos, size, style, name)
{
	cButText = "Close";
	CreateControls();
}

void HtmlDlg::CreateControls(void)
{
	wxBoxSizer* aMainBox = new wxBoxSizer(wxVERTICAL);
	SetSizer(aMainBox);
	cWindow = wxWebView::New(this, -1, /*"http://www.google.com/"*/ "http://localhost/JavaScript/test/TestNavigatorI.html", wxPoint(5, 5));
	aMainBox->Add(cWindow, 1, wxEXPAND | wxALL, 5);
	if (cButText != "")
	{
		cCloseButton = new wxButton(this, wxID_CANCEL, cButText, wxDefaultPosition, wxDefaultSize, 0);
		aMainBox->Add(cCloseButton, 0, wxALIGN_CENTER_HORIZONTAL | wxALL /*| wxADJUST_MINSIZE*/, 5);
	}
	else
		cCloseButton = NULL;
}

