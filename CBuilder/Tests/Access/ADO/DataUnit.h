//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ADODB.hpp>
#include <DB.hpp>
//---------------------------------------------------------------------------
class TDataBase : public TDataModule
{
__published:	// IDE-managed Components
        TADOQuery *ADOQuery1;
        TADOConnection *ADOConnection;
        void __fastcall DataModuleDestroy(TObject *Sender);
        void __fastcall DataModuleCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBase(TComponent* Owner);

        AnsiString
          Provider,
          ConnectionString;
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBase *DataBase;
//---------------------------------------------------------------------------
#endif
