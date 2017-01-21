bool __fastcall TForm1::SendRequest(AnsiString OKPO,int Card)
{
             TIdMessage * AMsg;
             AMsg = new TIdMessage(NULL);
             AMsg->ContentTransferEncoding="8bit";
             InitSendMessage(AMsg,EDPROU_REQUEST);
             AMsg->ExtraHeaders->Add("X-REQUESTSTRING:"+OKPO);
             AMsg->ExtraHeaders->Add("X-REQUESTCARDON:"+AnsiString(Card));
             AMsg->Body->Add(OKPO);
             SMTP_STATUS=1;
             StatusBar1->Repaint();
             try{
               IdSMTP1->Host=SMTP_HOST;
               IdSMTP1->Port=SMTP_PORT;
               if (SMTP_LOGIN){IdSMTP1->AuthenticationType=atLogin;
                   IdSMTP1->UserId=SMTP_USERID;
                   IdSMTP1->Password=SMTP_PASSWORD;
                  }else{IdSMTP1->AuthenticationType=atNone;
                   IdSMTP1->UserId="";
                   IdSMTP1->Password="";
                  }
                 if (IdSMTP1->Connected()){IdSMTP1->Disconnect();}
                 IdSMTP1->Connect();
                 IdSMTP1->Send(AMsg);
                 IdSMTP1->Disconnect();
                 AddToSMTPLog(OKPO);
                 SMTP_STATUS=0;
                 StatusBar1->Repaint();
               }
               catch (const Exception& e)
                 {
                  SMTP_STATUS=2;StatusBar1->Repaint();
                  Application->MessageBoxA(MailError(e.Message).c_str(),"Помилка !",MB_OK+MB_ICONERROR);
                  OptionsExecute(NULL);
                 }
             delete AMsg;
           return (SMTP_STATUS!=2);
}
//---------------------------------------------------------------------------
bool __fastcall TForm1::InitSendMessage(TIdMessage * AMsg,AnsiString MailType)
{
        AMsg->From->Address=MAIN_FROM;
        AMsg->Recipients->EMailAddresses=MAIN_TO;
        AMsg->ExtraHeaders->Add("X-ARMVersion:"+VERSION);
        AMsg->ExtraHeaders->Add("X-SenderARM:"+ARMNAME);
        AMsg->ExtraHeaders->Add("X-MailType:"+MailType);
        return true;
}
