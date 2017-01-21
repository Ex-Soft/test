//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
#include <DBGrids.hpp>
#include <Grids.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TBitBtn *InsertBitBtn;
        TBitBtn *DeleteBitBtn;
        TBitBtn *UpdateBitBtn;
        TEdit *IBServerName;
        TBitBtn *OpenBitBtn;
        TEdit *IBDatabaseName;
        TTimer *Timer1;
        TEdit *Events;
        TEdit *EventCount;
        TEdit *CancelAlerts;
        TDBGrid *DBGrid;
        TBitBtn *RefreshBitBtn;
        TCheckBox *UseEventsCheckBox;
        TCheckBox *CommitCheckBox;
        void __fastcall InsertBitBtnClick(TObject *Sender);
        void __fastcall DeleteBitBtnClick(TObject *Sender);
        void __fastcall UpdateBitBtnClick(TObject *Sender);
        void __fastcall OpenBitBtnClick(TObject *Sender);
        void __fastcall Timer1Timer(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall RefreshBitBtnClick(TObject *Sender);
        void __fastcall UseEventsCheckBoxClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        int IBCount,IBEvent,IBEventCount;
        bool IBCancelAlerts;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
