//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <dos.h>
#include <iostream>
#include<iomanip>
#include<stdio.h>
#include "SSl.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm11 *Form11;
int ret;
//---------------------------------------------------------------------------
__fastcall TForm11::TForm11(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm11::Button1Click(TObject *Sender)
{
      IdSMTP1->Host     = "gateapm.usbi.com.ua";
      IdSMTP1->Port     = 25;
      IdSMTP1->UserId   = "";
      IdSMTP1->Password = "";
      AnsiString DATA_DIR = "";
      AnsiString TO       = "";
      AnsiString FROM     = "";
      AnsiString VerN     = "";
      bool IsUpdate       = false;
      bool IsUpdateV      = false;
      if (GetParamExists("-h:"))
         {IdSMTP1->Host=GetParamValue("-h:");}
      if (GetParamExists("-n:"))
         {IdSMTP1->Port=GetParamValue("-n:").ToIntDef(25);}
      if (GetParamExists("-u:"))
         {IdSMTP1->UserId=GetParamValue("-u:");}
      if (GetParamExists("-p:"))
         {IdSMTP1->Password=GetParamValue("-p:");}
      if (GetParamExists("-a:"))
         {DATA_DIR=GetParamValue("-a:");}
      if (GetParamExists("-t:"))
         {TO=GetParamValue("-t:");}
      if (GetParamExists("-f:"))
         {FROM=GetParamValue("-f:");}
      IsUpdate = GetParamExists("-upd");
      if (GetParamExists("-vn:"))
         {VerN=GetParamValue("-vn:");IsUpdateV=true;}


      if (GetParamExists("/?") || IdSMTP1->Host=="" || DATA_DIR=="" || TO=="" || FROM=="")
         {
           Application->MessageBoxA("Usage :\n\rKSSend -h:hostname -t:to -f:from -a:attach_file [-n:port] [-u:userid] [-p:password] [-upd: | -un:version] \n\r\n\rEx: KSCheck -h:gateapm -n:25 -f:Test1@gateapm.usbi.com.ua -t:tEST1@gateapm.usbi.com.ua -un:1.0.0.2 \n\rEx: KSCheck -h:gateapm -n:25 -f:Test1@gateapm.usbi.com.ua -t:tEST1@gateapm.usbi.com.ua -a:C:\\temp\\CEC.chm -upd: \n\rEx: KSCheck -h:gateapm -n:25 -f:Test1@gateapm.usbi.com.ua -t:tEST1@gateapm.usbi.com.ua -a:C:\\temp\\test.txt","Help",MB_OK+MB_ICONINFORMATION);
           ret=-1;
           return;
         }
      try{
          //IdLogDebug1->Active=true;
          IdSMTP1->Connect();
          IdMessage1->From->Address = FROM;
          IdMessage1->Recipients->EMailAddresses = TO;
          if (IsUpdate)
             {
               IdMessage1->ExtraHeaders->Add("X-ARMVersion: 1.0.0.0");
               IdMessage1->ExtraHeaders->Add("X-SenderARM: CH_EDPROU");
               IdMessage1->ExtraHeaders->Add("X-MailType: UPDATE");
             }
          if (IsUpdateV)
             {
               IdMessage1->ExtraHeaders->Add("X-ARMVersion: 1.0.0.0");
               IdMessage1->ExtraHeaders->Add("X-SenderARM: CH_EDPROU");
               IdMessage1->ExtraHeaders->Add("X-MailType: VERSION");
               IdMessage1->ExtraHeaders->Add("X-RESULTSTRING: "+VerN);
             }
          TIdAttachment * Temp;
          Temp = new  TIdAttachment(IdMessage1->MessageParts,DATA_DIR);
          Temp->ContentTransfer = "base64";
          IdSMTP1->Send(IdMessage1);
          IdSMTP1->Disconnect();
          }catch (...)
                 {ret=-1;}
}
//---------------------------------------------------------------------------
bool __fastcall TForm11::GetParamExists(AnsiString Param)
{
   for (int i = 0 ; i<=ParamCount();i++){AnsiString DL = ParamStr(i);if (DL.Pos(Param)==1){return  true;}} return false;
}

AnsiString __fastcall TForm11::GetParamValue(AnsiString Param)
{
   for (int i = 0 ; i<=ParamCount();i++){AnsiString DL = ParamStr(i);if (DL.Pos(Param)==1){return  DL.Delete(1,Param.Length());}}return "";
}

void __fastcall TForm11::FormCreate(TObject *Sender)
{
        Button1Click(NULL);
        Application->Terminate();
}
//---------------------------------------------------------------------------

