//---------------------------------------------------------------------------

#include <vcl.h>
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
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   AnsiString Operation="open";
   /*
   Space ( )               %20
   Comma (,)               %2C
   Question mark (?)       %3F
   Period (.)              %2E
   Exclamation point (!)   %21
   Colon (:)               %3A
   Semicolon (;)           %3B
   Line feed               %0A
   Line break (ENTER key)  %0D
   */
   AnsiString File="mailto:Nozhenko@usbi.com.ua?Subject=Bug report&Body=CivilAll.exe%3A%20ver%2E%201%2E1%0A%0D&file=\"c:\\autoexec.bat\"";
   ShellExecute(Handle,Operation.c_str(),File.c_str(),0,0,SW_SHOWDEFAULT);
   /*
   const
  olMailItem = 0;
var
  Outlook, MailItem: OLEVariant;
begin
  try
    Outlook := GetActiveOleObject('Outlook.Application');
  except
    Outlook := CreateOleObject('Outlook.Application');
  end;

  MailItem := Outlook.CreateItem(olMailItem);
  MailItem.Recipients.Add('delphi at elists.org');
  MailItem.Subject := 'your subject';
  MailItem.Body := 'Visit: http://www.elists.org/mailman/listinfo/delphi';
  MailItem.Attachments.Add('C:\autoexec.bat');
  MailItem.Send;

  Outlook := Unassigned;
end;
   */
}
//---------------------------------------------------------------------------



