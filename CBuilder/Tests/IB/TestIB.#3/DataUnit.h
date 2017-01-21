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
#include <IBSQLMonitor.hpp>
//---------------------------------------------------------------------------
class TDataBase : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBSQLMonitor *IBSQLMonitor;
        void __fastcall IBSQLMonitorSQL(AnsiString EventText,
          TDateTime EventTime);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBase(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBase *DataBase;
//---------------------------------------------------------------------------
#endif
