#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <malloc.h>

#include "../../icq_socket.h"

#pragma comment(lib,"../../icq_socket.lib")

const DWORD TestUIN_1 = ... // тут нужно ввести UIN #1
const char TestUINPassword_1[] = ...; // тут нужно ввести пароль #1

const DWORD TestUIN_2 = ... // тут нужно ввести UIN #1
const char TestUINPassword_2[] = ...; // тут нужно ввести пароль #1

ICQ_Callback Callback;

void SaveLog(const char * str,bool DoStore = true)
{
  SYSTEMTIME Time;
  GetLocalTime(&Time);
  char buf[20000];
  sprintf(buf,"%04d/%02d/%02d %02d:%02d:%02d  -  %s\n",
    Time.wYear,Time.wMonth,Time.wDay,
    Time.wHour,Time.wMinute,Time.wSecond,
    str);
  printf(buf);
  if(!DoStore) return;
  FILE * f = fopen("logmes.txt","at");
  if(!f) return;
  fprintf(f,buf);  
  fclose(f);
}

void __cdecl BeginWait(ICQ_Socket S)
{
  SaveLog("BEGIN wait",false);
}
void __cdecl EndWait(ICQ_Socket S)
{
  SaveLog("END wait",false);
}

void __cdecl Connecting(ICQ_Socket S)
{
  char buf[1000];
  sprintf(buf,"Connecting to %s:%d",ICQ_GetConnectHost(S),ICQ_GetConnectPort(S));
  SaveLog(buf);
}
void __cdecl WaitConnect(ICQ_Socket S,DWORD WaitTime)
{
  char buf[1000];
  sprintf(buf,"Connecting time %d...",WaitTime);
  SaveLog(buf,false);
  
  if(kbhit()){
    char c = getch();
    if(c == 27){
//  if(WaitTime > 100*1000){
      SaveLog("Break connecting...",false);
      ICQ_SetActive(S,false);
      exit(1);
    }
  }
}
void __cdecl Connected(ICQ_Socket S)
{
  SaveLog("Connected");
}

char * GetDisconnectReason(ICQ_Socket S)
{
  long DisconnectReason = ICQ_GetDisconnectReason(S);
  switch(DisconnectReason){
  case ICQ_DisconnectReason_LanError: return "LanError";
  case ICQ_DisconnectReason_Reconnect: return "Reconnect";
  case ICQ_DisconnectReason_NoHostFound: return "NoHostFound";
  case ICQ_DisconnectReason_HostRefused: return "HostRefused";
  case ICQ_DisconnectReason_ProxyNoHostFound: return "ProxyNoHostFound";
  case ICQ_DisconnectReason_ProxyRefused: return "ProxyRefused";
  case ICQ_DisconnectReason_ProxyLoginError: return "ProxyLoginError";
  case ICQ_DisconnectReason_ProxyError: return "ProxyError";
  case ICQ_DisconnectReason_User: return "User";
  case ICQ_DisconnectReason_Timeout: return "Timeout";
  case ICQ_DisconnectReason_InvalidPassword: return "InvalidPassword";
  case ICQ_DisconnectReason_InvalidUIN: return "InvalidUIN";
  case ICQ_DisconnectReason_DeleteSocket: return "DeleteSocket";
  case ICQ_DisconnectReason_ServerGoAway: return "ServerGoAway";
  case ICQ_DisconnectReason_LanDataError: return "LanDataError";
  case ICQ_DisconnectReason_WinError: return "WinError";
  case ICQ_DisconnectReason_Redirect: return "Redirect";
  case ICQ_DisconnectReason_ServerError: return "ServerError";
  case ICQ_DisconnectReason_DualLogin: return "DualLogin";
  case ICQ_DisconnectReason_NULL: return "NULL";
  }
  return "is it reson???";
}

void __cdecl Disconnecting(ICQ_Socket S)
{
}

void __cdecl Disconnected(ICQ_Socket S)
{
  char buf[1000];
  sprintf(buf,"Disconnected: %s",GetDisconnectReason(S));
  SaveLog(buf);
}
void __cdecl InvalidLogin(ICQ_Socket S)
{
  SaveLog("InvalidLogin");
}
  
void __cdecl ProcessMessage(ICQ_Socket S,DWORD UIN,
    DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
    const char * Msg)
{
  char buf[1000];
  sprintf(buf,"Msg from %d, %04d/%02d/%02d %02d:%02d, %s",
    UIN,Year,Month,Day,Hour,Minute,Msg);
  SaveLog(buf);
}

void __cdecl ProcessUrl(ICQ_Socket S,DWORD UIN,
    DWORD Year,DWORD Month,DWORD Day,DWORD Hour,DWORD Minute,
    const char * Url,const char * Desc)
{
  char buf[1000];
  sprintf(buf,"Url from %d, %04d/%02d/%02d %02d:%02d, %s, %s",
    UIN,Year,Month,Day,Hour,Minute,Url,Desc);
  SaveLog(buf);
}

BOOL __cdecl Wait(ICQ_Socket S,void * WaitPointer,int * WaitResult)
{
  return true;
}

void __cdecl Log(ICQ_Socket S,ICQ_Log Level,const char * Str)
{
  char buf[1000];
  sprintf(buf,"Log [%d]: %s",(int)Level,Str);
  SaveLog(buf);
}

char * GetStatus(ICQ_Status Status)
{
  switch(Status){
  case ICQ_Status_Offline: return "Offline";
  case ICQ_Status_Online: return "Online";
  case ICQ_Status_Away: return "Away";
  case ICQ_Status_DND: return "DND";
  case ICQ_Status_NA: return "NA";
  case ICQ_Status_Occupied: return "Occupied";
  case ICQ_Status_FreeChat: return "FreeChat";
  case ICQ_Status_Invisible: return "Invisible";
  }
  return "is it status??";
}

void __cdecl Contact(ICQ_Socket S,ICQ_Contact * C)
{
  char buf[1000];
  sprintf(buf,"Contact: %d, Status: %s",C->UIN,GetStatus(C->Status));
  SaveLog(buf);
}

// ======================================================================

void DumpPacket(ICQ_Socket S,const void * Data,DWORD Len,char * Msg = "")
{
	static const DWORD MAX_DATA_SIZE = 8 * 1024;
	static const DWORD SPACE_PER_LINE = 6 + 16 * 3 + 18 + 5;
  BYTE * buf = (BYTE*)Data;
	DWORD nLenBuf, i, c;
	char szAscii[17], *pPos, more;

	szAscii[16] = '\0';
	i = c = more = 0;

  if(Len > 10000){
		Len = 10000;
		more = 1;
	}

	nLenBuf = (WORD)((((int)(Len / 16) + 1) * SPACE_PER_LINE) + 2 + strlen(Msg));
	char * p = (char*)alloca(nLenBuf);
	pPos = p;
	pPos += sprintf(pPos, Msg);
	pPos += sprintf(pPos, "\n");
	pPos += sprintf(pPos, "0000: ");

	for(;;){
		c = buf[i];
		szAscii[i % 16] = c > 32 ? c : '.';
		pPos += sprintf(pPos, "%02X ", c);
		i++;

		if (i % 16 == 0)
			pPos += sprintf(pPos, "%s",szAscii);
		
    if (i >= Len)
			break;

		if (i % 16 == 0)
			pPos += sprintf(pPos, "\n%04X: ", i);
		else if (i % 8 == 0)
			pPos += sprintf(pPos, " ");
	}

	if (more)
		pPos += sprintf(pPos, "...");
	else if (i % 16 != 0)
	{
		szAscii[(i % 16)] = '\0';
		if ((i % 16) <= 8)
		{
			strcpy(pPos, " ");
			pPos++;
		}
	
		while (i++ % 16 != 0)
			pPos += sprintf(pPos, "   ");
		pPos += sprintf(pPos, "%s", szAscii);
	}
  SaveLog(p);
}

void __cdecl WriteOscarPacket(ICQ_Socket S,const void * Data,DWORD Len)
{
  if(!Data)
    SaveLog("WriteOscarPacket: no data - not registed version!"); else
    DumpPacket(S,Data,Len,"Write to server");
}

void __cdecl ReadOscarPacket(ICQ_Socket S,const void * Data,DWORD Len)
{
  DumpPacket(S,Data,Len,"Read from server");
}

void Start()
{
  char buf[100];

  DWORD Ver = ICQ_GetLibVersion();
  DWORD License = ICQ_GetLicense();
  sprintf(buf,"start, Ver: %d.%d.%d of %d, License: %d",
    (int)((BYTE*)&Ver)[2],
    (int)((BYTE*)&Ver)[1],
    (int)((BYTE*)&Ver)[0],
    (int)((BYTE*)&Ver)[3],
    License);
  SaveLog(buf);

  bool IsOk = ICQ_CheckVersion(2,1);

  sprintf(buf,"Check ver: 2.1 (cur) - %s",IsOk ? "OK" : "Version of library is incorrect!");
  SaveLog(buf);

  if(!IsOk){
    printf("Press any key to exit...\n");
    getch();

    exit(1);
  }
}

int main()
{
  Start();
  
  ZeroMemory(&Callback,sizeof(Callback));
  Callback.dwSize = sizeof(Callback);
  Callback.Connecting = Connecting;
  Callback.BeginWait = BeginWait;
  Callback.EndWait = EndWait;
  Callback.WaitConnect = WaitConnect;
  Callback.Connected = Connected;
  Callback.Disconnecting = Disconnecting;
  Callback.Disconnected = Disconnected;
  Callback.InvalidLogin = InvalidLogin;
  Callback.ProcessMessage = ProcessMessage;
  Callback.ProcessUrl = ProcessUrl;
  Callback.Wait = Wait;
  Callback.Log = Log;
  Callback.ContactOnline = Contact;
  Callback.ContactOffline = Contact;
  Callback.ContactStatusUpdate = Contact;
//  Callback.WriteUDPPacket = WriteUDPPacket;
//  Callback.ReadUDPPacket = ReadUDPPacket;
  Callback.WriteOscarPacket = WriteOscarPacket;
  Callback.ReadOscarPacket = ReadOscarPacket;

  ICQ_SetStdCallback(&Callback);

  ICQ_Socket S[2];
  S[0] = ICQ_NewSocket();
  ICQ_SetUIN(S[0],TestUIN_1);
//  ICQ_SetNick(S,"...");
  ICQ_SetPass(S[0],TestUINPassword_1);
  ICQ_SetAutoConnect(S[0],true);
  ICQ_SetWaitConnect(S[0],true);
 
  S[1] = ICQ_NewSocket();
  ICQ_SetUIN(S[1],TestUIN_2);
//  ICQ_SetNick(S,"...");
  ICQ_SetPass(S[1],TestUINPassword_2);
  ICQ_SetAutoConnect(S[1],true);
  ICQ_SetWaitConnect(S[1],true);
 
  
  ICQ_SetContact2(S[0],TestUIN_2,false,false);
  ICQ_SetContact2(S[1],TestUIN_1,false,false);

  ICQ_SetActive(S[0],true);

  ICQ_SetActive(S[1],true);

  long r;

  for(long i = 0; i < 2; i++){
    DWORD To = ICQ_GetIndexContact(S[i],0)->UIN;
    char buf[1000];
    sprintf(buf,"test message from %u to %u",ICQ_GetUIN(S[i]),To);

    r = ICQ_Send_Message(S[i],To,buf,ICQ_Send_ThruServer);
    if(r == ICQ_Result_Void)
      printf("ICQ_Send_Message - is unsupported in demo version!",false); 
    else
      printf("ICQ_Send_Message - %s\n",r == ICQ_Result_OK ? "OK" : "Error");

    sprintf(buf,"test url info from %u to %u",ICQ_GetUIN(S[i]),To);
    r = ICQ_Send_Url(S[i],To,"http://softvariant.boom.ru",buf,ICQ_Send_ThruServer);
    if(r == ICQ_Result_Void)
      printf("ICQ_Send_Url - is unsupported in demo version!",false); 
    else
      printf("ICQ_Send_Url - %s\n",r == ICQ_Result_OK ? "OK" : "Error");
  }

  printf("in rep... press any key to break...\n");
  for(i = 0; i < 10000; i++, Sleep(100)){
    ICQ_Poll();
    if(kbhit()){ getch(); break; }
  }

  ICQ_DeleteSocket(S[0]);
  ICQ_DeleteSocket(S[1]);

  printf("Press any key to exit...\n");
  getch();

  return 0;
}
