(*=============================================================
 *
 *  Copyright (C) 1999-2002 Soft Variant Company.
 *  All Rights Reserved.
 *
 *  Freeware Delphi component for using
 *  ICQ_Socket.dll library v2.3
 *
 *  Author: Evgeny Golovin.
 *  E-Mail: softvariant@chat.ru
 *  Homepage: http://softvariant.boom.ru/icq_socket/index.htm
 *
 **************************************************************)
unit ICQSocket;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ICQ_Type_pas;

const
  ICQ_Result_CreateError = -100;
  ICQ_Version_Major = 2;
  ICQ_Version_Minor = 3;

  ICQ_VoidDate: TDateTime = 0;

type
  TICQSocket_Error = procedure (Sender: TObject; Error: Integer) of object;

  TICQSocket_Connecting = TNotifyEvent;
  TICQSocket_Connected = TNotifyEvent;
  TICQSocket_Disconnecting = TNotifyEvent;
  TICQSocket_Disconnected = TNotifyEvent;

  TICQSocket_InvalidLogin = TNotifyEvent;
  TICQSocket_InvalidPassword = TNotifyEvent;
  TICQSocket_InvalidUIN = TNotifyEvent;

  TICQSocket_ContactOnline = procedure (Sender: TObject; const Contact: ICQ_Contact) of object;
  TICQSocket_ContactOffline = procedure (Sender: TObject; const Contact: ICQ_Contact) of object;
  TICQSocket_ContactStatusUpdate = procedure (Sender: TObject; const Contact: ICQ_Contact) of object;

  TICQSocket_UserFound = procedure (Sender: TObject; UIN: DWORD;
    const Nick,First,Last,Email: string; Auth: ICQ_Auth) of object;
  TICQSocket_EndFound = TNotifyEvent;

  TICQSocket_NewUIN = procedure (Sender: TObject; UIN: DWORD) of object;

  TICQSocket_ProcessMessage = procedure (Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Msg: string) of object;
  TICQSocket_ProcessUrl = procedure (Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Url,Desc: string) of object;
  TICQSocket_ProcessWebPager = procedure (Sender: TObject;
    Date: TDateTime; const Nick,Email,Msg: string) of object;
  TICQSocket_ProcessAdded = procedure (Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Nick,First,Last,Email: string) of object;
  TICQSocket_ProcessMailExpress = procedure (Sender: TObject;
    Date: TDateTime; const Nick,Email,Msg: string) of object;

  TICQSocket_ProcessChatRequest = procedure(Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Desc: string) of object;

  TICQSocket_ProcessFileRequest = procedure(Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Desc,FileName: string; FileSize: Integer) of object;

  TICQSocket_ProcessAuthRequest = procedure(Sender: TObject; UIN: DWORD;
    Date: TDateTime; const Nick,First,Last,Email,Reson: string) of object;

  TICQSocket_UserNotFound = procedure(Sender: TObject; UIN: DWORD) of object;

  TICQSocket_UserInfo = procedure(Sender: TObject; UIN: DWORD;
    const Nick,First,Last,Email: string; Auth: ICQ_Auth) of object;

  TICQSocket_ExtUserInfo = procedure(Sender: TObject; UIN: DWORD;
    const City: string; CountryCode,CountryStat: DWORD;
    const State: string; Age: DWORD; Gender: ICQ_Gender;
    const Phone,HomePage,About: string) of object;
  TICQSocket_ExtUserInfo2 = procedure(Sender: TObject; UIN: DWORD;
    const City: string; CountryCode: DWORD; TimeOffset: Single;
    const State: string; Age: DWORD; Gender: ICQ_Gender;
    const Phone,HomePage,About: string) of object;

  TICQSocket_BeginWait = TNotifyEvent;
  TICQSocket_Wait = function(Sender: TObject; var WaitResult: Integer): Boolean of object;
  TICQSocket_WaitConnect = procedure(Sender: TObject; WaitTime: DWORD) of object;
  TICQSocket_EndWait = TNotifyEvent;

  TICQSocket_MetaUserFound = procedure(Sender: TObject; UIN: DWORD;
    const Nick,First,Last,Email: string; Auth: ICQ_Auth) of object;
  TICQSocket_MetaEndFound = TNotifyEvent;

  TICQSocket_MetaUserInfo = procedure(Sender: TObject;
    const Nick,First,Last,
     PriEml,SecEml,OldEml,
     City,State,Phone,Fax,
     Street,Cellular: string;
     Zip,Country,TimeZone: DWORD; Auth: ICQ_Auth;
     Web,HideIp: Boolean) of object;

  TICQSocket_MetaUserInfo2 = procedure(Sender: TObject;
    const Nick,First,Last,
     PriEml,SecEml,OldEml,
     City,State,Phone,Fax,
     Street,Cellular: string;
     Zip,Country: DWORD; TimeOffset: Single; Auth: ICQ_Auth;
     Web,HideIp: Boolean) of object;

  TICQSocket_MetaUserWork = procedure(Sender: TObject;
    const City,State,Phone,
     Fax,Address: string;
     Zip,Country: DWORD; const Company,Department,Job: string;
     Occupation: DWORD; const HomePage: string) of object;

  TICQSocket_MetaUserMore = procedure(Sender: TObject;
    Age: DWORD; Gender: ICQ_Gender; const HomePage: string;
    BDate: TDateTime;
    Lang1,Lang2,Lang3: DWORD) of object;

  TICQSocket_MetaUserAbout = procedure(Sender: TObject; const About: string) of object;

  TICQSocket_MetaUserInterests = procedure(Sender: TObject;
     Num: DWORD;
     Cat1: DWORD; const Int1: string;
     Cat2: DWORD; const Int2: string;
     Cat3: DWORD; const Int3: string;
     Cat4: DWORD; const Int4: string) of object;

  TICQSocket_MetaUserAffiliations = procedure(Sender: TObject;
     Num: DWORD;
     Cat1: DWORD; const Aff1: string;
     Cat2: DWORD; const Aff2: string;
     Cat3: DWORD; const Aff3: string;
     Cat4: DWORD; const Aff4: string;

     BNum: DWORD;
     BCat1: DWORD; const BAck1: string;
     BCat2: DWORD; const BAck2: string;
     BCat3: DWORD; const BAck3: string;
     BCat4: DWORD; const BAck4: string) of object;

  TICQSocket_MetaUserHomePageCategory = procedure(Sender: TObject;
    Num,Cat: DWORD; const Text: string) of object;

  TICQSocket_SrvUDPAck = procedure(Sender: TObject; Sequence: DWORD) of object;
  TICQSocket_SrvTCPAck = procedure(Sender: TObject; ID: DWORD) of object;

  TICQSocket_Timeout = procedure(Sender: TObject; CurAttempt,Sequence: DWORD) of object;
  TICQSocket_Log = procedure(Sender: TObject; Level: ICQ_Log; const Str: string) of object;

  TICQSocket_WriteUDPPacket = procedure(Sender: TObject;
    Data,CryptData: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen,Sequence: DWORD) of object;
  TICQSocket_ReadUDPPacket = procedure(Sender: TObject;
    Data: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen: DWORD) of object;

  TICQSocket_WriteOscarPacket = procedure(Sender: TObject;
    Data: Pointer; Len: DWORD) of object;
  TICQSocket_ReadOscarPacket = procedure(Sender: TObject;
    Data: Pointer; Len: DWORD) of object;

// ------------------------------------------------------------------------

  TICQLib_ForEach_Function = function(Sender: TObject; P: Pointer): Boolean of object;

// ------------------------------------------------------------------------

  TICQSocket = class(TComponent)
  private
    FSocket: ICQ_Socket;

    FOnError: TICQSocket_Error;

    FOnConnecting: TICQSocket_Connecting;
    FOnConnected: TICQSocket_Connected;
    FOnDisconnecting: TICQSocket_Disconnecting;
    FOnDisconnected: TICQSocket_Disconnected;
    FOnInvalidLogin: TICQSocket_InvalidLogin;

    FOnContactOnline: TICQSocket_ContactOnline;
    FOnContactOffline: TICQSocket_ContactOffline;
    FOnContactStatusUpdate: TICQSocket_ContactStatusUpdate;

    FOnUserFound: TICQSocket_UserFound;
    FOnEndFound: TICQSocket_EndFound;

    FOnNewUIN: TICQSocket_NewUIN;

    FOnProcessMessage: TICQSocket_ProcessMessage;
    FOnProcessUrl: TICQSocket_ProcessUrl;
    FOnProcessWebPager: TICQSocket_ProcessWebPager;
    FOnProcessAdded: TICQSocket_ProcessAdded;
    FOnProcessMailExpress: TICQSocket_ProcessMailExpress;

    FOnProcessChatRequest: TICQSocket_ProcessChatRequest;
    FOnProcessFileRequest: TICQSocket_ProcessFileRequest;
    FOnProcessAuthRequest: TICQSocket_ProcessAuthRequest;

    FOnUserNotFound: TICQSocket_UserNotFound;
    FOnUserInfo: TICQSocket_UserInfo;
    FOnExtUserInfo: TICQSocket_ExtUserInfo;

    FOnLog: TICQSocket_Log;
    FOnTimeout: TICQSocket_Timeout;

    FOnMetaUserFound: TICQSocket_MetaUserFound;
    FOnMetaUserInfo: TICQSocket_MetaUserInfo;
    FOnMetaUserWork: TICQSocket_MetaUserWork;
    FOnMetaUserMore: TICQSocket_MetaUserMore;
    FOnMetaUserAbout: TICQSocket_MetaUserAbout;

    FOnMetaUserInterests: TICQSocket_MetaUserInterests;
    FOnMetaUserAffiliations: TICQSocket_MetaUserAffiliations;
    FOnMetaUserHomePageCategory: TICQSocket_MetaUserHomePageCategory;

    FOnSrvUDPAck: TICQSocket_SrvUDPAck;
    FOnSrvTCPAck: TICQSocket_SrvTCPAck;

    FOnBeginWait: TICQSocket_BeginWait;
    FOnWait: TICQSocket_Wait;
    FOnWaitConnect: TICQSocket_WaitConnect;
    FOnEndWait: TICQSocket_EndWait;

    FOnWriteUDPPacket: TICQSocket_WriteUDPPacket;
    FOnReadUDPPacket: TICQSocket_ReadUDPPacket;

    FOnInvalidUIN: TICQSocket_InvalidUIN;
    FOnInvalidPassword: TICQSocket_InvalidPassword;

    FOnExtUserInfo2: TICQSocket_ExtUserInfo2;
    FOnMetaUserInfo2: TICQSocket_MetaUserInfo2;

    FOnMetaEndFound: TICQSocket_MetaEndFound;

    FOnWriteOscarPacket: TICQSocket_WriteOscarPacket;
    FOnReadOscarPacket: TICQSocket_ReadOscarPacket;

    procedure SetSocket(Value: ICQ_Socket);

    function GetProtocolVersion: Integer;
    procedure SetProtocolVersion(Value: Integer);

    function GetActive: Boolean;
    procedure SetActive(Value: Boolean);

    function GetConnecting: Boolean;

    function GetWaitConnect: Boolean;
    procedure SetWaitConnect(Value: Boolean);

    function GetAutoConnect: Boolean;
    procedure SetAutoConnect(Value: Boolean);

    function GetHost: string;
    procedure SetHost(Value: string);

    function GetHostPort: Integer;
    procedure SetHostPort(Value: Integer);

    function GetUIN: DWORD;
    procedure SetUIN(Value: DWORD);

    function GetNick: string;
    procedure SetNick(Value: string);

    function GetPassword: string;
    procedure SetPassword(Value: string);

    function GetMaxPassLen: Integer;
    procedure SetMaxPassLen(Value: Integer);

    function GetProxyUsed: Boolean;
    procedure SetProxyUsed(Value: Boolean);

    function GetProxyHost: string;
    procedure SetProxyHost(Value: string);

    function GetProxyPort: Integer;
    procedure SetProxyPort(Value: Integer);

    function GetProxyLoginUsed: Boolean;
    procedure SetProxyLoginUsed(Value: Boolean);

    function GetProxyUser: string;
    procedure SetProxyUser(Value: string);

    function GetProxyPassword: string;
    procedure SetProxyPassword(Value: string);

    function GetStatus: ICQ_Status;
    procedure SetStatus(Value: ICQ_Status);

    function GetLogLevel: ICQ_Log;
    procedure SetLogLevel(Value: ICQ_Log);

    function GetTimeout: Integer;
    procedure SetTimeout(Value: Integer);

    function GetMaxAttempts: Integer;
    procedure SetMaxAttempts(Value: Integer);

    function GetDisconnectReason: Integer;

    function GetRedirectCount: Integer;
    function GetRedirectHost: string;
    function GetRedirectPort: Integer;

    function GetConnectHost: string;
    function GetConnectPort: Integer;

    function GetLastSendUDPSequence: DWORD;

    function GetWait: Boolean;
    function GetWaitTimeout: Integer;

    function GetContactCount: Integer;
    function GetUINContactIndex(UIN: DWORD): Integer;
    function GetIndexContact(Index: Integer): PICQ_Contact;
    function GetUINContact(UIN: DWORD): PICQ_Contact;

    function GetLibVersion: string;
    procedure SetLibVersion(Value: string); // fix to view lib version in object inspector

    function GetLicense: string;
    procedure SetLicense(Value: string); // fix to view lib version in object inspector

    procedure SetAllowRequest(Value: Boolean);

  public

    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;

    procedure Assign(Source: TPersistent); override;
    procedure Loaded; override;

    function NewSocket: Boolean;

    procedure ClearDisconnectReason;
    // -------------------------------------------------------------
    function Send_GetInfo(UIN: DWORD): Integer;
    function Send_GetExtInfo(UIN: DWORD): Integer;
    function Send_GetMetaInfo(UIN: DWORD): Integer;
    // -------------------------------------------------------------
    function Send_Message(UIN: DWORD; const Text: string; Send: ICQ_Send): Integer; // *
    function Send_Url(UIN: DWORD; const Url,Desc: string; Send: ICQ_Send): Integer;
    function Send_Search(UIN: DWORD; const Email,Nick,FirstName,LastName: string): Integer;
    function Send_FullSearch(
         const Email,Nick,FirstName,LastName: string;
         MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
         Lang: DWORD; const City,State: string; Country: DWORD;
         const Company,Department,Job: string;
         Occupation: DWORD;
         Background: DWORD; const BackgroundDesc: string;
         Affiliation: DWORD; const AffiliationDesc: string;
         Homepage: DWORD; const HomepageDesc: string;
         Online: Boolean): Integer;
    function Send_FullSearch2(
         const Email,Nick,FirstName,LastName: string;
         MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
         Lang: DWORD; const City,State: string; Country: DWORD;
         const Company,Department,Job: string;
         Occupation: DWORD;
         Background: DWORD; const BackgroundDesc: string;
         Interests: DWORD; const InterestsDesc: string;
         Affiliation: DWORD; const AffiliationDesc: string;
         Homepage: DWORD; const HomepageDesc: string;
         Online: Boolean): Integer;
    function Send_KeepAlive: Integer; // *
    function Send_ContactList: Integer;
    function Send_VisibleList: Integer;
    function Send_InvisibleList: Integer;
    function Send_Authorize(UIN: DWORD): Integer;
    function Send_AllowRequest: Integer;
    function Send_DeniedRequest: Integer;
    function Send_SetAuth(Auth: ICQ_Auth): Integer;
    // -------------------------------------------------------------
    function Send_SetUserInfo(const Nick,First,Last,Email: string): Integer;

    function Send_SetMetaInfo(
      const Nick,First,Last,
      Email,Email2,Email3,
      City,State,Phone,
      Fax,Street,Cellular: string;
      Zip,CountryCode,CountryStat: DWORD; HideEmail: Boolean): Integer;
    function Send_SetMetaInfo2(
      const Nick,First,Last,
      Email,Email2,Email3,
      City,State,Phone,
      Fax,Street,Cellular: string;
      Zip,CountryCode: DWORD; TimeOffset: Single; HideEmail: Boolean): Integer;

    function Send_SetMetaInfoMore(
      Age: DWORD; Gender: ICQ_Gender; const HomePage: string;
      BDate: TDateTime; Lang1,Lang2,Lang3: DWORD): Integer;
    function Send_SetMetaInfoHome(
      Age: DWORD; const HomePage: string;
      BDate: TDateTime; Lang1,Lang2,Lang3: DWORD): Integer;

    function Send_SetMetaInfoAbout(const About: string): Integer;
    function Send_SetMetaInfoSecurity(Auth: ICQ_Auth; Web,HideIp: Boolean): Integer;
    // -------------------------------------------------------------
    function Wait: Integer;
    function WaitTimeout(Timeout: DWORD): Integer;

    procedure SetContact(UIN: DWORD; Visible: Boolean);
    procedure SetContact2(UIN: DWORD; Visible,Invisible: Boolean);
    procedure DeleteIndexContact(Index: Integer);
    procedure DeleteUINContact(UIN: DWORD);
    procedure RemoveIndexContact(Index: Integer);
    procedure RemoveUINContact(UIN: DWORD);
    procedure ClearContactList;

  public

    property Socket: ICQ_Socket read FSocket write SetSocket;
    property Connecting: Boolean read GetConnecting;

    property DisconnectReason: Integer read GetDisconnectReason;

    property RedirectCount: Integer read GetRedirectCount;
    property RedirectHost: string read GetRedirectHost;
    property RedirectPort: Integer read GetRedirectPort;

    property ConnectHost: string read GetConnectHost;
    property ConnectPort: Integer read GetConnectPort;

    property ContactCount: Integer read GetContactCount;
    property UINContactIndex[UIN: DWORD]: Integer read GetUINContactIndex;
    property IndexContact[I: Integer]: PICQ_Contact read GetIndexContact;
    property UINContact[UIN: DWORD]: PICQ_Contact read GetUINContact;

    property Active: Boolean read GetActive write SetActive;
    property WaitTime: Integer read GetWaitTimeout;
    property IsWait: Boolean read GetWait;

    property AllowRequest: Boolean write SetAllowRequest;

    // begin old propertys
    property Timeout: Integer read GetTimeout write SetTimeout default 6000;
    property MaxAttempts: Integer read GetMaxAttempts write SetMaxAttempts default 10;
    property LastSendUDPSequence: DWORD read GetLastSendUDPSequence;
    // end old propertys

  published

    property ProtocolVersion: Integer read GetProtocolVersion write SetProtocolVersion;

    property AutoConnect: Boolean read GetAutoConnect write SetAutoConnect default True;
    property WaitConnect: Boolean read GetWaitConnect write SetWaitConnect default True;

    property Host: string read GetHost write SetHost;
    property HostPort: Integer read GetHostPort write SetHostPort default 4000;

    property UIN: DWORD read GetUIN write SetUIN default 0;
    property Nick: string read GetNick write SetNick;
    property Password: string read GetPassword write SetPassword;
    property MaxPassLen: Integer read GetMaxPassLen write SetMaxPassLen;

    property ProxyUsed: Boolean read GetProxyUsed write SetProxyUsed;
    property ProxyHost: string read GetProxyHost write SetProxyHost;
    property ProxyPort: Integer read GetProxyPort write SetProxyPort;
    property ProxyLoginUsed: Boolean read GetProxyLoginUsed write SetProxyLoginUsed;
    property ProxyUser: string read GetProxyUser write SetProxyUser;
    property ProxyPassword: string read GetProxyPassword write SetProxyPassword;

    property Status: ICQ_Status read GetStatus write SetStatus default ICQ_Status_Online;
    property LogLevel: ICQ_Log read GetLogLevel write SetLogLevel default ICQ_Log_Off;

    property LibVersion: string read GetLibVersion write SetLibVersion stored False;
    property License: string read GetLicense write SetLicense stored False;

    // events ------

    property OnError: TICQSocket_Error read FOnError write FOnError;

    property OnConnecting: TICQSocket_Connecting read FOnConnecting write FOnConnecting;
    property OnConnected: TICQSocket_Connected read FOnConnected write FOnConnected;
    property OnDisconnecting: TICQSocket_Disconnecting read FOnDisconnecting write FOnDisconnecting;
    property OnDisconnected: TICQSocket_Disconnected read FOnDisconnected write FOnDisconnected;
    property OnInvalidLogin: TICQSocket_InvalidLogin read FOnInvalidLogin write FOnInvalidLogin;

    property OnContactOnline: TICQSocket_ContactOnline read FOnContactOnline write FOnContactOnline;
    property OnContactOffline: TICQSocket_ContactOffline read FOnContactOffline write FOnContactOffline;
    property OnContactStatusUpdate: TICQSocket_ContactStatusUpdate read FOnContactStatusUpdate write FOnContactStatusUpdate;

    property OnUserFound: TICQSocket_UserFound read FOnUserFound write FOnUserFound;
    property OnEndFound: TICQSocket_EndFound read FOnEndFound write FOnEndFound;

    property OnNewUIN: TICQSocket_NewUIN read FOnNewUIN write FOnNewUIN;

    property OnProcessMessage: TICQSocket_ProcessMessage read FOnProcessMessage write FOnProcessMessage;
    property OnProcessUrl: TICQSocket_ProcessUrl read FOnProcessUrl write FOnProcessUrl;
    property OnProcessWebPager: TICQSocket_ProcessWebPager read FOnProcessWebPager write FOnProcessWebPager;
    property OnProcessAdded: TICQSocket_ProcessAdded read FOnProcessAdded write FOnProcessAdded;
    property OnProcessMailExpress: TICQSocket_ProcessMailExpress read FOnProcessMailExpress write FOnProcessMailExpress;

    property OnProcessChatRequest: TICQSocket_ProcessChatRequest read FOnProcessChatRequest write FOnProcessChatRequest;
    property OnProcessFileRequest: TICQSocket_ProcessFileRequest read FOnProcessFileRequest write FOnProcessFileRequest;
    property OnProcessAuthRequest: TICQSocket_ProcessAuthRequest read FOnProcessAuthRequest write FOnProcessAuthRequest;

    property OnUserNotFound: TICQSocket_UserNotFound read FOnUserNotFound write FOnUserNotFound;
    property OnUserInfo: TICQSocket_UserInfo read FOnUserInfo write FOnUserInfo;
    property OnExtUserInfo: TICQSocket_ExtUserInfo read FOnExtUserInfo write FOnExtUserInfo;

    property OnLog: TICQSocket_Log read FOnLog write FOnLog;
    property OnTimeout: TICQSocket_Timeout read FOnTimeout write FOnTimeout;

    property OnMetaUserFound: TICQSocket_MetaUserFound read FOnMetaUserFound write FOnMetaUserFound;
    property OnMetaUserInfo: TICQSocket_MetaUserInfo read FOnMetaUserInfo write FOnMetaUserInfo;
    property OnMetaUserWork: TICQSocket_MetaUserWork read FOnMetaUserWork write FOnMetaUserWork;
    property OnMetaUserMore: TICQSocket_MetaUserMore read FOnMetaUserMore write FOnMetaUserMore;
    property OnMetaUserAbout: TICQSocket_MetaUserAbout read FOnMetaUserAbout write FOnMetaUserAbout;

    property OnMetaUserInterests: TICQSocket_MetaUserInterests read FOnMetaUserInterests write FOnMetaUserInterests;
    property OnMetaUserAffiliations: TICQSocket_MetaUserAffiliations read FOnMetaUserAffiliations write FOnMetaUserAffiliations;
    property OnMetaUserHomePageCategory: TICQSocket_MetaUserHomePageCategory read FOnMetaUserHomePageCategory write FOnMetaUserHomePageCategory;

    property OnSrvUDPAck: TICQSocket_SrvUDPAck read FOnSrvUDPAck write FOnSrvUDPAck;
    property OnSrvTCPAck: TICQSocket_SrvTCPAck read FOnSrvTCPAck write FOnSrvTCPAck;

    property OnBeginWait: TICQSocket_BeginWait read FOnBeginWait write FOnBeginWait;
    property OnWait: TICQSocket_Wait read FOnWait write FOnWait;
    property OnWaitConnect: TICQSocket_WaitConnect read FOnWaitConnect write FOnWaitConnect;
    property OnEndWait: TICQSocket_EndWait read FOnEndWait write FOnEndWait;

    property OnWriteUDPPacket: TICQSocket_WriteUDPPacket read FOnWriteUDPPacket write FOnWriteUDPPacket;
    property OnReadUDPPacket: TICQSocket_ReadUDPPacket read FOnReadUDPPacket write FOnReadUDPPacket;

    property OnInvalidUIN: TICQSocket_InvalidUIN read FOnInvalidUIN write FOnInvalidUIN;
    property OnInvalidPassword: TICQSocket_InvalidPassword read FOnInvalidPassword write FOnInvalidPassword;

    property OnExtUserInfo2: TICQSocket_ExtUserInfo2 read FOnExtUserInfo2 write FOnExtUserInfo2;
    property OnMetaUserInfo2: TICQSocket_MetaUserInfo2 read FOnMetaUserInfo2 write FOnMetaUserInfo2;

    property OnMetaEndFound: TICQSocket_MetaEndFound read FOnMetaEndFound write FOnMetaEndFound;

    property OnWriteOscarPacket: TICQSocket_WriteOscarPacket read FOnWriteOscarPacket write FOnWriteOscarPacket;
    property OnReadOscarPacket: TICQSocket_ReadOscarPacket read FOnReadOscarPacket write FOnReadOscarPacket;
  end;

function ICQLib_GetVersion: DWORD;
function ICQLib_GetStrVersion: string;
function ICQLib_GetLicense: DWORD;
function ICQLib_GetPacketVersion(Index: Integer): Integer;
function ICQLib_GetMaxSocketCount: Integer;
function ICQLib_GetSocketCount: Integer;
function ICQLib_ForEach(F: TICQLib_ForEach_Function; P: Pointer): Integer;

function ICQLib_GetCountry(Key: DWORD; Lang: DWORD = 12): string;
function ICQLib_GetCountryRange(var Min,Max: DWORD): Boolean;

function ICQLib_GetBackground(Key: DWORD; Lang: DWORD = 12): string;
function ICQLib_GetBackgroundRange(var Min,Max: DWORD): Boolean;

function ICQLib_GetAffiliation(Key: DWORD; Lang: DWORD = 12): string;
function ICQLib_GetAffiliationRange(var Min,Max: DWORD): Boolean;

function ICQLib_GetLanguage(Key: DWORD; Lang: DWORD = 12): string;
function ICQLib_GetLanguageRange(var Min,Max: DWORD): Boolean;

function ICQLib_GetInterest(Key: DWORD; Lang: DWORD = 12): string;
function ICQLib_GetInterestRange(var Min,Max: DWORD): Boolean;

procedure Register;

implementation

Uses ICQ_Socket_pas,extctrls;

const
  KeepAliveTimerInterval = 2 * 60 * 1000 - 5 * 1000;
  PollTimerInterval = 1000;

type
  TICQLib = class(TObject)
  public
    Callback: ICQ_Callback;
    KeepAliveTimer, PollTimer: TTimer;

    constructor Create;
    destructor Destroy; override;

    procedure CheckVersion;

    procedure OnKeepAliveTimer(Sender: TObject);
    procedure OnPollTimer(Sender: TObject);

    function OnEachKeepAlive(Sender: TObject; P: Pointer): Boolean;
    function OnEachFree(Sender: TObject; P: Pointer): Boolean;
  end;

var
  ICQLib: TICQLib;

// ====================================================================

procedure Register;
begin
  RegisterComponents('Craft', [TICQSocket]);
end;
// ====================================================================
constructor TICQSocket.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  FSocket := ICQ_Invalid_Socket;
  NewSocket;
end;
destructor TICQSocket.Destroy;
begin
  //LogLevel := ICQ_Log_Off;
  ICQ_DeleteSocket(FSocket);
  inherited Destroy;
end;
procedure TICQSocket.Assign(Source: TPersistent);
var Src: TICQSocket;
begin
  if Source is TICQSocket then begin
    Src := TICQSocket(Source);

    Active := False;
    ProtocolVersion := Src.ProtocolVersion;
    AutoConnect := Src.AutoConnect;
    WaitConnect := Src.WaitConnect;
    Host := Src.Host;
    HostPort := Src.HostPort;
    UIN := Src.UIN;
    Nick := Src.Nick;
    Password := Src.Password;
    MaxPassLen := Src.MaxPassLen;
    ProxyUsed := Src.ProxyUsed;
    ProxyHost := Src.ProxyHost;
    ProxyPort := Src.ProxyPort;
    ProxyLoginUsed := Src.ProxyLoginUsed;
    ProxyUser := Src.ProxyUser;
    ProxyPassword := Src.ProxyPassword;
    Status := Src.Status;
    LogLevel := Src.LogLevel;
    Timeout := Src.Timeout;
    MaxAttempts := Src.MaxAttempts;

    OnError := Src.OnError;
    OnConnecting := Src.OnConnecting;
    OnConnected := Src.OnConnected;
    OnDisconnecting := Src.OnDisconnecting;
    OnDisconnected := Src.OnDisconnected;
    OnInvalidLogin := Src.OnInvalidLogin;
    OnContactOnline := Src.OnContactOnline;
    OnContactOffline := Src.OnContactOffline;
    OnContactStatusUpdate := Src.OnContactStatusUpdate;
    OnUserFound := Src.OnUserFound;
    OnEndFound := Src.OnEndFound;
    OnNewUIN := Src.OnNewUIN;
    OnProcessMessage := Src.OnProcessMessage;
    OnProcessUrl := Src.OnProcessUrl;
    OnProcessWebPager := Src.OnProcessWebPager;
    OnProcessAdded := Src.OnProcessAdded;
    OnProcessMailExpress := Src.OnProcessMailExpress;
    OnProcessChatRequest := Src.OnProcessChatRequest;
    OnProcessFileRequest := Src.OnProcessFileRequest;
    OnProcessAuthRequest := Src.OnProcessAuthRequest;
    OnUserNotFound := Src.OnUserNotFound;
    OnUserInfo := Src.OnUserInfo;
    OnExtUserInfo := Src.OnExtUserInfo;
    OnLog := Src.OnLog;
    OnTimeout := Src.OnTimeout;
    OnMetaUserFound := Src.OnMetaUserFound;
    OnMetaUserInfo := Src.OnMetaUserInfo;
    OnMetaUserWork := Src.OnMetaUserWork;
    OnMetaUserMore := Src.OnMetaUserMore;
    OnMetaUserAbout := Src.OnMetaUserAbout;
    OnMetaUserInterests := Src.OnMetaUserInterests;
    OnMetaUserAffiliations := Src.OnMetaUserAffiliations;
    OnMetaUserHomePageCategory := Src.OnMetaUserHomePageCategory;
    OnSrvUDPAck := Src.OnSrvUDPAck;
    OnSrvTCPAck := Src.OnSrvTCPAck;
    OnBeginWait := Src.OnBeginWait;
    OnWait := Src.OnWait;
    OnWaitConnect := Src.OnWaitConnect;
    OnEndWait := Src.OnEndWait;
    OnWriteUDPPacket := Src.OnWriteUDPPacket;
    OnReadUDPPacket := Src.OnReadUDPPacket;
    OnInvalidUIN := Src.OnInvalidUIN;
    OnInvalidPassword := Src.OnInvalidPassword;
    OnExtUserInfo2 := Src.OnExtUserInfo2;
    OnMetaUserInfo2 := Src.OnMetaUserInfo2;
    OnMetaEndFound := Src.OnMetaEndFound;
    OnWriteOscarPacket := Src.OnWriteOscarPacket;
    OnReadOscarPacket := Src.OnReadOscarPacket;
  end;
  inherited Assign(Source);
end;
// ====================================================================
procedure TICQSocket.SetSocket(Value: ICQ_Socket);
begin
  if FSocket = Value then Exit;
  ICQ_DeleteSocket(FSocket);
  FSocket := Value;
  ICQ_SetCallback(FSocket,@ICQLib.Callback);
  ICQ_SetUserPointer(FSocket,Self);
end;
// ====================================================================
function TICQSocket.NewSocket: Boolean;
begin
  Socket := ICQ_NewSocket;
  Result := Socket <> ICQ_Invalid_Socket;
end;
// ====================================================================
procedure TICQSocket.Loaded;
begin
  inherited Loaded;
end;
// ====================================================================
function TICQSocket.GetProtocolVersion: Integer;
begin
  Result := ICQ_GetProtocolVersion(FSocket);
end;
procedure TICQSocket.SetProtocolVersion(Value: Integer);
begin
  ICQ_SetProtocolVersion(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetActive: Boolean;
begin
  Result := ICQ_GetActive(FSocket);
end;
procedure TICQSocket.SetActive(Value: Boolean);
begin
  if (csDesigning in ComponentState) and Value then begin
    MessageBox(0,'Cant Active in Designing process!','Error',
      MB_OK or MB_ICONWARNING);
    Exit;
  end;
{  if FSocket = ICQ_Invalid_Socket then begin
    if Assigned(OnError) then OnError(self,ICQ_Result_CreateError);
  end else }
  ICQ_SetActive(FSocket,Value);
//  Wait;
end;
// ====================================================================
function TICQSocket.GetAutoConnect: Boolean;
begin
  Result := ICQ_GetAutoConnect(FSocket);
end;
procedure TICQSocket.SetAutoConnect(Value: Boolean);
begin
  ICQ_SetAutoConnect(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetWaitConnect: Boolean;
begin
  Result := ICQ_GetWaitConnect(FSocket);
end;
procedure TICQSocket.SetWaitConnect(Value: Boolean);
begin
  ICQ_SetWaitConnect(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetHost: string;
begin
  Result := ICQ_GetHost(FSocket);
end;
procedure TICQSocket.SetHost(Value: string);
begin
  ICQ_SetHost(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetHostPort: Integer;
begin
  Result := ICQ_GetHostPort(FSocket);
end;
procedure TICQSocket.SetHostPort(Value: Integer);
begin
  ICQ_SetHostPort(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetUIN: DWORD;
begin
  Result := ICQ_GetUIN(FSocket);
end;
procedure TICQSocket.SetUIN(Value: DWORD);
begin
  ICQ_SetUIN(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetNick: string;
begin
  Result := ICQ_GetNick(FSocket);
end;
procedure TICQSocket.SetNick(Value: string);
begin
  ICQ_SetNick(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetPassword: string;
begin
  Result := ICQ_GetPass(FSocket);
end;
procedure TICQSocket.SetPassword(Value: string);
begin
  ICQ_SetPass(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetMaxPassLen: Integer;
begin
  Result := ICQ_GetMaxPassLen(FSocket);
end;
procedure TICQSocket.SetMaxPassLen(Value: Integer);
begin
  ICQ_SetMaxPassLen(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetProxyUsed: Boolean;
begin
  Result := ICQ_GetProxyUsed(FSocket);
end;
procedure TICQSocket.SetProxyUsed(Value: Boolean);
begin
  ICQ_SetProxyUsed(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetProxyHost: string;
begin
  Result := ICQ_GetProxyHost(FSocket);
end;
procedure TICQSocket.SetProxyHost(Value: string);
begin
  ICQ_SetProxyHost(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetProxyPort: Integer;
begin
  Result := ICQ_GetProxyPort(FSocket);
end;
procedure TICQSocket.SetProxyPort(Value: Integer);
begin
  ICQ_SetProxyPort(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetProxyLoginUsed: Boolean;
begin
  Result := ICQ_GetProxyLoginUsed(FSocket);
end;
procedure TICQSocket.SetProxyLoginUsed(Value: Boolean);
begin
  ICQ_SetProxyLoginUsed(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetProxyUser: string;
begin
  Result := ICQ_GetProxyUser(FSocket);
end;
procedure TICQSocket.SetProxyUser(Value: string);
begin
  ICQ_SetProxyUser(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetProxyPassword: string;
begin
  Result := ICQ_GetProxyPass(FSocket);
end;
procedure TICQSocket.SetProxyPassword(Value: string);
begin
  ICQ_SetProxyPass(FSocket,PChar(Value));
end;
// ====================================================================
function TICQSocket.GetStatus: ICQ_Status;
begin
  Result := ICQ_GetStatus(FSocket);
end;
procedure TICQSocket.SetStatus(Value: ICQ_Status);
begin
  ICQ_SetStatus(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetLogLevel: ICQ_Log;
begin
  Result := ICQ_GetLogLevel(FSocket);
end;
procedure TICQSocket.SetLogLevel(Value: ICQ_Log);
begin
  ICQ_SetLogLevel(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetTimeout: Integer;
begin
  Result := ICQ_GetTimeout(FSocket);
end;
procedure TICQSocket.SetTimeout(Value: Integer);
begin
  ICQ_SetTimeout(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetWaitTimeout: Integer;
begin
  Result := ICQ_GetWaitTimeout(FSocket);
end;
function TICQSocket.GetConnecting: Boolean;
begin
  Result := ICQ_GetConnecting(FSocket);
end;
// ====================================================================
function TICQSocket.GetMaxAttempts: Integer;
begin
  Result := ICQ_GetMaxAttempts(FSocket);
end;
procedure TICQSocket.SetMaxAttempts(Value: Integer);
begin
  ICQ_SetMaxAttempts(FSocket,Value);
end;
// ====================================================================
function TICQSocket.GetWait: Boolean;
begin
  Result := ICQ_GetWait(FSocket);
end;
// ====================================================================
function TICQSocket.GetDisconnectReason: Integer;
begin
  Result := ICQ_GetDisconnectReason(FSocket);
end;
procedure TICQSocket.ClearDisconnectReason;
begin
  ICQ_ClearDisconnectReason(FSocket);
end;
// ====================================================================
function TICQSocket.GetRedirectCount: Integer;
begin
  Result := ICQ_GetRedirectCount(FSocket);
end;
// ====================================================================
function TICQSocket.GetRedirectHost: string;
begin
  Result := ICQ_GetRedirectHost(FSocket);
end;
function TICQSocket.GetRedirectPort: Integer;
begin
  Result := ICQ_GetRedirectPort(FSocket);
end;
// ====================================================================
function TICQSocket.GetConnectHost: string;
begin
  Result := ICQ_GetConnectHost(FSocket);
end;
function TICQSocket.GetConnectPort: Integer;
begin
  Result := ICQ_GetConnectPort(FSocket);
end;
// ====================================================================
function TICQSocket.GetLastSendUDPSequence: DWORD;
begin
  Result := ICQ_GetLastSendUDPSequence(FSocket);
end;
// ====================================================================
function TICQSocket.GetContactCount: Integer;
begin
  Result := ICQ_GetContactCount(FSocket);
end;
// ====================================================================
function TICQSocket.GetUINContactIndex(UIN: DWORD): Integer;
begin
  Result := ICQ_GetUINContactIndex(FSocket,UIN);
end;
// ====================================================================
function TICQSocket.GetIndexContact(Index: Integer): PICQ_Contact;
begin
  Result := ICQ_GetIndexContact(FSocket,Index);
end;
// ====================================================================
function TICQSocket.GetUINContact(UIN: DWORD): PICQ_Contact;
begin
  Result := ICQ_GetUINContact(FSocket,UIN);
end;
// ====================================================================
procedure TICQSocket.SetLibVersion(Value: string);
begin
end;

function TICQSocket.GetLibVersion: string;
begin
  Result := ICQLib_GetStrVersion;
end;

procedure TICQSocket.SetLicense(Value: string);
begin
end;

function TICQSocket.GetLicense: string;
var L: DWORD;
begin
  L := ICQLib_GetLicense;
  case L of
    1: Result := '1: Ограниченная лицензия для частных лиц';
    2: Result := '2: Ограниченная лицензия для организаций';
    3: Result := '3: Лицензия для частных лиц';
    4: Result := '4: Лицензия для организаций';
    5: Result := '5: Профессиональная лицензия для частных лиц';
    6: Result := '6: Профессиональная лицензия для организаций';
    else Result := Format('Лицензия %d',[L]);
  end;
end;
// ====================================================================
procedure TICQSocket.SetAllowRequest(Value: Boolean);
begin
  if Value then
    Send_AllowRequest else
    Send_DeniedRequest;
end;
// ====================================================================
function TICQSocket.Send_GetInfo(UIN: DWORD): Integer;
begin
  Result := ICQ_Send_GetInfo(FSocket,UIN);
end;
// ====================================================================
function TICQSocket.Send_GetExtInfo(UIN: DWORD): Integer;
begin
  Result := ICQ_Send_GetExtInfo(FSocket,UIN);
end;
// ====================================================================
function TICQSocket.Send_GetMetaInfo(UIN: DWORD): Integer;
begin
  Result := ICQ_Send_GetMetaInfo(FSocket,UIN);
end;
// ====================================================================
function TICQSocket.Send_Message(UIN: DWORD; const Text: string; Send: ICQ_Send): Integer;
begin
  Result := ICQ_Send_Message(FSocket,UIN,PChar(Text),Send);
end;
// ====================================================================
function TICQSocket.Send_Url(UIN: DWORD; const Url,Desc: string; Send: ICQ_Send): Integer;
begin
  Result := ICQ_Send_Url(FSocket,UIN,PChar(Url),PChar(Desc),Send);
end;
// ====================================================================
function TICQSocket.Send_Search(UIN: DWORD; const Email,Nick,FirstName,LastName: string): Integer;
begin
  Result := ICQ_Send_Search(FSocket,UIN,PChar(Email),PChar(Nick),PChar(FirstName),PChar(LastName));
end;
function TICQSocket.Send_FullSearch(
     const Email,Nick,FirstName,LastName: string;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; const City,State: string; Country: DWORD;
     const Company,Department,Job: string;
     Occupation: DWORD;
     Background: DWORD; const BackgroundDesc: string;
     Affiliation: DWORD; const AffiliationDesc: string;
     Homepage: DWORD; const HomepageDesc: string;
     Online: Boolean): Integer;
begin
  Result := ICQ_Send_FullSearch(FSocket,PChar(Email),PChar(Nick),PChar(FirstName),
    PChar(LastName),MinAge,MaxAge,Gender,Lang,PChar(City),PChar(State),Country,
    PChar(Company),PChar(Department),PChar(Job),Occupation,
    Background,PChar(BackgroundDesc),Affiliation,PChar(AffiliationDesc),
    Homepage,PChar(HomepageDesc),Online);
end;
function TICQSocket.Send_FullSearch2(
     const Email,Nick,FirstName,LastName: string;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; const City,State: string; Country: DWORD;
     const Company,Department,Job: string;
     Occupation: DWORD;
     Background: DWORD; const BackgroundDesc: string;
     Interests: DWORD; const InterestsDesc: string;
     Affiliation: DWORD; const AffiliationDesc: string;
     Homepage: DWORD; const HomepageDesc: string;
     Online: Boolean): Integer;
begin
  Result := ICQ_Send_FullSearch2(FSocket,PChar(Email),PChar(Nick),PChar(FirstName),
    PChar(LastName),MinAge,MaxAge,Gender,Lang,PChar(City),PChar(State),Country,
    PChar(Company),PChar(Department),PChar(Job),Occupation,
    Background,PChar(BackgroundDesc),Interests,PChar(AffiliationDesc),
    Affiliation,PChar(AffiliationDesc),Homepage,PChar(HomepageDesc),Online);
end;
// ====================================================================
function TICQSocket.Send_KeepAlive: Integer;
begin
  Result := ICQ_Send_KeepAlive(FSocket);
end;
// ====================================================================
function TICQSocket.Send_ContactList: Integer;
begin
  Result := ICQ_Send_ContactList(FSocket);
end;
function TICQSocket.Send_VisibleList: Integer;
begin
  Result := ICQ_Send_VisibleList(FSocket);
end;
function TICQSocket.Send_InvisibleList: Integer;
begin
  Result := ICQ_Send_InvisibleList(FSocket);
end;
// ====================================================================
function TICQSocket.Send_SetAuth(Auth: ICQ_Auth): Integer;
begin
  Result := ICQ_Send_SetAuth(FSocket,Auth);
end;
// ====================================================================
function TICQSocket.Send_Authorize(UIN: DWORD): Integer;
begin
  Result := ICQ_Send_Authorize(FSocket,UIN);
end;
// ====================================================================
function TICQSocket.Send_AllowRequest: Integer;
begin
  Result := ICQ_Send_AllowRequest(FSocket);
end;
function TICQSocket.Send_DeniedRequest: Integer;
begin
  Result := ICQ_Send_DeniedRequest(FSocket);
end;
// ====================================================================
function TICQSocket.Send_SetUserInfo(const Nick,First,Last,Email: string): Integer;
begin
  Result := ICQ_Send_SetUserInfo(FSocket,PChar(Nick),PChar(First),PChar(Last),PChar(Email));
end;
// ====================================================================
function TICQSocket.Send_SetMetaInfo(
  const Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: string;
  Zip,CountryCode,CountryStat: DWORD; HideEmail: Boolean): Integer;
begin
  Result := ICQ_Send_SetMetaInfo(FSocket,
    PChar(Nick),PChar(First),PChar(Last),
    PChar(Email),PChar(Email2),PChar(Email3),
    PChar(City),PChar(State),PChar(Phone),
    PChar(Fax),PChar(Street),PChar(Cellular),
    Zip,CountryCode,CountryStat,HideEmail);
end;
// ====================================================================
function TICQSocket.Send_SetMetaInfo2(
  const Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: string;
  Zip,CountryCode: DWORD; TimeOffset: Single; HideEmail: Boolean): Integer;
begin
  Result := ICQ_Send_SetMetaInfo2(FSocket,
    PChar(Nick),PChar(First),PChar(Last),
    PChar(Email),PChar(Email2),PChar(Email3),
    PChar(City),PChar(State),PChar(Phone),
    PChar(Fax),PChar(Street),PChar(Cellular),
    Zip,CountryCode,TimeOffset,HideEmail);
end;
// ====================================================================
function TICQSocket.Send_SetMetaInfoMore(
  Age: DWORD; Gender: ICQ_Gender; const HomePage: string;
  BDate: TDateTime; Lang1,Lang2,Lang3: DWORD): Integer;
var BYear,BMonth,BDay: Word;
begin
  if BDate = ICQ_VoidDate then begin
    BYear := 0;
    BMonth := 0;
    BDay := 0;
  end else begin
    DecodeDate(BDate,BYear,BMonth,BDay);
  end;
  Result := ICQ_Send_SetMetaInfoMore(FSocket,Age,Gender,PChar(HomePage),
    BYear,BMonth,BDay,Lang1,Lang2,Lang3);
end;
function TICQSocket.Send_SetMetaInfoHome(
  Age: DWORD; const HomePage: string;
  BDate: TDateTime; Lang1,Lang2,Lang3: DWORD): Integer;
var BYear,BMonth,BDay: Word;
begin
  if BDate = ICQ_VoidDate then begin
    BYear := 0;
    BMonth := 0;
    BDay := 0;
  end else begin
    DecodeDate(BDate,BYear,BMonth,BDay);
  end;
  Result := ICQ_Send_SetMetaInfoHome(FSocket,Age,PChar(HomePage),
    BYear,BMonth,BDay,Lang1,Lang2,Lang3);
end;
// ====================================================================
function TICQSocket.Send_SetMetaInfoAbout(const About: string): Integer;
begin
  Result := ICQ_Send_SetMetaInfoAbout(FSocket,PChar(About));
end;
// ====================================================================
function TICQSocket.Send_SetMetaInfoSecurity(Auth: ICQ_Auth; Web,HideIp: Boolean): Integer;
begin
  Result := ICQ_Send_SetMetaInfoSecurity(FSocket,Auth,Web,HideIp);
end;
// ====================================================================
function TICQSocket.Wait: Integer;
begin
  Result := ICQ_Wait(FSocket);
end;
// ====================================================================
function TICQSocket.WaitTimeout(Timeout: DWORD): Integer;
begin
  Result := ICQ_WaitTimeout(FSocket,Timeout);
end;
// ====================================================================
procedure TICQSocket.SetContact(UIN: DWORD; Visible: Boolean);
begin
  ICQ_SetContact(FSocket,UIN,Visible);
end;
procedure TICQSocket.SetContact2(UIN: DWORD; Visible,Invisible: Boolean);
begin
  ICQ_SetContact2(FSocket,UIN,Visible,Invisible);
end;
// ====================================================================
procedure TICQSocket.DeleteIndexContact(Index: Integer);
begin
  ICQ_DeleteIndexContact(FSocket,Index);
end;
procedure TICQSocket.DeleteUINContact(UIN: DWORD);
begin
  ICQ_DeleteUINContact(FSocket,UIN);
end;
procedure TICQSocket.RemoveIndexContact(Index: Integer);
begin
  ICQ_RemoveIndexContact(FSocket,Index);
end;
procedure TICQSocket.RemoveUINContact(UIN: DWORD);
begin
  ICQ_RemoveUINContact(FSocket,UIN);
end;
// ====================================================================
procedure TICQSocket.ClearContactList;
begin
  ICQ_ClearContactList(FSocket);
end;
// ====================================================================
// ====================================================================
// ====================================================================
// ====================================================================
// ====================================================================
var FailExceptCount: Integer;
procedure HandleException(Socket: TICQSocket);
begin
  try
    Application.HandleException(Socket);
  except
    Inc(FailExceptCount);
  end;
end;

function EncodeDateTime(y,m,d,h,n: Integer): TDateTime;
begin
  try
    Result := EncodeDate(y,m,d) + EncodeTime(h,n,0,0);
  except
    Result := ICQ_VoidDate;
  end;
end;

procedure Callback_Connecting(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnConnecting) then
      Socket.OnConnecting(Socket);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_Connected(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnConnected) then
      Socket.OnConnected(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_Disconnecting(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnDisconnecting) then
      Socket.OnDisconnecting(Socket);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_Disconnected(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnDisconnected) then
      Socket.OnDisconnected(Socket);
  except
    HandleException(Socket);
  end;
end;

// user...
procedure Callback_ContactOnline(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnContactOnline) then
      Socket.OnContactOnline(Socket,Contact^);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_ContactOffline(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnContactOffline) then
      Socket.OnContactOffline(Socket,Contact^);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ContactStatusUpdate(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnContactStatusUpdate) then
      Socket.OnContactStatusUpdate(Socket,Contact^);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_UserFound(S: ICQ_Socket; UIN: DWORD;
  Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnUserFound) then
      Socket.OnUserFound(Socket,UIN,Nick,First,Last,Email,Auth);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_EndFound(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnEndFound) then
      Socket.OnEndFound(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_NewUIN(S: ICQ_Socket; UIN: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnNewUIN) then
      Socket.OnNewUIN(Socket,UIN);
  except
    HandleException(Socket);
  end;
end;

// Process...
procedure Callback_ProcessMessage(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD; Msg: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessMessage) then
      Socket.OnProcessMessage(Socket,UIN,
        EncodeDateTime(Year,Month,Day,Hour,Minute),Msg );
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessUrl(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD;
  Url,Desc: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessUrl) then
      Socket.OnProcessUrl(Socket,UIN,EncodeDateTime(Year,Month,Day,Hour,Minute),Url,Desc);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessWebPager(S: ICQ_Socket;
  Year,Month,Day,Hour,Minute: DWORD;
  Nick,Email,Msg: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessWebPager) then
      Socket.OnProcessWebPager(Socket,EncodeDateTime(Year,Month,Day,Hour,Minute),
        Nick,Email,Msg);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessAdded(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD;
  Nick,First,Last,Email: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessAdded) then
      Socket.OnProcessAdded(Socket,UIN,EncodeDateTime(Year,Month,Day,Hour,Minute),
        Nick,First,Last,Email);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessMailExpress(S: ICQ_Socket;
  Year,Month,Day,Hour,Minute: DWORD;
  Nick,Email,Msg: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessMailExpress) then
      Socket.OnProcessMailExpress(Socket,EncodeDateTime(Year,Month,Day,Hour,Minute),
        Nick,Email,Msg);
  except
    HandleException(Socket);
  end;
end;

// request
procedure Callback_ProcessChatRequest(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD; Desc: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessChatRequest) then
      Socket.OnProcessChatRequest(Socket,UIN,EncodeDateTime(Year,Month,Day,Hour,Minute),
        Desc);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessFileRequest(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD;
  Desc,FileName: PChar; filesize: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessFileRequest) then
      Socket.OnProcessFileRequest(Socket,UIN,EncodeDateTime(Year,Month,Day,Hour,Minute),
        Desc,FileName,filesize);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ProcessAuthRequest(S: ICQ_Socket;
  UIN,Year,Month,Day,Hour,Minute: DWORD;
  Nick,First,Last,Email,Reson: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnProcessAuthRequest) then
      Socket.OnProcessAuthRequest(Socket,UIN,
        EncodeDateTime(Year,Month,Day,Hour,Minute),
        Nick,First,Last,Email,Reson );
  except
    HandleException(Socket);
  end;
end;

// info ...
procedure Callback_UserNotFound(S: ICQ_Socket; UIN: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnUserNotFound) then
      Socket.OnUserNotFound(Socket,UIN);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_UserInfo(S: ICQ_Socket; UIN: DWORD;
  Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnUserInfo) then
      Socket.OnUserInfo(Socket,UIN,Nick,First,Last,Email,Auth);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ExtUserInfo(S: ICQ_Socket; UIN: DWORD;
  City: PChar; CountryCode,CountryStat: DWORD;
  State: PChar; Age: DWORD; Gender: ICQ_Gender;
  Phone,HomePage,About: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnExtUserInfo) then
      Socket.OnExtUserInfo(Socket,UIN,
        City,CountryCode,CountryStat,
        State,Age,Gender,
        Phone,HomePage,About);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ExtUserInfo2(S: ICQ_Socket; UIN: DWORD;
  City: PChar; CountryCode: DWORD; TimeOffset: Single;
  State: PChar; Age: DWORD; Gender: ICQ_Gender;
  Phone,HomePage,About: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnExtUserInfo2) then
      Socket.OnExtUserInfo2(Socket,UIN,
        City,CountryCode,TimeOffset,
        State,Age,Gender,
        Phone,HomePage,About);
  except
    HandleException(Socket);
  end;
end;

// Ack
procedure Callback_SrvUDPAck(S: ICQ_Socket; Sequence: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnSrvUDPAck) then
      Socket.OnSrvUDPAck(Socket,Sequence);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_SrvTCPAck(S: ICQ_Socket; ID: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnSrvTCPAck) then
      Socket.OnSrvTCPAck(Socket,ID);
  except
    HandleException(Socket);
  end;
end;

// Misc
procedure Callback_Log(S: ICQ_Socket; Level: ICQ_Log; Str: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnLog) then
      Socket.OnLog(Socket,Level,Str);
  except
    HandleException(Socket);
  end;
end;
function Callback_Wait(S: ICQ_Socket; WaitPointer: Pointer; var WaitResult: Integer): BOOL; cdecl;
var Socket: TICQSocket;
begin
  Result := True;
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnWait) then
      Result := Socket.OnWait(Socket,WaitResult);
  except
    HandleException(Socket);
  end;
end;

// Meta user...
procedure Callback_MetaUserFound(S: ICQ_Socket;
     UIN: DWORD; Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserFound) then
      Socket.OnMetaUserFound(Socket,UIN,Nick,First,Last,Email,Auth);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaEndFound(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaEndFound) then
      Socket.OnMetaEndFound(Socket);
  except
    HandleException(Socket);
  end;
end;


procedure Callback_MetaUserInfo(S: ICQ_Socket;
     Nick,First,Last,
     PriEml,SecEml,OldEml,
     City,State,Phone,Fax,
     Street,Cellular: PChar;
     Zip,Country,TimeZone: DWORD; Auth: ICQ_Auth;
     Web,HideIp: BOOL); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserInfo) then
      Socket.OnMetaUserInfo(Socket,
         Nick,First,Last,
         PriEml,SecEml,OldEml,
         City,State,Phone,Fax,
         Street,Cellular,
         Zip,Country,TimeZone,Auth,
         Web,HideIp);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserInfo2(S: ICQ_Socket;
     Nick,First,Last,
     PriEml,SecEml,OldEml,
     City,State,Phone,Fax,
     Street,Cellular: PChar;
     Zip,Country: DWORD; TimeOffset: Single; Auth: ICQ_Auth;
     Web,HideIp: BOOL); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserInfo2) then
      Socket.OnMetaUserInfo2(Socket,
         Nick,First,Last,
         PriEml,SecEml,OldEml,
         City,State,Phone,Fax,
         Street,Cellular,
         Zip,Country,TimeOffset,Auth,
         Web,HideIp);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserWork(S: ICQ_Socket;
     City,State,Phone,
     Fax,Address: PChar;
     Zip,Country: DWORD; Company,Department,Job: PChar;
     Occupation: DWORD; HomePage: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserWork) then
      Socket.OnMetaUserWork(Socket,City,State,Phone,
       Fax,Address,Zip,Country,Company,Department,Job,
       Occupation,HomePage);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserMore(S: ICQ_Socket;
     Age: DWORD; Gender: ICQ_Gender; HomePage: PChar;
     BYear,BMonth,BDay,
     Lang1,Lang2,Lang3: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserMore) then
      Socket.OnMetaUserMore(Socket,Age,Gender,HomePage,
        EncodeDateTime(BYear,BMonth,BDay,0,0),
        Lang1,Lang2,Lang3);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserAbout(S: ICQ_Socket; About: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserAbout) then
      Socket.OnMetaUserAbout(Socket,About);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserInterests(S: ICQ_Socket;
     Num: DWORD;
     Cat1: DWORD; Int1: PChar;
     Cat2: DWORD; Int2: PChar;
     Cat3: DWORD; Int3: PChar;
     Cat4: DWORD; Int4: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserInterests) then
      Socket.OnMetaUserInterests(Socket,Num,
        Cat1,Int1,
        Cat2,Int2,
        Cat3,Int3,
        Cat4,Int4 );
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserAffiliations(S: ICQ_Socket;
     Num: DWORD;
     Cat1: DWORD; Aff1: PChar;
     Cat2: DWORD; Aff2: PChar;
     Cat3: DWORD; Aff3: PChar;
     Cat4: DWORD; Aff4: PChar;

     BNum: DWORD;
     BCat1: DWORD; BAck1: PChar;
     BCat2: DWORD; BAck2: PChar;
     BCat3: DWORD; BAck3: PChar;
     BCat4: DWORD; BAck4: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserAffiliations) then
      Socket.OnMetaUserAffiliations(Socket,Num,
        Cat1,Aff1,
        Cat2,Aff2,
        Cat3,Aff3,
        Cat4,Aff4,
        BNum,
        BCat1,BAck1,
        BCat2,BAck2,
        BCat3,BAck3,
        BCat4,BAck4 );
  except
    HandleException(Socket);
  end;
end;

procedure Callback_MetaUserHomePageCategory(S: ICQ_Socket;
  Num,Cat: DWORD; Text: PChar); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnMetaUserHomePageCategory) then
      Socket.OnMetaUserHomePageCategory(Socket,Num,Cat,Text);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_Timeout(S: ICQ_Socket; CurAttempt,Sequence: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnTimeout) then
      Socket.OnTimeout(Socket,CurAttempt,Sequence);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_BeginWait(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnBeginWait) then
      Socket.OnBeginWait(Socket);
  except
    HandleException(Socket);
  end;
end;
procedure Callback_EndWait(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnEndWait) then
      Socket.OnEndWait(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_WaitConnect(S: ICQ_Socket; WaitTime: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnWaitConnect) then
      Socket.OnWaitConnect(Socket,WaitTime);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_InvalidLogin(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnInvalidLogin) then
      Socket.OnInvalidLogin(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_InvalidPassword(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnInvalidPassword) then
      Socket.OnInvalidPassword(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_InvalidUIN(S: ICQ_Socket); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnInvalidUIN) then
      Socket.OnInvalidPassword(Socket);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_WriteUDPPacket(S: ICQ_Socket;
    Data,CryptData: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen,Sequence: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnWriteUDPPacket) then
      Socket.OnWriteUDPPacket(Socket,Data,CryptData,Len,
        ProxyHeader,ProxyHeaderLen,Sequence);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ReadUDPPacket(S: ICQ_Socket;
    Data: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnReadUDPPacket) then
      Socket.OnReadUDPPacket(Socket,Data,Len,ProxyHeader,ProxyHeaderLen);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_WriteOscarPacket(S: ICQ_Socket;
    Data: Pointer; Len: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnWriteOscarPacket) then
      Socket.OnWriteOscarPacket(Socket,Data,Len);
  except
    HandleException(Socket);
  end;
end;

procedure Callback_ReadOscarPacket(S: ICQ_Socket;
    Data: Pointer; Len: DWORD); cdecl;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(ICQ_GetUserPointer(S));
  try
    if not Assigned(Socket) then Exit;
    if Assigned(Socket.OnReadOscarPacket) then
      Socket.OnReadOscarPacket(Socket,Data,Len);
  except
    HandleException(Socket);
  end;
end;

//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================
function ICQLib_GetVersion: DWORD;
begin
  Result := ICQ_GetLibVersion;
end;
function ICQLib_GetStrVersion: string;
var Ver: DWORD; ByteVer: array [0..3] of Byte absolute Ver;

  function PostStr: string;
  begin
    case Ver and 3 of
      0: Result := 'BETA NOT REGISTERED';
      1: Result := 'BETA REGISTERED';
      2: Result := 'NOT REGISTERED';
      3: Result := 'REGISTERED';
    end;
  end;

begin
  Ver := ICQLib_GetVersion;
  Result :=
    Format('%d.%d.%d [%d] %s',
      [ ByteVer[2],ByteVer[1],
        ByteVer[0],ByteVer[3],
        PostStr ] );
end;
function ICQLib_GetLicense: DWORD;
begin
  Result := ICQ_GetLicense;
end;
function ICQLib_GetPacketVersion(Index: Integer): Integer;
begin
  Result := ICQ_GetPacketVersion(Index);
end;
function ICQLib_GetMaxSocketCount: Integer;
begin
  Result := ICQ_GetMaxSocketCount;
end;
function ICQLib_GetSocketCount: Integer;
begin
  Result := ICQ_GetSocketCount;
end;
//=============================================================================
type
  PForEachStruct = ^TForEachStruct;
  TForEachStruct = record
    F: TICQLib_ForEach_Function;
    P: Pointer;
  end;

  function ICQLib_ForEach_Function(S: ICQ_Socket; P: Pointer): BOOL; cdecl;
  var Socket: TICQSocket; PS: PForEachStruct;
  begin
    Result := False;
    PS := PForEachStruct(P);
    Socket := TICQSocket(ICQ_GetUserPointer(S));
    try
      if not Assigned(Socket) then Exit;
      Result := PS^.F(Socket,PS^.P);
    except
      HandleException(Socket);
    end;
  end;

function ICQLib_ForEach(F: TICQLib_ForEach_Function; P: Pointer): Integer;
var S: TForEachStruct;
begin
  S.F := F;
  S.P := P;
  Result := ICQ_ForEach(ICQLib_ForEach_Function,@S);
end;
//=============================================================================
function ICQLib_GetCountry(Key: DWORD; Lang: DWORD = 12): string;
begin
  Result := ICQ_GetCountry(Key,Lang);
end;
function ICQLib_GetCountryRange(var Min,Max: DWORD): Boolean;
begin
  Result := ICQ_GetCountryRange(Min,Max);
end;
//=============================================================================
function ICQLib_GetBackground(Key: DWORD; Lang: DWORD = 12): string;
begin
  Result := ICQ_GetBackground(Key,Lang);
end;
function ICQLib_GetBackgroundRange(var Min,Max: DWORD): Boolean;
begin
  Result := ICQ_GetBackgroundRange(Min,Max);
end;
//=============================================================================
function ICQLib_GetAffiliation(Key: DWORD; Lang: DWORD = 12): string;
begin
  Result := ICQLib_GetAffiliation(Key,Lang);
end;
function ICQLib_GetAffiliationRange(var Min,Max: DWORD): Boolean;
begin
  Result := ICQLib_GetAffiliationRange(Min,Max);
end;
//=============================================================================
function ICQLib_GetLanguage(Key: DWORD; Lang: DWORD = 12): string;
begin
  Result := ICQLib_GetLanguage(Key,Lang);
end;
function ICQLib_GetLanguageRange(var Min,Max: DWORD): Boolean;
begin
  Result := ICQLib_GetLanguageRange(Min,Max);
end;
//=============================================================================
function ICQLib_GetInterest(Key: DWORD; Lang: DWORD = 12): string;
begin
  Result := ICQLib_GetInterest(Key,Lang);
end;
function ICQLib_GetInterestRange(var Min,Max: DWORD): Boolean;
begin
  Result := ICQLib_GetInterestRange(Min,Max);
end;
//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================
constructor TICQLib.Create;
begin
  inherited Create;

//  LibVersion := ICQ_GetLibVersion;

  KeepAliveTimer := TTimer.Create(nil);
  KeepAliveTimer.Enabled := False;
  KeepAliveTimer.OnTimer := OnKeepAliveTimer;
  KeepAliveTimer.Interval := KeepAliveTimerInterval;

  PollTimer := TTimer.Create(nil);
  PollTimer.Enabled := False;
  PollTimer.OnTimer := OnPollTimer;
  PollTimer.Interval := PollTimerInterval;

  ZeroMemory(@Callback,sizeof(Callback));
  Callback.dwSize := sizeof(Callback);

  Callback.Connecting := Callback_Connecting;
  Callback.Connected := Callback_Connected;
  Callback.Disconnecting := Callback_Disconnecting;
  Callback.Disconnected := Callback_Disconnected;

  // user...
  Callback.ContactOnline := Callback_ContactOnline;
  Callback.ContactOffline := Callback_ContactOffline;
  Callback.ContactStatusUpdate := Callback_ContactStatusUpdate;

  Callback.UserFound := Callback_UserFound;
  Callback.EndFound := Callback_EndFound;
  Callback.NewUIN := Callback_NewUIN;

  // Process...
  Callback.ProcessMessage := Callback_ProcessMessage;
  Callback.ProcessUrl := Callback_ProcessUrl;
  Callback.ProcessWebPager := Callback_ProcessWebPager;
  Callback.ProcessAdded := Callback_ProcessAdded;
  Callback.ProcessMailExpress := Callback_ProcessMailExpress;

  // request
  Callback.ProcessChatRequest := Callback_ProcessChatRequest;
  Callback.ProcessFileRequest := Callback_ProcessFileRequest;
  Callback.ProcessAuthRequest := Callback_ProcessAuthRequest;

  // info ...
  Callback.UserNotFound := Callback_UserNotFound;
  Callback.UserInfo := Callback_UserInfo;
  Callback.ExtUserInfo := Callback_ExtUserInfo;

  // Ack
  Callback.SrvUDPAck := Callback_SrvUDPAck;
  Callback.SrvTCPAck := Callback_SrvTCPAck;

  // Misc
  Callback.Log := Callback_Log;
  Callback.Wait := Callback_Wait;
  Callback.WaitConnect := Callback_WaitConnect;
  Callback.Timeout := Callback_Timeout;

  // Meta user...
  Callback.MetaUserFound := Callback_MetaUserFound;
  Callback.MetaUserInfo := Callback_MetaUserInfo;
  Callback.MetaUserWork := Callback_MetaUserWork;
  Callback.MetaUserMore := Callback_MetaUserMore;
  Callback.MetaUserAbout := Callback_MetaUserAbout;
  Callback.MetaUserInterests := Callback_MetaUserInterests;
  Callback.MetaUserAffiliations := Callback_MetaUserAffiliations;
  Callback.MetaUserHomePageCategory := Callback_MetaUserHomePageCategory;

  Callback.BeginWait := Callback_BeginWait;
  Callback.EndWait := Callback_EndWait;
  Callback.InvalidLogin := Callback_InvalidLogin;

  Callback.WriteUDPPacket := Callback_WriteUDPPacket;
  Callback.ReadUDPPacket := Callback_ReadUDPPacket;

  Callback.InvalidUIN := Callback_InvalidUIN;
  Callback.InvalidPassword := Callback_InvalidPassword;

  Callback.ExtUserInfo2 := Callback_ExtUserInfo2;
  Callback.MetaUserInfo2 := Callback_MetaUserInfo2;

  Callback.MetaEndFound := Callback_MetaEndFound;

  Callback.WriteOscarPacket := Callback_WriteOscarPacket;
  Callback.ReadOscarPacket := Callback_ReadOscarPacket;
end;
//=============================================================================
destructor TICQLib.Destroy;
begin
  KeepAliveTimer.Free;
  PollTimer.Free;
  ICQLib_ForEach(OnEachFree,nil);
  inherited Destroy;
end;
//=============================================================================
procedure TICQLib.CheckVersion;
var Ver: DWORD;
begin
  if not ICQ_CheckVersion(ICQ_Version_Major,ICQ_Version_Minor) then begin
    Ver := ICQLib_GetVersion;
    MessageBox(0,PChar(Format(
      'Invalid %s library version!!!'#13+
      'Need: v%d.%d but found v%d.%d'
      ,[ICQ_LibName,ICQ_Version_Major,ICQ_Version_Minor,
        PByteArray(@Ver)[2],PByteArray(@Ver)[1]])),
      'Critical error',MB_OK or MB_ICONERROR);
    Halt(3333);
  end;
  KeepAliveTimer.Enabled := True;
  PollTimer.Enabled := True;
end;
//=============================================================================
procedure TICQLib.OnKeepAliveTimer(Sender: TObject);
begin
  ICQLib_ForEach(OnEachKeepAlive,nil);
end;
procedure TICQLib.OnPollTimer(Sender: TObject);
begin
  ICQ_Poll;
end;
//=============================================================================
function TICQLib.OnEachKeepAlive(Sender: TObject; P: Pointer): Boolean;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(Sender);
  Socket.Send_KeepAlive;
  Result := True;
end;
function TICQLib.OnEachFree(Sender: TObject; P: Pointer): Boolean;
var Socket: TICQSocket;
begin
  Socket := TICQSocket(Sender);
  Socket.Free;
  Result := True;
end;
//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================
//=============================================================================

initialization

  FailExceptCount := 0;
  ICQLib := TICQLib.Create;
  ICQLib.CheckVersion;

finalization

  ICQLib.Free;

end.
