//---------------------------------------------------------------------------

#ifndef MainFormH
#define MainFormH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPanel *PanelLog;
        TMemo *MemoLog;
        TImage *TestImage;
        TButton *ButtonGetInfo;
        TButton *ButtonLoadImage;
        TCheckBox *CheckBoxAutoSize;
        TButton *ButtonDrawGrid;
        TGroupBox *GroupBoxGridSettings;
        TLabel *LabelPenWidth;
        TLabel *LabelPadding;
        TEdit *EditPenWidth;
        TEdit *EditPadding;
        TLabel *LabelLength;
        TEdit *EditLength;
        TButton *ButtonClear;
        TButton *ButtonDoIt;
        void __fastcall ButtonGetInfoClick(TObject *Sender);
        void __fastcall ButtonLoadImageClick(TObject *Sender);
        void __fastcall CheckBoxAutoSizeClick(TObject *Sender);
        void __fastcall ButtonDrawGridClick(TObject *Sender);
        void __fastcall ButtonClearClick(TObject *Sender);
        void __fastcall ButtonDoItClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
