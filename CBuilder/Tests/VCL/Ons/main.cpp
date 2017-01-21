//---------------------------------------------------------------------------

#include <vcl.h>
#include <vector>
#include <limits>
#include <DateUtils.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#pragma pack(push,1)

struct AnyStruct
{
   AnsiString
     First,
     Second,
     Third;

   __fastcall AnyStruct(AnsiString aFirst="", AnsiString aSecond="", AnsiString aThird=""):
   First(aFirst),
   Second(aSecond),
   Third(aThird)
   {};
};
#pragma pack(pop)

std::vector<AnyStruct> ListOfList;

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   ColorOfComboBox=clMaroon;
   ColorOfPageControl=clGreen;
   ColorOfTabSheet=clOlive;
   ColorOfListView=clNavy;
   ColorOfDateTimePicker=clPurple;
   ColorOfEdit=clTeal;
   ColorOfCheckBox=clGray;
   ColorOfUpDown=clSilver;
   ColorOfOnIdle=clRed;
   ColorOfTreeView=clLime;

   //Application->OnIdle=AppOnIdle;
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TForm
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormActivate(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnActivate");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCanResize(TObject *Sender, int &NewWidth, int &NewHeight, bool &Resize)
{
   Memo1->Lines->Add("MainForm OnCanResize");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   //
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCloseQuery(TObject *Sender, bool &CanClose)
{
   //
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormConstrainedResize(TObject *Sender, int &MinWidth, int &MinHeight, int &MaxWidth, int &MaxHeight)
{
   Memo1->Lines->Add("MainForm OnConstrainedResize");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnCreate");

   unsigned int
     b4=0,
     after=0;

   int
     _b4=0,
     _after=0;


   short
     __b4=0,
     __after=0;

   b4=4294967294; // !4294967295
   ComboBox1->Items->AddObject("Line1",(TObject *)b4); // sizeof(ComboBox1->Items->Objects[0]) == 4 byte
   after=(unsigned int)ComboBox1->Items->Objects[0];
   if(b4 != after)
     ShowMessage(IntToStr(b4)+"\r\n"+IntToStr(after));

   _b4=2147483647; //2147483648
   ComboBox1->Items->AddObject("Line2",(TObject *)_b4);
   _after=(int)ComboBox1->Items->Objects[1];
   if(_b4 != _after)
     ShowMessage(IntToStr(_b4)+"\r\n"+IntToStr(_after));

// WINUSER.H
// /*
//  * Combo Box return Values
// */
// #define CB_OKAY             0
// #define CB_ERR              (-1)
// #define CB_ERRSPACE         (-2)

   __b4=-std::numeric_limits<short>::max();
   ComboBox1->Items->AddObject("Line3",(TObject *)__b4);
   __after=(short)ComboBox1->Items->Objects[2];
   if(__b4 != __after)
     ShowMessage(IntToStr(__b4)+"\r\n"+IntToStr(__after));

   ComboBox1->Items->Add("Line4");
   ComboBox1->Items->Add("aaaa");
   ComboBox1->Items->Add("abbb");
   ComboBox1->Items->Add("abcc");
   ComboBox1->Items->Add("abcd");

   ComboBox2->Items->Add("Line1");
   ComboBox2->Items->Add("Line2");
   ComboBox2->Items->Add("Line3");
   ComboBox2->Items->Add("Line4");
   ComboBox2->Items->Add("aaaa");
   ComboBox2->Items->Add("abbb");
   ComboBox2->Items->Add("abcc");
   ComboBox2->Items->Add("abcd");

   ComboBox1->ItemIndex=3;
   ComboBox2->Text="aaaa";

   ListView1->Items->Count=64;

   TreeView1->Items->Clear();

   TreeView1->Items->Add(0,"Level [0] (Root)");
   TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");
   TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");
   TreeView1->Items->Add(TreeView1->Items->Item[0],"Level [0] (Root)");

   int
     i,
     SubLevel0=0,
     SubLevel1,
     SubLevel2,
     SubLevel3;

   TTreeNode
     *pTN;

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

   //EditSource->Text="Text";

   PageControl1->ActivePage=TabSheet1;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDeactivate(TObject *Sender)
{
   //
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDestroy(TObject *Sender)
{
   //
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormHide(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnHide");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormPaint(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnPaint");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormResize(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnResize");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   Memo1->Lines->Add("MainForm OnShow");
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TComboBox
//---------------------------------------------------------------------------
void __fastcall TMainForm::ComboBoxChange(TObject *Sender)
{
   TComboBox *ComboBox=0;

   if((ComboBox=dynamic_cast<TComboBox *>(Sender)))
     {
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+" OnChange",ColorOfComboBox,Graphics::TFontStyles()<<fsBold<<fsUnderline);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->ItemIndex="+IntToStr(ComboBox->ItemIndex),ColorOfComboBox);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->Text="+ComboBox->Text,ColorOfComboBox);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ComboBoxClick(TObject *Sender)
{
   TComboBox *ComboBox=0;

   if((ComboBox=dynamic_cast<TComboBox *>(Sender)))
     {
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+" OnClick",ColorOfComboBox,Graphics::TFontStyles()<<fsBold<<fsUnderline);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->ItemIndex="+IntToStr(ComboBox->ItemIndex),ColorOfComboBox);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->Text="+ComboBox->Text,ColorOfComboBox);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ComboBoxEnter(TObject *Sender)
{
   TComboBox *ComboBox=0;

   if((ComboBox=dynamic_cast<TComboBox *>(Sender)))
     {
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+" OnEnter",ColorOfComboBox,Graphics::TFontStyles()<<fsBold<<fsUnderline);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->ItemIndex="+IntToStr(ComboBox->ItemIndex),ColorOfComboBox);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->Text="+ComboBox->Text,ColorOfComboBox);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ComboBoxExit(TObject *Sender)
{
   TComboBox *ComboBox=0;

   if((ComboBox=dynamic_cast<TComboBox *>(Sender)))
     {
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+" OnExit",ColorOfComboBox,Graphics::TFontStyles()<<fsBold<<fsUnderline);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->ItemIndex="+IntToStr(ComboBox->ItemIndex),ColorOfComboBox);
        WriteToLog("ComboBox"+IntToStr(ComboBox->Tag)+"->Text="+ComboBox->Text,ColorOfComboBox);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonItemIndexClick(TObject *Sender)
{
   ComboBox1->ItemIndex=StrToIntDef(EditComboBoxValue->Text,0);
   WriteToLog("ComboBox1->ItemIndex="+IntToStr(ComboBox1->ItemIndex),ColorOfComboBox);
   WriteToLog("ComboBox1->Text="+ComboBox1->Text,ColorOfComboBox);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonTextClick(TObject *Sender)
{
   ComboBox1->Text=EditComboBoxValue->Text;
   WriteToLog("ComboBox1->Text="+ComboBox1->Text,ColorOfComboBox);
   WriteToLog("ComboBox1->ItemIndex="+IntToStr(ComboBox1->ItemIndex),ColorOfComboBox);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonTextOfClick(TObject *Sender)
{
   int idx=ComboBox1->Items->IndexOf(EditComboBoxValue->Text);

   ComboBox1->ItemIndex=idx;
   WriteToLog("ComboBox1->ItemIndex="+IntToStr(ComboBox1->ItemIndex),ColorOfComboBox);
   WriteToLog("ComboBox1->Text="+ComboBox1->Text,ColorOfComboBox);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonClearClick(TObject *Sender)
{
   int no=StrToIntDef(EditComboBoxValue->Text,0);

   if(no)
     ComboBox1->Clear();
   else
     ComboBox1->Items->Clear();
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TPageControl
//---------------------------------------------------------------------------
void __fastcall TMainForm::PageControl1Change(TObject *Sender)
{
   WriteToLog("PageControl OnChange",ColorOfPageControl,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("PageControl1->TabIndex="+IntToStr(PageControl1->TabIndex),ColorOfPageControl);

   ComboBox1->Parent=PageControl1->Pages[PageControl1->TabIndex];
   ComboBox1->Parent=PageControl1->ActivePage;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PageControlDrawTab(TCustomTabControl *Control, int TabIndex, const TRect &Rect, bool Active)
{
   WriteToLog("PageControl OnDrawTab",ColorOfPageControl,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("TabIndex="+IntToStr(TabIndex),ColorOfPageControl);
   WriteToLog("Rect left="+IntToStr(Rect.left)+" top="+IntToStr(Rect.top)+" right="+IntToStr(Rect.right)+" bottom="+IntToStr(Rect.bottom),ColorOfPageControl);
   WriteToLog("Active="+BoolToStr(Active,true),ColorOfPageControl);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TTabSheet
//---------------------------------------------------------------------------
void __fastcall TMainForm::TabSheetEnter(TObject *Sender)
{
   TTabSheet *TabSheet=0;

   if(!(TabSheet=dynamic_cast<TTabSheet *>(Sender)))
     return;

   WriteToLog(TabSheet->Name+" OnEnter",ColorOfTabSheet,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("PageControl1->TabIndex="+IntToStr(PageControl1->TabIndex),ColorOfTabSheet);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetTabSheetClick(TObject *Sender)
{
   WriteToLog("ButtonSetTabSheetClick",ColorOfTabSheet);

   int no=StrToIntDef(EditComboBoxValue->Text,0);

   if(no<PageControl1->PageCount)
     PageControl1->ActivePageIndex=no;
   else
     PageControl1->ActivePage=TabSheet1;
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TListView
//---------------------------------------------------------------------------
void __fastcall TMainForm::ListView1Data(TObject *Sender, TListItem *Item)
{
   TListView *lv=dynamic_cast<TListView *>(Sender);
   //TListItem *li=0;

   WriteToLog("ListView OnData",ColorOfListView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("Item->Index="+IntToStr(Item->Index),ColorOfListView);
   if(lv)
     {
        WriteToLog("ListView->Items->Count="+IntToStr(lv->Items->Count),ColorOfListView);
        //li=lv->TopItem;
        WriteToLog("ListView->VisibleRowCount="+IntToStr(lv->VisibleRowCount),ColorOfListView);
     }
   WriteToLog("ListOfList.size()="+IntToStr(ListOfList.size()),ColorOfListView);

   if(Item->Index<ListOfList.size())
     {
        Item->Caption=ListOfList[Item->Index].First;
        Item->SubItems->Add(ListOfList[Item->Index].Second);
        Item->SubItems->Add(ListOfList[Item->Index].Third);
     }
   else
     {
        AnyStruct AnyStruct;

        AnyStruct.First="1st "+IntToStr(Item->Index);
        AnyStruct.Second="2nd "+IntToStr(Item->Index);
        AnyStruct.Third="3rd "+IntToStr(Item->Index);
        ListOfList.push_back(AnyStruct);

        Item->Caption=ListOfList[Item->Index].First;
        Item->SubItems->Add(ListOfList[Item->Index].Second);
        Item->SubItems->Add(ListOfList[Item->Index].Third);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListView1DataFind(TObject *Sender, TItemFind Find, const AnsiString FindString, const TPoint &FindPosition, Pointer FindData, int StartIndex, TSearchDirection Direction, bool Wrap, int &Index)
{
   WriteToLog("ListView OnDataFind",ColorOfListView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListView1DataHint(TObject *Sender, int StartIndex, int EndIndex)
{
   WriteToLog("ListView OnDataHint",ColorOfListView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("StartIndex="+IntToStr(StartIndex)+" EndIndex="+IntToStr(EndIndex),ColorOfListView);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListView1DataStateChange(TObject *Sender, int StartIndex, int EndIndex, TItemStates OldState, TItemStates NewState)
{
   WriteToLog("ListView OnDataStateChange",ColorOfListView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::WriteToLog(AnsiString aStr, TColor aColor, Graphics::TFontStyles aFontStyle)
{
   int SelStart=Memo1->SelStart,SelEnd;

   Memo1->Lines->Add(aStr);
   SelEnd=Memo1->SelStart;
   Memo1->SelStart=SelStart;
   Memo1->SelLength=SelEnd-SelStart;
   Memo1->SelAttributes->Style=aFontStyle;
   Memo1->SelAttributes->Color=aColor;
   Memo1->SelStart=SelEnd;
   Memo1->SelLength=0;
   Memo1->SelAttributes->Assign(Memo1->DefAttributes);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DateTimePicker1Change(TObject *Sender)
{
   WriteToLog("DateTimePicker1 OnChange",ColorOfDateTimePicker,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog(DateTimePicker1->DateTime.DateTimeString()+" "+FloatToStr(DateTimePicker1->DateTime),ColorOfDateTimePicker);
   DateTimePicker2->DateTime=DateTimePicker1->DateTime;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DateTimePicker2Change(TObject *Sender)
{
   WriteToLog("DateTimePicker2 OnChange",ColorOfDateTimePicker,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   DateTimePicker1->DateTime=DateTimePicker2->DateTime;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonNowClick(TObject *Sender)
{
   static TDate
     v=-53780; //min 4 DateTimePicker == TDate(1752,10,1)
   //static TDate v=-693593; min 4 TDate == TDate(1,1,1);

   WriteToLog("ButtonNowClick",ColorOfDateTimePicker);
   //DateTimePicker1->DateTime=DateOf(Now());
   DateTimePicker1->DateTime=v+366;
   DateTimePicker2->DateTime=DateOf(Now());
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::EditSourceChange(TObject *Sender)
{
   TEdit
     *Edit;

   if(!(Edit=dynamic_cast<TEdit *>(Sender)))
     return;

   WriteToLog(Edit->Name+" OnChange",ColorOfEdit,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   if(Edit->Name=="EditSource")
     EditDestination->Text=Edit->Text;
   if(Edit->Name=="EditSrc")
     WriteToLog(Edit->Name+" OnChange Text="+Edit->Text+" Position="+IntToStr(UpDownEditSrc->Position),ColorOfEdit);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetEditClick(TObject *Sender)
{
   WriteToLog("ButtonSetEditClick",ColorOfEdit);
   EditDestination->Text=EditSrc->Text;

   unsigned char
     Buff[0x0aaff];

   int
     ErrNo;

   AnsiString
     Mess;

   setmem(Buff,0x0aaff,0);
   ErrNo=SendMessage(EditSource->Handle,WM_GETTEXT,0x0aaff,(LPARAM)Buff);

   setmem(Buff,0x0aaff,0);
   if(!(ErrNo=GetWindowText(EditSource->Handle,Buff,0x0aaff)))
     {
        ErrNo=GetLastError();
        Mess="Error: "+IntToStr(ErrNo)+"\nMessage: "+SysErrorMessage(ErrNo);
     }

   strcpy(Buff,"qwerty");
   ErrNo=SendMessage(EditSource->Handle,WM_SETTEXT,0,(LPARAM)Buff);

   *((WORD *)Buff)=0x0aaff;
   ErrNo=SendMessage(EditSource->Handle,EM_GETLINE,0,(LPARAM)Buff);

   EditSource->SetFocus();
   EditSource->SelStart=3;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CheckBoxSourceClick(TObject *Sender)
{
   TCheckBox *CheckBox;

   if(!(CheckBox=dynamic_cast<TCheckBox *>(Sender)))
     return;

   WriteToLog(CheckBox->Name+" OnClick",ColorOfCheckBox,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   if(CheckBox->Name=="CheckBoxSource")
     CheckBoxDestination->Checked=CheckBox->Checked;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonCheckBoxClick(TObject *Sender)
{
   WriteToLog("ButtonCheckBoxClick",ColorOfCheckBox);
   CheckBoxDestination->Checked=CheckBoxSrc->Checked;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetEditOnAnotherTabSheetClick(TObject *Sender)
{
   WriteToLog("ButtonSetEditOnAnotherTabSheetClick",ColorOfEdit);

   EditDestination->Text=EditComboBoxValue->Text;

   UpDownEditSrc->Position=StrToIntDef(EditComboBoxValue->Text,13);
   EditSrc->Text=EditComboBoxValue->Text;
   UpDownEditSrc->Position=StrToIntDef(EditComboBoxValue->Text,13);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UpDownEditSrcChanging(TObject *Sender, bool &AllowChange)
{
   WriteToLog("UpDownEditSrc OnChanging",ColorOfUpDown,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   AnsiString Mess="AllowChange="+BoolToStr(AllowChange,true)+" Position="+IntToStr(UpDownEditSrc->Position);

   WriteToLog(Mess,ColorOfUpDown);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UpDownEditSrcChangingEx(TObject *Sender, bool &AllowChange, short NewValue, TUpDownDirection Direction)
{
   WriteToLog("UpDownEditSrc OnChangingEx",ColorOfUpDown,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   AnsiString Mess="AllowChange="+BoolToStr(AllowChange,true)+" NewValue="+IntToStr(NewValue)+" Direction=";

   switch(Direction)
     {
        case updNone :
          {
             Mess+="updNone";
             break;
          }
        case updUp :
          {
             Mess+="updUp";
             break;
          }
        case updDown :
          {
             Mess+="updDown";
             break;
          }
        default :
          {
             Mess+="Unknown";
          }
     }

   Mess+=" Position="+IntToStr(UpDownEditSrc->Position);

   WriteToLog(Mess,ColorOfUpDown);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UpDownEditSrcClick(TObject *Sender, TUDBtnType Button)
{
   WriteToLog("UpDownEditSrc OnClick",ColorOfUpDown,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   AnsiString Mess="Button=";

   switch(Button)
     {
        case btNext :
          {
             Mess+="btNext";
             break;
          }
        case btPrev :
          {
             Mess+="btPrev";
             break;
          }
        default :
          {
             Mess+="Unknown";
          }
     }

   Mess+=" Position="+IntToStr(UpDownEditSrc->Position);

   WriteToLog(Mess,ColorOfUpDown);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetUpDownOnAnotherTabSheetClick(TObject *Sender)
{
   WriteToLog("ButtonSetUpDownOnAnotherTabSheetClick",ColorOfUpDown);
   UpDownEditSrc->Position=StrToIntDef(EditComboBoxValue->Text,13);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::AppOnIdle(TObject *Sender, bool &Done)
{
   WriteToLog("OnIdle",ColorOfOnIdle,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog(AnsiString(Sender->ClassName())+" "+BoolToStr(Done,true),ColorOfOnIdle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewAddition(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnAddition",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewAdvancedCustomDraw(TCustomTreeView *Sender, const TRect &ARect, TCustomDrawStage Stage, bool &DefaultDraw)
{
   WriteToLog("OnAdvancedCustomDraw",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewAdvancedCustomDrawItem(TCustomTreeView *Sender, TTreeNode *Node, TCustomDrawState State, TCustomDrawStage Stage, bool &PaintImages, bool &DefaultDraw)
{
   WriteToLog("OnAdvancedCustomDrawItem",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewChange(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnChange",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("Node->AbsoluteIndex="+IntToStr(Node->AbsoluteIndex)+" Node->Index="+IntToStr(Node->Index)+" Node->ImageIndex="+IntToStr(Node->ImageIndex)+" Node->Level="+IntToStr(Node->Level)+" Node->OverlayIndex="+IntToStr(Node->OverlayIndex)+" Node->SelectedIndex="+IntToStr(Node->SelectedIndex)+" Node->StateIndex="+IntToStr(Node->StateIndex)+" Node->Text="+Node->Text,ColorOfTreeView);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewChanging(TObject *Sender, TTreeNode *Node, bool &AllowChange)
{
   WriteToLog("OnChanging",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
   WriteToLog("Node->AbsoluteIndex="+IntToStr(Node->AbsoluteIndex)+" Node->Index="+IntToStr(Node->Index)+" Node->ImageIndex="+IntToStr(Node->ImageIndex)+" Node->Level="+IntToStr(Node->Level)+" Node->OverlayIndex="+IntToStr(Node->OverlayIndex)+" Node->SelectedIndex="+IntToStr(Node->SelectedIndex)+" Node->StateIndex="+IntToStr(Node->StateIndex)+" Node->Text="+Node->Text+" AllowChange="+BoolToStr(AllowChange,true),ColorOfTreeView);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewClick(TObject *Sender)
{
   WriteToLog("OnClick",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCollapsed(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnCollapsed",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCollapsing(TObject *Sender, TTreeNode *Node, bool &AllowCollapse)
{
   WriteToLog("OnCollapsing",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCompare(TObject *Sender, TTreeNode *Node1, TTreeNode *Node2, int Data, int &Compare)
{
   WriteToLog("OnCompare",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewContextPopup(TObject *Sender, TPoint &MousePos, bool &Handled)
{
   WriteToLog("OnContextPopup",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCreateNodeClass(TCustomTreeView *Sender, TTreeNodeClass &NodeClass)
{
   WriteToLog("OnCreateNodeClass",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCustomDraw(TCustomTreeView *Sender, const TRect &ARect, bool &DefaultDraw)
{
   WriteToLog("OnCustomDraw",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewCustomDrawItem(TCustomTreeView *Sender, TTreeNode *Node, TCustomDrawState State, bool &DefaultDraw)
{
   WriteToLog("OnCustomDrawItem",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewDblClick(TObject *Sender)
{
   WriteToLog("OnDblClick",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewDeletion(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnDeletion",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewDragDrop(TObject *Sender, TObject *Source, int X, int Y)
{
   WriteToLog("OnDragDrop",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept)
{
   WriteToLog("OnDragOver",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewEdited(TObject *Sender, TTreeNode *Node, AnsiString &S)
{
   WriteToLog("OnEdited",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewEditing(TObject *Sender, TTreeNode *Node, bool &AllowEdit)
{
   WriteToLog("OnEditing",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewEndDock(TObject *Sender, TObject *Target, int X, int Y)
{
   WriteToLog("OnEndDock",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewEndDrag(TObject *Sender, TObject *Target, int X, int Y)
{
   WriteToLog("OnEndDrag",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewEnter(TObject *Sender)
{
   WriteToLog("OnEnter",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewExit(TObject *Sender)
{
   WriteToLog("OnExit",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewExpanded(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnExpanded",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewExpanding(TObject *Sender, TTreeNode *Node, bool &AllowExpansion)
{
   WriteToLog("OnExpanding",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewGetImageIndex(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnGetImageIndex",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewGetSelectedIndex(TObject *Sender, TTreeNode *Node)
{
   WriteToLog("OnGetSelectedIndex",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewKeyDown(TObject *Sender, WORD &Key, TShiftState Shift)
{
   WriteToLog("OnKeyDown",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewKeyPress(TObject *Sender, char &Key)
{
   WriteToLog("OnKeyPress",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewKeyUp(TObject *Sender, WORD &Key, TShiftState Shift)
{
   WriteToLog("OnKeyUp",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
//   WriteToLog("OnMouseDown",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewMouseMove(TObject *Sender, TShiftState Shift, int X, int Y)
{
//   WriteToLog("OnMouseMove",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewMouseUp(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
//   WriteToLog("OnMouseUp",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewStartDock(TObject *Sender, TDragDockObject *&DragObject)
{
   WriteToLog("OnStartDock",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::TreeViewStartDrag(TObject *Sender, TDragObject *&DragObject)
{
   WriteToLog("OnStartDrag",ColorOfTreeView,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonFocusedClick(TObject *Sender)
{
   ShowMessage(ComboBox1->Focused() ? "true" : "false");
}
//---------------------------------------------------------------------------

