//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControlStringGrid;
        TTabSheet *TabSheetSelfDraw;
        TTabSheet *TabSheetOns;
        TStringGrid *StringGrid;
        TButton *TestButton;
        TStringGrid *StringGridOns;
        TSplitter *SplitterH;
        TRichEdit *RichEdit1;
        TTabSheet *TabSheetRunTime;
        TStringGrid *StringGridRunTime;
        TTabSheet *TabSheetIntegrate;
        TStringGrid *StringGridIntegrate;
        TComboBox *ComboBoxIntegrate;
        TComboBox *ComboBoxIntegrateSelfDraw;
        void __fastcall StringGridDrawCell(TObject *Sender, int ACol, int ARow, TRect &Rect, TGridDrawState State);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall StringGridOnsGetEditMask(TObject *Sender, int ACol, int ARow, AnsiString &Value);
        void __fastcall StringGridOnsGetEditText(TObject *Sender, int ACol, int ARow, AnsiString &Value);
        void __fastcall StringGridOnsSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect);
        void __fastcall StringGridOnsSetEditText(TObject *Sender, int ACol, int ARow, const AnsiString Value);
        void __fastcall StringGridRunTimeKeyDown(TObject *Sender, WORD &Key, TShiftState Shift);
        void __fastcall StringGridRunTimeSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect);
        void __fastcall StringGridOnsDblClick(TObject *Sender);
        void __fastcall StringGridIntegrateSelectCell(TObject *Sender,
          int ACol, int ARow, bool &CanSelect);
        void __fastcall ComboBoxIntegrateExit(TObject *Sender);
        void __fastcall ComboBoxIntegrateSelfDrawDrawItem(
          TWinControl *Control, int Index, TRect &Rect,
          TOwnerDrawState State);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        void __fastcall WriteToLog(AnsiString aStr, TColor aColor=clBlack, Graphics::TFontStyles aFontStyle=Graphics::TFontStyles());
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
