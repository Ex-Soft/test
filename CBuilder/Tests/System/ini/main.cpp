//---------------------------------------------------------------------------

#include <vcl.h>
#include <inifiles.hpp>
//#include <graphics.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
   AnsiString IniFileName=GetCurrentDir()+"\\tmp.ini";

   char *Buff=0;
   DWORD BuffSize=0x0ffff,Count;

   while(!Buff && BuffSize)
     {
        Buff=new char [BuffSize];
        if(!Buff)
          BuffSize>>=1;
     }

   if(!Buff && !BuffSize)
     {
        return;
     }

   Count=GetPrivateProfileSectionNames(Buff,BuffSize,IniFileName.c_str());

   AnsiString Section;
   while(Count)
     {
        Section=Buff;
        Count-=Section.Length()+1;
        memmove(Buff,Buff+Section.Length()+1,Count);
     }

   delete []Buff;

   TStringList *MyList=new TStringList;
   TIniFile *MyIni=new TIniFile(IniFileName);

   MyIni->ReadSectionValues("Font",MyList);

   Memo1->Lines=MyList;
   Memo1->Lines->Insert(0,"[Font]");
   Caption=" Font: "+Memo1->Lines->Values["Name"];
   Memo1->Font->Name=MyList->Values["Name"];
   Memo1->Font->Size=StrToInt(MyList->Values["Size"]);

   Memo1->Lines->Add("");
   Memo1->Lines->Add("fOnT");
   Memo1->Lines->Add(AnsiString::StringOfChar('=',4));
   Memo1->Lines->Add("[font] name = "+MyIni->ReadString("font","name",""));
   Memo1->Lines->Add("[fONT] cOLOR = "+MyIni->ReadString("fONT","cOLOR",""));
   Memo1->Lines->Add("[fOnT] SiZe = "+IntToStr(MyIni->ReadInteger("fOnT","SiZe",0)));

   Memo1->Lines->Add("");
   Memo1->Lines->Add("Иванов");
   Memo1->Lines->Add(AnsiString::StringOfChar('=',6));
   Memo1->Lines->Add("[ИваНов] name = "+MyIni->ReadString("ИваНов","name",""));
   Memo1->Lines->Add("[Иванов] cOLOR = "+MyIni->ReadString("Иванов","cOLOR",""));
   Memo1->Lines->Add("[Иванов] SiZe = "+IntToStr(MyIni->ReadInteger("Иванов","SiZe",0)));

   delete MyList;
   delete MyIni;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
   TIniFile *MyIni=new TIniFile(GetCurrentDir()+"\\tmp.ini");
   MyIni->WriteString("Font","Name",Memo1->Lines->Values["Name"]);
   MyIni->WriteString("Font","Size",Memo1->Lines->Values["Size"]);
   delete MyIni;
}
//---------------------------------------------------------------------------
