//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <DB.hpp>
#include <IBCustomDataSet.hpp>
#include <IBDatabase.hpp>
#include <IBQuery.hpp>
#include <IBServices.hpp>
#include <IBSQL.hpp>
#include <IBStoredProc.hpp>
//---------------------------------------------------------------------------

class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction;
        TIBSQL *IBSQL1;
        TIBStoredProc *IBStoredProc;
        TIBSecurityService *IBSecurityService;
        TIBServerProperties *IBServerProperties;
        TIBSQL *IBSQL2;
        TIBQuery *IBQuery1;
        TIBQuery *IBQuery2;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);
        AnsiString IBUser,IBUserPassword,IBServerName,IBDatabaseName;
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
