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

#ifndef __ICQ_TYPE_H__
#define __ICQ_TYPE_H__

#include <windows.h>

#ifdef ICQ_SOCKET_EXPORTS
  #define ICQ_SOCKET_API extern "C" extern __declspec(dllexport) 
#else
  #ifdef ICQ_SOCKET_LIB
    #define ICQ_SOCKET_API extern "C" extern 
  #else
    #define ICQ_SOCKET_API extern "C" extern __declspec(dllimport)
  #endif
#endif

// Тип сокета
typedef void *ICQ_Socket;

// Ошибочное значение сокета. Используйте проверку результата функции
// ICQ_NewSocket с этим значением для проверки.
const ICQ_Socket ICQ_Invalid_Socket = (ICQ_Socket)-1;

// см. ICQ_GetCountry и подобные функции
#define ICQ_KeyNotFound   ""
#define ICQ_KeyNotEntered "? ? ? ?"

enum
{
  // Результат значения сетевых функций (начинаются с ICQ_Send_)
  ICQ_Result_OK = 0x0,
  ICQ_Result_Error = -1,
  ICQ_Result_Void = -2, // означает, что функция 
     // не поддерживается в данной версии библиотеки, 
     // например в не зарегистрированной.

  ICQ_Protocol_Udp = 5,
  ICQ_Protocol_Udp5 = 5,
  ICQ_Protocol_Oscar = 8,
  ICQ_Protocol_Oscar8 = 8,

  ICQ_ProxyType_Socks5 = 5,

  ICQ_DisconnectReason_NULL = 0,
  ICQ_DisconnectReason_LanError  = -100, // ошибка: сетевая
  ICQ_DisconnectReason_Reconnect = -101, // подключение
  ICQ_DisconnectReason_NoHostFound = -102, // ошибка: не найден Host
  ICQ_DisconnectReason_HostRefused = -103, // ошибка: нет ответа от Host
  ICQ_DisconnectReason_ProxyNoHostFound = -104, // ошибка: не найден ProxyHost
  ICQ_DisconnectReason_ProxyRefused = -105, // ошибка: нет ответа от ProxyHost
  ICQ_DisconnectReason_ProxyLoginError  = -106, // ошибка авторизации на прокси
  ICQ_DisconnectReason_ProxyError = -107, // ошибка подключения к прокси
  ICQ_DisconnectReason_ServerGoAway = -108, // ICQ сервер нас отключил
  ICQ_DisconnectReason_User = -109, // вызов ICQ_Disconnect или изменение параметров соединения
  ICQ_DisconnectReason_Timeout = -110, // отключение по таймауту
  ICQ_DisconnectReason_InvalidPassword = -111, // не верный пароль при подключении
  ICQ_DisconnectReason_InvalidUIN = -112, // не верный UIN при подключении
  ICQ_DisconnectReason_DeleteSocket = -113, // удаление сокета
  ICQ_DisconnectReason_LanDataError = -114, // ошибка в сетевом пакете
  ICQ_DisconnectReason_WinError = -115, // ошибка Windows
  ICQ_DisconnectReason_Redirect = -116, // необходимо перенаправление для подключения
  ICQ_DisconnectReason_ServerError = -117, // ошибка на ICQ сервере
  ICQ_DisconnectReason_DualLogin = -118 // попытка двойного пдключения
};

enum ICQ_Status // статус
{ 
  ICQ_Status_Offline = 0L,
  ICQ_Status_Online,
  ICQ_Status_Away,
  ICQ_Status_DND,
  ICQ_Status_NA,
  ICQ_Status_Occupied,
  ICQ_Status_FreeChat,
  ICQ_Status_Invisible 
};

enum ICQ_Auth 
{ 
  ICQ_Auth_Authorize = 0L, // необходимо подтверждение для добавления в список контактов
  ICQ_Auth_Trust           // при добавлении в список контактов подтверждения не требуется
};

enum ICQ_Gender // пол
{
  ICQ_Gender_Void = 0L, // не введен
  ICQ_Gender_Female,    // женский
  ICQ_Gender_Male       // мужской
};

enum ICQ_Send // тип отправки сообщений
{ 
  ICQ_Send_ThruServer = 0L, // через главный сервер
  ICQ_Send_Direct, // напрямую - в настоящее время не поддерживается
  ICQ_Send_BestWay // автоматически по лучшему маршруту
};

enum ICQ_Log // трассирока сообщений для отладки
{ 
  ICQ_Log_Off = 0L, // трассировка выключена
  ICQ_Log_Fatal,    // только критические сообщения
  ICQ_Log_Error,    // все ошибки
  ICQ_Log_Warning,  // предупреждения и ошибки
  ICQ_Log_Message   // включены все сообщения
};

struct ICQ_Contact // структура контакта
{
  DWORD UIN;     
  BOOL Visible;  
  DWORD IP,Port,RealIP,TcpFlag;
  ICQ_Status Status; 

  DWORD Version;
  BOOL Invisible;
  BOOL AllowDirect, Birthday, WebPresence;
  DWORD UserClass, WarningLevel;
};

typedef void (__cdecl * ICQ_Callback_Connecting)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_Connected)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_Disconnecting)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_Disconnected)(ICQ_Socket S);

typedef void (__cdecl * ICQ_Callback_ContactOnline)(ICQ_Socket S,ICQ_Contact*);
typedef void (__cdecl * ICQ_Callback_ContactOffline)(ICQ_Socket S,ICQ_Contact*);
typedef void (__cdecl * ICQ_Callback_ContactStatusUpdate)(ICQ_Socket S,ICQ_Contact*);

typedef void (__cdecl * ICQ_Callback_UserFound)(ICQ_Socket S,DWORD UIN,
  const char * Nick,const char * First,const char * Last,const char * Email,ICQ_Auth);

typedef void (__cdecl * ICQ_Callback_EndFound)(ICQ_Socket S);

typedef void (__cdecl * ICQ_Callback_NewUIN)(ICQ_Socket S,DWORD UIN);

typedef void (__cdecl * ICQ_Callback_ProcessMessage)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,const char * Msg);

typedef void (__cdecl * ICQ_Callback_ProcessUrl)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,const char * Url,const char * Desc);

typedef void (__cdecl * ICQ_Callback_ProcessWebPager)(ICQ_Socket S,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
  const char * Nick,const char * Email,const char * Msg);

typedef void (__cdecl * ICQ_Callback_ProcessAdded)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
  const char * Nick,const char * First,const char * Last,const char * Email);

typedef void (__cdecl * ICQ_Callback_ProcessMailExpress)(ICQ_Socket S,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
  const char * Nick,const char * Email,const char * Msg);

typedef void (__cdecl * ICQ_Callback_ProcessChatRequest)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,const char * Desc);

typedef void (__cdecl * ICQ_Callback_ProcessFileRequest)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
  const char * Desc,const char * FileName,DWORD FileSize);

typedef void (__cdecl * ICQ_Callback_ProcessAuthRequest)(ICQ_Socket S,DWORD UIN,
  DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
  const char * Nick,const char * First,const char * Last,const char * Email,const char * Reason);

typedef void (__cdecl * ICQ_Callback_UserNotFound)(ICQ_Socket S,DWORD UIN);

typedef void (__cdecl * ICQ_Callback_UserInfo)(ICQ_Socket S,DWORD UIN,
  const char * Nick,const char * First,const char * Last,const char * Email,ICQ_Auth);

typedef void (__cdecl * ICQ_Callback_ExtUserInfo)(ICQ_Socket S,DWORD UIN,
   const char * City,DWORD CountryCode,DWORD CountryStat,
   const char * State,DWORD Age,ICQ_Gender Gender,const char * Phone,const char * HomePage,const char * About);

typedef void (__cdecl * ICQ_Callback_ExtUserInfo2)(ICQ_Socket S,DWORD UIN,
   const char * City,DWORD CountryCode,float TimeOffset,
   const char * State,DWORD Age,ICQ_Gender Gender,const char * Phone,const char * HomePage,const char * About);

typedef void (__cdecl * ICQ_Callback_SrvUDPAck)(ICQ_Socket S,DWORD Sequence);

typedef void (__cdecl * ICQ_Callback_SrvTCPAck)(ICQ_Socket S,DWORD ID);

typedef void (__cdecl * ICQ_Callback_Log)(ICQ_Socket S,ICQ_Log Level,const char * Str);

typedef BOOL (__cdecl * ICQ_Callback_Wait)(ICQ_Socket S,void * WaitPointer,PINT WaitResult);

typedef void (__cdecl * ICQ_Callback_MetaUserFound)(ICQ_Socket S,DWORD UIN,
  const char * Nick,const char * First,const char * Last,const char * Email,ICQ_Auth);

typedef void (__cdecl * ICQ_Callback_MetaEndFound)(ICQ_Socket S);

typedef void (__cdecl * ICQ_Callback_MetaUserInfo)(ICQ_Socket S,
  const char * Nick,const char * First,const char * Last,const char * PriEml,const char * SecEml,const char * OldEml,
  const char * City,const char * State,const char * Phone,const char * Fax,const char * Street,const char * Cellular,
  DWORD Zip,DWORD CountryCode,DWORD TimeZone,ICQ_Auth,BOOL Web,BOOL HideIp);

typedef void (__cdecl * ICQ_Callback_MetaUserInfo2)(ICQ_Socket S,
  const char * Nick,const char * First,const char * Last,const char * PriEml,const char * SecEml,const char * OldEml,
  const char * City,const char * State,const char * Phone,const char * Fax,const char * Street,const char * Cellular,
  DWORD Zip,DWORD CountryCode,float TimeOffset,ICQ_Auth,BOOL Web,BOOL HideIp);

typedef void (__cdecl * ICQ_Callback_MetaUserWork)(ICQ_Socket S,
  const char * City,const char * State,const char * Phone,const char * Fax,const char * Address,
  DWORD Zip,DWORD CountryCode,const char * Company,const char * Department,const char * Job,
  DWORD Occupation,const char * HomePage);

typedef void (__cdecl * ICQ_Callback_MetaUserMore)(ICQ_Socket S,
  DWORD Age,ICQ_Gender Gender,const char * HomePage,
  DWORD BYear,DWORD BMonth,DWORD BDay,DWORD Lang1,DWORD Lang2,DWORD Lang3);

typedef void (__cdecl * ICQ_Callback_MetaUserAbout)(ICQ_Socket S,const char * About);

typedef void (__cdecl * ICQ_Callback_MetaUserInterests)(ICQ_Socket S,
  DWORD Num,
  DWORD Cat1,const char * Int1,
  DWORD Cat2,const char * Int2,
  DWORD Cat3,const char * Int3,
  DWORD Cat4,const char * Int4);

typedef void (__cdecl * ICQ_Callback_MetaUserAffiliations)(ICQ_Socket S,
  DWORD Num,
  DWORD Cat1,const char * Aff1,
  DWORD Cat2,const char * Aff2,
  DWORD Cat3,const char * Aff3,
  DWORD Cat4,const char * Aff4,
  
  DWORD BNum,
  DWORD BCat1,const char * BAck1,
  DWORD BCat2,const char * BAck2,
  DWORD BCat3,const char * BAck3,
  DWORD BCat4,const char * BAck4);

typedef void (__cdecl * ICQ_Callback_MetaUserHomePageCategory)(ICQ_Socket S,
  DWORD Num,DWORD Cat,const char * Text);

typedef void (__cdecl * ICQ_Callback_Timeout)(ICQ_Socket S,
  DWORD CurAttempt,DWORD Sequence);

typedef void (__cdecl * ICQ_Callback_BeginWait)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_EndWait)(ICQ_Socket S);

typedef void (__cdecl * ICQ_Callback_InvalidLogin)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_InvalidUIN)(ICQ_Socket S);
typedef void (__cdecl * ICQ_Callback_InvalidPassword)(ICQ_Socket S);

typedef void (__cdecl * ICQ_Callback_WaitConnect)(ICQ_Socket S,DWORD WaitTime);

typedef void (__cdecl * ICQ_Callback_WriteUDPPacket)(ICQ_Socket S,
    const void * Data,const void * CryptData,DWORD Len,
    const void * ProxyHeader,DWORD ProxyHeaderLen,DWORD Sequence);

typedef void (__cdecl * ICQ_Callback_ReadUDPPacket)(ICQ_Socket S,
    const void * Data,DWORD Len,
    const void * ProxyHeader,DWORD ProxyHeaderLen);

typedef void (__cdecl * ICQ_Callback_WriteOscarPacket)(ICQ_Socket S,
    const void * Data,DWORD Len);

typedef void (__cdecl * ICQ_Callback_ReadOscarPacket)(ICQ_Socket S,
    const void * Data,DWORD Len);


struct ICQ_Callback
{
  DWORD dwSize;

  ICQ_Callback_Connecting Connecting;
  ICQ_Callback_Connected Connected;
  ICQ_Callback_Disconnecting Disconnecting;
  ICQ_Callback_Disconnected Disconnected;
  
  ICQ_Callback_InvalidLogin InvalidLogin; // old

  ICQ_Callback_ContactOnline ContactOnline;
  ICQ_Callback_ContactOffline ContactOffline;
  ICQ_Callback_ContactStatusUpdate ContactStatusUpdate;

  ICQ_Callback_UserFound UserFound;
  ICQ_Callback_EndFound EndFound;

  ICQ_Callback_NewUIN NewUIN;

  ICQ_Callback_ProcessMessage ProcessMessage;
  ICQ_Callback_ProcessUrl ProcessUrl;
  ICQ_Callback_ProcessWebPager ProcessWebPager;
  ICQ_Callback_ProcessAdded ProcessAdded;
  ICQ_Callback_ProcessMailExpress ProcessMailExpress;
  ICQ_Callback_ProcessChatRequest ProcessChatRequest;
  ICQ_Callback_ProcessFileRequest ProcessFileRequest;
  ICQ_Callback_ProcessAuthRequest ProcessAuthRequest;

  ICQ_Callback_UserInfo UserInfo;
  ICQ_Callback_ExtUserInfo ExtUserInfo;

  ICQ_Callback_SrvUDPAck SrvUDPAck;
  ICQ_Callback_SrvTCPAck SrvTCPAck;

  ICQ_Callback_BeginWait BeginWait;
  ICQ_Callback_Wait Wait;
  ICQ_Callback_WaitConnect WaitConnect;
  ICQ_Callback_EndWait EndWait;

  ICQ_Callback_MetaUserFound MetaUserFound;

  ICQ_Callback_MetaUserInfo MetaUserInfo; // old
  ICQ_Callback_MetaUserWork MetaUserWork;
  ICQ_Callback_MetaUserMore MetaUserMore;
  ICQ_Callback_MetaUserAbout MetaUserAbout;
  ICQ_Callback_MetaUserInterests MetaUserInterests;
  ICQ_Callback_MetaUserAffiliations MetaUserAffiliations;
  ICQ_Callback_MetaUserHomePageCategory MetaUserHomePageCategory;

  ICQ_Callback_Timeout Timeout;
  ICQ_Callback_Log Log;

  ICQ_Callback_WriteUDPPacket WriteUDPPacket;
  ICQ_Callback_ReadUDPPacket ReadUDPPacket;

  // В демо версии события записи пакета вызывается, но 
  // параметры равны NULL. Корректные параметры доступны только
  // в полной версии. 

  ICQ_Callback_InvalidUIN InvalidUIN;
  ICQ_Callback_InvalidPassword InvalidPassword;

  ICQ_Callback_ExtUserInfo2 ExtUserInfo2;
  ICQ_Callback_MetaUserInfo2 MetaUserInfo2;

  ICQ_Callback_MetaEndFound MetaEndFound;

  ICQ_Callback_WriteOscarPacket WriteOscarPacket;
  ICQ_Callback_ReadOscarPacket ReadOscarPacket;

  ICQ_Callback_UserNotFound UserNotFound;
};

typedef BOOL (__cdecl * ICQ_Register)(WORD,WORD,WORD,WORD,WORD);

#endif	
