//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#include <IniFiles.hpp>
#pragma hdrstop

#include "main.h"
#include "Tables.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

bool __fastcall ReadIniFile(AnsiString aIniFileName);
bool __fastcall WriteIniFile(AnsiString aIniFileName);
bool __fastcall ReadIniStrings(TIniFile *IniFile, AnsiString Section, TStrings *Strings);
bool __fastcall WriteIniStrings(TIniFile *IniFile, AnsiString Section, TStrings *Strings);
AnsiString __fastcall CheckAttachmentFileName(AnsiString FileName);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   long btnstyle=GetWindowLong(FTPDownloadRestoreCheckBox->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(FTPDownloadRestoreCheckBox->Handle,GWL_STYLE,btnstyle);

   ReadIniFile(ChangeFileExt(Application->ExeName,".ini"));

   POP3SummaryWorking=false;
   POP3GetMailMessageWorking=false;
   LastStatus="";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   EMailPageControl->ActivePage=POP3TabSheet;
   SMTPUpdateButtons();
   POP3UpdateButtons();
   FTPUpdateButtons();
   SMTPPostMessageDateEdit->Text=Now().DateTimeString();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   WriteIniFile(ChangeFileExt(Application->ExeName,".ini"));
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// POP3
//---------------------------------------------------------------------------
void __fastcall TMainForm::POP3ConnectDisconnectButtonClick(TObject *Sender)
{
   if(NMPOP3->Connected)
     NMPOP3->Disconnect();
   else
     {
        POP3AttachmentPathEdit->Text=POP3AttachmentPathEdit->Text.Trim();
        if(POP3AttachmentPathEdit->Text.IsEmpty())
          POP3AttachmentPathEdit->Text="c:\\";

        NMPOP3->Host=POP3HostEdit->Text;
        NMPOP3->UserID=POP3UserIDEdit->Text;
        NMPOP3->Password=POP3PasswordEdit->Text;
        NMPOP3->DeleteOnRead=POP3DeleteMessageAfterReadingCheckBox->Checked;
        NMPOP3->AttachFilePath=POP3AttachmentPathEdit->Text;
        switch(POP3ReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMPOP3->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMPOP3->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMPOP3->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMPOP3->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMPOP3->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
          }
        try
          {
             NMPOP3->Connect();
          }
        catch(Exception &eException)
          {
             ShowMessage(eException.Message+" "+LastStatus);
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3GetMailMessageButtonClick(TObject *Sender)
{
   AnsiString S;
   int M;

   if(NMPOP3->MailCount>0)
     {
        switch(POP3ReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMPOP3->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMPOP3->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMPOP3->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMPOP3->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMPOP3->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
          }
        if(InputQuery("Retrieve an E-Mail message","Which message? (1-"+IntToStr(NMPOP3->MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if((M<0)||(M>NMPOP3->MailCount))
               ShowMessage("Invalid message index");
             else
               {
                  POP3GetMailMessageWorking=true;
                  NMPOP3->GetMailMessage(M);
               }
          }
     }
   else
     ShowMessage("No Messages to Get");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3SummarizeButtonClick(TObject *Sender)
{
   AnsiString S;
   int M;

   if(NMPOP3->MailCount>0)
     {
        switch(POP3ReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMPOP3->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMPOP3->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMPOP3->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMPOP3->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMPOP3->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
          }
        if(InputQuery("Retrieve a Summary","Which message? (1-"+IntToStr(NMPOP3->MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if((M<0) || (M>NMPOP3->MailCount))
               ShowMessage("Invalid message index");
             else
               {
                  POP3SummaryWorking=true;
                  NMPOP3->GetSummary(M);
                  POP3MessageIDEdit->Text=NMPOP3->UniqueID(M);
               }
          }
     }
   else
     ShowMessage("No Messages to Summarize");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3DeleteButtonClick(TObject *Sender)
{
   AnsiString S;
   int M;

   if(NMPOP3->MailCount>0)
     {
        switch(POP3ReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMPOP3->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMPOP3->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMPOP3->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMPOP3->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMPOP3->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMPOP3->ReportLevel=Status_None;
                          break;
                       }
          }
        if(InputQuery("Delete a Message","Which message? (1-"+IntToStr(NMPOP3->MailCount)+")",S))
          {
             M=StrToIntDef(S,-1);
             if((M<0) || (M>NMPOP3->MailCount))
               ShowMessage("Invalid message index");
             else
               NMPOP3->DeleteMailMessage(M);
          }
     }
   else
     ShowMessage("No Messages to Delete");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3ResetButtonClick(TObject *Sender)
{
   switch(POP3ReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMPOP3->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMPOP3->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMPOP3->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMPOP3->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMPOP3->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMPOP3->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMPOP3->ReportLevel=Status_None;
                     break;
                  }
     }
   NMPOP3->Reset();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3AuthenticationFailed(bool &Handled)
{
   AnsiString NewPass, NewID;
   if(MessageDlg("Authentication Failed. Retry?",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrYes)
     {
        NewPass=NMPOP3->Password;
        NewID=NMPOP3->UserID;
        InputQuery("Authentication Failed","Input User ID",NewID);
        InputQuery("Authentication Failed","Input Password",NewPass);
        NMPOP3->Password=NewPass;
        NMPOP3->UserID=NewID;
        Handled=true;
     }
   else
     Handled=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3AuthenticationNeeded(bool &Handled)
{
   AnsiString NewPass,NewID;
   NewPass=NMPOP3->Password;
   NewID=NMPOP3->UserID;
   InputQuery("Authorization Needed","Input User ID",NewID);
   InputQuery("Authorization Needed","Input Password",NewPass);
   NMPOP3->UserID=NewID;
   NMPOP3->Password=NewPass;
   Handled=TRUE;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Connect(TObject *Sender)
{
   if(NMPOP3->MailCount>0)
     {
        ShowMessage(IntToStr(NMPOP3->MailCount)+" messages in your mailbox");
        NMPOP3->List();
     }
   else
     ShowMessage("No messages waiting");
   POP3UpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3ConnectionFailed(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Connection Failed");
   POP3UpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3ConnectionRequired(bool &Handled)
{
   if(MessageDlg("Connection Required",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrYes)
     {
        NMPOP3->Connect();
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3DecodeEnd(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("DecodeEnd");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3DecodeStart(AnsiString &FileName)
{
   FileName=CheckAttachmentFileName(FileName);

   AnsiString S;

   S=FileName;
   if(InputQuery("Save File Attachment", "Filename?", S))
     FileName=S;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Disconnect(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Disconnected");
   POP3UpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Failure(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Operation Failed");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3HostResolved(TComponent *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Host Resolved");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3InvalidHost(bool &Handled)
{
   AnsiString TmpStr=NMPOP3->Host;

   if(InputQuery("Invalid Host!","Specify a new host:",TmpStr))
     {
        NMPOP3->Host=TmpStr;
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3List(int Msg, int Size)
{
   POP3StatusWindowMemo->Lines->Add("Message "+IntToStr(Msg)+": "+IntToStr(Size)+" bytes");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3PacketRecvd(TObject *Sender)
{
   if(NMPOP3->BytesTotal)
     POP3StatusWindowMemo->Lines->Add(IntToStr(NMPOP3->BytesRecvd)+" bytes out of "+IntToStr(NMPOP3->BytesTotal)+" transferred ("+FloatToStrF((NMPOP3->BytesRecvd*100./NMPOP3->BytesTotal),ffFixed,18,2)+"%)");
   else
     POP3StatusWindowMemo->Lines->Add(IntToStr(NMPOP3->BytesRecvd)+" bytes out of "+IntToStr(NMPOP3->BytesTotal)+" transferred");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Reset(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Delete flags reset");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3RetrieveEnd(TObject *Sender)
{
   if(POP3SummaryWorking)
     {
        POP3FromPersonThatSentTheEMailEdit->Text=NMPOP3->Summary->From.Trim();
        POP3SubjectOfTheEMailEdit->Text=NMPOP3->Summary->Subject.Trim();
        POP3MemoLabelLabel->Caption="Summary";
        POP3MessageBodyMemo->Text=NMPOP3->Summary->Header->Text;
        POP3StatusWindowMemo->Lines->Add("Summary retrieved");
        POP3SummaryWorking=false;
     }
   if(POP3GetMailMessageWorking)
     {
        POP3MemoLabelLabel->Caption="Message Body";

        POP3MessageBodyMemo->Clear();
        POP3MessageBodyMemo->Lines->Add("Header");
        POP3MessageBodyMemo->Lines->Add(AnsiString::StringOfChar('-',20));
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->AddStrings(NMPOP3->MailMessage->Head);
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->Add("RawBody");
        POP3MessageBodyMemo->Lines->Add(AnsiString::StringOfChar('-',20));
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->AddStrings(NMPOP3->MailMessage->RawBody);
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->Add("Body");
        POP3MessageBodyMemo->Lines->Add(AnsiString::StringOfChar('-',20));
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->AddStrings(NMPOP3->MailMessage->Body);
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->Add("Attachment");
        POP3MessageBodyMemo->Lines->Add(AnsiString::StringOfChar('-',20));
        POP3MessageBodyMemo->Lines->Add("");
        POP3MessageBodyMemo->Lines->AddStrings(NMPOP3->MailMessage->Attachments);
        POP3SubjectOfTheEMailEdit->Text=NMPOP3->MailMessage->Subject;
        POP3FromPersonThatSentTheEMailEdit->Text=NMPOP3->MailMessage->From;

        int Pos;
        AnsiString Delim="";

        for(int i=0; i<NMPOP3->MailMessage->Head->Count; i++)
           {
              Pos=NMPOP3->MailMessage->Head->Strings[i].LowerCase().Pos("boundary=");
              if(Pos)
                {
                   Delim=NMPOP3->MailMessage->Head->Strings[i].Delete(1,Pos+9);
                   Pos=Delim.Pos("\"");
                   if(Pos)
                     {
                        Delim.Delete(Pos,1);
                        break;
                     }
                   else
                     Delim="";
                }
           }

        if(!Delim.IsEmpty())
          {
             AnsiString Line,FileName,CodeTable;
             std::fstream DetachFile;
             unsigned long BytesOut;
             bool ContentType,ContentTransferEncoding,ContentDisposition;

             for(int i=0; i<NMPOP3->MailMessage->RawBody->Count; i++)
                {
                   ContentType=ContentTransferEncoding=ContentDisposition=false;
                   FileName="";

                   do
                     {
                        Line=NMPOP3->MailMessage->RawBody->Strings[i++];
                        if(Line.Pos("Content-Type: application/octet-stream"))
                          {
                             ContentType=true;
                             continue;
                          }

                        if(Line.Pos("Content-Transfer-Encoding: base64"))
                          {
                             ContentTransferEncoding=true;
                             continue;
                          }

                        if(Line.Pos("Content-Disposition: attachment"))
                          {
                             ContentDisposition=true;

                             if(!(Pos=Line.LowerCase().Pos("filename=")))
                               continue;

                             FileName=Line.SubString(Pos+10,Line.Length()-Pos-10+1);

                             if(!(Pos=FileName.Pos("\"")))
                               continue;
                             FileName.Delete(Pos,FileName.Length()-Pos+1);
                             FileName=CheckAttachmentFileName(FileName);
                             continue;
                          }
                     }while(!Line.IsEmpty() && i<NMPOP3->MailMessage->RawBody->Count);

                   if(ContentType && ContentTransferEncoding && ContentDisposition && !FileName.IsEmpty())
                     {
                        Line="";
                        do
                          {
                             Pos=NMPOP3->MailMessage->RawBody->Strings[i].Pos("=");
                             if(!NMPOP3->MailMessage->RawBody->Strings[i].IsEmpty())
                               {
                                  if(!Pos)
                                    Line+=NMPOP3->MailMessage->RawBody->Strings[i];
                                  else
                                    Line+=NMPOP3->MailMessage->RawBody->Strings[i].SubString(1,Pos-1);
                               }
                             i++;
                          }while(!Pos);

                        IdBase64Decoder->Reset();
                        IdBase64Decoder->AutoCompleteInput=true;
                        //IdBase64Decoder->TakesFileName=true;
                        //IdBase64Decoder->FileName=FileName+".aaa";
                        //IdBase64Decoder->UseEvent=true;
                        //IdBase64Decoder->OnCodedData=IdBase64DecoderCodedData;
                        //IdBase64Decoder->OnNotification=IdBase64DecoderNotification;
                        IdBase64Decoder->BytesOut.H=0;
                        IdBase64Decoder->BytesOut.L=0;
                        Line=IdBase64Decoder->CodeString(Line);
                        Pos=Line.Pos(";");
                        Line=Line.Delete(1,Pos);

                        FileName=IncludeTrailingPathDelimiter(NMPOP3->AttachFilePath)+FileName;

                        DetachFile.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc|std::ios_base::binary);
                        if(!DetachFile.good())
                          continue;

                        BytesOut = IdBase64Decoder->BytesOut.H<<16 | IdBase64Decoder->BytesOut.L;

                        DetachFile.write(Line.c_str(),BytesOut);
                        DetachFile.close();
                     }
                }
          }

        POP3StatusWindowMemo->Lines->Add("GetMailMessage retrieved");
        POP3GetMailMessageWorking=false;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3RetrieveStart(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Retrieving Summary");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Status(TComponent *Sender, AnsiString Status)
{
   LastStatus=Status;
   POP3StatusWindowMemo->Lines->Add(Status);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMPOP3Success(TObject *Sender)
{
   POP3StatusWindowMemo->Lines->Add("Message get successfully");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::POP3UpdateButtons(void)
{
   POP3ConnectDisconnectButton->Caption=NMPOP3->Connected?"Disconnect":"Connect";
   POP3GetMailMessageButton->Enabled=NMPOP3->Connected && NMPOP3->MailCount;
   POP3SummarizeButton->Enabled=NMPOP3->Connected;
   POP3DeleteButton->Enabled=NMPOP3->Connected;
   POP3ResetButton->Enabled=NMPOP3->Connected;
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// End POP3
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// SMTP
//---------------------------------------------------------------------------
void __fastcall TMainForm::SMTPConnectDisconnectButtonClick(TObject *Sender)
{
   if(NMSMTP->Connected)
     NMSMTP->Disconnect();
   else
     {
        NMSMTP->Host=SMTPHostEdit->Text;
        NMSMTP->UserID=SMTPUserIDEdit->Text;
        switch(SMTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMSMTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMSMTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMSMTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMSMTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMSMTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMSMTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMSMTP->ReportLevel=Status_None;
                          break;
                       }
          }
        try
          {
             NMSMTP->Connect();
          }
        catch(Exception &eException)
          {
             ShowMessage(eException.Message);
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPSendMailButtonClick(TObject *Sender)
{
   if(NMSMTP->Connected)
     {
        NMSMTP->ClearParams=SMTPClearParamsPropertyCheckBox->Checked;
        NMSMTP->SubType=mtPlain;
        switch(SMTPEncodeMethodRadioGroup->ItemIndex)
          {
             case 0: {
                        NMSMTP->EncodeType=uuMime;
                        break;
                     }
             case 1: {
                        NMSMTP->EncodeType=uuCode;
                        break;
                     }
          }
        NMSMTP->Charset=CharsetComboBox->Text;
        switch(SMTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMSMTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMSMTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMSMTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMSMTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMSMTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMSMTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMSMTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMSMTP->PostMessage->FromAddress=SMTPPostMessageFromAddressEdit->Text;
        NMSMTP->PostMessage->FromName=SMTPPostMessageFromNameEdit->Text;
        NMSMTP->PostMessage->ToAddress->Text=SMTPPostMessageToAddressMemo->Text;
        NMSMTP->PostMessage->ToCarbonCopy->Text=SMTPPostMessageToCarbonCopyMemo->Text;
        NMSMTP->PostMessage->ToBlindCarbonCopy->Text=SMTPPostMessageToBlindCarbonCopyMemo->Text;
        NMSMTP->PostMessage->Body->Text=SMTPPostMessageBodyMemo->Text;
        NMSMTP->PostMessage->Attachments->Text=SMTPPostMessageAttachmentsListBox->Items->Text;
        NMSMTP->PostMessage->Subject=SMTPPostMessageSubjectEdit->Text;
        NMSMTP->PostMessage->LocalProgram=SMTPPostMessageLocalProgramEdit->Text;
        NMSMTP->PostMessage->Date=SMTPPostMessageDateEdit->Text;
        NMSMTP->PostMessage->ReplyTo=SMTPPostMessageReplyToEdit->Text;
        NMSMTP->SendMail();
     }
   else
     ShowMessage("You need to connect before you can send your message");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPClearsEditFieldsAndParametersButtonClick(TObject *Sender)
{
   NMSMTP->ClearParameters();
   SMTPPostMessageDateEdit->Clear();
   SMTPPostMessageFromAddressEdit->Clear();
   SMTPPostMessageFromNameEdit->Clear();
   SMTPPostMessageLocalProgramEdit->Clear();
   SMTPPostMessageReplyToEdit->Clear();
   SMTPPostMessageSubjectEdit->Clear();
   SMTPPostMessageToAddressMemo->Clear();
   SMTPPostMessageToBlindCarbonCopyMemo->Clear();
   SMTPPostMessageToCarbonCopyMemo->Clear();
   SMTPPostMessageBodyMemo->Clear();
   SMTPStatusWindowMemo->Clear();
   SMTPPostMessageAttachmentsListBox->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPExpandListButtonClick(TObject *Sender)
{
   if(!NMSMTP->ExpandList(SMTPNameOfTheMailingListToExpandEdit->Text))
     ShowMessage("ExpandList failed (unsupported or list not found)");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPPostMessageAttachmentsListBoxKeyDown(TObject *Sender, WORD &Key, TShiftState Shift)
{
   if(Key==VK_INSERT)
     if(OpenDialog1->Execute())
       SMTPPostMessageAttachmentsListBox->Items->Add(OpenDialog1->FileName);
   if(Key==VK_DELETE)
     SMTPPostMessageAttachmentsListBox->Items->Delete(SMTPPostMessageAttachmentsListBox->ItemIndex);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPAttachmentNotFound(AnsiString Filename)
{
   SMTPStatusWindowMemo->Lines->Add("File attachment "+Filename+" not found");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPAuthenticationFailed(bool &Handled)
{
   AnsiString S;
   S=NMSMTP->UserID;
   if(InputQuery("Authentication Failed","Invalid User ID. New User ID: ", S))
     {
        NMSMTP->UserID=S;
        Handled=TRUE;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPConnect(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Connected");
   SMTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPConnectionFailed(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Connection Failed");
   SMTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPConnectionRequired(bool &Handled)
{
   if(MessageDlg("Connection Required",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrYes)
     {
        NMSMTP->Connect();
        Handled=true;
    }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPDisconnect(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Disconnected");
   SMTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPEncodeEnd(AnsiString Filename)
{
   SMTPStatusWindowMemo->Lines->Add(Filename+" encoded");
}
//---------------------------------------------------------------------------


void __fastcall TMainForm::NMSMTPEncodeStart(AnsiString Filename)
{
   SMTPStatusWindowMemo->Lines->Add("Encoding "+Filename);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPFailure(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Message delivery failure");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPHeaderIncomplete(bool &handled, int hiType)
{
   AnsiString S;

   switch(hiType)
     {
        case hiFromAddress : {
                                if(InputQuery("Missing From Address","Enter From Address: ",S))
                                  {
                                     NMSMTP->PostMessage->FromAddress=S;
                                     handled=TRUE;
                                  }
                                break;
                             }
        case hiToAddress   : {
                                if(InputQuery("Missing To Address","Enter To Address: ",S))
                                  {
                                     NMSMTP->PostMessage->ToAddress->Text=S;
                                     handled=TRUE;
                                  }
                                break;
                             }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPHostResolved(TComponent *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Host Resolved");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPInvalidHost(bool &Handled)
{
   AnsiString TmpStr=NMSMTP->Host;
   if(InputQuery("Invalid Host!","Specify a new host:",TmpStr))
     {
        NMSMTP->Host=TmpStr;
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPMailListReturn(AnsiString MailAddress)
{
   SMTPStatusWindowMemo->Lines->Add(MailAddress);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPPacketSent(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add(IntToStr(NMSMTP->BytesSent)+" bytes out of "+IntToStr(NMSMTP->BytesTotal)+" transferred ("+FloatToStrF((NMSMTP->BytesSent*100./NMSMTP->BytesTotal),ffFixed,18,2)+"%)");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPRecipientNotFound(AnsiString Recipient)
{
   SMTPStatusWindowMemo->Lines->Add("Recipient "+Recipient+" not found");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPSendStart(TObject *Sender)
{
   NMSMTP->FinalHeader->Values["Importance"]="High";
   NMSMTP->FinalHeader->Values["X-Priority"]="1 (High)";

   NMSMTP->FinalHeader->Values["X-Confirm-Reading-To"]=NMSMTP->PostMessage->FromAddress; // подтверждение о прочтении
   NMSMTP->FinalHeader->Values["Disposition-Notification-To"]=NMSMTP->PostMessage->FromAddress; // подтверждение о прочтении
   NMSMTP->FinalHeader->Values["Return-Receipt-To"]=NMSMTP->PostMessage->FromAddress; // подтверждение о доставке

   SMTPStatusWindowMemo->Lines->Add("Sending Message");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPStatus(TComponent *Sender, AnsiString Status)
{
   SMTPStatusWindowMemo->Lines->Add(Status);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMSMTPSuccess(TObject *Sender)
{
   SMTPStatusWindowMemo->Lines->Add("Message sent successfully");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SMTPUpdateButtons(void)
{
   SMTPConnectDisconnectButton->Caption=NMSMTP->Connected?"Disconnect":"Connect";
   SMTPSendMailButton->Enabled=NMSMTP->Connected;
   SMTPClearsEditFieldsAndParametersButton->Enabled=NMSMTP->Connected;
   SMTPExpandListButton->Enabled=NMSMTP->Connected;
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// End SMTP
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// FTP
//---------------------------------------------------------------------------
void __fastcall TMainForm::FTPConnectDisconnectButtonClick(TObject *Sender)
{
   if(NMFTP->Connected)
     NMFTP->Disconnect();
   else
     {
        NMFTP->Vendor=NMOS_AUTO;
        NMFTP->Host=FTPHostEdit->Text;
        NMFTP->UserID=FTPUserIDEdit->Text;
        NMFTP->Password=FTPPasswordEdit->Text;
        switch(FTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMFTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMFTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMFTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMFTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMFTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMFTP->Connect();
    }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPListButtonClick(TObject *Sender)
{
   switch(FTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMFTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMFTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMFTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMFTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMFTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMFTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMFTP->ReportLevel=Status_None;
                     break;
                  }
     }
   FTPListMemo->Clear();
   NMFTP->ParseList=FTPParseListCheckBox->Checked;
   switch(FTPTypeListRadioGroup->ItemIndex)
     {
        case 0: {
                   NMFTP->List();
                   break;
                }
        case 1: {
                    NMFTP->Nlist();
                    break;
                }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPChangeDirButtonClick(TObject *Sender)
{
   AnsiString TheDir;

   if(InputQuery("Change directory","Directory name?",TheDir))
     {
        switch(FTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMFTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMFTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMFTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMFTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMFTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMFTP->ChangeDir(TheDir);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPDownloadButtonClick(TObject *Sender)
{
   AnsiString RemoteFile,LocalFile;

   TOpenDialog *O=new TOpenDialog(this);
   if(InputQuery("Download a file","File to download: ",RemoteFile))
     {
        O->Title="Save file as";
        if(O->Execute())
          {
             LocalFile=O->FileName;
             switch(FTPTransferModeRadioGroup->ItemIndex)
               {
                  case 0: {
                             NMFTP->Mode(MODE_ASCII);
                             break;
                          }
                  case 1: {
                             NMFTP->Mode(MODE_IMAGE);
                             break;
                          }
                  case 2: {
                             NMFTP->Mode(MODE_BYTE);
                             break;
                          }
               }
             switch(FTPReportLevelComboBox->ItemIndex)
               {
                  case 0  : {
                               NMFTP->ReportLevel=Status_None;
                               break;
                            }
                  case 1  : {
                               NMFTP->ReportLevel=Status_Informational;
                               break;
                            }
                  case 2  : {
                               NMFTP->ReportLevel=Status_Basic;
                               break;
                            }
                  case 3  : {
                               NMFTP->ReportLevel=Status_Routines;
                               break;
                            }
                  case 4  : {
                               NMFTP->ReportLevel=Status_Debug;
                               break;
                            }
                  case 5  : {
                               NMFTP->ReportLevel=Status_Trace;
                               break;
                            }
                  default : {
                               NMFTP->ReportLevel=Status_None;
                               break;
                            }
               }
             if(FTPDownloadRestoreCheckBox->Checked)
               NMFTP->DownloadRestore(RemoteFile,LocalFile);
             else
               NMFTP->Download(RemoteFile,LocalFile);
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPUploadButtonClick(TObject *Sender)
{
   AnsiString LocalFile,RemoteFile;
   int FileHandle,FSize;

   TOpenDialog *O=new TOpenDialog(this);
   O->Title="Select file to upload";

   if(O->Execute())
     if(InputQuery("Choose Remote File Name","Filename?",RemoteFile))
       {
          LocalFile = O->FileName;
          switch(FTPTransferModeRadioGroup->ItemIndex)
            {
               case 0: {
                          NMFTP->Mode(MODE_ASCII);
                          break;
                       }
               case 1: {
                          NMFTP->Mode(MODE_IMAGE);
                          break;
                       }
               case 2: {
                          NMFTP->Mode(MODE_BYTE);
                          break;
                       }
            }
          switch(FTPReportLevelComboBox->ItemIndex)
            {
               case 0  : {
                            NMFTP->ReportLevel=Status_None;
                            break;
                         }
               case 1  : {
                            NMFTP->ReportLevel=Status_Informational;
                            break;
                         }
               case 2  : {
                            NMFTP->ReportLevel=Status_Basic;
                            break;
                         }
               case 3  : {
                            NMFTP->ReportLevel=Status_Routines;
                            break;
                         }
               case 4  : {
                            NMFTP->ReportLevel=Status_Debug;
                            break;
                         }
               case 5  : {
                            NMFTP->ReportLevel=Status_Trace;
                            break;
                         }
               default : {
                            NMFTP->ReportLevel=Status_None;
                            break;
                         }
            }
          FileHandle=FileOpen(LocalFile,fmOpenRead);
          FSize=FileSeek(FileHandle,0,2);
          FileClose(FileHandle);
          NMFTP->Allocate(FSize);
          NMFTP->Upload(LocalFile, RemoteFile);
       }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPUploadAppendButtonClick(TObject *Sender)
{
   AnsiString LocalFile,RemoteFile;

   TOpenDialog *O=new TOpenDialog(this);
   O->Title="Select file to upload";

   if(O->Execute())
     if(InputQuery("Choose Remote File Name","Filename?",RemoteFile))
       {
          LocalFile=O->FileName;
          switch(FTPTransferModeRadioGroup->ItemIndex)
            {
              case 0: {
                         NMFTP->Mode(MODE_ASCII);
                         break;
                      }
              case 1: {
                         NMFTP->Mode(MODE_IMAGE);
                         break;
                      }
              case 2: {
                         NMFTP->Mode(MODE_BYTE);
                         break;
                      }
            }
          switch(FTPReportLevelComboBox->ItemIndex)
            {
               case 0  : {
                            NMFTP->ReportLevel=Status_None;
                            break;
                         }
               case 1  : {
                            NMFTP->ReportLevel=Status_Informational;
                            break;
                         }
               case 2  : {
                            NMFTP->ReportLevel=Status_Basic;
                            break;
                         }
               case 3  : {
                            NMFTP->ReportLevel=Status_Routines;
                            break;
                         }
               case 4  : {
                            NMFTP->ReportLevel=Status_Debug;
                            break;
                         }
               case 5  : {
                            NMFTP->ReportLevel=Status_Trace;
                            break;
                         }
               default : {
                            NMFTP->ReportLevel=Status_None;
                            break;
                         }
            }
          NMFTP->UploadAppend(LocalFile, RemoteFile);
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPUploadUniqueButtonClick(TObject *Sender)
{
   AnsiString LocalFile;

   TOpenDialog *O=new TOpenDialog(this);
   O->Title="Upload file";
   if(O->Execute())
     {
        LocalFile=O->FileName;
        switch(FTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMFTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMFTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMFTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMFTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMFTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMFTP->UploadUnique(LocalFile);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPUploadRestoreButtonClick(TObject *Sender)
{
   AnsiString LocalFile, RemoteFile, FPos;
   int FPosition;

   TOpenDialog *O=new TOpenDialog(this);
   O->Title = "Select file to upload";
   if(O->Execute())
     if(InputQuery("Choose Remote File Name","Filename?", RemoteFile))
       if(InputQuery("Choose restoration point","Byte Count: ",FPos))
         {
            FPosition=StrToInt(FPos);
            LocalFile = O->FileName;

            switch(FTPTransferModeRadioGroup->ItemIndex)
              {
                 case 0: {
                            NMFTP->Mode(MODE_ASCII);
                            break;
                         }
                 case 1: {
                            NMFTP->Mode(MODE_IMAGE);
                            break;
                         }
                 case 2: {
                            NMFTP->Mode(MODE_BYTE);
                            break;
                         }
              }
            switch(FTPReportLevelComboBox->ItemIndex)
              {
                 case 0  : {
                              NMFTP->ReportLevel=Status_None;
                              break;
                           }
                 case 1  : {
                              NMFTP->ReportLevel=Status_Informational;
                              break;
                           }
                 case 2  : {
                              NMFTP->ReportLevel=Status_Basic;
                              break;
                           }
                 case 3  : {
                              NMFTP->ReportLevel=Status_Routines;
                              break;
                           }
                 case 4  : {
                              NMFTP->ReportLevel=Status_Debug;
                              break;
                           }
                 case 5  : {
                              NMFTP->ReportLevel=Status_Trace;
                              break;
                           }
                 default : {
                              NMFTP->ReportLevel=Status_None;
                              break;
                           }
              }
            NMFTP->UploadRestore(LocalFile,RemoteFile,FPosition);
         }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPAbortButtonClick(TObject *Sender)
{
   switch(FTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMFTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMFTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMFTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMFTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMFTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMFTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMFTP->ReportLevel=Status_None;
                     break;
                  }
     }
   NMFTP->Abort();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPDoCommandButtonClick(TObject *Sender)
{
   if(!FTPDoCommandEdit->Text.IsEmpty())
     {
        switch(FTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMFTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMFTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMFTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMFTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMFTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMFTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMFTP->DoCommand(FTPDoCommandEdit->Text);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPAuthenticationFailed(bool &Handled)
{
   AnsiString ThePass, TheID;
   if(MessageDlg("Authentication Failed. Retry?",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrYes)
     {
        ThePass=NMFTP->Password;
        TheID=NMFTP->UserID;
        InputQuery("Reauthenticate","Enter User ID",TheID);
        InputQuery("Reauthenticate","Enter Password",ThePass);
        NMFTP->Password=ThePass;
        NMFTP->UserID=TheID;
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPAuthenticationNeeded(bool &Handled)
{
   AnsiString APass,AnID;

   if(NMFTP->Password=="")
     if(InputQuery("Password needed","Enter password: ",APass))
       {
          NMFTP->Password=APass;
          Handled=true;
       }
     else
       Handled=false;

   if(NMFTP->UserID=="")
     if(InputQuery("User ID needed","Enter User ID: ",AnID))
       {
          NMFTP->UserID=AnID;
          Handled=true;
       }
     else
       Handled=false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPConnect(TObject *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Connected");
   FTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPConnectionFailed(TObject *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Connection Failed");
   FTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPConnectionRequired(bool &Handled)
{
   if(MessageDlg("Connection Required",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrYes)
     {
        NMFTP->Connect();
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPDisconnect(TObject *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Disconnected");
   FTPUpdateButtons();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPError(TComponent *Sender,WORD Errno,AnsiString Errmsg)
{
   FTPStatusWindowMemo->Lines->Add("Error #"+IntToStr(Errno)+"("+Errmsg+")");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPFailure(bool &Handled, TCmdType Trans_Type)
{
  switch(Trans_Type)
    {
       case cmdChangeDir:   {
                               FTPStatusWindowMemo->Lines->Add("ChangeDir failure");
                               break;
                            }
       case cmdMakeDir:     {
                               FTPStatusWindowMemo->Lines->Add("MakeDir failure");
                               break;
                            }
       case cmdDelete:      {
                               FTPStatusWindowMemo->Lines->Add("Delete failure");
                               break;
                            }
       case cmdRemoveDir:   {
                               FTPStatusWindowMemo->Lines->Add("RemoveDir failure");
                               break;
                            }
       case cmdList:        {
                               FTPStatusWindowMemo->Lines->Add("List failure");
                               break;
                            }
       case cmdRename:      {
                               FTPStatusWindowMemo->Lines->Add("Rename failure");
                               break;
                            }
       case cmdUpRestore:   {
                               FTPStatusWindowMemo->Lines->Add("UploadRestore failure");
                               break;
                            }
       case cmdDownRestore: {
                               FTPStatusWindowMemo->Lines->Add("DownloadRestore failure");
                               break;
                            }
       case cmdDownload:    {
                               FTPStatusWindowMemo->Lines->Add("Download failure");
                               break;
                            }
       case cmdUpload:      {
                               FTPStatusWindowMemo->Lines->Add("Upload failure");
                               break;
                            }
       case cmdAppend:      {
                               FTPStatusWindowMemo->Lines->Add("UploadAppend failure");
                               break;
                            }
       case cmdReInit:      {
                               FTPStatusWindowMemo->Lines->Add("Reinitialize failure");
                               break;
                            }
       case cmdAllocate:    {
                               FTPStatusWindowMemo->Lines->Add("Allocate failure");
                               break;
                            }
       case cmdNList:       {
                               FTPStatusWindowMemo->Lines->Add("NList failure");
                               break;
                            }
       case cmdDoCommand:   {
                               FTPStatusWindowMemo->Lines->Add("DoCommand failure");
                               break;
                            }
       case cmdCurrentDir:  {
                               FTPStatusWindowMemo->Lines->Add("CurrentDir failure");
                               break;
                            }
    }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPHostResolved(TComponent *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Host Resolved");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPInvalidHost(bool &Handled)
{
   AnsiString TmpStr=NMFTP->Host;
   if(InputQuery("Invalid Host!", "Specify a new host:",TmpStr))
     {
        NMFTP->Host=TmpStr;
        Handled=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPListItem(AnsiString Listing)
{
   FTPListMemo->Lines->Add(Listing);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPPacketRecvd(TObject *Sender)
{
   unsigned long BytesRecvd=NMFTP->BytesRecvd,BytesTotal=NMFTP->BytesTotal;
   AnsiString tmp=IntToStr(BytesRecvd)+" bytes received out of "+IntToStr(BytesTotal);

   if(BytesTotal)
     tmp+=" ("+FloatToStrF((BytesRecvd*100./BytesTotal),ffFixed,18,2)+"%)";

   FTPStatusBar->SimpleText=tmp;
   FTPStatusWindowMemo->Lines->Add(tmp);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPPacketSent(TObject *Sender)
{
   unsigned long BytesSent=NMFTP->BytesSent,BytesTotal=NMFTP->BytesTotal;
   AnsiString tmp=IntToStr(BytesSent)+" bytes received out of "+IntToStr(BytesTotal);

   if(BytesTotal)
     tmp+=" ("+FloatToStrF((BytesSent*100./BytesTotal),ffFixed,18,2)+"%)";

   FTPStatusBar->SimpleText=tmp;
   FTPStatusWindowMemo->Lines->Add(tmp);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPStatus(TComponent *Sender, AnsiString Status)
{
   FTPStatusWindowMemo->Lines->Add(Status);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPSuccess(TCmdType Trans_Type)
{
  switch(Trans_Type)
    {
      case cmdChangeDir:   {
                              FTPStatusWindowMemo->Lines->Add("ChangeDir success");
                              break;
                           }
      case cmdMakeDir:     {
                              FTPStatusWindowMemo->Lines->Add("MakeDir success");
                              break;
                           }
      case cmdDelete:      {
                              FTPStatusWindowMemo->Lines->Add("Delete success");
                              break;
                           }
      case cmdRemoveDir:   {
                              FTPStatusWindowMemo->Lines->Add("RemoveDir success");
                              break;
                           }
      case cmdList:        {
                              FTPStatusWindowMemo->Lines->Add("List success");
                              if(NMFTP->FTPDirectoryList)
                                {
                                   int i;
                                   AnsiString tmp;

                                   for(i=0;i<NMFTP->FTPDirectoryList->name->Count;i++)
                                      {
                                         tmp=NMFTP->FTPDirectoryList->name->Strings[i];
                                         tmp+=" "+NMFTP->FTPDirectoryList->Size->Strings[i];
                                         tmp+=" "+NMFTP->FTPDirectoryList->ModifDate->Strings[i];
                                         tmp+=" "+NMFTP->FTPDirectoryList->Attribute->Strings[i];
                                         FTPListMemo->Lines->Add(tmp);
                                      }
                                   for(i=0;i<FTPStringGrid->ColCount;i++)
                                      FTPStringGrid->Cols[i]->Clear();
                                   FTPStringGrid->RowCount=NMFTP->FTPDirectoryList->name->Count+1;
                                   FTPStringGrid->ColCount=4;
                                   FTPStringGrid->Cells[0][0]="Filename";
                                   FTPStringGrid->Cells[1][0]="File Size";
                                   FTPStringGrid->Cells[2][0]="Modified Date";
                                   FTPStringGrid->Cells[3][0]="Attributes";
                                   for(i=0;i<NMFTP->FTPDirectoryList->name->Count;i++)
                                      {
                                         FTPStringGrid->Cells[0][i+1]=NMFTP->FTPDirectoryList->name->Strings[i];
                                         FTPStringGrid->Cells[1][i+1]=NMFTP->FTPDirectoryList->Size->Strings[i];
                                         FTPStringGrid->Cells[2][i+1]=NMFTP->FTPDirectoryList->ModifDate->Strings[i];
                                         FTPStringGrid->Cells[3][i+1]=NMFTP->FTPDirectoryList->Attribute->Strings[i];
                                      }
                                }
                              break;
                           }
      case cmdRename:      {
                              FTPStatusWindowMemo->Lines->Add("Rename success");
                              break;
                           }
      case cmdUpRestore:   {
                              FTPStatusWindowMemo->Lines->Add("UploadRestore success");
                              break;
                           }
      case cmdDownRestore: {
                              FTPStatusWindowMemo->Lines->Add("DownloadRestore success");
                              break;
                           }
      case cmdDownload:    {
                              FTPStatusWindowMemo->Lines->Add("Download success");
                              break;
                           }
      case cmdUpload:      {
                              FTPStatusWindowMemo->Lines->Add("Upload success");
                              break;
                           }
      case cmdAppend:      {
                              FTPStatusWindowMemo->Lines->Add("UploadAppend success");
                              break;
                           }
      case cmdReInit:      {
                              FTPStatusWindowMemo->Lines->Add("Reinitialize success");
                              break;
                           }
      case cmdAllocate:    {
                              FTPStatusWindowMemo->Lines->Add("Allocate success");
                              break;
                           }
      case cmdNList:       {
                              FTPStatusWindowMemo->Lines->Add("NList success");
                              break;
                           }
      case cmdDoCommand:   {
                              FTPStatusWindowMemo->Lines->Add("DoCommand success");
                              break;
                           }
      case cmdCurrentDir:  {
                              FTPStatusWindowMemo->Lines->Add("CurrentDir success");
                              break;
                           }
    }

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPTransactionStart(TObject *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Transaction Start");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPTransactionStop(TObject *Sender)
{
   FTPStatusWindowMemo->Lines->Add("Transaction Stop");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMFTPUnSupportedFunction(TCmdType Trans_Type)
{
   switch(Trans_Type)
     {
        case cmdChangeDir   : {
                                 FTPStatusWindowMemo->Lines->Add("ChangeDir not supported by this server");
                                 break;
                              }
        case cmdMakeDir     : {
                                 FTPStatusWindowMemo->Lines->Add("MakeDir not supported by this server");
                                 break;
                              }
        case cmdDelete      : {
                                 FTPStatusWindowMemo->Lines->Add("Delete not supported by this server");
                                 break;
                              }
        case cmdRemoveDir   : {
                                 FTPStatusWindowMemo->Lines->Add("RemoveDir not supported by this server");
                                 break;
                              }
        case cmdList        : {
                                 FTPStatusWindowMemo->Lines->Add("List not supported by this server");
                                 break;
                              }
        case cmdRename      : {
                                 FTPStatusWindowMemo->Lines->Add("Rename not supported by this server");
                                 break;
                              }
        case cmdUpRestore   : {
                                 FTPStatusWindowMemo->Lines->Add("UploadRestore not supported by this server");
                                 break;
                              }
        case cmdDownRestore : {
                                 FTPStatusWindowMemo->Lines->Add("DownloadRestore not supported by this server");
                                 break;
                              }
        case cmdDownload    : {
                                 FTPStatusWindowMemo->Lines->Add("Download not supported by this server");
                                 break;
                              }
        case cmdUpload      : {
                                 FTPStatusWindowMemo->Lines->Add("Upload not supported by this server");
                                 break;
                              }
        case cmdAppend      : {
                                 FTPStatusWindowMemo->Lines->Add("UploadAppend not supported by this server");
                                 break;
                              }
        case cmdReInit      : {
                                 FTPStatusWindowMemo->Lines->Add("Reinitialize not supported by this server");
                                 break;
                              }
        case cmdAllocate    : {
                                 FTPStatusWindowMemo->Lines->Add("Allocate not supported by this server");
                                 break;
                              }
        case cmdNList       : {
                                 FTPStatusWindowMemo->Lines->Add("NList not supported by this server");
                                 break;
                              }
        case cmdDoCommand   : {
                                 FTPStatusWindowMemo->Lines->Add("DoCommand not supported by this server");
                                 break;
                              }
        case cmdCurrentDir  : {
                                 FTPStatusWindowMemo->Lines->Add("CurrentDir not supported by this server");
                                 break;
                              }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FTPUpdateButtons(void)
{
   FTPConnectDisconnectButton->Caption=NMFTP->Connected?"Disconnect":"Connect";
   FTPListButton->Enabled=NMFTP->Connected;
   FTPChangeDirButton->Enabled=NMFTP->Connected;
   FTPDownloadButton->Enabled=NMFTP->Connected;
   FTPUploadButton->Enabled=NMFTP->Connected;
   FTPUploadAppendButton->Enabled=NMFTP->Connected;
   FTPUploadUniqueButton->Enabled=NMFTP->Connected;
   FTPUploadRestoreButton->Enabled=NMFTP->Connected;
   FTPAbortButton->Enabled=NMFTP->Connected;
   FTPDoCommandButton->Enabled=NMFTP->Connected;
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// End FTP
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// HTTP
//---------------------------------------------------------------------------
void __fastcall TMainForm::HTTPGetButtonClick(TObject *Sender)
{
   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }

   switch(HTTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMHTTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMHTTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMHTTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMHTTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMHTTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
     }
   NMHTTP->InputFileMode=CheckBoxInputFileMode->Checked;
   if(NMHTTP->InputFileMode && HTTPBodyDisplayMemo->Lines->Count && !HTTPBodyDisplayMemo->Lines->Strings[0].Trim().IsEmpty())
     NMHTTP->Body=HTTPBodyDisplayMemo->Lines->Strings[0].Trim();
   NMHTTP->Get(HTTPURLInputEdit->Text);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPHeadButtonClick(TObject *Sender)
{
   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }
   switch(HTTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMHTTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMHTTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMHTTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMHTTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMHTTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
     }
   NMHTTP->Head(HTTPURLInputEdit->Text);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPOptionsButtonClick(TObject *Sender)
{
   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }
   switch(HTTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMHTTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMHTTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMHTTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMHTTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMHTTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
     }
   NMHTTP->Options(HTTPURLInputEdit->Text);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPTraceButtonClick(TObject *Sender)
{
   AnsiString S;

   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }

   if(InputQuery("Trace Data Required","Input data to send as trace",S))
     {
        switch(HTTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMHTTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMHTTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMHTTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMHTTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMHTTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMHTTP->Trace(HTTPURLInputEdit->Text, S);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPPutButtonClick(TObject *Sender)
{
   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }

   if(OpenDialog1->Execute())
     {
        NMHTTP->OutputFileMode=true;
        switch(HTTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMHTTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMHTTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMHTTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMHTTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMHTTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMHTTP->Put(HTTPURLInputEdit->Text,OpenDialog1->FileName);
        NMHTTP->OutputFileMode=false;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPPostButtonClick(TObject *Sender)
{
   AnsiString S;

   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }

   if(InputQuery("Post Data Required","Input data to Post",S))
     {
        switch(HTTPReportLevelComboBox->ItemIndex)
          {
             case 0  : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
             case 1  : {
                          NMHTTP->ReportLevel=Status_Informational;
                          break;
                       }
             case 2  : {
                          NMHTTP->ReportLevel=Status_Basic;
                          break;
                       }
             case 3  : {
                          NMHTTP->ReportLevel=Status_Routines;
                          break;
                       }
             case 4  : {
                          NMHTTP->ReportLevel=Status_Debug;
                          break;
                       }
             case 5  : {
                          NMHTTP->ReportLevel=Status_Trace;
                          break;
                       }
             default : {
                          NMHTTP->ReportLevel=Status_None;
                          break;
                       }
          }
        NMHTTP->Post(HTTPURLInputEdit->Text, S);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::HTTPDeleteButtonClick(TObject *Sender)
{
   if(NMHTTP->Connected)
     {
        ShowMessage("Already connected");
        return;
     }
   switch(HTTPReportLevelComboBox->ItemIndex)
     {
        case 0  : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
        case 1  : {
                     NMHTTP->ReportLevel=Status_Informational;
                     break;
                  }
        case 2  : {
                     NMHTTP->ReportLevel=Status_Basic;
                     break;
                  }
        case 3  : {
                     NMHTTP->ReportLevel=Status_Routines;
                     break;
                  }
        case 4  : {
                     NMHTTP->ReportLevel=Status_Debug;
                     break;
                  }
        case 5  : {
                     NMHTTP->ReportLevel=Status_Trace;
                     break;
                  }
        default : {
                     NMHTTP->ReportLevel=Status_None;
                     break;
                  }
     }
   NMHTTP->Delete(HTTPURLInputEdit->Text);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPAboutToSend(TObject *Sender)
{
   NMHTTP->SendHeader->Values["If-Modified-Since"]= "Wed, 09 Sep 1998 10:49:15 GMT";
//  Memo3->Text = NMHTTP1->SendHeader->Text;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPAuthenticationNeeded(TObject *Sender)
{
   AnsiString AnID,APass;

   InputQuery("Authentication required","Enter a user ID",AnID);
   InputQuery("Authentication required", "Enter a password",APass);
   NMHTTP->HeaderInfo->UserId=AnID;
   NMHTTP->HeaderInfo->Password=APass;
   ShowMessage("Authentication information in place, please retry the previous command");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPConnect(TObject *Sender)
{
  HTTPStatusWindowMemo->Lines->Add("Connected");
  HTTPStatusWindowMemo->Lines->Add("Local Address: "+NMHTTP->LocalIP);
  HTTPStatusWindowMemo->Lines->Add("Remote Address: "+NMHTTP->RemoteIP);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPConnectionFailed(TObject *Sender)
{
   HTTPStatusWindowMemo->Lines->Add("Connection Failed");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPDisconnect(TObject *Sender)
{
   HTTPStatusWindowMemo->Lines->Add("Disconnected");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPFailure(CmdType Cmd)
{
   HTTPHeaderDisplayMemo->Text=NMHTTP->Header;
   HTTPBodyDisplayMemo->Text=NMHTTP->Body;
   switch(Cmd)
     {
       case CmdGET:     {
                           HTTPStatusWindowMemo->Lines->Add("HTTP GET Failed");
                           break;
                        }
       case CmdPOST:    {
                           HTTPStatusWindowMemo->Lines->Add("HTTP Post Failed");
                           break;
                        }
       case CmdHEAD:    {
                           HTTPStatusWindowMemo->Lines->Add("HTTP HEAD Failed");
                           break;
                        }
       case CmdOPTIONS: {
                           HTTPStatusWindowMemo->Lines->Add("HTTP OPTIONS Failed");
                           break;
                        }
       case CmdTRACE:   {
                           HTTPStatusWindowMemo->Lines->Add("HTTP TRACE Failed");
                           break;
                        }
       case CmdPUT:     {
                           HTTPStatusWindowMemo->Lines->Add("HTTP PUT Failed");
                           break;
                        }
       case CmdDELETE:  {
                           HTTPStatusWindowMemo->Lines->Add("HTTP Delete Failed");
                           break;
                        }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPHostResolved(TComponent *Sender)
{
   HTTPStatusWindowMemo->Lines->Add("Host Resolved");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPInvalidHost(bool &Handled)
{
   AnsiString TmpStr;
   if(InputQuery("Invalid Host!","Specify a new host:",TmpStr))
     {
        NMHTTP->Host=TmpStr;
        Handled=true;
    }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPPacketRecvd(TObject *Sender)
{
   unsigned long BytesRecvd=NMHTTP->BytesRecvd,BytesTotal=NMHTTP->BytesTotal;
   AnsiString tmp=IntToStr(BytesRecvd)+" bytes received out of "+IntToStr(BytesTotal);

   if(BytesTotal)
     tmp+=" ("+FloatToStrF((BytesRecvd*100./BytesTotal),ffFixed,18,2)+"%)";

   HTTPStatusWindowMemo->Lines->Add(tmp);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPPacketSent(TObject *Sender)
{
   unsigned long BytesSent=NMHTTP->BytesSent,BytesTotal=NMHTTP->BytesTotal;
   AnsiString tmp=IntToStr(BytesSent)+" bytes received out of "+IntToStr(BytesTotal);

   if(BytesTotal)
     tmp+=" ("+FloatToStrF((BytesSent*100./BytesTotal),ffFixed,18,2)+"%)";

   HTTPStatusWindowMemo->Lines->Add(tmp);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPRedirect(bool &Handled)
{
   if(MessageDlg("This site is redirecting you to another site. Allow redirect?",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo,0)==mrNo)
     Handled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPStatus(TComponent *Sender, AnsiString Status)
{
   HTTPStatusWindowMemo->Lines->Add(Status);
   HTTPStatusWindowMemo->Lines->Add("Last WinSock error: "+IntToStr(NMHTTP->LastErrorNo));
   if(NMHTTP->BeenCanceled)
     HTTPStatusWindowMemo->Lines->Add("Input/ouput operation canceled");
   if(NMHTTP->BeenTimedOut)
     HTTPStatusWindowMemo->Lines->Add("Operation timed out");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::NMHTTPSuccess(CmdType Cmd)
{
   if(NMHTTP->CookieIn!="")
     HTTPCookieDisplayMemo->Text=NMHTTP->CookieIn;
   HTTPHeaderDisplayMemo->Text=NMHTTP->Header;
   HTTPBodyDisplayMemo->Text=NMHTTP->Body;
   switch(Cmd)
     {
        case CmdGET:     {
                            HTTPStatusWindowMemo->Lines->Add("HTTP GET Successful");
                            break;
                         }
        case CmdPOST:    {
                            HTTPStatusWindowMemo->Lines->Add("HTTP POST Successful");
                            break;
                         }
        case CmdHEAD:    {
                            HTTPStatusWindowMemo->Lines->Add("HTTP HEAD Successful");
                            break;
                         }
        case CmdOPTIONS: {
                            HTTPStatusWindowMemo->Lines->Add("HTTP OPTIONS Successful");
                            break;
                         }
        case CmdTRACE:   {
                            HTTPStatusWindowMemo->Lines->Add("HTTP TRACE Successful");
                            break;
                         }
        case CmdPUT:     {
                            HTTPStatusWindowMemo->Lines->Add("HTTP PUT Successful");
                            break;
                         }
        case CmdDELETE:  {
                            HTTPStatusWindowMemo->Lines->Add("HTTP DELETE Successful");
                            break;
                         }
     }
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// End HTTP
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
   
   // SMTP
   MainForm->SMTPHostEdit->Text=IniFile->ReadString("SMTP","Host","");
   MainForm->SMTPUserIDEdit->Text=IniFile->ReadString("SMTP","UserID","");
   MainForm->SMTPPostMessageFromAddressEdit->Text=IniFile->ReadString("SMTP","PostMessageFromAddress","");
   MainForm->SMTPPostMessageFromNameEdit->Text=IniFile->ReadString("SMTP","PostMessageFromName","");
   MainForm->SMTPPostMessageLocalProgramEdit->Text=IniFile->ReadString("SMTP","PostMessageLocalProgram","");
   MainForm->SMTPPostMessageReplyToEdit->Text=IniFile->ReadString("SMTP","PostMessageReplyTo","");
   MainForm->SMTPPostMessageSubjectEdit->Text=IniFile->ReadString("SMTP","PostMessageSubject","");
   MainForm->SMTPNameOfTheMailingListToExpandEdit->Text=IniFile->ReadString("SMTP","NameOfTheMailingListToExpand","");
   ReadIniStrings(IniFile,"SMTPPostMessageToAddress",MainForm->SMTPPostMessageToAddressMemo->Lines);
   ReadIniStrings(IniFile,"SMTPPostMessageToCarbonCopy",MainForm->SMTPPostMessageToCarbonCopyMemo->Lines);
   ReadIniStrings(IniFile,"SMTPPostMessageToBlindCarbonCopy",MainForm->SMTPPostMessageToBlindCarbonCopyMemo->Lines);
   ReadIniStrings(IniFile,"SMTPPostMessageBody",MainForm->SMTPPostMessageBodyMemo->Lines);
   ReadIniStrings(IniFile,"SMTPPostMessageAttachments",MainForm->SMTPPostMessageAttachmentsListBox->Items);

   // FTP
   MainForm->FTPHostEdit->Text=IniFile->ReadString("FTP","Host","");
   MainForm->FTPUserIDEdit->Text=IniFile->ReadString("FTP","UserID","");
   MainForm->FTPPasswordEdit->Text=IniFile->ReadString("FTP","Password","");

   // HTTP
   MainForm->HTTPURLInputEdit->Text=IniFile->ReadString("HTTP","URL","");

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
   IniFile->WriteString("POP3","Host",MainForm->POP3HostEdit->Text);
   IniFile->WriteString("POP3","UserID",MainForm->POP3UserIDEdit->Text);
   IniFile->WriteString("POP3","Password",MainForm->POP3PasswordEdit->Text);
   IniFile->WriteString("POP3","AttachmentPath",MainForm->POP3AttachmentPathEdit->Text);

   // SMTP
   IniFile->WriteString("SMTP","Host",MainForm->SMTPHostEdit->Text);
   IniFile->WriteString("SMTP","UserID",MainForm->SMTPUserIDEdit->Text);
   IniFile->WriteString("SMTP","PostMessageFromAddress",MainForm->SMTPPostMessageFromAddressEdit->Text);
   IniFile->WriteString("SMTP","PostMessageFromName",MainForm->SMTPPostMessageFromNameEdit->Text);
   IniFile->WriteString("SMTP","PostMessageLocalProgram",MainForm->SMTPPostMessageLocalProgramEdit->Text);
   IniFile->WriteString("SMTP","PostMessageReplyTo",MainForm->SMTPPostMessageReplyToEdit->Text);
   IniFile->WriteString("SMTP","PostMessageSubject",MainForm->SMTPPostMessageSubjectEdit->Text);
   IniFile->WriteString("SMTP","NameOfTheMailingListToExpand",MainForm->SMTPNameOfTheMailingListToExpandEdit->Text);
   WriteIniStrings(IniFile,"SMTPPostMessageToAddress",MainForm->SMTPPostMessageToAddressMemo->Lines);
   WriteIniStrings(IniFile,"SMTPPostMessageToCarbonCopy",MainForm->SMTPPostMessageToCarbonCopyMemo->Lines);
   WriteIniStrings(IniFile,"SMTPPostMessageToBlindCarbonCopy",MainForm->SMTPPostMessageToBlindCarbonCopyMemo->Lines);
   WriteIniStrings(IniFile,"SMTPPostMessageBody",MainForm->SMTPPostMessageBodyMemo->Lines);
   WriteIniStrings(IniFile,"SMTPPostMessageAttachments",MainForm->SMTPPostMessageAttachmentsListBox->Items);

   // FTP
   IniFile->WriteString("FTP","Host",MainForm->FTPHostEdit->Text);
   IniFile->WriteString("FTP","UserID",MainForm->FTPUserIDEdit->Text);
   IniFile->WriteString("FTP","Password",MainForm->FTPPasswordEdit->Text);

   // HTTP
   IniFile->WriteString("HTTP","URL",MainForm->HTTPURLInputEdit->Text);

   delete IniFile;
   return true;
}
//---------------------------------------------------------------------------

bool __fastcall ReadIniStrings(TIniFile *IniFile, AnsiString Section, TStrings *Strings)
{
   int Count=IniFile->ReadInteger(Section,"Count",0);
   AnsiString Ident;

   for(int i=0; i<Count; i++)
      {
         Ident="Item"+IntToStr(i);
         Strings->Add(IniFile->ReadString(Section,Ident,""));
      }

   return true;
}
//---------------------------------------------------------------------------

bool __fastcall WriteIniStrings(TIniFile *IniFile, AnsiString Section, TStrings *Strings)
{
   int Count=Strings->Count;
   AnsiString Ident;

   IniFile->WriteInteger(Section,"Count",Count);
   for(int i=0; i<Count; i++)
      {
         Ident="Item"+IntToStr(i);
         IniFile->WriteString(Section,Ident,Strings->Strings[i]);
      }

   return true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdBase64DecoderCodedData(TComponent *aComponent, const AnsiString aString)
{
   AnsiString Mess="IdBase64Decoder OnCodedData ";

   Mess+=aComponent->ClassName();
   Mess+="::";
   Mess+=aComponent->Name;
   Mess+=" ";
   Mess+=aString;

   POP3StatusWindowMemo->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IdBase64DecoderNotification(TComponent *aComponent, int aInt, const AnsiString aString)
{
   AnsiString Mess="IdBase64Decoder OnNotification";

   Mess+=aComponent->ClassName();
   Mess+="::";
   Mess+=aComponent->Name;
   Mess+=" ";
   Mess+=IntToStr(aInt);
   Mess+=" ";
   Mess+=aString;

   POP3StatusWindowMemo->Lines->Add(Mess);
}
//---------------------------------------------------------------------------


AnsiString __fastcall CheckAttachmentFileName(AnsiString FileName)
{
   TIdBase64Decoder *IdBase64Decoder=0;

   try
     {
        try
          {
             IdBase64Decoder=new TIdBase64Decoder(0);
          }
        catch(std::bad_alloc)
          {
             FileName=ExtractFileName(__FILE__)+"("+__LINE__+"): Insufficient memory";
             throw Exception(FileName);
          }

        int Pos;
        AnsiString CodeTable;

        if(FileName.SubString(1,2)=="=?")
          {
             FileName=FileName.Delete(1,2);
             Pos=FileName.Pos("?");
             CodeTable=FileName.SubString(1,Pos-1);
             FileName=FileName.Delete(1,Pos);
             Pos=FileName.Pos("?");
             FileName=FileName.Delete(1,Pos);
             Pos=FileName.Pos("?");
             FileName=FileName.Delete(Pos,FileName.Length()-Pos+1);

             IdBase64Decoder->Reset();
             IdBase64Decoder->AutoCompleteInput=true;
             FileName=IdBase64Decoder->CodeString(FileName);
             Pos=FileName.Pos(";");
             FileName=FileName.Delete(1,Pos);

             if(CodeTable.LowerCase()=="koi8-r")
               {
                  int i;
                  unsigned char Src,Dest;

                  for(Pos=1; Pos<=FileName.Length(); Pos++)
                     {
                        Src=FileName[Pos];

                        for(i=0; i<sizeof(KOI8_R); i++)
                           if(KOI8_R[i]==Src)
                             break;
                        if(i<sizeof(KOI8_R))
                          Dest=WIN_1251[i];
                        else
                          Dest=Src;
                        FileName[Pos]=Dest;
                     }
               }
          }
     }
   __finally
     {
        if(IdBase64Decoder)
          delete IdBase64Decoder;
     }

   return(FileName);
}
//---------------------------------------------------------------------------
