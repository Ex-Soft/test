//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DB.hpp>
#include <DBTables.hpp>
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TQuery *Query1;
        TDataSource *DataSource1;
        TQuery *QuerySetGet;
        TTable *Table1;
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
