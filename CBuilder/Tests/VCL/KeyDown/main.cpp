//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "FindUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Edit1KeyDown(TObject *Sender, WORD &Key, TShiftState Shift)
{
   AnsiString
     Mess="OnKeyDown: "+IntToStr(Key);

   if(Shift.Contains(ssShift))
     Mess+=" ssShift";
   if(Shift.Contains(ssAlt))
     Mess+=" ssAlt";
   if(Shift.Contains(ssCtrl))
     Mess+=" ssCtrl";
   if(Shift.Contains(ssLeft))
     Mess+=" ssLeft";
   if(Shift.Contains(ssRight))
     Mess+=" ssRight";
   if(Shift.Contains(ssMiddle))
     Mess+=" ssMiddle";
   if(Shift.Contains(ssDouble))
     Mess+=" ssDouble";

   Memo1->Lines->Add(Mess);

   if(Key!=VK_CONTROL && Key!=VK_MENU && Shift.Contains(ssAlt) && Shift.Contains(ssCtrl))
     {
        wchar_t
          UnicodeChar[2];

        BYTE
          KeyState[256];

        HKL
          hkl=GetKeyboardLayout(0);

        UINT
          ScanCode,
          Flags=0;

        WORD
          Char,
          CharHi,
          CharLo;

        int
          Result;

        AnsiString
          Mess;

        if(!GetKeyboardState(KeyState))
          return;

        Char=KeyState[VK_CONTROL];
        Char&=~0x080;
        KeyState[VK_CONTROL]=Char;

        Char=KeyState[VK_MENU];
        Char&=~0x080;
        KeyState[VK_MENU]=Char;

        /*
        ScanCode=MapVirtualKey(Key,0);
        Result=ToAscii(Key,ScanCode,KeyState,&Char,Flags);
        CharHi=Char&0x0ff00;
        CharLo=Char&0x000ff;
        Mess=(char)CharLo;
        Result=ToUnicode(Key,ScanCode,KeyState,UnicodeChar,2,Flags);

        ScanCode=MapVirtualKeyEx(Key,0,hkl);
        Result=ToAsciiEx(Key,ScanCode,KeyState,&Char,Flags,hkl);
        CharHi=Char&0x0ff00;
        CharLo=Char&0x000ff;
        Mess=(char)CharLo;
        Result=ToUnicodeEx(Key,ScanCode,KeyState,UnicodeChar,2,Flags,hkl);
        */

        Char=KeyState[VK_SHIFT];
        //Char&=~0x080;
        Char|=0x080;
        KeyState[VK_SHIFT]=Char;

        Char=KeyState[VK_LSHIFT];
        //Char&=~0x080;
        Char|=0x080;
        KeyState[VK_LSHIFT]=Char;

        Char=KeyState[VK_LCONTROL];
        Char&=~0x080;
        KeyState[VK_LCONTROL]=Char;

        Char=KeyState[VK_LMENU];
        Char&=~0x080;
        KeyState[VK_LMENU]=Char;

        Char=KeyState[VK_RSHIFT];
        Char&=~0x080;
        KeyState[VK_RSHIFT]=Char;

        Char=KeyState[VK_RCONTROL];
        Char&=~0x080;
        KeyState[VK_RCONTROL]=Char;

        Char=KeyState[VK_RMENU];
        Char&=~0x080;
        KeyState[VK_RMENU]=Char;

        //setmem(KeyState,256,0);

        SHORT
          TranslateChar,
          TranslateCharHi,
          TranslateCharLo;

        TranslateChar=VkKeyScan(Key);
        TranslateCharHi=TranslateChar&0x0ff00;
        TranslateCharLo=TranslateChar&0x000ff;

        TranslateChar=VkKeyScanEx(Key,hkl);
        TranslateCharHi=TranslateChar&0x0ff00;
        TranslateCharLo=TranslateChar&0x0ff;

        TranslateChar=VkKeyScan('Є');
        TranslateCharHi=TranslateChar&0x0ff00;
        TranslateCharLo=TranslateChar&0x000ff;

        ScanCode=MapVirtualKey(TranslateCharLo,0);
        Result=ToAscii(TranslateCharLo,ScanCode,KeyState,&Char,Flags);
        CharHi=Char&0x0ff00;
        CharLo=Char&0x000ff;
        Mess=(char)CharLo;
        Result=ToUnicode(TranslateCharLo,ScanCode,KeyState,UnicodeChar,2,Flags);

        ScanCode=MapVirtualKey(Key,0);
        Result=ToAscii(Key,ScanCode,KeyState,&Char,Flags);
        CharHi=Char&0x0ff00;
        CharLo=Char&0x000ff;
        Mess=(char)CharLo;
        Result=ToUnicode(Key,ScanCode,KeyState,UnicodeChar,2,Flags);

        ScanCode=MapVirtualKeyEx(Key,0,hkl);
        Result=ToAsciiEx(Key,ScanCode,KeyState,&Char,Flags,hkl);
        CharHi=Char&0x0ff00;
        CharLo=Char&0x000ff;
        Mess=(char)CharLo;
        Result=ToUnicodeEx(Key,ScanCode,KeyState,UnicodeChar,2,Flags,hkl);

        FindForm=new TFindForm(MainForm);

        LPARAM
          lParam=0;

        TranslateChar=VkKeyScan('Є');
        TranslateCharHi=TranslateChar&0x0ff00;
        TranslateCharLo=TranslateChar&0x000ff;

        ScanCode=MapVirtualKey(TranslateCharLo,0);

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        //PostMessage(FindForm->EditSearch->Handle,WM_KEYDOWN,TranslateCharLo,lParam); // test

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        lParam|=1<<30;
        lParam|=1<<31;
        //PostMessage(FindForm->EditSearch->Handle,WM_KEYUP,TranslateCharLo,lParam); // test

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        PostMessage(FindForm->Handle,WM_KEYDOWN,Key,lParam); // test

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        lParam|=1<<30;
        lParam|=1<<31;
        PostMessage(FindForm->Handle,WM_KEYUP,Key,lParam); // test

        FindForm->EditSearch->ToggleSubClass(true);

        //PostMessage(FindForm->EditSearch->Handle,WM_SETFOCUS,0,0);

        SetKeyboardState(KeyState);
        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        PostMessage(FindForm->EditSearch->Handle,WM_KEYDOWN,Key,lParam); // main

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        lParam|=1<<30;
        lParam|=1<<31;
        //PostMessage(FindForm->EditSearch->Handle,WM_KEYUP,Key,lParam); // + еще одна буква

        lParam=0;
        lParam|=1;
        lParam|=ScanCode<<16;
        //PostMessage(FindForm->EditSearch->Handle,WM_CHAR,CharLo,lParam); // + еще одна буква

        //PostMessage(FindForm->EditSearch->Handle,WM_KEYDOWN,Key,lParam); // + еще одна буква
        //PostMessage(FindForm->EditSearch->Handle,WM_KEYDOWN,Key,lParam); // + еще одна буква

        //FindForm->EditSearch->Text=Mess;
        //PostMessage(FindForm->EditSearch->Handle,EM_SETSEL,0,0);

        FindForm->ShowModal();
        delete FindForm;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Edit1KeyPress(TObject *Sender, char &Key)
{
   AnsiString
     Mess="OnKeyPress: "+AnsiString(Key);

   Memo1->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Edit1KeyUp(TObject *Sender, WORD &Key, TShiftState Shift)
{
   AnsiString
     Mess="OnKeyUp: "+IntToStr(Key);

   if(Shift.Contains(ssShift))
     Mess+=" ssShift";
   if(Shift.Contains(ssAlt))
     Mess+=" ssAlt";
   if(Shift.Contains(ssCtrl))
     Mess+=" ssCtrl";
   if(Shift.Contains(ssLeft))
     Mess+=" ssLeft";
   if(Shift.Contains(ssRight))
     Mess+=" ssRight";
   if(Shift.Contains(ssMiddle))
     Mess+=" ssMiddle";
   if(Shift.Contains(ssDouble))
     Mess+=" ssDouble";

   Memo1->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

