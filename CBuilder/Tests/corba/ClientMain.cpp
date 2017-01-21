//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include <corba.h>
#include "ClientMain.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

PostModule::Post_ptr __fastcall TForm1::Getpost(void)
{
        if (Fpost == NULL)
        {
                 Fpost = PostModule::Post::_bind();
        }
        return Fpost;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Setpost(PostModule::Post_ptr _ptr)
{
        Fpost = _ptr;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::BitBtn1Click(TObject *Sender)
{
   String text=Memo1->Lines->Text;
   String name=Edit1->Text;
   int words=post->GetText(text.c_str(),name.c_str());
   StatusBar1->Panels->Items[0]->Text="Телеграмма принята ("+IntToStr(words)+") слов";
   StatusBar1->Panels->Items[1]->Text="отправил: "+name;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormShow(TObject *Sender)
{
   StatusBar1->Panels->Items[0]->Width=StatusBar1->Width/2;
}
//---------------------------------------------------------------------------
