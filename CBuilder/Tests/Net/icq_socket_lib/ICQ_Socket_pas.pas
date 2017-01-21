(*=============================================================
 *
 *  Copyright (C) 1999-2002 Soft Variant Company.
 *  All Rights Reserved.
 *
 *  ICQ_Socket_pas header for ICQ_Socket.dll version 2.3
 *
 *  Author: Evgeny Golovin.
 *  E-Mail: softvariant@chat.ru
 *  Homepage: http://softvariant.boom.ru/icq_socket/index.htm
 *
 **************************************************************)
unit ICQ_Socket_pas;
// оригинал: icq_socket.h - смотрите описание функций

// ====================================================
// Библиотека ICQ_Socket поможет Вам интегрировать в
// программы возможности общения друг с другом, используя
// все прелести протокола ICQ.
// ====================================================
// Способ распространения - shareware.
// Незарегистрированная версия библиотеки работает
// неограниченное время, но некоторые функции заблокированы.
// Чтобы открыть все функции библиотеки, Вам нужно купить
// регистрационный ключ. Для этого посетите сайт:
// ====================================================
// http://softvariant.narod.ru/icq_socket/index.htm
// ====================================================
// По всем вопросам обращайтесь на softvariant@narod.ru
// Ваше мнение очень важно для улучшения данной библиотеки.
// ====================================================
// Все функции можно вызывать из разных покотов
// при возникновении одновременного доступа, второй
// поток будет ждать, пока первый не завершит операцию
// ====================================================

interface

Uses ICQ_Type_pas, Windows;

const ICQ_LibName = 'ICQ_Socket.dll';
type
  ICQ_ForEach_Function = function (S: ICQ_Socket; P: Pointer): LongBool; cdecl;

function ICQ_GetLibVersion: DWORD; cdecl;
function ICQ_GetLicense: DWORD; cdecl;
function ICQ_GetPacketVersion(Index: DWORD): Longint; cdecl;
function ICQ_GetMaxSocketCount: DWORD; cdecl;
function ICQ_GetSocketCount: DWORD; cdecl;
function ICQ_CheckVersion(Major,Minor: DWORD): LongBool; cdecl;

function ICQ_ForEach(F: ICQ_ForEach_Function; P: Pointer): Integer; cdecl;

// create
function ICQ_NewSocket: ICQ_Socket; cdecl;
procedure ICQ_DeleteSocket(S: ICQ_Socket); cdecl;

// callback
procedure ICQ_SetStdCallback(Callback: PICQ_Callback); cdecl;
function ICQ_GetStdCallback: PICQ_Callback; cdecl;

procedure ICQ_SetCallback(S: ICQ_Socket; Callback: PICQ_Callback); cdecl;
function ICQ_GetCallback(S: ICQ_Socket): PICQ_Callback; cdecl;

// property
procedure ICQ_SetProtocolVersion(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetProtocolVersion(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetActive(S: ICQ_Socket; Value: LongBool); cdecl;
function ICQ_GetActive(S: ICQ_Socket): LongBool; cdecl;

function ICQ_GetConnecting(S: ICQ_Socket): LongBool; cdecl;

procedure ICQ_SetWaitConnect(S: ICQ_Socket; Value: LongBool); cdecl;
function ICQ_GetWaitConnect(S: ICQ_Socket): LongBool; cdecl;

procedure ICQ_SetAutoConnect(S: ICQ_Socket; Value: LongBool); cdecl;
function ICQ_GetAutoConnect(S: ICQ_Socket): LongBool; cdecl;

procedure ICQ_SetHost(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetHost(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetHostPort(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetHostPort(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetUIN(S: ICQ_Socket; Value: DWORD); cdecl;
function ICQ_GetUIN(S: ICQ_Socket): DWORD; cdecl;

procedure ICQ_SetNick(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetNick(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetPass(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetPass(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetMaxPassLen(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetMaxPassLen(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetProxyUsed(S: ICQ_Socket; Value: LongBool); cdecl;
function ICQ_GetProxyUsed(S: ICQ_Socket): LongBool; cdecl;

procedure ICQ_SetProxyHost(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetProxyHost(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetProxyPort(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetProxyPort(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetProxyLoginUsed(S: ICQ_Socket; Value: LongBool); cdecl;
function ICQ_GetProxyLoginUsed(S: ICQ_Socket): LongBool; cdecl;

procedure ICQ_SetProxyUser(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetProxyUser(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetProxyPass(S: ICQ_Socket; Value: PChar); cdecl;
function ICQ_GetProxyPass(S: ICQ_Socket): PChar; cdecl;

procedure ICQ_SetStatus(S: ICQ_Socket; Status: ICQ_Status); cdecl;
function ICQ_GetStatus(S: ICQ_Socket): ICQ_Status; cdecl;

procedure ICQ_SetLogLevel(S: ICQ_Socket; Value: ICQ_Log); cdecl;
function ICQ_GetLogLevel(S: ICQ_Socket): ICQ_Log; cdecl;

procedure ICQ_SetTimeout(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetTimeout(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetMaxAttempts(S: ICQ_Socket; Value: Longint); cdecl;
function ICQ_GetMaxAttempts(S: ICQ_Socket): Longint; cdecl;

procedure ICQ_SetUserPointer(S: ICQ_Socket; Value: Pointer); cdecl;
function ICQ_GetUserPointer(S: ICQ_Socket): Pointer; cdecl;

procedure ICQ_SetWaitPointer(S: ICQ_Socket; Value: Pointer); cdecl;
function ICQ_GetWaitPointer(S: ICQ_Socket): Pointer; cdecl;

function ICQ_GetWait(S: ICQ_Socket): LongBool; cdecl;
function ICQ_GetWaitTimeout(S: ICQ_Socket): Longint; cdecl;

function ICQ_GetDisconnectReason(S: ICQ_Socket): Longint; cdecl;
procedure ICQ_ClearDisconnectReason(S: ICQ_Socket); cdecl;

function ICQ_GetRedirectCount(S: ICQ_Socket): Longint; cdecl;
function ICQ_GetRedirectHost(S: ICQ_Socket): PChar; cdecl;
function ICQ_GetRedirectPort(S: ICQ_Socket): Longint; cdecl;

function ICQ_GetConnectHost(S: ICQ_Socket): PChar; cdecl;
function ICQ_GetConnectPort(S: ICQ_Socket): Longint; cdecl;

function ICQ_GetLastSendUDPSequence(S: ICQ_Socket): DWORD; cdecl;

function ICQ_GetContactCount(S: ICQ_Socket): DWORD; cdecl;
function ICQ_GetUINContactIndex(S: ICQ_Socket; UIN: DWORD): Longint; cdecl;
function ICQ_GetIndexContact(S: ICQ_Socket; Index: DWORD): PICQ_Contact; cdecl;
function ICQ_GetUINContact(S: ICQ_Socket; UIN: DWORD): PICQ_Contact; cdecl;
procedure ICQ_SetContact(S: ICQ_Socket; UIN: DWORD; Visible: LongBool); cdecl;
procedure ICQ_SetContact2(S: ICQ_Socket; UIN: DWORD; Visible,Invisible: LongBool); cdecl;
procedure ICQ_DeleteIndexContact(S: ICQ_Socket; Index: DWORD); cdecl;
procedure ICQ_DeleteUINContact(S: ICQ_Socket; UIN: DWORD); cdecl;
procedure ICQ_RemoveIndexContact(S: ICQ_Socket; Index: DWORD); cdecl;
procedure ICQ_RemoveUINContact(S: ICQ_Socket; UIN: DWORD); cdecl;
procedure ICQ_ClearContactList(S: ICQ_Socket); cdecl;

// connect
function ICQ_Connect(S: ICQ_Socket;
  Host: PChar; Port: Longint; Status: ICQ_Status;
  UIN: DWORD; Nick,Pass: PChar): Longint; cdecl;
procedure ICQ_Disconnect(S: ICQ_Socket); cdecl;

// net
procedure ICQ_Poll; cdecl;
procedure ICQ_PollSocket(S: ICQ_Socket); cdecl;

function ICQ_Send_GetInfo(S: ICQ_Socket; UIN: DWORD): Longint; cdecl;
function ICQ_Send_GetExtInfo(S: ICQ_Socket; UIN: DWORD): Longint; cdecl;
function ICQ_Send_GetMetaInfo(S: ICQ_Socket; UIN: DWORD): Longint; cdecl;

function ICQ_Send_Message(S: ICQ_Socket; UIN: DWORD; Text: PChar; Send: ICQ_Send): Longint; cdecl;
function ICQ_Send_Url(S: ICQ_Socket; UIN: DWORD; Url,Desc: PChar; Send: ICQ_Send): Longint; cdecl;

function ICQ_Send_Search(S: ICQ_Socket; UIN: DWORD;
     Email,Nick,FirstName,LastName: PChar): Longint; cdecl;

function ICQ_Send_FullSearch(S: ICQ_Socket;
     Email,Nick,FirstName,LastName: PChar;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; City,State: PChar; Country: DWORD;
     Company,Department,Job: PChar;
     Occupation: DWORD;
     Background: DWORD; BackgroundDesc: PChar;
     Affiliation: DWORD; AffiliationDesc: PChar;
     Homepage: DWORD; HomepageDesc: PChar;
     Online: LongBool): Longint; cdecl;

function ICQ_Send_FullSearch2(S: ICQ_Socket;
     Email,Nick,FirstName,LastName: PChar;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; City,State: PChar; Country: DWORD;
     Company,Department,Job: PChar;
     Occupation: DWORD;
     Background: DWORD; BackgroundDesc: PChar;
     Interests: DWORD; InterestsDesc: PChar;
     Affiliation: DWORD; AffiliationDesc: PChar;
     Homepage: DWORD; HomepageDesc: PChar;
     Online: LongBool): Longint; cdecl;

function ICQ_Send_KeepAlive(S: ICQ_Socket): Longint; cdecl;

function ICQ_Send_ContactList(S: ICQ_Socket): Longint; cdecl;
function ICQ_Send_VisibleList(S: ICQ_Socket): Longint; cdecl;
function ICQ_Send_InvisibleList(S: ICQ_Socket): Longint; cdecl;

function ICQ_Send_Authorize(S: ICQ_Socket; UIN: DWORD): Longint; cdecl;

function ICQ_Send_AllowRequest(S: ICQ_Socket): Longint; cdecl;
function ICQ_Send_DeniedRequest(S: ICQ_Socket): Longint; cdecl;

function ICQ_Send_SetAuth(S: ICQ_Socket; Auth: ICQ_Auth): Longint; cdecl;

function ICQ_Send_SetUserInfo(S: ICQ_Socket; Nick,First,Last,Email: PChar): Longint; cdecl;

function ICQ_Send_SetMetaInfo2(S: ICQ_Socket;
  Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: PChar;
  Zip,CountryCode: DWORD; TimeOffset: Single; HideEmail: LongBool): Longint; cdecl;
function ICQ_Send_SetMetaInfo(S: ICQ_Socket;
  Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: PChar;
  Zip,CountryCode,CountryStat: DWORD; HideEmail: LongBool): Longint; cdecl;

function ICQ_Send_SetMetaInfoHome(S: ICQ_Socket;
  Age: DWORD; HomePage: PChar;
  BYear,BMonth,BDay: DWORD;
  Lang1,Lang2,Lang3: DWORD): Longint; cdecl;
function ICQ_Send_SetMetaInfoMore(S: ICQ_Socket;
  Age: DWORD; Gender: ICQ_Gender; HomePage: PChar;
  BYear,BMonth,BDay: DWORD;
  Lang1,Lang2,Lang3: DWORD): Longint; cdecl;

function ICQ_Send_SetMetaInfoAbout(S: ICQ_Socket; About: PChar): Longint; cdecl;
function ICQ_Send_SetMetaInfoSecurity(S: ICQ_Socket; Auth: ICQ_Auth; Web,HideIp: LongBool): Longint; cdecl;

//misc
function ICQ_Wait(S: ICQ_Socket): Longint; cdecl;
function ICQ_WaitTimeout(S: ICQ_Socket; Timeout: DWORD): Longint; cdecl;

function ICQ_GetCountry(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetCountryRange(var Min,Max: DWORD): LongBool; cdecl;

function ICQ_GetOccupation(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetOccupationRange(var Min,Max: DWORD): LongBool; cdecl;

function ICQ_GetBackground(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetBackgroundRange(var Min,Max: DWORD): LongBool; cdecl;

function ICQ_GetAffiliation(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetAffiliationRange(var Min,Max: DWORD): LongBool; cdecl;

function ICQ_GetLanguage(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetLanguageRange(var Min,Max: DWORD): LongBool; cdecl;

function ICQ_GetInterest(Key: DWORD; Lang: DWORD = 12): PChar; cdecl;
function ICQ_GetInterestRange(var Min,Max: DWORD): LongBool; cdecl;

implementation

function ICQ_GetLibVersion: DWORD; external ICQ_LibName;
function ICQ_GetLicense: DWORD; external ICQ_LibName;
function ICQ_GetPacketVersion(Index: DWORD): Longint; external ICQ_LibName;
function ICQ_GetMaxSocketCount: DWORD; external ICQ_LibName;
function ICQ_GetSocketCount: DWORD; external ICQ_LibName;
function ICQ_CheckVersion(Major,Minor: DWORD): LongBool; external ICQ_LibName;

function ICQ_ForEach(F: ICQ_ForEach_Function; P: Pointer): Integer; external ICQ_LibName;

// create
function ICQ_NewSocket: ICQ_Socket; external ICQ_LibName;
procedure ICQ_DeleteSocket(S: ICQ_Socket); external ICQ_LibName;

// callback
procedure ICQ_SetStdCallback(Callback: PICQ_Callback); external ICQ_LibName;
function ICQ_GetStdCallback: PICQ_Callback; external ICQ_LibName;

procedure ICQ_SetCallback(S: ICQ_Socket; Callback: PICQ_Callback); external ICQ_LibName;
function ICQ_GetCallback(S: ICQ_Socket): PICQ_Callback; external ICQ_LibName;

// property
procedure ICQ_SetProtocolVersion(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetProtocolVersion(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetActive(S: ICQ_Socket; Value: LongBool); external ICQ_LibName;
function ICQ_GetActive(S: ICQ_Socket): LongBool; external ICQ_LibName;

procedure ICQ_SetWaitConnect(S: ICQ_Socket; Value: LongBool); external ICQ_LibName;
function ICQ_GetWaitConnect(S: ICQ_Socket): LongBool; external ICQ_LibName;

procedure ICQ_SetAutoConnect(S: ICQ_Socket; Value: LongBool); external ICQ_LibName;
function ICQ_GetAutoConnect(S: ICQ_Socket): LongBool; external ICQ_LibName;

procedure ICQ_SetHost(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetHost(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetHostPort(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetHostPort(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetUIN(S: ICQ_Socket; Value: DWORD); external ICQ_LibName;
function ICQ_GetUIN(S: ICQ_Socket): DWORD; external ICQ_LibName;

procedure ICQ_SetNick(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetNick(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetPass(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetPass(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetMaxPassLen(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetMaxPassLen(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetProxyUsed(S: ICQ_Socket; Value: LongBool); external ICQ_LibName;
function ICQ_GetProxyUsed(S: ICQ_Socket): LongBool; external ICQ_LibName;

procedure ICQ_SetProxyHost(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetProxyHost(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetProxyPort(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetProxyPort(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetProxyLoginUsed(S: ICQ_Socket; Value: LongBool); external ICQ_LibName;
function ICQ_GetProxyLoginUsed(S: ICQ_Socket): LongBool; external ICQ_LibName;

procedure ICQ_SetProxyUser(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetProxyUser(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetProxyPass(S: ICQ_Socket; Value: PChar); external ICQ_LibName;
function ICQ_GetProxyPass(S: ICQ_Socket): PChar; external ICQ_LibName;

procedure ICQ_SetStatus(S: ICQ_Socket; Status: ICQ_Status); external ICQ_LibName;
function ICQ_GetStatus(S: ICQ_Socket): ICQ_Status; external ICQ_LibName;

procedure ICQ_SetAuth(S: ICQ_Socket; Auth: ICQ_Auth); external ICQ_LibName;

procedure ICQ_SetLogLevel(S: ICQ_Socket; Value: ICQ_Log); external ICQ_LibName;
function ICQ_GetLogLevel(S: ICQ_Socket): ICQ_Log; external ICQ_LibName;

procedure ICQ_SetTimeout(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetTimeout(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetMaxAttempts(S: ICQ_Socket; Value: Longint); external ICQ_LibName;
function ICQ_GetMaxAttempts(S: ICQ_Socket): Longint; external ICQ_LibName;

procedure ICQ_SetUserPointer(S: ICQ_Socket; Value: Pointer); external ICQ_LibName;
function ICQ_GetUserPointer(S: ICQ_Socket): Pointer; external ICQ_LibName;

procedure ICQ_SetWaitPointer(S: ICQ_Socket; Value: Pointer); external ICQ_LibName;
function ICQ_GetWaitPointer(S: ICQ_Socket): Pointer; external ICQ_LibName;

function ICQ_GetWait(S: ICQ_Socket): LongBool; external ICQ_LibName;

function ICQ_GetWaitTimeout(S: ICQ_Socket): Integer; external ICQ_LibName;
function ICQ_GetConnecting(S: ICQ_Socket): LongBool; external ICQ_LibName;

function ICQ_GetDisconnectReason(S: ICQ_Socket): Integer; external ICQ_LibName;
procedure ICQ_ClearDisconnectReason(S: ICQ_Socket); external ICQ_LibName;

function ICQ_GetRedirectCount(S: ICQ_Socket): Longint; external ICQ_LibName;
function ICQ_GetRedirectHost(S: ICQ_Socket): PChar; external ICQ_LibName;
function ICQ_GetRedirectPort(S: ICQ_Socket): Longint; external ICQ_LibName;

function ICQ_GetConnectHost(S: ICQ_Socket): PChar; external ICQ_LibName;
function ICQ_GetConnectPort(S: ICQ_Socket): Longint; external ICQ_LibName;

function ICQ_GetLastSendUDPSequence(S: ICQ_Socket): DWORD; external ICQ_LibName;

function ICQ_GetContactCount(S: ICQ_Socket): DWORD; external ICQ_LibName;
function ICQ_GetUINContactIndex(S: ICQ_Socket; UIN: DWORD): Longint; external ICQ_LibName;
function ICQ_GetIndexContact(S: ICQ_Socket; Index: DWORD): PICQ_Contact; external ICQ_LibName;
function ICQ_GetUINContact(S: ICQ_Socket; UIN: DWORD): PICQ_Contact; external ICQ_LibName;
procedure ICQ_SetContact(S: ICQ_Socket; UIN: DWORD; Visible: LongBool); external ICQ_LibName;
procedure ICQ_SetContact2(S: ICQ_Socket; UIN: DWORD; Visible,Invisible: LongBool); external ICQ_LibName;
procedure ICQ_DeleteIndexContact(S: ICQ_Socket; Index: DWORD); external ICQ_LibName;
procedure ICQ_DeleteUINContact(S: ICQ_Socket; UIN: DWORD); external ICQ_LibName;
procedure ICQ_RemoveIndexContact(S: ICQ_Socket; Index: DWORD); external ICQ_LibName;
procedure ICQ_RemoveUINContact(S: ICQ_Socket; UIN: DWORD); external ICQ_LibName;
procedure ICQ_ClearContactList(S: ICQ_Socket); external ICQ_LibName;

// connect
function ICQ_Connect(S: ICQ_Socket;
  Host: PChar; Port: Longint; Status: ICQ_Status;
  UIN: DWORD; Nick,Pass: PChar): Longint; external ICQ_LibName;
procedure ICQ_Disconnect(S: ICQ_Socket); external ICQ_LibName;

// net
procedure ICQ_Poll; external ICQ_LibName;
procedure ICQ_PollSocket(S: ICQ_Socket); external ICQ_LibName;

function ICQ_Send_GetInfo(S: ICQ_Socket; UIN: DWORD): Longint; external ICQ_LibName;
function ICQ_Send_GetExtInfo(S: ICQ_Socket; UIN: DWORD): Longint; external ICQ_LibName;
function ICQ_Send_GetMetaInfo(S: ICQ_Socket; UIN: DWORD): Longint; external ICQ_LibName;

function ICQ_Send_Message(S: ICQ_Socket; UIN: DWORD; Text: PChar; Send: ICQ_Send): Longint; external ICQ_LibName;
function ICQ_Send_Url(S: ICQ_Socket; UIN: DWORD; Url,Desc: PChar; Send: ICQ_Send): Longint; external ICQ_LibName;

function ICQ_Send_Search(S: ICQ_Socket; UIN: DWORD;
     Email,Nick,FirstName,LastName: PChar): Longint; external ICQ_LibName;

function ICQ_Send_FullSearch(S: ICQ_Socket;
     Email,Nick,FirstName,LastName: PChar;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; City,State: PChar; Country: DWORD;
     Company,Department,Job: PChar;
     Occupation: DWORD;
     Background: DWORD; BackgroundDesc: PChar;
     Affiliation: DWORD; AffiliationDesc: PChar;
     Homepage: DWORD; HomepageDesc: PChar;
     Online: LongBool): Longint; external ICQ_LibName;

function ICQ_Send_FullSearch2(S: ICQ_Socket;
     Email,Nick,FirstName,LastName: PChar;
     MinAge,MaxAge: DWORD; Gender: ICQ_Gender;
     Lang: DWORD; City,State: PChar; Country: DWORD;
     Company,Department,Job: PChar;
     Occupation: DWORD;
     Background: DWORD; BackgroundDesc: PChar;
     Interests: DWORD; InterestsDesc: PChar;
     Affiliation: DWORD; AffiliationDesc: PChar;
     Homepage: DWORD; HomepageDesc: PChar;
     Online: LongBool): Longint; external ICQ_LibName;

function ICQ_Send_KeepAlive(S: ICQ_Socket): Longint; external ICQ_LibName;

function ICQ_Send_ContactList(S: ICQ_Socket): Longint; external ICQ_LibName;
function ICQ_Send_VisibleList(S: ICQ_Socket): Longint; external ICQ_LibName;
function ICQ_Send_InvisibleList(S: ICQ_Socket): Longint; external ICQ_LibName;

function ICQ_Send_Authorize(S: ICQ_Socket; UIN: DWORD): Longint; external ICQ_LibName;

function ICQ_Send_AllowRequest(S: ICQ_Socket): Longint; external ICQ_LibName;
function ICQ_Send_DeniedRequest(S: ICQ_Socket): Longint; external ICQ_LibName;

function ICQ_Send_SetAuth(S: ICQ_Socket; Auth: ICQ_Auth): Longint; external ICQ_LibName;

function ICQ_Send_SetUserInfo(S: ICQ_Socket; Nick,First,Last,Email: PChar): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfo2(S: ICQ_Socket;
  Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: PChar;
  Zip,CountryCode: DWORD; TimeOffset: Single; HideEmail: LongBool): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfo(S: ICQ_Socket;
  Nick,First,Last,
  Email,Email2,Email3,
  City,State,Phone,
  Fax,Street,Cellular: PChar;
  Zip,CountryCode,CountryStat: DWORD; HideEmail: LongBool): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfoMore(S: ICQ_Socket;
  Age: DWORD; Gender: ICQ_Gender; HomePage: PChar;
  BYear,BMonth,BDay: DWORD;
  Lang1,Lang2,Lang3: DWORD): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfoHome(S: ICQ_Socket;
  Age: DWORD; HomePage: PChar;
  BYear,BMonth,BDay: DWORD;
  Lang1,Lang2,Lang3: DWORD): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfoAbout(S: ICQ_Socket; About: PChar): Longint; external ICQ_LibName;
function ICQ_Send_SetMetaInfoSecurity(S: ICQ_Socket; Auth: ICQ_Auth; Web,HideIp: LongBool): Longint; external ICQ_LibName;

//misc
function ICQ_Wait(S: ICQ_Socket): Longint; external ICQ_LibName;
function ICQ_WaitTimeout(S: ICQ_Socket; Timeout: DWORD): Longint; external ICQ_LibName;

function ICQ_GetCountry(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetCountryRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

function ICQ_GetOccupation(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetOccupationRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

function ICQ_GetBackground(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetBackgroundRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

function ICQ_GetAffiliation(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetAffiliationRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

function ICQ_GetLanguage(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetLanguageRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

function ICQ_GetInterest(Key: DWORD; Lang: DWORD): PChar; external ICQ_LibName;
function ICQ_GetInterestRange(var Min,Max: DWORD): LongBool; external ICQ_LibName;

end.
