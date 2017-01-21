//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "Frame"
#pragma resource "*.dfm"

void __fastcall ShowTree(TControl *Control, TTreeNode *pTN);
void __fastcall ShowControl_(TControl *Control);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ShowTreeButtonClick(TObject *Sender)
{
   TreeView1->Items->Clear();
   ShowTree(MainForm,TreeView1->Items->GetFirstNode());
   TreeView1->FullExpand();
}
//---------------------------------------------------------------------------

void __fastcall ShowTree(TControl *Control, TTreeNode *pTN)
{
   TWinControl
     *tmpWinControl=dynamic_cast<TWinControl *>(Control);

   if(!tmpWinControl)
     return;

   AnsiString
     tmp=tmpWinControl->Name;

   if(tmpWinControl->Owner && !tmpWinControl->Owner->Name.IsEmpty())
     tmp+=" (Owner="+tmpWinControl->Owner->Name+")";

   if(tmpWinControl->Parent && !tmpWinControl->Parent->Name.IsEmpty())
     tmp+=" (Parent="+tmpWinControl->Parent->Name+")";

   tmp+=" (Visible="+BoolToStr(tmpWinControl->Visible,true)+")";
   tmp+=" (Showing="+BoolToStr(tmpWinControl->Showing,true)+")";
   tmp+=" (IsWindowVisible="+BoolToStr(IsWindowVisible(tmpWinControl->Handle),true)+")";

   TTreeNode *NewpTN=MainForm->TreeView1->Items->AddChild(pTN,tmp);

   for(int i=0; i<tmpWinControl->ControlCount; i++)
      ShowTree(tmpWinControl->Controls[i],NewpTN);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ShowControlButtonClick(TObject *Sender)
{
   ShowControlMemo->Lines->Clear();
   ShowControl_(MainForm);
}
//---------------------------------------------------------------------------

void __fastcall ShowControl_(TControl *Control)
{
   TWinControl *tmpWinControl=dynamic_cast<TWinControl *>(Control);

   if(!tmpWinControl)
     return;

   if(!tmpWinControl->ControlCount && tmpWinControl->Enabled)
     {
        AnsiString tmp=tmpWinControl->Name;

        TEdit *tmpEdit=(TEdit *)Control;

        tmp+="->Text="+tmpEdit->Text;
        MainForm->ShowControlMemo->Lines->Add(tmp);
     }
   for(int i=0; i<tmpWinControl->ControlCount; i++)
      ShowControl_(tmpWinControl->Controls[i]);
}
//---------------------------------------------------------------------------

