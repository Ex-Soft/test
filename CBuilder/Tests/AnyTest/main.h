//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------

#include <Buttons.hpp>
#include <Classes.hpp>
#include <ComCtrls.hpp>
#include <Controls.hpp>
#include <ExtCtrls.hpp>
#include <Graphics.hpp>
#include <Grids.hpp>
#include <ImgList.hpp>
#include <Menus.hpp>
#include <StdCtrls.hpp>
#include <ToolWin.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------

class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TMainMenu *MainMenu1;
        TMenuItem *N1;
        TMenuItem *N12;
        TMenuItem *N13;
        TMenuItem *N14;
        TPageControl *AllPageControl;
        TTabSheet *ControlBarTabSheet;
        TControlBar *ControlBar1;
        TCoolBar *CoolBar2;
        TEdit *CoolBar2Left;
        TEdit *CoolBar2Width;
        TCoolBar *CoolBar1;
        TEdit *CoolBar1Left;
        TEdit *CoolBar1Width;
        TTabSheet *StringGridTabSheet;
        TStringGrid *StringGridData;
        TImageList *PageControlImageList;
        TTabSheet *ToolBarTabSheet;
        TToolBar *ToolBar1;
        TToolButton *ToolButton1;
        TMenuItem *N2;
        TMenuItem *N21;
        TMenuItem *N22;
        TMenuItem *N23;
        TMenuItem *N24;
        TMenuItem *N11;
        TToolButton *ToolButton2;
        TTabSheet *AlphaBlendTabSheet;
        TButton *StartAlphaBlendButton;
        TMemo *Memo1;
        TCheckBox *UseTransparentColorCheckBox;
        TTabSheet *ForReallyAnyTestTabSheet;
        TBitBtn *ForReallyAnyTestBitBtn;
        TDateTimePicker *StringGridDateTimePicker;
        TPopupMenu *VerticalTextPopupMenu;
        TMenuItem *Example1PopupMenuBar;
        TMenuItem *Example2PopupMenuBar;
        TMenuItem *Example3PopupMenuBar;
        TMenuItem *Example4PopupMenuBar;
        TMenuItem *Example5PopupMenuBar;
        TTabSheet *SharedTabSheet;
        TListBox *ListBox1;
        TButton *Button1;
        TMenuItem *N15;
        TMenuItem *N151;
        TMenuItem *N152;
        TMenuItem *N153;
        TMenuItem *N154;
        TMenuItem *N155;
        TTabSheet *TabSheetImage;
        TOpenDialog *OpenDialog;
        TButton *ButtonImageLoad;
        TImage *Image1;
        TSpeedButton *SpeedButton1;
        TSpeedButton *SpeedButton2;
        TSpeedButton *SpeedButton3;
        TButton *ButtonSetter;
        TButton *ButtonGetter;
        void __fastcall FormShow(TObject *Sender);
        void __fastcall ControlBar1BandMove(TObject *Sender, TControl *Control, TRect &ARect);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall StartAlphaBlendButtonClick(TObject *Sender);
        void __fastcall StringGridDataSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect);
        void __fastcall StringGridDateTimePickerExit(TObject *Sender);
        void __fastcall StringGridDataDrawCell(TObject *Sender, int ACol, int ARow, TRect &Rect, TGridDrawState State);
        void __fastcall StringGridDataMouseMove(TObject *Sender, TShiftState Shift, int X, int Y);
        void __fastcall VerticalTextPopupMenuPopup(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall ForReallyAnyTestBitBtnClick(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall ButtonImageLoadClick(TObject *Sender);
        void __fastcall OpenDialogShow(TObject *Sender);
        void __fastcall ButtonSetterClick(TObject *Sender);
private:	// User declarations
//---------------------------------------------------------------------------
// Begin 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------
        void __fastcall ExpandMenuItemWidth(TObject *Sender, TCanvas *ACanvas, int &Width, int &Height);
        void __fastcall DrawNewItem(TObject *Sender, TCanvas *ACanvas, const TRect &ARect, bool Selected);

        void CreateVerticalFont();

        TLogFont VerticalFont;
        TIcon *Icon;

        TFont *OldFont;

        TRect VerticalDrawingRect, TempRect;

        AnsiString VerticalText;

        int MenuHeight, VerticalBarLength;

        long int CheckmarkSize, OldForegroundColor, OldBackgroundColor;
        bool VerticalBarDrawn;
//---------------------------------------------------------------------------
// End 4 Adding vertical text to popup menu
//---------------------------------------------------------------------------

public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        int Row,Col;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
