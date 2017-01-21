//---------------------------------------------------------------------------

#include <vcl.h>
#include <dir.h>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   AnsiString
     FindPath = argc>1 ? AnsiString(*(argv+1)) : ExtractFilePath(*argv);

   if(FindPath.IsEmpty())
     return 0;

   FindPath=IncludeTrailingPathDelimiter(FindPath)+"*.*";

   ffblk
     ffblk;

   int
     done;

   done=findfirst(FindPath.c_str(),&ffblk,0);
   while(!done)
   {
      done=findnext(&ffblk);
   }

   TSearchRec
     sr;

   done=FindFirst(FindPath,0,sr);
   while(!done)
   {
      done=FindNext(sr);
   }
   FindClose(sr);

   AnsiString
     Mess;

   FindPath=IncludeTrailingPathDelimiter(*(argv+1))+"\x0d";
   done=FileExists(FindPath);
   if(!DeleteFile(FindPath))
   {
      done=GetLastError();
      Mess=SysErrorMessage(done);
   }

   SHFILEOPSTRUCT
     SHFileOpStruct;

   char
     Buff[256];

   setmem(Buff,sizeof(Buff),'\x0');
   strcpy(Buff,FindPath.c_str());
   setmem(&SHFileOpStruct,sizeof(SHFileOpStruct),'\x0');
   SHFileOpStruct.wFunc=FO_DELETE;
   SHFileOpStruct.pFrom=Buff;
   if(done=SHFileOperation(&SHFileOpStruct))
   {
      done=GetLastError();
      Mess=SysErrorMessage(done);
   }

   return 0;
}
//---------------------------------------------------------------------------
