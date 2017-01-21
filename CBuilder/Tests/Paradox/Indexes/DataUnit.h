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
class TDataBase : public TDataModule
{
__published:	// IDE-managed Components
        TTable *Table1;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBase(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBase *DataBase;
//---------------------------------------------------------------------------
#endif
