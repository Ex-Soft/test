//---------------------------------------------------------------------------

#include <vcl.h>
#include <StrUtils.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define SEND_BY_ICQ_COM

AnsiString
  csend;

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSendClick(TObject *Sender)
{
   AnsiString
     PostData;

   #if defined(SEND_BY_ICQ_COM)
     EditHost->Text="wwp.icq.com";

     PostData="from="+EditFromNick->Text;
     PostData+="&fromemail="+EditFromMail->Text;
     PostData+="&body="+AnsiReplaceStr(MemoMessage->Text,"\r\n","");
     PostData+="&to="+EditToUIN->Text;
     PostData+="&submit=Send+Message";

     csend="POST /scripts/WWPMsg.dll HTTP/1.0\r\n";
     csend+="Referer: http://"+EditHost->Text+"/"+EditToUIN->Text+"\r\n";
     csend+="Content-Type: application/x-www-form-urlencoded\r\n";
     csend+="Content-Length: "+IntToStr(PostData.Length())+"\r\n";
     csend+="Host: "+EditHost->Text+"\r\n";
     csend+="Accept: */*\r\n";
     csend+="Accept-Encoding: gzip, deflate\r\n";
     csend+="Connection: Keep-Alive\r\n";
     csend+="User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;)\r\n\r\n";
     csend+=PostData;
   #else
     EditHost->Text="wwp.mirabilis.com";

     PostData="from="+EditFromNick->Text+"&fromemail="+EditFromMail->Text+"&fromicq="+EditFromUIN->Text+"&body="+AnsiReplaceStr(MemoMessage->Text,"\r\n","")+"&to="+EditToUIN->Text+"&send=";

     csend="post http://wwp.icq.com/scripts/wwpmsg.dll http/2.0\r\n";
     csend+="referer: http://wwp.mirabilis.com\r\n";
     csend+="user-agent: mozilla/4.06 (win95; i)\r\n";
     csend+="connection: keep-alive\r\n";
     csend+="host: wwp.mirabilis.com:80\r\n";
     csend+="content-type: application/x-www-form-urlencoded\r\n";
     csend+="content-length: "+IntToStr(PostData.Length())+"\r\n";
     csend+="accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*\r\n\r\n";
     csend+=PostData;
   #endif

   ClientSocketICQ->Host=EditHost->Text;
   ClientSocketICQ->Port=80;
   ClientSocketICQ->Active=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocketICQConnect(TObject *Sender, TCustomWinSocket *Socket)
{
   ClientSocketICQ->Socket->SendText(csend);
   ClientSocketICQ->Active=false;
}
//---------------------------------------------------------------------------

