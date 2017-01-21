//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
#include <ComCtrls.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *SynchronizeThreadsGroupBox;
        TRadioGroup *SynchronizeModeRadioGroup;
        TButton *SynchronizeThreadsButton;
        TListBox *ListBox1;
        TGroupBox *PriorityThreadsGroupBox;
        TLabel *FirstThreadLabel;
        TLabel *SecondThreadLabel;
        TTrackBar *SecondThreadTrackBar;
        TTrackBar *FirstThreadTrackBar;
        TProgressBar *FirstThreadProgressBar;
        TProgressBar *SecondThreadProgressBar;
        TLabel *PriorityLabel;
        TLabel *ProgressLabel;
        TButton *PriorityThreadsButton;
        void __fastcall SynchronizeThreadsButtonClick(TObject *Sender);
        void __fastcall SynchronizeModeRadioGroupClick(TObject *Sender);
        void __fastcall PriorityThreadsButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        
        void __fastcall ThreadsDone(TObject *Sender);
        void __fastcall PriorityDone(TObject *Sender);

        AnsiString
          ListText;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
