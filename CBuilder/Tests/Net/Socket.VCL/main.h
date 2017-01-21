//---------------------------------------------------------------------------
#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <ScktComp.hpp>
#include <ComCtrls.hpp>
#include <map>
//---------------------------------------------------------------------------

#include "TCPInfo.h"

class TMainForm : public TForm
{
__published:	// IDE-managed Components
    TServerSocket *ServerSocket1;
    TClientSocket *ClientSocket1;
    TStatusBar *StatusBar1;
    TListBox *MessBox;
    TEdit *Edit1;
    TListBox *ReceiveBox;
    TLabel *Label1;
    TLabel *Label2;
    TLabel *Label3;
    TListBox *ClientsListBox;
    void __fastcall FormActivate(TObject *Sender);
    void __fastcall ClientSocket1Connect(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ClientSocket1Connecting(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ClientSocket1Disconnect(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ClientSocket1Error(TObject *Sender, TCustomWinSocket *Socket, TErrorEvent ErrorEvent, int &ErrorCode);
    void __fastcall ClientSocket1Lookup(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ClientSocket1Read(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ClientSocket1Write(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1Accept(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1ClientConnect(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1ClientDisconnect(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1ClientError(TObject *Sender, TCustomWinSocket *Socket, TErrorEvent ErrorEvent, int &ErrorCode);
    void __fastcall ServerSocket1ClientRead(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1ClientWrite(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1GetSocket(TObject *Sender, int Socket, TServerClientWinSocket *&ClientSocket);
    void __fastcall ServerSocket1GetThread(TObject *Sender, TServerClientWinSocket *ClientSocket, TServerClientThread *&SocketThread);
    void __fastcall ServerSocket1Listen(TObject *Sender, TCustomWinSocket *Socket);
    void __fastcall ServerSocket1ThreadEnd(TObject *Sender, TServerClientThread *Thread);
    void __fastcall ServerSocket1ThreadStart(TObject *Sender, TServerClientThread *Thread);
    void __fastcall Edit1KeyDown(TObject *Sender, WORD &Key, TShiftState Shift);
private:	// User declarations
public:		// User declarations
    __fastcall TMainForm(TComponent* Owner);

    bool IsServer;
    AnsiString NickName,Host,IPAddress,OutTimeFormat,MessageToList,ReceiveMessage;
    std::map<int, TConnectionInfo> Connections;

    void __fastcall ShowReceiveString(int SocketHandle);

    bool __fastcall FindConnection(int SocketHandle);
    void __fastcall AddConnection(int SocketHandle);
    void __fastcall DelConnection(int SocketHandle);
    void __fastcall ClearConnections(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
