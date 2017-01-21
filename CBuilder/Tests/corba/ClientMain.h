//---------------------------------------------------------------------------

#ifndef ClientMainH
#define ClientMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "PostServ_c.hh"
#include <Buttons.hpp>
#include <ComCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TEdit *Edit1;
        TMemo *Memo1;
        TBitBtn *BitBtn1;
        TStatusBar *StatusBar1;
        void __fastcall BitBtn1Click(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
private:	// User declarations
        PostModule::Post_ptr __fastcall Getpost();
        PostModule::Post_var Fpost;
        void __fastcall Setpost(PostModule::Post_ptr _ptr);
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
        __property PostModule::Post_ptr post = {read=Getpost, write=Setpost};
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
