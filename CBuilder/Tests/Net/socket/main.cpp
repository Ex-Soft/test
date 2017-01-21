//---------------------------------------------------------------------------

#include <stdio.h>
#include <winsock.h>
#include <string.h>
#pragma hdrstop

//#define TEST_INDY_BASE64
//#define TEST_IP_GET
#define TEST_SEND_EMAIL

#if defined(TEST_INDY_BASE64)
   #include <IdCoder3to4.hpp>
#endif

#if defined(TEST_IP_GET)
   #include <iphlpapi.h>
#endif
//---------------------------------------------------------------------------

const int WINSOCK_VERSION=0x0101;

#pragma argsused
int main(int argc, char* argv[])
{
#if defined(TEST_INDY_BASE64)
   TIdBase64Decoder
     *IdBase64Decoder=new TIdBase64Decoder(0);

   IdBase64Decoder->Reset();
   IdBase64Decoder->AutoCompleteInput=true;

   char
     *MyAuth="ADRvdGhlcnNAbWFpbC5ydQBleHBlcmltZW50YXRvcg==";

   AnsiString
     Line=IdBase64Decoder->CodeString(MyAuth);

   int
     BytesOut=IdBase64Decoder->BytesOut.H<<16 | IdBase64Decoder->BytesOut.L;

   AnsiString
     tmpLine;

   for(;!Line.IsEmpty();)
      tmpLine=Fetch(Line,'\x0');

   TIdBase64Encoder
     *IdBase64Encoder=new TIdBase64Encoder(0);

   tmpLine=IdBase64Encoder->GetVersion();

   IdBase64Encoder->Reset();
   IdBase64Encoder->IgnoreNotification=false;
   IdBase64Encoder->IgnoreCodedData=false;
   IdBase64Encoder->AutoCompleteInput=true;

   char
     StrToEncoder[255];

   *StrToEncoder='\x0';
   *(StrToEncoder+1)='\x0';
   strcat(StrToEncoder+1,"4others@mail.ru");

   int
     Pos=strlen(StrToEncoder+1)+1;

   *(StrToEncoder+Pos)='\x0';
   *(StrToEncoder+Pos+1)='\x0';
   strcat(StrToEncoder+Pos+1,"password");
   Pos+=strlen(StrToEncoder+Pos+1)+1;
   *(StrToEncoder+Pos)='\x0';
   *(StrToEncoder+Pos+1)='\x0';
   Line=IdBase64Encoder->CodeString(AnsiString(StrToEncoder,Pos));

   Pos=Line.Pos(";");
   Line=Line.Delete(1,Pos);
   if(Line!=MyAuth)
     Line=MyAuth;

   setmem(StrToEncoder,sizeof(StrToEncoder),'\x0');
   strcpy(StrToEncoder,Line.c_str());
   if(Pos=strcmp(StrToEncoder,MyAuth))
     ;

   IdBase64Decoder->Reset();
   Line=IdBase64Decoder->CodeString(StrToEncoder);

   for(;!Line.IsEmpty();)
      tmpLine=Fetch(Line,'\x0');

   delete IdBase64Encoder;
   delete IdBase64Decoder;
#endif

   WSADATA
     wsaData;

   if(WSAStartup(WINSOCK_VERSION,&wsaData))
   {
      printf("winsock not bi initialized!\n");
      WSACleanup();
      return(-1);
   }
   else
      printf("Winsock initial OK!!!!\n");

   char
     chInfo[64];

   if(gethostname(chInfo,sizeof(chInfo)))
   {
      printf("Not local host\n");
      return(-1);
   }
   else
   {
      printf(chInfo);
      printf(" GetHostName OK !!!!!\n");
   }

#if defined(TEST_IP_GET)
   printf("\n");

   hostent
     *localhost;

   int
     i;

   u_long
     ipHO;

   char
     dot[6],
     result[64];

   unsigned char
     binIp[4];

   if(localhost=gethostbyname(chInfo))
   {
      unsigned long
        addr_local=*((unsigned long *)localhost->h_addr);

      in_addr
        in;

      char
        *addr_str;

      in.S_un.S_un_b.s_b1=localhost->h_addr_list[0][0];
      in.S_un.S_un_b.s_b2=localhost->h_addr_list[0][1];
      in.S_un.S_un_b.s_b3=localhost->h_addr_list[0][2];
      in.S_un.S_un_b.s_b4=localhost->h_addr_list[0][3];
      addr_str=inet_ntoa(in);

      printf("h_addr_list#1\n");

      printf("%s\n",addr_str);
      printf("\n");

      int
        iterations=0;

      u_long
        *ppIpNO;

      u_long
        *pIpNO;

      i=0;
      *result=0;

      printf("h_addr_list#2\n");

      do
      {
         iterations++;
         ppIpNO=(u_long *)localhost->h_addr_list;
         if(ppIpNO+i==NULL)
           break;
         pIpNO=((u_long *)*(ppIpNO+i));
         if(pIpNO==NULL)
           break;

         //convert back to host order, since SOCKADDR_IN expects that
         ipHO=ntohl(*pIpNO);

         binIp[0]=(BYTE)((ipHO & 0xff000000) >> 24);
         itoa(binIp[0],dot,10);
         strcat(result,dot);
         binIp[1]=(BYTE)((ipHO & 0x00ff0000) >> 16);
         itoa(binIp[1],dot,10);
         strcat(result,".");
         strcat(result,dot);
         binIp[2]=(BYTE)((ipHO & 0x0000ff00) >> 8);
         itoa(binIp[2],dot,10);
         strcat(result,".");
         strcat(result,dot);
         binIp[3]=(BYTE)(ipHO & 0x000000ff);
         itoa(binIp[3],dot,10);
         strcat(result,".");
         strcat(result,dot);
         strcat(result,"\n");
         printf("%s",result);
         i++;
      }while((pIpNO != NULL) && (iterations < 6));
   }
   printf("\n");

   unsigned long
     size=0;

   GetIpAddrTable(0,&size,false);

   PMIB_IPADDRTABLE
     table=(PMIB_IPADDRTABLE)malloc(size);

   GetIpAddrTable(table,&size,false);

   int
     count=table->dwNumEntries;

   MIB_IPADDRROW
     *Row=&(table->table[0]);

   printf("GetIpAddrTable\n");

   for(i=0; i<count; ++i,++Row)
   {
      ipHO=ntohl(table->table[i].dwAddr);

      *result=0;
      
      binIp[0]=(BYTE)((ipHO & 0xff000000) >> 24);
      itoa(binIp[0],dot,10);
      strcat(result,dot);
      binIp[1]=(BYTE)((ipHO & 0x00ff0000) >> 16);
      itoa(binIp[1],dot,10);
      strcat(result,".");
      strcat(result,dot);
      binIp[2]=(BYTE)((ipHO & 0x0000ff00) >> 8);
      itoa(binIp[2],dot,10);
      strcat(result,".");
      strcat(result,dot);
      binIp[3]=(BYTE)(ipHO & 0x000000ff);
      itoa(binIp[3],dot,10);
      strcat(result,".");
      strcat(result,dot);
      strcat(result,"\n");
      printf("%s",result);

      printf("\tAddress: %ld\n",table->table[i].dwAddr);
      printf("\tMask:    %ld\n",table->table[i].dwMask);
      printf("\tIndex:   %ld\n",table->table[i].dwIndex);
      printf("\tBCast:   %ld\n",table->table[i].dwBCastAddr);
      printf("\tReasm:   %ld\n",table->table[i].dwReasmSize);
   }
   
   free(table);
#endif

#if defined(TEST_SEND_EMAIL)
   SOCKET
     hServerSocket=socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);

   if(hServerSocket==INVALID_SOCKET)
   {
      printf("Error create socket :-(\n");
      return(-1);
   }

   int
     Result;

   char
     *Mess;

   hostent
     *mailru=gethostbyname("smtp.mail.ru");

   unsigned long
     addr= *((unsigned long *)mailru->h_addr);//inet_addr(
     //"212.26.141.2""62.244.21.66");

   SOCKADDR_IN
     sockAddr;

   sockAddr.sin_family=AF_INET;
   sockAddr.sin_port=htons(25);
   sockAddr.sin_addr.s_addr=addr;

   int
     nConnect=connect(hServerSocket,(PSOCKADDR)&sockAddr,sizeof(sockAddr));

   char
     Buff[0x0ffff];

   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="EHLO nozhenko\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }


   Mess="AUTH PLAIN\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="ADRvdGhlcnNAbWFpbC5ydQBleHBlcmltZW50YXRvcg==\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="VRFY 4others\r\n";
   //Mess="VRFY 4others@mail.ru\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   //Mess="MAIL FROM:<nozhenko@vek.kiev.ua>\r\n";
   Mess="MAIL FROM:<4others@mail.ru>\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="RCPT TO:<bva_kiev@mail.ru>\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="RCPT TO:<4others@ua.fm>\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

//   Mess="RCPT TO:<380972514722@2sms.kyivstar.net>\r\n";
//   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
//   {
//      Result=WSAGetLastError();
//   }
//   setmem(Buff,sizeof(Buff),'\x0');
//   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
//   {
//      Result=WSAGetLastError();
//   }

   Mess="DATA\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
//BCC: 380972514722@2sms.kyivstar.net\r\n
   Mess="From: 4others@mail.ru\r\nTo: Vladimir Bondarenko <bva_kiev@mail.ru>\r\nCC: 4others@ua.fm\r\nMIME-Version: 1.0\r\nContent-Type: text/plain; charset=windows-1251\r\nContent-Transfer-Encoding: 8bit\r\nSubject: 义耱 from my programm (2 rn)\r\nX-Confirm-Reading-To: 4others@mail.ru\r\nDisposition-Notification-To: 4others@mail.ru\r\nReturn-Receipt-To: 4others@mail.ru\r\nX-Priority: 1 (High)\r\n\r\nLine#1 义耱\r\nLine#2 义耱\r\nLine#3 义耱\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   Mess=".\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

//   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
//   {
//      Result=WSAGetLastError();
//   }

   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   Mess="QUIT\r\n";
   if((Result=send(hServerSocket,Mess,strlen(Mess),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }
   setmem(Buff,sizeof(Buff),'\x0');
   if((Result=recv(hServerSocket,Buff,sizeof(Buff),0))==SOCKET_ERROR)
   {
      Result=WSAGetLastError();
   }

   closesocket(hServerSocket);
#endif

   if(WSACleanup())
   {
      printf("Error Cleapir\n");
      return(-1);
   }
   else
     printf("Cleapir Good !!!!!\n");

   return(0);
}
//---------------------------------------------------------------------------

