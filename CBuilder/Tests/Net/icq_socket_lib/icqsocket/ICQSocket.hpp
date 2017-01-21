// Borland C++ Builder
// Copyright (c) 1995, 1999 by Borland International
// All rights reserved

// (DO NOT EDIT: machine generated header) 'ICQSocket.pas' rev: 5.00

#ifndef ICQSocketHPP
#define ICQSocketHPP

#pragma delphiheader begin
#pragma option push -w-
#pragma option push -Vx
#include <ICQ_Type_pas.hpp>	// Pascal unit
#include <Dialogs.hpp>	// Pascal unit
#include <Forms.hpp>	// Pascal unit
#include <Controls.hpp>	// Pascal unit
#include <Graphics.hpp>	// Pascal unit
#include <Classes.hpp>	// Pascal unit
#include <SysUtils.hpp>	// Pascal unit
#include <Messages.hpp>	// Pascal unit
#include <Windows.hpp>	// Pascal unit
#include <SysInit.hpp>	// Pascal unit
#include <System.hpp>	// Pascal unit

//-- user supplied -----------------------------------------------------------

namespace Icqsocket
{
//-- type declarations -------------------------------------------------------
typedef void __fastcall (__closure *TICQSocket_Error)(System::TObject* Sender, int Error);

typedef void __fastcall (__closure *TICQSocket_Connecting)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_Connected)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_Disconnecting)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_Disconnected)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_InvalidLogin)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_InvalidPassword)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_InvalidUIN)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_ContactOnline)(System::TObject* Sender, const Icq_type_pas::ICQ_Contact 
	&Contact);

typedef void __fastcall (__closure *TICQSocket_ContactOffline)(System::TObject* Sender, const Icq_type_pas::ICQ_Contact 
	&Contact);

typedef void __fastcall (__closure *TICQSocket_ContactStatusUpdate)(System::TObject* Sender, const Icq_type_pas::ICQ_Contact 
	&Contact);

typedef void __fastcall (__closure *TICQSocket_UserFound)(System::TObject* Sender, unsigned UIN, const 
	AnsiString Nick, const AnsiString First, const AnsiString Last, const AnsiString Email, Icq_type_pas::ICQ_Auth 
	Auth);

typedef void __fastcall (__closure *TICQSocket_EndFound)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_NewUIN)(System::TObject* Sender, unsigned UIN);

typedef void __fastcall (__closure *TICQSocket_ProcessMessage)(System::TObject* Sender, unsigned UIN
	, System::TDateTime Date, const AnsiString Msg);

typedef void __fastcall (__closure *TICQSocket_ProcessUrl)(System::TObject* Sender, unsigned UIN, System::TDateTime 
	Date, const AnsiString Url, const AnsiString Desc);

typedef void __fastcall (__closure *TICQSocket_ProcessWebPager)(System::TObject* Sender, System::TDateTime 
	Date, const AnsiString Nick, const AnsiString Email, const AnsiString Msg);

typedef void __fastcall (__closure *TICQSocket_ProcessAdded)(System::TObject* Sender, unsigned UIN, 
	System::TDateTime Date, const AnsiString Nick, const AnsiString First, const AnsiString Last, const 
	AnsiString Email);

typedef void __fastcall (__closure *TICQSocket_ProcessMailExpress)(System::TObject* Sender, System::TDateTime 
	Date, const AnsiString Nick, const AnsiString Email, const AnsiString Msg);

typedef void __fastcall (__closure *TICQSocket_ProcessChatRequest)(System::TObject* Sender, unsigned 
	UIN, System::TDateTime Date, const AnsiString Desc);

typedef void __fastcall (__closure *TICQSocket_ProcessFileRequest)(System::TObject* Sender, unsigned 
	UIN, System::TDateTime Date, const AnsiString Desc, const AnsiString FileName, int FileSize);

typedef void __fastcall (__closure *TICQSocket_ProcessAuthRequest)(System::TObject* Sender, unsigned 
	UIN, System::TDateTime Date, const AnsiString Nick, const AnsiString First, const AnsiString Last, 
	const AnsiString Email, const AnsiString Reson);

typedef void __fastcall (__closure *TICQSocket_UserNotFound)(System::TObject* Sender, unsigned UIN);
	

typedef void __fastcall (__closure *TICQSocket_UserInfo)(System::TObject* Sender, unsigned UIN, const 
	AnsiString Nick, const AnsiString First, const AnsiString Last, const AnsiString Email, Icq_type_pas::ICQ_Auth 
	Auth);

typedef void __fastcall (__closure *TICQSocket_ExtUserInfo)(System::TObject* Sender, unsigned UIN, const 
	AnsiString City, unsigned CountryCode, unsigned CountryStat, const AnsiString State, unsigned Age, 
	Icq_type_pas::ICQ_Gender Gender, const AnsiString Phone, const AnsiString HomePage, const AnsiString 
	About);

typedef void __fastcall (__closure *TICQSocket_ExtUserInfo2)(System::TObject* Sender, unsigned UIN, 
	const AnsiString City, unsigned CountryCode, float TimeOffset, const AnsiString State, unsigned Age
	, Icq_type_pas::ICQ_Gender Gender, const AnsiString Phone, const AnsiString HomePage, const AnsiString 
	About);

typedef void __fastcall (__closure *TICQSocket_BeginWait)(System::TObject* Sender);

typedef bool __fastcall (__closure *TICQSocket_Wait)(System::TObject* Sender, int &WaitResult);

typedef void __fastcall (__closure *TICQSocket_WaitConnect)(System::TObject* Sender, unsigned WaitTime
	);

typedef void __fastcall (__closure *TICQSocket_EndWait)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_MetaUserFound)(System::TObject* Sender, unsigned UIN, 
	const AnsiString Nick, const AnsiString First, const AnsiString Last, const AnsiString Email, Icq_type_pas::ICQ_Auth 
	Auth);

typedef void __fastcall (__closure *TICQSocket_MetaEndFound)(System::TObject* Sender);

typedef void __fastcall (__closure *TICQSocket_MetaUserInfo)(System::TObject* Sender, const AnsiString 
	Nick, const AnsiString First, const AnsiString Last, const AnsiString PriEml, const AnsiString SecEml
	, const AnsiString OldEml, const AnsiString City, const AnsiString State, const AnsiString Phone, const 
	AnsiString Fax, const AnsiString Street, const AnsiString Cellular, unsigned Zip, unsigned Country, 
	unsigned TimeZone, Icq_type_pas::ICQ_Auth Auth, bool Web, bool HideIp);

typedef void __fastcall (__closure *TICQSocket_MetaUserInfo2)(System::TObject* Sender, const AnsiString 
	Nick, const AnsiString First, const AnsiString Last, const AnsiString PriEml, const AnsiString SecEml
	, const AnsiString OldEml, const AnsiString City, const AnsiString State, const AnsiString Phone, const 
	AnsiString Fax, const AnsiString Street, const AnsiString Cellular, unsigned Zip, unsigned Country, 
	float TimeOffset, Icq_type_pas::ICQ_Auth Auth, bool Web, bool HideIp);

typedef void __fastcall (__closure *TICQSocket_MetaUserWork)(System::TObject* Sender, const AnsiString 
	City, const AnsiString State, const AnsiString Phone, const AnsiString Fax, const AnsiString Address
	, unsigned Zip, unsigned Country, const AnsiString Company, const AnsiString Department, const AnsiString 
	Job, unsigned Occupation, const AnsiString HomePage);

typedef void __fastcall (__closure *TICQSocket_MetaUserMore)(System::TObject* Sender, unsigned Age, 
	Icq_type_pas::ICQ_Gender Gender, const AnsiString HomePage, System::TDateTime BDate, unsigned Lang1
	, unsigned Lang2, unsigned Lang3);

typedef void __fastcall (__closure *TICQSocket_MetaUserAbout)(System::TObject* Sender, const AnsiString 
	About);

typedef void __fastcall (__closure *TICQSocket_MetaUserInterests)(System::TObject* Sender, unsigned 
	Num, unsigned Cat1, const AnsiString Int1, unsigned Cat2, const AnsiString Int2, unsigned Cat3, const 
	AnsiString Int3, unsigned Cat4, const AnsiString Int4);

typedef void __fastcall (__closure *TICQSocket_MetaUserAffiliations)(System::TObject* Sender, unsigned 
	Num, unsigned Cat1, const AnsiString Aff1, unsigned Cat2, const AnsiString Aff2, unsigned Cat3, const 
	AnsiString Aff3, unsigned Cat4, const AnsiString Aff4, unsigned BNum, unsigned BCat1, const AnsiString 
	BAck1, unsigned BCat2, const AnsiString BAck2, unsigned BCat3, const AnsiString BAck3, unsigned BCat4
	, const AnsiString BAck4);

typedef void __fastcall (__closure *TICQSocket_MetaUserHomePageCategory)(System::TObject* Sender, unsigned 
	Num, unsigned Cat, const AnsiString Text);

typedef void __fastcall (__closure *TICQSocket_SrvUDPAck)(System::TObject* Sender, unsigned Sequence
	);

typedef void __fastcall (__closure *TICQSocket_SrvTCPAck)(System::TObject* Sender, unsigned ID);

typedef void __fastcall (__closure *TICQSocket_Timeout)(System::TObject* Sender, unsigned CurAttempt
	, unsigned Sequence);

typedef void __fastcall (__closure *TICQSocket_Log)(System::TObject* Sender, Icq_type_pas::ICQ_Log Level
	, const AnsiString Str);

typedef void __fastcall (__closure *TICQSocket_WriteUDPPacket)(System::TObject* Sender, void * Data, 
	void * CryptData, unsigned Len, void * ProxyHeader, unsigned ProxyHeaderLen, unsigned Sequence);

typedef void __fastcall (__closure *TICQSocket_ReadUDPPacket)(System::TObject* Sender, void * Data, 
	unsigned Len, void * ProxyHeader, unsigned ProxyHeaderLen);

typedef void __fastcall (__closure *TICQSocket_WriteOscarPacket)(System::TObject* Sender, void * Data
	, unsigned Len);

typedef void __fastcall (__closure *TICQSocket_ReadOscarPacket)(System::TObject* Sender, void * Data
	, unsigned Len);

typedef bool __fastcall (__closure *TICQLib_ForEach_Function)(System::TObject* Sender, void * P);

class DELPHICLASS TICQSocket;
class PASCALIMPLEMENTATION TICQSocket : public Classes::TComponent 
{
	typedef Classes::TComponent inherited;
	
private:
	void *FSocket;
	TICQSocket_Error FOnError;
	Classes::TNotifyEvent FOnConnecting;
	Classes::TNotifyEvent FOnConnected;
	Classes::TNotifyEvent FOnDisconnecting;
	Classes::TNotifyEvent FOnDisconnected;
	Classes::TNotifyEvent FOnInvalidLogin;
	TICQSocket_ContactOnline FOnContactOnline;
	TICQSocket_ContactOffline FOnContactOffline;
	TICQSocket_ContactStatusUpdate FOnContactStatusUpdate;
	TICQSocket_UserFound FOnUserFound;
	Classes::TNotifyEvent FOnEndFound;
	TICQSocket_NewUIN FOnNewUIN;
	TICQSocket_ProcessMessage FOnProcessMessage;
	TICQSocket_ProcessUrl FOnProcessUrl;
	TICQSocket_ProcessWebPager FOnProcessWebPager;
	TICQSocket_ProcessAdded FOnProcessAdded;
	TICQSocket_ProcessMailExpress FOnProcessMailExpress;
	TICQSocket_ProcessChatRequest FOnProcessChatRequest;
	TICQSocket_ProcessFileRequest FOnProcessFileRequest;
	TICQSocket_ProcessAuthRequest FOnProcessAuthRequest;
	TICQSocket_UserNotFound FOnUserNotFound;
	TICQSocket_UserInfo FOnUserInfo;
	TICQSocket_ExtUserInfo FOnExtUserInfo;
	TICQSocket_Log FOnLog;
	TICQSocket_Timeout FOnTimeout;
	TICQSocket_MetaUserFound FOnMetaUserFound;
	TICQSocket_MetaUserInfo FOnMetaUserInfo;
	TICQSocket_MetaUserWork FOnMetaUserWork;
	TICQSocket_MetaUserMore FOnMetaUserMore;
	TICQSocket_MetaUserAbout FOnMetaUserAbout;
	TICQSocket_MetaUserInterests FOnMetaUserInterests;
	TICQSocket_MetaUserAffiliations FOnMetaUserAffiliations;
	TICQSocket_MetaUserHomePageCategory FOnMetaUserHomePageCategory;
	TICQSocket_SrvUDPAck FOnSrvUDPAck;
	TICQSocket_SrvTCPAck FOnSrvTCPAck;
	Classes::TNotifyEvent FOnBeginWait;
	TICQSocket_Wait FOnWait;
	TICQSocket_WaitConnect FOnWaitConnect;
	Classes::TNotifyEvent FOnEndWait;
	TICQSocket_WriteUDPPacket FOnWriteUDPPacket;
	TICQSocket_ReadUDPPacket FOnReadUDPPacket;
	Classes::TNotifyEvent FOnInvalidUIN;
	Classes::TNotifyEvent FOnInvalidPassword;
	TICQSocket_ExtUserInfo2 FOnExtUserInfo2;
	TICQSocket_MetaUserInfo2 FOnMetaUserInfo2;
	Classes::TNotifyEvent FOnMetaEndFound;
	TICQSocket_WriteOscarPacket FOnWriteOscarPacket;
	TICQSocket_ReadOscarPacket FOnReadOscarPacket;
	void __fastcall SetSocket(void * Value);
	int __fastcall GetProtocolVersion(void);
	void __fastcall SetProtocolVersion(int Value);
	bool __fastcall GetActive(void);
	void __fastcall SetActive(bool Value);
	bool __fastcall GetConnecting(void);
	bool __fastcall GetWaitConnect(void);
	void __fastcall SetWaitConnect(bool Value);
	bool __fastcall GetAutoConnect(void);
	void __fastcall SetAutoConnect(bool Value);
	AnsiString __fastcall GetHost();
	void __fastcall SetHost(AnsiString Value);
	int __fastcall GetHostPort(void);
	void __fastcall SetHostPort(int Value);
	unsigned __fastcall GetUIN(void);
	void __fastcall SetUIN(unsigned Value);
	AnsiString __fastcall GetNick();
	void __fastcall SetNick(AnsiString Value);
	AnsiString __fastcall GetPassword();
	void __fastcall SetPassword(AnsiString Value);
	int __fastcall GetMaxPassLen(void);
	void __fastcall SetMaxPassLen(int Value);
	bool __fastcall GetProxyUsed(void);
	void __fastcall SetProxyUsed(bool Value);
	AnsiString __fastcall GetProxyHost();
	void __fastcall SetProxyHost(AnsiString Value);
	int __fastcall GetProxyPort(void);
	void __fastcall SetProxyPort(int Value);
	bool __fastcall GetProxyLoginUsed(void);
	void __fastcall SetProxyLoginUsed(bool Value);
	AnsiString __fastcall GetProxyUser();
	void __fastcall SetProxyUser(AnsiString Value);
	AnsiString __fastcall GetProxyPassword();
	void __fastcall SetProxyPassword(AnsiString Value);
	Icq_type_pas::ICQ_Status __fastcall GetStatus(void);
	void __fastcall SetStatus(Icq_type_pas::ICQ_Status Value);
	Icq_type_pas::ICQ_Log __fastcall GetLogLevel(void);
	void __fastcall SetLogLevel(Icq_type_pas::ICQ_Log Value);
	int __fastcall GetTimeout(void);
	void __fastcall SetTimeout(int Value);
	int __fastcall GetMaxAttempts(void);
	void __fastcall SetMaxAttempts(int Value);
	int __fastcall GetDisconnectReason(void);
	int __fastcall GetRedirectCount(void);
	AnsiString __fastcall GetRedirectHost();
	int __fastcall GetRedirectPort(void);
	AnsiString __fastcall GetConnectHost();
	int __fastcall GetConnectPort(void);
	unsigned __fastcall GetLastSendUDPSequence(void);
	bool __fastcall GetWait(void);
	int __fastcall GetWaitTimeout(void);
	int __fastcall GetContactCount(void);
	int __fastcall GetUINContactIndex(unsigned UIN);
	Icq_type_pas::PICQ_Contact __fastcall GetIndexContact(int Index);
	Icq_type_pas::PICQ_Contact __fastcall GetUINContact(unsigned UIN);
	AnsiString __fastcall GetLibVersion();
	void __fastcall SetLibVersion(AnsiString Value);
	AnsiString __fastcall GetLicense();
	void __fastcall SetLicense(AnsiString Value);
	void __fastcall SetAllowRequest(bool Value);
	
public:
	__fastcall virtual TICQSocket(Classes::TComponent* AOwner);
	__fastcall virtual ~TICQSocket(void);
	virtual void __fastcall Assign(Classes::TPersistent* Source);
	virtual void __fastcall Loaded(void);
	bool __fastcall NewSocket(void);
	void __fastcall ClearDisconnectReason(void);
	int __fastcall Send_GetInfo(unsigned UIN);
	int __fastcall Send_GetExtInfo(unsigned UIN);
	int __fastcall Send_GetMetaInfo(unsigned UIN);
	int __fastcall Send_Message(unsigned UIN, const AnsiString Text, Icq_type_pas::ICQ_Send Send);
	int __fastcall Send_Url(unsigned UIN, const AnsiString Url, const AnsiString Desc, Icq_type_pas::ICQ_Send 
		Send);
	int __fastcall Send_Search(unsigned UIN, const AnsiString Email, const AnsiString Nick, const AnsiString 
		FirstName, const AnsiString LastName);
	int __fastcall Send_FullSearch(const AnsiString Email, const AnsiString Nick, const AnsiString FirstName
		, const AnsiString LastName, unsigned MinAge, unsigned MaxAge, Icq_type_pas::ICQ_Gender Gender, unsigned 
		Lang, const AnsiString City, const AnsiString State, unsigned Country, const AnsiString Company, const 
		AnsiString Department, const AnsiString Job, unsigned Occupation, unsigned Background, const AnsiString 
		BackgroundDesc, unsigned Affiliation, const AnsiString AffiliationDesc, unsigned Homepage, const AnsiString 
		HomepageDesc, bool Online);
	int __fastcall Send_FullSearch2(const AnsiString Email, const AnsiString Nick, const AnsiString FirstName
		, const AnsiString LastName, unsigned MinAge, unsigned MaxAge, Icq_type_pas::ICQ_Gender Gender, unsigned 
		Lang, const AnsiString City, const AnsiString State, unsigned Country, const AnsiString Company, const 
		AnsiString Department, const AnsiString Job, unsigned Occupation, unsigned Background, const AnsiString 
		BackgroundDesc, unsigned Interests, const AnsiString InterestsDesc, unsigned Affiliation, const AnsiString 
		AffiliationDesc, unsigned Homepage, const AnsiString HomepageDesc, bool Online);
	int __fastcall Send_KeepAlive(void);
	int __fastcall Send_ContactList(void);
	int __fastcall Send_VisibleList(void);
	int __fastcall Send_InvisibleList(void);
	int __fastcall Send_Authorize(unsigned UIN);
	int __fastcall Send_AllowRequest(void);
	int __fastcall Send_DeniedRequest(void);
	int __fastcall Send_SetAuth(Icq_type_pas::ICQ_Auth Auth);
	int __fastcall Send_SetUserInfo(const AnsiString Nick, const AnsiString First, const AnsiString Last
		, const AnsiString Email);
	int __fastcall Send_SetMetaInfo(const AnsiString Nick, const AnsiString First, const AnsiString Last
		, const AnsiString Email, const AnsiString Email2, const AnsiString Email3, const AnsiString City, 
		const AnsiString State, const AnsiString Phone, const AnsiString Fax, const AnsiString Street, const 
		AnsiString Cellular, unsigned Zip, unsigned CountryCode, unsigned CountryStat, bool HideEmail);
	int __fastcall Send_SetMetaInfo2(const AnsiString Nick, const AnsiString First, const AnsiString Last
		, const AnsiString Email, const AnsiString Email2, const AnsiString Email3, const AnsiString City, 
		const AnsiString State, const AnsiString Phone, const AnsiString Fax, const AnsiString Street, const 
		AnsiString Cellular, unsigned Zip, unsigned CountryCode, float TimeOffset, bool HideEmail);
	int __fastcall Send_SetMetaInfoMore(unsigned Age, Icq_type_pas::ICQ_Gender Gender, const AnsiString 
		HomePage, System::TDateTime BDate, unsigned Lang1, unsigned Lang2, unsigned Lang3);
	int __fastcall Send_SetMetaInfoHome(unsigned Age, const AnsiString HomePage, System::TDateTime BDate
		, unsigned Lang1, unsigned Lang2, unsigned Lang3);
	int __fastcall Send_SetMetaInfoAbout(const AnsiString About);
	int __fastcall Send_SetMetaInfoSecurity(Icq_type_pas::ICQ_Auth Auth, bool Web, bool HideIp);
	int __fastcall Wait(void);
	int __fastcall WaitTimeout(unsigned Timeout);
	void __fastcall SetContact(unsigned UIN, bool Visible);
	void __fastcall SetContact2(unsigned UIN, bool Visible, bool Invisible);
	void __fastcall DeleteIndexContact(int Index);
	void __fastcall DeleteUINContact(unsigned UIN);
	void __fastcall RemoveIndexContact(int Index);
	void __fastcall RemoveUINContact(unsigned UIN);
	void __fastcall ClearContactList(void);
	__property void * Socket = {read=FSocket, write=SetSocket};
	__property bool Connecting = {read=GetConnecting, nodefault};
	__property bool IsWait = {read=GetWait, nodefault};
	__property int DisconnectReason = {read=GetDisconnectReason, nodefault};
	__property int RedirectCount = {read=GetRedirectCount, nodefault};
	__property AnsiString RedirectHost = {read=GetRedirectHost};
	__property int RedirectPort = {read=GetRedirectPort, nodefault};
	__property AnsiString ConnectHost = {read=GetConnectHost};
	__property int ConnectPort = {read=GetConnectPort, nodefault};
	__property int ContactCount = {read=GetContactCount, nodefault};
	__property int UINContactIndex[unsigned UIN] = {read=GetUINContactIndex};
	__property Icq_type_pas::PICQ_Contact IndexContact[int I] = {read=GetIndexContact};
	__property Icq_type_pas::PICQ_Contact UINContact[unsigned UIN] = {read=GetUINContact};
	__property bool Active = {read=GetActive, write=SetActive, nodefault};
	__property int WaitTime = {read=GetWaitTimeout, nodefault};
	__property bool AllowRequest = {write=SetAllowRequest, nodefault};
	__property int Timeout = {read=GetTimeout, write=SetTimeout, nodefault};
	__property int MaxAttempts = {read=GetMaxAttempts, write=SetMaxAttempts, nodefault};
	__property unsigned LastSendUDPSequence = {read=GetLastSendUDPSequence, nodefault};
	
__published:
	__property int ProtocolVersion = {read=GetProtocolVersion, write=SetProtocolVersion, nodefault};
	__property bool AutoConnect = {read=GetAutoConnect, write=SetAutoConnect, nodefault};
	__property bool WaitConnect = {read=GetWaitConnect, write=SetWaitConnect, nodefault};
	__property AnsiString Host = {read=GetHost, write=SetHost};
	__property int HostPort = {read=GetHostPort, write=SetHostPort, nodefault};
	__property unsigned UIN = {read=GetUIN, write=SetUIN, nodefault};
	__property AnsiString Nick = {read=GetNick, write=SetNick};
	__property AnsiString Password = {read=GetPassword, write=SetPassword};
	__property int MaxPassLen = {read=GetMaxPassLen, write=SetMaxPassLen, nodefault};
	__property bool ProxyUsed = {read=GetProxyUsed, write=SetProxyUsed, nodefault};
	__property AnsiString ProxyHost = {read=GetProxyHost, write=SetProxyHost};
	__property int ProxyPort = {read=GetProxyPort, write=SetProxyPort, nodefault};
	__property bool ProxyLoginUsed = {read=GetProxyLoginUsed, write=SetProxyLoginUsed, nodefault};
	__property AnsiString ProxyUser = {read=GetProxyUser, write=SetProxyUser};
	__property AnsiString ProxyPassword = {read=GetProxyPassword, write=SetProxyPassword};
	__property Icq_type_pas::ICQ_Status Status = {read=GetStatus, write=SetStatus, nodefault};
	__property Icq_type_pas::ICQ_Log LogLevel = {read=GetLogLevel, write=SetLogLevel, nodefault};
	__property AnsiString LibVersion = {read=GetLibVersion, write=SetLibVersion, stored=false};
	__property AnsiString License = {read=GetLicense, write=SetLicense, stored=false};
	__property TICQSocket_Error OnError = {read=FOnError, write=FOnError};
	__property Classes::TNotifyEvent OnConnecting = {read=FOnConnecting, write=FOnConnecting};
	__property Classes::TNotifyEvent OnConnected = {read=FOnConnected, write=FOnConnected};
	__property Classes::TNotifyEvent OnDisconnecting = {read=FOnDisconnecting, write=FOnDisconnecting};
		
	__property Classes::TNotifyEvent OnDisconnected = {read=FOnDisconnected, write=FOnDisconnected};
	__property Classes::TNotifyEvent OnInvalidLogin = {read=FOnInvalidLogin, write=FOnInvalidLogin};
	__property TICQSocket_ContactOnline OnContactOnline = {read=FOnContactOnline, write=FOnContactOnline
		};
	__property TICQSocket_ContactOffline OnContactOffline = {read=FOnContactOffline, write=FOnContactOffline
		};
	__property TICQSocket_ContactStatusUpdate OnContactStatusUpdate = {read=FOnContactStatusUpdate, write=
		FOnContactStatusUpdate};
	__property TICQSocket_UserFound OnUserFound = {read=FOnUserFound, write=FOnUserFound};
	__property Classes::TNotifyEvent OnEndFound = {read=FOnEndFound, write=FOnEndFound};
	__property TICQSocket_NewUIN OnNewUIN = {read=FOnNewUIN, write=FOnNewUIN};
	__property TICQSocket_ProcessMessage OnProcessMessage = {read=FOnProcessMessage, write=FOnProcessMessage
		};
	__property TICQSocket_ProcessUrl OnProcessUrl = {read=FOnProcessUrl, write=FOnProcessUrl};
	__property TICQSocket_ProcessWebPager OnProcessWebPager = {read=FOnProcessWebPager, write=FOnProcessWebPager
		};
	__property TICQSocket_ProcessAdded OnProcessAdded = {read=FOnProcessAdded, write=FOnProcessAdded};
	__property TICQSocket_ProcessMailExpress OnProcessMailExpress = {read=FOnProcessMailExpress, write=
		FOnProcessMailExpress};
	__property TICQSocket_ProcessChatRequest OnProcessChatRequest = {read=FOnProcessChatRequest, write=
		FOnProcessChatRequest};
	__property TICQSocket_ProcessFileRequest OnProcessFileRequest = {read=FOnProcessFileRequest, write=
		FOnProcessFileRequest};
	__property TICQSocket_ProcessAuthRequest OnProcessAuthRequest = {read=FOnProcessAuthRequest, write=
		FOnProcessAuthRequest};
	__property TICQSocket_UserNotFound OnUserNotFound = {read=FOnUserNotFound, write=FOnUserNotFound};
	__property TICQSocket_UserInfo OnUserInfo = {read=FOnUserInfo, write=FOnUserInfo};
	__property TICQSocket_ExtUserInfo OnExtUserInfo = {read=FOnExtUserInfo, write=FOnExtUserInfo};
	__property TICQSocket_Log OnLog = {read=FOnLog, write=FOnLog};
	__property TICQSocket_Timeout OnTimeout = {read=FOnTimeout, write=FOnTimeout};
	__property TICQSocket_MetaUserFound OnMetaUserFound = {read=FOnMetaUserFound, write=FOnMetaUserFound
		};
	__property TICQSocket_MetaUserInfo OnMetaUserInfo = {read=FOnMetaUserInfo, write=FOnMetaUserInfo};
	__property TICQSocket_MetaUserWork OnMetaUserWork = {read=FOnMetaUserWork, write=FOnMetaUserWork};
	__property TICQSocket_MetaUserMore OnMetaUserMore = {read=FOnMetaUserMore, write=FOnMetaUserMore};
	__property TICQSocket_MetaUserAbout OnMetaUserAbout = {read=FOnMetaUserAbout, write=FOnMetaUserAbout
		};
	__property TICQSocket_MetaUserInterests OnMetaUserInterests = {read=FOnMetaUserInterests, write=FOnMetaUserInterests
		};
	__property TICQSocket_MetaUserAffiliations OnMetaUserAffiliations = {read=FOnMetaUserAffiliations, 
		write=FOnMetaUserAffiliations};
	__property TICQSocket_MetaUserHomePageCategory OnMetaUserHomePageCategory = {read=FOnMetaUserHomePageCategory
		, write=FOnMetaUserHomePageCategory};
	__property TICQSocket_SrvUDPAck OnSrvUDPAck = {read=FOnSrvUDPAck, write=FOnSrvUDPAck};
	__property TICQSocket_SrvTCPAck OnSrvTCPAck = {read=FOnSrvTCPAck, write=FOnSrvTCPAck};
	__property Classes::TNotifyEvent OnBeginWait = {read=FOnBeginWait, write=FOnBeginWait};
	__property TICQSocket_Wait OnWait = {read=FOnWait, write=FOnWait};
	__property TICQSocket_WaitConnect OnWaitConnect = {read=FOnWaitConnect, write=FOnWaitConnect};
	__property Classes::TNotifyEvent OnEndWait = {read=FOnEndWait, write=FOnEndWait};
	__property TICQSocket_WriteUDPPacket OnWriteUDPPacket = {read=FOnWriteUDPPacket, write=FOnWriteUDPPacket
		};
	__property TICQSocket_ReadUDPPacket OnReadUDPPacket = {read=FOnReadUDPPacket, write=FOnReadUDPPacket
		};
	__property Classes::TNotifyEvent OnInvalidUIN = {read=FOnInvalidUIN, write=FOnInvalidUIN};
	__property Classes::TNotifyEvent OnInvalidPassword = {read=FOnInvalidPassword, write=FOnInvalidPassword
		};
	__property TICQSocket_ExtUserInfo2 OnExtUserInfo2 = {read=FOnExtUserInfo2, write=FOnExtUserInfo2};
	__property TICQSocket_MetaUserInfo2 OnMetaUserInfo2 = {read=FOnMetaUserInfo2, write=FOnMetaUserInfo2
		};
	__property Classes::TNotifyEvent OnMetaEndFound = {read=FOnMetaEndFound, write=FOnMetaEndFound};
	__property TICQSocket_WriteOscarPacket OnWriteOscarPacket = {read=FOnWriteOscarPacket, write=FOnWriteOscarPacket
		};
	__property TICQSocket_ReadOscarPacket OnReadOscarPacket = {read=FOnReadOscarPacket, write=FOnReadOscarPacket
		};
};


//-- var, const, procedure ---------------------------------------------------
static const Shortint ICQ_Result_CreateError = 0xffffff9c;
static const Shortint ICQ_Version_Major = 0x2;
static const Shortint ICQ_Version_Minor = 0x3;
extern PACKAGE System::TDateTime ICQ_VoidDate;
extern PACKAGE void __fastcall Register(void);
extern PACKAGE unsigned __fastcall ICQLib_GetVersion(void);
extern PACKAGE AnsiString __fastcall ICQLib_GetStrVersion();
extern PACKAGE unsigned __fastcall ICQLib_GetLicense(void);
extern PACKAGE int __fastcall ICQLib_GetPacketVersion(int Index);
extern PACKAGE int __fastcall ICQLib_GetMaxSocketCount(void);
extern PACKAGE int __fastcall ICQLib_GetSocketCount(void);
extern PACKAGE int __fastcall ICQLib_ForEach(TICQLib_ForEach_Function F, void * P);
extern PACKAGE AnsiString __fastcall ICQLib_GetCountry(unsigned Key, unsigned Lang);
extern PACKAGE bool __fastcall ICQLib_GetCountryRange(unsigned &Min, unsigned &Max);
extern PACKAGE AnsiString __fastcall ICQLib_GetBackground(unsigned Key, unsigned Lang);
extern PACKAGE bool __fastcall ICQLib_GetBackgroundRange(unsigned &Min, unsigned &Max);
extern PACKAGE AnsiString __fastcall ICQLib_GetAffiliation(unsigned Key, unsigned Lang);
extern PACKAGE bool __fastcall ICQLib_GetAffiliationRange(unsigned &Min, unsigned &Max);
extern PACKAGE AnsiString __fastcall ICQLib_GetLanguage(unsigned Key, unsigned Lang);
extern PACKAGE bool __fastcall ICQLib_GetLanguageRange(unsigned &Min, unsigned &Max);
extern PACKAGE AnsiString __fastcall ICQLib_GetInterest(unsigned Key, unsigned Lang);
extern PACKAGE bool __fastcall ICQLib_GetInterestRange(unsigned &Min, unsigned &Max);

}	/* namespace Icqsocket */
#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using namespace Icqsocket;
#endif
#pragma option pop	// -w-
#pragma option pop	// -Vx

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// ICQSocket
