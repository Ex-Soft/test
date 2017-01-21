//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <ComCtrls.hpp>
#include <Controls.hpp>
#include <ExtCtrls.hpp>
#include <ImgList.hpp>
#include <StdCtrls.hpp>
#include <CheckLst.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------

class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TImageList *ControlPageImageList;
        TPageControl *LeftPageControl;
        TTabSheet *LeftTabSheet1;
        TRichEdit *RichEdit;
        TTabSheet *LeftTabSheet2;
        TTabSheet *TabSheet3;
        TSplitter *SplitterV;
        TPageControl *MainRightPageControl;
        TTabSheet *MainRightTabSheet1;
        TPageControl *RightPageControl1;
        TTabSheet *RightTabSheet1;
        TListView *BottomListView;
        TSplitter *SplitterH;
        TListView *TopListView;
        TTabSheet *RightTabSheet2;
        TCheckListBox *CheckListBox1;
        TScrollBox *ScrollBox1;
        TCheckBox *CheckBox1;
        TCheckBox *CheckBox2;
        TCheckBox *CheckBox3;
        void __fastcall PageControlDrawTab(TCustomTabControl *Control, int TabIndex, const TRect &Rect, bool Active);
        void __fastcall PageControlResize(TObject *Sender);
        void __fastcall LeftPageControlChange(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall CheckListBox1MouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
        void __fastcall CheckListBox1Click(TObject *Sender);
        void __fastcall CheckListBox1ClickCheck(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        int
          CheckListBoxItemIndex;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
