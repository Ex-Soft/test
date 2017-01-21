//---------------------------------------------------------------------------

#ifndef SSlH
#define SSlH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <IdBaseComponent.hpp>
#include <IdComponent.hpp>
#include <IdMessage.hpp>
#include <IdMessageClient.hpp>
#include <IdPOP3.hpp>
#include <IdTCPClient.hpp>
#include <IdTCPConnection.hpp>
#include <IdSMTP.hpp>
#include <IdIntercept.hpp>
#include <IdLogBase.hpp>
#include <IdLogDebug.hpp>
//---------------------------------------------------------------------------
class TForm11 : public TForm
{
__published:	// IDE-managed Components
        TIdMessage *IdMessage1;
        TIdSMTP *IdSMTP1;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
        AnsiString __fastcall GetParamValue(AnsiString Param);
        bool       __fastcall GetParamExists(AnsiString Param);
public:		// User declarations
        __fastcall TForm11(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm11 *Form11;
extern int ret;
//---------------------------------------------------------------------------
#endif
