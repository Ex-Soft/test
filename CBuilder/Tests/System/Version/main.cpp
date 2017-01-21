//---------------------------------------------------------------------------

#include <vcl.h>
#include <winver.h>
#pragma hdrstop

//---------------------------------------------------------------------------
wchar_t
  name_VS[]=L"VS_VERSION_INFO";

struct VS_VERSIONINFO {
    WORD  wLength;
    WORD  wValueLength;
    WORD  wType;
    WCHAR szKey[sizeof(name_VS)/2];
    WORD  Padding1[];
    VS_FIXEDFILEINFO Value;
    WORD  Padding2[];
    WORD  Children[];
};

struct TRANSLATE
{
   WORD wLanguage;
   WORD wCodePage;
};

#pragma argsused
int main(int argc, char* argv[])
{
   char
     *version=0,
     *buff=0,
     *ExeName="fbembed.dll";

   DWORD
     unused_param,
     buff_size;

   unsigned int
     len;

   unsigned short
     *lang;

   AnsiString
     FileDescription,
     FileVersion,
     CompanyName;

   TRANSLATE
     *lpTranslate=0;

   if(buff_size=GetFileVersionInfoSize(ExeName,&unused_param))
   {
      buff=new char [buff_size];
      if(buff && GetFileVersionInfo(ExeName,0,buff_size,buff))
      {
         VS_VERSIONINFO
           *pVerInfo=(VS_VERSIONINFO *)buff;

         WORD
           tmpWord;

         tmpWord=HIWORD(pVerInfo->Value.dwFileVersionMS);
         tmpWord=LOWORD(pVerInfo->Value.dwFileVersionMS);
         tmpWord=HIWORD(pVerInfo->Value.dwFileVersionLS);
         tmpWord=LOWORD(pVerInfo->Value.dwFileVersionLS);

         if(VerQueryValue(buff,"\\VarFileInfo\\Translation",(void **)&lang,&len))
         {
            lpTranslate=new TRANSLATE;
            memcpy(lpTranslate,lang,sizeof(TRANSLATE));
            if(lpTranslate)
              delete lpTranslate;

            if(VerQueryValue(buff,(AnsiString("\\StringFileInfo\\")+IntToHex(lang[0],4)+IntToHex(lang[1],4)+"\\FileDescription").c_str(),(void **)&version,&len))
              FileDescription = version ? version : "UNKNOWN";
            if(VerQueryValue(buff,(AnsiString("\\StringFileInfo\\")+IntToHex(lang[0],4)+IntToHex(lang[1],4)+"\\FileVersion").c_str(),(void **)&version,&len))
              FileVersion = version ? version : "UNKNOWN";
            if(VerQueryValue(buff,(AnsiString("\\StringFileInfo\\")+IntToHex(lang[0],4)+IntToHex(lang[1],4)+"\\CompanyName").c_str(),(void **)&version,&len))
              CompanyName = version ? version : "UNKNOWN";

            if(HIWORD(pVerInfo->Value.dwFileVersionMS)<6)
            {
               pVerInfo->Value.dwFileVersionMS+=5<<16;
               tmpWord=HIWORD(pVerInfo->Value.dwFileVersionMS);
               tmpWord=LOWORD(pVerInfo->Value.dwFileVersionMS);

               HANDLE
                 hResource;

               if(hResource=BeginUpdateResource(ExeName,0))
               {
                  if(UpdateResource(hResource,RT_VERSION,MAKEINTRESOURCE(VS_VERSION_INFO),lang[0],buff,buff_size))
                  {
                     EndUpdateResource(hResource,0);
                  }
               }
            }
         }
      }
   }

   if(buff)
     delete []buff;

   return(0);
}
//---------------------------------------------------------------------------
