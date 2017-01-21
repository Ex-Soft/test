//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
#include "IBTools.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerExistsButtonClick(TObject *Sender)
{
   Result->ShowHint=true;
   try
      {
         ServerExists(ServerName->Text.Trim());
         Result->Text="True";
         Result->Hint="All Ok!!!";
      }
   catch(Exception &eException)
      {
         Result->Text="False";
         Result->Hint=eException.Message;
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestServerVersionButtonClick(TObject *Sender)
{
   Result->ShowHint=true;
   try
      {
         Result->Text=ServerVersion(ServerName->Text.Trim(),UserName->Text.Trim(),UserPassword->Text.Trim());
         Result->Hint="All Ok!!!";
      }
   catch(Exception &eException)
      {
         Result->Text="Unknown";
         Result->Hint=eException.Message;
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UserExistsButtonClick(TObject *Sender)
{
   Result->ShowHint=true;
   try
      {
         UserExists(ServerName->Text.Trim(),UserName->Text.Trim(),UserPassword->Text.Trim());
         Result->Text="True";
         Result->Hint="All Ok!!!";
      }
   catch(Exception &eException)
      {
         Result->Text="False";
         Result->Hint=eException.Message;
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestAddUserButtonClick(TObject *Sender)
{
   Result->ShowHint=true;
   try
      {
         AddUser(ServerName->Text.Trim(),UserName->Text.Trim(),UserPassword->Text.Trim(),"aaaa","aaaa");
         Result->Text="True";
         Result->Hint="All Ok!!!";
      }
   catch(Exception &eException)
      {
         Result->Text="False";
         Result->Hint=eException.Message;
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestSplitIBDatabaseNameButtonClick(
      TObject *Sender)
{
   AnsiString Server,DataBase;

   Result->Text=SplitIBDatabaseName(FullDataBaseName->Text,Server,DataBase)?"true":"false";
   ServerName->Text=Server;
   DataBaseName->Text=DataBase;
   Result->Hint="";
   Result->ShowHint=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestTCPIP2DNSButtonClick(TObject *Sender)
{
   Result->Text=TCPIP2DNS(FullDataBaseName->Text);
   Result->Hint="";
   Result->ShowHint=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestDNS2TCPIPButtonClick(TObject *Sender)
{
   Result->Text=DNS2TCPIP(FullDataBaseName->Text);
   Result->Hint="";
   Result->ShowHint=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestIsLocalPathButtonClick(TObject *Sender)
{
   Result->Text=IsLocalPath(FullDataBaseName->Text)?"true":"false";
   Result->Hint="";
   Result->ShowHint=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TestIsDNSPathButtonClick(TObject *Sender)
{
   Result->Text=IsDNSPath(FullDataBaseName->Text)?"true":"false";
   Result->Hint="";
   Result->ShowHint=false;
}
//---------------------------------------------------------------------------


