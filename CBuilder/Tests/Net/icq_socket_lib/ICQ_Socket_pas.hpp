// Borland C++ Builder
// Copyright (c) 1995, 1999 by Borland International
// All rights reserved

// (DO NOT EDIT: machine generated header) 'ICQ_Socket_pas.pas' rev: 5.00

#ifndef ICQ_Socket_pasHPP
#define ICQ_Socket_pasHPP

#pragma delphiheader begin
#pragma option push -w-
#pragma option push -Vx
#include <Windows.hpp>	// Pascal unit
#include <ICQ_Type_pas.hpp>	// Pascal unit
#include <SysInit.hpp>	// Pascal unit
#include <System.hpp>	// Pascal unit

//-- user supplied -----------------------------------------------------------

namespace Icq_socket_pas
{
//-- type declarations -------------------------------------------------------
typedef BOOL __cdecl (*ICQ_ForEach_Function)(void * S, void * P);

//-- var, const, procedure ---------------------------------------------------
#define ICQ_LibName "ICQ_Socket.dll"
extern "C" unsigned __cdecl ICQ_GetLibVersion(void);
extern "C" unsigned __cdecl ICQ_GetLicense(void);
extern "C" int __cdecl ICQ_GetPacketVersion(unsigned Index);
extern "C" unsigned __cdecl ICQ_GetMaxSocketCount(void);
extern "C" unsigned __cdecl ICQ_GetSocketCount(void);
extern "C" BOOL __cdecl ICQ_CheckVersion(unsigned Major, unsigned Minor);
extern "C" int __cdecl ICQ_ForEach(ICQ_ForEach_Function F, void * P);
extern "C" void * __cdecl ICQ_NewSocket(void);
extern "C" void __cdecl ICQ_DeleteSocket(void * S);
extern "C" void __cdecl ICQ_SetStdCallback(Icq_type_pas::PICQ_Callback Callback);
extern "C" Icq_type_pas::PICQ_Callback __cdecl ICQ_GetStdCallback(void);
extern "C" void __cdecl ICQ_SetCallback(void * S, Icq_type_pas::PICQ_Callback Callback);
extern "C" Icq_type_pas::PICQ_Callback __cdecl ICQ_GetCallback(void * S);
extern "C" void __cdecl ICQ_SetProtocolVersion(void * S, int Value);
extern "C" int __cdecl ICQ_GetProtocolVersion(void * S);
extern "C" void __cdecl ICQ_SetActive(void * S, BOOL Value);
extern "C" BOOL __cdecl ICQ_GetActive(void * S);
extern "C" void __cdecl ICQ_SetWaitConnect(void * S, BOOL Value);
extern "C" BOOL __cdecl ICQ_GetWaitConnect(void * S);
extern "C" void __cdecl ICQ_SetAutoConnect(void * S, BOOL Value);
extern "C" BOOL __cdecl ICQ_GetAutoConnect(void * S);
extern "C" void __cdecl ICQ_SetHost(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetHost(void * S);
extern "C" void __cdecl ICQ_SetHostPort(void * S, int Value);
extern "C" int __cdecl ICQ_GetHostPort(void * S);
extern "C" void __cdecl ICQ_SetUIN(void * S, unsigned Value);
extern "C" unsigned __cdecl ICQ_GetUIN(void * S);
extern "C" void __cdecl ICQ_SetNick(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetNick(void * S);
extern "C" void __cdecl ICQ_SetPass(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetPass(void * S);
extern "C" void __cdecl ICQ_SetMaxPassLen(void * S, int Value);
extern "C" int __cdecl ICQ_GetMaxPassLen(void * S);
extern "C" void __cdecl ICQ_SetProxyUsed(void * S, BOOL Value);
extern "C" BOOL __cdecl ICQ_GetProxyUsed(void * S);
extern "C" void __cdecl ICQ_SetProxyHost(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetProxyHost(void * S);
extern "C" void __cdecl ICQ_SetProxyPort(void * S, int Value);
extern "C" int __cdecl ICQ_GetProxyPort(void * S);
extern "C" void __cdecl ICQ_SetProxyLoginUsed(void * S, BOOL Value);
extern "C" BOOL __cdecl ICQ_GetProxyLoginUsed(void * S);
extern "C" void __cdecl ICQ_SetProxyUser(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetProxyUser(void * S);
extern "C" void __cdecl ICQ_SetProxyPass(void * S, char * Value);
extern "C" char * __cdecl ICQ_GetProxyPass(void * S);
extern "C" void __cdecl ICQ_SetStatus(void * S, Icq_type_pas::ICQ_Status Status);
extern "C" Icq_type_pas::ICQ_Status __cdecl ICQ_GetStatus(void * S);
extern "C" void __cdecl ICQ_SetLogLevel(void * S, Icq_type_pas::ICQ_Log Value);
extern "C" Icq_type_pas::ICQ_Log __cdecl ICQ_GetLogLevel(void * S);
extern "C" void __cdecl ICQ_SetTimeout(void * S, int Value);
extern "C" int __cdecl ICQ_GetTimeout(void * S);
extern "C" void __cdecl ICQ_SetMaxAttempts(void * S, int Value);
extern "C" int __cdecl ICQ_GetMaxAttempts(void * S);
extern "C" void __cdecl ICQ_SetUserPointer(void * S, void * Value);
extern "C" void * __cdecl ICQ_GetUserPointer(void * S);
extern "C" void __cdecl ICQ_SetWaitPointer(void * S, void * Value);
extern "C" void * __cdecl ICQ_GetWaitPointer(void * S);
extern "C" BOOL __cdecl ICQ_GetWait(void * S);
extern "C" int __cdecl ICQ_GetWaitTimeout(void * S);
extern "C" BOOL __cdecl ICQ_GetConnecting(void * S);
extern "C" int __cdecl ICQ_GetDisconnectReason(void * S);
extern "C" void __cdecl ICQ_ClearDisconnectReason(void * S);
extern "C" int __cdecl ICQ_GetRedirectCount(void * S);
extern "C" char * __cdecl ICQ_GetRedirectHost(void * S);
extern "C" int __cdecl ICQ_GetRedirectPort(void * S);
extern "C" char * __cdecl ICQ_GetConnectHost(void * S);
extern "C" int __cdecl ICQ_GetConnectPort(void * S);
extern "C" unsigned __cdecl ICQ_GetLastSendUDPSequence(void * S);
extern "C" unsigned __cdecl ICQ_GetContactCount(void * S);
extern "C" int __cdecl ICQ_GetUINContactIndex(void * S, unsigned UIN);
extern "C" Icq_type_pas::PICQ_Contact __cdecl ICQ_GetIndexContact(void * S, unsigned Index);
extern "C" Icq_type_pas::PICQ_Contact __cdecl ICQ_GetUINContact(void * S, unsigned UIN);
extern "C" void __cdecl ICQ_SetContact(void * S, unsigned UIN, BOOL Visible);
extern "C" void __cdecl ICQ_SetContact2(void * S, unsigned UIN, BOOL Visible, BOOL Invisible);
extern "C" void __cdecl ICQ_DeleteIndexContact(void * S, unsigned Index);
extern "C" void __cdecl ICQ_DeleteUINContact(void * S, unsigned UIN);
extern "C" void __cdecl ICQ_RemoveIndexContact(void * S, unsigned Index);
extern "C" void __cdecl ICQ_RemoveUINContact(void * S, unsigned UIN);
extern "C" void __cdecl ICQ_ClearContactList(void * S);
extern "C" int __cdecl ICQ_Connect(void * S, char * Host, int Port, Icq_type_pas::ICQ_Status Status, 
	unsigned UIN, char * Nick, char * Pass);
extern "C" void __cdecl ICQ_Disconnect(void * S);
extern "C" void __cdecl ICQ_Poll(void);
extern "C" void __cdecl ICQ_PollSocket(void * S);
extern "C" int __cdecl ICQ_Send_GetInfo(void * S, unsigned UIN);
extern "C" int __cdecl ICQ_Send_GetExtInfo(void * S, unsigned UIN);
extern "C" int __cdecl ICQ_Send_GetMetaInfo(void * S, unsigned UIN);
extern "C" int __cdecl ICQ_Send_Message(void * S, unsigned UIN, char * Text, Icq_type_pas::ICQ_Send 
	Send);
extern "C" int __cdecl ICQ_Send_Url(void * S, unsigned UIN, char * Url, char * Desc, Icq_type_pas::ICQ_Send 
	Send);
extern "C" int __cdecl ICQ_Send_Search(void * S, unsigned UIN, char * Email, char * Nick, char * FirstName
	, char * LastName);
extern "C" int __cdecl ICQ_Send_FullSearch(void * S, char * Email, char * Nick, char * FirstName, char * 
	LastName, unsigned MinAge, unsigned MaxAge, Icq_type_pas::ICQ_Gender Gender, unsigned Lang, char * 
	City, char * State, unsigned Country, char * Company, char * Department, char * Job, unsigned Occupation
	, unsigned Background, char * BackgroundDesc, unsigned Affiliation, char * AffiliationDesc, unsigned 
	Homepage, char * HomepageDesc, BOOL Online);
extern "C" int __cdecl ICQ_Send_FullSearch2(void * S, char * Email, char * Nick, char * FirstName, char * 
	LastName, unsigned MinAge, unsigned MaxAge, Icq_type_pas::ICQ_Gender Gender, unsigned Lang, char * 
	City, char * State, unsigned Country, char * Company, char * Department, char * Job, unsigned Occupation
	, unsigned Background, char * BackgroundDesc, unsigned Interests, char * InterestsDesc, unsigned Affiliation
	, char * AffiliationDesc, unsigned Homepage, char * HomepageDesc, BOOL Online);
extern "C" int __cdecl ICQ_Send_KeepAlive(void * S);
extern "C" int __cdecl ICQ_Send_ContactList(void * S);
extern "C" int __cdecl ICQ_Send_VisibleList(void * S);
extern "C" int __cdecl ICQ_Send_InvisibleList(void * S);
extern "C" int __cdecl ICQ_Send_Authorize(void * S, unsigned UIN);
extern "C" int __cdecl ICQ_Send_AllowRequest(void * S);
extern "C" int __cdecl ICQ_Send_DeniedRequest(void * S);
extern "C" int __cdecl ICQ_Send_SetAuth(void * S, Icq_type_pas::ICQ_Auth Auth);
extern "C" int __cdecl ICQ_Send_SetUserInfo(void * S, char * Nick, char * First, char * Last, char * 
	Email);
extern "C" int __cdecl ICQ_Send_SetMetaInfo2(void * S, char * Nick, char * First, char * Last, char * 
	Email, char * Email2, char * Email3, char * City, char * State, char * Phone, char * Fax, char * Street
	, char * Cellular, unsigned Zip, unsigned CountryCode, float TimeOffset, BOOL HideEmail);
extern "C" int __cdecl ICQ_Send_SetMetaInfo(void * S, char * Nick, char * First, char * Last, char * 
	Email, char * Email2, char * Email3, char * City, char * State, char * Phone, char * Fax, char * Street
	, char * Cellular, unsigned Zip, unsigned CountryCode, unsigned CountryStat, BOOL HideEmail);
extern "C" int __cdecl ICQ_Send_SetMetaInfoMore(void * S, unsigned Age, Icq_type_pas::ICQ_Gender Gender
	, char * HomePage, unsigned BYear, unsigned BMonth, unsigned BDay, unsigned Lang1, unsigned Lang2, 
	unsigned Lang3);
extern "C" int __cdecl ICQ_Send_SetMetaInfoHome(void * S, unsigned Age, char * HomePage, unsigned BYear
	, unsigned BMonth, unsigned BDay, unsigned Lang1, unsigned Lang2, unsigned Lang3);
extern "C" int __cdecl ICQ_Send_SetMetaInfoAbout(void * S, char * About);
extern "C" int __cdecl ICQ_Send_SetMetaInfoSecurity(void * S, Icq_type_pas::ICQ_Auth Auth, BOOL Web, 
	BOOL HideIp);
extern "C" int __cdecl ICQ_Wait(void * S);
extern "C" int __cdecl ICQ_WaitTimeout(void * S, unsigned Timeout);
extern "C" char * __cdecl ICQ_GetCountry(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetCountryRange(unsigned &Min, unsigned &Max);
extern "C" char * __cdecl ICQ_GetOccupation(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetOccupationRange(unsigned &Min, unsigned &Max);
extern "C" char * __cdecl ICQ_GetBackground(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetBackgroundRange(unsigned &Min, unsigned &Max);
extern "C" char * __cdecl ICQ_GetAffiliation(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetAffiliationRange(unsigned &Min, unsigned &Max);
extern "C" char * __cdecl ICQ_GetLanguage(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetLanguageRange(unsigned &Min, unsigned &Max);
extern "C" char * __cdecl ICQ_GetInterest(unsigned Key, unsigned Lang);
extern "C" BOOL __cdecl ICQ_GetInterestRange(unsigned &Min, unsigned &Max);

}	/* namespace Icq_socket_pas */
#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using namespace Icq_socket_pas;
#endif
#pragma option pop	// -w-
#pragma option pop	// -Vx

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// ICQ_Socket_pas
