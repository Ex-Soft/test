//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "U2Mess1.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TForm2 *Form2;
//---------------------------------------------------------------------------

__fastcall TForm2::TForm2(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm2::OnClose(TWMClose &Message)
{
   Label2->Caption="������! ���������!";
   if(MessageDlgPos("���� ����� �������. ��������?",mtConfirmation,TMsgDlgButtons()<<mbYes<<mbNo<<mbCancel,0,BoundsRect.Left,BoundsRect.Bottom)==mrYes)
     Close();
   else
     Label2->Caption="�� ��������!";
   Message.Result=0;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::OnActivate(TWMActivate &Message)
{
   if(Message.Active==WA_INACTIVE)
     Label1->Caption="���� ��������";
   else
     Label1->Caption="���!!! � �������!!!";
   Message.Result=0;
}
//---------------------------------------------------------------------------

void __fastcall TForm2::OnMoving(TMessage &Message)
{
   Message.Result=true;
}
//---------------------------------------------------------------------------

