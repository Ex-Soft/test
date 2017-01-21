//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TButton *ButtonOpen;
        TButton *ButtonClose;
        TButton *ButtonLoad;
        TButton *ButtonFree;
        TButton *ButtonEnabled;
        TButton *ButtonDisabled;
        void __fastcall ButtonOpenClick(TObject *Sender);
        void __fastcall ButtonCloseClick(TObject *Sender);
        void __fastcall ButtonLoadClick(TObject *Sender);
        void __fastcall ButtonFreeClick(TObject *Sender);
        void __fastcall ButtonEnabledDisabledClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        HINSTANCE
          dllInstance;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
