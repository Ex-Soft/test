#ifdef WIN32
#define CLOSE closesocket
#else
#define CLOSE close
#endif

int main(int argc, char* argv[])
{
#ifdef WIN32
   {
      WORD wVersionRequested;
      WSADATA wsaData;
      int err;
      
      wVersionRequested = MAKEWORD( 2, 2 );
      
      err = WSAStartup( wVersionRequested, &wsaData );
      if ( err != 0 ) {
         /* Tell the user that we could not find a usable */
         /* WinSock DLL.                                  */
         return -1;
      }
   }
#endif
   {
      SOCKET s1 = socket( PF_INET, SOCK_DGRAM, 0 );
      SOCKET s2 = socket( PF_INET, SOCK_DGRAM, 0 );
      
      struct sockaddr_in sin;
      sin.sin_family = AF_INET;
      sin.sin_port = htons(4000);
      sin.sin_addr.s_addr = inet_addr("127.0.0.1");
      
      if( bind(s1, (struct sockaddr *)&sin, sizeof(sin))==0 )
         std::cout<<"Success "<<__LINE__<<std::endl;
      if( bind(s2, (struct sockaddr *)&sin, sizeof(sin))==0 )
         std::cout<<"Success "<<__LINE__<<std::endl;
      CLOSE(s1);
      CLOSE(s2);
   }

   {
      SOCKET s1 = socket( PF_INET, SOCK_STREAM, 0 );
      SOCKET s2 = socket( PF_INET, SOCK_STREAM, 0 );
      
      struct sockaddr_in sin;
      sin.sin_family = AF_INET;
      sin.sin_port = htons(4000);
      sin.sin_addr.s_addr = inet_addr("127.0.0.1");
      
      if( bind(s1, (struct sockaddr *)&sin, sizeof(sin))==0 )
         std::cout<<"Success "<<__LINE__<<std::endl;
      if( bind(s2, (struct sockaddr *)&sin, sizeof(sin))==0 )
         std::cout<<"Success "<<__LINE__<<std::endl;
      CLOSE(s1);
      CLOSE(s2);
   }
   return 0;
} 