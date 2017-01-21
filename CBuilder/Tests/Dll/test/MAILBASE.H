//***************************************************************************
//

#ifndef MailBase_H
#define MailBase_H

#ifdef DLL
#define _dll_ _export
#else
#define _dll_ _import
#endif

//***************************************************************************

class TUSIVersion
{
public :

unsigned char
  major, minor;

TUSIVersion ( int aMajor = 1, int aMinor = 0 ) :
  major(aMajor), minor(aMinor)
{ }
int Major ( void ) { return (int)major; }
int Minor ( void ) { return (int)minor; }
};

//***************************************************************************

enum { MaxFiles = 256 };

//***************************************************************************

class TUSIFile
{
public :

AnsiString
  Name;
long
  Size;
unsigned long
  CRC;
long
  CRCpos;

TUSIFile ( ) :
  Size(0), CRC(0), CRCpos(0)
{
}
};

//***************************************************************************

class TUSIEnvelope
{
public :

TUSIVersion
  Version;
char
  SystemName [ 17 ];
char
  Type;
char
  SendBox [ 9 ],
  SendComp [ 17 ];
TDateTime
  TimePack, TimeSend;
char
  RecvBox [ 9 ],
  RecvComp [ 17 ];
TDateTime
  TimeRecv, TimeOpen;

short
  Files;

TUSIFile
  File [ MaxFiles ];

TUSIEnvelope ( ) :
  Type(' '), Files(0)
{
  SystemName[0] = '\0';
  SendBox[0] = '\0';
  SendComp[0] = '\0';
  TimePack = TDateTime(2001, 1, 1);
  TimeSend = TDateTime(2001, 1, 1);
  RecvBox[0] = '\0';
  RecvComp[0] = '\0';
  TimeRecv = TDateTime(2001, 1, 1);
  TimeOpen = TDateTime(2001, 1, 1);
}
TUSIEnvelope ( char * aSystemName, char aType, char * aSendBox, char * aSendComp, char * aRecvBox, char * aRecvComp, TUSIVersion aVersion = TUSIVersion() ) :
  Type(aType), Version(aVersion), Files(0)
{
  strncpy(SystemName, aSystemName, 16);
  strncpy(SendBox, aSendBox, 8);
  strncpy(SendComp, aSendComp, 16);
  TimePack = Now();
  TimeSend = TDateTime(2001, 1, 1);
  strncpy(RecvBox, aRecvBox, 8);
  strncpy(RecvComp, aRecvComp, 16);
  TimeRecv = TDateTime(2001, 1, 1);
  TimeOpen = TDateTime(2001, 1, 1);
}
};

extern TUSIVersion _dll_ __fastcall LibraryVersion ( void );

extern unsigned long _dll_ __fastcall CRC ( TStream * Stream, int Count = 0 );

extern void _dll_ __fastcall PackEnvelope ( AnsiString PathMailOut, int USBNo, TUSIEnvelope & Env, AnsiString PathName );
extern void _dll_ __fastcall TestEnvelope ( AnsiString FileName );
extern void _dll_ __fastcall ViewEnvelope ( AnsiString FileName, TUSIEnvelope & Env );
extern void _dll_ __fastcall OpenEnvelope ( AnsiString FileName, TUSIEnvelope & Env, AnsiString PathBuff );

// old TMC-style

extern void _dll_ __fastcall ViewEnvelope_TMC ( AnsiString FileName, TUSIEnvelope & Env );
extern void _dll_ __fastcall OpenEnvelope_TMC ( AnsiString FileName, TUSIEnvelope & Env, AnsiString PathBuff );

#endif

