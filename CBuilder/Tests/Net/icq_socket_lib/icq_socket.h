/*=============================================================
 *
 *  Copyright (C) 1999-2002 Soft Variant Company.
 *  All Rights Reserved.
 *
 *  Author: Evgeny Golovin.
 *  E-Mail: softvariant@chat.ru
 *  Homepage: http://softvariant.boom.ru/icq_socket/index.htm
 *
 **************************************************************/

#ifndef __ICQ_SOCKET_H__ 
#define __ICQ_SOCKET_H__ 

#include "icq_type.h"

// ====================================================
// ���������� ICQ_Socket ������� ��� ������������� �
// ��������� ����������� ������� ���� � ������, ��������� 
// ��� �������� ��������� ICQ.
// ====================================================
// ������ ��������������� - shareware. 
// �������������������� ������ ���������� �������� 
// �������������� �����, �� ��������� ������� �������������. 
// ����� ������� ��� ������� ����������, ��� ����� ������ 
// ��������������� ����. ��� ����� �������� ����:
// ====================================================
// http://softvariant.narod.ru/icq_socket/index.htm
// ====================================================
// �� ���� �������� ����������� �� softvariant@narod.ru
// ���� ������ ����� ����� ��� ��������� ������ ����������.
// ====================================================
// ��� ������� ����� �������� �� ������ �������
// ��� ������������� �������������� �������, ������
// ����� ����� �����, ���� ������ �� �������� ��������
// ====================================================

// �������� ����� ������ ����������, ����������� ��������� �������:
// (BYTE*)[3] = ICQ_VERSION_GENERAL - ��� ���� ����������� ������ ����������
// (BYTE*)[2] = ICQ_VERSION_MAJOR   - ������ ����������
// (BYTE*)[1] = ICQ_VERSION_MINOR   - �����������
// (BYTE*)[0] = ICQ_VERSION_SUB     - ���������, ����� � ��������
// ���� ��� 0 ����. - �� ������������������ ������
// ���� ��� 1 ����. - ���� ������
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLibVersion();

// �������� ����� ��������, 0 - ���������� �� ����������������
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLicense();

// ���������������� ����������. 
// ������ ������ ���� ������� �� ��������� ��� ������� (�����������).
// ���� ���������� true � ��������������� ����� �����,
// �� �������� ������� ���������� ����������. 
// ���� ����������� �� ����������� ����� �� ����� �������
// ���������, ��� ������ �� ��������� ���� ����������� �����. 
//BOOL __cdecl ICQ_Register(WORD,WORD,WORD,WORD);

// Index ������� � 0, �������������� ������ ��������� ICQ
// ����� ������: -1
ICQ_SOCKET_API long __cdecl ICQ_GetPacketVersion(DWORD Index);

// ������������ ���������� ICQ �������, ������� �� ������ 
// ������� �������� ICQ_NewSocket
ICQ_SOCKET_API DWORD __cdecl ICQ_GetMaxSocketCount();

// ������� ���������� �������, ��������� �������� ICQ_NewSocket
ICQ_SOCKET_API DWORD __cdecl ICQ_GetSocketCount();

// �������� ������������� ������, ������������ � �������, 
// � ������� ������� ����������. ���� 0, �� ������ ���������� ��
// ���������� � ������� Major,Minor
ICQ_SOCKET_API BOOL __cdecl ICQ_CheckVersion(DWORD Major,DWORD Minor);

// ��� ���� ������� �������� �������, ���� ��� ���������� True,
// ��������� �� �������� void * P
ICQ_SOCKET_API DWORD __cdecl ICQ_ForEach(BOOL (__cdecl*F)(ICQ_Socket,void*),void * P);

// -------------------------------------------------------------

// ������� �����. ����� ����� �� ������ ������������ ��� �� ����
// ��������� ��������, ��� ����� ��� ICQ_Socket. ���� ������ ������� 
// ���������� ICQ_Invalid_Socket, �� ��������� ������. �� ��������
// ������� ����� ����� ���������� ��� ������������� �������� ICQ_DeleteSocket
ICQ_SOCKET_API ICQ_Socket __cdecl ICQ_NewSocket(); 

// ������� �����. ����� ����� �� �� ������ ������������ ���.
ICQ_SOCKET_API void __cdecl ICQ_DeleteSocket(ICQ_Socket); 

// -------------------------------------------------------------
// � � � � � � � �

// ���� � �������� ������� ������� ����� "online",
// �� ��� ��������, ��� ��������� ���������� �� ��������
// �� ����, ���������� �� � ������ ������ ��� ���,
// � �������� ������, ���������� ���������� �� �������!

// ��� ������������� ���� �������, ���������� �������, 
// ������������ �������������, ��. ICQ_Callback

// ���������� ������� ������������ ��� ���� ������� (online)
ICQ_SOCKET_API void __cdecl ICQ_SetStdCallback(ICQ_Callback * Callback);
ICQ_SOCKET_API ICQ_Callback * __cdecl ICQ_GetStdCallback();

// ���������� ������� ������������ ��� ����������� ������ (online)
ICQ_SOCKET_API void __cdecl ICQ_SetCallback(ICQ_Socket,ICQ_Callback*);
ICQ_SOCKET_API ICQ_Callback * __cdecl ICQ_GetCallback(ICQ_Socket);

// -------------------------------------------------------------
// ���������� ������ ��������� ICQ. �� ������ �������� ������ ��������������
// ���������� �������� ICQ_GetPacketVersion
ICQ_SOCKET_API void __cdecl ICQ_SetProtocolVersion(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetProtocolVersion(ICQ_Socket);

// ������������ (�����������) � �������, ���� WaitConnect == true, �� ������� ����������
ICQ_SOCKET_API void __cdecl ICQ_SetActive(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetActive(ICQ_Socket);

// ���� true, �� ����� ��������� � �������� �����������
ICQ_SOCKET_API BOOL __cdecl ICQ_GetConnecting(ICQ_Socket);

// ���� true, �� ������� ���������� ����� ������� ����������� (online)
ICQ_SOCKET_API void __cdecl ICQ_SetWaitConnect(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetWaitConnect(ICQ_Socket);

// ���� true, �� ��� ������������� ����� �����������
// �������������� ����������� � ������� (online)
ICQ_SOCKET_API void __cdecl ICQ_SetAutoConnect(ICQ_Socket,BOOL);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetAutoConnect(ICQ_Socket);

// ���������� ������ ICQ. ����� ���� � IP ������ ���� "A.B.C.D"
// ����� ����� ������������� ������, �������� "login.icq.com:5190"
ICQ_SOCKET_API void __cdecl ICQ_SetHost(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetHost(ICQ_Socket);

// ���������� ���� ������� ICQ
ICQ_SOCKET_API void __cdecl ICQ_SetHostPort(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetHostPort(ICQ_Socket);

// ���������� ��� ICQ �����
ICQ_SOCKET_API void __cdecl ICQ_SetUIN(ICQ_Socket,DWORD);
ICQ_SOCKET_API DWORD __cdecl ICQ_GetUIN(ICQ_Socket);

// ���������� ��� ���
ICQ_SOCKET_API void __cdecl ICQ_SetNick(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetNick(ICQ_Socket);

// ���������� ��� ������
ICQ_SOCKET_API void __cdecl ICQ_SetPass(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetPass(ICQ_Socket);

// ���������� ������������ ����� ������
ICQ_SOCKET_API void __cdecl ICQ_SetMaxPassLen(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetMaxPassLen(ICQ_Socket);

// ���������� ������������� ������ �������. ���� true, ��������������
ICQ_SOCKET_API void __cdecl ICQ_SetProxyUsed(ICQ_Socket S,BOOL Value);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetProxyUsed(ICQ_Socket S);

// ���������� ������ ������ (��. �������� ICQ_SetHost)
ICQ_SOCKET_API void __cdecl ICQ_SetProxyHost(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyHost(ICQ_Socket);

// ���������� ���� ������ �������
ICQ_SOCKET_API void __cdecl ICQ_SetProxyPort(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetProxyPort(ICQ_Socket);

// ���������� ������������� �������������� ������ �������
ICQ_SOCKET_API void __cdecl ICQ_SetProxyLoginUsed(ICQ_Socket S,BOOL Value);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetProxyLoginUsed(ICQ_Socket S);

// ���������� ������������ ������ ������� ��� ��������������
ICQ_SOCKET_API void __cdecl ICQ_SetProxyUser(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyUser(ICQ_Socket);

// ���������� ������ ������������ ������ ������� 
// ��� ��������������
ICQ_SOCKET_API void __cdecl ICQ_SetProxyPass(ICQ_Socket,const char*);
ICQ_SOCKET_API char * __cdecl ICQ_GetProxyPass(ICQ_Socket);

// ���������� ��������� (online)
ICQ_SOCKET_API void __cdecl ICQ_SetStatus(ICQ_Socket,ICQ_Status);
ICQ_SOCKET_API ICQ_Status __cdecl ICQ_GetStatus(ICQ_Socket);

// ���������� ������� ��������� ��� ������� (online)
ICQ_SOCKET_API void __cdecl ICQ_SetLogLevel(ICQ_Socket,ICQ_Log);
ICQ_SOCKET_API ICQ_Log __cdecl ICQ_GetLogLevel(ICQ_Socket);

// ===== ��� ������������� � �������� �������� ===== 
ICQ_SOCKET_API void __cdecl ICQ_SetTimeout(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetTimeout(ICQ_Socket);

// ===== ��� ������������� � �������� �������� ===== 
ICQ_SOCKET_API void __cdecl ICQ_SetMaxAttempts(ICQ_Socket,long);
ICQ_SOCKET_API long __cdecl ICQ_GetMaxAttempts(ICQ_Socket);

// ���������� ��������� ������������ (online)
// ������������ ��� ����� ICQ_Socket � ��. �������
ICQ_SOCKET_API void __cdecl ICQ_SetUserPointer(ICQ_Socket,void*);
ICQ_SOCKET_API void * __cdecl ICQ_GetUserPointer(ICQ_Socket);

// ���������� ��������� � ������� Wait (��. ICQ_Callback) (online)
ICQ_SOCKET_API void __cdecl ICQ_SetWaitPointer(ICQ_Socket,void*);
ICQ_SOCKET_API void * __cdecl ICQ_GetWaitPointer(ICQ_Socket);

// ������ ��������, ���� ��, �� ����� �������������� �
// ������� ICQ_Wait (online)
ICQ_SOCKET_API BOOL __cdecl ICQ_GetWait(ICQ_Socket);

// ����� ����� �������� � ������������
ICQ_SOCKET_API DWORD __cdecl ICQ_GetWaitTimeout(ICQ_Socket);

// �������� ������� ����������. �������� ������� ������������
// � �������� Disconnecting � Disconnected. ����������
// �������� ICQ_DisconnectReason_ ...
ICQ_SOCKET_API long __cdecl ICQ_GetDisconnectReason(ICQ_Socket S);

// �������� ������ ����������. ���� ����� ������������ � ��������
// Disconnecting � Disconnected ��� �������
// ICQ_DisconnectReason_InvalidUIN, ICQ_DisconnectReason_InvalidPassword
// ICQ_DisconnectReason_Redirect. ��������, ���� ��� ����������� � �������
// ��������� �������������, ����� ��������� ������ ��� ����������� �����������
ICQ_SOCKET_API void __cdecl ICQ_ClearDisconnectReason(ICQ_Socket S);

// ���������� �������������, �������� 1 - ���� ������������� (���
// ����������� ������������ �������� RedirectHost � RedirectPort),
// 0 - �� ���� ������������� � ����������� ���������� �� ���������
// Host � HostPort
ICQ_SOCKET_API long __cdecl ICQ_GetRedirectCount(ICQ_Socket S);

// ���� �������������
ICQ_SOCKET_API char * __cdecl ICQ_GetRedirectHost(ICQ_Socket S);
// ���� �������������
ICQ_SOCKET_API long __cdecl ICQ_GetRedirectPort(ICQ_Socket S);

// ���� ���� �������������, �� ���������� RedirectHost, ����� Host
ICQ_SOCKET_API char * __cdecl ICQ_GetConnectHost(ICQ_Socket S);
// ���� ���� �������������, �� ���������� RedirectPort, ����� HostPort
ICQ_SOCKET_API long __cdecl ICQ_GetConnectPort(ICQ_Socket S);

// ===== ��� ������������� � �������� �������� ===== 
ICQ_SOCKET_API DWORD __cdecl ICQ_GetLastSendUDPSequence(ICQ_Socket);

// -------------------------------------------------------------
// ������ ��� ������� ���������. ��� ������� �� �������� ������ �� ����

// ���������� ���������
ICQ_SOCKET_API DWORD __cdecl ICQ_GetContactCount(ICQ_Socket);

// �������� ������ �������� �� ICQ ������ (����� �������� ���������� � 0)
ICQ_SOCKET_API long __cdecl ICQ_GetUINContactIndex(ICQ_Socket,DWORD UIN);

// �������� ���������� � �������� �� ��� �������
ICQ_SOCKET_API ICQ_Contact * __cdecl ICQ_GetIndexContact(ICQ_Socket,DWORD Index);

// �������� ���������� � �������� �� ICQ ������ 
ICQ_SOCKET_API ICQ_Contact * __cdecl ICQ_GetUINContact(ICQ_Socket,DWORD UIN);

// ������ �������, ��. ICQ_SetContact2
ICQ_SOCKET_API void __cdecl ICQ_SetContact(ICQ_Socket,DWORD UIN,BOOL Visible);

// �������� ��� �������� �������. 
// �������� Visible ������������ ���������� �������� � ������� ������
// �������� Invisible ������������ ���������� �������� � ��������� ������
ICQ_SOCKET_API void __cdecl ICQ_SetContact2(ICQ_Socket,DWORD UIN,BOOL Visible,BOOL Invisible);

// ������� ������� �� ��� �������
ICQ_SOCKET_API void __cdecl ICQ_DeleteIndexContact(ICQ_Socket S,DWORD Index);
ICQ_SOCKET_API void __cdecl ICQ_RemoveIndexContact(ICQ_Socket S,DWORD Index); // old

// ������� ������� �� ICQ ������ 
ICQ_SOCKET_API void __cdecl ICQ_DeleteUINContact(ICQ_Socket S,DWORD UIN);
ICQ_SOCKET_API void __cdecl ICQ_RemoveUINContact(ICQ_Socket S,DWORD UIN); // old

// ��������� ������ ���������
ICQ_SOCKET_API void __cdecl ICQ_ClearContactList(ICQ_Socket);

// -------------------------------------------------------------
// ������������ � �������. ���� ��� ��������������� �������� �����������,
// �� ����������� �������� Active ��� ���� �� ����
ICQ_SOCKET_API long __cdecl ICQ_Connect(ICQ_Socket,
  const char * Host,long Port,ICQ_Status,DWORD UIN,const char * Nick,const char * Pass);

// ����������� �� �������
ICQ_SOCKET_API void __cdecl ICQ_Disconnect(ICQ_Socket);

// -------------------------------------------------------------

// ������� ������� ��� ���� �������� �������, ��. ICQ_PollSocket
ICQ_SOCKET_API void __cdecl ICQ_Poll();

// ������� ������� ��� ������.
// ������ ���������� ��� ��������� ������� � ���� 
// (����� ���������, �����������, �������� ������������� �� ������ � ��)
ICQ_SOCKET_API void __cdecl ICQ_PollSocket(ICQ_Socket);

// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// ����� ���� ������� �������� ������ �� ����. ��� ����� ������� 
// ���������� � ICQ_Send_. ����������� ���������� �������� ���������
// ��������:
//   ICQ_Result_OK - ���������� ����������, ����� ��� ���������
//   ICQ_Result_Error - ��������� ������ ��� ������� ������. 
//     ����� ��������, ��� ��� �������� ����� ��������, ����� 
//     ��� ��������� � ���������� ���������
//   ICQ_Result_Void - ������ ������� �� �������������� � ������
//     ������ ����������
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------
// -------------------------------------------------------------


// ��������� ����. ��������� ����� � ������� UserInfo
ICQ_SOCKET_API long __cdecl ICQ_Send_GetInfo(ICQ_Socket,DWORD UIN);

// ===== ��� ������������� � �������� �������� ===== 
ICQ_SOCKET_API long __cdecl ICQ_Send_GetExtInfo(ICQ_Socket,DWORD UIN);

// ��������� ���� ����. ��������� ����� � ��������:
//   MetaUserInfo2, MetaUserMore, MetaUserWork, MetaUserAbout, 
//   MetaUserInterests, MetaUserAffiliations
ICQ_SOCKET_API long __cdecl ICQ_Send_GetMetaInfo(ICQ_Socket,DWORD UIN);

// -------------------------------------------------------------

// ��������� ���������
// ===== ��� ������� �������� ������ � ������ ������ ===== 
// � �������� ���������� ��������� ����������� ICQ_Send_ThruServer
ICQ_SOCKET_API long __cdecl ICQ_Send_Message(ICQ_Socket,DWORD UIN,const char * Text,ICQ_Send);

// ��������� url
// � �������� ���������� ��������� ����������� ICQ_Send_ThruServer
ICQ_SOCKET_API long __cdecl ICQ_Send_Url(ICQ_Socket,DWORD UIN,const char * Url,const char * Desc,ICQ_Send);

// ������ ������������. ���� ���� �� ������, �� 
// ����������� "" ��� ��������� ���������� � 0 ��� ���������. 
// ����� MetaUserFound ��� ������������ ���������� ������ � 
// MetaEndFound ��� ���������� ��������
ICQ_SOCKET_API long __cdecl ICQ_Send_Search(ICQ_Socket,DWORD UIN,
     const char * Email,const char * Nick,
     const char * FirstName,const char * LastName);

// ������ ������������ �� ����������� ����������. ���� ���� �� ������, �� 
// ����������� "" ��� ��������� ���������� � 0 ��� ���������. 
// ����� MetaUserFound ��� ������������ ���������� ������ � 
// MetaEndFound ��� ���������� ��������
ICQ_SOCKET_API long __cdecl ICQ_Send_FullSearch2(ICQ_Socket S,
    const char * Email,const char * Nick,
    const char * FirstName,const char * LastName,
    DWORD MinAge,DWORD MaxAge,ICQ_Gender Gender,
    DWORD Lang,const char * City,const char * State,DWORD Country,
    const char * Company,const char * Department,const char * Job,
    DWORD Occupation,
    DWORD Background,const char * BackgroundDesc,
    DWORD Interests,const char * InterestsDesc,
    DWORD Affiliation,const char * AffiliationDesc,
    DWORD Homepage,const char * HomepageDesc,
    BOOL Online);

ICQ_SOCKET_API long __cdecl ICQ_Send_FullSearch(ICQ_Socket S,
    const char * Email,const char * Nick,
    const char * FirstName,const char * LastName,
    DWORD MinAge,DWORD MaxAge,ICQ_Gender Gender,
    DWORD Lang,const char * City,const char * State,DWORD Country,
    const char * Company,const char * Department,const char * Job,
    DWORD Occupation,
    DWORD Background,const char * BackgroundDesc,
    DWORD Affiliation,const char * AffiliationDesc,
    DWORD Homepage,const char * HomepageDesc,
    BOOL Online);

// ���� �� ��������������
// ===== ��� ������� �������� ������ � ������ ������ ===== 
ICQ_SOCKET_API long __cdecl ICQ_Send_KeepAlive(ICQ_Socket);

// ������� �� ������ ������ ���������
ICQ_SOCKET_API long __cdecl ICQ_Send_ContactList(ICQ_Socket);
ICQ_SOCKET_API long __cdecl ICQ_Send_VisibleList(ICQ_Socket);
ICQ_SOCKET_API long __cdecl ICQ_Send_InvisibleList(ICQ_Socket);

// ������� ������������� ����� �� ������ ���������� ��� � ������ ���������
// ���������� �������, ��. ICQ_Send_AllowRequest � ICQ_Send_DeniedRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_Authorize(ICQ_Socket,DWORD UIN);

// -------------------------------------------------------------
// ������� ������������� ����� �� ������. ���������� ������������
// � �������� ProcessChatRequest, ProcessFileRequest, ProcessAuthRequest.
// � ������ ������ ���������� �������� ������ ������ �� ������� ProcessAuthRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_AllowRequest(ICQ_Socket);

// ������� ������������� ����� �� ������. ���������� ������������
// � �������� ProcessChatRequest, ProcessFileRequest, ProcessAuthRequest.
// � ������ ������ ���������� �������� ������ ������ �� ������� ProcessAuthRequest
ICQ_SOCKET_API long __cdecl ICQ_Send_DeniedRequest(ICQ_Socket);

// -------------------------------------------------------------
// ������� ��������� ����������. ���� �� �����������.

ICQ_SOCKET_API long __cdecl ICQ_Send_SetAuth(ICQ_Socket S,ICQ_Auth Auth);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetUserInfo(ICQ_Socket, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfo2(ICQ_Socket S, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email,const char * Email2,const char * Email3, 
  const char * City,const char * State,const char * Phone, 
  const char * Fax,const char * Street,const char * Cellular, 
  DWORD Zip,DWORD CountryCode,float TimeOffset,BOOL HideEmail);

// old version
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfo(ICQ_Socket, 
  const char * Nick,const char * First,const char * Last, 
  const char * Email,const char * Email2,const char * Email3, 
  const char * City,const char * State,const char * Phone, 
  const char * Fax,const char * Street,const char * Cellular, 
  DWORD Zip,DWORD CountryCode,DWORD CountryStat,BOOL HideEmail);

// ��� �������������, �������� ��� �� "�� ����������"
// ����������� ICQ_Send_SetMetaInfoMore
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoHome(ICQ_Socket,
  DWORD Age,const char * HomePage,
  DWORD Year,DWORD Month,DWORD Day,
  DWORD Lang1,DWORD Lang2,DWORD Lang3);

// ���� ������� �� "��������", �� Age ����� 0xFFFF
ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoMore(ICQ_Socket,
  DWORD Age,ICQ_Gender Gender,const char * HomePage,
  DWORD Year,DWORD Month,DWORD Day,
  DWORD Lang1,DWORD Lang2,DWORD Lang3);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoAbout(ICQ_Socket,
  const char * About);

ICQ_SOCKET_API long __cdecl ICQ_Send_SetMetaInfoSecurity(ICQ_Socket,
  ICQ_Auth,BOOL Web,BOOL HideIp);

// -------------------------------------------------------------
//misc

// ����� ���������� ���������� ��������
// ===== ��� ������������� � �������� �������� ===== 
ICQ_SOCKET_API long __cdecl ICQ_Wait(ICQ_Socket);

ICQ_SOCKET_API long __cdecl ICQ_WaitTimeout(ICQ_Socket,DWORD);
// ================================================================
// default: 12 = english

ICQ_SOCKET_API char * __cdecl ICQ_GetCountry(DWORD Key,DWORD Lang = 12);

// return true if key is unsigned
ICQ_SOCKET_API BOOL __cdecl ICQ_GetCountryRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetOccupation(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetOccupationRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetBackground(DWORD Key,DWORD Lang = 12);                              
ICQ_SOCKET_API BOOL __cdecl ICQ_GetBackgroundRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetAffiliation(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetAffiliationRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetLanguage(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetLanguageRange(DWORD& Min,DWORD& Max);

ICQ_SOCKET_API char * __cdecl ICQ_GetInterest(DWORD Key,DWORD Lang = 12);
ICQ_SOCKET_API BOOL __cdecl ICQ_GetInterestRange(DWORD& Min,DWORD& Max);

#endif
