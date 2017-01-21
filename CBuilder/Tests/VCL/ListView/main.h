//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <Db.hpp>
#include <DBTables.hpp>
#include <ExtCtrls.hpp>
#include <ImgList.hpp>
#include <DB.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TTable *Table1;
        TImageList *ImageListSmallImages;
        TPageControl *PageControl1;
        TTabSheet *TabSheetListView1;
        TListView *ListView1;
        TListView *ListView2;
        TTabSheet *TabSheetTreeView;
        TTreeView *TreeView1;
        TTabSheet *TabSheetListView2;
        TListView *ListViewSort;
        TRichEdit *RichEdit1;
        TButton *ButtonShowIndex;
        TButton *ButtonAdd;
        TButton *ButtonInsert;
        TButton *ButtonChange;
        TImageList *ImageListStateImages;
        void __fastcall FormShow(TObject *Sender);
        void __fastcall ListView1SelectItem(TObject *Sender,
          TListItem *Item, bool Selected);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall TreeView1DblClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall ButtonShowIndexClick(TObject *Sender);
        void __fastcall ButtonAddClick(TObject *Sender);
        void __fastcall ButtonInsertClick(TObject *Sender);
        void __fastcall ListViewSortColumnClick(TObject *Sender,
          TListColumn *Column);
        void __fastcall ListViewSortCompare(TObject *Sender,
          TListItem *Item1, TListItem *Item2, int Data, int &Compare);
        void __fastcall ButtonChangeClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);

        int ColumnToSort;
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
