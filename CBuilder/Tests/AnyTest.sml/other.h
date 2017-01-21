//---------------------------------------------------------------------------

#ifndef otherH
#define otherH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TOtherForm : public TForm
{
__published:	// IDE-managed Components
        TBitBtn *ForReallyAnyTestBitBtn;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall ForReallyAnyTestBitBtnClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
public:		// User declarations
        __fastcall TOtherForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TOtherForm *OtherForm;
//---------------------------------------------------------------------------
#endif
