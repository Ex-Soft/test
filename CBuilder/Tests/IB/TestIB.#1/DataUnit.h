//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <DB.hpp>
#include <IBDatabase.hpp>
#include <IBSQL.hpp>
#include <IBDatabaseInfo.hpp>
#include <IBExtract.hpp>
#include <IBCustomDataSet.hpp>
#include <IBStoredProc.hpp>
#include <IBQuery.hpp>
#include <IBTable.hpp>
#include "IBDatabaseINI.hpp"
#include "IBFilterDialog.hpp"
#include "IBScript.hpp"
//---------------------------------------------------------------------------
class TDataBases : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction1;
        TIBSQL *IBSQL1;
        TIBTransaction *IBTransaction2;
        TIBSQL *IBSQL2;
        TIBDatabaseInfo *IBDatabaseInfo;
        TIBExtract *IBExtract;
        TIBStoredProc *IBStoredProc1;
        TIBStoredProc *IBStoredProc2;
        TIBTable *IBTable;
        TIBQuery *IBQuery;
        TIBTable *IBTableDBF;
        TIBFilterDialog *IBFilterDialog;
        TIBScript *IBScript;
        TIBSQLParser *IBSQLParser;
        TIBDatabaseINI *IBDatabaseINI;
        void __fastcall DataModuleDestroy(TObject *Sender);
        void __fastcall IBScriptExecuteError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex, bool &Ignore);
        void __fastcall IBScriptParamCheck(TIBScript *Sender, bool &Pause);
        void __fastcall IBScriptParse(TObject *Sender, TIBParseKind AKind, AnsiString SQLText);
        void __fastcall IBScriptParseError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex);
        void __fastcall IBSQLParserError(TObject *Sender, AnsiString Error, AnsiString SQLText, int LineIndex);
        void __fastcall IBSQLParserParse(TObject *Sender, TIBParseKind AKind, AnsiString SQLText);
        void __fastcall IBDatabaseLogin(TIBDatabase *Database,
          TStrings *LoginParams);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBases(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBases *DataBases;
//---------------------------------------------------------------------------
#endif
