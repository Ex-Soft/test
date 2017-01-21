//---------------------------------------------------------------------------

#include <vcl.h>
#include <Math.hpp>
#include <DateUtils.hpp>
#include <limits>
#include <dir.h>
#include <stdio.h>
#include <fstream>
#include <iostream>
//#define VCL_IOSTREAM
#include <sysset.h>
#include <StrUtils.hpp>
#include <IniFiles.hpp>
#include <process.h>
#pragma hdrstop

//#pragma message("Test")
//Project->Options (Shift+Ctrl+F11)->Compiler->Show general messages

#include "main.h"
#include "test.hpp"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#if !defined(LOCALIZE_ERROR)
  #define LOCALIZE_ERROR ExtractFileName(__FILE__)+"("+__LINE__+"): "
#endif

#define TEST_FIND_FIRST
//#define TEST_COPY_DIRECTORY
//#define TEST_ALLOCATE
//#define TEST_FLOAT_TO_FROM_FILE
//#define TEST_ANSISTRING_ARRAY
//#define TEST_NEW_N_ARRAY
//#define TEST_DATE_BETWEEN
//#define TEST_LITERAL_CONST
//#define TEST_SIZEOF
//#define TEST_INI
//#define TEST_TIME
//#define TEST_ANSI_STRING
//#define TEST_TDATETIME
//#define RECYCLE_BIN
//#define TEST_LIMIT
//#define TEST_VARIANT
//#define TEST_VARIANT_ARRAY
//#define TEST_IS_XXX
//#define GET_NUMBER_FORMAT
//#define TEST_ROUND
//#define TEST_EXTRACT_FROM_FILE
//#define TEST_KEYBOARD
//#define TEST_TO_OTHERS_APP
//#define TEST_CAST

#if defined(TEST_TIME)
  #include <time.h>
#endif

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   int
     tmpInt=(int)HInstance;

   long
     tmpLong=(long)MainInstance;

   DWORD
     tmpDWORD=GetCurrentProcessId();

   unsigned
     tmpUnsigned=getpid();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";

   long
     btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);

   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);

   ForReallyAnyTestBitBtn->Hint="Line #1\nLine #2\nLine #3";
}
//---------------------------------------------------------------------------

void function1(int* first,int val)
{
 *first=val+(*first++);
}

void function2(int* first,int val)
{
 *++first=val+(*first);
}

#if defined(TEST_NEW_N_ARRAY)

#define TEST_NEW_N_ARRAY_MAX 3

void _Allocate_(int ***ar)
{
   *ar=new int*[TEST_NEW_N_ARRAY_MAX];
   for(int i=0; i<TEST_NEW_N_ARRAY_MAX; ++i)
      (*ar)[i]=new int[TEST_NEW_N_ARRAY_MAX];
}

void _Allocate_(int **&ar)
{
   ar=new int*[TEST_NEW_N_ARRAY_MAX];
   for(int i=0; i<TEST_NEW_N_ARRAY_MAX; ++i)
      ar[i]=new int[TEST_NEW_N_ARRAY_MAX];
}

void _De_Allocate_(int **ar)
{
   for(int i=0; i<TEST_NEW_N_ARRAY_MAX; ++i)
      delete[] ar[i];
   delete[] ar;
}
#endif

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   int
     tmpInt;

   AnsiString
     tmpAnsiString;

#if defined(TEST_FIND_FIRST)
TSearchRec
  sr;

int
  done=FindFirst("D:\\soft.src\\c#\\test\\Services\\TestService\\*.*",faDirectory|faReadOnly|faHidden|faSysFile|faArchive,sr);

while(!done)
{
   if((sr.Attr & faDirectory) && (sr.Name=="." || sr.Name==".."))
   {
      done=FindNext(sr);
      continue;
   }

   tmpAnsiString=ExtractFileExt(sr.Name);
   done=FindNext(sr);
}
#endif

#if defined(TEST_COPY_DIRECTORY)
SHFILEOPSTRUCT
  SHFileOpStruct;

char
  src[MAX_PATH],
  dest[MAX_PATH];

setmem(&SHFileOpStruct,sizeof(SHFileOpStruct),'\x0');
setmem(src,sizeof(src),'\x0');
setmem(dest,sizeof(dest),'\x0');

strcpy(src,"e:\\temp\\src");
strcpy(dest,"e:\\temp\\dest");

if(DirectoryExists(dest))
{
   SHFileOpStruct.wFunc=FO_DELETE;
   SHFileOpStruct.pFrom=dest;
   if(SHFileOperation(&SHFileOpStruct))
     ShowMessage("Error");
}

SHFileOpStruct.wFunc=FO_COPY;
SHFileOpStruct.pFrom=src;
SHFileOpStruct.pTo=dest;
if(SHFileOperation(&SHFileOpStruct))
  ShowMessage("Error");
#endif

#if defined(TEST_ALLOCATE) || defined(TEST_FLOAT_TO_FROM_FILE)
   FILE
     *f_ptr=0;
#endif

#if defined(TEST_ALLOCATE)
   char
     PartLoIn,
     PartLoOut=0xc1,
     PartHiIn,
     PartHiOut=0xff;

   WORD
     tmpWord;

   #pragma pack( push, 1 )
   union UnionWord
   {
      char
        Lo;
        
      char
        Hi;

      WORD
        W;
   } tmpUnionWord;
   #pragma pack( pop ) ;

   tmpUnionWord.Lo='\xc1';
   tmpUnionWord.Hi='\xff';

   tmpInt=sizeof(tmpUnionWord);
   tmpInt=sizeof(UnionWord);

   setmem(&tmpUnionWord,sizeof(tmpUnionWord),'\x0');

   if(f_ptr=fopen("char_by_part.bin","wb"))
   {
      tmpInt=fwrite(&PartLoOut,sizeof(char),1,f_ptr);
      tmpInt=fwrite(&PartHiOut,sizeof(char),1,f_ptr);
      fclose(f_ptr);
   }

   if(f_ptr=fopen("char_by_part.bin","rb"))
   {
      tmpInt=fread(&tmpWord,sizeof(WORD),1,f_ptr);
      fclose(f_ptr);
   }

   PartLoIn=char(tmpWord&0xff);
   PartHiIn=char((tmpWord&0xff00)>>8);
   tmpWord=PartLoIn&0xc0;
   tmpWord<<=2;
   tmpWord|=(unsigned char)PartHiIn;
   PartLoIn&=0x3f;
   tmpAnsiString="Cyl="+IntToStr(tmpWord)+" Sec="+IntToStr(PartLoIn);

   if(f_ptr=fopen("char_by_part.bin","rb"))
   {
      tmpInt=fread(&tmpUnionWord,sizeof(tmpUnionWord),1,f_ptr);
      fclose(f_ptr);
   }

   PartLoIn=tmpUnionWord.Lo;
   PartHiIn=tmpUnionWord.Hi;
   tmpWord=PartLoIn&0xc0;
   tmpWord<<=2;
   tmpWord|=(unsigned char)PartHiIn;
   PartLoIn&=0x3f;
   tmpAnsiString="Cyl="+IntToStr(tmpWord)+" Sec="+IntToStr(PartLoIn);
#endif

#if defined(TEST_FLOAT_TO_FROM_FILE)
   const int
     len=5;

   float
     *ArrayFloat=new float[len];

   for(int i=0; i<len; ++i)
      *(ArrayFloat+i)=i+1;

   if(f_ptr=fopen("float_by_part.bin","wb"))
   {
      for(int i=0; i<len; ++i)
         tmpInt=fwrite(ArrayFloat+i,sizeof(float),1,f_ptr);

      fclose(f_ptr);
   }

   if(f_ptr=fopen("float_by_entire.bin","wb"))
   {
      tmpInt=fwrite(ArrayFloat,sizeof(float),len,f_ptr);
      fclose(f_ptr);
   }

   for(int i=0; i<len; ++i)
      *(ArrayFloat+i)=0;

   if(f_ptr=fopen("float_by_part.bin","rb"))
   {
      for(int i=0; i<len; ++i)
         tmpInt=fread(ArrayFloat+i,sizeof(float),1,f_ptr);

      fclose(f_ptr);
   }

   for(int i=0; i<len; ++i)
      *(ArrayFloat+i)=0;

   if(f_ptr=fopen("float_by_entire.bin","rb"))
   {
      tmpInt=fread(ArrayFloat,sizeof(float),len,f_ptr);
      fclose(f_ptr);
   }

   delete []ArrayFloat;
#endif

#if defined(TEST_ANSISTRING_ARRAY)
   AnsiString
     txt_data[8][6][100];

   for(int iii=0; iii<8; ++iii)
      for(int jjj=0; jjj<6; ++jjj)
         for(int kkk=0; kkk<100; ++kkk)
            txt_data[iii][jjj][kkk]="["+IntToStr(iii)+"]["+IntToStr(jjj)+"]["+IntToStr(kkk)+"]";

   tmpAnsiString="";
   for(int iii=0; iii<8; ++iii)
      for(int jjj=0; jjj<6; ++jjj)
         for(int kkk=0; kkk<100; ++kkk)
            tmpAnsiString+=txt_data[iii][jjj][kkk];
#endif

#if defined(TEST_NEW_N_ARRAY)
   int
     **arr=0;

   arr=new int*[TEST_NEW_N_ARRAY_MAX];
   for(int i_arr=0; i_arr<TEST_NEW_N_ARRAY_MAX; ++i_arr)
      arr[i_arr]=new int[TEST_NEW_N_ARRAY_MAX];

   for(int i_arr=0; i_arr<TEST_NEW_N_ARRAY_MAX; ++i_arr)
      for(int j_arr=0; j_arr<TEST_NEW_N_ARRAY_MAX; ++j_arr)
         arr[i_arr][j_arr]=i_arr+j_arr;

   if(arr)
   {
      _De_Allocate_(arr);
      arr=0;
   }

   _Allocate_(&arr);
   for(int i_arr=0; i_arr<TEST_NEW_N_ARRAY_MAX; ++i_arr)
      for(int j_arr=0; j_arr<TEST_NEW_N_ARRAY_MAX; ++j_arr)
         arr[i_arr][j_arr]=i_arr+j_arr;
   if(arr)
   {
      _De_Allocate_(arr);
      arr=0;
   }

   _Allocate_(arr);
   for(int i_arr=0; i_arr<TEST_NEW_N_ARRAY_MAX; ++i_arr)
      for(int j_arr=0; j_arr<TEST_NEW_N_ARRAY_MAX; ++j_arr)
         arr[i_arr][j_arr]=i_arr+j_arr;
   if(arr)
   {
      _De_Allocate_(arr);
      arr=0;
   }
#endif

#if defined(TEST_SIZEOF)
   byte
     testByteArray[]={0x0,0x1,0x2,0x3,0x4,0x5};

   tmpInt=sizeof(testByteArray);
   tmpAnsiString=IntToStr(tmpInt);
#endif

#if defined(TEST_INI)
   AnsiString
     IniFileName=ExtractFilePath(Application->ExeName)+"ini.ini";

   TIniFile
     *IniFile=new TIniFile(IniFileName);

   IniFile->WriteString("main","LastUser","blah-blah-blah");

   delete IniFile;

   WritePrivateProfileString("main","LastUser2","blah-blah-blah",IniFileName.c_str());
#endif

#if defined(TEST_TIME)
   time_t
     first,
     second;

   double
     diff;

   first=time(0);
   Sleep(2000); // delay(2000);
   second=time(0);
   diff=difftime(second,first); // sec

   clock_t
     start,
     stop;

   start=clock();
   Sleep(2000); // delay(2000);
   stop=clock();
   diff=stop-start;
   diff=(stop-start)/CLK_TCK; // sec

   // M$
   DWORD
     GTCStart,
     GTCStop,
     GTCDiff;

   GTCStart=GetTickCount();
   Sleep(2000);
   GTCStop=GetTickCount();
   GTCDiff=GTCStop-GTCStart; // ms
#endif

#if defined(TEST_ANSI_STRING)
   AnsiString
     TestAnsiStringI,
     TestAnsiStringII,
     SubStr="cc";

   TestAnsiStringI="AaBbCcDdEeFf";
   TestAnsiStringI.LowerCase();
   TestAnsiStringII=TestAnsiStringI;
   if(AnsiContainsStr(TestAnsiStringI,"AA"))
     TestAnsiStringII=TestAnsiStringI;
   if(AnsiContainsText(TestAnsiStringI,"AA"))
   {
     int
       Pos;

     if(Pos=TestAnsiStringI.LowerCase().Pos(SubStr))
       TestAnsiStringI.Insert("Zz",Pos+SubStr.Length());
     TestAnsiStringII=TestAnsiStringI;
   }
#endif

#if defined(TEST_VARIANT_ARRAY)
   Variant
     tmpOpenArray1(OPENARRAY(int,(1,8)),varInteger),
     tmpOpenArray2(OPENARRAY(int,(1,8,11,18)),varInteger),
     tmpOpenArray3(OPENARRAY(int,(1,8,11,18,21,28)),varInteger);

   int
     _cnt_,
     _i_,
     _j_;

   if(tmpOpenArray1.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpOpenArray1);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpOpenArray1,i);
         _j_=VarArrayHighBound(tmpOpenArray1,i);
      }
   }
   //tmpOpenArray1.PutElement(0x0ffff,0); // EVariantBadIndexError: 'Variant array index out of bounds'
   tmpOpenArray1.PutElement(0x0ffff,1);
   tmpOpenArray1.PutElement(0x0eeee,8);
   //tmpOpenArray1.PutElement(0x0eeee,9); // EVariantBadIndexError: 'Variant array index out of bounds'

   if(tmpOpenArray2.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpOpenArray2);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpOpenArray2,i);
         _j_=VarArrayHighBound(tmpOpenArray2,i);
      }
   }
   tmpOpenArray2.PutElement(0x0ffff,1,11);
   tmpOpenArray2.PutElement(0x0eeee,8,18);

   if(tmpOpenArray3.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpOpenArray3);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpOpenArray3,i);
         _j_=VarArrayHighBound(tmpOpenArray3,i);
      }
   }
   tmpOpenArray3.PutElement(0x0ffff,1,11,21);
   tmpOpenArray3.PutElement(0x0eeee,8,18,28);

   int
     Bounds1[]={0,4},
     Bounds2[]={0,4,20,24},
     Bounds3[]={0,4,20,24,40,44};

   Variant
     tmpVarArrayCreate1=VarArrayCreate(Bounds1,sizeof(Bounds1)/sizeof(int)-1,varVariant),
     tmpVarArrayCreate2=VarArrayCreate(Bounds2,sizeof(Bounds2)/sizeof(Bounds2[0])-1,varVariant),
     tmpVarArrayCreate3=VarArrayCreate(Bounds3,ARRAYSIZE(Bounds3)-1,varVariant);

   if(tmpVarArrayCreate1.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpVarArrayCreate1);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpVarArrayCreate1,i);
         _j_=VarArrayHighBound(tmpVarArrayCreate1,i);
      }
   }
   tmpVarArrayCreate1.PutElement(0x0ffff,0);
   tmpVarArrayCreate1.PutElement(0x0eeee,4);

   if(tmpVarArrayCreate2.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpVarArrayCreate2);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpVarArrayCreate2,i);
         _j_=VarArrayHighBound(tmpVarArrayCreate2,i);
      }
   }
   tmpVarArrayCreate2.PutElement(0x0ffff,0,20);
   tmpVarArrayCreate2.PutElement(0x0eeee,4,24);

   if(tmpVarArrayCreate3.IsArray())
   {
      _cnt_=VarArrayDimCount(tmpVarArrayCreate3);
      for(int i=1; i<=_cnt_; ++i)
      {
         _i_=VarArrayLowBound(tmpVarArrayCreate3,i);
         _j_=VarArrayHighBound(tmpVarArrayCreate3,i);
      }
   }
   tmpVarArrayCreate3.PutElement(0x0ffff,0,20,40);
   tmpVarArrayCreate3.PutElement(0x0eeee,4,24,44);
#endif

#if defined(TEST_LITERAL_CONST)
   int
     tmpInt1=0xFFFFEFD6, //0x0FFFFEFE7,
     tmpInt2=(unsigned int)tmpInt1;

   long
     tmpLong1=0xFFFFEFD6L,
     tmpLong2=(unsigned long)tmpLong1;

   tmpLong2=sizeof(tmpLong1);

   short
     tmpShort=-10;

   tmpInt1=tmpShort;

   tmpShort=0x0fa;
   tmpInt1=tmpShort;

   tmpShort=0x0fffa;
   tmpInt1=tmpShort;

   __int64
     tmpInt64=0xFFFFEFD6L;

   if(tmpInt64>0)
     tmpInt64=0xFFFFFFFFFFFFEFD6L;

   tmpLong1=-1072896760;

   unsigned long
     tmpULong1=tmpLong1;

   tmpInt64=tmpULong1;
#endif

#if defined(TEST_DATE_BETWEEN)
   TDate
     d,
     dd;

   d=TDateTime(2005,1,1);

   dd=TDateTime(2005,1,2);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2005,1,31);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2005,2,1);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2005,12,31);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2006,3,1);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2007,3,1);
   ShowMessage(DaysBetween(dd,d));

   dd=TDateTime(2008,3,1);
   ShowMessage(DaysBetween(dd,d));

   dd=DateOf(Now());
   ShowMessage(dd.DateTimeString());
   ShowMessage(dd.DateString());
   ShowMessage(dd.TimeString());
   ShowMessage(DaysBetween(dd,d));
#endif

   struct A
   {
      typedef double value_type;
      static value_type fun(value_type x, value_type y){return x+y;}
   };

   char
     __buff__[1024];

   sprintf(__buff__,"result=%f",A::fun<33>(2.));

   strcpy(__buff__,"123 567");

   char
     *pos;

   pos=strchr(__buff__,'\x20');
   *(__buff__+int(pos-__buff__))='\x0';

   strcpy(__buff__,"!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¨¸¥´²³¯¿ªºÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ");

   AnsiString
     __a__="123456";

   ShowMessage(IntToStr(__a__.LastDelimiter("2")));
   ShowMessage(IntToStr(__a__.LastDelimiter("8")));

   char
     *buff;

   buff=GetCommandLine();

   int
     buffInt[5]={1,2,3,4,5},
     *ptr=buffInt;

   function1(ptr,100);
   function2(ptr,200);
   //return;
/*
   TDate
     d,
     dd;

   AnsiString
     tmpAnsiString=c;

   d=TDateTime(1700,1,31);
   tmpAnsiString+=d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(1800,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(1900,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(2100,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(1600,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(2000,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   d=TDateTime(2400,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy")+"="+BoolToStr(IsLeapYear(YearOf(d)),true);
   ShowMessage(tmpAnsiString);

   d=TDateTime(2005,1,31);
   tmpAnsiString+="\n"+d.FormatString("dd.mm.yyyy");
   for(int i=0; i<26; ++i)
   {
      dd=IncMonth(d,i);
      tmpAnsiString+="\n"+dd.FormatString("dd.mm.yyyy");
   }

   tmpAnsiString="";
   for(int i=0; i<26; ++i)
   {
      dd=IncMonth(d,-i);
      tmpAnsiString+="\n"+dd.FormatString("dd.mm.yyyy");
   }

   d=TDateTime(2005,1,1);
   dd=TDateTime(2005,12,31);
   tmpAnsiString=FloatToStr(dd.Val)+" "+dd.FormatString("dd.mm.yyyy")+"-"+FloatToStr(d.Val)+" "+d.FormatString("dd.mm.yyyy")+"="+IntToStr(DaysBetween(d,dd));
   ShowMessage(tmpAnsiString);

   dd=TDateTime(2008,12,31);
   tmpAnsiString=FloatToStr(dd.Val)+" "+dd.FormatString("dd.mm.yyyy")+"-"+FloatToStr(d.Val)+" "+d.FormatString("dd.mm.yyyy")+"="+IntToStr(YearsBetween(d,dd));
   ShowMessage(tmpAnsiString);

   return;

   char
     *Buff=0;

   unsigned int
     BuffSize=0xffff,
     len;

   std::fstream
     InputFile;

   AnsiString
     Mess,
     InputFileName="e:\\Ad Blocking.txt";

   try
     {
        while(!Buff&&BuffSize)
          {
             Buff=new char [BuffSize];
             if(!Buff)
               BuffSize>>=1;
          }
        if(!Buff&&!BuffSize)
          {
             Mess="Insufficient memory";
             throw Exception(Mess);
          }

        InputFile.open(InputFileName.c_str(),std::ios_base::in);
        if(!InputFile.is_open() || !InputFile.good())
          {
             Mess="Can't open file: \""+InputFileName+"\"";
             throw Exception(Mess);
          }

        Mess="";
        while(!InputFile.eof())
          {
             InputFile.getline(Buff,BuffSize);
             if(!InputFile.good() && !InputFile.eof())
               {
                  Mess="Data read error from file: \""+InputFileName+"\"";
                  throw Exception(Mess);
               }

             if((len=strlen(Buff)) && *(Buff+len-1)=='\n')
               *(Buff+len-1)='\x0';

             if(strstr(Buff,"Removed"))
               {
                  if(!strstr(Buff,"hit3.hotlog.ru")
                     && !strstr(Buff,"hit4.hotlog.ru")
                     && !strstr(Buff,"counter.rambler.ru")
                     && !strstr(Buff,"top.list.ru")
                     && !strstr(Buff,"clx.ru")
                    )
                    {
                       if(!Mess.IsEmpty())
                         Mess+="\n";
                       Mess+=Buff;
                    }
               }
          }
        ShowMessage(Mess);
     }
   __finally
     {
        if(Buff)
          delete []Buff;

        if(InputFile.is_open())
          InputFile.close();
     }
*/
#if defined(TEST_CAST)
   int
     Divisor=3,
     ResultI;

   double
     ResultD;

   ResultD=32.0/80.0*50.0;
   ShowMessage(FloatToStrF(ResultD,ffFixed,18,2));
   ResultD=(32.0/80.0)*50.0;
   ShowMessage(FloatToStrF(ResultD,ffFixed,18,2));
   ResultD=32.0*50.0/80.0;
   ShowMessage(FloatToStrF(ResultD,ffFixed,18,2));
   ResultD=(32.0*50.0)/80.0;
   ShowMessage(FloatToStrF(ResultD,ffFixed,18,2));

   AnsiString
     Str="";

   for(int i=-10; i<11; ++i)
      {
         ResultI=i/Divisor;
         ResultD=(i*1.)/Divisor;

         if(!Str.IsEmpty())
           Str+="\n";

         Str+=IntToStr(i)+"/"+IntToStr(Divisor)+" = "+IntToStr(ResultI)+" "+FloatToStrF(ResultD,ffFixed,18,9);
      }

   ShowMessage(Str);
#endif

#if defined(TEST_TO_OTHERS_APP)
   STARTUPINFO
     sinfo;

   PROCESS_INFORMATION
     pinfo;

   setmem(&sinfo,sizeof(sinfo),0);
   sinfo.cb=sizeof(sinfo);

   char
      SystemRoot[MAXPATH];

   GetEnvironmentVariable("SystemRoot",SystemRoot,MAXPATH);

   AnsiString
     AppName=SystemRoot;

   AppName+="\\system32\\notepad.exe";

   if(!CreateProcess(AppName.c_str(),0,0,0,false,NORMAL_PRIORITY_CLASS,0,0,&sinfo,&pinfo))
   {
      AppName="Can't run: \""+AppName+"\"\r\nError #"+IntToStr(GetLastError());
      Application->MessageBox(AppName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
      return;
   }

   CloseHandle(pinfo.hThread);
   CloseHandle(pinfo.hProcess);

   HWND
     hwndN=FindWindow("Notepad","Untitled - Notepad");

   if(hwndN)
     {
        HWND
          hwndE=FindWindowEx(hwndN,0,"Edit","");

        if(hwndE)
          {
             SHORT
               Key=VkKeyScan('q')&0x000ff;

             UINT
               ScanCode=MapVirtualKey(Key,0);

             LPARAM
               lParam=0;

               lParam|=1;
               lParam|=ScanCode<<16;
               PostMessage(hwndE,WM_KEYDOWN,Key,lParam);

               lParam=0;
               lParam|=1;
               lParam|=ScanCode<<16;
               lParam|=1<<30;
               lParam|=1<<31;
               PostMessage(hwndE,WM_KEYUP,Key,lParam);

               //keybd_event(Key,ScanCode,0,0); // by debugger send 'q' to IDE
               //keybd_event(Key,ScanCode,KEYEVENTF_KEYUP,0);
          }

        AnsiString
          Mess;

        int
          tmpInt;

        bool
          //Result=SetForegroundWindow(hwndN);
          Result=BringWindowToTop(hwndN);

        if(!Result)
          {
             tmpInt=GetLastError();
             //Mess="SetForegroundWindow() ";
             Mess="BringWindowToTop() ";
             Mess+="error: "+IntToStr(tmpInt)+"\nMessage: "+SysErrorMessage(tmpInt);
             ShowMessage(Mess);
             return;
          }

        HMENU
          hmenuMain=GetMenu(hwndN),
          hmenuSub;

        if(hmenuMain)
          {
             int
               MenuItemsCount=GetMenuItemCount(hmenuMain);

             if(MenuItemsCount==-1)
               {
                  tmpInt=GetLastError();
                  Mess="GetMenuItemCount() error: "+IntToStr(tmpInt)+"\nMessage: "+SysErrorMessage(tmpInt);
                  return;
               }

             char
               tmpCharBuff[0xff];

             MENUITEMINFO
               menuiteminfo;

             menuiteminfo.cbSize=sizeof(menuiteminfo);

             int
               i;

             for(i=0; i<MenuItemsCount; ++i)
                {
                   //GetMenuString(hmenuMain,i,tmpCharBuff,0xff,MF_BYCOMMAND); // All
                   GetMenuString(hmenuMain,i,tmpCharBuff,0xff,MF_BYPOSITION); // Only Main Menu
                   if(!GetMenuItemInfo(hmenuMain,i,true,&menuiteminfo))
                     {
                        tmpInt=GetLastError();
                        Mess="GetMenuItemInfo() error: "+IntToStr(tmpInt)+"\nMessage: "+SysErrorMessage(tmpInt);
                     }

                }


             hmenuSub=GetSubMenu(hmenuMain,0);
             MenuItemsCount=GetMenuItemCount(hmenuSub);
             if(MenuItemsCount==-1)
               {
                  tmpInt=GetLastError();
                  Mess="GetMenuItemCount() error: "+IntToStr(tmpInt)+"\nMessage: "+SysErrorMessage(tmpInt);
                  return;
               }
             for(i=0; i<MenuItemsCount; ++i)
                {
                   //GetMenuString(hmenuSub,i,tmpCharBuff,0xff,MF_BYCOMMAND);
                   GetMenuString(hmenuSub,i,tmpCharBuff,0xff,MF_BYPOSITION);
                   if(!GetMenuItemInfo(hmenuSub,i,true,&menuiteminfo))
                     {
                        tmpInt=GetLastError();
                        Mess="GetMenuItemInfo() error: "+IntToStr(tmpInt)+"\nMessage: "+SysErrorMessage(tmpInt);
                     }
                }

             UINT
               idMenu=GetMenuItemID(hmenuSub,3);

             PostMessage(hwndN,WM_COMMAND,idMenu,0);

             hwndN=FindWindow(0,"Save As");
             if(hwndN)
               {
                  hwndE=FindWindowEx(hwndN,0,"Edit","");
                  if(hwndE)
                    {
                       strcpy(tmpCharBuff,"d:\\test.txt");
                       SendMessage(hwndE,WM_SETTEXT,0,(LPARAM)tmpCharBuff);
                    }
               }
          }
     }
#endif

#if defined(TEST_KEYBOARD)
   AnsiString
     Mess;

   int
     BuffSize;

   BYTE
     KeyState[256];

   if(GetKeyboardState(KeyState))
     {
        WORD
          Char;

        Mess="";
        Char=KeyState[VK_CONTROL];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="VK_CONTROL";
          }
        Char=KeyState[VK_LCONTROL];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_LCONTROL)";
          }
        Char=KeyState[VK_RCONTROL];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_RCONTROL)";
          }

        Char=KeyState[VK_MENU];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="VK_MENU";
          }
        Char=KeyState[VK_LMENU];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_LMENU)";
          }
        Char=KeyState[VK_RMENU];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_RMENU)";
          }

        Char=KeyState[VK_SHIFT];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="VK_SHIFT";
          }
        Char=KeyState[VK_LSHIFT];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_LSHIFT)";
          }
        Char=KeyState[VK_RSHIFT];
        if(Char&0x080)
          {
             if(!Mess.IsEmpty())
               Mess+=" ";
             Mess+="(VK_RSHIFT)";
          }

        if(!Mess.IsEmpty())
          ShowMessage(Mess);
     }
   else
     {
        BuffSize=GetLastError();
        Mess="GetKeyboardState() error: "+IntToStr(BuffSize)+"\nMessage: "+SysErrorMessage(BuffSize);
        ShowMessage(Mess);
     }

   HKL
     hkl,
     *Buff=0;

   BuffSize=0;
   BuffSize=GetKeyboardLayoutList(BuffSize,Buff);
   if(Buff=new HKL [BuffSize])
     {
        if(BuffSize=GetKeyboardLayoutList(BuffSize,Buff))
          for(int i=0; i<BuffSize; ++i)
             {
                hkl=*(Buff+i);
             }
        else
          {
             BuffSize=GetLastError();

             AnsiString
               Mess="GetKeyboardLayoutList() error: "+IntToStr(BuffSize)+"\nMessage: "+SysErrorMessage(BuffSize);

             ShowMessage(Mess);
          }
        delete []Buff;
     }
#endif

#if defined(TEST_TDATETIME)
   AnsiString
     a="01.01.2000 07:13:14.15 pm";

   TDateTime
     b=TDateTime(a),
     bb;

   AnsiString
     c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");

   ShowMessage(c);

   a="8:1:2.3 pm";
   b=StrToTime(a);
   bb=TDateTime(a,TDateTime::Time);
   c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm")+"\n"+bb.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");
   ShowMessage(c);

   a="9:2:3.4 pm";
   b=StrToTime(a);
   bb=TDateTime(a,TDateTime::Time);
   c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm")+"\n"+bb.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");
   ShowMessage(c);

   a="10:11:12 pm";
   b=StrToTime(a);
   bb=TDateTime(a,TDateTime::Time);
   c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm")+"\n"+bb.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");
   ShowMessage(c);

   a="14:15:16.17";
   b=StrToTime(a);
   bb=TDateTime(a,TDateTime::Time);
   c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm")+"\n"+bb.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");
   ShowMessage(c);

   a="21:22:23";
   b=StrToTime(a);
   bb=TDateTime(a,TDateTime::Time);
   c=b.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm")+"\n"+bb.FormatString("dd.mm.yyyy hh:nn:ss.zz ampm");
   ShowMessage(c);

   c=IsLeapYear(1900) ? "oB!" : "Tampax";
   b=TDateTime(1900,2,28);
   b=IncDay(b);
   c=b.FormatString("dd.mm.yyyy");
   ShowMessage(c);
#endif

#if defined(RECYCLE_BIN)
   SHFILEOPSTRUCT
     SHFileOpStruct;

   char
     *Buff=0;

   unsigned int
     BuffSize=0x0ffff;

   setmem(&SHFileOpStruct,sizeof(SHFileOpStruct),'\x0');
   SHFileOpStruct.wFunc=FO_DELETE;
   SHFileOpStruct.fFlags=FOF_ALLOWUNDO|FOF_NOCONFIRMATION|FOF_NOERRORUI|FOF_SILENT;

   try
     {
        AnsiString
          Src="d:\\temp\\base.zip",
          FileName,
          Mess="";

        while(!Buff && BuffSize)
          {
             Buff=new char [BuffSize];
             if(!Buff)
               BuffSize>>=1;
          }
        if(!Buff && !BuffSize)
          {
             Mess+="insufficient memory";
             throw Exception(LOCALIZE_ERROR+Mess);
          }

        if(ExtractFileDrive(Src).IsEmpty())
          {
             Mess+="full path required";
             throw Exception(LOCALIZE_ERROR+Mess);
          }
        FileName=Src;
        SHFileOpStruct.pFrom=Buff;
        if(FileName.Length()<BuffSize)
          {
             setmem(Buff,BuffSize,'\x0');
             strcpy(Buff,FileName.c_str());
             if(SHFileOperation(&SHFileOpStruct))
               ShowMessage("Error");
          }
        else
          {
             Mess+="insufficient memory";
             throw Exception(LOCALIZE_ERROR+Mess);
          }
     }
   __finally
     {
        if(Buff)
          delete []Buff;
     }
#endif

#if defined(TEST_LIMIT)
   double
     a=std::numeric_limits<double>::min(), //-308
     b=DBL_EPSILON, //-16
     c=DBL_MIN; //-308

   if(a>b) //false
     ShowMessage("std::numeric_limits<double>::min()>DBL_EPSILON");
   if(a>c) //false
     ShowMessage("std::numeric_limits<double>::min()>DBL_MIN");
   if(b>c) //true
     ShowMessage("DBL_EPSILON>DBL_MIN");

   short
     ShortA=std::numeric_limits<short>::max(),
     ShortB=SHRT_MAX;

   if(ShortA!=ShortB)
     ShowMessage("std::numeric_limits<short>::max()!=SHRT_MAX");
#endif

#if defined(TEST_VARIANT)
   Variant
     a;

   a.Clear();

   if(a.IsEmpty())
     a=1;
   a.Clear();

   if(a.IsEmpty())
     a=999999999999999999;
   a.Clear();

   if(a.IsNull())
     a=2;

   VarClear(a);
   if(a.IsEmpty())
     a=1;

   VarClear(a);
   if(a.IsNull())
     a=2;

   a=Unassigned;
   if(a.IsEmpty())
     a=1;

   a=Unassigned;
   if(a.IsNull())
     a=2;

   VarClear(a);
   if(a.IsEmpty())
     a=1;

   VarClear(a);
   if(a.IsNull())
     a=2;
#endif

#if defined(TEST_IS_XXX)
   AnsiString
     Mess="",
     AllAll="",
     AllSmall="";

   for(unsigned char c=0; c<=0x0ff; ++c)
      {
         if(c>=0x20)
           {
              if(!AllAll.IsEmpty())
                AllAll+=" ";
              AllAll+=(char)c;

              if(((char)c>='À' && (char)c<='ß') || char(c)=='²' || char(c)=='ª' || char(c)=='¯' || char(c)=='¥' || char(c)=='¨')
                {
                  if(!AllAll.IsEmpty())
                    AllAll+="-";
                  AllAll+="oB!";

                  if((char)c>='À' && (char)c<='ß')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString((char)(c+0x20));
                    }

                  if(char(c)=='²')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString('³');
                    }

                  if(char(c)=='ª')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString('º');
                    }

                  if(char(c)=='¯')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString('¿');
                    }

                  if(char(c)=='¥')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString('´');
                    }

                  if(char(c)=='¨')
                    {
                       if(!AllSmall.IsEmpty())
                         AllSmall+=" ";
                       AllSmall+=AnsiString((char)c)+"-"+AnsiString('¸');
                    }
                }
           }

         if(isalpha(c)) // 'A'..'Z','a'..'z'
           {
              if(!Mess.IsEmpty())
                Mess+=" ";
              Mess+=(char)c;
           }
         if(c==0x0ff)
           break;
      }
   ShowMessage(AllAll);
   ShowMessage(AllSmall);
   ShowMessage("isalpha="+Mess);

   Mess="";
   for(unsigned char c=0; c<=0x0ff; ++c)
      {
         if(isdigit(c)) // '0'..'9'
           {
              if(!Mess.IsEmpty())
                Mess+=" ";
              Mess+=(char)c;
           }
         if(c==0x0ff)
           break;
      }
   ShowMessage("isdigit="+Mess);

   Mess="";
   for(unsigned char c=0; c<=0x0ff; ++c)
      {
         if(isalnum(c)) // isalpha + isdigit 'A'..'Z','a'..'z','0'..'9'
           {
              if(!Mess.IsEmpty())
                Mess+=" ";
              Mess+=(char)c;
           }
         if(c==0x0ff)
           break;
      }
   ShowMessage("isalnum="+Mess);

   Mess="";
   for(unsigned char c=0; c<=0x0ff; ++c)
      {
         if(isascii(c)) // 0..127
           {
              if(!Mess.IsEmpty())
                Mess+=" ";
              Mess+=c;
           }
         if(c==0x0ff)
           break;
      }
   ShowMessage("isascii="+Mess);
#endif

#if defined(TEST_EXTRACT_FROM_FILE)
   AnsiString
     FileName="d:\\path1\\path2\\filename.ext",
     Drive=ExtractFileDrive(FileName), // == "d:"
     Path=ExtractFilePath(FileName), // == "d:\\path1\\path2\\"
     Name=ExtractFileName(FileName), // == "filename.ext"
     Ext=ExtractFileExt(FileName), // == ".ext"
     b=Drive+Path+Name+"___"+Ext;

   ShowMessage(b);

   FileName="d:";
   Drive=ExtractFileDrive(FileName); // == "d:"
   Path=ExtractFilePath(FileName); // == "d:"
   Name=ExtractFileName(FileName); // == NULL
   Ext=ExtractFileExt(FileName); // == NULL
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="d:filename.ext";
   Drive=ExtractFileDrive(FileName); // == "d:"
   Path=ExtractFilePath(FileName); // == "d:"
   Name=ExtractFileName(FileName); // == "filename.ext"
   Ext=ExtractFileExt(FileName); // == ".ext"
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="d:\\";
   Drive=ExtractFileDrive(FileName); // == "d:"
   Path=ExtractFilePath(FileName); // == "d:\\"
   Name=ExtractFileName(FileName); // == NULL
   Ext=ExtractFileExt(FileName); // == NULL
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="d:\\filename.ext";
   Drive=ExtractFileDrive(FileName); // == "d:"
   Path=ExtractFilePath(FileName); // == "d:\\"
   Name=ExtractFileName(FileName); // == "filename.ext"
   Ext=ExtractFileExt(FileName); // == ".ext"
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="\\filename.ext";
   Drive=ExtractFileDrive(FileName); // == NULL
   Path=ExtractFilePath(FileName); // == "\\"
   Name=ExtractFileName(FileName); // == "filename.ext"
   Ext=ExtractFileExt(FileName); // == ".ext"
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="\\path1\\path2\\filename.ext";
   Drive=ExtractFileDrive(FileName); // == NULL
   Path=ExtractFilePath(FileName); // == "\\path1\\path2\\"
   Name=ExtractFileName(FileName); // == "filename.ext"
   Ext=ExtractFileExt(FileName); // == ".ext"
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   FileName="path1\\path2\\filename.ext";
   Drive=ExtractFileDrive(FileName); // == NULL
   Path=ExtractFilePath(FileName); // == "path1\\path2\\"
   Name=ExtractFileName(FileName); // == "filename.ext"
   Ext=ExtractFileExt(FileName); // == ".ext"
   b=Drive+Path+Name+"___"+Ext;
   ShowMessage(b);

   char
     drive[MAXDRIVE],
     dir[MAXDIR],
     file[MAXFILE],
     ext[MAXEXT];

   int
     flags;

   FileName="d:\\path1 subpath1\\path2 subpath2\\filename subfilename.preext presubext.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // =="d:"
   if(flags&DIRECTORY)
     b+=dir; // =="\\path1\\path2\\"
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   FileName="d:";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // =="d:"
   if(flags&DIRECTORY)
     b+=dir; // ==""
   if(flags&FILENAME)
     b+=file; // == ""
   if(flags&EXTENSION)
     b+=ext; // ==""
   ShowMessage(b);

   FileName="d:filename.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // =="d:"
   if(flags&DIRECTORY)
     b+=dir; // ==""
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   FileName="d:\\";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // =="d:"
   if(flags&DIRECTORY)
     b+=dir; // =="\\"
   if(flags&FILENAME)
     b+=file; // == ""
   if(flags&EXTENSION)
     b+=ext; // ==""
   ShowMessage(b);

   FileName="d:\\filename.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // =="d:"
   if(flags&DIRECTORY)
     b+=dir; // =="\\"
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   FileName="\\filename.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // ==""
   if(flags&DIRECTORY)
     b+=dir; // =="\\"
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   FileName="\\path1\\path2\\filename.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // ==""
   if(flags&DIRECTORY)
     b+=dir; // =="\\path1\\path2\\"
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   FileName="path1\\path2\\filename.ext";
   b="";
   flags=fnsplit(FileName.c_str(),drive,dir,file,ext);
   if(flags&DRIVE)
     b+=drive; // ==""
   if(flags&DIRECTORY)
     b+=dir; // =="path1\\path2\\"
   if(flags&FILENAME)
     b+=file; // == "filename"
   if(flags&EXTENSION)
     b+=ext; // ==".ext"
   ShowMessage(b);

   char
     curdir[MAXPATH];

   int
     result;

   for(int drive='C'; drive<='E'; ++drive)
      {
         setmem(curdir,MAXPATH,'\x0');
         strcpy(curdir,"x:\\");
         *curdir=drive;
         if(!(result=getcurdir(drive-'A'+1,curdir+3)))
           {
              b=AnsiString((char)drive)+": getcurdir="+curdir;
              ShowMessage(b);
           }
      }

   setmem(curdir,MAXPATH,'\x0');
   strcpy(curdir,"x:\\");
   *curdir=getdisk()+'A';
   if(!(result=getcurdir(0,curdir+3)))
     {
        b=curdir;
        ShowMessage(b);
     }

   b="GetCurrentDir() = "+GetCurrentDir();
   ShowMessage(b);

   ShowMessage("DirectoryExists(\"d:\")="+BoolToStr(DirectoryExists("d:"),true));
   ShowMessage("DirectoryExists(\"d:\\\")="+BoolToStr(DirectoryExists("d:\\"),true));
   ShowMessage("DirectoryExists(\"obj\")="+BoolToStr(DirectoryExists("obj"),true));
#endif

#if defined(TEST_ROUND)
  TFPURoundingMode
    FPURoundingMode=GetRoundMode();

   double
     a=123.445, //1.235,
     b;

   //SetRoundMode(rmNearest);
   //SetRoundMode(rmDown);
   SetRoundMode(rmUp);
   //SetRoundMode(rmTruncate);

   //if(FPURoundingMode!=rmDown)
   //  SetRoundMode(rmDown);

   b=/*Simple*/RoundTo(a,-2);

   tmpAnsiString=FloatToStrF(a,ffFixed,18,2);
   tmpAnsiString+=" "+FloatToStrF(b,ffFixed,18,2);
#endif

#if defined(GET_NUMBER_FORMAT)
   char
     in[]="-123456789",
     out[1024],
     DecimalSep[]="-",
     ThousandSep[]="~";

   NUMBERFMT
     Format;

   int
     Result;

   AnsiString
     Mess;

   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_IDIGITS,out,1024);
   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_ILZERO,out,1024);
   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_SGROUPING,out,1024);
   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_SDECIMAL,out,1024);
   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_STHOUSAND,out,1024);
   Result=GetLocaleInfo(LOCALE_USER_DEFAULT,LOCALE_INEGNUMBER,out,1024);

   Format.NumDigits=9; // 9 - max 10 - The parameter is incorrect (ErrNo=87)
   Format.LeadingZero=1;
   Format.Grouping=5;
   Format.lpDecimalSep=DecimalSep;
   Format.lpThousandSep=ThousandSep;
   Format.NegativeOrder=0;
   Result=GetNumberFormat(LOCALE_USER_DEFAULT,0,in,0,out,0);
   if(Result<=1024)
     {
        if(Result=GetNumberFormat(LOCALE_USER_DEFAULT,0,in,0,out,1024))
          ShowMessage(out);
        else
          {
             Mess="ErrNo="+IntToStr(GetLastError());
             ShowMessage(Mess);
          }

        setmem(out,1024,'\x0');
        if(Result=GetNumberFormat(LOCALE_USER_DEFAULT,0,in,&Format,out,1024))
          ShowMessage(out);
        else
          {
             int
               err=GetLastError();

             Mess=SysErrorMessage(err)+" (ErrNo="+IntToStr(err)+")";
             ShowMessage(Mess);
          }
     }
#endif
}
//---------------------------------------------------------------------------



