using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;

namespace TestVGrid
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();

            var categoryRow = new CategoryRow("CategoryRow1");
            vGridControl.Rows.Add(categoryRow);

            var editRow1 = new EditorRow { Name = "EditorRow1" };
            editRow1.Properties.Caption = "EditorRow1";
            editRow1.Properties.Value = 1;
            editRow1.Properties.RowEdit = new RepositoryItemTextEdit();
            categoryRow.ChildRows.Add(editRow1);

            var editRow2 = new EditorRow { Name = "EditorRow2" };
            editRow2.Properties.Caption = "EditorRow2";
            editRow2.Properties.Value = 2;
            editRow2.Properties.RowEdit = new RepositoryItemTextEdit();
            categoryRow.ChildRows.Add(editRow2);

            var editRow3 = new EditorRow { Name = "EditorRow3" };
            editRow3.Properties.Caption = "EditorRow3";
            editRow3.Properties.Value = 3;
            editRow3.Properties.RowEdit = new RepositoryItemTextEdit();
            categoryRow.ChildRows.Add(editRow3);
        }
    }
}
