//---------------------------------------------------------------------------
#ifndef TCPIPInput2H
#define TCPIPInput2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <Mask.hpp>
//---------------------------------------------------------------------------
class TPreference2 : public TForm
{
__published:	// IDE-managed Components
    TMaskEdit *IPAddress_1;
    TBitBtn *BitBtn1;
    TBitBtn *BitBtn2;
    TLabel *Label1;
    TLabel *Label2;
    TMaskEdit *IPAddress_2;
    TLabel *Label3;
    TMaskEdit *IPAddress_3;
    TMaskEdit *IPAddress_4;
    TLabel *Label4;
        TLabel *Label5;
        TEdit *EditHost;
    void __fastcall BitBtn1Click(TObject *Sender);
    void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
public:		// User declarations
    __fastcall TPreference2(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TPreference2 *Preference2;
//---------------------------------------------------------------------------
#endif
