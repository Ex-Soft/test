#include "stdafx.h"
#include "GetConnectionString.h"

void GetConnectionString(char *aIniFileName, char *aConnectionString, DWORD aConnectionStringSize)
{
	char
		*Buff=0;

	DWORD
		BuffSize=0x0ffff;

	while(!Buff && BuffSize)
	{
		try
		{
		Buff=new char [BuffSize];
		}
		catch(std::bad_alloc)
		{
			BuffSize>>=1;
		}
	}
	if(!Buff && !BuffSize)
	{
		return;
	}

	GetModuleFileName(0,Buff,BuffSize);

	char
		*ptr;

	if(ptr=strrchr(Buff,'\\'))
	{
		*(ptr+1)='\x0';
		strcat(Buff,aIniFileName);
	}

	GetPrivateProfileString("main","ConnectionString",0,aConnectionString,aConnectionStringSize,Buff);

	delete []Buff;
}
