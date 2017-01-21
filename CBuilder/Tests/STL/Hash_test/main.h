//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------

typedef void (__closure *FieldHandler)();
//---------------------------------------------------------------------------

class TMainForm : public TForm
{
__published:    // IDE-managed Components
    TButton *Button1;
    void __fastcall Button1Click(TObject *Sender);

private:
    void A();
    void B();
    void C();

public:
    __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
