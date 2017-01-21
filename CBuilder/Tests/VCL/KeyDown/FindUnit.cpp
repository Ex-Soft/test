//---------------------------------------------------------------------------

#include <vcl.h>
#include <new>
#pragma hdrstop

#include "FindUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TFindForm *FindForm;
//---------------------------------------------------------------------------

__fastcall TFindForm::TFindForm(TComponent* Owner):TForm(Owner)
{
   EditSearch=0;
   
   try
     {
        EditSearch=new TMyEdit(Owner);
     }
   catch(std::bad_alloc)
     {
        throw Exception(AnsiString(__FUNC__)+" Insufficient memory");
     }

   EditSearch->Parent=this;
   EditSearch->Left=55;
   EditSearch->Top=0;
   EditSearch->OnKeyDown=EditSearchKeyDown;
   EditSearch->AutoSelect=false;
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::FormCreate(TObject *Sender)
{
   long
     ws=GetWindowLong(Handle,GWL_STYLE);

   ws&=~WS_BORDER;
   ws=SetWindowLong(Handle,GWL_STYLE,ws);
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::FormShow(TObject *Sender)
{
   Height = LabelInfoKeyDown->Height+6 ;
   EditSearch->SelLength=0;
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::EditSearchKeyDown(TObject *Sender, WORD &Key, TShiftState Shift)
{
   if(Key==VK_ESCAPE)
     Close();
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::EditSearchChange(TObject *Sender)
{
//
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(EditSearch)
     {
        delete EditSearch;
        EditSearch=0;
     }
   Action=caFree;
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::MyOnKeyDown(TWMKeyDown& Message)
{
   AnsiString
     Mess="OnKeyDown Msg="+IntToStr(Message.Msg)+" CharCode="+IntToStr(Message.CharCode)+" Unused="+IntToStr(Message.Unused)+" KeyData="+IntToStr(Message.KeyData);

   __int32
     RepeatCount=Message.KeyData & 0xffff,
     ScanCode=(Message.KeyData & 0x0ff0000)>>16,
     ExtendedKey=(Message.KeyData & 0x1000000)>>24,
     ContextCode=(Message.KeyData & 0x20000000)>>29,
     PreviousKeyState=(Message.KeyData & 0x40000000)>>30,
     TransitionState=(Message.KeyData & 0x80000000)>>31;

   Mess+=" "+IntToStr(RepeatCount)+" "+IntToStr(ScanCode)+" "+IntToStr(ExtendedKey)+" "+IntToStr(ContextCode)+" "+IntToStr(PreviousKeyState)+" "+IntToStr(TransitionState);
   LabelInfoKeyDown->Caption=Mess;
}
//---------------------------------------------------------------------------

void __fastcall TFindForm::MyOnKeyUp(TWMKeyUp& Message)
{
   AnsiString
     Mess="OnKeyUp Msg="+IntToStr(Message.Msg)+" CharCode="+IntToStr(Message.CharCode)+" Unused="+IntToStr(Message.Unused)+" KeyData="+IntToStr(Message.KeyData);

   __int32
     RepeatCount=Message.KeyData & 0xffff,
     ScanCode=(Message.KeyData & 0x0ff0000)>>16,
     ExtendedKey=(Message.KeyData & 0x1000000)>>24,
     ContextCode=(Message.KeyData & 0x20000000)>>29,
     PreviousKeyState=(Message.KeyData & 0x40000000)>>30,
     TransitionState=(Message.KeyData & 0x80000000)>>31;

   Mess+=" "+IntToStr(RepeatCount)+" "+IntToStr(ScanCode)+" "+IntToStr(ExtendedKey)+" "+IntToStr(ContextCode)+" "+IntToStr(PreviousKeyState)+" "+IntToStr(TransitionState);
   LabelInfoKeyUp->Caption=Mess;
}
//---------------------------------------------------------------------------

