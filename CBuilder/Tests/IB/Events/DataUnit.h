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
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction;
        TIBQuery *IBQuery;
        TIBEvents *IBEvents;
        TIBQuery *IBViewQuery;
        TDataSource *DataSource;
        void __fastcall DataModuleDestroy(TObject *Sender);
        void __fastcall IBEventsEventAlert(TObject *Sender,
          AnsiString EventName, int EventCount, bool &CancelAlerts);
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
