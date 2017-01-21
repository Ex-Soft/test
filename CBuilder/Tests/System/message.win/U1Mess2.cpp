//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "U1Mess2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::OnClose(TWMClose &Message)
{
   Label2->Caption="Караул! Закрывают!";
   if(MessageDlgPos("Меня хотят закрыть. Согласны?",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo<<mbCancel,0,BoundsRect.Left,BoundsRect.Bottom)==mrYes)
     Close();
   else
     Label2->Caption="Не закроюсь!";
}
//---------------------------------------------------------------------------

void __fastcall TForm1::OnKeyDown(TWMKeyDown& Message)
{
   Label1->Caption="Msg="+IntToStr(Message.Msg)+" CharCode="+IntToStr(Message.CharCode)+" Unused="+IntToStr(Message.Unused)+" KeyData="+IntToStr(Message.KeyData);
   Label2->Caption=(char)Message.CharCode;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::OnMoving(TMessage& Message)
{
   AnsiString Mess=IntToStr(Message.WParam);
   RECT *rPtr=(RECT *)Message.LParam;

   if(Message.WParam == WMSZ_BOTTOM)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_BOTTOM";
     }
   if(Message.WParam == WMSZ_BOTTOMLEFT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_BOTTOMLEFT";
     }
   if(Message.WParam == WMSZ_BOTTOMRIGHT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_BOTTOMRIGHT";
     }
   if(Message.WParam == WMSZ_LEFT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_LEFT";
     }
   if(Message.WParam == WMSZ_RIGHT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_RIGHT";
     }
   if(Message.WParam == WMSZ_TOP)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_TOP";
     }
   if(Message.WParam == WMSZ_TOPLEFT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_TOPLEFT";
     }
   if(Message.WParam == WMSZ_TOPRIGHT)
     {
        if(!Mess.IsEmpty())
          Mess+=" ";
        Mess+="WMSZ_TOPRIGHT";
     }

   Mess+="\r\nRECT Left="+IntToStr(rPtr->left)+" Top="+IntToStr(rPtr->top)+" Right="+IntToStr(rPtr->right)+" Bottom="+IntToStr(rPtr->bottom);
   Label1->Caption=Mess;

   Mess="Left="+IntToStr(Left)+" Top="+IntToStr(Top);
   Label2->Caption=Mess;

   Message.Result=true;
}
//---------------------------------------------------------------------------


