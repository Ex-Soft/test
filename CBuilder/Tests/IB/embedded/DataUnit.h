//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DB.hpp>
#include <IBDatabase.hpp>
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
