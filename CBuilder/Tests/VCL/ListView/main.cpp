//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner): TForm(Owner)
{
   ColumnToSort=0;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   TListColumn *NewColumn;
   TListItem *item;

   NewColumn=ListViewSort->Columns->Add();
   NewColumn->Caption="Column #0";
   NewColumn->Width=100;
   NewColumn=ListViewSort->Columns->Add();
   NewColumn->Caption="Column #1";
   NewColumn->Width=100;
   NewColumn=ListViewSort->Columns->Add();
   NewColumn->Caption="Column #2";
   NewColumn->Width=100;

   char a='Z';
   item=ListViewSort->Items->Add();
   item->Caption=AnsiString(a--);
   item->SubItems->Add(AnsiString(a--));
   item->SubItems->Add(AnsiString(a--));
   item->SubItems->Add(AnsiString(a--));

   a='S';
   item=ListViewSort->Items->Add();
   item->Caption=AnsiString(a++);
   item->SubItems->Add(AnsiString(a++));
   item->SubItems->Add(AnsiString(a++));
   item->SubItems->Add(AnsiString(a++));

   a='L';
   item=ListViewSort->Items->Add();
   item->Caption=AnsiString(a--);
   item->SubItems->Add(AnsiString(a--));
   item->SubItems->Add(AnsiString(a--));
   item->SubItems->Add(AnsiString(a--));

   a='F';
   item=ListViewSort->Items->Add();
   item->Caption=AnsiString(a++);
   item->SubItems->Add(AnsiString(a++));
   item->SubItems->Add(AnsiString(a++));
   item->SubItems->Add(AnsiString(a++));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{

  TListColumn *NewColumn;
  TListItem *item;
  int i;

  if(!Table1->Active)
    Table1->Open();

  NewColumn=ListView1->Columns->Add();
  NewColumn->Caption="Items Caption";
  NewColumn->Width=100;
  NewColumn=ListView1->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;
  NewColumn=ListView1->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;
  NewColumn=ListView1->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;

  NewColumn=ListView2->Columns->Add();
  NewColumn->Caption="Items Caption";
  NewColumn->Width=100;
  NewColumn=ListView2->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;
  NewColumn=ListView2->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;
  NewColumn=ListView2->Columns->Add();
  NewColumn->Caption="Items SubItems";
  NewColumn->Width=100;

  for(Table1->First(),i=0;!Table1->Eof;Table1->Next(),i++)
     {
        item=ListView1->Items->Add();
        item->Caption="Items Caption";
        item->SubItems->Add(Table1->FieldByName("Seria")->AsString);
        item->SubItems->Add(Table1->FieldByName("Polis_No")->AsInteger);
        item->SubItems->Add(Table1->FieldByName("Address")->AsString);
        item->ImageIndex = i<ImageListSmallImages->AllocBy ? i : 0; //Caption Icons (dafault ImageList[0] 4 all)
        item->StateIndex = i<ImageListStateImages->AllocBy ? i : 0; //Caption Icons
        item->SubItemImages[0] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
        item->SubItemImages[1] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
        item->SubItemImages[2] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
     }

  for(Table1->First(),i=0;!Table1->Eof;Table1->Next(),i++)
     {
        item=ListView2->Items->Add();
        item->Caption="Items Caption";
        item->SubItems->Add(Table1->FieldByName("Seria")->AsString);
        item->SubItems->Add(Table1->FieldByName("Polis_No")->AsInteger);
        item->SubItems->Add(Table1->FieldByName("Address")->AsString);
        item->ImageIndex = i<ImageListSmallImages->AllocBy ? i : 0; //Caption Icons (dafault ImageList[0] 4 all)
        item->StateIndex = i<ImageListStateImages->AllocBy ? i : 0; //Caption Icons
        item->SubItemImages[0] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
        item->SubItemImages[1] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
        item->SubItemImages[2] = i<ImageListSmallImages->AllocBy ? i : 0; // SubItems[i] Icons
     }

  item->Caption="Caption";
  item->SubItems->Strings[0]="Strings[0]";
  item->SubItems->Strings[1]="Strings[1]";
  item->SubItems->Strings[2]="Strings[2]";
  item=ListView1->Items->Item[0];
  item->Focused=true;
  item->Selected=true;

  TreeView1->Items->Clear();

  TreeView1->Items->Add(0,"Level [0] (Root)");
  TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");
  TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");
  TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");

  int SubLevel0=0,SubLevel1,SubLevel2,SubLevel3;
  TTreeNode *pTN;

  pTN=TreeView1->Items->GetFirstNode();
  while(pTN)
     {
        for(i=0; i<3; i++)
           {
              TreeView1->Items->AddChild(pTN,"SubLevel ["+IntToStr(SubLevel0)+"] Items#"+IntToStr(i+1));
              pTN->ImageIndex=1;
              pTN->SelectedIndex=2;
              pTN->StateIndex=3;
           }
        pTN=pTN->getNextSibling();
     }

  pTN=TreeView1->Items->GetFirstNode();
  while(pTN)
     {
        for(SubLevel1=0; SubLevel1<3; SubLevel1++)
           for(i=0; i<3; i++)
              {
                 TreeView1->Items->AddChild(pTN->Item[SubLevel1],"SubLevel ["+IntToStr(SubLevel0)+"]["+IntToStr(SubLevel1)+"] Items#"+IntToStr(i+1));
                 pTN->Item[SubLevel1]->ImageIndex=1;
                 pTN->Item[SubLevel1]->SelectedIndex=2;
                 pTN->Item[SubLevel1]->StateIndex=3;
              }
        pTN=pTN->getNextSibling();
     }

  pTN=TreeView1->Items->GetFirstNode();
  while(pTN)
     {
        for(SubLevel1=0; SubLevel1<3; SubLevel1++)
           for(SubLevel2=0; SubLevel2<3; SubLevel2++)
              for(i=0; i<3; i++)
                 {
                    TreeView1->Items->AddChild(pTN->Item[SubLevel1]->Item[SubLevel2],"SubLevel ["+IntToStr(SubLevel0)+"]["+IntToStr(SubLevel1)+"]["+IntToStr(SubLevel2)+"] Items#"+IntToStr(i+1));
                    pTN->Item[SubLevel1]->Item[SubLevel2]->ImageIndex=1;
                    pTN->Item[SubLevel1]->Item[SubLevel2]->SelectedIndex=2;
                    pTN->Item[SubLevel1]->Item[SubLevel2]->StateIndex=3;
                 }
        pTN=pTN->getNextSibling();
     }

  pTN=TreeView1->Items->GetFirstNode();
  while(pTN)
     {
        for(SubLevel1=0; SubLevel1<3; SubLevel1++)
           for(SubLevel2=0; SubLevel2<3; SubLevel2++)
              for(SubLevel3=0; SubLevel3<3; SubLevel3++)
                 for(i=0; i<3; i++)
                    {
                       TreeView1->Items->AddChild(pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3],"SubLevel ["+IntToStr(SubLevel0)+"]["+IntToStr(SubLevel1)+"]["+IntToStr(SubLevel2)+"]["+IntToStr(SubLevel3)+"] Items#"+IntToStr(i+1));
                       pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->ImageIndex=1;
                       pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->SelectedIndex=2;
                       pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->StateIndex=3;
                    }
        pTN=pTN->getNextSibling();
     }

  pTN=TreeView1->Items->GetFirstNode();
  while(pTN)
     {
        for(SubLevel1=0; SubLevel1<3; SubLevel1++)
           for(SubLevel2=0; SubLevel2<3; SubLevel2++)
              for(SubLevel3=0; SubLevel3<3; SubLevel3++)
                 for(int SubLevel4=0; SubLevel4<3; SubLevel4++)
                    for(i=0; i<3; i++)
                       {
                          pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->Item[SubLevel4]->ImageIndex=1;
                          pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->Item[SubLevel4]->SelectedIndex=2;
                          pTN->Item[SubLevel1]->Item[SubLevel2]->Item[SubLevel3]->Item[SubLevel4]->StateIndex=3;
                       }
        pTN=pTN->getNextSibling();
     }

  TreeView1->FullExpand();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListView1SelectItem(TObject *Sender,
      TListItem *Item, bool Selected)
{
//   AnsiString Mess;
   if(Selected)
     {
//        Mess="OnSelectItem. Select Row#"+IntToStr(ListView1->Selected->Index);
//        ShowMessage(Mess.c_str());
        ListView2->Items->Item[ListView1->Selected->Index]->Selected=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
//   if(Table1->Active)
//     Table1->Close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeView1DblClick(TObject *Sender)
{
   ShowMessage("AbsoluteIndex="+IntToStr(TreeView1->Selected->AbsoluteIndex)+"\r\nIndex="+IntToStr(TreeView1->Selected->Index)+"\r\nData="+TreeView1->Selected->Text);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonShowIndexClick(TObject *Sender)
{
   if(ListViewSort->Selected)
     RichEdit1->Lines->Add("ListViewSort->Selected->Index="+IntToStr(ListViewSort->Selected->Index));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonAddClick(TObject *Sender)
{
   static char a='B';
   TListItem *item;

   item=ListViewSort->Items->Add();
   item->Caption=AnsiString(a++);
   a = a > 'Z' ? 'A' : a;
   item->SubItems->Add(AnsiString(a++));
   a = a > 'Z' ? 'A' : a;
   item->SubItems->Add(AnsiString(a++));
   a = a > 'Z' ? 'A' : a;
   item->SubItems->Add(AnsiString(a++));
   a = a > 'Z' ? 'A' : a;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonInsertClick(TObject *Sender)
{
   static char a='b';
   TListItem *item;

   item=ListViewSort->Items->Insert(0);
   item->Caption=AnsiString(a++);
   a = a > 'z' ? 'a' : a;
   item->SubItems->Add(AnsiString(a++));
   a = a > 'z' ? 'a' : a;
   item->SubItems->Add(AnsiString(a));
   a = a > 'z' ? 'a' : a;
   item->SubItems->Add(AnsiString(a++));
   a = a > 'z' ? 'a' : a;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListViewSortColumnClick(TObject *Sender, TListColumn *Column)
{
   ColumnToSort=Column->Index;
   ((TCustomListView *)Sender)->AlphaSort();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListViewSortCompare(TObject *Sender, TListItem *Item1, TListItem *Item2, int Data, int &Compare)
{
   if(ColumnToSort==0)
     Compare=CompareText(Item1->Caption,Item2->Caption);
   else
     {
        int ix=ColumnToSort-1;
        Compare=CompareText(Item1->SubItems->Strings[ix],Item2->SubItems->Strings[ix]);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonChangeClick(TObject *Sender)
{
   if(ListViewSort->Selected)
     ListViewSort->Selected->Caption="~";
}
//---------------------------------------------------------------------------

