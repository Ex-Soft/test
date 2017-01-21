//---------------------------------------------------------------------------

#include "MyEdit.h"
#include "main.h"
//---------------------------------------------------------------------------

__fastcall TMyEdit::TMyEdit(TComponent* Owner):TEdit(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMyEdit::ToggleSubClass(bool On)
{
  if(On)
    WindowProc=SubClassWndProc;
  else
    WindowProc=WndProc;
}
//---------------------------------------------------------------------------

void __fastcall TMyEdit::SubClassWndProc(Messages::TMessage &Message)
{
  if(Message.Msg==WM_KEYDOWN || Message.Msg==WM_KEYUP)
    {
       AnsiString
         Mess="";

       if(Message.Msg==WM_KEYDOWN)
         Mess+="WM_KEYDOWN ";
       if(Message.Msg==WM_KEYUP)
         Mess+="WM_KEYUP ";

       Mess+=IntToStr(Message.Msg)+" "+IntToStr(Message.WParam)+" "+IntToStr(Message.LParam);

       __int32
         RepeatCount=Message.LParam & 0xffff,
         ScanCode=(Message.LParam & 0x0ff0000)>>16,
         ExtendedKey=(Message.LParam & 0x1000000)>>24,
         ContextCode=(Message.LParam & 0x20000000)>>29,
         PreviousKeyState=(Message.LParam & 0x40000000)>>30,
         TransitionState=(Message.LParam & 0x80000000)>>31;

       Mess+=" "+IntToStr(RepeatCount)+" "+IntToStr(ScanCode)+" "+IntToStr(ExtendedKey)+" "+IntToStr(ContextCode)+" "+IntToStr(PreviousKeyState)+" "+IntToStr(TransitionState);

       MainForm->Memo1->Lines->Add(Mess);

       char
         buff[0xffff];

       int
         len=GetKeyNameText(Message.LParam,(LPTSTR)buff,0xffff);

       if(len)
         {
            *(buff+len)='\x0';
            MainForm->Memo1->Lines->Add(buff);
         }
       WndProc(Message);
    }
  else
    WndProc(Message);
}
//---------------------------------------------------------------------------

