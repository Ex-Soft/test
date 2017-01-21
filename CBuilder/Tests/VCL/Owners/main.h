//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include <Grids.hpp>
#include "Frame.h"
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControlMainForm;
        TEdit *EditMainForm;
        TComboBox *ComboBoxMainForm;
        TGroupBox *GroupBoxMainForm;
        TDateTimePicker *DateTimePickerMainForm;
        TEdit *EditGroupBoxMainForm;
        TComboBox *ComboBoxGroupBoxMainForm;
        TDateTimePicker *DateTimePickerGroupBoxMainForm;
        TTabSheet *TabSheet1;
        TEdit *EditTabSheet1;
        TComboBox *ComboBoxTabSheet1;
        TDateTimePicker *DateTimePickerTabSheet1;
        TGroupBox *GroupBoxTabSheet1;
        TEdit *EditGroupBoxTabSheet1;
        TComboBox *ComboBoxGroupBoxTabSheet1;
        TDateTimePicker *DateTimePickerGroupBoxTabSheet1;
        TTabSheet *TabSheet2;
        TEdit *EditTabSheet2;
        TComboBox *ComboBoxTabSheet2;
        TDateTimePicker *DateTimePickerTabSheet2;
        TGroupBox *GroupBoxTabSheet2;
        TEdit *EditGroupBoxTabSheet2;
        TComboBox *ComboBoxGroupBoxTabSheet2;
        TDateTimePicker *DateTimePickerGroupBoxTabSheet2;
        TButton *ShowTreeButton;
        TTabSheet *TabSheet3;
        TTreeView *TreeView1;
        TButton *ShowControlButton;
        TTabSheet *TabSheet4;
        TMemo *ShowControlMemo;
        TRadioGroup *RadioGroupMainForm;
        TRadioGroup *RadioGroupGroupBoxMainForm;
        TStringGrid *StringGridTabSheet1;
        TTabSheet *TabSheet5;
        TFrameTest *FrameTest1;
        void __fastcall ShowTreeButtonClick(TObject *Sender);
        void __fastcall ShowControlButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
