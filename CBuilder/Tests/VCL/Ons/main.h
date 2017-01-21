//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ImgList.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControl1;
        TTabSheet *TabSheet1;
        TComboBox *ComboBox1;
        TComboBox *ComboBox2;
        TEdit *EditComboBoxValue;
        TTabSheet *TabSheet2;
        TRichEdit *Memo1;
        TGroupBox *GroupBoxComboBox;
        TButton *ButtonItemIndex;
        TButton *ButtonText;
        TButton *ButtonTextOf;
        TButton *ButtonClear;
        TButton *ButtonSetTabSheet;
        TTabSheet *TabSheet3;
        TListView *ListView1;
        TGroupBox *GroupBoxDateTimePicker;
        TDateTimePicker *DateTimePicker1;
        TDateTimePicker *DateTimePicker2;
        TButton *ButtonNow;
        TGroupBox *GroupBoxEdit;
        TEdit *EditSource;
        TEdit *EditDestination;
        TLabel *Label1;
        TButton *ButtonSetEdit;
        TEdit *EditSrc;
        TGroupBox *GroupBoxCheckBox;
        TCheckBox *CheckBoxSource;
        TLabel *Label2;
        TCheckBox *CheckBoxDestination;
        TCheckBox *CheckBoxSrc;
        TButton *ButtonCheckBox;
        TButton *ButtonSetEditOnAnotherTabSheet;
        TUpDown *UpDownEditSrc;
        TButton *ButtonSetUpDownOnAnotherTabSheet;
        TTabSheet *TabSheet4;
        TTreeView *TreeView1;
        TImageList *ImageListSmallImages;
        TImageList *ImageListStateImages;
        TButton *ButtonFocused;
        void __fastcall ComboBoxChange(TObject *Sender);
        void __fastcall ComboBoxClick(TObject *Sender);
        void __fastcall ComboBoxEnter(TObject *Sender);
        void __fastcall ComboBoxExit(TObject *Sender);
        void __fastcall ButtonItemIndexClick(TObject *Sender);
        void __fastcall ButtonTextClick(TObject *Sender);
        void __fastcall ButtonTextOfClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall PageControl1Change(TObject *Sender);
        void __fastcall PageControlDrawTab(TCustomTabControl *Control, int TabIndex, const TRect &Rect, bool Active);
        void __fastcall FormActivate(TObject *Sender);
        void __fastcall FormCanResize(TObject *Sender, int &NewWidth, int &NewHeight, bool &Resize);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
        void __fastcall FormConstrainedResize(TObject *Sender, int &MinWidth, int &MinHeight, int &MaxWidth, int &MaxHeight);
        void __fastcall FormDeactivate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall FormHide(TObject *Sender);
        void __fastcall FormPaint(TObject *Sender);
        void __fastcall FormResize(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall ButtonClearClick(TObject *Sender);
        void __fastcall TabSheetEnter(TObject *Sender);
        void __fastcall ButtonSetTabSheetClick(TObject *Sender);
        void __fastcall ListView1Data(TObject *Sender, TListItem *Item);
        void __fastcall ListView1DataFind(TObject *Sender, TItemFind Find, const AnsiString FindString, const TPoint &FindPosition, Pointer FindData, int StartIndex, TSearchDirection Direction, bool Wrap, int &Index);
        void __fastcall ListView1DataHint(TObject *Sender, int StartIndex, int EndIndex);
        void __fastcall ListView1DataStateChange(TObject *Sender, int StartIndex, int EndIndex, TItemStates OldState, TItemStates NewState);
        void __fastcall DateTimePicker1Change(TObject *Sender);
        void __fastcall DateTimePicker2Change(TObject *Sender);
        void __fastcall ButtonNowClick(TObject *Sender);
        void __fastcall EditSourceChange(TObject *Sender);
        void __fastcall ButtonSetEditClick(TObject *Sender);
        void __fastcall CheckBoxSourceClick(TObject *Sender);
        void __fastcall ButtonCheckBoxClick(TObject *Sender);
        void __fastcall ButtonSetEditOnAnotherTabSheetClick(TObject *Sender);
        void __fastcall UpDownEditSrcChanging(TObject *Sender, bool &AllowChange);
        void __fastcall UpDownEditSrcChangingEx(TObject *Sender, bool &AllowChange, short NewValue, TUpDownDirection Direction);
        void __fastcall UpDownEditSrcClick(TObject *Sender, TUDBtnType Button);
        void __fastcall ButtonSetUpDownOnAnotherTabSheetClick(TObject *Sender);
        void __fastcall TreeViewAddition(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewAdvancedCustomDraw(
          TCustomTreeView *Sender, const TRect &ARect,
          TCustomDrawStage Stage, bool &DefaultDraw);
        void __fastcall TreeViewAdvancedCustomDrawItem(
          TCustomTreeView *Sender, TTreeNode *Node, TCustomDrawState State,
          TCustomDrawStage Stage, bool &PaintImages, bool &DefaultDraw);
        void __fastcall TreeViewChange(TObject *Sender, TTreeNode *Node);
        void __fastcall TreeViewChanging(TObject *Sender, TTreeNode *Node,
          bool &AllowChange);
        void __fastcall TreeViewClick(TObject *Sender);
        void __fastcall TreeViewCollapsed(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewCollapsing(TObject *Sender,
          TTreeNode *Node, bool &AllowCollapse);
        void __fastcall TreeViewCompare(TObject *Sender, TTreeNode *Node1,
          TTreeNode *Node2, int Data, int &Compare);
        void __fastcall TreeViewContextPopup(TObject *Sender,
          TPoint &MousePos, bool &Handled);
        void __fastcall TreeViewCreateNodeClass(TCustomTreeView *Sender,
          TTreeNodeClass &NodeClass);
        void __fastcall TreeViewCustomDraw(TCustomTreeView *Sender,
          const TRect &ARect, bool &DefaultDraw);
        void __fastcall TreeViewCustomDrawItem(TCustomTreeView *Sender,
          TTreeNode *Node, TCustomDrawState State, bool &DefaultDraw);
        void __fastcall TreeViewDblClick(TObject *Sender);
        void __fastcall TreeViewDeletion(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewDragDrop(TObject *Sender, TObject *Source,
          int X, int Y);
        void __fastcall TreeViewDragOver(TObject *Sender, TObject *Source,
          int X, int Y, TDragState State, bool &Accept);
        void __fastcall TreeViewEdited(TObject *Sender, TTreeNode *Node,
          AnsiString &S);
        void __fastcall TreeViewEditing(TObject *Sender, TTreeNode *Node,
          bool &AllowEdit);
        void __fastcall TreeViewEndDock(TObject *Sender, TObject *Target,
          int X, int Y);
        void __fastcall TreeViewEndDrag(TObject *Sender, TObject *Target,
          int X, int Y);
        void __fastcall TreeViewEnter(TObject *Sender);
        void __fastcall TreeViewExit(TObject *Sender);
        void __fastcall TreeViewExpanded(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewExpanding(TObject *Sender,
          TTreeNode *Node, bool &AllowExpansion);
        void __fastcall TreeViewGetImageIndex(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewGetSelectedIndex(TObject *Sender,
          TTreeNode *Node);
        void __fastcall TreeViewKeyDown(TObject *Sender, WORD &Key,
          TShiftState Shift);
        void __fastcall TreeViewKeyPress(TObject *Sender, char &Key);
        void __fastcall TreeViewKeyUp(TObject *Sender, WORD &Key,
          TShiftState Shift);
        void __fastcall TreeViewMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall TreeViewMouseMove(TObject *Sender,
          TShiftState Shift, int X, int Y);
        void __fastcall TreeViewMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall TreeViewStartDock(TObject *Sender,
          TDragDockObject *&DragObject);
        void __fastcall TreeViewStartDrag(TObject *Sender,
          TDragObject *&DragObject);
        void __fastcall ButtonFocusedClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        TColor
          ColorOfComboBox,
          ColorOfPageControl,
          ColorOfTabSheet,
          ColorOfListView,
          ColorOfDateTimePicker,
          ColorOfEdit,
          ColorOfCheckBox,
          ColorOfUpDown,
          ColorOfOnIdle,
          ColorOfTreeView;

        void __fastcall WriteToLog(AnsiString aStr, TColor aColor=clBlack, Graphics::TFontStyles aFontStyle=Graphics::TFontStyles());
        void __fastcall AppOnIdle(TObject *Sender, bool &Done);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
