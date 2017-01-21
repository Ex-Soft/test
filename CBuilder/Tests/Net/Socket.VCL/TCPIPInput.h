//---------------------------------------------------------------------------
#ifndef TCPIPInputH
#define TCPIPInputH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
#include <Mask.hpp>
//---------------------------------------------------------------------------
class TPreference1 : public TForm
{
__published:	// IDE-managed Components
    TBitBtn *BitBtn1;
    TBitBtn *BitBtn2;
    TEdit *NickName;
    TRadioGroup *RadioGroup1;
    TRadioButton *IsServer;
    TRadioButton *IsClient;
    TLabel *Label2;
    void __fastcall IsServerClick(TObject *Sender);
    void __fastcall IsClientClick(TObject *Sender);
    
    void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
    void __fastcall BitBtn1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
    __fastcall TPreference1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TPreference1 *Preference1;
//---------------------------------------------------------------------------
#endif
