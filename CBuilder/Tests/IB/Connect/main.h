//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DB.hpp>
#include <DBGrids.hpp>
#include <Grids.hpp>
#include <IBCustomDataSet.hpp>
#include <IBDatabase.hpp>
#include <IBQuery.hpp>
#include <IBSQLMonitor.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TIBDatabase *IBDatabase;
        TIBTransaction *IBTransaction;
        TIBQuery *IBQuery;
        TDataSource *DataSource;
        TDBGrid *DBGrid;
        TLabel *LabelPrompt;
        TEdit *EditInput;
        TIBSQLMonitor *IBSQLMonitor;
        TMemo *Memo;
        void __fastcall EditInputChange(TObject *Sender);
        void __fastcall IBSQLMonitorSQL(AnsiString EventText,
          TDateTime EventTime);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        bool __fastcall ConnectToDatabase(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
