//---------------------------------------------------------------------------

#ifndef childH
#define childH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <Controls.hpp>
#include <Forms.hpp>
#include "FrameTst.h"
#include "VictimLabel.h"
//---------------------------------------------------------------------------

class TChildForm : public TForm
{
__published:	// IDE-managed Components
        TTestFrame *TestFrameWithException;
        void __fastcall FormActivate(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDeactivate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall FormHide(TObject *Sender);
        void __fastcall FormPaint(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TChildForm(TComponent* Owner, int aInt1=0, int aInt2=0);
};
//---------------------------------------------------------------------------
extern PACKAGE TChildForm *ChildForm;
//---------------------------------------------------------------------------
#endif
