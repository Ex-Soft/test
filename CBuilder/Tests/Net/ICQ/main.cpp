//---------------------------------------------------------------------------
#include <stdio.h>
#include <winsock.h>
#pragma hdrstop
//---------------------------------------------------------------------------

int ReplyCode(char *Reply);
char *HtmlEncode(unsigned char *inp_str, char *out_str);

//#define SEND_BY_ICQ_COM
#define SEND_BY_MIRANDA_ORG_UA

#pragma argsused
int main(int argc, char* argv[])
{
   const int WINSOCK_VERSION=0x0101;

   WSADATA
     wsaData;

   SOCKET
     conn;

   char
     *Server=0,
     *Client=0;

   if(WSAStartup(WINSOCK_VERSION,&wsaData))
   {
      printf("winsock not bi initialized!!!");
      return(0);
   }

   unsigned int
     ServerSize=0xffff,
     ClientSize=ServerSize;

   while(!Server&&ServerSize)
   {
      Server=new char [ServerSize];
      if(!Server)
        ServerSize>>=1;
   }
   if(!Server&&!ServerSize)
   {
      printf("Insufficient memory!!!");
      WSACleanup();
      return(0);
   }
   while(!Client&&ClientSize)
   {
      Client=new char [ClientSize];
      if(!Client)
        ClientSize>>=1;
   }
   if(!Client&&!ClientSize)
   {
      printf("Insufficient memory!!!");
      delete []Server;
      WSACleanup();
      return(0);
   }

   HtmlEncode("\r\n!\"#$%&'()*+,-./ 0123456789 :;<=>?@\r\nABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n[\\]^_`\r\nabcdefghijklmnopqrstuvwxyz\r\n{|}~\r\n¨¸¥´²³¯¿ªº\r\nÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞß\r\nàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ",Server);

   char
     chInfo[64];

   if(gethostname(chInfo,sizeof(chInfo)))
   {
      printf("Not local host!!! (WSAGetLastError()=%d)",WSAGetLastError());
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }

   if((conn=socket(AF_INET,SOCK_STREAM,IPPROTO_TCP))==INVALID_SOCKET)
   {
      printf("Error create socket!!! (WSAGetLastError()=%d)",WSAGetLastError());
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }

   hostent
     *hp;

   unsigned long
     addr;

   char
     *ICQServer=
   #if defined(SEND_BY_ICQ_COM)
     "wwp.icq.com"
   #elif defined(SEND_BY_MIRANDA_ORG_UA)
     "miranda.org.ua"
   #else
     "wwp.mirabilis.com"
   #endif
     ;

   if((addr=inet_addr(ICQServer))==INADDR_NONE)
     hp=gethostbyname(ICQServer);
   else
     hp=gethostbyaddr((char*)&addr,sizeof(addr),AF_INET);

   if(!hp)
   {
      printf("Unknown server!!! (%s)",ICQServer);
      closesocket(conn);
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }

   SOCKADDR_IN
     sockAddr;

   sockAddr.sin_family=AF_INET;
   sockAddr.sin_port=htons(80);
   sockAddr.sin_addr.s_addr=*((unsigned long*)hp->h_addr);

   if(connect(conn,(PSOCKADDR)&sockAddr,sizeof(sockAddr)))
   {
      printf("Can't connect to %s!!!",ICQServer);
      closesocket(conn);
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }

   char
     PostData[0x0ffff],
     tmpBuff[10];

   #if defined(SEND_BY_ICQ_COM)
     PostData="from=P_Igor&fromemail=inozhenko@yahoo.com&body=Test+from+my+programm&to=93580519&submit=Send+Message";
     itoa(strlen(PostData),tmpBuff,10);
     *Client='\x0';
     strcat(Client,"POST /scripts/WWPMsg.dll HTTP/1.0\r\n");
     strcat(Client,"referer: http://");
     strcat(Client,ICQServer);
     strcat(Client,"/93580519\r\n");
     strcat(Client,"content-type: application/x-www-form-urlencoded\r\n");
     strcat(Client,"content-length: ");
     strcat(Client,tmpBuff);
     strcat(Client,"\r\n");
     strcat(Client,"host: ");
     strcat(Client,ICQServer);
     strcat(Client,"\r\n");
     strcat(Client,"Accept: */*\r\n");
     strcat(Client,"Accept-Encoding: gzip, deflate\r\n");
     strcat(Client,"Connection: Keep-Alive\r\n");
     strcat(Client,"User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;)\r\n\r\n");
     strcat(Client,PostData);
   #elif defined(SEND_BY_MIRANDA_ORG_UA)
     //PostData="uin=170471120&content=TestFromP_IgorByBorlandCPlusPlusBuilder"; // VBondarenko
     //PostData="uin=93580519&content=TestFromP_IgorByBorlandCPlusPlusBuilder"; // Ola
     //strcpy(PostData,"uin=170471120&content=TestFromP_IgorByBorlandCPlusPlusBuilder");
     strcpy(PostData,"uin=169792846&content=TestFromP_IgorByBorlandCPlusPlusBuilder");
     strcat(PostData,Server);

     itoa(strlen(PostData),tmpBuff,10);
     *Client='\x0';
     strcat(Client,"POST http://miranda.org.ua/index.php?do=send_icq HTTP/1.1\r\n");
     strcat(Client,"Host: ");
     strcat(Client,ICQServer);
     strcat(Client,"\r\n");
     strcat(Client,"User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.7.13) Gecko/20060414\r\n");
     strcat(Client,"Accept: text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5\r\n");
     strcat(Client,"Accept-Language: en-us,en;q=0.5\r\n");
     strcat(Client,"Accept-Encoding: gzip,deflate\r\n");
     strcat(Client,"Accept-Charset: windows-1251,utf-8;q=0.7,*;q=0.7\r\n");
     strcat(Client,"Keep-Alive: 300\r\n");
     strcat(Client,"Proxy-Connection: keep-alive\r\n");
     strcat(Client,"Referer: http://miranda.org.ua/index.php?do=send_icq\r\n");
     strcat(Client,"Content-Type: application/x-www-form-urlencoded\r\n");
     strcat(Client,"Content-Length: ");
     strcat(Client,tmpBuff);
     strcat(Client,"\r\n");
     strcat(Client,"\r\n");
     strcat(Client,PostData);
   #else
     PostData="from=P_Igor&fromemail=inozhenko@yahoo.com&fromicq=169792846&body=Test+from+my+programm&to=93580519&send=";
     itoa(strlen(PostData),tmpBuff,10);
     *Client='\x0';
     strcat(Client,"post http://wwp.icq.com/scripts/wwpmsg.dll http/2.0\r\n");
     strcat(Client,"referer: http://");
     strcat(Client,ICQServer);
     strcat(Client,"\r\n");
     strcat(Client,"user-agent: mozilla/4.06 (win95; i)\r\n");
     strcat(Client,"connection: keep-alive\r\n");
     strcat(Client,"host: wwp.mirabilis.com:80\r\n");
     strcat(Client,"content-type: application/x-www-form-urlencoded\r\n");
     strcat(Client,"content-length: ");
     strcat(Client,tmpBuff);
     strcat(Client,"\r\n");
     strcat(Client,"accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*\r\n\r\n");
     strcat(Client,PostData);
   #endif
   if(send(conn,Client,strlen(Client),0)==SOCKET_ERROR)
   {
      printf("send error!!! (WSAGetLastError()=%d)",WSAGetLastError());
      closesocket(conn);
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }

   /*
   setmem(Server,ServerSize,'\x0');
   if(recv(conn,Server,ServerSize,0)==SOCKET_ERROR)
   {
      printf("recv error!!! (WSAGetLastError()=%d)",WSAGetLastError());
      closesocket(conn);
      delete []Server;
      delete []Client;
      WSACleanup();
      return(0);
   }
   */

   closesocket(conn);
   delete []Server;
   delete []Client;
   WSACleanup();

   return(0);
}
//---------------------------------------------------------------------------

int ReplyCode(char *Reply)
{
   int
     Code=0,
     len;

   if(!(len=strlen(Reply)))
     return(Code);

   char
     *CodeStr=0;

   unsigned int
     Size=0x0ffff;

   while(!CodeStr&&Size)
   {
      CodeStr=new char [Size];
      if(!CodeStr)
        Size>>=1;
   }
   if(!CodeStr&&!Size)
   {
      printf("Insufficient memory!!!");
      return(Code);
   }
   setmem(CodeStr,Size,'\x0');

   for(int i=0; i<len && i<Size && isdigit(*(Reply+i)); ++i)
      *(CodeStr+i)=*(Reply+i);
   Code=atoi(CodeStr);

   delete []CodeStr;

   return(Code);
}
//---------------------------------------------------------------------------

char *HtmlEncode(unsigned char *inp_str, char *out_str)
{
   *out_str='\x0';

   int
     len=strlen(inp_str),
     ii,
     j=0;

   char
     buff[4];

   for(int i=0; i<len; ++i)
   {
      if((*(inp_str+i)>=48 && *(inp_str+i)<=57) // '0'..'9'
        || (*(inp_str+i)>=65 && *(inp_str+i)<=90) // 'A'..'Z'
        || (*(inp_str+i)>=97 && *(inp_str+i)<=122) // 'a'..'z'
        || *(inp_str+i)==42 // *
        || *(inp_str+i)==45 // -
        || *(inp_str+i)==46 // .
        || *(inp_str+i)==95) // _
      {
         *(out_str+j++)=*(inp_str+i);
         continue;
      }

      if(*(inp_str+i)==32)
      {
         *(out_str+j++)='+';
         continue;
      }

      sprintf(buff,"%%%02X",*(inp_str+i));
      for(ii=0; ii<3; ++ii)
         *(out_str+j++)=*(buff+ii);
   }

   *(out_str+j)='\x0';

   return(out_str);
}
//---------------------------------------------------------------------------
