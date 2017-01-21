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
   BottomListView->HandleNeeded();
   CheckListBoxItemIndex=-1;
   CheckListBox1->MultiSelect=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   RichEdit->Height=ClientHeight;

   RichEdit->Lines->Add("TopListView->Height="+IntToStr(TopListView->Height));
   RichEdit->Lines->Add("BottomListView->Height="+IntToStr(BottomListView->Height));

   BottomListView->Height=RightTabSheet1->ClientHeight*(1./3);

   RichEdit->Lines->Add("TopListView->Height="+IntToStr(TopListView->Height));
   RichEdit->Lines->Add("BottomListView->Height="+IntToStr(BottomListView->Height));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LeftPageControlChange(TObject *Sender)
{
   RichEdit->Parent=LeftPageControl->Pages[LeftPageControl->TabIndex];
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PageControlDrawTab(TCustomTabControl *Control, int TabIndex, const TRect &Rect, bool Active)
{
   TPageControl *PageControl=0;

   if(PageControl=dynamic_cast<TPageControl *>(Control))
     {
        RichEdit->Lines->Add("TabIndex="+IntToStr(TabIndex));
        RichEdit->Lines->Add("Rect left="+IntToStr(Rect.left)+" top="+IntToStr(Rect.top)+" right="+IntToStr(Rect.right)+" bottom="+IntToStr(Rect.bottom));
        RichEdit->Lines->Add("Active="+BoolToStr(Active,true));

        int TextIndentation=5;
        int PictureIndentation=10;
        int ActiveIndentation = Active ? 4 : 0;

        RichEdit->Lines->Add("ControlPageImageList->Draw X="+IntToStr(Rect.left+PictureIndentation+ActiveIndentation)+" Y="+IntToStr((PageControl->TabHeight-ControlPageImageList->Height)/2));
        ControlPageImageList->Draw(PageControl->Canvas,Rect.left+PictureIndentation+ActiveIndentation,(PageControl->TabHeight-ControlPageImageList->Height)/2,TabIndex);

        TRect rect(Rect.left+PictureIndentation+ControlPageImageList->Width+PictureIndentation,Rect.top+TextIndentation,Rect.right-TextIndentation,Rect.bottom-TextIndentation);
        int height=DrawText(PageControl->Canvas->Handle,PageControl->Pages[TabIndex]->Caption.c_str(),-1,&rect,DT_CALCRECT|DT_WORDBREAK);

        if(Rect.bottom-TextIndentation-Rect.top-TextIndentation>height)
          rect.top=Rect.top+TextIndentation+(Rect.bottom-TextIndentation-Rect.top-TextIndentation-height)/2;
        else
          rect.top=Rect.top+TextIndentation;
        rect.right=Rect.right-TextIndentation;
        rect.bottom=Rect.bottom-TextIndentation;

        DrawText(PageControl->Canvas->Handle,PageControl->Pages[TabIndex]->Caption.c_str(),-1,&rect,DT_CENTER|DT_WORDBREAK);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PageControlResize(TObject *Sender)
{
   TPageControl *PageControl=0;

   if(PageControl=dynamic_cast<TPageControl *>(Sender))
     {
        if(PageControl->Tag!=PageControl->Width)
          {
             int OldPageControlWidth=PageControl->Tag;

             PageControl->Tag=PageControl->Width;
             if(OldPageControlWidth)
               PageControl->TabWidth=PageControl->TabWidth*(PageControl->Width/(double)OldPageControlWidth);
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CheckListBox1MouseMove(TObject *Sender, TShiftState Shift, int X, int Y)
{
   return;
   
   AnsiString
     Mess="CheckListBox OnMouseMove X="+IntToStr(X)+" Y="+IntToStr(Y);

   static int
     xx=-1,
     yy=-1;

   bool
     Changed=false;

   int
     CurrIndex=CheckListBox1->ItemAtPos(Point(X,Y),true);

   Mess+=" ItemAtPos="+IntToStr(CurrIndex);

   if(xx!=X)
     {
        xx=X;
        Changed=true;
     }
   if(yy!=Y)
     {
        yy=Y;
        Changed=true;
     }

   if(Changed)
     RichEdit->Lines->Add(Mess);

   if(CurrIndex!=-1)
     {
        if(CheckListBoxItemIndex!=CurrIndex)
          {
             CheckListBoxItemIndex=CurrIndex;
             Application->CancelHint();
             CheckListBox1->Hint=CheckListBox1->Items->Strings[CheckListBoxItemIndex];
          }
     }
   else
     CheckListBox1->Hint="ItemAtPos="+IntToStr(CurrIndex);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CheckListBox1Click(TObject *Sender)
{
   AnsiString
     Mess="CheckListBox OnClick";

   RichEdit->Lines->Add(Mess);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CheckListBox1ClickCheck(TObject *Sender)
{
   AnsiString
     Mess="CheckListBox OnClickCheck";

   RichEdit->Lines->Add(Mess);

   for(int idx=0; idx<CheckListBox1->Items->Count; ++idx)
      //if(CheckListBox1->State[idx]==cbChecked && idx!=CheckListBox1->ItemIndex)
      //  CheckListBox1->State[idx]=cbUnchecked;
      if(CheckListBox1->Checked[idx] && idx!=CheckListBox1->ItemIndex)
        CheckListBox1->Checked[idx]=false;

}
//---------------------------------------------------------------------------

