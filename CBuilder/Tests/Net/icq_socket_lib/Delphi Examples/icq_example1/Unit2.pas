unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Buttons, ExtCtrls, ICQSocket, ICQ_Type_pas, Menus, Unit4;

type
  TICQFrame = class(TFrame)
    UINEdit: TEdit;
    Label1: TLabel;
    PassEdit: TEdit;
    Label2: TLabel;
    StatusCombo: TComboBox;
    Label3: TLabel;
    ConnectBtn: TBitBtn;
    ContactList: TListBox;
    Label4: TLabel;
    RemoveContactBtn: TBitBtn;
    ContactUINEdit: TEdit;
    ContactVisCombo: TComboBox;
    SetContactBtn: TBitBtn;
    LogMemo: TMemo;
    LogLabel: TLabel;
    Bevel1: TBevel;
    UrlLabel: TLabel;
    UrlEdit: TEdit;
//    Label7: TLabel;
    DescEdit: TEdit;
    SendRadio: TRadioGroup;
    SendBtn: TBitBtn;
    ICQSocket: TICQSocket;
    Trace: TCheckBox;
    TopPanel: TPanel;
    GetInfoBtn: TBitBtn;
    SearchBtn: TBitBtn;
    Shape: TShape;
    procedure UINEditEnter(Sender: TObject);
    procedure UINEditChange(Sender: TObject);
    procedure PassEditChange(Sender: TObject);
    procedure StatusComboChange(Sender: TObject);
    procedure ICQSocketConnected(Sender: TObject);
    procedure ICQSocketDisconnected(Sender: TObject);
    procedure ConnectBtnClick(Sender: TObject);
    procedure ContactListEnter(Sender: TObject);
    procedure UrlEditEnter(Sender: TObject);
    procedure SetContactBtnClick(Sender: TObject);
    procedure ContactListClick(Sender: TObject);
    procedure ContactListKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure ContactListMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure RemoveContactBtnClick(Sender: TObject);
    procedure SendRadioClick(Sender: TObject);
    procedure SendBtnClick(Sender: TObject);
    procedure ICQSocketContactOnline(Sender: TObject;
      const Contact: ICQ_Contact);
    procedure ICQSocketBeginWait(Sender: TObject);
    procedure ICQSocketEndWait(Sender: TObject);
    procedure ICQSocketEndFound(Sender: TObject);
    procedure ICQSocketError(Sender: TObject; Error: Integer);
    procedure ICQSocketInvalidLogin(Sender: TObject);
    procedure ICQSocketLog(Sender: TObject; Level: ICQ_Log;
      const Str: String);
    procedure ICQSocketProcessAdded(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Nick, First, Last, Email: String);
    procedure ICQSocketProcessAuthRequest(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Nick, First, Last, Email, Reson: String);
    procedure ICQSocketProcessChatRequest(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Desc: String);
    procedure ICQSocketProcessFileRequest(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Desc, FileName: String; FileSize: Integer);
    procedure ICQSocketProcessMailExpress(Sender: TObject; Date: TDateTime;
      const Nick, Email, Msg: String);
    procedure ICQSocketProcessMessage(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Msg: String);
    procedure ICQSocketProcessUrl(Sender: TObject; UIN: Cardinal;
      Date: TDateTime; const Url, Desc: String);
    procedure ICQSocketProcessWebPager(Sender: TObject; Date: TDateTime;
      const Nick, Email, Msg: String);
    procedure ICQSocketTimeout(Sender: TObject; CurAttempt,
      Sequence: Cardinal);
    function ICQSocketWait(Sender: TObject;
      var WaitResult: Integer): Boolean;
    procedure ICQSocketSrvUDPAck(Sender: TObject; Sequence: Cardinal);
    procedure ICQSocketReadUDPPacket(Sender: TObject; Data: Pointer;
      Len: Cardinal; ProxyHeader: Pointer; ProxyHeaderLen: Cardinal);
    procedure ICQSocketWriteUDPPacket(Sender: TObject; Data,
      CryptData: Pointer; Len: Cardinal; ProxyHeader: Pointer;
      ProxyHeaderLen, Sequence: Cardinal);
    procedure UrlEditExit(Sender: TObject);
    procedure UINEditExit(Sender: TObject);
    procedure ContactListExit(Sender: TObject);
    procedure ICQSocketConnecting(Sender: TObject);
    procedure ICQSocketWaitConnect(Sender: TObject; WaitTime: Cardinal);
    procedure ICQSocketDisconnecting(Sender: TObject);
    procedure ICQSocketWriteOscarPacket(Sender: TObject; Data: Pointer;
      Len: Cardinal);
    procedure ICQSocketReadOscarPacket(Sender: TObject; Data: Pointer;
      Len: Cardinal);
    procedure GetInfoBtnClick(Sender: TObject);
  private
    { Private declarations }
    OldUrl,OldMessage: string;
    MetaInfoForm: TMetaInfoForm;

    procedure AddLog(const S: string; A: array of const);
    procedure MakeContactList;
  public
    { Public declarations }
    InfoForm: TMetaInfoForm;

    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;

    procedure LoadState;
    procedure SaveState;
  end;

implementation

{$R *.DFM}

Uses Unit3;

function NthWord(const S,Sub: string; N: Integer): string;
var I,K: Integer;
begin
  Result := S;
  for I := 2 to N do begin
    K := AnsiPos(Sub,Result);
    if K = 0 then begin
      Result := '';
      Exit;
    end;
    Delete(Result,1,K-1+Length(Sub));
  end;
  K := AnsiPos(Sub,Result);
  if K > 0 then
    Delete(Result,K,Length(Result));
  Result := Trim(Result);
end;

constructor TICQFrame.Create(AOwner: TComponent);
begin
  inherited;
  InfoForm := TMetaInfoForm.Create(Self);
  InfoForm.SetEventTo(ICQSocket);
end;
destructor TICQFrame.Destroy;
begin
  ICQSocket.Active := False;
  inherited;
end;

procedure TICQFrame.AddLog(const S: string; A: array of const);
begin
  if not Assigned(LogMemo) then Exit;
  LogMemo.Lines.Add(FormatDateTime('hh:nn:ss - ',Now)+Format(S,A));
  SendMessage(LogMemo.Handle,EM_LINESCROLL,0,1);
end;

procedure TICQFrame.LoadState;
var List: TStringList; S,FileName: string; I: Integer;

  procedure AddContact(const S: string);
  var UIN: DWORD;

    function GetBool(I: Integer): Boolean;
    begin
      Result := StrToIntDef(NthWord(S,' ',I),0) <> 0;
    end;

  begin
    UIN := StrToIntDef(NthWord(S,' ',1),0);
    if UIN > 0 then
      ICQSocket.SetContact2(UIN,GetBool(2),GetBool(3));
  end;

  procedure LoadDef;
  begin
    UINEdit.Text := '';
    PassEdit.Text := '';
    StatusCombo.ItemIndex := Ord(ICQ_Status_Online);
    ICQSocket.Status := ICQ_Status_Online;
    UrlEdit.Text := '';
    DescEdit.Text := '';
    MakeContactList;
  end;

  function LoadPassStr(const S: string): string;
  begin
    if S = '.' then Result := '' else Result := S;
  end;

begin
  ICQSocket.ClearContactList;
  ContactList.Items.Clear;
  LogMemo.Clear;

  LoadDef;
  FileName := Format('state%d.cfg',[Tag]);
  if not FileExists(FileName) then Exit;

  List := TStringList.Create;
  try
    List.LoadFromFile(FileName);
    if List.Count > 0 then begin
      S := List.Strings[0];
      UINEdit.Text := NthWord(S,' ',1);
      PassEdit.Text := LoadPassStr(NthWord(S,' ',2));
      StatusCombo.ItemIndex := StrToIntDef(NthWord(S,' ',3),0);
      ICQSocket.Status := ICQ_Status(StatusCombo.ItemIndex);
      for I := 1 to List.Count-1 do AddContact(List.Strings[I]);
      MakeContactList;
    end;
  finally
    List.Free;
  end;
end;
procedure TICQFrame.SaveState;
var List: TStringList; S: string; I: Integer;

  procedure AddContact(I: Integer);
  var Contact: PICQ_Contact;
  begin
    Contact := ICQSocket.IndexContact[I];
    List.Add(Format('%d %d %d',[Contact^.UIN,Ord(Contact^.Visible),Ord(Contact^.Invisible)]));
  end;
  function SavePassStr: string;
  begin
    Result := NthWord(PassEdit.Text,' ',1);
    if Result = '' then Result := '.';
  end;

begin
  List := TStringList.Create;
  try
   List.Add(Format('%d %s %d',
     [ StrToIntDef(UINEdit.Text,0), SavePassStr,
       StatusCombo.ItemIndex ] ));

    for I := 0 to ICQSocket.ContactCount-1 do AddContact(I);
    List.SaveToFile(Format('state%d.cfg',[Tag]));
  finally
    List.Free;
  end;
end;

procedure TICQFrame.MakeContactList;
var I,Count: Integer; Contact: PICQ_Contact;

  function GetIpAddr(IP: DWORD): string;
  begin
    Result := Format('%d.%d.%d.%d',
      [ PByteArray(@IP)^[3],PByteArray(@IP)^[2],
        PByteArray(@IP)^[1],PByteArray(@IP)^[0] ] );
  end;

  function GetVisIndex: Integer;
  begin
    if Contact^.Visible then Result := 1 else
    if Contact^.Invisible then Result := 2 else
      Result := 0;
  end;

begin
  ContactUINEdit.Text := '';
  ContactVisCombo.ItemIndex := 0;
  ContactList.Items.Clear;
  Count := ICQSocket.ContactCount;
  for I := 0 to Count-1 do begin
    Contact := ICQSocket.IndexContact[I];
    ContactList.Items.Add(
      Format('%d, %s, %s, %s',
        [ Contact^.UIN,
          ContactVisCombo.Items.Strings[GetVisIndex],
          StatusCombo.Items.Strings[Ord(Contact^.Status)],
          GetIpAddr(Contact^.RealIP) ]) );
  end;
end;

procedure TICQFrame.UINEditEnter(Sender: TObject);
begin
  ConnectBtn.Default := True;
  SetContactBtn.Default := False;
  SendBtn.Default := False;
end;

procedure TICQFrame.UINEditExit(Sender: TObject);
begin
  ConnectBtn.Default := False;
end;

procedure TICQFrame.UINEditChange(Sender: TObject);
begin
  ICQSocket.UIN := StrToIntDef(UINEdit.Text,0);
end;

procedure TICQFrame.PassEditChange(Sender: TObject);
begin
  ICQSocket.Password := NthWord(PassEdit.Text,' ',1);
end;

procedure TICQFrame.StatusComboChange(Sender: TObject);
begin
  ICQSocket.Status := ICQ_Status(StatusCombo.ItemIndex);
end;

procedure TICQFrame.ICQSocketConnected(Sender: TObject);
begin
  AddLog('Connected',[]);
  ConnectBtn.Caption := 'Disconnect';
  ConnectBtn.Default := False;
  Shape.Brush.Color := clGreen;
//  SetContactBtn.Default := False;
//  SendBtn.Default := False;
//  ICQSocket.Send_ContactList;
//  ICQSocket.Send_VisibleList;
//  ICQSocket.Send_InvisibleList;
end;

procedure TICQFrame.ICQSocketDisconnected(Sender: TObject);

  function GetReason: string;
  begin
    case ICQSocket.DisconnectReason of
      ICQ_DisconnectReason_NULL: Result := '';
      ICQ_DisconnectReason_LanError: Result := 'LanError';
      ICQ_DisconnectReason_Reconnect: Result := 'Reconnect';
      ICQ_DisconnectReason_NoHostFound: Result := 'NoHostFound';
      ICQ_DisconnectReason_HostRefused: Result := 'HostRefused';
      ICQ_DisconnectReason_ProxyNoHostFound: Result := 'ProxyNoHostFound';
      ICQ_DisconnectReason_ProxyRefused: Result := 'ProxyRefused';
      ICQ_DisconnectReason_ProxyLoginError: Result := 'ProxyLoginError';
      ICQ_DisconnectReason_ProxyError: Result := 'ProxyError';
      ICQ_DisconnectReason_ServerGoAway: Result := 'ServerGoAway';
      ICQ_DisconnectReason_User: Result := 'User';
      ICQ_DisconnectReason_Timeout: Result := 'Timeout';
      ICQ_DisconnectReason_InvalidPassword: Result := 'InvalidPassword';
      ICQ_DisconnectReason_InvalidUIN: Result := 'InvalidUIN';
      ICQ_DisconnectReason_DeleteSocket: Result := 'DeleteSocket';
      ICQ_DisconnectReason_LanDataError: Result := 'LanDataError';
      ICQ_DisconnectReason_WinError: Result := 'WinError';
      ICQ_DisconnectReason_Redirect: Result := 'Redirect';
      ICQ_DisconnectReason_ServerError: Result := 'ServerError';
      ICQ_DisconnectReason_DualLogin: Result := 'DualLogin';
    end;
  end;

begin
  AddLog('Disconnected: %s',[GetReason]);
  ConnectBtn.Caption := 'Connect';
  Shape.Brush.Color := clRed;
end;

procedure TICQFrame.ICQSocketConnecting(Sender: TObject);
const Mes: array[Boolean] of string = ('Connecting','Redirecting');
begin
  AddLog('%s to %s:%d',
    [ Mes[ICQSocket.RedirectCount > 0],
      ICQSocket.ConnectHost,ICQSocket.ConnectPort ]);
end;

procedure TICQFrame.ConnectBtnClick(Sender: TObject);
begin
  if ICQSocket.Connecting then
    ICQSocket.Active := False else
    ICQSocket.Active := not ICQSocket.Active;
end;

procedure TICQFrame.ContactListEnter(Sender: TObject);
begin
  SetContactBtn.Default := True;
  ConnectBtn.Default := False;
  SendBtn.Default := False;
end;

procedure TICQFrame.ContactListExit(Sender: TObject);
begin
  SetContactBtn.Default := False;
end;

procedure TICQFrame.UrlEditEnter(Sender: TObject);
begin
  SendBtn.Default := True;
  ConnectBtn.Default := False;
  SetContactBtn.Default := False;
end;

procedure TICQFrame.UrlEditExit(Sender: TObject);
begin
  SendBtn.Default := False;
end;

procedure TICQFrame.SetContactBtnClick(Sender: TObject);
var UIN: DWORD; Visile, Invisible: Boolean;
begin
  UIN := StrToIntDef(ContactUINEdit.Text,0);
  if UIN = 0 then begin
    ContactUINEdit.SetFocus;
    Application.MessageBox('Input UIN','Error',MB_OK);
    Exit;
  end;
  case ContactVisCombo.ItemIndex of
    0: begin Visile := False; Invisible := False; end;
    1: begin Visile := True; Invisible := False; end;
    2: begin Visile := False; Invisible := True; end;
  end;

  ICQSocket.SetContact2(UIN,Visile,Invisible);
  ICQSocket.Send_ContactList;
//  ICQSocket.Send_VisibleList;
//  ICQSocket.Send_InvisibleList;
  MakeContactList;
  ContactList.ItemIndex := ICQSocket.UINContactIndex[UIN];
end;

procedure TICQFrame.ContactListClick(Sender: TObject);
var Contact: PICQ_Contact;
begin
  Contact := ICQSocket.IndexContact[ContactList.ItemIndex];
  ContactUINEdit.Text := IntToStr(Contact^.UIN);
  ContactVisCombo.ItemIndex := Ord(Contact^.Visible);
end;

procedure TICQFrame.ContactListKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
  ContactListClick(nil);
end;

procedure TICQFrame.ContactListMouseDown(Sender: TObject;
  Button: TMouseButton; Shift: TShiftState; X, Y: Integer);
begin
  ContactListClick(nil);
end;

procedure TICQFrame.RemoveContactBtnClick(Sender: TObject);
var I: Integer;
begin
  I := ContactList.ItemIndex;
  ICQSocket.RemoveIndexContact(I);
  ICQSocket.Send_ContactList;
  MakeContactList;
  ContactList.ItemIndex := I-1;
end;

procedure TICQFrame.SendRadioClick(Sender: TObject);
begin
  if SendRadio.ItemIndex = 0 then begin
    DescEdit.Enabled := True;
    DescEdit.Color := clWindow;
    UrlLabel.Caption := 'Url';
    OldMessage := UrlEdit.Text;
    UrlEdit.Text := OldUrl;
  end else begin
    DescEdit.Enabled := False;
    DescEdit.Color := clSilver;
    UrlLabel.Caption := 'Message';
    OldUrl := UrlEdit.Text;
    UrlEdit.Text := OldMessage;
  end;
  UrlEdit.SetFocus;
end;

procedure TICQFrame.SendBtnClick(Sender: TObject);
var UIN: DWORD; R: Integer;
begin
  if not ICQSocket.Active then begin
    UINEdit.SetFocus;
    Exit;
  end;
  UIN := StrToIntDef(ContactUINEdit.Text,0);
  if UIN = 0 then begin
    ContactUINEdit.SetFocus;
    Application.MessageBox('Input UIN','Error',MB_OK);
    Exit;
  end;
  AddLog('Send',[]);
  if SendRadio.ItemIndex = 0 then
    R := ICQSocket.Send_Url(UIN,UrlEdit.Text,DescEdit.Text,ICQ_Send_ThruServer) else
    R := ICQSocket.Send_Message(UIN,UrlEdit.Text,ICQ_Send_ThruServer);
  if R = ICQ_Result_Void then
    DemoForm.ShowModal;
end;

procedure TICQFrame.ICQSocketContactOnline(Sender: TObject;
  const Contact: ICQ_Contact);
begin
  AddLog('UIN: %d, Status: %s',
    [Contact.UIN,StatusCombo.Items.Strings[Ord(Contact.Status)]]);
  MakeContactList;
end;

procedure TICQFrame.ICQSocketBeginWait(Sender: TObject);
begin
  Enabled := False;
  AddLog('Begin Wait...',[]);
end;

procedure TICQFrame.ICQSocketEndWait(Sender: TObject);
begin
  AddLog('End Wait',[]);
  Enabled := True;
end;

procedure TICQFrame.ICQSocketEndFound(Sender: TObject);
begin
  AddLog('End Found',[]);
end;

procedure TICQFrame.ICQSocketError(Sender: TObject; Error: Integer);
begin
  AddLog('Error: %d',[Error]);
end;

procedure TICQFrame.ICQSocketInvalidLogin(Sender: TObject);
begin
  AddLog('Invalid login !!!',[]);
end;

procedure TICQFrame.ICQSocketLog(Sender: TObject; Level: ICQ_Log;
  const Str: String);
begin
  AddLog('Log [%d]: %s',[Ord(Level),Str]);
end;

function LogDate(Date: TDateTime): string;
begin
  Result := FormatDateTime('dd/mm/yy hh:nn',Date);
end;

procedure TICQFrame.ICQSocketProcessAdded(Sender: TObject; UIN: Cardinal;
  Date: TDateTime; const Nick, First, Last, Email: String);
begin
  AddLog('#Added: %d,%s,%s,%s,%s,%s',[UIN,LogDate(Date),Nick,First,Last,Email]);
end;

procedure TICQFrame.ICQSocketProcessAuthRequest(Sender: TObject;
  UIN: Cardinal; Date: TDateTime; const Nick, First, Last, Email,
  Reson: String);
begin
  AddLog('#AuthReq: %d,%s,%s,%s,%s,%s,%s',
    [UIN,LogDate(Date),Nick,First,Last,Email,Reson]);
end;

procedure TICQFrame.ICQSocketProcessChatRequest(Sender: TObject;
  UIN: Cardinal; Date: TDateTime; const Desc: String);
begin
  AddLog('#ChatReq: %d,%s,%s',
    [UIN,LogDate(Date),Desc]);
end;

procedure TICQFrame.ICQSocketProcessFileRequest(Sender: TObject;
  UIN: Cardinal; Date: TDateTime; const Desc, FileName: String;
  FileSize: Integer);
begin
  AddLog('#FileReq: %d,%s,%s,%s,%d',
    [UIN,LogDate(Date),Desc,FileName,FileSize]);
end;

procedure TICQFrame.ICQSocketProcessMailExpress(Sender: TObject;
  Date: TDateTime; const Nick, Email, Msg: String);
begin
  AddLog('#Mail: %s,%s,%s,%s',
    [LogDate(Date),Nick,Email,Msg]);
end;

procedure TICQFrame.ICQSocketProcessMessage(Sender: TObject; UIN: Cardinal;
  Date: TDateTime; const Msg: String);
begin
  AddLog('- - - - -',[]);
  AddLog('#Msg: %d,%s,%s',
    [UIN,LogDate(Date),Msg]);
end;

procedure TICQFrame.ICQSocketProcessUrl(Sender: TObject; UIN: Cardinal;
  Date: TDateTime; const Url, Desc: String);
begin
  AddLog('- - - - -',[]);
  AddLog('#Url: %d,%s,url - %s, desc - %s',
    [UIN,LogDate(Date),Url,Desc]);
end;        

procedure TICQFrame.ICQSocketProcessWebPager(Sender: TObject;
  Date: TDateTime; const Nick, Email, Msg: String);
begin
  AddLog('- - - - -',[]);
  AddLog('#WebPage: %s,%s,%s,%s',
    [LogDate(Date),Nick, Email, Msg]);
end;

procedure TICQFrame.ICQSocketTimeout(Sender: TObject; CurAttempt,
  Sequence: Cardinal);
begin
  AddLog('Timeout: %d of %d for %d',[CurAttempt,ICQSocket.MaxAttempts,Sequence]);
end;

function TICQFrame.ICQSocketWait(Sender: TObject;
  var WaitResult: Integer): Boolean;
begin
//  AddLog('Wait...',[]);
  Application.ProcessMessages;
  Result := True;
end;


procedure TICQFrame.ICQSocketSrvUDPAck(Sender: TObject; Sequence: Cardinal);
begin
  AddLog('Packet send: %d',[Sequence]);
end;

const Hex: PChar = '0123456789ABCDEF';

  function GetHex(B: Byte): string;
  begin
    Result := Hex[B shr 4] + Hex[B and $F];
  end;

  function GetPacketData(Data: Pointer; Len,MaxLen: Integer): string;
  var I: Integer; B: Byte;
  begin
    if Len > MaxLen then Len := MaxLen;
    for I := 0 to Len-1 do begin
      B := PByteArray(Data)^[I];
      Result := Result + Hex[B shr 4] + Hex[B and $F] + ' ';
    end;
    if Len < MaxLen then Result := Result + '...';
  end;

procedure TICQFrame.ICQSocketReadUDPPacket(Sender: TObject; Data: Pointer;
 Len: Cardinal; ProxyHeader: Pointer; ProxyHeaderLen: Cardinal);
var Cmd: Word;
begin
  if not Trace.Checked then Exit;
  Cmd := PWordArray(Integer(Data)+7)^[0];
  AddLog('ReadUDP [Cmd: $%s%s (%d)]: %s',
    [ GetHex(Cmd shr 8),GetHex(Cmd), Cmd,
      GetPacketData(Data,Len,30)]);
end;

procedure TICQFrame.ICQSocketWriteUDPPacket(Sender: TObject; Data,
  CryptData: Pointer; Len: Cardinal; ProxyHeader: Pointer; ProxyHeaderLen,
  Sequence: Cardinal);
var Cmd: Word;
begin
  if not Trace.Checked then Exit;
  if not Assigned(Data) then begin
    AddLog('WriteUDP (ICQ_Socket is DEMO version - no data)',[]);
    Exit;
  end;
  Cmd := PWordArray(Integer(Data)+14)^[0];
  AddLog('WriteUDP [Cmd: $%s%s (%d)]: %s',
    [ GetHex(Cmd shr 8),GetHex(Cmd), Cmd,
      GetPacketData(Data,Len,30)]);

//  AddLog('WriteUDP for %d: %s',[Sequence,GetPacketData(Data,Len,30)]);
end;

procedure TICQFrame.ICQSocketWaitConnect(Sender: TObject;
  WaitTime: Cardinal);
begin
  if WaitTime > 60000 then begin
    AddLog('Force break connect. Try again !!!',[]);
    ICQSocket.Active := False;
    Exit;
  end;
  AddLog('Wait connect: %d msec',[WaitTime]);
end;

procedure TICQFrame.ICQSocketDisconnecting(Sender: TObject);
begin
//  AddLog('Disconnecting',[]);
end;

procedure TICQFrame.ICQSocketWriteOscarPacket(Sender: TObject;
  Data: Pointer; Len: Cardinal);
begin
  if not Trace.Checked then Exit;
  if not Assigned(Data) then begin
    AddLog('WriteOscar (ICQ_Socket is DEMO version - no data)',[]);
    Exit;
  end;
  AddLog('WriteOscar: %s',[GetPacketData(Data,Len,30)]);
end;

procedure TICQFrame.ICQSocketReadOscarPacket(Sender: TObject;
  Data: Pointer; Len: Cardinal);
begin
  if not Trace.Checked then Exit;
  AddLog('ReadOscar: %s',[GetPacketData(Data,Len,30)]);
end;

procedure TICQFrame.GetInfoBtnClick(Sender: TObject);
var UIN: DWORD; r: Integer;
begin
  UIN := StrToIntDef(ContactUINEdit.Text,0);
  if UIN = 0 then begin
    ContactUINEdit.SetFocus;
    Application.MessageBox('Input UIN','Error',MB_OK);
    Exit;
  end;
  r := ICQSocket.Send_GetMetaInfo(UIN);
  if r = ICQ_Result_OK then begin
    InfoForm.Hide;
    InfoForm.Show;
    InfoForm.ResetInfo(UIN);
  end else
    Application.MessageBox(PChar(Format('Error get info: %d',[r])),'Error',MB_OK);
end;

end.

