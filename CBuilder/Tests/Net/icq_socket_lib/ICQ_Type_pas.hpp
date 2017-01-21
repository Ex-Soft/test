// Borland C++ Builder
// Copyright (c) 1995, 1999 by Borland International
// All rights reserved

// (DO NOT EDIT: machine generated header) 'ICQ_Type_pas.pas' rev: 5.00

#ifndef ICQ_Type_pasHPP
#define ICQ_Type_pasHPP

#pragma delphiheader begin
#pragma option push -w-
#pragma option push -Vx
#include <Windows.hpp>	// Pascal unit
#include <SysInit.hpp>	// Pascal unit
#include <System.hpp>	// Pascal unit

//-- user supplied -----------------------------------------------------------

namespace Icq_type_pas
{
//-- type declarations -------------------------------------------------------
typedef void *ICQ_Socket;

#pragma option push -b-
enum ICQ_Status { ICQ_Status_Offline, ICQ_Status_Online, ICQ_Status_Away, ICQ_Status_DND, ICQ_Status_NA, 
	ICQ_Status_Occupied, ICQ_Status_FreeChat, ICQ_Status_Invisible };
#pragma option pop

#pragma option push -b-
enum ICQ_Auth { ICQ_Auth_Authorize, ICQ_Auth_Trust };
#pragma option pop

#pragma option push -b-
enum ICQ_Gender { ICQ_Gender_Void, ICQ_Gender_Female, ICQ_Gender_Male };
#pragma option pop

#pragma option push -b-
enum ICQ_Send { ICQ_Send_ThruServer, ICQ_Send_Direct, ICQ_Send_BestWay };
#pragma option pop

#pragma option push -b-
enum ICQ_Log { ICQ_Log_Off, ICQ_Log_Fatal, ICQ_Log_Error, ICQ_Log_Warning, ICQ_Log_Message };
#pragma option pop

struct ICQ_Contact;
typedef ICQ_Contact *PICQ_Contact;

struct ICQ_Contact
{
	unsigned UIN;
	BOOL Visible;
	unsigned IP;
	unsigned Port;
	unsigned RealIP;
	unsigned TcpFlag;
	ICQ_Status Status;
	unsigned Version;
	BOOL Invisible;
	BOOL AllowDirect;
	BOOL Birthday;
	BOOL WebPresence;
	unsigned UserClass;
	unsigned WarningLevel;
} ;

typedef void __cdecl (*ICQ_Callback_Connecting)(void * S);

typedef void __cdecl (*ICQ_Callback_Connected)(void * S);

typedef void __cdecl (*ICQ_Callback_Disconnecting)(void * S);

typedef void __cdecl (*ICQ_Callback_Disconnected)(void * S);

typedef void __cdecl (*ICQ_Callback_InvalidLogin)(void * S);

typedef void __cdecl (*ICQ_Callback_InvalidPassword)(void * S);

typedef void __cdecl (*ICQ_Callback_InvalidUIN)(void * S);

typedef void __cdecl (*ICQ_Callback_ContactOnline)(void * S, PICQ_Contact Contact);

typedef void __cdecl (*ICQ_Callback_ContactOffline)(void * S, PICQ_Contact Contact);

typedef void __cdecl (*ICQ_Callback_ContactStatusUpdate)(void * S, PICQ_Contact Contact);

typedef void __cdecl (*ICQ_Callback_UserFound)(void * S, unsigned UIN, char * Nick, char * First, char * 
	Last, char * Email, ICQ_Auth Auth);

typedef void __cdecl (*ICQ_Callback_EndFound)(void * S);

typedef void __cdecl (*ICQ_Callback_NewUIN)(void * S, unsigned UIN);

typedef void __cdecl (*ICQ_Callback_ProcessMessage)(void * S, unsigned UIN, unsigned Year, unsigned 
	Month, unsigned Day, unsigned Hour, unsigned Minute, char * Msg);

typedef void __cdecl (*ICQ_Callback_ProcessUrl)(void * S, unsigned UIN, unsigned Year, unsigned Month
	, unsigned Day, unsigned Hour, unsigned Minute, char * Url, char * Desc);

typedef void __cdecl (*ICQ_Callback_ProcessWebPager)(void * S, unsigned Year, unsigned Month, unsigned 
	Day, unsigned Hour, unsigned Minute, char * Nick, char * Email, char * Msg);

typedef void __cdecl (*ICQ_Callback_ProcessAdded)(void * S, unsigned UIN, unsigned Year, unsigned Month
	, unsigned Day, unsigned Hour, unsigned Minute, char * Nick, char * First, char * Last, char * Email
	);

typedef void __cdecl (*ICQ_Callback_ProcessMailExpress)(void * S, unsigned Year, unsigned Month, unsigned 
	Day, unsigned Hour, unsigned Minute, char * Nick, char * Email, char * Msg);

typedef void __cdecl (*ICQ_Callback_ProcessChatRequest)(void * S, unsigned UIN, unsigned Year, unsigned 
	Month, unsigned Day, unsigned Hour, unsigned Minute, char * Desc);

typedef void __cdecl (*ICQ_Callback_ProcessFileRequest)(void * S, unsigned UIN, unsigned Year, unsigned 
	Month, unsigned Day, unsigned Hour, unsigned Minute, char * Desc, char * FileName, unsigned FileSize
	);

typedef void __cdecl (*ICQ_Callback_ProcessAuthRequest)(void * S, unsigned UIN, unsigned Year, unsigned 
	Month, unsigned Day, unsigned Hour, unsigned Minute, char * Nick, char * First, char * Last, char * 
	Email, char * Reson);

typedef void __cdecl (*ICQ_Callback_UserNotFound)(void * S, unsigned UIN);

typedef void __cdecl (*ICQ_Callback_UserInfo)(void * S, unsigned UIN, char * Nick, char * First, char * 
	Last, char * Email, ICQ_Auth Auth);

typedef void __cdecl (*ICQ_Callback_ExtUserInfo)(void * S, unsigned UIN, char * City, unsigned CountryCode
	, unsigned CountryStat, char * State, unsigned Age, ICQ_Gender Gender, char * Phone, char * HomePage
	, char * About);

typedef void __cdecl (*ICQ_Callback_ExtUserInfo2)(void * S, unsigned UIN, char * City, unsigned CountryCode
	, float TimeOffset, char * State, unsigned Age, ICQ_Gender Gender, char * Phone, char * HomePage, char * 
	About);

typedef void __cdecl (*ICQ_Callback_SrvUDPAck)(void * S, unsigned Sequence);

typedef void __cdecl (*ICQ_Callback_SrvTCPAck)(void * S, unsigned ID);

typedef void __cdecl (*ICQ_Callback_Log)(void * S, ICQ_Log Level, char * Str);

typedef void __cdecl (*ICQ_Callback_BeginWait)(void * S);

typedef BOOL __cdecl (*ICQ_Callback_Wait)(void * S, void * WaitPointer, int &WaitResult);

typedef void __cdecl (*ICQ_Callback_WaitConnect)(void * S, unsigned WaitTime);

typedef void __cdecl (*ICQ_Callback_Timeout)(void * S, unsigned CurAttempt, unsigned Sequence);

typedef void __cdecl (*ICQ_Callback_EndWait)(void * S);

typedef void __cdecl (*ICQ_Callback_MetaUserFound)(void * S, unsigned UIN, char * Nick, char * First
	, char * Last, char * Email, ICQ_Auth Auth);

typedef void __cdecl (*ICQ_Callback_MetaEndFound)(void * S);

typedef void __cdecl (*ICQ_Callback_MetaUserInfo)(void * S, char * Nick, char * First, char * Last, 
	char * PriEml, char * SecEml, char * OldEml, char * City, char * State, char * Phone, char * Fax, char * 
	Street, char * Cellular, unsigned Zip, unsigned Country, unsigned TimeZone, ICQ_Auth Auth, BOOL Web
	, BOOL HideIp);

typedef void __cdecl (*ICQ_Callback_MetaUserInfo2)(void * S, char * Nick, char * First, char * Last, 
	char * PriEml, char * SecEml, char * OldEml, char * City, char * State, char * Phone, char * Fax, char * 
	Street, char * Cellular, unsigned Zip, unsigned Country, float TimeOffset, ICQ_Auth Auth, BOOL Web, 
	BOOL HideIp);

typedef void __cdecl (*ICQ_Callback_MetaUserWork)(void * S, char * City, char * State, char * Phone, 
	char * Fax, char * Address, unsigned Zip, unsigned Country, char * Company, char * Department, char * 
	Job, unsigned Occupation, char * HomePage);

typedef void __cdecl (*ICQ_Callback_MetaUserMore)(void * S, unsigned Age, ICQ_Gender Gender, char * 
	HomePage, unsigned BYear, unsigned BMonth, unsigned BDay, unsigned Lang1, unsigned Lang2, unsigned 
	Lang3);

typedef void __cdecl (*ICQ_Callback_MetaUserAbout)(void * S, char * About);

typedef void __cdecl (*ICQ_Callback_MetaUserInterests)(void * S, unsigned Num, unsigned Cat1, char * 
	Int1, unsigned Cat2, char * Int2, unsigned Cat3, char * Int3, unsigned Cat4, char * Int4);

typedef void __cdecl (*ICQ_Callback_MetaUserAffiliations)(void * S, unsigned Num, unsigned Cat1, char * 
	Aff1, unsigned Cat2, char * Aff2, unsigned Cat3, char * Aff3, unsigned Cat4, char * Aff4, unsigned 
	BNum, unsigned BCat1, char * BAck1, unsigned BCat2, char * BAck2, unsigned BCat3, char * BAck3, unsigned 
	BCat4, char * BAck4);

typedef void __cdecl (*ICQ_Callback_MetaUserHomePageCategory)(void * S, unsigned Num, unsigned Cat, 
	char * Text);

typedef void __cdecl (*ICQ_Callback_WriteUDPPacket)(void * S, void * Data, void * CryptData, unsigned 
	Len, void * ProxyHeader, unsigned ProxyHeaderLen, unsigned Sequence);

typedef void __cdecl (*ICQ_Callback_ReadUDPPacket)(void * S, void * Data, unsigned Len, void * ProxyHeader
	, unsigned ProxyHeaderLen);

typedef void __cdecl (*ICQ_Callback_WriteOscarPacket)(void * S, void * Data, unsigned Len);

typedef void __cdecl (*ICQ_Callback_ReadOscarPacket)(void * S, void * Data, unsigned Len);

struct ICQ_Callback;
typedef ICQ_Callback *PICQ_Callback;

struct ICQ_Callback
{
	unsigned dwSize;
	ICQ_Callback_Connecting Connecting;
	ICQ_Callback_Connected Connected;
	ICQ_Callback_Disconnecting Disconnecting;
	ICQ_Callback_Disconnected Disconnected;
	ICQ_Callback_InvalidLogin InvalidLogin;
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
	ICQ_Callback_MetaUserInfo MetaUserInfo;
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
	ICQ_Callback_InvalidUIN InvalidUIN;
	ICQ_Callback_InvalidPassword InvalidPassword;
	ICQ_Callback_ExtUserInfo2 ExtUserInfo2;
	ICQ_Callback_MetaUserInfo2 MetaUserInfo2;
	ICQ_Callback_MetaEndFound MetaEndFound;
	ICQ_Callback_WriteOscarPacket WriteOscarPacket;
	ICQ_Callback_ReadOscarPacket ReadOscarPacket;
	ICQ_Callback_UserNotFound UserNotFound;
} ;

typedef BOOL __cdecl (*ICQ_Register)(Word a, Word b, Word c, Word d, Word e);

//-- var, const, procedure ---------------------------------------------------
extern PACKAGE void *ICQ_Invalid_Socket;
#define ICQ_KeyNotFound ""
#define ICQ_KeyNotEntered "? ? ? ?"
static const Shortint ICQ_Result_OK = 0x0;
static const Shortint ICQ_Result_Error = 0xffffffff;
static const Shortint ICQ_Result_Void = 0xfffffffe;
static const Shortint ICQ_Protocol_Udp = 0x5;
static const Shortint ICQ_Protocol_Udp5 = 0x5;
static const Shortint ICQ_Protocol_Oscar = 0x8;
static const Shortint ICQ_Protocol_Oscar8 = 0x8;
static const Shortint ICQ_ProxyType_Socks5 = 0x5;
static const Shortint ICQ_DisconnectReason_NULL = 0x0;
static const Shortint ICQ_DisconnectReason_LanError = 0xffffff9c;
static const Shortint ICQ_DisconnectReason_Reconnect = 0xffffff9b;
static const Shortint ICQ_DisconnectReason_NoHostFound = 0xffffff9a;
static const Shortint ICQ_DisconnectReason_HostRefused = 0xffffff99;
static const Shortint ICQ_DisconnectReason_ProxyNoHostFound = 0xffffff98;
static const Shortint ICQ_DisconnectReason_ProxyRefused = 0xffffff97;
static const Shortint ICQ_DisconnectReason_ProxyLoginError = 0xffffff96;
static const Shortint ICQ_DisconnectReason_ProxyError = 0xffffff95;
static const Shortint ICQ_DisconnectReason_ServerGoAway = 0xffffff94;
static const Shortint ICQ_DisconnectReason_User = 0xffffff93;
static const Shortint ICQ_DisconnectReason_Timeout = 0xffffff92;
static const Shortint ICQ_DisconnectReason_InvalidPassword = 0xffffff91;
static const Shortint ICQ_DisconnectReason_InvalidUIN = 0xffffff90;
static const Shortint ICQ_DisconnectReason_DeleteSocket = 0xffffff8f;
static const Shortint ICQ_DisconnectReason_LanDataError = 0xffffff8e;
static const Shortint ICQ_DisconnectReason_WinError = 0xffffff8d;
static const Shortint ICQ_DisconnectReason_Redirect = 0xffffff8c;
static const Shortint ICQ_DisconnectReason_ServerError = 0xffffff8b;
static const Shortint ICQ_DisconnectReason_DualLogin = 0xffffff8a;

}	/* namespace Icq_type_pas */
#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using namespace Icq_type_pas;
#endif
#pragma option pop	// -w-
#pragma option pop	// -Vx

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// ICQ_Type_pas
