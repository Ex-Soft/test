//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "TCPIPInput.h"
#include "TCPIPInput2.h"
#include "TCPDef.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

const int TmpBuffSize=40;

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   IsServer=true;
   Host=IPAddress="";
   OutTimeFormat="h:nn:ss am/pm";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormActivate(TObject *Sender)
{
   TModalResult Result;

   Application->CreateForm(__classid(TPreference1), &Preference1);
   Result=Preference1->ShowModal();
   Preference1->Free();
   if(Result!=mrOk)
     Application->Terminate();

   if(!IsServer)
     {
        Application->CreateForm(__classid(TPreference2), &Preference2);
        Result=Preference2->ShowModal();
        Preference2->Free();
        if(Result!=mrOk)
          Application->Terminate();

        ClientsListBox->Visible=false;

        if(!Host.IsEmpty())
          ClientSocket1->Host=Host;
        else
          ClientSocket1->Address=IPAddress;
        ClientSocket1->Port=1313;
        ClientSocket1->Open();
     }
   else
     {
        ServerSocket1->Port=1313;
        ServerSocket1->Open();
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Connect(TObject *Sender,
      TCustomWinSocket *Socket)
{
    AddConnection(Socket->SocketHandle);
    Connections[Socket->SocketHandle].State=csConnected;

    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnConnect";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    MessageToList="Server Host: "+Socket->RemoteHost;
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    MessageToList="Server IP: "+Socket->RemoteAddress;
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    ReceiveBox->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Connecting(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnConnecting";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Disconnect(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnDisconnect";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    DelConnection(Socket->SocketHandle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Error(TObject *Sender,
      TCustomWinSocket *Socket, TErrorEvent ErrorEvent, int &ErrorCode)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnError";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    //ErrorCode=0;
    Connections[Socket->SocketHandle].State=csError;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Lookup(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnLookup";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Read(TObject *Sender, TCustomWinSocket *Socket)
{
    char
      Buff[TmpBuffSize];

    int
      ReceiveCount=Socket->ReceiveBuf(Buff,TmpBuffSize-1);

    for(int i=0; i<ReceiveCount; i++)
       {
          if(*(Buff+i)=='>')
            {
               *(Connections[Socket->SocketHandle].Buff)=0x0;
               Connections[Socket->SocketHandle].Count=0;
            }
          else if(*(Buff+i)=='<')
                 ShowReceiveString(Socket->SocketHandle);
               else
                 *(Connections[Socket->SocketHandle].Buff+Connections[Socket->SocketHandle].Count++)=*(Buff+i);
       }

    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnRead";
    MessBox->Items->Append(MessageToList);
    MessBox->Items->Append("Receive "+IntToStr(ReceiveCount)+" byte(s)");
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClientSocket1Write(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Client Socket: OnWrite";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1Accept(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnAccept";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    MessageToList=Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ClientConnect(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnClientConnect";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;

    int i;
    for(i=0; i<ServerSocket1->Socket->ActiveConnections; i++)
       if(ServerSocket1->Socket->Connections[i]->SocketHandle==Socket->SocketHandle)
         break;

    if(i<ServerSocket1->Socket->ActiveConnections)
      {
         Connections[Socket->SocketHandle].State=csConnected;
         ClientsListBox->Items->AddObject(Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")",(TObject *)Socket->SocketHandle);
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ClientDisconnect(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnClientDisconnect";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    DelConnection(Socket->SocketHandle);
    MessageToList=Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    for(int i=0; i<ClientsListBox->Items->Count; i++)
       if((int)ClientsListBox->Items->Objects[i]==Socket->SocketHandle)
         {
            ClientsListBox->Items->Delete(i);
            break;
         }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ClientError(TObject *Sender,
      TCustomWinSocket *Socket, TErrorEvent ErrorEvent, int &ErrorCode)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnClientError";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    Connections[Socket->SocketHandle].State=csError;
    MessageToList=Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    for(int i=0; i<ClientsListBox->Items->Count; i++)
       if((int)ClientsListBox->Items->Objects[i]==Socket->SocketHandle)
         {
            ClientsListBox->Items->Delete(i);
            break;
         }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ClientRead(TObject *Sender, TCustomWinSocket *Socket)
{
    char
      Buff[TmpBuffSize];

    int
      ReceiveCount=Socket->ReceiveBuf(Buff,TmpBuffSize-1);

    for(int i=0; i<ReceiveCount; i++)
       {
          if(*(Buff+i)=='>')
            {
               *(Connections[Socket->SocketHandle].Buff)=0x0;
               Connections[Socket->SocketHandle].Count=0;
            }
          else if(*(Buff+i)=='<')
                 ShowReceiveString(Socket->SocketHandle);
               else
                 *(Connections[Socket->SocketHandle].Buff+Connections[Socket->SocketHandle].Count++)=*(Buff+i);
       }

    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnClientRead";
    MessBox->Items->Append(MessageToList);
    MessageToList=Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    MessBox->Items->Append("Receive "+IntToStr(ReceiveCount)+" byte(s)");
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ClientWrite(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnClientWrite";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
    MessageToList=Socket->RemoteHost+" ("+Socket->RemoteAddress+":"+IntToStr(Socket->RemotePort)+")";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1GetSocket(TObject *Sender,
      int Socket, TServerClientWinSocket *&ClientSocket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnGetSocket";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;

    AddConnection(Socket);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1GetThread(TObject *Sender,
      TServerClientWinSocket *ClientSocket,
      TServerClientThread *&SocketThread)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnGetThread";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1Listen(TObject *Sender,
      TCustomWinSocket *Socket)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnListen";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ThreadEnd(TObject *Sender,
      TServerClientThread *Thread)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnThreadEnd";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ServerSocket1ThreadStart(TObject *Sender,
      TServerClientThread *Thread)
{
    MessageToList=Now().FormatString(OutTimeFormat)+" Server Socket: OnThreadStart";
    MessBox->Items->Append(MessageToList);
    StatusBar1->SimpleText=MessageToList;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Edit1KeyDown(TObject *Sender, WORD &Key,
      TShiftState Shift)
{
    int Count,i;

    if(ClientsListBox->ItemIndex<0)
      ClientsListBox->ItemIndex=0;

    if(Key==VK_RETURN)
      {
        Edit1->Text=">"+Edit1->Text+"<";
        if(IsServer)
          {
             for(i=0; i<ServerSocket1->Socket->ActiveConnections; i++)
                if(ServerSocket1->Socket->Connections[i]->SocketHandle==(int)ClientsListBox->Items->Objects[ClientsListBox->ItemIndex])
                  break;
             if(i<ServerSocket1->Socket->ActiveConnections)
               Count=ServerSocket1->Socket->Connections[i]->SendBuf(Edit1->Text.c_str(),Edit1->Text.Length());
          }
        else
          Count=ClientSocket1->Socket->SendBuf(Edit1->Text.c_str(),Edit1->Text.Length());
        Edit1->Text="";

        MessageToList=Now().FormatString(OutTimeFormat)+" Send "+IntToStr(Count)+" byte(s)";
        MessBox->Items->Append(MessageToList);
        StatusBar1->SimpleText=MessageToList;
      }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ShowReceiveString(int SocketHandle)
{
   AnsiString tmp="";
   if(Connections[SocketHandle].Count)
     tmp=AnsiString(Connections[SocketHandle].Buff,Connections[SocketHandle].Count);
   ReceiveBox->Items->Add(tmp);
}
//---------------------------------------------------------------------------

bool __fastcall TMainForm::FindConnection(int SocketHandle)
{
   std::map<int, TConnectionInfo>::iterator i=Connections.find(SocketHandle);

   return(i!=Connections.end());
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::AddConnection(int SocketHandle)
{
   if(FindConnection(SocketHandle))
     return;

   TConnectionInfo *tmp;

   try
     {
        tmp=new TConnectionInfo;
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): AddConnection() Insufficient memory");
     }

   Connections.insert(std::map<int, TConnectionInfo>::value_type(SocketHandle,*tmp));
   delete tmp;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DelConnection(int SocketHandle)
{
   std::map<int, TConnectionInfo>::iterator i=Connections.find(SocketHandle);

   if(i==Connections.end())
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): DelConnection() SocketHandle "+IntToStr(SocketHandle)+" doesn't exist");

   Connections.erase(i);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ClearConnections(void)
{
   Connections.clear();
}
//---------------------------------------------------------------------------

