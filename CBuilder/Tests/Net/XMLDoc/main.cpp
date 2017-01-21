//---------------------------------------------------------------------------

#include <vcl.h>
#include <xmldoc.hpp>
#include <shdocvw.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";

   long
     btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);

   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   TXMLDocument
     *tmpXMLDocument=0;

   TWebBrowser
     *tmpWebBrowser=0;

   tmpWebBrowser=new TWebBrowser(MainForm->Handle);

   if(tmpWebBrowser)
     delete tmpWebBrowser;

   //tmpXMLDocument=new TXMLDocument("e:\\doc2html.htm");

   if(tmpXMLDocument)
     delete tmpXMLDocument;
}
//---------------------------------------------------------------------------



