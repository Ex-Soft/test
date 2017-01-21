//---------------------------------------------------------------------------

#include <vcl.h>
#include <IniFiles.hpp>
#include <new>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "CGAUGES"
#pragma resource "*.dfm"

bool __fastcall ReadIniFile(AnsiString aIniFileName);
bool __fastcall WriteIniFile(AnsiString aIniFileName);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   MailCount=0;
   CurrMsg=0;

   RetrieveHeaderStart=false;
   RetrieveHeaderStop=false;
   RetrieveRawStart=false;
   RetrieveRawStop=false;

   HeaderSize=0;
   MsgSize=0;
   OldPartsCount=0;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ReadIniFile(ChangeFileExt(Application->ExeName,".ini"));
   EMailPageControl->ActivePage=POP3TabSheet;
   POP3UpdateButtons();

   POP3StatusWindowMemo->Lines->Add("IdPOP3->Version="+IdPOP3->Version);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(IdPOP3->Connected())
     {
        IdPOP3->Disconnect();

        if(IdLogDebugPOP3->Active)
          IdLogDebugPOP3->Active=false;
     }

   WriteIniFile(ChangeFileExt(Application->ExeName,".ini"));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3ConnectDisconnectButtonClick(TObject *Sender)
{
   try
     {
        if(IdPOP3->Connected())
          {
             POP3StatusWindowMemo->Lines->Add("IdPOP3->Disconnect() b4");
             IdPOP3->Disconnect();
             POP3StatusWindowMemo->Lines->Add("IdPOP3->Disconnect() after");

             if(IdLogDebugPOP3->Active)
               IdLogDebugPOP3->Active=false;

             POP3UpdateButtons();
             return;
          }

        POP3StatusWindowMemo->Clear();

        if(POP3IdLogDebugToFileCheckBox->Checked)
          {
             IdLogDebugPOP3->Target=ltFile;
             IdLogDebugPOP3->Filename=ChangeFileExt(Application->ExeName,".log");
             if(FileExists(IdLogDebugPOP3->Filename))
               DeleteFile(IdLogDebugPOP3->Filename);
          }
        else
          IdLogDebugPOP3->Target=ltEvent;

        IdLogDebugPOP3->Active=IdLogDebugCheckBox->Checked;

        IdPOP3->Host=POP3HostEdit->Text.Trim();
        IdPOP3->UserId=POP3UserIDEdit->Text.Trim();
        IdPOP3->Password=POP3PasswordEdit->Text.Trim();

        POP3StatusWindowMemo->Lines->Add("IdPOP3->Connect() b4");
        IdPOP3->Connect();
        POP3StatusWindowMemo->Lines->Add("IdPOP3->Connect() after");

        POP3StatusWindowMemo->Lines->Add("IdPOP3->CheckMessages() b4");
        MailCount=IdPOP3->CheckMessages();
        POP3StatusWindowMemo->Lines->Add("There are "+IntToStr(MailCount)+" message(s) in mailbox");
        POP3StatusWindowMemo->Lines->Add("IdPOP3->CheckMessages() after");

        POP3UpdateButtons();
     }
   catch(Exception &eException)
     {
        ShowMessage(eException.Message);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3UpdateButtons(void)
{
   bool
     Connected=IdPOP3->Connected();

   POP3ConnectDisconnectButton->Caption = Connected ? "Disconnect" : "Connect";
   POP3GetMailMessageButton->Enabled = Connected && MailCount;
   POP3SummarizeButton->Enabled = Connected && MailCount;
   POP3DeleteButton->Enabled = Connected && MailCount;
   POP3ResetButton->Enabled = Connected && MailCount;

   IdLogDebugCheckBox->Enabled = !Connected;
   POP3IdLogDebugToFileCheckBox->Enabled = !Connected;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3Connected(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("IdPOP3 OnConnected");
/* Don't do this!!!
   try
     {
        POP3StatusWindowMemo->Lines->Add("IdPOP3->CheckMessages() b4");
        MailCount=IdPOP3->CheckMessages();
        POP3StatusWindowMemo->Lines->Add("IdPOP3->CheckMessages() after");
     }
   catch(Exception &eException)
     {
        ShowMessage(eException.Message);
     }
*/
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3Disconnected(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("IdPOP3 OnDisconnected");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3Status(TObject *axSender, const TIdStatus axStatus, const AnsiString asStatusText)
{
   AnsiString
     Mess="IdPOP3 OnStatus axSender="+axSender->ClassName()+" axStatus=";

   switch(axStatus)
     {
        case hsResolving :
          {
             Mess+="A host name is being resolved to an IP Address";
             break;
          }
	case hsConnecting :
          {
             Mess+="A connection is being opened";
             break;
          }
	case hsConnected :
          {
             Mess+="A connection has been made";
             break;
          }
	case hsDisconnecting :
          {
             Mess+="The connection is being closed";
             break;
          }
	case hsDisconnected :
          {
             Mess+="The connection has been closed";
             break;
          }
	case Idcomponent::hsText :
          {
             Mess+="The connection is generating an informational message";
             break;
          }
     }

   POP3StatusWindowMemo->Lines->Add(Mess+" asStatusText="+asStatusText);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3Work(TObject *Sender, TWorkMode AWorkMode, const int AWorkCount)
{
   AnsiString
     Mess="IdPOP3 OnWork ";

   static AnsiString
     FileName="";

   unsigned long int
     CountWorkCount;

   switch(AWorkMode)
     {
        case wmRead  : {
                          Mess+="The component is reading data from the peer (AWorkCount="+IntToStr(AWorkCount)+")";
                          break;
                       }
	case wmWrite : {
                          Mess+="The component is sending data to the peer (AWorkCount="+IntToStr(AWorkCount)+")";
                          break;
                       }
     }
   POP3StatusWindowMemo->Lines->Add(Mess);

   if(RetrieveHeaderStart && !RetrieveHeaderStop)
     HeaderSize=AWorkCount;

   POP3StatusWindowMemo->Lines->Add(IntToStr(HeaderSize));

   if(RetrieveRawStart)
     {
        CountWorkCount=HeaderSize+AWorkCount-3;

        TIdAttachment
          *Attachment=0;

        bool
          FileNameChanged=false;

        int
          PartsCount=IdMessagePOP3->MessageParts->Count;

        if(PartsCount && OldPartsCount!=PartsCount)
          {
             OldPartsCount=PartsCount;
             if(Attachment=dynamic_cast<TIdAttachment *>(IdMessagePOP3->MessageParts->Items[OldPartsCount-1]))
               {
                  if(FileName!=Attachment->FileName)
                    {
                       FileName=Attachment->FileName;
                       FileNameChanged=true;
                    }
                  else
                    FileNameChanged=false;
               }
          }
        /*
        for(int i=0; i<PartsCount; ++i)
           {
              POP3StatusWindowMemo->Lines->Add("IdMessagePOP3->MessageParts->Count="+IntToStr(PartsCount));
              if(Attachment=dynamic_cast<TIdAttachment *>(IdMessagePOP3->MessageParts->Items[i]))
                {
                   if(FileName!=Attachment->FileName)
                     {
                        FileName=Attachment->FileName;
                        FileNameChanged=true;
                     }
                   else
                     FileNameChanged=false;
                }
            }
         */
        if(FileNameChanged)
          {
             POP3StatusWindowMemo->Lines->Add("Attachment->FileName="+FileName);
             FileNamePOP3Label->Caption="\""+FileName+"\" -> \""+IncludeTrailingPathDelimiter(POP3AttachmentPathEdit->Text.Trim())+FileName+"\"";
             FileNamePOP3Label->Repaint();
             Application->ProcessMessages();
             FileNameChanged=false;
          }
     }
   else
     CountWorkCount=AWorkCount;

   POP3StatusWindowMemo->Lines->Add(IntToStr(CountWorkCount));
   CGaugePOP3->Progress=(CountWorkCount*100.)/MsgSize;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3WorkBegin(TObject *Sender, TWorkMode AWorkMode, const int AWorkCountMax)
{
   AnsiString
     Mess="IdPOP3 OnWorkBegin ";

   switch(AWorkMode)
     {
        case wmRead  : {
                          Mess+="The component is reading data from the peer (AWorkCountMax="+IntToStr(AWorkCountMax)+")";
                          break;
                       }
	case wmWrite : {
                          Mess+="The component is sending data to the peer (AWorkCountMax="+IntToStr(AWorkCountMax)+")";
                          break;
                       }
     }

   POP3StatusWindowMemo->Lines->Add(Mess);

   if(!RetrieveHeaderStart)
     {
        RetrieveHeaderStart=true;
        POP3StatusWindowMemo->Lines->Add("Start RetrieveHeaderStart");
     }

   if(!RetrieveRawStart && RetrieveHeaderStop)
     {
        RetrieveRawStart=true;
        POP3StatusWindowMemo->Lines->Add("Start RetrieveRawStart");
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdPOP3WorkEnd(TObject *Sender, TWorkMode AWorkMode)
{
   AnsiString
     Mess="IdPOP3 OnWorkEnd ";

   switch(AWorkMode)
     {
        case wmRead  : {
                          Mess+="The component is reading data from the peer";
                          break;
                       }
	case wmWrite : {
                          Mess+="The component is sending data to the peer";
                          break;
                       }
     }

   POP3StatusWindowMemo->Lines->Add(Mess);

   if(!RetrieveHeaderStop && RetrieveHeaderStart)
     {
        RetrieveHeaderStop=true;
        POP3StatusWindowMemo->Lines->Add("Stop RetrieveHeaderStop");
     }

   if(!RetrieveRawStop && RetrieveRawStart)
     {
        RetrieveRawStop=true;
        POP3StatusWindowMemo->Lines->Add("Stop RetrieveRawStop");
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdLogDebugPOP3LogItem(TComponent *ASender, AnsiString &AText)
{
   POP3StatusWindowMemo->Lines->Add("IdLogDebugPOP3 OnLogItem (AText="+AText+")");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdLogDebugPOP3Connect(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("IdLogDebugPOP3 OnConnect");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3GetMailMessageButtonClick(TObject *Sender)
{
   if(MailCount>0)
     {
        AnsiString
          S;

        if(InputQuery("Retrieve an E-Mail message","Which message? (1-"+IntToStr(MailCount)+")",S))
          {
             CurrMsg=StrToIntDef(S,-1);
             if(CurrMsg<0 || CurrMsg>MailCount)
               ShowMessage("Invalid message index");
             else
               {
                  try
                    {
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize() b4");
                       MsgSize=IdPOP3->RetrieveMsgSize(CurrMsg);
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize="+IntToStr(MsgSize));
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize() after");

                       RetrieveHeaderStart=false;
                       RetrieveHeaderStop=false;
                       RetrieveRawStart=false;
                       RetrieveRawStop=false;

                       HeaderSize=0;
                       OldPartsCount=0;

                       CGaugePOP3->Visible=true;
                       FileNamePOP3Label->Visible=true;
                       CGaugePOP3->Progress=0;

                       POP3MessageBodyMemo->Clear();

                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Retrieve() b4");
                       IdMessagePOP3->Clear();
                       IdPOP3->Retrieve(CurrMsg,IdMessagePOP3);
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Retrieve() after");

                       CGaugePOP3->Visible=false;
                       FileNamePOP3Label->Visible=false;
                       
                       POP3FromPersonThatSentTheEMailEdit->Text="Name="+IdMessagePOP3->From->Name+" From="+IdMessagePOP3->From->Address+" Text="+IdMessagePOP3->From->Text;
                       POP3SubjectOfTheEMailEdit->Text=IdMessagePOP3->Subject;
                       POP3MessageIDEdit->Text=IdMessagePOP3->MsgId;

                       TIdAttachment
                         *Attachment=0;

                       TIdText
                         *Text=0;

                       int
                         PartsCount=IdMessagePOP3->MessageParts->Count;

                       for(int i=0; i<PartsCount; ++i)
                          {
                             if(Text=dynamic_cast<TIdText *>(IdMessagePOP3->MessageParts->Items[i]))
                               {
                                  POP3MessageBodyMemo->Lines->AddStrings(Text->Body);
                               }
                             if(Attachment=dynamic_cast<TIdAttachment *>(IdMessagePOP3->MessageParts->Items[i]))
                               {
                                  POP3StatusWindowMemo->Lines->Add("Attachment->FileName="+Attachment->FileName);
                                  POP3StatusWindowMemo->Lines->Add("Attachment->Boundary="+Attachment->Boundary);
                                  Attachment->SaveToFile(IncludeTrailingPathDelimiter(POP3AttachmentPathEdit->Text.Trim())+Attachment->FileName);
                               }
                          }

                       if(POP3DeleteMessageAfterReadingCheckBox->Checked)
                         IdPOP3->Delete(CurrMsg);
                    }
                  catch(Exception &eException)
                    {
                       ShowMessage(eException.Message);
                    }
               }
          }
     }
   else
     ShowMessage("No Messages to Get");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3SummarizeButtonClick(TObject *Sender)
{
   if(MailCount>0)
     {
        int
          M;

        AnsiString
          S;

        if(InputQuery("Retrieve an E-Mail message","Which message? (1-"+IntToStr(MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if(M<0 ||M>MailCount)
               ShowMessage("Invalid message index");
             else
               {
                  try
                    {
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize() b4");
                       MsgSize=IdPOP3->RetrieveMsgSize(M);
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize="+IntToStr(MsgSize));
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveMsgSize() after");

                       RetrieveHeaderStart=false;
                       RetrieveHeaderStop=false;
                       RetrieveRawStart=false;
                       RetrieveRawStop=false;

                       HeaderSize=0;

                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveHeader() b4");
                       IdMessagePOP3->Clear();
                       IdPOP3->RetrieveHeader(M,IdMessagePOP3);
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->RetrieveHeader() after");

                       POP3FromPersonThatSentTheEMailEdit->Text="Name="+IdMessagePOP3->From->Name+" From="+IdMessagePOP3->From->Address+" Text="+IdMessagePOP3->From->Text;
                       POP3SubjectOfTheEMailEdit->Text=IdMessagePOP3->Subject;
                       POP3MessageIDEdit->Text=IdMessagePOP3->MsgId;
                    }
                  catch(Exception &eException)
                    {
                       ShowMessage(eException.Message);
                    }
               }
          }
     }
   else
     ShowMessage("No Messages to Summarize");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3DeleteButtonClick(TObject *Sender)
{
   if(MailCount>0)
     {
        int
          M;

        AnsiString
          S;

        if(InputQuery("Retrieve an E-Mail message","Which message? (1-"+IntToStr(MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if(M<0 ||M>MailCount)
               ShowMessage("Invalid message index");
             else
               {
                  try
                    {
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Delete() b4");
                       IdPOP3->Delete(M);
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Delete() after");
                    }
                  catch(Exception &eException)
                    {
                       ShowMessage(eException.Message);
                    }
               }
          }
     }
   else
     ShowMessage("No Messages to Delete");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3ResetButtonClick(TObject *Sender)
{
   if(MailCount>0)
     {
        int
          M;

        AnsiString
          S;

        if(InputQuery("Retrieve an E-Mail message","Which message? (1-"+IntToStr(MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if(M<0 ||M>MailCount)
               ShowMessage("Invalid message index");
             else
               {
                  try
                    {
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Reset() b4");
                       if(IdPOP3->Reset())
                         POP3StatusWindowMemo->Lines->Add("All messages has been reseted successfully");
                       else
                         POP3StatusWindowMemo->Lines->Add("Error reseting messages");
                       POP3StatusWindowMemo->Lines->Add("IdPOP3->Reset() after");
                    }
                  catch(Exception &eException)
                    {
                       ShowMessage(eException.Message);
                    }
               }
          }
     }
   else
     ShowMessage("No Messages to Reset");
}
//---------------------------------------------------------------------------

bool __fastcall ReadIniFile(AnsiString aIniFileName)
{
   if(!FileExists(aIniFileName))
     return false;

   TIniFile *IniFile=0;

   try
     {
        IniFile=new TIniFile(aIniFileName);
     }
   catch(std::bad_alloc)
     {
        Application->MessageBox("Insufficient memory",Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return false;
     }

   // POP3
   MainForm->POP3HostEdit->Text=IniFile->ReadString("POP3","Host","");
   MainForm->POP3UserIDEdit->Text=IniFile->ReadString("POP3","UserID","");
   MainForm->POP3PasswordEdit->Text=IniFile->ReadString("POP3","Password","");
   MainForm->POP3AttachmentPathEdit->Text=IniFile->ReadString("POP3","AttachmentPath","c:\\");

   delete IniFile;
   return true;
}
//---------------------------------------------------------------------------

bool __fastcall WriteIniFile(AnsiString aIniFileName)
{
   TIniFile *IniFile;

   try
     {
        IniFile=new TIniFile(aIniFileName);
     }
   catch(std::bad_alloc)
     {
        Application->MessageBox("Insufficient memory",Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return false;
     }

   // POP3
   IniFile->WriteString("POP3","Host",MainForm->POP3HostEdit->Text.Trim());
   IniFile->WriteString("POP3","UserID",MainForm->POP3UserIDEdit->Text.Trim());
   IniFile->WriteString("POP3","Password",MainForm->POP3PasswordEdit->Text.Trim());
   IniFile->WriteString("POP3","AttachmentPath",MainForm->POP3AttachmentPathEdit->Text.Trim());

   delete IniFile;
   return true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPConnectDisconnectButtonClick(TObject *Sender)
{

   IdMessagePOP3->Clear();
   IdMessagePOP3->ContentType="multipart/alternative";
   IdMessagePOP3->IsEncoded=true;
   IdMessagePOP3->CharSet="KOI8-R";
   IdMessagePOP3->ContentTransferEncoding="base64";

   TIdText
     *IdText=new TIdText(IdMessagePOP3->MessageParts,0);

   IdText->ContentType="text/plain; charset=koi8-r";
   IdText->Body->Add("Line# 1");
   IdText->Body->Add("Line# 2");
   IdText->Body->Add("Line# 3");

   IdText=new TIdText(IdMessagePOP3->MessageParts,0);
   IdText->ContentType="text/html";
   IdText->Body->LoadFromFile(ExtractFilePath(Application->ExeName)+"avatara.gif");

   IdMessagePOP3->From->Address="4others@mail.ru";
   IdMessagePOP3->Recipients->EMailAddresses="4others@ua.fm";
   IdMessagePOP3->Subject="Test TIdSMTP";

/*
     FIdMessage.ContentType := 'Multipart/Alternative';
  // text/plain part
  idtTextPart := TIdText.Create(FIdMessage.MessageParts, nil);
  idtTextPart.ContentType := 'text/plain';

  idtTextPart:= TIdText.Create(FIdMessage.MessageParts, nil);
  idtTextPart.ContentType := 'text/html';
  if FileExists(HtmlFileName)
    then idtTextPart.Body.LoadFromFile(HtmlFileName);
  idtTextPart.Body.Text := ReplaceRegExpr('(?im)\[%PERIOD%\]',
    idtTextPart.Body.Text,
    APeriod);
  idtTextPart.Body.Text := ReplaceRegExpr('(?im)\[%GOODS_TABLE%\]',
    idtTextPart.Body.Text,
    AGoodsList);

  FIdMessage.CharSet := 'windows-1251';
  FIdMessage.Subject := Subject;

  if FileExists(LogoFileName)
    then TIdAttachmentFile.Create(FIdMessage.MessageParts, LogoFileName);
*/
   IdLogDebugPOP3->Target=ltEvent;
   IdLogDebugPOP3->Active=true;

   IdSMTP->Host="smtp.mail.ru";
   IdSMTP->AuthenticationType=atLogin;
   IdSMTP->UserId="4others@mail.ru";
   IdSMTP->Password="password";
   IdSMTP->Connect();
   IdSMTP->Send(IdMessagePOP3);
   IdSMTP->Disconnect();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPConnected(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("IdSMTP OnConnected");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPDisconnected(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("IdSMTP OnDisconnected");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPStatus(TObject *axSender, const TIdStatus axStatus, const AnsiString asStatusText)
{
   AnsiString
     Mess="IdSMTP OnStatus axSender="+axSender->ClassName()+" axStatus=";

   switch(axStatus)
     {
        case hsResolving :
          {
             Mess+="A host name is being resolved to an IP Address";
             break;
          }
	case hsConnecting :
          {
             Mess+="A connection is being opened";
             break;
          }
	case hsConnected :
          {
             Mess+="A connection has been made";
             break;
          }
	case hsDisconnecting :
          {
             Mess+="The connection is being closed";
             break;
          }
	case hsDisconnected :
          {
             Mess+="The connection has been closed";
             break;
          }
	case Idcomponent::hsText :
          {
             Mess+="The connection is generating an informational message";
             break;
          }
     }

   POP3StatusWindowMemo->Lines->Add(Mess+" asStatusText="+asStatusText);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPWork(TObject *Sender, TWorkMode AWorkMode, const int AWorkCount)
{
//
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPWorkBegin(TObject *Sender, TWorkMode AWorkMode, const int AWorkCountMax)
{
   AnsiString
     Mess="IdSMTP OnWorkBegin ";

   switch(AWorkMode)
     {
        case wmRead  : {
                          Mess+="The component is reading data from the peer (AWorkCountMax="+IntToStr(AWorkCountMax)+")";
                          break;
                       }
	case wmWrite : {
                          Mess+="The component is sending data to the peer (AWorkCountMax="+IntToStr(AWorkCountMax)+")";
                          break;
                       }
     }

   POP3StatusWindowMemo->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdSMTPWorkEnd(TObject *Sender, TWorkMode AWorkMode)
{
   AnsiString
     Mess="IdSMTP OnWorkEnd ";

   switch(AWorkMode)
     {
        case wmRead  : {
                          Mess+="The component is reading data from the peer";
                          break;
                       }
	case wmWrite : {
                          Mess+="The component is sending data to the peer";
                          break;
                       }
     }

   POP3StatusWindowMemo->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

