//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   TSysCharSet Separators,WhiteSpace;
   TStringList *StringsList;
   char *Content;
   int Result;
   AnsiString Str="";

   StringsList=new TStringList;
   Content=new char [0x0ffff];

   Separators.Clear();
   Separators<<'\x20'<<'\t'<<'=';

   WhiteSpace.Clear();
   WhiteSpace<<'y'<<'-';

   strcpy(Content,"Line#1 yLine#2\r\nLine#3\nLine#4\tLine#5=Line#6\t\"Line #7=\" 'Line #8' \"Line #9 \"Line #10\"\tLine #11\t=Line#12=Line #13");

   Result=ExtractStrings(Separators,WhiteSpace,Content,StringsList);

   for(int i=0; i<StringsList->Count; i++)
      {
         if(!Str.IsEmpty())
           Str+="\n";
         Str+=StringsList->Strings[i];
      }

   Str="Result="+IntToStr(Result)+"\n"+Str;
   ShowMessage(Str);

   StringsList->Clear();
   delete StringsList;
   delete []Content;
}
//---------------------------------------------------------------------------



