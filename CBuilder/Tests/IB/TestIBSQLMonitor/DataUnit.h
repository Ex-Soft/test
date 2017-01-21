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
#include <IBSQL.hpp>
//---------------------------------------------------------------------------
class TDataBase : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction;
        TIBSQL *IBSQL;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBase(TComponent* Owner);

        void __fastcall CloseIB(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBase *DataBase;
//---------------------------------------------------------------------------
#endif
