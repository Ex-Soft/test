//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <DB.hpp>
#include <DBTables.hpp>
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TQuery *Query;
        TDataSource *DataSource;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);

protected:
        void __fastcall MyDBNotify(TDatabaseEvent DBEvent, const void *Param);
        void __fastcall MyDB_BeforeConnect(TObject *Sender);

};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
