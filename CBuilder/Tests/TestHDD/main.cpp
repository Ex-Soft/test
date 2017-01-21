//---------------------------------------------------------------------------

#include <vcl.h>
#include <winioctl.h>
#include <stdio.h>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma pack( push, 1 )
struct PartitionTableEntry
{
   byte BootIndicator;
   byte StartingHead;
   WORD StartingCylAndSect;
   byte SystemIndicator;
   byte EndingHead;
   WORD EndingCylAndSect;
   DWORD StartingSector;
   DWORD NumberOfSects;
};
#pragma pack( pop ) ;

void ParseCylAndSec(WORD CylAndSect, WORD &Cyl, byte &Sec);

#pragma argsused
int main(int argc, char* argv[])
{
   if(argc<2)
   {
      printf("Usage: TestHDD <PhysicalDriveNo>\n\n");
      return 0;
   }

   HANDLE
     hDevice;

   int
     ErrNo;

   AnsiString
     Message="\\\\.\\PhysicalDrive"+IntToStr(StrToIntDef(*(argv+1),0));

   if((hDevice=CreateFile(Message.c_str(),GENERIC_READ,FILE_SHARE_READ|FILE_SHARE_WRITE,0,OPEN_EXISTING,0,0))==INVALID_HANDLE_VALUE)
   {
      Message="CreateFile() error: "+IntToStr(ErrNo=GetLastError())+"\nMessage: "+SysErrorMessage(ErrNo);
      MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
      return -1;
   }

   DISK_GEOMETRY
     pdg;

   DWORD
     junk;

   if(DeviceIoControl(hDevice,IOCTL_DISK_GET_DRIVE_GEOMETRY,NULL,0,&pdg,sizeof(pdg),&junk,(LPOVERLAPPED)NULL))
   {
      printf("Cylinders = %I64d\n", pdg.Cylinders);
      printf("Tracks/cylinder = %ld\n", (ULONG) pdg.TracksPerCylinder);
      printf("Sectors/track = %ld\n", (ULONG) pdg.SectorsPerTrack);
      printf("Bytes/sector = %ld\n", (ULONG) pdg.BytesPerSector);

      ULONGLONG
        DiskSize = pdg.Cylinders.QuadPart * (ULONG)pdg.TracksPerCylinder * (ULONG)pdg.SectorsPerTrack * (ULONG)pdg.BytesPerSector;

      printf("Disk size = %I64d (Bytes) = %I64d (Gb)\n", DiskSize, DiskSize / (1024 * 1024 * 1024));
      printf("\n");

      PARTITION_INFORMATION_EX
        pie;

      DWORD
        BytesReturned;

      if(DeviceIoControl(hDevice,IOCTL_DISK_GET_PARTITION_INFO_EX,NULL,0,&pie,sizeof(pie),&BytesReturned,(LPOVERLAPPED)NULL))
      {
      }
      else
      {
         Message="DeviceIoControl() error: "+IntToStr(ErrNo=GetLastError())+"\nMessage: "+SysErrorMessage(ErrNo);
         MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
      }

      const int
        MaxPartittionCount=4;

      PartitionTableEntry
        pte[MaxPartittionCount];

      LONG
        DistanceToMoveLow=0,
        DistanceToMoveHigh=0;

      if(SetFilePointer(hDevice,DistanceToMoveLow,&DistanceToMoveHigh,FILE_BEGIN)==DistanceToMoveLow)
      {
         char
           Buff[512];

         DWORD
           NumberOfBytesRead;

         if(ReadFile(hDevice,Buff,sizeof(Buff),&NumberOfBytesRead,0))
         {
            setmem(pte,sizeof(pte),'\x0');
            memcpy(pte,Buff+0x1be,sizeof(pte));

            byte
              SecS,
              SecE;

            WORD
              CylS,
              CylE;

            printf("Status  Hd   sec/cyl   Typ  Hd   sec/cyl    Start Sec   Num Sec      LBA\n");
            printf("====== ==== ========== === ==== ========== ========== ========== ==========\n");
            for(int i=0; i<MaxPartittionCount; ++i)
            {
               ParseCylAndSec(pte[i].StartingCylAndSect,CylS,SecS);
               ParseCylAndSec(pte[i].EndingCylAndSect,CylE,SecE);

               printf("%6x %4i %4i/%5i  %02x %4i %4i/%5i %10u %10u %10u\n",
                      pte[i].BootIndicator,
                      pte[i].StartingHead,
                      SecS,
                      CylS,
                      pte[i].SystemIndicator,
                      pte[i].EndingHead,
                      SecE,
                      CylE,
                      pte[i].StartingSector,
                      pte[i].NumberOfSects,
                      (CylS*(ULONG)pdg.TracksPerCylinder+(ULONG)pte[i].StartingHead)*(ULONG)pdg.SectorsPerTrack+SecS-1);
            }
         }
         else
         {
            ErrNo=GetLastError();
            Message="ReadFile() error: "+IntToStr(ErrNo)+"\nMessage: "+SysErrorMessage(ErrNo);
            MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
         }
      }
      else
      {
         Message="SetFilePointer() error: "+IntToStr(ErrNo=GetLastError())+"\nMessage: "+SysErrorMessage(ErrNo);
         MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
      }
   }
   else
   {
      Message="DeviceIoControl() error: "+IntToStr(ErrNo=GetLastError())+"\nMessage: "+SysErrorMessage(ErrNo);
      MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
   }

   if(!CloseHandle(hDevice))
   {
      Message="CloseHandle() error: "+IntToStr(ErrNo=GetLastError())+"\nMessage: "+SysErrorMessage(ErrNo);
      MessageBox(0,Message.c_str(),"Error",MB_OK|MB_ICONERROR);
      return -1;
   }

   return 0;
}
//---------------------------------------------------------------------------

void ParseCylAndSec(WORD CylAndSect, WORD &Cyl, byte &Sec)
{
   Sec=CylAndSect&0xff;
   Cyl=Sec&0xc0;
   Cyl<<=2;
   Cyl+=(CylAndSect&0xff00)>>8;
   Sec&=0x3f;
}
//---------------------------------------------------------------------------
