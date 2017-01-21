//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <DBGrids.hpp>
#include <Grids.hpp>
#include <DBCtrls.hpp>
#include <Mask.hpp>
#include <dbcgrids.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControlMain;
        TTabSheet *TabSheetTable;
        TDBGrid *DBGridInsurant;
        TTabSheet *TabSheetLog;
        TRichEdit *RichEditLog;
        TDBText *DBText1;
        TDBEdit *DBEdit1;
        TDBMemo *DBMemo1;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall DBEdit1Change(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        TColor
          MainFormColor,
          DataUnitColor,
          IBDatabaseColor,
          IBSQLMonitorColor,
          IBTransactionColor,
          IBTableColor,
          IBDataSetColor,
          DataSourceColor,
          DBEditColor;

        void __fastcall WriteToLog(AnsiString aStr, TColor aColor=clBlack, Graphics::TFontStyles aFontStyle=Graphics::TFontStyles());
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
