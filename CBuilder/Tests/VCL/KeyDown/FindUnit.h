//---------------------------------------------------------------------------

#ifndef FindUnitH
#define FindUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>

#include "MyEdit.h"
//---------------------------------------------------------------------------
class TFindForm : public TForm
{
__published:	// IDE-managed Components
        TLabel *LabelSearch;
        TLabel *LabelInfoKeyDown;
        TLabel *LabelInfoKeyUp;
        void __fastcall EditSearchKeyDown(TObject *Sender, WORD &Key, TShiftState Shift);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall EditSearchChange(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
private:	// User declarations
        void __fastcall MyOnKeyDown(TWMKeyDown& Message);
        void __fastcall MyOnKeyUp(TWMKeyUp& Message);
public:		// User declarations
        __fastcall TFindForm(TComponent* Owner);

        BEGIN_MESSAGE_MAP
          MESSAGE_HANDLER(WM_KEYDOWN,TWMKeyDown,MyOnKeyDown);
          MESSAGE_HANDLER(WM_KEYUP,TWMKeyUp,MyOnKeyUp);
        END_MESSAGE_MAP(TComponent)

        TMyEdit *EditSearch;
};
//---------------------------------------------------------------------------
extern PACKAGE TFindForm *FindForm;
//---------------------------------------------------------------------------
#endif
