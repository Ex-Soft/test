//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------

#include <Buttons.hpp>
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
//---------------------------------------------------------------------------

class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TBitBtn *ForReallyAnyTestBitBtn;
        TCheckBox *caFreeCheckBox;
        TCheckBox *ModalCheckBox;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall ForReallyAnyTestBitBtnClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall FormActivate(TObject *Sender);
        void __fastcall FormCloseQuery(TObject *Sender, bool &CanClose);
        void __fastcall FormDeactivate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall FormHide(TObject *Sender);
        void __fastcall FormPaint(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall FormResize(TObject *Sender);
        void __fastcall FormCanResize(TObject *Sender, int &NewWidth,
          int &NewHeight, bool &Resize);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        void __fastcall OnAppException(TObject *Sender, Exception *eException);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
