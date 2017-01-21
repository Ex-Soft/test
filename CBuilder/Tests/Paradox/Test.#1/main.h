//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <DBGrids.hpp>
#include <Grids.hpp>
#include <ComCtrls.hpp>
#include <Menus.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TMainMenu *MainMenu;
        TPageControl *PageControl1;
        TTabSheet *TabSheetQuery;
        TDBGrid *DBGrid1;
        TMenuItem *File1;
        TMenuItem *Exit1;
        TTabSheet *TabSheetSetGet;
        TGroupBox *GroupBoxSetGet;
        TLabel *LabelEditSetGet;
        TCheckBox *CheckBoxASCII;
        TButton *ButtonSetGet;
        TRadioButton *RadioButtonSet;
        TRadioButton *RadioButtonGet;
        TEdit *EditValue;
        TLabel *LabelId;
        TEdit *EditId;
        void __fastcall Exit1Click(TObject *Sender);
        void __fastcall ButtonSetGetClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
