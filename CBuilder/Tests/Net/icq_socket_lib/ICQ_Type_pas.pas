(*=============================================================
 *
 *  Copyright (C) 1999-2002 Soft Variant Company.
 *  All Rights Reserved.
 *
 *  ICQ_Type_pas header for ICQ_Socket.dll version 2.3
 *
 *  Author: Evgeny Golovin.
 *  E-Mail: softvariant@chat.ru
 *  Homepage: http://softvariant.boom.ru/icq_socket/index.htm
 *
 **************************************************************)
unit ICQ_Type_pas;
// оригинал: icq_type.h

interface

Uses Windows;

type
  ICQ_Socket = Pointer;

const
  ICQ_Invalid_Socket: ICQ_Socket = ICQ_Socket(-1);

  ICQ_KeyNotFound = '';
  ICQ_KeyNotEntered = '? ? ? ?';

  ICQ_Result_OK           = 0;
  ICQ_Result_Error        = -1;
  ICQ_Result_Void         = -2;

  ICQ_Protocol_Udp = 5;
  ICQ_Protocol_Udp5 = 5;
  ICQ_Protocol_Oscar = 8;
  ICQ_Protocol_Oscar8 = 8;

  ICQ_ProxyType_Socks5 = 5;

  ICQ_DisconnectReason_NULL = 0;
  ICQ_DisconnectReason_LanError  = -100; // сетевая ошибка
  ICQ_DisconnectReason_Reconnect = -101; // подключение
  ICQ_DisconnectReason_NoHostFound = -102; // не найден Host
  ICQ_DisconnectReason_HostRefused = -103; // ошибка подключения к Host
  ICQ_DisconnectReason_ProxyNoHostFound = -104; // не найден ProxyHost
  ICQ_DisconnectReason_ProxyRefused = -105; // ошибка подключения к ProxyHost
  ICQ_DisconnectReason_ProxyLoginError  = -106; // ошибка авторизации на прокси
  ICQ_DisconnectReason_ProxyError = -107; // ошибка подключения к прокси
  ICQ_DisconnectReason_ServerGoAway = -108; // ICQ сервер нас отключил
  ICQ_DisconnectReason_User = -109; // вызов ICQ_Disconnect или изменение параметров соединения
  ICQ_DisconnectReason_Timeout = -110; // отключение по таймауту
  ICQ_DisconnectReason_InvalidPassword = -111; // не верный пароль при подключении
  ICQ_DisconnectReason_InvalidUIN = -112; // не верный UIN при подключении
  ICQ_DisconnectReason_DeleteSocket = -113; // удаление сокета
  ICQ_DisconnectReason_LanDataError = -114; // ошибка данных
  ICQ_DisconnectReason_WinError = -115;
  ICQ_DisconnectReason_Redirect = -116; // необходимо перенаправление для подключения
  ICQ_DisconnectReason_ServerError = -117; // ICQ сервер нас отключил
  ICQ_DisconnectReason_DualLogin = -118; // попытка двойного пдключения

type
  ICQ_Status =
    ( ICQ_Status_Offline     ,
      ICQ_Status_Online      ,
      ICQ_Status_Away        ,
      ICQ_Status_DND         ,
      ICQ_Status_NA          ,
      ICQ_Status_Occupied    ,
      ICQ_Status_FreeChat    ,
      ICQ_Status_Invisible   );

  ICQ_Auth =
    ( ICQ_Auth_Authorize,
      ICQ_Auth_Trust     );

  ICQ_Gender =
    ( ICQ_Gender_Void,
      ICQ_Gender_Female,
      ICQ_Gender_Male );

  ICQ_Send =
    ( ICQ_Send_ThruServer,
      ICQ_Send_Direct    ,
      ICQ_Send_BestWay   );

  ICQ_Log =
    ( ICQ_Log_Off     ,
      ICQ_Log_Fatal   ,
      ICQ_Log_Error   ,
      ICQ_Log_Warning ,
      ICQ_Log_Message );

  PICQ_Contact = ^ICQ_Contact;
  ICQ_Contact = record
    UIN: DWORD;
    Visible: LongBool;
    IP,Port,RealIP,TcpFlag: DWORD;
    Status: ICQ_Status;
    
    Version: DWORD;
    Invisible, AllowDirect, Birthday, WebPresence: BOOL;
    UserClass, WarningLevel: DWORD;
  end;

  ICQ_Callback_Connecting = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_Connected = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_Disconnecting = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_Disconnected = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_InvalidLogin = procedure(S: ICQ_Socket); cdecl;

  ICQ_Callback_InvalidPassword = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_InvalidUIN = procedure(S: ICQ_Socket); cdecl;

  // contact...
  ICQ_Callback_ContactOnline = procedure(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;
  ICQ_Callback_ContactOffline = procedure(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;
  ICQ_Callback_ContactStatusUpdate = procedure(S: ICQ_Socket; Contact: PICQ_Contact); cdecl;

  ICQ_Callback_UserFound = procedure(S: ICQ_Socket; UIN: DWORD;
    Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;
  ICQ_Callback_EndFound = procedure(S: ICQ_Socket); cdecl;

  ICQ_Callback_NewUIN = procedure(S: ICQ_Socket; UIN: DWORD); cdecl;

  // Process...
  ICQ_Callback_ProcessMessage = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD; Msg: PChar); cdecl;

  ICQ_Callback_ProcessUrl = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD;
    Url,Desc: PChar); cdecl;

  ICQ_Callback_ProcessWebPager = procedure(S: ICQ_Socket;
    Year,Month,Day,Hour,Minute: DWORD;
    Nick,Email,Msg: PChar); cdecl;

  ICQ_Callback_ProcessAdded = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD;
    Nick,First,Last,Email: PChar); cdecl;

  ICQ_Callback_ProcessMailExpress = procedure(S: ICQ_Socket;
    Year,Month,Day,Hour,Minute: DWORD;
    Nick,Email,Msg: PChar); cdecl;

  // request
  ICQ_Callback_ProcessChatRequest = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD; Desc: PChar); cdecl;

  ICQ_Callback_ProcessFileRequest = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD;
    Desc,FileName: PChar; FileSize: DWORD); cdecl;

  ICQ_Callback_ProcessAuthRequest = procedure(S: ICQ_Socket;
    UIN,Year,Month,Day,Hour,Minute: DWORD;
    Nick,First,Last,Email,Reson: PChar); cdecl;

  // info ...
  ICQ_Callback_UserNotFound = procedure(S: ICQ_Socket; UIN: DWORD); cdecl;

  ICQ_Callback_UserInfo = procedure(S: ICQ_Socket; UIN: DWORD;
    Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;

  ICQ_Callback_ExtUserInfo = procedure(S: ICQ_Socket; UIN: DWORD;
    City: PChar; CountryCode,CountryStat: DWORD;
    State: PChar; Age: DWORD; Gender: ICQ_Gender;
    Phone,HomePage,About: PChar); cdecl;

  ICQ_Callback_ExtUserInfo2 = procedure(S: ICQ_Socket; UIN: DWORD;
    City: PChar; CountryCode: DWORD; TimeOffset: Single;
    State: PChar; Age: DWORD; Gender: ICQ_Gender;
    Phone,HomePage,About: PChar); cdecl;

  // Ack
  ICQ_Callback_SrvUDPAck = procedure(S: ICQ_Socket; Sequence: DWORD); cdecl;
  ICQ_Callback_SrvTCPAck = procedure(S: ICQ_Socket; ID: DWORD); cdecl;

  // Misc
  ICQ_Callback_Log = procedure(S: ICQ_Socket; Level: ICQ_Log; Str: PChar); cdecl;

  ICQ_Callback_BeginWait = procedure(S: ICQ_Socket); cdecl;
  ICQ_Callback_Wait = function(S: ICQ_Socket; WaitPointer: Pointer; var WaitResult: Integer): LongBool; cdecl;
  ICQ_Callback_WaitConnect = procedure(S: ICQ_Socket; WaitTime: DWORD); cdecl;
  ICQ_Callback_Timeout = procedure(S: ICQ_Socket; CurAttempt,Sequence: DWORD); cdecl;
  ICQ_Callback_EndWait = procedure(S: ICQ_Socket); cdecl;


  // Meta user...
  ICQ_Callback_MetaUserFound = procedure(S: ICQ_Socket;
       UIN: DWORD; Nick,First,Last,Email: PChar; Auth: ICQ_Auth); cdecl;
  ICQ_Callback_MetaEndFound = procedure(S: ICQ_Socket); cdecl;

  ICQ_Callback_MetaUserInfo = procedure(S: ICQ_Socket;
       Nick,First,Last,
       PriEml,SecEml,OldEml,
       City,State,Phone,Fax,
       Street,Cellular: PChar;
       Zip,Country,TimeZone: DWORD; Auth: ICQ_Auth;
       Web,HideIp: LongBool); cdecl;

  ICQ_Callback_MetaUserInfo2 = procedure(S: ICQ_Socket;
       Nick,First,Last,
       PriEml,SecEml,OldEml,
       City,State,Phone,Fax,
       Street,Cellular: PChar;
       Zip,Country: DWORD; TimeOffset: Single; Auth: ICQ_Auth;
       Web,HideIp: LongBool); cdecl;

  ICQ_Callback_MetaUserWork = procedure(S: ICQ_Socket;
       City,State,Phone,
       Fax,Address: PChar;
       Zip,Country: DWORD; Company,Department,Job: PChar;
       Occupation: DWORD; HomePage: PChar); cdecl;

  ICQ_Callback_MetaUserMore = procedure(S: ICQ_Socket;
       Age: DWORD; Gender: ICQ_Gender; HomePage: PChar;
       BYear,BMonth,BDay,
       Lang1,Lang2,Lang3: DWORD); cdecl;

  ICQ_Callback_MetaUserAbout = procedure(S: ICQ_Socket; About: PChar); cdecl;

  ICQ_Callback_MetaUserInterests = procedure(S: ICQ_Socket;
       Num: DWORD;
       Cat1: DWORD; Int1: PChar;
       Cat2: DWORD; Int2: PChar;
       Cat3: DWORD; Int3: PChar;
       Cat4: DWORD; Int4: PChar); cdecl;

  ICQ_Callback_MetaUserAffiliations = procedure(S: ICQ_Socket;
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

  ICQ_Callback_MetaUserHomePageCategory = procedure(S: ICQ_Socket;
    Num,Cat: DWORD; Text: PChar); cdecl;

  ICQ_Callback_WriteUDPPacket = procedure(S: ICQ_Socket;
    Data,CryptData: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen,Sequence: DWORD); cdecl;
  ICQ_Callback_ReadUDPPacket = procedure(S: ICQ_Socket;
    Data: Pointer; Len: DWORD;
    ProxyHeader: Pointer; ProxyHeaderLen: DWORD); cdecl;

  ICQ_Callback_WriteOscarPacket = procedure(S: ICQ_Socket;
    Data: Pointer; Len: DWORD); cdecl;

  ICQ_Callback_ReadOscarPacket = procedure(S: ICQ_Socket;
    Data: Pointer; Len: DWORD); cdecl;

  PICQ_Callback = ^ICQ_Callback;
  ICQ_Callback = record
    dwSize: DWORD;

    Connecting: ICQ_Callback_Connecting;
    Connected: ICQ_Callback_Connected;
    Disconnecting: ICQ_Callback_Disconnecting;
    Disconnected: ICQ_Callback_Disconnected;
    InvalidLogin: ICQ_Callback_InvalidLogin;

    ContactOnline: ICQ_Callback_ContactOnline;
    ContactOffline: ICQ_Callback_ContactOffline;
    ContactStatusUpdate: ICQ_Callback_ContactStatusUpdate;

    UserFound: ICQ_Callback_UserFound;
    EndFound: ICQ_Callback_EndFound;
    NewUIN: ICQ_Callback_NewUIN;

    // Process...
    ProcessMessage: ICQ_Callback_ProcessMessage;
    ProcessUrl: ICQ_Callback_ProcessUrl;
    ProcessWebPager: ICQ_Callback_ProcessWebPager;
    ProcessAdded: ICQ_Callback_ProcessAdded;
    ProcessMailExpress: ICQ_Callback_ProcessMailExpress;

    // request
    ProcessChatRequest: ICQ_Callback_ProcessChatRequest;
    ProcessFileRequest: ICQ_Callback_ProcessFileRequest;
    ProcessAuthRequest: ICQ_Callback_ProcessAuthRequest;

    // info ...
    UserInfo: ICQ_Callback_UserInfo;
    ExtUserInfo: ICQ_Callback_ExtUserInfo;

    // Ack
    SrvUDPAck: ICQ_Callback_SrvUDPAck;
    SrvTCPAck: ICQ_Callback_SrvTCPAck;

    // Wait
    BeginWait: ICQ_Callback_BeginWait;
    Wait: ICQ_Callback_Wait;
    WaitConnect: ICQ_Callback_WaitConnect;
    EndWait: ICQ_Callback_EndWait;

    // Meta user...
    MetaUserFound: ICQ_Callback_MetaUserFound;
    MetaUserInfo: ICQ_Callback_MetaUserInfo;
    MetaUserWork: ICQ_Callback_MetaUserWork;
    MetaUserMore: ICQ_Callback_MetaUserMore;
    MetaUserAbout: ICQ_Callback_MetaUserAbout;
    MetaUserInterests: ICQ_Callback_MetaUserInterests;
    MetaUserAffiliations: ICQ_Callback_MetaUserAffiliations;
    MetaUserHomePageCategory: ICQ_Callback_MetaUserHomePageCategory;

    Timeout: ICQ_Callback_Timeout;
    Log: ICQ_Callback_Log;

    WriteUDPPacket: ICQ_Callback_WriteUDPPacket;
    ReadUDPPacket: ICQ_Callback_ReadUDPPacket;

    InvalidUIN: ICQ_Callback_InvalidUIN;
    InvalidPassword: ICQ_Callback_InvalidPassword;

    ExtUserInfo2: ICQ_Callback_ExtUserInfo2;
    MetaUserInfo2: ICQ_Callback_MetaUserInfo2;

    MetaEndFound: ICQ_Callback_MetaEndFound;

    WriteOscarPacket: ICQ_Callback_WriteOscarPacket;
    ReadOscarPacket: ICQ_Callback_ReadOscarPacket;

    UserNotFound: ICQ_Callback_UserNotFound;
  end;

  ICQ_Register = function (a,b,c,d,e: WORD): LongBool; cdecl;

implementation

end.

