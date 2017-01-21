//---------------------------------------------------------------------------

#ifndef DataUnitH
#define DataUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DB.hpp>
#include <IBCustomDataSet.hpp>
#include <IBDatabase.hpp>
#include <IBQuery.hpp>
#include <IBTable.hpp>
#include <IBSQLMonitor.hpp>
#include <IBSQL.hpp>
//---------------------------------------------------------------------------
class TDataBase : public TDataModule
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransactionRead;
        TIBTransaction *IBTransactionWrite;
        TIBTable *IBTableInsurant;
        TIBDataSet *IBDataSetInsurant;
        TIBTable *IBTableJuridPerson;
        TIBTable *IBTableNaturPerson;
        TIBQuery *IBQueryNaturPerson;
        TIBQuery *IBQueryJuridPerson;
        TIBQuery *IBQueryInsurant;
        TIBSQLMonitor *IBSQLMonitor;
        TDataSource *DataSourceInsurant;
        TDataSource *DataSourceJuridPerson;
        TDataSource *DataSourceNaturPerson;
        TIBSQL *IBSQLInsurant;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
        void __fastcall IBDatabaseAfterConnect(TObject *Sender);
        void __fastcall IBDatabaseAfterDisconnect(TObject *Sender);
        void __fastcall IBDatabaseBeforeConnect(TObject *Sender);
        void __fastcall IBDatabaseBeforeDisconnect(TObject *Sender);
        void __fastcall IBDatabaseDialectDowngradeWarning(TObject *Sender);
        void __fastcall IBDatabaseIdleTimer(TObject *Sender);
        void __fastcall IBDatabaseLogin(TIBDatabase *Database, TStrings *LoginParams);
        void __fastcall IBSQLMonitorSQL(AnsiString EventText, TDateTime EventTime);
        void __fastcall IBTransactionReadIdleTimer(TObject *Sender);
        void __fastcall IBTableInsurantAfterCancel(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterClose(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterDatabaseDisconnect(TObject *Sender);
        void __fastcall IBTableInsurantAfterDelete(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterEdit(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterInsert(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterOpen(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterPost(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterRefresh(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterScroll(TDataSet *DataSet);
        void __fastcall IBTableInsurantAfterTransactionEnd(TObject *Sender);
        void __fastcall IBTableInsurantBeforeCancel(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeClose(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeDatabaseDisconnect(TObject *Sender);
        void __fastcall IBTableInsurantBeforeDelete(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeEdit(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeInsert(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeOpen(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforePost(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeRefresh(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeScroll(TDataSet *DataSet);
        void __fastcall IBTableInsurantBeforeTransactionEnd(TObject *Sender);
        void __fastcall IBTableInsurantDatabaseFree(TObject *Sender);
        void __fastcall IBTableInsurantCalcFields(TDataSet *DataSet);
        void __fastcall IBTableInsurantDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBTableInsurantEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBTableInsurantFilterRecord(TDataSet *DataSet, bool &Accept);
        void __fastcall IBTableInsurantNewRecord(TDataSet *DataSet);
        void __fastcall IBTableInsurantPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBTableInsurantUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction);
        void __fastcall IBTableInsurantUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction);
        void __fastcall IBTableInsurantTransactionFree(TObject *Sender);
        void __fastcall IBDataSetInsurantAfterCancel(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterClose(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterDatabaseDisconnect(TObject *Sender);
        void __fastcall IBDataSetInsurantAfterDelete(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterEdit(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterInsert(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterOpen(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterPost(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterRefresh(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterScroll(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantAfterTransactionEnd(TObject *Sender);
        void __fastcall IBDataSetInsurantBeforeCancel(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeClose(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeDatabaseDisconnect(TObject *Sender);
        void __fastcall IBDataSetInsurantBeforeDelete(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeEdit(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeInsert(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeOpen(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforePost(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeRefresh(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeScroll(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantBeforeTransactionEnd(TObject *Sender);
        void __fastcall IBDataSetInsurantDatabaseFree(TObject *Sender);
        void __fastcall IBDataSetInsurantCalcFields(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantDeleteError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBDataSetInsurantEditError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBDataSetInsurantFilterRecord(TDataSet *DataSet, bool &Accept);
        void __fastcall IBDataSetInsurantNewRecord(TDataSet *DataSet);
        void __fastcall IBDataSetInsurantPostError(TDataSet *DataSet, EDatabaseError *E, TDataAction &Action);
        void __fastcall IBDataSetInsurantUpdateError(TDataSet *DataSet, EDatabaseError *E, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction);
        void __fastcall IBDataSetInsurantUpdateRecord(TDataSet *DataSet, TUpdateKind UpdateKind, TIBUpdateAction &UpdateAction);
        void __fastcall IBDataSetInsurantTransactionFree(TObject *Sender);
        void __fastcall DataSourceInsurantDataChange(TObject *Sender, TField *Field);
        void __fastcall DataSourceInsurantStateChange(TObject *Sender);
        void __fastcall DataSourceInsurantUpdateData(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataBase(TComponent* Owner);
        void __fastcall OpenDatabase(void);
        void __fastcall CloseDatabase(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataBase *DataBase;
//---------------------------------------------------------------------------
#endif
