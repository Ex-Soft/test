//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Db.hpp>
#include <IBDatabase.hpp>
#include <IBQuery.hpp>
#include <IBCustomDataSet.hpp>
#include <IBEvents.hpp>
#include <IBTable.hpp>
#include <DB.hpp>
#include <IBSQL.hpp>
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction;
        TIBSQL *IBSQL;
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);
        bool __fastcall OpenDatbase(void);
        AnsiString IBUser,IBUserPassword,IBServerName,IBDatabaseName;
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
